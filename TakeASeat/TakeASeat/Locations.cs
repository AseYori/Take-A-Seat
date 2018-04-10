using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TakeASeat
{
    class Locations
    {

        private string _locations;
        public string Location{
            get{return _locations;}
            set{_locations = value; OnPropertyChanged(nameof(Location)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
            
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
