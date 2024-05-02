
//We just override the methods on this stage of the scope of the project.
//We can refactor this later if we need to.
//We can find the code onlien easily. Don't repeat yourself.

namespace BuberDinner.Domain.Common.Models
{

    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            var valueObject = (ValueObject)obj;

            return GetEqualityComponents()
                        .SequenceEqual(valueObject.GetEqualityComponents());
        }

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !Equals(left, right);
        }
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x ^ y);
        }

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }
    }
}

namespace BuberDinner.Domain.Common.Models.Price
{
    public class Price : ValueObject
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; } = string.Empty;

        public Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
    // replace with some logic namespace data!
}
