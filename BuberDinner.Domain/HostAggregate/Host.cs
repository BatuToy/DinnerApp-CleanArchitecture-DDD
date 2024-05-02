using System.Diagnostics;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;


namespace BuberDinner.Domain.HostAggregate;
public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<DinnerId> _dinnerIds = new List<DinnerId>();
    private readonly List<MenuId> _menuIds = new List<MenuId>();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfileImage { get; set; }
    public float AverageRating { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    public UserId UserId { get; set; }

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuId> MuneIds => _menuIds.AsReadOnly();

    public Host(
        HostId hostId,
        UserId userId,
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(hostId)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Host Create(
        UserId userId,
        string firstName,
        string lastName,
        string profileImage,
        float averageRating)
    {
        return new Host(
            HostId.CreateUnique(),
            userId,
            firstName,
            lastName,
            profileImage,
            averageRating,
            DateTime.Now,
            DateTime.Now);
    }
}
