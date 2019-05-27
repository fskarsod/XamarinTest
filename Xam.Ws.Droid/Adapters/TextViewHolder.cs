using Android.Views;
using Android.Widget;

namespace Xam.Ws.Droid.Adapters
{
    /// <summary>
    ///     Je Viewholder (zie Viewholder pattern)
    ///     
    ///     Bij een ListView manage je zelf de listview cellen.
    ///     De ViewHolder pattern gebruik je om de gemaakte listview cellen te cachen en te hergebruiken
    ///     Je hoeft dan niet elke keer nieuwe cellen te maken en FindViewById te gebruiken (dit is relatief zware operatie)
    /// 
    ///     https://stackoverflow.com/questions/21501316/what-is-the-benefit-of-viewholder
    ///     https://www.javacodegeeks.com/2013/09/android-viewholder-pattern-example.html
    /// </summary>
    public class TextViewHolder : Java.Lang.Object
    {
        /// <summary>
        ///     Onze listview cellen hebben alleen een textview die we willen manipuleren
        /// </summary>
        public TextView TextView { get; }

        /// <summary>
        ///     De view die je meegeeft is de listview cel die gemaakt is
        /// </summary>
        /// <param name="listViewCell"></param>
        public TextViewHolder(View listViewCell)
        {
            TextView = listViewCell.FindViewById<TextView>(Resource.Id.myListItemTextView);
        }
    }
}