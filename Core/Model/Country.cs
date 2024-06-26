﻿namespace Core.Model;

public class Country
{
    public int Country_id { get; set; } // PK
    public string Country_iso_code { get; set; } = string.Empty;
    public string Country_name { get; set; } = string.Empty;
    public List<Production_Country>? ProductionCountry { get; set; }
}
