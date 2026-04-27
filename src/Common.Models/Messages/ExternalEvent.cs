namespace Common.Models.Messages
{
    using Newtonsoft.Json;
    using Common.Models.AuditInfo;
    using Common.Models.Serializer;

    public abstract class ExternalEvent : IExternalEvent
    {
        public string Id { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<AuditInfo>))]
        public IAuditInfo AuditInfo { get; set; }

        public long Version { get; set; }

        public DateTime TimeStamp { get; set; }

        // Need for deserialize 
        public ExternalEvent()
        {
            TimeStamp = DateTime.UtcNow;
        }

        public ExternalEvent(IAuditInfo auditInfo, string id, int version, DateTime? timeStamp = null)
            : this(auditInfo, id, timeStamp)
        {
            Version = version;
        }

        protected ExternalEvent(IAuditInfo auditInfo, string id, DateTime? timeStamp = null)
        {
            AuditInfo = auditInfo;
            if (!timeStamp.HasValue)
            {
                TimeStamp = DateTime.UtcNow;
            }
            else
            {
                TimeStamp = (DateTime)timeStamp;
            }

            Id = id;
        }

    }
}
