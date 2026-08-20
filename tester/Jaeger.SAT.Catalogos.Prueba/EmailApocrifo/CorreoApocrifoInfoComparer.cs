namespace Jaeger.SAT.Catalogos.Prueba.EmailApocrifo {
    public class CorreoApocrifoInfoComparer : IEqualityComparer<CorreoApocrifoInfo> {
        public bool Equals(CorreoApocrifoInfo x, CorreoApocrifoInfo y) {
            if (ReferenceEquals(x, y))
                return true;
            if (x is null || y is null)
                return false;

            // La duplicidad se define si tienen el mismo correo electrónico (case-insensitive)
            return string.Equals(x.StandsFor, y.StandsFor, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(CorreoApocrifoInfo obj) {
            if (obj is null || obj.StandsFor is null)
                return 0;
            return obj.StandsFor.ToLowerInvariant().GetHashCode();
        }
    }
}
