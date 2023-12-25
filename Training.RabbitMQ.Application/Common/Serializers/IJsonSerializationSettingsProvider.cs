using Newtonsoft.Json;

namespace Training.RabbitMQ.Application.Common.Serializers;

public interface IJsonSerializationSettingsProvider
{
    JsonSerializerSettings Get(bool clone = false);
}