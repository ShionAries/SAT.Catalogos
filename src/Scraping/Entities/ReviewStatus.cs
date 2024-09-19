using Jaeger.SAT.Catalogos.Scraping.ValueObjects;

namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    public class ReviewStatus {
        protected internal StatusEnum _Status;
        

        public ReviewStatus(StatusEnum status) {
            this._Status = status;
        }

        public ReviewStatus Uptodate() {
            this._Status = StatusEnum.UpToDate;
            return this;
        }

        /// <summary>
        /// no encontrado
        /// </summary>
        public ReviewStatus NotFound() {
            this._Status = StatusEnum.NotFound;
            return this;
        }

        /// <summary>
        /// sin actualizar
        /// </summary>
        public ReviewStatus NotUpdated() {
            this._Status = StatusEnum.NotUpdated;
            return this;
        }

        /// <summary>
        /// es actualizable
        /// </summary>
        public bool IsUptodate() {
            return this._Status == StatusEnum.UpToDate;
        }

        /// <summary>
        /// no encontrado
        /// </summary>
        public bool IsNotFound() {
            return this._Status == StatusEnum.NotFound;
        }

        /// <summary>
        /// no actualizado
        /// </summary>
        public bool IsNotUpdated() {
            return this._Status == StatusEnum.NotUpdated;
        }
    }
}
