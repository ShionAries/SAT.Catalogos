using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// clase contexto para el manejo de catalogos diversos
    /// </summary>
    /// <typeparam name="T">The type of the T.</typeparam>
    public interface IRepositoryContext<T> : IRepositoryGeneric where T : class, new() {
        /// <summary>
        /// obtener o establecer la version del catalogo
        /// </summary>
        new string Version { get; set; }

        /// <summary>
        /// obtener o establecer titulo del catalogo
        /// </summary>
        new string Description { get; set; }

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

        /// <summary>
        /// busqueda de elmento por su clave
        /// </summary>
        /// <param name="query">clave</param>
        /// <returns>TObject</returns>
        T Search(string query);

        /// <summary>
        /// cargar la informacion de un catalogo
        /// </summary>
        new void Load();

        /// <summary>
        /// cargar la informacion de un catalogo
        /// </summary>
        //void LoadZIP();

        /// <summary>
        /// guardar los cambios del catalogo
        /// </summary>
        new bool Save();

        bool SaveZIP();
        
        int Import(List<T> items);

        new int Import(System.Data.DataTable dataTable);
    }
}
