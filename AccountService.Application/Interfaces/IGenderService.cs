using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using Common.Application.Interfaces;

namespace AccountService.Application.Interfaces;

public interface IGenderService : IService<GenderEntityDto, CreateGenderEntityDto, UpdateGenderEntityDto>
{
}