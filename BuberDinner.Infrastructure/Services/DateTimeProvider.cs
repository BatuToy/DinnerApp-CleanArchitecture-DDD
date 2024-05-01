using BuberDinner.Application.Common.Intefaces.Services;

namespace BuberDinner.Infrastructre.Services;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

