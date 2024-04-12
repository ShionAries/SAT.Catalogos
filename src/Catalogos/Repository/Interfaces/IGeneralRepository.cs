namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IGeneralRepository {
        string Builder { get; set; }
        int Import(System.Data.DataTable dataTable);
        bool Save();
    }
}
