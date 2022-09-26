﻿namespace TemplateApi.Domain.Models.Queries;

public class PaginationQuery
{
    public int PageSize { get; set; } = 10;
    public int Page { get; set; } = 1;
}
public record PaginationResponse(int Pages, int Total);
