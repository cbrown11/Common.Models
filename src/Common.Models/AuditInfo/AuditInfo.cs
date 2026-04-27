namespace Common.Models.AuditInfo
{
    public class AuditInfo : IAuditInfo
    {
        public AuditInfo()
        {
            Created = DateTime.UtcNow;
        }

        public AuditInfo(string by)
            : this()
        {
            By = by;
        }

        public DateTime Created { get; set; }

        public string By { get; set; }
    }
}
