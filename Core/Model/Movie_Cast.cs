namespace Core.Model;

public class Movie_Cast
{
    public int Movie_id { get; set; }
    public int Person_id { get; set; }
    public string Character_name { get; set; } = string.Empty;
    public int Gender_id { get; set; }
    public int Cast_order { get; set; }
    public List<Movie>? Movies { get; set; }
    public List<Gender>? Genders { get; set; }
    public List<Person>? Persons { get; set; }
}
