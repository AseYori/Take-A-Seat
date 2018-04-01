﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TakeASeat
{
    class ServerConnection : INotifyPropertyChanged
    {
        private const string _URI = "http://192.168.178.127/colleagues/create.php?";


        public ServerConnection()
        {

            var uri = "http://192.168.178.127/database/phpliteadmin.php";
        }


        public async Task<bool> SendColleagueRequest(string nameshortcut, string name, string surname)
        {

            var request = new HttpRequestMessage();
            var nameshortcutUri = "nameshortcut=" + nameshortcut;
            var nameUri = "name=" + name;
            var surnameUri = "surname=" + surname;
            request.RequestUri = new Uri(_URI + nameshortcutUri + "&" + nameUri + "&" + surnameUri);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Successfully");
                return await Task.FromResult(false);
            }
            else
            {
                Console.WriteLine("Failure");
                
            }
            HttpContent content = response.Content;
            var json = await content.ReadAsStringAsync();
            Console.WriteLine("Json: " + json);
            return await Task.FromResult(true);

        }


        private bool _isConnecting;
        public bool IsConnecting {
            get {
                return _isConnecting;
            }

            set {
                _isConnecting = value;

                OnPropertyChanged(nameof(IsConnecting));
            }
        }

        private String _serverName;
        public String ServerName {
            get {
                return _serverName;
            }

            set
            {
                _serverName = value;

                OnPropertyChanged(nameof(ServerName));
            }
        }

        private List<String> _listOfLevels = new List<string>();
        public List<String> ListOfLevels
        {
            get { return _listOfLevels; }
            set
            {
                _listOfLevels = value;

                OnPropertyChanged(nameof(ListOfLevels));
            }
        }

        private List<String> _listOfPlaces = new List<string>();
        public List<String> ListOfPlaces
        {
            get { return _listOfPlaces; }
            set
            {
                _listOfPlaces = value;

                OnPropertyChanged(nameof(ListOfPlaces));
            }
        }

        public List<String> loadLevelsFromServer()
        {
            _listOfLevels.Add("EG");
            _listOfLevels.Add("OG");
            

            return ListOfLevels;
        }

        public List<String> loadPlacesOfALevelFromServer(string level)
        {
            _listOfPlaces.Clear();
            if (level == "EG")
            {
                _listOfPlaces.Add("Place1");
                _listOfPlaces.Add("Place2");
                _listOfPlaces.Add("Place3");
            }
            else if (level == "OG")
            {
                _listOfPlaces.Add("Place4");
                _listOfPlaces.Add("Place5");
                _listOfPlaces.Add("Place6");
                _listOfPlaces.Add("Place7");
            }
            return _listOfPlaces;
        }


        private List<String> _listOfPlacesOfColleagues = new List<string>();

        public List<String> ListOfPlacesOfColleagues
        {
            get
            {
                return _listOfPlacesOfColleagues;
            }

            set
            {
                _listOfPlacesOfColleagues = value;

                OnPropertyChanged(nameof(ListOfPlacesOfColleagues));
            }
        }


        public List<String> loadPlacesOfColleaguesFromServer()
        {
            _listOfPlacesOfColleagues.Add("ColleaguePlace1");
            _listOfPlacesOfColleagues.Add("ColleaguePlace2");
            _listOfPlacesOfColleagues.Add("ColleaguePlace3");
            _listOfPlacesOfColleagues.Add("ColleaguePlace4");
            _listOfPlacesOfColleagues.Add("ColleaguePlace5");
            _listOfPlacesOfColleagues.Add("ColleaguePlace6");

            return _listOfPlacesOfColleagues;

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
