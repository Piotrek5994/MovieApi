using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;

namespace Infrastracture.Service.IService;

public interface IGenderService
{
    Task<List<Gender_Dto>> Get(GenderFilter filter);
    Task<int> Post(Create_Gender_Dto genderDto);
    Task<bool> Put(Create_Gender_Dto genderDto, int genderId);
    Task<bool> Delete(int genderId);
}
