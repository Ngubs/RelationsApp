using System.ComponentModel.DataAnnotations.Schema;

namespace RelationsApp.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int UnitNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public int Zip { get; set; }
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }
    }
}
