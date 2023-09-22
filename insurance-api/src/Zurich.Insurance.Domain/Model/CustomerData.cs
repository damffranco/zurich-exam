namespace Zurich.Insurance.Domain.Model
{
    public sealed class CustomerData
    {
        public string CustomerExternalId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string DocId { get; set; }
    }
}
