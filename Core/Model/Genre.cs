﻿namespace Core.Model;

public class Genre
{
    public int Genre_id { get; set; }
    public string Genre_name { get; set; }
    public Movie_Genre MovieGenre { get; set; }
}
