using Android.Content;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace Xam.Ws.Droid.Adapters
{
    /// <summary>
    ///     Deze Adapter converteert een lijst van strings naar een lijst van views
    ///     
    /// </summary>
    public class TextAdapter : BaseAdapter<string>
    {
        private readonly Context _context;
        private readonly IList<string> _items;

        /// <summary>
        ///     Dit is een indexer
        ///     hiermee zou je op een instantie van de TextAdapter
        ///     mTextAdapter[0] kunnen aanroepen.
        ///     in de klasse zelf doe je dit d.m.v this[0]
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override string this[int position] => _items[position];

        /// <summary>
        ///     Een property van de base klasse die moet aangeven hoeveel items het listview zou moeten hebben
        /// </summary>
        public override int Count => _items.Count;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="context">context is een component van android, een activity inherit van Context</param>
        /// <param name="items">de lijst van strings die we in de listview willen tonen</param>
        public TextAdapter(Context context, IList<string> items)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        ///     Geeft een uniek id terug, positie is in ons geval uniek genoeg
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override long GetItemId(int position)
        {
            return position;
        }

        /// <summary>
        ///     Deze methode maakt (of hergebruikt) een listview cel
        /// </summary>
        /// <param name="position">positie in de listview</param>
        /// <param name="convertView">optioneel: een listview cel die hergebruikt kan worden</param>
        /// <param name="parent">de listview zelf</param>
        /// <returns></returns>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            TextViewHolder itemViewHolder;
            View itemView = convertView;
            // Kijk of we een nieuwe view moeten maken of een bestaande kunnen hergebruiken
            if (itemView == null)
            {
                // Verkrijg een LayoutInflater, dit is een component/API van android waarmee views gemaakt worden
                // Zoals hieronder te zien is geef je een resource.Layout (die verwijst naar een xml-bestand) en daar wordt een view-object van gemaakt
                var inflater = _context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                itemView = inflater.Inflate(Resource.Layout.my_list_item, parent, false);

                // omdat we een nieuwe view maken moeten we ook een nieuwe viewholder maken
                // In de constructor van de viewholder wordt de FindViewById gedaan zodat we onze textView kunnen manipuleren
                itemViewHolder = new TextViewHolder(itemView);

                // de viewholder geven we ook aan de gemaakte view
                itemView.Tag = itemViewHolder;
            }
            else
            {
                // onze view bestaat al, onze viewholder dus ook
                // Deze kunnen we op deze manier verkrijgen
                itemViewHolder = (TextViewHolder)itemView.Tag;
            }

            // Hier kunnen we de textview manipuleren (lees: tekst zetten)
            itemViewHolder.TextView.Text = _items[position];

            // Tot slot geven we de gemaakte (of hergebruikte view terug)
            return itemView;
        }
    }
}