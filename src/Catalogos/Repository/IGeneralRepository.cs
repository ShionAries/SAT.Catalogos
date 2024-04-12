namespace Jaeger.SAT.Catalogos.Repository {
    public interface IGeneralRepository {
        string Builder { get; set; }
        int Import(System.Data.DataTable dataTable);
        bool Save();
    }
}
