namespace WeatherApp
{
    public class ConvertTempTo
    {
        public double Fahrenheit(double tempInCelsius)
        {
            double temperature;

            temperature = tempInCelsius * 9 / 5 + 32;

            return temperature;
        }

        public double Celsius(double tempInKelvin)
        {
            double temperature;

            temperature = tempInKelvin - 273.15;

            return temperature;
        }
    }
}
