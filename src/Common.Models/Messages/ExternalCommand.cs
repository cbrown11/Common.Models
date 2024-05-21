namespace Common.Models.Messages
{
    using DomainDrivenDesign.Serializer;
    using DomainDrivenDesign.Shared;
    using DomainDrivenDesign.Shared.Interfaces;
    using Newtonsoft.Json;

    public class ExternalCommand : IExternalCommand
    {
        public string Id { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<AuditInfo>))]
        public IAuditInfo AuditInfo { get; set; }
        public DateTime TimeStamp { get; set; }

        public ExternalCommand() {

            TimeStamp = DateTime.UtcNow;
        }

        protected ExternalCommand(IAuditInfo auditInfo, string id, DateTime? timeStamp = null)
        {
            Id = id;
            AuditInfo = auditInfo;
            if (!timeStamp.HasValue)
            {
                TimeStamp = DateTime.UtcNow;
            }
            else
            {
                TimeStamp = (DateTime)timeStamp;
            }   
        }
    }
}
