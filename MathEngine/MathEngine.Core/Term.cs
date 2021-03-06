﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MathEngine.Utility;

namespace MathEngine.Core
{
    public class Term : IEquatable<Term>
    {
        public Term(TermClass tag) : this(tag, Enumerable.Empty<Term>())
        {
        }

        public Term(TermClass tag, params Term[] operands) : this(tag, (IEnumerable<Term>)operands)
        {
        }

        public Term(string tag) : this(new TermClass(tag), Enumerable.Empty<Term>())
        {
        }

        public Term(string tag, params Term[] operands) : this(new TermClass(tag), (IEnumerable<Term>)operands)
        {
        }

        public Term(TermClass tag, IEnumerable<Term> operands)
        {
            Tag = tag;
            Operands = new List<Term>(operands);
        }

        public TermClass Tag { get; }

        public List<Term> Operands { get; }

        public bool Equals(Term other)
        {
            return Tag.Equals(other.Tag) && 
                (Tag.IgnoreOperandOrder ? Operands.ScrambledEquals(other.Operands) : Operands.SequenceEqual(other.Operands));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Term) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return  Tag.GetHashCode() * 397;
            }
        }

        public static bool operator ==(Term left, Term right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Term left, Term right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            var operandsFormated = Operands.Count > 0
                ? $"[{Operands.Skip(1).Select(o => o.ToString()).Aggregate(Operands.FirstOrDefault()?.ToString(), (acc, x) => acc + ", " + x)}]"
                : "";
            return
                $"{Tag}{operandsFormated}";
        }
    }

    public class Decimal : Term, IEquatable<Decimal>
    {
        public Decimal(TermClass tag) : base(tag)
        {
            throw new NotSupportedException();
        }

        public Decimal(decimal value) : base(TermClass.Decimal)
        {
            Value = value;
        }

        public decimal Value { get; }

        public bool Equals(Decimal other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Value == other.Value;
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
                return Value.GetHashCode();
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
            return Value.ToString(CultureInfo.CurrentCulture);
        }
    }

    public class Integer : Term, IEquatable<Integer>
    {
        public Integer(TermClass tag) : base(tag)
        {
            throw new NotSupportedException();
        }

        public Integer(int value) : base(TermClass.Integer)
        {
            Value = value;
        }

        public int Value { get; }

        public bool Equals(Integer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Value == other.Value;
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
                return Value;
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
}