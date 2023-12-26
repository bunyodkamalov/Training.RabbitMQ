using AutoMapper;
using Training.RabbitMQ.Application.Common.Identity.Models;
using Training.RabbitMQ.Domain.Entities.User;

namespace Training.RabbitMQ.Infrastructure.Common.Mappers.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<SignUpDetails, User>();
    }
}