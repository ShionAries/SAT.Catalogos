using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos.Update {
    public class Injectors : IInjector {
        /// <summary>
        /// constructor
        /// </summary>
        public Injectors() {
            Items = new List<IInjector>();
        }

        /// <summary>
        /// obtener o establecer inyectores
        /// </summary>
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
