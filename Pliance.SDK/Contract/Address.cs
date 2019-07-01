namespace Pliance.SDK.Contract
{
    public class Address
    {
        public string Street1 { get; }
        public string Street2 { get; }
        public string City { get; }
        public string StreetNo { get; }
        public string PostalCode { get; }
        public string Country { get; }

        public Address(string street1, string street2, string city, string streetNo, string postalCode, string country)
        {
            Street1 = street1;
            Street2 = street2;
            City = city;
            StreetNo = streetNo;
            PostalCode = postalCode;
            Country = country;
        }
    }
}