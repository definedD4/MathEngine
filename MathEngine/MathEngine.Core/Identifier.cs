using System;

namespace MathEngine.Core
{
    public sealed class Identifier
    {
        public static Identifier Add => new Identifier("Add");
        public static Identifier Mul => new Identifier("Mul");
        public static Identifier Pow => new Identifier("Pow");
        public static Identifier Decimal => new Identifier("Decimal");
        public static Identifier Integer => new Identifier("Integer");

        public Identifier(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name;
        }

        public string Name { get; }

        private bool Equals(Identifier other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Identifier && Equals((Identifier) obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
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
}