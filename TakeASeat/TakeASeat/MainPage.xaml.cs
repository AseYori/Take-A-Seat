using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TakeASeat
{
	public partial class MainPage : ContentPage
	{

        private ServerConnection server;
        private List<string> _locations = new List<string>();
        public List<string> Locations
        {
            get { return _locations; }

            set
            {
                _locations = value;

                OnPropertyChanged(nameof(Locations));
            }
        }

       

        private BuildingLevel buildingLvl;

        public MainPage()
		{
            
            
            server = new ServerConnection();
            BindingContext = server;
            server.IsConnecting = false;
            
            InitializeComponent();

            Locations.Add("WBN");
            Locations.Add("DUS");
            Locations.Add("DT");
            locationPicker.BindingContext = this;



        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {

            server.IsConnecting = true;

            //await server.SendColleagueRequest(nameshortcut.Text, name.Text, surname.Text);
            //string places = await server.readPlacesRequest();
            string colleagues = await server.readColleaguesRequest();
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
