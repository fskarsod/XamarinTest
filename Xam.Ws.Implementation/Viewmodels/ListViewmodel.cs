using System;
using System.Collections.Generic;
using System.Linq;

namespace Xam.Ws.Implementation.Viewmodels
{
    /// <summary>
    ///     Viewmodel voor de ListView demo
    /// </summary>
    public class ListViewmodel : BaseViewmodel
    {
        private IList<string> _items;
        private readonly Random _random;

        /// <summary>
        ///     Lijst van items die getoond kunnen worden
        /// </summary>
        public IList<string> Items
        {
            get => _items;
            set
            {
                if(_items != value)
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public ListViewmodel()
        {
            _random = new Random();
            Items = new List<string>()
            {
                "Element 1",
                "Element 2",
                "Element 3",
                "Element 4"
            };
        }

        /// <summary>
        ///     Nep-vernieuw methode waarmee een lijst wordt aangemaakt met een willekeurig aantal elementen
        /// </summary>
        public void Refresh()
        {
            // Maak een random nummer van 1 tot en met 10 (exclusive upper bound)
            var randomInt = _random.Next(1, 11);
            // Genereer een lijstje van strings met deze nummers
            Items = Enumerable.Range(0, randomInt)
                .Select(i => $"Element {i}")
                .ToList();
        }
    }
}
