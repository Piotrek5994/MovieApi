using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;

namespace Infrastracture.Service.IService;

public interface IMovieCrewService
{
    Task<List<Movie_Crew_Dto>> Get(MovieCrewFilter filter);
    Task<bool> Post(Create_Movie_Crew_Dto movieCrewDto);
    Task<bool> Delete(int movieId, int personId, int departmentId);
}
