using AutoMapper;
using Core.CommandDto;
using Core.Filter;
using Core.Model;
using Core.ModelDto;
using Infrastracture.Repositories;
using Infrastracture.Service.IService;

namespace Infrastracture.Service;

public class PersonService : IPersonService
{
    private readonly IPersonRepositories _personRepositories;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepositories personRepositories, IMapper mapper)
    {
        _personRepositories = personRepositories;
        _mapper = mapper;
    }
    public async Task<List<Person_Dto>> Get(PersonFilter filter)
    {
        List<Person> getPerson = await _personRepositories.Get(filter);
        List<Person_Dto> personMapped = _mapper.Map<List<Person_Dto>>(getPerson);
        return personMapped;
    }
    public async Task<int> Post(Create_Person_Dto createPerson)
    {
        Person  mappedPerson = _mapper.Map<Person>(createPerson);
        int createdPerson = await _personRepositories.CreatePerson(mappedPerson);
        return createdPerson;
    }
    public async Task<bool> Put(Create_Person_Dto createPerson, int personId)
    {
        Person mappedPerson = _mapper.Map<Person>(createPerson);
        bool changePerson = await _personRepositories.UpdatePerson(mappedPerson,personId);
        return changePerson;
    }
    public async Task<bool> Delete(int personId)
    {
        bool deletePerson = await _personRepositories.DeletePerson(personId);
        return deletePerson;
    }
}
