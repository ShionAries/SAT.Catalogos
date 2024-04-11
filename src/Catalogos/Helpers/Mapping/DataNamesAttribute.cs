using System;
using System.Collections.Generic;
using System.Linq;

namespace Jaeger.SAT.Catalogos.Helpers.Mapping {
    public class DataNamesAttribute : Attribute {
        protected List<string> ValuesNamesField { get; set; }

        public List<string> ValueNames {
            get {
                return ValuesNamesField;
            }
            set {
                ValuesNamesField = value;
            }
        }

        public DataNamesAttribute() {
            ValuesNamesField = new List<string>();
        }

        public DataNamesAttribute(params string[] valueNames) {
            ValuesNamesField = valueNames.ToList();
        }
    }
}
