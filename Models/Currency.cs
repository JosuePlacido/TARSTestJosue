using System;
using System.ComponentModel.DataAnnotations;

namespace TARSTestJosue.Models
{
	public class Price : IEquatable<Price>
	{
		public Price(string currency, decimal amount)
		{
			this.Currency = currency;
			this.Amount = amount;
		}

		public static readonly string Dollar = "$";
		public static readonly string Real = "R$";
		public string Currency { get; private set; }
		[DataType(DataType.Currency)]
		public decimal Amount { get; private set; }

		public bool Equals(Price other)
		{
			if (object.ReferenceEquals(other, null)) return false;
			if (object.ReferenceEquals(other, this)) return true;
			return this.Currency.Equals(other.Currency) && this.Amount.Equals(other.Amount);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Price);
		}

		public override int GetHashCode()
		{
			return this.Currency.GetHashCode() ^ this.Amount.GetHashCode();
		}

		public override string ToString()
		{
			return $"{Currency} {Amount.ToString("n")}";
		}
	}
}
