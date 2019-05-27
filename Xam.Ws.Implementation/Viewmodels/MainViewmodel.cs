using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Xam.Ws.Implementation.Viewmodels
{
    public class MainViewmodel : INotifyPropertyChanged
    {
        private int _input;

        /// <summary>
        ///     Uitvoer veld met een 'berekening' in de viewmodel die getest kan worden.
        ///     Deze berekening geeft geen afhankelijkheid van het Android-systeem en is isoleerbaar te testen
        /// </summary>
        public int Output
        {
            get
            {
                return Input + 10;
            }
        }

        /// <summary>
        ///     Invoerveld
        /// </summary>
        public int Input
        {
            get { return _input; }
            set
            {
                if(_input != value)
                {
                    _input = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Output));
                }
            }
        }

        #region INotifyPropertyChanged

        /// <summary>
        ///     Property changed event waar naar geluisterd kan worden
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Verstuurt een PropertyChanged-event
        /// </summary>
        /// <param name="propertyName">naam van de property die veranderd is</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
