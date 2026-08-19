namespace Jaeger.SAT.Catalogos.Prueba.EmailApocrifo {
    public class SatSpoofedEmailInfoComparer : IEqualityComparer<SatSpoofedEmailInfo> {
        public bool Equals(SatSpoofedEmailInfo x, SatSpoofedEmailInfo y) {
            if (ReferenceEquals(x, y))
                return true;
            if (x is null || y is null)
                return false;

            // La duplicidad se define si tienen el mismo correo electrónico (case-insensitive)
            return string.Equals(x.StandsFor, y.StandsFor, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(SatSpoofedEmailInfo obj) {
            if (obj is null || obj.StandsFor is null)
                return 0;
            return obj.StandsFor.ToLowerInvariant().GetHashCode();
        }
    }
}
