using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TakeASeat
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BuildingLevel : ContentPage
	{
        ServerConnection server = new ServerConnection();
		public BuildingLevel (List<String> Levels)
		{
            InitializeComponent();

            for(int i = 0; i < Levels.Count; i++)
            {
                Button btn = new Button()
                {
                    Text = Levels[i],
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                };

                btn.Clicked += Level_Clicked;


                StackLayoutLevelButtons.Children.Add(btn);

            }
		}

        public void Level_Clicked(object sender, EventArgs e)
        {

            Button btn = (sender as Button);
            Navigation.PushAsync(new LevelPlaces(server.loadPlacesOfALevelFromServer(btn.Text)));
        }
	}
}