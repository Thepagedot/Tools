using System;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Thepagedot.Tools.Xamarin.Android
{
	public class ExpandableHeightGridView : GridView
	{
		public bool IsExpanded = false;

		public ExpandableHeightGridView(Context context) : base(context) { }
		public ExpandableHeightGridView(Context context, IAttributeSet attrs) : base(context, attrs) { }
		public ExpandableHeightGridView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle) { }

		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			// HACK! TAKE THAT ANDROID!
			if (IsExpanded)
			{
				// Calculate entire height by providing a very large height hint.
				// But do not use the highest 2 bits of this integer; those are
				// reserved for the MeasureSpec mode
				int expandSpec = MeasureSpec.MakeMeasureSpec(Integer.MaxValue >> 2, MeasureSpecMode.AtMost);
				base.OnMeasure(widthMeasureSpec, expandSpec);

				//var parameters = LayoutParameters;
				LayoutParameters.Height = MeasuredHeight;
			}
			else
			{
				base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
			}
		}
	}
}