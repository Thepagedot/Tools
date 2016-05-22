using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thepagedot.Tools
{
	public interface IHttpService
	{
		Task<string> GetStringAsync(string url, TimeSpan? cacheTime = null, TimeSpan? timeout = null);
	}
}
