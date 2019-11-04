using ClockApp.Models;
using System.Windows;
using System.Xml;

namespace ClockApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static App Instance;
        public string temperature;
        public string wind;
        public string pressure;
        public string humidity;
        public string clouds;
        public XmlDocument xmlDocument;
        void Appstartup(object sender ,StartupEventArgs e)
        {
            WeatherModel modelInstance = new WeatherModel();
            modelInstance.SetCurrentURL("istanbul");
            xmlDocument =  modelInstance.GetXML();
            XmlNode temp_node = xmlDocument.SelectSingleNode("//temperature");
            XmlAttribute temp_value = temp_node.Attributes["value"];
            string temp_string = temp_value.Value;
            temperature = temp_string;

            temp_node = xmlDocument.SelectSingleNode("//humidity");
            temp_value = temp_node.Attributes["value"];
            temp_string = temp_value.Value;
            humidity = temp_string;

            temp_node = xmlDocument.SelectSingleNode("//clouds");
            temp_value = temp_node.Attributes["name"];
            temp_string = temp_value.Value;
            clouds = temp_string;

            temp_node = xmlDocument.SelectSingleNode("//speed");
            temp_value = temp_node.Attributes["name"];
            temp_string = temp_value.Value;
            wind = temp_string;

            Instance = this;
          

        }
    }
}