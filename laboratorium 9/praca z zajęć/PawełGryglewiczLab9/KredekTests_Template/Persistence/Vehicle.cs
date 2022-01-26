using System.ComponentModel.DataAnnotations;

namespace KredekTests_Template
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int? YearOfProduction { get; set; }
        public decimal? Worth { get; set; }

        public int Power { get; set; }

        public Vehicle()
        {
        }

        public Vehicle(string manufacturer, string model, int yearOfProduction, int worth)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.YearOfProduction = yearOfProduction;
            this.Worth = worth;
        }
    }
}
