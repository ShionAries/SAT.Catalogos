using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos {
    public class Injectors : IInjectorInterface {
        public Injectors() {
            this.Items = new List<IInjectorInterface>();
        }

        public List<IInjectorInterface> Items { get; set; }

        public int Inject(string logger) {
            foreach (var item in this.Items) {
                item.Inject(logger);
            }
            return 0;
        }

        public void Validate() {
            
        }
    }
}
