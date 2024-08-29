namespace Jaeger.SAT.Catalogos.Update {
    public interface IInjector {
        System.DateTime LastVersion { get; set; }
        int Inject(Helpers.ILogger logger);
    }
}
