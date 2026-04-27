

namespace Common.Models.Messages
{
    using Common.Models.AuditInfo;
    using Common.Models.Serializer;
    using System.Text.Json.Serialization;

    public interface ICommand
    {
        public string Id { get; set; }
        DateTime TimeStamp { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<AuditInfo>))]
        public IAuditInfo AuditInfo { get; set; }
    }
}
