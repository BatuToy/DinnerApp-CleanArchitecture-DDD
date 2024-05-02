using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Enities;

public sealed class Reservation : Entity<ReservationId>
{
    private readonly IEnumerable<ReservationStatus> _reservationStatus = new List<ReservationStatus>();

    // The props are : GuestCount, GuestId, BillId, ArrivalDateTime, CreatedDateTime, UpdatedDateTime
    public int GuestCount { get; }
    public BillId BillId { get;}
    public GuestId GuestId { get; } 
    public DateTime ArrivalDateTime { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    public IEnumerable<ReservationStatus> ReservationStatus => _reservationStatus;
    
    // Don't pass the ReservationStatus in the constructor because it's a list of statuses
    private Reservation(
        ReservationId reservationId,
        int guestCount,
        BillId billId,
        GuestId guestId,
        DateTime arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(reservationId)
    {
        GuestCount = guestCount;
        BillId = billId;
        GuestId = guestId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Reservation Create(int guestCount, BillId billId, GuestId guestId)
    {
        return new(ReservationId.CreateUnique(), guestCount, billId, guestId, DateTime.Now, DateTime.Now, DateTime.Now);
}

    }