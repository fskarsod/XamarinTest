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
using Xam.Ws.Droid.Adapters;
using Xam.Ws.Implementation.Viewmodels;

namespace Xam.Ws.Droid
{
    /// <summary>
    ///     Android Activity voor de ListView demo
    /// </summary>
    [Activity(Label = "MyListActivity")]
    public class MyListActivity : Activity
    {
        private ListViewmodel _viewmodel;
        private ListView _listView;
        private Button _button;

        /// <summary>
        ///     Deze lifecycle methode wordt aangeroepen wanneer de activity aangemaakt wordt
        ///     Gebeurt in principe eenmalig
        /// </summary>
        /// <param name="savedInstanceState">parameters die meegegeven kunnen worden</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Altijd de base (in Java super) methode aanroepen
            base.OnCreate(savedInstanceState);

            // Initialiseer de viewmodel voor deze activity
            _viewmodel = new ListViewmodel();

            // Zet de XML layout die gebruikt moet worden
            // Zie activity_list.axml in de ./Resource/Layout-folder
            SetContentView(Resource.Layout.activity_list);

            // Vind de views op basis van Id
            _listView = FindViewById<ListView>(Resource.Id.myListView);
            _button = FindViewById<Button>(Resource.Id.myButton);

            // Zet de adapter
            _listView.Adapter = new TextAdapter(this, _viewmodel.Items);
        }

        /// <summary>
        ///     Deze lifecycle methode wordt aangeroepen wanneer de activity zichtbaar wordt voor de gebruiker
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();

            // Luister naar veranderingen in het viewmodel
            _viewmodel.PropertyChanged += _viewmodel_PropertyChanged;

            // Luister naar het klik-event van de button
            _button.Click += _button_Click;
        }

        /// <summary>
        ///     Deze lifecycle methode wordt aangeroepen wanneer de activity niet meer zichtbaar is voor de gebruiker
        ///     bijv. naar de achtergrond zonder de app te vernietigen
        /// </summary>
        protected override void OnStop()
        {
            base.OnStop();

            // Alles eventhandlers netjes opnruimen
            _viewmodel.PropertyChanged -= _viewmodel_PropertyChanged;
            _button.Click -= _button_Click;
        }

        private void _viewmodel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Controleer of de items de property is die veranderd is
            if(e.PropertyName.Equals(nameof(_viewmodel.Items)))
            {
                // Zet een nieuwe adapter zodat de Listview opnieuw tekent.
                _listView.Adapter = new TextAdapter(this, _viewmodel.Items);
            }
        }

        private void _button_Click(object sender, EventArgs e)
        {
            // Wanneer de knop geklikt wordt, roepen we een commando of actie in de viewmodel aan
            _viewmodel.Refresh();
        }
    }
}