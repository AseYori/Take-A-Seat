using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TakeASeat
{
    class PlaceOccupations
    {
        private string _workplace;
        public string Workplace {
            get { return _workplace; }
            set { _workplace = value; OnPropertyChanged(nameof(Workplace)); }
        }

        private string _nameshortcut;
        public string Nameshortcut {
            get { return _nameshortcut; }
            set { _nameshortcut = value; OnPropertyChanged(nameof(Nameshortcut)); }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(nameof(Status)); }
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
