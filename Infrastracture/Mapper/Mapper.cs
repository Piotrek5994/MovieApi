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
    }
}
