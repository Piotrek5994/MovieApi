namespace Core.Model;

public class Movie_User
{
    public int User_id { get; set; }
    public string User_name { get; set; } = string.Empty;
    public string User_last_name { get; set; } = string.Empty;
    public string User_email { get; set; } = string.Empty;
    public string User_password { get; set; } = string.Empty;
    public string User_phone { get; set; } = string.Empty;
    public string User_role { get; set; } = string.Empty;
    public List<Movie>? Movie { get; set; }
}
