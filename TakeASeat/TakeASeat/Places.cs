using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TakeASeat
{
    
    class Places
    {
        private string _workplace;
        public string Workplace {
            get { return _workplace; }
            set{ _workplace = value; OnPropertyChanged(nameof(Workplace)); }
        }

        private string _room;
        public string Room {
            get { return _room; }
            set { _room = value; OnPropertyChanged(nameof(Room)); }
        }

        private string _level;
        public string Level {
            get { return _level; }
            set { _level = value; OnPropertyChanged(nameof(Level)); }
        }

        private string _location;
        public string Location {
            get { return _location; }
            set { _location = value; OnPropertyChanged(nameof(Location)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }



    }
}
