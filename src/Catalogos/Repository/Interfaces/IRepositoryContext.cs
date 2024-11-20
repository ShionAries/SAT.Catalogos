using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Repository.Builder;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// clase contexto para el manejo de catalogos diversos
    /// </summary>
    /// <typeparam name="T">The type of the T.</typeparam>
    public interface IRepositoryContext<T> : IRepositoryBuilder, IRepositoryLoadBuilder, IRepositoryGeneric where T : class, new() {
        /// <summary>
        /// obtener o establecer la version del catalogo
        /// </summary>
        new string Version { get; set; }

        /// <summary>
        /// obtener o establecer titulo del catalogo
        /// </summary>
        new string Title { get; set; }

        /// <summary>
        /// obtener o establecer la fecha de revision
        /// </summary>
        new string Revision { get; set; }

        /// <summary>
        /// obtener o establecer ultima fecha de actualizacion
        /// </summary>
        new System.DateTime? LastUpdate { get; set; }

        new string Builder { get; }

        /// <summary>
        /// obtener o establecer la lista de objetos
        /// </summary>
        List<T> Items { get; set; }

        void Add(T item);

        /// <summary>
        /// eliminar un objeto de la coleccion por la referencia de un objeto
        /// </summary>
        bool Delete(T deleteItem);

        /// <summary>
        /// eliminar un objeto de la coleccion por referencia del indice
        /// </summary>
        bool Delete(int index);

        T Search(string query);

        /// <summary>
        /// cargar la informacion de un catalogo
        /// </summary>
        new void Load();

        /// <summary>
        /// cargar la informacion de un catalogo
        /// </summary>
        void LoadZIP();

        /// <summary>
        /// guardar los cambios del catalogo
        /// </summary>
        new bool Save();

        bool SaveZIP();

        /// <summary>
        /// restaurar el catalogo desde el proyecto
        /// </summary>
        bool Restore();

        int Import(List<T> items);

        new int Import(System.Data.DataTable dataTable);
    }
}
