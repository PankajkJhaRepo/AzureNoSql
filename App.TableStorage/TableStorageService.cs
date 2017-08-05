using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Table; // Namespace for Table storage types

namespace App.TableStorage
{
    public class TableStorageService<T>
         where T : TableEntity, new()
    {

        CloudStorageAccount StorageAccount = null;
        String _TableName;
        public TableStorageService(String TableName)
        {
            StorageAccount = TableStorageAccount.GetCloudStorageAccount();
            this._TableName = TableName;

        }

        public bool CreateTable()
        {
            bool result = true;
            // Create the table client.
            CloudTableClient tableClient = StorageAccount.CreateCloudTableClient();

            // Retrieve a reference to the table.
            CloudTable table = tableClient.GetTableReference(_TableName);

            // Create the table if it doesn't exist.
            result = table.CreateIfNotExists();
            return result;
        }

        public bool Insert(T record)
        {
            bool result = true;

            // Create the table client.
            CloudTableClient tableClient = StorageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference(_TableName);

            // Create the table if it doesn't exist.
            table.CreateIfNotExists();

            //// Create the TableOperation object that inserts the customer entity.
            TableOperation insertOperation = TableOperation.Insert(record);

            //// Execute the insert operation.
            table.Execute(insertOperation);

            return result;

        }
        public bool BatchInsert(List<T> records)
        {
            bool result = true;

            // Create the table client.
            CloudTableClient tableClient = StorageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference(_TableName);

            // Create the table if it doesn't exist.
            table.CreateIfNotExists();
            // Create the batch operation.
            TableBatchOperation batchOperation = new TableBatchOperation();
            foreach(T record in records)
            {
                batchOperation.Insert(record);
            }

            //// Execute the insert operation.
            table.ExecuteBatch(batchOperation);

            return result;

        }
        public IEnumerable<T> GetRecord(TableQuery<T> query)
        {

            // Create the table client.
            CloudTableClient tableClient = StorageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference(_TableName);
            var result= table.ExecuteQuery(query);
            return result;

            // Construct the query operation for all customer entities where PartitionKey="Smith".
            //TableQuery<T> query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Smith"));

            //// Print the fields for each customer.
            //foreach (T entity in table.ExecuteQuery(query))
            //{
            //    Console.WriteLine("{0}, {1}\t{2}\t{3}", entity.PartitionKey, entity.RowKey,
            //        entity.Email, entity.PhoneNumber);
            //}
        }



    }
}
