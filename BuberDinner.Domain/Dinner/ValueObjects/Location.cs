namespace BuberDinner.Domain.Dinner.ValueObjects;

using BuberDinner.Domain.Common.Models;

public sealed class Location : ValueObject
{
    public string Name { get; private set; }
    public string Address { get; private set; }
    public float Latitude { get; set; }
    public float Longtitude { get; set; }

    private Location(string name, string address, float latitude, float longtitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longtitude = longtitude;
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longtitude;
    }
}