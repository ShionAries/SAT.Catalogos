using System.Collections.Generic;
using System.Reflection;

namespace Jaeger.SAT.Catalogos {
    public class ControlLayout {
        public ControlLayout() { 
            this.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Builder = Assembly.GetExecutingAssembly().GetName().Name.ToString();
        }

        public string Version { get; set; }

        public string Builder { get; set; }

        public Configuration Configuration { get; set; }

        public List<OriginLayout> Origins { get; set; }
    }
}
