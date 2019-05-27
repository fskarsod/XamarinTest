using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Widget;
using System;
using Xam.Ws.Implementation.Viewmodels;

namespace Xam.Ws.Droid
{
    /// <summary>
    ///     De hoofdactivity van je app
    ///     Dit wordt aangegeven door `MainLauncher = true` in de Attribuut hieronder
    /// </summary>
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _button;
        private EditText _myEditText;
        private TextView _textView;

        MainViewmodel _viewmodel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Initialiseer de viewmodel voor deze activity
            _viewmodel = new MainViewmodel();

            // Zet de juiste layout resource
            SetContentView(Resource.Layout.activity_main);

            // Vind alle id's die je nodig hebt
            _button = FindViewById<Button>(Resource.Id.mainButton);
            _myEditText = FindViewById<EditText>(Resource.Id.myEditText);
            _textView = FindViewById<TextView>(Resource.Id.myTextView);
        }

        protected override void OnStart()
        {
            base.OnStart();

            _button.Click += Button_Click;
            _myEditText.TextChanged += MyEditText_TextChanged;
            _textView.Text = "Dit is mijn tekst";

            _viewmodel.PropertyChanged += Viewmodel_PropertyChanged;
        }

        private void Viewmodel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Luister naar de veranderingen waar je in geinteresseerd bent
            if(e.PropertyName == nameof(_viewmodel.Output))
            {
                _textView.Text = _viewmodel.Output.ToString();
            }
        }

        protected override void OnStop()
        {
            base.OnStop();
            
            // Alle handlers netjes opruimen
            _button.Click -= Button_Click;
            _viewmodel.PropertyChanged -= Viewmodel_PropertyChanged;
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            // Als je op de knop klikt start je de `MyListActivity`
            StartActivity(typeof(MyListActivity));
        }

        private void MyEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            try
            {
                _viewmodel.Input = int.Parse(e.Text.ToString());
            }
            catch(Exception ex)
            {
                // Log.Debug wordt in je log output weergegeven
                // De Tag is een Android specifiek ding waarmee je debugregels (of andere info) kan groeperen
                Log.Debug("Tag", ex.ToString());
            }
        }
    }
}