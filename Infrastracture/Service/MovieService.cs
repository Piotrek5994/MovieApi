using AutoMapper;
using Core.CommandDto;
using Core.Filter;
using Core.IRepositories;
using Core.Model;
using Core.ModelDto;
using Infrastracture.Service.IService;

namespace Infrastracture.Service;

public class MovieService : IMovieService
{
    private readonly IMovieRepositories _movieRepositories;
    private readonly IMapper _mapper;

    public MovieService(IMovieRepositories movieRepositories, IMapper mapper)
    {
        _movieRepositories = movieRepositories;
        _mapper = mapper;
    }
    public async Task<List<Movie_Dto>> Get(MovieFilter filter)
    {
        List<Movie> getMovieList = await _movieRepositories.Get(filter);
        List<Movie_Dto> mapperMovie = _mapper.Map<List<Movie_Dto>>(getMovieList);
        return mapperMovie;
    }
    public async Task<int> Post(Create_Movie_Dto movieDto)
    {
        Movie mappedMovie = _mapper.Map<Movie>(movieDto);
        int createMovieDto = await _movieRepositories.CreateMovie(mappedMovie);
        return createMovieDto;
    }
    public async Task<bool> Put(Create_Movie_Dto movieDto,int movieId)
    {
        Movie mappedMovie = _mapper.Map<Movie>(movieDto);
        bool changeMovie = await _movieRepositories.UpdateMovie(mappedMovie, movieId);
        return changeMovie;
    }
    public async Task<bool> Delete(int movieId)
    {
        bool deleteResult = await _movieRepositories.DeleteMovie(movieId);
        return deleteResult;
    }
}
