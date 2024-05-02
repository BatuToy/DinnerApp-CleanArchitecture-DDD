using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.Entities;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new();
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<GuestRating> _guestRatings = new();
    // UserId will be created in the future
    // GuestRating will be created in the future
    // GuestRatingId will be created in the future
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public float AverageRating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    //Should all the DinnerId's will be inherit from DinnerId?
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<GuestRating> Ratings => _guestRatings.AsReadOnly();

    public Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        DateTime createdDateTime,
        DateTime updatedDateTime
    ) : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
    {
        return new Guest(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            createdDateTime,
            updatedDateTime);
    }
}
