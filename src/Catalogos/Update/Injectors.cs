using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos.Update {
    public class Injectors : IInjector {
        public Injectors() {
            Items = new List<IInjector>();
        }

        public List<IInjector> Items { get; set; }

        public int Inject(Helpers.ILogger logger) {
            foreach (var item in Items) {
                item.Inject(logger);
            }
            return 0;
        }

        public void Validate() {

        }
    }
}
