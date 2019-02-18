namespace SimmyWebApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Threading.Tasks;

    using Microsoft.Azure;

    using SimmyWebApp.Models;
    using SimmyWebApp.Common.Writers;

    public class CustomerController : ApiController
    {
        private static Lazy<StorageTableWriter> writer = new Lazy<StorageTableWriter>(() => {
            return new StorageTableWriter(CloudConfigurationManager.GetSetting("StorageTableConnectionString"), "testTable");
        });

        [Route("api/v1/customer")]
        public async Task<string> PutAsync(string firstName, string lastName)
        {
            //// TODO: change this all
            string tenantId = "0633d5ee-5a7d-46fa-bf6a-054f194ec493";
            string customerId = "ef2a89b7-3a18-4383-8742-938f4b5fd5ce";

            Customer customer = new Customer(tenantId, customerId, firstName, lastName);
            await writer.Value.InsertOrReplaceAsync(customer);
            return "OK";
        }
    }
}
