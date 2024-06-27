using BackendProject.Shared.Paging;

namespace BackendProject.App.Accounts.Employees.Lecturers.Queries.Filter;

public record LecturerPagingQuery(
    int PageIndex,
    int PageSize,
    string? SortField,
    int SortOrder,
    string? SearchText,
    string Lang)
    : PagingQuery(PageIndex, PageSize, SortField, SortOrder, SearchText);