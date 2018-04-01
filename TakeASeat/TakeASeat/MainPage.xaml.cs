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




        public MainPage()
		{
            server = new ServerConnection();
            server.IsConnecting = false;
            BindingContext = server;
			InitializeComponent();

		}

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {

            //Console.WriteLine("nameshortcut: " + nameshortcut.Text);
            //Console.WriteLine("name: " + name.Text);
            //Console.WriteLine("surname: " + surname.Text);
            server.IsConnecting = true;
            //await Task.Delay(5000);
            await server.SendColleagueRequest(nameshortcut.Text, name.Text, surname.Text);
            server.IsConnecting = false;
            //await Navigation.PushAsync(new BuildingLevel(server.loadLevelsFromServer()));
        }

        private void SearchingButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchingColleagues(server.loadPlacesOfColleaguesFromServer()));
        }

       
    }
}
