using System.ComponentModel.DataAnnotations;

namespace DatingSite.Models
{
    public class City
    {
        [Key]
        public int Zipcode { get; set; }
        public string CityName { get; set; }
    }
}
