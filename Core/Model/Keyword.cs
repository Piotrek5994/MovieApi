﻿namespace Core.Model;

public class Keyword
{
    public int Keyword_id { get; set; }
    public string Keyword_name { get; set; } = string.Empty;
    public Movie_Keywords? MovieKeywords { get; set; }
}
