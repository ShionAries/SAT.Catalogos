using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// clase contexto para el manejo de catalogos diversos
    /// </summary>
    /// <typeparam name="T">The type of the T.</typeparam>
    public interface IRespositoryContext<T> where T : class, new() {
        /// <summary>
        /// obtener o establecer la version del catalogo
        /// </summary>
        string Version { get; set; }

        /// <summary>
        /// obtener o establecer titulo del catalogo
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// obtener o establecer la fecha de revision
        /// </summary>
        string Revision { get; set; }

        System.DateTime? Actualizacion { get; set; }

        string Builder { get; set; }

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

        /// <summary>
        /// cargar la informacion de un catalogo
        /// </summary>
        void Load();

        /// <summary>
        /// cargar la informacion de un catalogo
        /// </summary>
        void LoadZIP();

        /// <summary>
        /// guardar los cambios del catalogo
        /// </summary>
        bool Save();

        bool SaveZIP();

        /// <summary>
        /// restaurar el catalogo desde el proyecto
        /// </summary>
        bool Restore();

        int Import(List<T> items);

        int Import(System.Data.DataTable dataTable);
    }
}
