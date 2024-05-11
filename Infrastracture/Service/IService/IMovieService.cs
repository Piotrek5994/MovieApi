using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;

namespace Infrastracture.Service.IService;

public interface IMovieService
{
    Task<List<Movie_Dto>> Get(MovieFilter filter);
    Task<int> Post(Create_Movie_Dto movieDto);
    Task<bool> Put(Create_Movie_Dto movieDto, int movieId);
    Task<bool> Delete(int movieId);
}
