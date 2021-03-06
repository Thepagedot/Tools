using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Thepagedot.Tools.Xamarin.Android
{
	public class ResourceService : IResourceService
	{
		/// <summary>
		/// Gets the string of the given Android resource key
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="key">Key.</param>
		public string GetString(string key)
		{
			var resId = Application.Context.Resources.GetIdentifier(key, "string", Application.Context.PackageName);
			return Application.Context.GetString(resId);
		}
	}
}