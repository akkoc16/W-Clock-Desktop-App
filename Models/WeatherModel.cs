using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http;
using System.Net;
using System.Xml;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClockApp.Models
{

    public class WeatherModel: INotifyPropertyChanged
    {
        public string Title { get; set; } = "Temperature";
        private const string APIKEY = "e339e932539ff62c7ef6d1edd5825377";
        private string CurrentURL;
        private XmlDocument xmlDocument;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string GetTemp()
        {
            XmlNode temp_node = xmlDocument.SelectSingleNode("//temperature");
            XmlAttribute temp_value = temp_node.Attributes["value"];
            string temp_string = temp_value.Value;
            Console.WriteLine(temp_string);
            return temp_string;
           
        }

       

        public void SetCurrentURL(string location)
        {
            CurrentURL = "http://api.openweathermap.org/data/2.5/weather?q="
                + location + "&mode=xml&units=metric&APPID=" + APIKEY;
        }
        public XmlDocument GetXML()
        {
            using (WebClient client = new WebClient())
            {
                Console.WriteLine(CurrentURL);
                string xmlContent = client.DownloadString(CurrentURL);
                Console.WriteLine(xmlContent);
                xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlContent);
                return xmlDocument;
            }
        }
    }
}