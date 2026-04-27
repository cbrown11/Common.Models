namespace Common.Models.AuditInfo
{
    public interface IAuditInfo
    {
        DateTime Created { get; set; }

        string By { get; set; }
    }
}
