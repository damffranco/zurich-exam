namespace Zurich.Insurance.Domain.Entities
{
    public class Customer
    {
        public string ExternalId { get; set; }
        public string Nome { get; set; }
        public DateTime BirthDate { get; set; }
        public string DocId { get; set; }
    }
}
