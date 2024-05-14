using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;

namespace Infrastracture.Service.IService;

public interface IMovieCastService
{
    Task<List<Movie_Cast_Dto>> Get(MovieCastFilter filter);
    Task<bool> Post(Create_Movie_Cast_Dto movieCastDto);
    Task<bool> Delete(int movieId, int personId, int genderId);
}
