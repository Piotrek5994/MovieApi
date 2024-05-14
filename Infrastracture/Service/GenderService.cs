using AutoMapper;
using Core.CommandDto;
using Core.Filter;
using Core.Model;
using Core.ModelDto;
using Infrastracture.Repositories;
using Infrastracture.Service.IService;

namespace Infrastracture.Service;

public class GenderService : IGenderService
{
    private readonly IGenderRepositories _genderRepository;
    private readonly IMapper _mapper;

    public GenderService(IGenderRepositories genderRepository, IMapper mapper)
    {
        _genderRepository = genderRepository;
        _mapper = mapper;
    }
    public async Task<List<Gender_Dto>> Get(GenderFilter filter)
    {
        List<Gender> getGender = await _genderRepository.Get(filter);
        List<Gender_Dto> mappedGender = _mapper.Map<List<Gender_Dto>>(getGender);
        return mappedGender;
    }
    public async Task<int> Post(Create_Gender_Dto genderDto)
    {
        Gender mappedGender = _mapper.Map<Gender>(genderDto);
        int createGenderId = await _genderRepository.CreateGender(mappedGender);
        return createGenderId;
    }
    public async Task<bool> Put(Create_Gender_Dto genderDto,int genderId)
    {
        Gender mappedGender = _mapper.Map<Gender>(genderDto);
        bool changeGander = await _genderRepository.UpdateGender(mappedGender, genderId);
        return changeGander;
    }
    public async Task<bool> Delete(int genderId)
    {
        bool deleteResult = await _genderRepository.DeleteGender(genderId);
        return deleteResult;
    }
}
