

namespace Common.Models.Messages
{
    public interface IEvent : IMessage
    {
        string Id { get; }
    }
}
