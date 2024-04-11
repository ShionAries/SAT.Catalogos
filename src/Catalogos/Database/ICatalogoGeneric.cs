using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos.Abstractions {
    public interface ICatalogoGeneric<T> where T : class, new() {
        string Version { get; set; }
        string Title { get; set; }
        string Revision { get; set; }
        System.DateTime? Actualizacion { get; set; }
        void Add(T item);

        bool Delete(T deleteItem);

        bool Delete(int index);

        void Load();

        void LoadZIP();

        bool Save();

        bool SaveZIP();

        bool Restore();

        int Import(List<T> items);
        int Import(System.Data.DataTable dataTable);
        List<T> Items { get; set; }
    }
}
