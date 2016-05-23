using System;
using Android.App;
using Android.OS;
using Android.Views;

namespace Thepagedot.Tools.Xamarin.Android
{
	public static class ActivityHelpers
	{
		/// <summary>
		/// Sets the system bar background to a sepcific color when > Lollypop.
		/// </summary>
		/// <returns>The system bar background.</returns>
		/// <param name="activity">Activity.</param>
		/// <param name="colorResourceId">Color resource identifier.</param>
		public static void SetSystemBarBackground(this Activity activity, int colorResourceId)
		{
			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
			{
				// Set status bar color
				activity.Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
				activity.Window.SetStatusBarColor(activity.Resources.GetColor(colorResourceId)); //Resource.Color.HomeMaticBlue));
			}
		}
	}
}

