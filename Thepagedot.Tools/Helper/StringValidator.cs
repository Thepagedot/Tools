using System.Linq;

namespace Thepagedot.Tools.Helper
{
    public static class StringValidator
    {
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
