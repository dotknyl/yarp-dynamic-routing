namespace Yarp.DynamicRouting.Core.Common.Models
{
    public record ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public record PaginatedApiResponse<T>
    {
        public bool Success { get; set; }
        public IEnumerable<T>? Data { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public int? Total { get; set; }
        public string? ErrorMessage { get; set; }
    }
}