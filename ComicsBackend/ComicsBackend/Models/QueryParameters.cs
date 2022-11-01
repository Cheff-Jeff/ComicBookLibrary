namespace ComicsBackend.Models
{
    public class QueryParameters
    {
        const int _maxSize = 100;
        private int _pageSize = 50;

        public int Page { get; set; } = 1;
        public int Size 
        {
            get { return _pageSize; }
            set { _pageSize = Math.Min(value, _maxSize); }
        }
    }
}
 