using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Enities;

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