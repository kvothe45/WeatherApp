using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void citySelect_Click(object sender, RoutedEventArgs e)
        {
            var tempConversion = new ConvertTempTo();
            var city = cityName.Text;
            if (city == "")
            {
                city = "dallas";
            }
            RootObject weatherData = await WeatherModel.GetWeatherAsync(city);
            string displayString = $"Weather for {city}\n" +
                                   $"Lat:  {weatherData.coord.lat}\n" +
                                   $"Lon:  {weatherData.coord.lon}\n" +
                                   $"Temperature:  {tempConversion.Fahrenheit(tempConversion.Celsius(weatherData.main.temp))}\n" +
                                   $"High:  {tempConversion.Fahrenheit(tempConversion.Celsius(weatherData.main.temp_max))}\n" +
                                   $"Low:  {tempConversion.Fahrenheit(tempConversion.Celsius(weatherData.main.temp_min))}\n";
            foreach (var element in weatherData.weather)
            {
                displayString += $"Main:  {element.main}\n" +
                                 $"Description:  {element.description}\n" +
                                 $"Icon:  {element.icon}\n";
            }
            displayString += $"Humidity:  {weatherData.main.humidity}\n" +
                 $"Pressure:  {weatherData.main.pressure}\n";
            weatherDisplayBox.Text = displayString;
        }
    }
}