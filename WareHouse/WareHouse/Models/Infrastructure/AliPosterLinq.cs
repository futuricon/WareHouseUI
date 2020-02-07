using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Models.Infrastructure
{
	public static class AliPosterLinq
	{

		public static bool AnyIndex<T>(this IEnumerable<T> items, Func<T,bool> predicate,out int index)
		{
			if (items == null) throw new ArgumentNullException("items");
			if (predicate == null) throw new ArgumentNullException("predicate");

			int retVal = 0;
			foreach (var item in items)
			{
				if (predicate(item)) { index = retVal;return true; }
				retVal++;
			}
			index = -1;
			return false;
		}

		public static IEnumerable<T> TakeAll<T>(this IEnumerable<T> items, Func<T, bool> predicate)
		{
			if (items == null) throw new ArgumentNullException("items");
			if (predicate == null) throw new ArgumentNullException("predicate");

			foreach (var item in items)
			{
				if (predicate(item)) yield return item;
			}
		}

		public static string DeleteAllLetter(this string str)
		{
			string result = "";
			if (string.IsNullOrWhiteSpace(str)) return "";

			foreach (var s in str.Trim())
			{
				if (char.IsDigit(s)||s==',')
				{
					result += s;
				}
			}
			return result;
		}
	}
}
