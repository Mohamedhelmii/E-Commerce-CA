namespace E_Commerce.Core.Entities.OrderAggregate
{
    public class Address
    {
        public Address() { }
        public Address(string firstName, string lastName, string street, string city, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            ZipCode = zipCode;
        }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
