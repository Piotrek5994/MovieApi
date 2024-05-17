using Core.Filter;
using Core.Model;

namespace Infrastracture.Repositories;

public interface IPersonRepositories
{
    Task<List<Person>> Get(PersonFilter filter);
    Task<int> CreatePerson(Person person);
    Task<bool> UpdatePerson(Person person, int personId);
    Task<bool> DeletePerson(int personId);
}
