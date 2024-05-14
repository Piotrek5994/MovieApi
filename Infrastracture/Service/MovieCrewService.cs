using AutoMapper;
using Core.CommandDto;
using Core.Filter;
using Core.Model;
using Core.ModelDto;
using Infrastracture.Repositories;
using Infrastracture.Service.IService;

namespace Infrastracture.Service;

public class MovieCrewService : IMovieCrewService
{
    private readonly IMovieCrewRepositories _movieCrewRepositories;
    private readonly IMapper _mapper;

    public MovieCrewService(IMovieCrewRepositories movieCrewRepositories, IMapper mapper)
    {
        _movieCrewRepositories = movieCrewRepositories;
        _mapper = mapper;
    }
    public async Task<List<Movie_Crew_Dto>> Get(MovieCrewFilter filter)
    {
        List<Movie_Crew> getMovieCrews = await _movieCrewRepositories.Get(filter);
        List<Movie_Crew_Dto> mappedMovieCrews = _mapper.Map<List<Movie_Crew_Dto>>(getMovieCrews);
        return mappedMovieCrews;
    }
    public async Task<bool> Post(Create_Movie_Crew_Dto movieCrewDto)
    {
        Movie_Crew mappedMovieCrew = _mapper.Map<Movie_Crew>(movieCrewDto);
        bool createMovieCrew = await _movieCrewRepositories.CreateMovieCrew(mappedMovieCrew);
        return createMovieCrew;
    }
    public async Task<bool> Delete(int movieId, int personId, int departmentId)
    {
        bool deleteResult = await _movieCrewRepositories.DeleteMovieCrew(movieId, personId, departmentId);
        return deleteResult;
    }
}
