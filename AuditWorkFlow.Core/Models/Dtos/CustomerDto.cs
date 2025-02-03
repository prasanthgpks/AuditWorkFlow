namespace AuditWorkFlow.Core.Models.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string CountryCode { get; set; }

        public string PhoneNumber { get; set; }

        public string PanNumber { get; set; }
    }
}
