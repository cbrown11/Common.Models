using System.Text.Json.Serialization;
using DomainDrivenDesign.Serializer;
using DomainDrivenDesign.Shared.Interfaces;

namespace Common.Models.Messages
{
    public interface ICommand
    {
        public string Id { get; set; }
        DateTime TimeStamp { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<DomainDrivenDesign.Shared.AuditInfo>))]
        public IAuditInfo AuditInfo { get; set; }
    }
}
