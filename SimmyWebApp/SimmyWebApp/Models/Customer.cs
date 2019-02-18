namespace SimmyWebApp.Models
{
    using Microsoft.WindowsAzure.Storage.Table;

    public class Customer : TableEntity
    {
        public Customer(string tenantId, string userId, string firstName, string lastName)
        {
            this.PartitionKey = tenantId;
            this.RowKey = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}