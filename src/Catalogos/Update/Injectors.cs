using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos.Update {
    public class Injectors : IInjectorInterface {
        public Injectors() {
            Items = new List<IInjectorInterface>();
        }

        public List<IInjectorInterface> Items { get; set; }

        public int Inject(Helpers.ILoggerInterface logger) {
            foreach (var item in Items) {
                item.Inject(logger);
            }
            return 0;
        }

        public void Validate() {

        }
    }
}
