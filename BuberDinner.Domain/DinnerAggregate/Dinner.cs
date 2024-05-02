using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Enities;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using Price = BuberDinner.Domain.DinnerAggregate.ValueObjects.Price;


namespace BuberDinner.Domain.DinnerAggregate;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new List<Reservation>();
    private readonly IEnumerable<DinnerStatus> _dinnerStatuses = new List<DinnerStatus>();


    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime StartedDateTime { get; }
    public DateTime EndedDateTime { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price{ get; }
    public Location Location { get; }
    public string ImageUrl { get; }
    public HostId HostId { get; }
    public MenuId  MenuId { get; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public IEnumerable<DinnerStatus> Status => _dinnerStatuses;
    public Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        bool isPublic,
        int maxGuests,
        Price price,
        Location location,
        string imageUrl,
        HostId hostId,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime startedDateTime,
        DateTime endedDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        MenuId menuId) : base(dinnerId)
    {
        HostId = hostId;
        MenuId = menuId;
        Name = name;
        Description = description;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        Location = location;
        ImageUrl = imageUrl;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    
    public static Dinner Create(
        string name,
        string description,
        bool isPublic,
        int maxGuests,
        string imageUrl,
        Price price,
        Location location,
        MenuId menuId,
        HostId hostId)
    {
       return new(
           DinnerId.CreateUnique(),
           name,
           description,
           isPublic,
           maxGuests,
           price,
           location,
           imageUrl,
           hostId,
           DateTime.UtcNow,
           DateTime.UtcNow,
           DateTime.UtcNow,
           DateTime.UtcNow,
           DateTime.UtcNow,
           DateTime.UtcNow,
           menuId); 
    }
   
}