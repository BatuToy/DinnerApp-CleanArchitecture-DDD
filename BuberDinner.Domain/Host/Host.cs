using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Host.ValueObjects;


namespace BuberDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    public Host(HostId hostId) : base(hostId)
    {
    }
}