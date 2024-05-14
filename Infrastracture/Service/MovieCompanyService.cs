using AutoMapper;
using Core.CommandDto;
using Core.Filter;
using Core.Model;
using Core.ModelDto;
using Infrastracture.Repositories;
using Infrastracture.Service.IService;

namespace Infrastracture.Service;

public class MovieCompanyService : IMovieCompanyService
{
    private readonly IMovieCompanyRepositories _movieCompanyRepositories;
    private readonly IMapper _mapper;

    public MovieCompanyService(IMovieCompanyRepositories movieCompanyRepositories, IMapper mapper)
    {
        _movieCompanyRepositories = movieCompanyRepositories;
        _mapper = mapper;
    }
    public async Task<List<Movie_Company_Dto>> Get(MovieCompanyFilter filter)
    {
        List<Movie_Company> getMovieCompanies = await _movieCompanyRepositories.Get(filter);
        List<Movie_Company_Dto> mappedMovieCompanies = _mapper.Map<List<Movie_Company_Dto>>(getMovieCompanies);
        return mappedMovieCompanies;
    }
    public async Task<bool> Post(Create_Movie_Company_Dto movieCompanyDto)
    {
        Movie_Company mappedMovieCompanies = _mapper.Map<Movie_Company>(movieCompanyDto);
        bool createMovieCompanies = await _movieCompanyRepositories.CreateMovieCompany(mappedMovieCompanies);
        return createMovieCompanies;
    }
    public async Task<bool> Delete(int movieId, int companyId)
    {
        bool deleteResult = await _movieCompanyRepositories.DeleteMovieCompany(movieId,companyId);
        return deleteResult;
    }
}
