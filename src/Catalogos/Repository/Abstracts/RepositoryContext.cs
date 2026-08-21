using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos {
    /// <summary>
    /// Clase contexto abstracta para la gestión y persistencia de catálogos diversos.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad del catálogo.</typeparam>
    public abstract class RepositoryContext<T> : RepositoryBase, IRepositoryContext<T> where T : class, new() {
        #region Declaraciones

        protected internal bool _Recuperar = true;
        protected internal Repository<T> _Repository;

        #endregion

        #region Constructor

        public RepositoryContext() {
            FileName = "miCatalogo.json";
            WorkingFolder = @"C:\Jaeger\Jaeger.Catalogos";
            _Repository = new Repository<T>();
        }

        #endregion

        #region Propiedades

        public string FileName { get; set; }

        public string Version {
            get { return _Repository.Version; }
            set { _Repository.Version = value; }
        }

        public string Description {
            get { return _Repository.Title; }
            set { _Repository.Title = value; }
        }

        public string Revision {
            get { return _Repository.Revision; }
            set { _Repository.Revision = value; }
        }

        public DateTime? LastUpdate {
            get { return NormalizeDate(_Repository.LastUpdate); }
            set { _Repository.LastUpdate = value ?? DateTime.MinValue; }
        }

        public string Builder => _Repository.Builder;

        public string WorkingFolder { get; set; }

        public bool Recuperar {
            get { return _Recuperar; }
            set { _Recuperar = value; }
        }

        public List<T> Items {
            get { return _Repository.Items; }
            set { _Repository.Items = value; }
        }

        #endregion

        #region Métodos Públicos

        public abstract T Search(string query);

        /// <summary>
        /// Carga la información del catálogo desde el archivo local o recurso embebido predeterminado.
        /// </summary>
        public virtual void Load() {
            string localName = ResolverName(FileName, FileName, true);

            if (File.Exists(localName)) {
                using (StreamReader reader = new StreamReader(localName, Encoding.UTF8)) {
                    string valor = reader.ReadToEnd();
                    if (!string.IsNullOrWhiteSpace(valor)) {
                        Serializer(valor);
                    }
                }
            }

            if (this.Items == null) {
                this.Items = new List<T>();
            }
        }

        /// <summary>
        /// Carga la información del catálogo especificando una ruta exacta (soporta .json y .zip).
        /// </summary>
        public virtual void Load(string fileName) {
            if (string.IsNullOrWhiteSpace(fileName))
                return;

            FileInfo fileInfo = new FileInfo(fileName);
            if (!fileInfo.Exists)
                return;

            string extension = fileInfo.Extension.ToLowerInvariant();

            if (extension == ".zip") {
                byte[] fileBytes = File.ReadAllBytes(fileName);
                string valor = Unzip(fileBytes);
                if (!string.IsNullOrEmpty(valor)) {
                    Serializer(valor);
                }
            } else if (extension == ".json") {
                string valor = File.ReadAllText(fileName, Encoding.UTF8);
                if (!string.IsNullOrEmpty(valor)) {
                    Serializer(valor);
                }
            }

            if (this.Items == null) {
                this.Items = new List<T>();
            }
        }

        /// <summary>
        /// Guarda los cambios del catálogo en formato JSON plano sin BOM.
        /// </summary>
        public virtual bool Save() {
            try {
                EnsureWorkingFolderExists();
                string destinationPath = ResolverName(FileName);
                Encoding utf8WithoutBom = new UTF8Encoding(false);

                File.WriteAllText(destinationPath, _Repository.ToJson(), utf8WithoutBom);
                return File.Exists(destinationPath);
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Guarda los cambios del catálogo comprimidos en formato ZIP.
        /// </summary>
        public virtual bool SaveZIP() {
            try {
                EnsureWorkingFolderExists();
                byte[] contenido = Zip(_Repository.ToJson());
                string destinationPath = Path.ChangeExtension(ResolverName(FileName), "zip");

                File.WriteAllBytes(destinationPath, contenido);
                return File.Exists(destinationPath);
            } catch {
                return false;
            }
        }

        public int Import(List<T> items) {
            Items = items ?? new List<T>();
            return Items.Count;
        }

        public int Import(DataTable dataTable) {
            if (dataTable == null) {
                Items = new List<T>();
                return 0;
            }

            DataNamesMapper<T> mapper = new DataNamesMapper<T>();
            Items = mapper.Map(dataTable).ToList();
            return Items.Count;
        }

        public void AddLastUpdate(DateTime? lastUpdate = null) {
            LastUpdate = lastUpdate;
        }

        #endregion

        #region Métodos de Apoyo Protegidos

        protected void EnsureWorkingFolderExists() {
            if (!Directory.Exists(WorkingFolder)) {
                Directory.CreateDirectory(WorkingFolder);
            }
        }

        protected virtual string ResolverName(string fileName) {
            if (Path.IsPathRooted(fileName))
                return fileName;

            return Path.Combine(WorkingFolder, fileName);
        }

        protected virtual string ResolverName(string fileName, string fileDefault, bool resource = true) {
            string resolvedPath = ResolverName(fileName);

            if (!File.Exists(resolvedPath)) {
                if (resource) {
                    string defaultPath = ResolverName(fileDefault);
                    if (!File.Exists(defaultPath)) {
                        if (Recuperar) {
                            if (GetResource(fileDefault, defaultPath)) {
                                return defaultPath;
                            }
                        } else {
                            Save();
                            return defaultPath;
                        }
                    } else {
                        return defaultPath;
                    }
                }
            }

            return resolvedPath;
        }

        protected virtual bool GetResource(string nameResource, string fileName) {
            EnsureWorkingFolderExists();

            string resourcePath = $"Jaeger.SAT.Catalogos.Resources.{nameResource}.zip";

            using (Stream oStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath)) {
                if (oStream != null) {
                    byte[] resourceData = ReadFully(oStream);
                    string data = Unzip(resourceData);

                    if (!string.IsNullOrEmpty(data)) {
                        Encoding utf8WithoutBom = new UTF8Encoding(false);
                        File.WriteAllText(fileName, data, utf8WithoutBom);
                    }
                }
            }

            return File.Exists(fileName);
        }

        protected virtual void Serializer(string valor) {
            _Repository = JsonConvert.DeserializeObject<Repository<T>>(valor, _jsonSettings) ?? new Repository<T>();
        }

        #endregion

        #region Gestión de Compresión (ZIP)

        protected byte[] ReadFully(Stream input) {
            using (MemoryStream ms = new MemoryStream()) {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        protected byte[] Zip(string textToZip) {
            using (MemoryStream memoryStream = new MemoryStream()) {
                using (ZipArchive zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true)) {
                    ZipArchiveEntry entry = zipArchive.CreateEntry(FileName);

                    using (Stream entryStream = entry.Open())
                    using (StreamWriter streamWriter = new StreamWriter(entryStream, new UTF8Encoding(false))) {
                        streamWriter.Write(textToZip);
                    }
                }

                return memoryStream.ToArray();
            }
        }

        protected string Unzip(byte[] zippedBuffer) {
            if (zippedBuffer == null || zippedBuffer.Length == 0)
                return null;

            using (MemoryStream zippedStream = new MemoryStream(zippedBuffer))
            using (ZipArchive archive = new ZipArchive(zippedStream, ZipArchiveMode.Read)) {
                ZipArchiveEntry entry = archive.Entries.FirstOrDefault();
                if (entry != null) {
                    using (Stream unzippedEntryStream = entry.Open())
                    using (MemoryStream ms = new MemoryStream()) {
                        unzippedEntryStream.CopyTo(ms);
                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }

            return null;
        }

        #endregion
    }
}