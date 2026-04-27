namespace Common.Models.AuditInfo
{
    public class SourceAuditInfo : IAuditInfo
    {

        public string Source { get; set; }

        public DateTime Created { get => AuditInfo.Created; set => AuditInfo.Created = value; }
        public string By { get => AuditInfo.By; set => AuditInfo.By = value; }


        protected IAuditInfo AuditInfo { get; set; }

        public SourceAuditInfo(IAuditInfo auditInfo, string source)
        {
            AuditInfo = auditInfo;
            Created = auditInfo.Created;
            By = auditInfo.By;
            Source = source;
        }

    }
}