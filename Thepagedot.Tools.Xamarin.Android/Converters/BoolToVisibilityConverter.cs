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

namespace Thepagedot.Tools.Xamarin.Android.Converters
{
    public class BoolToVisibilityConverter
    {
        public static ViewStates Convert(int arg)
        {
            return (arg > 0) ? ViewStates.Visible : ViewStates.Gone;
        }
    }

    public class BoolToNegatedVisibilityConverter
    {
        public static ViewStates Convert(int arg)
        {
            return (arg > 0) ? ViewStates.Gone : ViewStates.Visible;
        }
    }
}