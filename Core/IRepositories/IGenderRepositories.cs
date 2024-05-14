using Core.Filter;
using Core.Model;

namespace Infrastracture.Repositories;

public interface IGenderRepositories
{
    Task<List<Gender>> Get(GenderFilter filter);
    Task<int> CreateGender(Gender gender);
    Task<bool> UpdateGender(Gender gender, int genderId);
    Task<bool> DeleteGender(int genderId);
}
