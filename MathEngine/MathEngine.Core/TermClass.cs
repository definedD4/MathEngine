using System;

namespace MathEngine.Core
{
    public sealed class TermClass
    {
        public static TermClass Add => new TermClass("Add", ignoreOperandOrder:true);
        public static TermClass Mul => new TermClass("Mul", ignoreOperandOrder:true);
        public static TermClass Pow => new TermClass("Pow");
        public static TermClass Decimal => new TermClass("Decimal");
        public static TermClass Integer => new TermClass("Integer");

        public TermClass(string name, bool ignoreOperandOrder = false)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name;
            IgnoreOperandOrder = ignoreOperandOrder;
        }

        public string Name { get; }
        public bool IgnoreOperandOrder { get; }

        public static TermClass Parse(string str)
        {
            switch (str)
            {
                case "Add":
                    return Add;
                case "Mul":
                    return Mul;
                case "Pow":
                    return Pow;
                case "Decimal":
                    return Decimal;
                case "Integer":
                    return Integer;
                default:
                    return new TermClass(str);
            }
        }

        #region Equality members

        private bool Equals(TermClass other)
        {
            return string.Equals(Name, other.Name) && IgnoreOperandOrder == other.IgnoreOperandOrder;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is TermClass && Equals((TermClass) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Name.GetHashCode() * 397) ^ IgnoreOperandOrder.GetHashCode();
            }
        }

        public static bool operator ==(TermClass left, TermClass right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TermClass left, TermClass right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}