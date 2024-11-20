namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// interface generica para repositorio
    /// </summary>
    public interface IRepositoryGeneric {
        /// <summary>
        /// obtener o establecer la version del catalogo
        /// </summary>
        string Version { get; set; }

        /// <summary>
        /// obtener o establecer titulo del catalogo
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// obtener o establecer la fecha de revision
        /// </summary>
        string Revision { get; set; }

        System.DateTime? LastUpdate { get; set; }

        string Builder { get; }

        /// <summary>
        /// cargar la informacion de un catalogo
        /// </summary>
        void Load();

        int Import(System.Data.DataTable dataTable);

        bool Save();
    }
}
