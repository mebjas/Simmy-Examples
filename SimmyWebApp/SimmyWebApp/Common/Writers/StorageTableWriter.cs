namespace SimmyWebApp.Common.Writers
{
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;

    public class StorageTableWriter
    {
        private CloudTable table;

        public StorageTableWriter(string connectionString, string tableName)
        {
            //// TODO: argument checks

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            this.table = tableClient.GetTableReference(tableName);
            this.table.CreateIfNotExists();
        }

        public async Task InsertOrReplaceAsync(ITableEntity entity)
        {
            TableOperation insertOperation = TableOperation.InsertOrReplace(entity);
            await this.table.ExecuteAsync(insertOperation).ConfigureAwait(false);
        }
    }
}