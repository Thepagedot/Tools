using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Thepagedot.Tools.Xamarin.Android
{
	public class LocalStorageService : ILocalStorageService
	{
		private readonly JsonSerializerSettings _JsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects };

		/// <summary>
		/// Parses an object to JSON and saves it to a local file
		/// </summary>
		/// <returns></returns>
		/// <param name="fileName">File name.</param>
		/// <param name="content">Object to parse and save.</param>
		public async Task SaveToFileAsync(string fileName, object content)
		{
			var json = JsonConvert.SerializeObject(content, Formatting.Indented, _JsonSerializerSettings);
			var filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
			using (var file = File.Open(filePath, FileMode.Create, FileAccess.Write))
			{
				using (var stream = new StreamWriter(file))
				{
					await stream.WriteAsync(json);
				}
			}
		}

		/// <summary>
		/// Loads JSON content from a file and parses it to an object.
		/// </summary>
		/// <returns>The parsed object</returns>
		/// <param name="fileName">File name.</param>
		/// <typeparam name="T">The object's type.</typeparam>
		public async Task<T> LoadFromFileAsync<T>(string fileName)
		{
			string json;
			var filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
			if (File.Exists(filePath))
			{
				using (var file = File.Open(filePath, FileMode.Open, FileAccess.Read))
				{
					using (var stream = new StreamReader(file))
					{
						json = await stream.ReadToEndAsync();
					}
				}

				try
				{
					var content = JsonConvert.DeserializeObject<T>(json, _JsonSerializerSettings);
					return content;
				}
				catch (JsonException)
				{
					return default(T);
				}
			}

			return default(T);
		}
	}
}