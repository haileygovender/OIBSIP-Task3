using System.ComponentModel.DataAnnotations;
namespace TemperatureConverter.Models
{

    public class ValueClass
    {
        [Required(ErrorMessage = "Please enter a temperature.")]
        [RegularExpression(@"^\d+\.?\d*$", ErrorMessage = "Please enter a valid number.")]
        public double Temperature { get; set; }

        public string? FromUnit { get; set; }
        public string? ToUnit { get; set; }
        public double ConvertedTemperature { get; set; }
    }
}
