using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos {
    public class Injectors : AbstractCollection, IInjectorInterface { 
        public Injectors() {
            this.Items = new List<IInjectorInterface>();
        }

        public bool Validate(IInjectorInterface member) {
            return true;
        }

        public List<IInjectorInterface> Items { get; set; }
    }
}
