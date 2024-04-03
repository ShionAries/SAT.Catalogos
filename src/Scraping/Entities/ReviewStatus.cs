namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    public class ReviewStatus {
        //protected internal string status;
        //public const string UP_TO_DATE = "UP-TO-DATE";
        //public const string NOT_FOUND = "NOT-FOUND";
        //public const string NOT_UPDATED = "NOT-UPDATED";
        protected internal StatusEnum _Status;

        public enum StatusEnum {
            UpToDate,
            NotFound,
            NotUpdated
        }

        public ReviewStatus(StatusEnum status) {
            this._Status = status;
        }

        //public ReviewStatus(string status) { }

        public ReviewStatus uptodate() {
            this._Status = StatusEnum.UpToDate;
            return this;
        }

        public ReviewStatus notFound() {
            this._Status = StatusEnum.NotFound;
            return this;
        }

        public ReviewStatus notUpdated() {
            this._Status = StatusEnum.NotUpdated;
            return this;
        }

        public bool isUptodate() {
            return this._Status == StatusEnum.UpToDate;
        }

        public bool isNotFound() {
            return this._Status == StatusEnum.NotFound;
        }

        public bool isNotUpdated() {
            return this._Status == StatusEnum.NotUpdated;
        }

    }
}
