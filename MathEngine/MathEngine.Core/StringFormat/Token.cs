using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEngine.Core.StringFormat
{
    public abstract class Token
    {

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public static bool operator ==(Token left, Token right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Token left, Token right)
        {
            return !Equals(left, right);
        }
    }

    public class Identifier : Token
    {
        public string Name { get; }

        public Identifier(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name;
        }

        protected bool Equals(Identifier other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Identifier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ Name.GetHashCode();
            }
        }

        public static bool operator ==(Identifier left, Identifier right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Identifier left, Identifier right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Integer : Token
    {
        public int Value { get; }

        public Integer(int value)
        {
            Value = value;
        }

        protected bool Equals(Integer other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Integer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ Value;
            }
        }

        public static bool operator ==(Integer left, Integer right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Integer left, Integer right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class Decimal : Token
    {
        public decimal Value { get; }

        public Decimal(decimal value)
        {
            Value = value;
        }

        protected bool Equals(Decimal other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Decimal) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ Value.GetHashCode();
            }
        }

        public static bool operator ==(Decimal left, Decimal right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Decimal left, Decimal right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class OpenBrackets : Token
    {
        public override string ToString()
        {
            return "[";
        }
    }

    public class CloseBrackets : Token
    {
        public override string ToString()
        {
            return "]";
        }
    }
}
