using AutoMapper;
using Core.CommandDto;
using Core.Model;
using Core.ModelDto;

namespace Infrastracture.Mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Movie_User, Movie_User_Dto>()
                 .AfterMap((src, dest) =>
                 {
                     dest.Id = src.User_id;
                     dest.Name = src.User_name;
                     dest.Last_name = src.User_last_name;
                     dest.Email = src.User_email;
                     dest.Password = src.User_password;
                     dest.Phone = src.User_phone;
                     dest.Role = src.User_role;
                 });
        CreateMap<Movie, Movie_Dto>()
                  .AfterMap((src, dest) =>
                  {
                      dest.Id = src.Movie_id;
                      dest.Title = src.Title;
                      dest.Budget = src.Budget;
                      dest.Homepage = src.Homepage;
                      dest.Overview = src.Overview;
                      dest.Popularity = src.Popularity;
                      dest.Release_date = src.Release_date;
                      dest.Revenue = src.Revenue;
                      dest.Runtime = src.Runtime;
                      dest.Status = src.Movie_status;
                      dest.Tagline = src.Tagline;
                      dest.Vote_average = src.Vote_average;
                      dest.Vote_count = src.Vote_count;
                      dest.Src_foto = src.Movie_src_foto;
                      dest.Src_video = src.Movie_src_video;
                      dest.User_id = src.User_id;
                  });
        CreateMap<Movie_Company, Movie_Company_Dto>();
        CreateMap<Production_Company, Production_Company_Dto>()
                   .AfterMap((src, dest) =>
                   {
                       dest.Id = src.Company_id;
                       dest.Company_name = src.Company_name;
                   });
        CreateMap<Movie_Cast, Movie_Cast_Dto>();
        CreateMap<Create_Movie_User_Dto, Movie_User>()
                  .AfterMap((src, dest) =>
                  {
                      dest.User_name = src.Name;
                      dest.User_last_name = src.Last_name;
                      dest.User_email = src.Email;
                      dest.User_password = src.Password;
                      dest.User_phone = src.Phone;
                      dest.User_role = src.Role;
                  });
        CreateMap<Create_Movie_Dto, Movie>()
                  .AfterMap((src, dest) =>
                  {
                      dest.Title = src.Title;
                      dest.Budget = src.Budget;
                      dest.Homepage = src.Homepage;
                      dest.Overview = src.Overview;
                      dest.Popularity = src.Popularity;
                      dest.Release_date = src.Release_date;
                      dest.Revenue = src.Revenue;
                      dest.Runtime = src.Runtime;
                      dest.Movie_status = src.Status;
                      dest.Tagline = src.Tagline;
                      dest.Vote_average = src.Vote_average;
                      dest.Vote_count = src.Vote_count;
                      dest.User_id = src.User_id;
                  });
        CreateMap<Create_Movie_Company_Dto, Movie_Company>();
        CreateMap<Create_Production_Company_Dto, Production_Company>()
                  .AfterMap((src, dest) =>
                  {
                      dest.Company_name = src.Company_name;
                  });
        CreateMap<Create_Movie_Cast_Dto, Movie_Cast>();
    }
}
