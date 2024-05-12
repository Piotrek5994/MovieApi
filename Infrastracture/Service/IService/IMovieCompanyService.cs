using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;

namespace Infrastracture.Service.IService;

public interface IMovieCompanyService
{
    Task<List<Movie_Company_Dto>> Get(MovieCompanyFilter filter);
    Task<int> Post(Create_Movie_Company_Dto movieCompanyDto);
    Task<bool> Put(Create_Movie_Company_Dto movieCompanyDto, int movieCompanyId);
    Task<bool> Delete(int movieCompanyId);
}
