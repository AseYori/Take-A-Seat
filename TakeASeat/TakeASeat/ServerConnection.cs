using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TakeASeat
{
    class ServerConnection : INotifyPropertyChanged
    {
        private const string _URI = "http://192.168.178.127/";
        // create url
        private const string _COLLEAGUE_CREATE = "colleagues/create.php?";
        private const string _PLACEOCCUPATION_CREATE = "placeoccupation/create.php?";

        // read url
        private const string _COLLEAGUE_READ = "colleagues/read.php";
        private const string _PLACES_READ = "places/readAll.php";
        private const string _PLACESOCCUPATION_READ = "placeoccupation/read.php";
        private const string _LOCATIONS_READ = "locations/read.php";
        private const string _PLACES_AVAILABLE_READ = "places/readAvailable.php";

        private bool _isConnecting;
        public bool IsConnecting
        {
            get
            {
                return _isConnecting;
            }

            set
            {
                _isConnecting = value;

                OnPropertyChanged(nameof(IsConnecting));
            }
        }

        public ServerConnection()
        {}


        public async Task<bool> SendColleagueRequest(string nameshortcut, string name, string surname)
        {

            var request = new HttpRequestMessage();
            var nameshortcutUri = "nameshortcut=" + nameshortcut;
            var nameUri = "name=" + name;
            var surnameUri = "surname=" + surname;
            request.RequestUri = new Uri(_URI + _COLLEAGUE_CREATE + nameshortcutUri + "&" + nameUri + "&" + surnameUri);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var requestResults = await sendRequest(request);
            return await Task.FromResult(true);

        }

        //TODO Read Methods for 3 tables

        public async Task<String> readPlacesRequest()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(_URI + _PLACES_READ);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var requestResults = await sendRequest(request);
            return await Task.FromResult<string>(requestResults);
        }

        public async Task<String> readColleaguesRequest()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(_URI + _COLLEAGUE_READ);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var requestResults = await sendRequest(request);
            return await Task.FromResult<string>(requestResults);
        }

        public async Task<String> readPlaceOccupationsRequest()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(_URI + _PLACESOCCUPATION_READ);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var requestResults = await sendRequest(request);
            return await Task.FromResult<string>(requestResults);
        }


        //TODO Create another method for placesoccuppation

        public async Task<string> sendRequest(HttpRequestMessage request)
        {

            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Successfully");
            }
            else
            {
                Console.WriteLine("Failure");
                
            }
            HttpContent content = response.Content;
            var json = await content.ReadAsStringAsync();
            
            return await Task<string>.FromResult(json);
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
