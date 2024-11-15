using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Abstracts {
    /// <summary>
    /// clase contexto para el manejo de catalogos diversos
    /// </summary>
    /// <typeparam name="T">The type of the T.</typeparam>
    public abstract class RepositoryContext<T> : IRepositoryContext<T> where T : class, new() {
        #region declaraciones
        protected internal bool _Recuperar = true;
        protected internal Repository<T> _Repository;
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        public RepositoryContext() {
            FileName = "miCatalogo.json";
            WorkingFolder = @"C:\Jaeger\Jaeger.Catalogos";
            _Repository = new Repository<T>();
        }

        #region propiedades
        /// <summary>
        /// obtener o establecer el nombre del archivo
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// obtener o establecer la version del catalogo
        /// </summary>
        public string Version {
            get {
                return _Repository.Version;
            }
            set {
                _Repository.Version = value;
            }
        }

        /// <summary>
        /// obtener o establecer titulo del catalogo
        /// </summary>
        public string Title {
            get {
                return _Repository.Title;
            }
            set {
                _Repository.Title = value;
            }
        }

        /// <summary>
        /// obtener o establecer la fecha de revision
        /// </summary>
        public string Revision {
            get {
                return _Repository.Revision;
            }
            set {
                _Repository.Revision = value;
            }
        }

        /// <summary>
        /// obtener o establecer ultima fecha de actualizacion
        /// </summary>
        public DateTime? LastUpdate {
            get {
                if (_Repository.LastUpdate >= new DateTime(1900, 1, 1))
                    return _Repository.LastUpdate;
                return null;
            }
            set { _Repository.LastUpdate = value; }
        }

        /// <summary>
        /// obtener o establecer nombre del editor
        /// </summary>
        public string Builder {
            get { return _Repository.Builder; }
        }

        /// <summary>
        /// obtener o establecer ruta de inicial donde se encuentra el catalogo
        /// </summary>
        public string WorkingFolder { get; set; }

        /// <summary>
        /// obtener o establecer si el catalogo debe ser recuperado desde los recursos de la libreria
        /// </summary>
        public bool Recuperar {
            get {
                return _Recuperar;
            }
            set {
                _Recuperar = value;
            }
        }

        /// <summary>
        /// obtener o establecer la lista de objetos
        /// </summary>
        public List<T> Items {
            get {
                return _Repository.Items;
            }
            set {
                _Repository.Items = value;
            }
        }
        #endregion

        #region metodos publicos
        public void Add(T newItem) {
            try {
                if (Items == null) {
                    Items = new List<T>();
                }
                T e = Items.FirstOrDefault((t) => t == newItem);
                if (e == null)
                    Items.Add(newItem);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// eliminar un objeto de la coleccion por la referencia de un objeto
        /// </summary>
        public bool Delete(T deleteItem) {
            try {
                Items.Remove(deleteItem);
                return true;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// eliminar un objeto de la coleccion por referencia del indice
        /// </summary>
        public bool Delete(int index) {
            try {
                Items.RemoveAt(index);
                return true;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// busqueda de elemento
        /// </summary>
        /// <param name="query">indice</param>
        /// <returns>T</returns>
        public abstract T Search(string query);

        /// <summary>
        /// cargar la informacion de un catalogo
        /// </summary>
        public virtual void Load() {
            string localName = ResolverName(FileName, FileName, true);
            if (File.Exists(localName)) {
                StreamReader oStreamReader = new StreamReader(localName);
                string valor = oStreamReader.ReadToEnd();
                oStreamReader.Close();
                if (valor.Length > 0) {
                    Serializer(valor);
                }
                if (Items == null)
                    Items = new List<T>();
            } else {
                Items = new List<T>();
            }
        }

        public virtual void Load(string fileName) {
            var fileInfo = new FileInfo(fileName);
            if (fileInfo.Exists) {
                if (fileInfo.Extension.ToLower() == ".zip") {
                    var valor = Unzip(File.ReadAllBytes(fileName));
                    if (!string.IsNullOrEmpty(valor)) {
                        Serializer(valor);
                    }
                } else if (fileInfo.Extension.ToLower() == ".json") {
                    var valor = File.ReadAllText(fileName);
                    if (!string.IsNullOrEmpty(valor)) {
                        Serializer(valor);
                    }
                }
            }
        }

        /// <summary>
        /// cargar la informacion de un catalogo
        /// </summary>
        public void LoadZIP() {
            string localName = ResolverName(FileName, FileName, true);
            if (File.Exists(localName)) {
                StreamReader oStreamReader = new StreamReader(localName);
                string valor = oStreamReader.ReadToEnd();
                oStreamReader.Close();
                if (valor.Length > 0) {
                    Serializer(valor);
                }
                if (Items == null)
                    Items = new List<T>();
            } else {
                Items = new List<T>();
            }
        }

        /// <summary>
        /// guardar los cambios del catalogo
        /// </summary>
        public bool Save() {
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            File.WriteAllText(ResolverName(FileName), _Repository.ToJson(), utf8WithoutBom);
            return false;
        }

        public bool SaveZIP() {
            var contenido = Zip(_Repository.ToJson());
            var nombre = Path.ChangeExtension(ResolverName(FileName), "zip");
            File.WriteAllBytes(nombre, contenido);
            return false;
        }

        /// <summary>
        /// restaurar el catalogo desde el proyecto
        /// </summary>
        public bool Restore() {
            return false;
        }

        public int Import(List<T> items) {
            Items = items;
            return Items.Count;
        }

        public int Import(System.Data.DataTable dataTable) {
            var mapper = new Helpers.Mapping.DataNamesMapper<T>();
            Items = mapper.Map(dataTable).ToList();
            return Items.Count;
        }
        #endregion

        #region metodos privados
        public void AddLastUpdate(DateTime? lastUpdate = null) {
            if (lastUpdate != null) {
                this.LastUpdate = lastUpdate;
            } else {
                this.LastUpdate = null;
            }
        }

        private bool GetResource(string nameResource, string fileName) {
            // sino existe la carpeta la creamos
            if (!Directory.Exists(Path.GetDirectoryName(fileName))) {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            }

            using (Stream oStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Concat("Jaeger.SAT.Catalogos.Resources.", nameResource + ".zip"))) {
                var d = Unzip(ReadFully(oStream));
                Encoding utf8WithoutBom = new UTF8Encoding(false);
                File.WriteAllText(fileName, d, utf8WithoutBom);
            }

            return File.Exists(fileName);
        }

        private string ResolverName(string fileName) {
            return Path.Combine(this.WorkingFolder, fileName);
        }

        private string ResolverName(string fileName, string fileDefault, bool resource = true) {
            string localName = fileName;
            if (File.Exists(fileName) == false) {
                if (resource) {
                    if (File.Exists(ResolverName(fileDefault)) == false) {
                        if (Recuperar == true) {
                            if (GetResource(fileDefault, ResolverName(fileDefault))) {
                                localName = ResolverName(fileDefault);
                            }
                        } else {
                            localName = ResolverName(fileDefault);
                            Save();
                        }
                    } else {
                        localName = ResolverName(fileDefault);
                    }
                }
            }
            return localName;
        }

        private void Serializer(string valor) {
            var configuration = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "dd/MM/yyyy" };
            this._Repository = JsonConvert.DeserializeObject<Repository<T>>(valor, configuration);
            this.Items = this._Repository.Items;
        }

        #region archivo zip
        private byte[] ReadFully(Stream input) {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream()) {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0) {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Zips a string into a zipped byte array.
        /// </summary>
        /// <param name="textToZip">The text to be zipped.</param>
        /// <returns>byte[] representing a zipped stream</returns>
        private byte[] Zip(string textToZip) {
            using (var memoryStream = new MemoryStream()) {
                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true)) {
                    var demoFile = zipArchive.CreateEntry(FileName);

                    using (var entryStream = demoFile.Open()) {
                        using (var streamWriter = new StreamWriter(entryStream)) {
                            streamWriter.Write(textToZip);
                        }
                    }
                }

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Unzip a zipped byte array into a string.
        /// </summary>
        /// <param name="zippedBuffer">The byte array to be unzipped</param>
        /// <returns>string representing the original stream</returns>
        private string Unzip(byte[] zippedBuffer) {
            using (var zippedStream = new MemoryStream(zippedBuffer)) {
                using (var archive = new ZipArchive(zippedStream)) {
                    var entry = archive.Entries.FirstOrDefault();

                    if (entry != null) {
                        using (var unzippedEntryStream = entry.Open()) {
                            using (var ms = new MemoryStream()) {
                                unzippedEntryStream.CopyTo(ms);
                                var unzippedArray = ms.ToArray();

                                return Encoding.UTF8.GetString(unzippedArray);
                            }
                        }
                    }

                    return null;
                }
            }
        }
        #endregion
        #endregion
    }
}
