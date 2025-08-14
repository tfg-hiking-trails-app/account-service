using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Application.Interfaces;
using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using AutoMapper;
using Common.Application.Services;
using Common.Application.Utils;

namespace AccountService.Application.Services;

public class GenderService : AbstractService<Gender, GenderEntityDto, CreateGenderEntityDto, UpdateGenderEntityDto>, 
    IGenderService
{
    public GenderService(IGenderRepository repository, IMapper mapper) 
        : base(repository, mapper)
    {
    }

    protected override void CheckDataValidity(CreateGenderEntityDto createEntityDto)
    {
        if (string.IsNullOrEmpty(createEntityDto.GenderValue))
            Validator.CheckNullArgument(createEntityDto.GenderValue, nameof(createEntityDto.GenderValue));
    }
    
}