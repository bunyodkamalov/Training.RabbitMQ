using System.ComponentModel.DataAnnotations.Schema;
using Training.RabbitMQ.Domain.Entities.Bases;
using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Domain.Entities.Subs;

public class EmailHistory : NotificationHistory
{
    public EmailHistory()
    {
        Type = NotificationType.Email;
    }

    public string SenderEmailAddress { get; set; } = default!;

    public string ReceiverEmailAddress { get; set; } = default!;

    public string Subject { get; set; } = default!;

    [NotMapped]
    public EmailTemplate EmailTemplate
    {
        get => Template is not null ? Template as EmailTemplate : null;
        set => Template = value;
    }
}