namespace Core.Model;

public class Movie_User
{
    public int User_id { get; set; }
    public string User_name { get; set; }
    public string User_last_name { get; set; }
    public string User_email { get; set; }
    public string User_password { get; set; }
    public string User_phone { get; set; }
    public string User_role { get; set; }
    public List<Movie> Movie { get; set; }
}
