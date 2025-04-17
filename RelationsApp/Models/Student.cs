namespace RelationsApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
