namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// Interface para clave de SAT simple
    /// </summary>
    public interface IClaveBase {
        string Clave { get; set; }
        string Descripcion { get; set; }
    }
}
