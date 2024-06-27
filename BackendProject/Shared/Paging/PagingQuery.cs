namespace BackendProject.Shared.Paging;

public record PagingQuery(int PageIndex, int PageSize, string? SortField, int SortOrder, string? SearchText);