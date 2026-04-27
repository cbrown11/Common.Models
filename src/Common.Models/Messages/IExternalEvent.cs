

namespace Common.Models.Messages
{
    using Common.Models.AuditInfo;
    using Common.Models.Serializer;

    public interface IExternalEvent: IEvent
    {
        string Id { get; set; }
        DateTime TimeStamp { get; set; }
        long Version { get; set; }
        IAuditInfo AuditInfo { get; set; }
    }
}