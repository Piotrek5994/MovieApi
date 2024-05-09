﻿namespace Core.Filter;

public class UserFilter
{
    public int? Id { get; set; }
    public int page { get; set; } = 1;
    public int limit { get; set; } = 10;
    public string SortBy { get; set; } = string.Empty;
    public int? SortDirection { get; set; }
}