using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Xam.Ws.Implementation.Viewmodels
{
    /// <summary>
    ///     Baseviewmodel die INotifyPropertyChanged implementeert
    /// </summary>
    public abstract class BaseViewmodel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        /// <summary>
        ///     Property changed event waar naar geluisterd kan worden vanuit de view
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Verstuurt een PropertyChanged-event
        ///     [CallerMemberName] zorgt ervoor dat <paramref name="propertyName"/> automatisch gevuld wordt met de aanroepende methode of property
        /// </summary>
        /// <param name="propertyName">naam van de property die veranderd is</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // `?.` is een aparte operator in C#
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            // De code hierboven is gelijk aan de code hieronder
            // if(PropertyChanged != null)
            // {
            //     PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            // }
        }

        #endregion
    }
}
