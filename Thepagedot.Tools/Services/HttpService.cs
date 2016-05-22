﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModernHttpClient;

namespace Thepagedot.Tools.Services
{
	/// <summary>
	/// An Http service to manage network requests
	/// </summary>
	public class HttpService : IHttpService
	{
		// Dictionary for cache files
		private static readonly Dictionary<string, CacheFile<string>> Cache = new Dictionary<string, CacheFile<string>>();

		// Use the ModernHttpClient to provide a working timeout
		private static HttpClient HttpClient = new HttpClient(new NativeMessageHandler());
		//private static CookieContainer Cookies = new CookieContainer();


		/// <summary>
		/// Returns the response source code of a simple web request
		/// </summary>
		/// <returns>The response string.</returns>
		/// <param name="url">Request URL.</param>
		/// <param name="cacheTime">Defines how long the cache of this request should be hold.</param>
		/// <param name="timeout">Defines the timeout.</param>
		public async Task<string> GetStringAsync(string url, TimeSpan? cacheTime = null, TimeSpan? timeout = null)
		{
			// Check if cached response is available
			if (cacheTime != null && Cache.ContainsKey(url))
			{
				var cacheFile = Cache[url];

				// Check if cache is still valid
				if (DateTime.Now.Subtract(cacheFile.TimeStamp) < cacheTime)
				{
					return cacheFile.Value;
				}
			}

			// Set request timeout if available, otherwise set default timeout
			if (timeout != null)
				HttpClient.Timeout = (TimeSpan)timeout;
			else
				HttpClient.Timeout = new TimeSpan(0, 0, 60);

			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, url);
				//request.Headers.Add("If-Modified-Since", DateTime.UtcNow.ToString());
				var response = await HttpClient.SendAsync(request);
				var content = await response.Content.ReadAsStringAsync();

				return content;
			}
			catch (WebException wex)
			{
				// Host not found
				Debug.WriteLine(wex);
				return null;
			}
			catch (TaskCanceledException tce)
			{
				// Timeout has been reached
				Debug.WriteLine(tce);
				return null;
			}
		}

		/// <summary>
		/// Deletes the chache file for a specific url
		/// </summary>
		/// <returns></returns>
		/// <param name="url">Request URL.</param>
		public void DeleteCache(string url)
		{
			// Check if cached response is available
			if (Cache.ContainsKey(url))
			{
				Cache.Remove(url);
			}
		}
	}

	internal class CacheFile<T>
	{
		public DateTime TimeStamp { get; set; }
		public T Value { get; set; }

		public CacheFile(T value)
		{
			TimeStamp = DateTime.Now;
			Value = value;
		}
	}
}
