using System;
using System.Diagnostics;
using System.Globalization;

namespace CSandbox
{
    
    public class TemperatureTypes
    {
        private const double Delta = .05;
        public abstract class Temperature
        {
            private protected double Value { get; init; }
            public static implicit operator float(Temperature temp) => (float) temp.Value;
            public static implicit operator double(Temperature temp) => temp.Value;
            public static implicit operator int(Temperature temp) => (int) temp.Value;

            public override string ToString()
            {
                return Value.ToString(CultureInfo.InvariantCulture);
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
                var temp = (Temperature) obj;
                return Math.Abs(Value - temp.Value) <= Delta;
            }

            public override int GetHashCode()
            {
                return (int)Value << 2;
            }
        }

        public class Celsius : Temperature
        {
            private string TempSymbol {get;} = "°C";

            public Celsius()
            {
                Console.WriteLine($"Input temperature in {TempSymbol} - ");
                Value = Convert.ToDouble(Console.ReadLine());
            }
            public Celsius(object obj)
            {
                Value = obj switch
                {
                    int i => i,
                    float f => f,
                    double d => d,
                    _ => throw new Exception()
                };
            }
        }
        
        public class Fahrenheit : Temperature
        {
            private string TempSymbol {get;} = "°F";

            public Fahrenheit()
            {
                Console.WriteLine($"Input temperature in {TempSymbol} - ");
                Value = Convert.ToDouble(Console.ReadLine());
            }
            public Fahrenheit(object obj)
            {
                Value = obj switch
                {
                    int i => i,
                    float f => f,
                    double d => d,
                    _ => throw new Exception()
                };
            }
        }
    }
}