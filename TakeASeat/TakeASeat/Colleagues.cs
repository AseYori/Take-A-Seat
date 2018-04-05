using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TakeASeat
{
    class Colleagues
    {
        private string _nameshortcut;
        public string Nameshortcut {
            get { return _nameshortcut; }
            set { _nameshortcut = value; OnPropertyChanged(nameof(Nameshortcut)); }
        }

        private string _name;
        public string Name {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        private string _surname;
        public string Surname {
            get { return _surname; }
            set { _surname = value; OnPropertyChanged(nameof(_surname)); }
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
