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
	public partial class LevelPlaces : ContentPage
	{
		public LevelPlaces (List<String> listOfPlaces)
		{

			InitializeComponent ();

            for(int i = 0; i < listOfPlaces.Count; i++)
            {
                Button btn = new Button
                {
                    Text = listOfPlaces[i]
                };

                StackLayoutPlaces.Children.Add(btn);
            }
		}
	}
}