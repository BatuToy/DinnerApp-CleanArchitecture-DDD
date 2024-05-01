using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Guest.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    public Guid HostId { get; }
    public Guid DinnerId { get; }
    public int Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public GuestRating(
        GuestRatingId guestRatingId,
        Guid hostId,
        Guid dinnerId,
        int rating,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(guestRatingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static GuestRating Create(
        Guid hostId,
        Guid dinnerId,
        int rating,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new GuestRating(
            GuestRatingId.CreateUnique(),
            hostId,
            dinnerId,
            rating,
            createdDateTime,
            updatedDateTime);
    }
}