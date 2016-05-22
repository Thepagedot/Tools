using System.Linq;

namespace Thepagedot.Tools.Helper
{
	/// <summary>
	/// Validates strings
	/// </summary>
	public static class StringValidator
	{
		/// <summary>
		/// Checks if a string matches the e-mail address pattern
		/// </summary>
		/// <returns>true if address is valid</returns>
		/// <param name="address">E-mail address.</param>
		public static bool ValidateAddress(string address)
		{
			if (string.IsNullOrEmpty(address))
				return false;

			var trimmedAddress = address.Trim();

			if (trimmedAddress.Contains("@") &&
				trimmedAddress.Contains(".") &&
				trimmedAddress.Length >= 6)
				return true;

			return false;
		}
	}
}
