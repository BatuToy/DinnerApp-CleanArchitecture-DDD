using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _section = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewId = new();

    public string Name { get; }    
    public string Description { get; } 
    public float AverageRating { get; } 

    public DateTime CreatetDatetime { get; }
    public DateTime UpdateDatetime { get; }

    public HostId  HostId { get; }
    public IReadOnlyList<MenuSection> Sections => _section.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewId.AsReadOnly();


    public Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        DateTime createtDatetime,
        DateTime updateDatetime) 
        : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatetDatetime = createtDatetime;
        UpdateDatetime = updateDatetime;
    }

    public static Menu Create(
        string name,
        string description,
        HostId hostId)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            DateTime.Now,
            DateTime.Now);
    }



}