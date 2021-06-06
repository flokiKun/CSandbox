using System;

namespace CSandbox
{
    class Program
    {
        private static void Main(string[] args)
        {
            var temp1 = new TemperatureTypes.Celsius(32.5) ;
            var temp2 = new TemperatureTypes.Fahrenheit(137.7);
            Console.WriteLine($" Celsius is {temp1} Fahrenheit is {temp2}");
        }
    }
}