using System.Windows;
using System.Windows.Controls;
using ClockApp.Models;

namespace ClockApp
{
    /// <summary>
    /// Interaction logic for AlarmsView.xaml
    /// </summary>
    public partial class WeatherView : UserControl
    {
       
        public static WeatherView Instance { get; set; }
        public string temperature;
        public string wind;
        public string humidity;
        public string clouds;


        public WeatherView()
        {
            Instance = this;
            temperature = App.Instance.temperature;
            humidity = App.Instance.humidity;
            clouds = App.Instance.clouds;
            wind = App.Instance.wind;
            InitializeComponent();
            
        }

        public void SetTemperature()
        {   
            TempText.Text = temperature + "°C";
            WindText.Text = wind;
            CloudText.Text = clouds;
            HumidityText.Text = "%" + humidity;

        }
        private void SetTempEvent(object sender, RoutedEventArgs e)
        {
            SetTemperature();


        }


    }
}