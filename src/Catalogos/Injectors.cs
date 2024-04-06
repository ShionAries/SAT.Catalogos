using Jaeger.SAT.Catalogos.Database;
using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos {
    public class Injectors : AbstractCollection, IInjectorInterface { 
        public Injectors() {
            this.Items = new List<IInjectorInterface>();
        }

        public List<IInjectorInterface> Items { get; set; }

        public int inject(Repository repository, string logger) {
            throw new System.NotImplementedException();
        }

        public void validate() {
            throw new System.NotImplementedException();
        }
    }
}
