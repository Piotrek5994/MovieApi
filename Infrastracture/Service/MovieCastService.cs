using AutoMapper;
using Core.CommandDto;
using Core.Filter;
using Core.Model;
using Core.ModelDto;
using Infrastracture.Repositories;
using Infrastracture.Service.IService;

namespace Infrastracture.Service;

public class MovieCastService : IMovieCastService
{
    private readonly IMovieCastRepositories _movieCastRepositories;
    private readonly IMapper _mapper;

    public MovieCastService(IMovieCastRepositories movieCastRepositories, IMapper mapper)
    {
        _movieCastRepositories = movieCastRepositories;
        _mapper = mapper;
    }
    public async Task<List<Movie_Cast_Dto>> Get(MovieCastFilter filter)
    {
        List<Movie_Cast> getMovieCasts = await _movieCastRepositories.Get(filter);
        List<Movie_Cast_Dto> mappedMovieCasts = _mapper.Map<List<Movie_Cast_Dto>>(getMovieCasts);
        return mappedMovieCasts;
    }
    public async Task<bool> Post(Create_Movie_Cast_Dto movieCastDto)
    {
        Movie_Cast mappedMovieCast = _mapper.Map<Movie_Cast>(movieCastDto);
        bool createMovieCast = await _movieCastRepositories.CreateMovieCast(mappedMovieCast);
        return createMovieCast;
    }
    public async Task<bool> Delete (int movieId, int personId, int genderId)
    {
        bool deleteResult = await _movieCastRepositories.DeleteMovieCast(movieId, personId, genderId);
        return deleteResult;
    }
}
