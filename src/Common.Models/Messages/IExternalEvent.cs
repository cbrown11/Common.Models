// Copyright (c) Janus Henderson Investors. All rights reserved.

using DomainDrivenDesign.Shared.Interfaces;

namespace Common.Models.Messages
{
    public interface IExternalEvent: IEvent
    {
        string Id { get; set; }
        DateTime TimeStamp { get; set; }
        long Version { get; set; }
        IAuditInfo AuditInfo { get; set; }
    }
}