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
	public partial class SearchingColleagues : ContentPage
	{
		public SearchingColleagues (List<string> listOfPlacesFromColleagues)
		{
			InitializeComponent ();

            this.BindingContext = listOfPlacesFromColleagues; //new[] { "a", "b", "c" };
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            Console.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}