namespace Thepagedot.Tools.Helper
{
	public static class StringExtensions
	{
		/// <summary>
		/// Converts a string to an array of bytes
		/// </summary>
		/// <returns>The byte array.</returns>
		/// <param name="str">String.</param>
		public static byte[] ToByteArray(this string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}

		/// <summary>
		/// Converts an array of bytes to a string
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="bytes">Byte array.</param>
		public static string ToString(this byte[] bytes)
		{
			char[] chars = new char[bytes.Length / sizeof(char)];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}
	}
}