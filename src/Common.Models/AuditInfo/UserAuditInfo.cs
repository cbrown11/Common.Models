namespace Common.Models.AuditInfo
{

    public class UserAuditInfo : AuditInfo, IAuditInfo
    {
        public UserAuditInfo(string id, string fullName)
            : base(fullName)
        {
            FullName = fullName;
        }

        public string FullName { get; set; }
    }
}
