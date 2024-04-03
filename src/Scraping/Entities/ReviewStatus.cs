namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    public class ReviewStatus {
        protected internal StatusEnum _Status;

        public enum StatusEnum {
            UpToDate,
            NotFound,
            NotUpdated
        }

        public ReviewStatus(StatusEnum status) {
            this._Status = status;
        }

        public ReviewStatus Uptodate() {
            this._Status = StatusEnum.UpToDate;
            return this;
        }

        public ReviewStatus NotFound() {
            this._Status = StatusEnum.NotFound;
            return this;
        }

        public ReviewStatus NotUpdated() {
            this._Status = StatusEnum.NotUpdated;
            return this;
        }

        public bool IsUptodate() {
            return this._Status == StatusEnum.UpToDate;
        }

        public bool IsNotFound() {
            return this._Status == StatusEnum.NotFound;
        }

        public bool IsNotUpdated() {
            return this._Status == StatusEnum.NotUpdated;
        }
    }
}
