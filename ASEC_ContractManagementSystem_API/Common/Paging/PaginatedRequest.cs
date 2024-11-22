using Microsoft.AspNetCore.Mvc;

namespace ASEC_ContractManagementSystem_API.Common.Paging
{
    public class PaginatedRequest
    {
        [FromQuery(Name = "p")]
        public int PageNumber { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 10;
        [FromQuery(Name = "s")]
        public string? SearhKeyword { get; set; }
    }
}
