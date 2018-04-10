using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TakeASeat
{
	public partial class MainPage : ContentPage
	{

        private ServerConnection server;
        private ObservableCollection<string> _locationsList;// = new List<string>();
        public ObservableCollection<string> LocationsList
        {
            get { return _locationsList; }

            set
            {
                _locationsList = value;

                OnPropertyChanged(nameof(LocationsList));
            }
        }

       

        private BuildingLevel buildingLvl;

        public MainPage()
		{

            LocationsList = new ObservableCollection<string>();
            server = new ServerConnection();
            BindingContext = server;
            server.IsConnecting = false;

            InitializeComponent();

            locationPicker.BindingContext = this;
            Setup_Locations();
        }


        private async void Setup_Locations()
        {
            string locationsRequest = await server.readLocationsRequest();

            List<Locations> liste = new List<Locations>();
            liste = JsonConvert.DeserializeAnonymousType<List<Locations>>(locationsRequest, liste);


            for (int i = 0; i < liste.Count; i++)
            {
                LocationsList.Add(liste[i].Location);
            }
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {

            server.IsConnecting = true;

            //await server.SendColleagueRequest(nameshortcut.Text, name.Text, surname.Text);
            //string places = await server.readPlacesRequest();

            //string loc = await server.readLocationsRequest();
            //Console.WriteLine("Loc: " + loc);

            //var enigwas = JsonConvert.DeserializeObject<List<string>>(loc);
            //Console.WriteLine("Enigwas: " + enigwas);

            //string colleagues = await server.readColleaguesRequest();
            //Console.WriteLine("ColleagueJSON: " + colleagues);

            //List<Colleagues> colleague = new List<Colleagues>();
            //colleague = JsonConvert.DeserializeAnonymousType<List<Colleagues>>(colleagues, colleague);
            //Console.WriteLine("JSON: " + colleague);


            //for (int i = 0; i < colleague.Count; i++)
            //{
            //    System.Diagnostics.Debug.WriteLine(colleague[i].Name);
            //}





            //string placeoccupation = await server.readPlaceOccupationsRequest();

            server.IsConnecting = false;

            if(buildingLvl == null)
            {
                buildingLvl = new BuildingLevel(server.loadLevelsFromServer());
            }
            await Navigation.PushAsync(buildingLvl);
        }

        private void SearchingButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchingColleagues(server.loadPlacesOfColleaguesFromServer()));
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Psender-> " + (sender as Picker).Items[(sender as Picker).SelectedIndex]);
        }
    }
}
