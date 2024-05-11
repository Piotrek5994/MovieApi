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
                     src.User_id = dest.Id;
                     src.User_name = dest.Name;
                     src.User_last_name = dest.Last_name;
                     src.User_email = dest.Email;
                     src.User_password = dest.Password;
                     src.User_phone = dest.Phone;
                     src.User_role = dest.Role;
                 });
        CreateMap<Movie_User, Create_Movie_User_Dto>()
                .AfterMap((src, dest) =>
                {
                    src.User_name = dest.Name;
                    src.User_last_name = dest.Last_name;
                    src.User_email = dest.Email;
                    src.User_password = dest.Password;
                    src.User_phone = dest.Phone;
                    src.User_role = dest.Role;
                });
        CreateMap<Create_Movie_User_Dto, Movie_User>()
              .AfterMap((src, dest) =>
              {
                  src.Name = dest.User_name;
                  src.Last_name = dest.User_last_name;
                  src.Email = dest.User_email;
                  src.Password = dest.User_password;
                  src.Phone = dest.User_phone;
                  src.Role = dest.User_role;
              });
    }
}
