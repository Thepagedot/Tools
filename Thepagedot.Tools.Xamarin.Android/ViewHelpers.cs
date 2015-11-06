using Android.Views;
using Android.Widget;

namespace Thepagedot.Tools.Xamarin.Android
{
    public static class ViewHelpers
    {
        public static void SetListViewHeightBasedOnChildren(AbsListView listView)
        {
            var listAdapter = listView.Adapter;
            if (listAdapter == null)
                return;

            var desiredWidth = View.MeasureSpec.MakeMeasureSpec(listView.Width, MeasureSpecMode.Unspecified);
            var totalHeight = 0;

            View view = null;
            for (var i = 0; i < listAdapter.Count; i++)
            {
                view = listAdapter.GetView(i, view, listView);
                if (i == 0)
                    view.LayoutParameters = new ViewGroup.LayoutParams(desiredWidth, ViewGroup.LayoutParams.WrapContent);

                //view.Measure(desiredWidth, MeasureSpecMode.Unspecified);
                view.Measure(desiredWidth, 0);
                totalHeight += view.MeasuredHeight;
            }
            var p = listView.LayoutParameters;

            if (listView is ListView)
                p.Height = totalHeight + (((ListView)listView).DividerHeight * (listAdapter.Count - 1));
            else
                p.Height = totalHeight / 2;

            listView.LayoutParameters = p;
        }
    }
}
