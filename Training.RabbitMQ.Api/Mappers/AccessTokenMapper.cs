using AutoMapper;
using Training.RabbitMQ.Api.Models.Dtos;
using Training.RabbitMQ.Domain.Entities.Subs;

namespace Training.RabbitMQ.Api.Mappers;

public class AccessTokenMapper : Profile
{
    public AccessTokenMapper()
    {
        CreateMap<AccessToken, AccessTokenDto>().ReverseMap();
    }
}