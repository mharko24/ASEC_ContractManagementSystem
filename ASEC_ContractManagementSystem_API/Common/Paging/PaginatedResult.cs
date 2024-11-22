namespace ASEC_ContractManagementSystem_API.Common.Paging
{
    public class PaginatedResult<T> where T : class
    {
        public IEnumerable<T>? data { get; set; }
        public int pageCurrent { get; set; }
        public int numSize { get; set; }
        public string? Keyword { get; set; }
    }
}
