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
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User_id))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User_name))
                  .ForMember(dest => dest.Last_name, opt => opt.MapFrom(src => src.User_last_name))
                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User_email))
                  .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.User_password))
                  .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.User_phone))
                  .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.User_role));

        CreateMap<Movie, Movie_Dto>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Movie_id))
                  .ForMember(dest => dest.MovieCompany, opt => opt.MapFrom(src => src.MovieCompany));

        CreateMap<Movie_Company, Movie_Company_Dto>()
                  .ForMember(dest => dest.Movie_id, opt => opt.MapFrom(src => src.Movie_id))
                  .ForMember(dest => dest.Company_id, opt => opt.MapFrom(src => src.Company_id))
                  .ForMember(dest => dest.Production, opt => opt.MapFrom(src => src.ProductionCompany));

        CreateMap<Production_Company, Production_Company_Dto>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Company_id))
                  .ForMember(dest => dest.Company_name, opt => opt.MapFrom(src => src.Company_name));

        CreateMap<Movie_Cast, Movie_Cast_Dto>();
        CreateMap<Movie_Crew, Movie_Crew_Dto>();
        CreateMap<Gender, Gender_Dto>();
        CreateMap<Person, Person_Dto>();
        CreateMap<Department, Department_Dto>();
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
                      dest.Revenue = src.Revenue.ToString();
                      dest.Runtime = src.Runtime;
                      dest.Release_date = src.Release_date;
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
        CreateMap<Create_Movie_Crew_Dto, Movie_Crew>();
        CreateMap<Create_Gender_Dto, Gender>();
        CreateMap<Create_Person_Dto, Person>();
        CreateMap<Create_Department_Dto, Department>();
    }
}
