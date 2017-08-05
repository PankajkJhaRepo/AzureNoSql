using System;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Entity;
using System.Linq;
using System.Collections.Generic;

namespace App.CosmodbStorage
{
    public class DocumentdbService<T>
         where T : BaseDocumentdb, new()
    {
        DocumentClient client = null;
        public DocumentdbService()
        {
            string endpoint = DocumentDbAccount.GetDocumentdbEndPoint();
            string authKey = DocumentDbAccount.GetDocumentdbKey();
            client = new DocumentClient(new Uri(endpoint), authKey);
        }
        public async Task<bool> CreateDatabase()
        {
            bool result = false;
            var db = await client.CreateDatabaseAsync(new Database { Id = Constants.dbName });
            // Collection for device telemetry. Here the JSON property deviceId is used  
            // as the partition key to spread across partitions. Configured for 2500 RU/s  
            // throughput and an indexing policy that supports sorting against any  
            // number or string property.
            if (db != null)
            {
                DocumentCollection myCollection = new DocumentCollection();
                myCollection.Id = Constants.DeviceCollectionName;
                myCollection.PartitionKey.Paths.Add("/" + Constants.DevicePartitionKeyName);

                await client.CreateDocumentCollectionAsync(
                    UriFactory.CreateDatabaseUri(Constants.dbName),
                    myCollection,
                    new RequestOptions { OfferThroughput = 2500 });

                result = true;
            }
            return result;
        }
        public bool Create(T reading)
        {
            var result =  client.CreateDocumentAsync(
      UriFactory.CreateDocumentCollectionUri(Constants.dbName, Constants.DeviceCollectionName), reading).Result ;
            if (result != null)
                return true;
            else
                return false;

        }


        public  T Get(string Id, string DeviceId)
        {
            // Read document. Needs the partition key and the Id to be specified
            Document result =  client.ReadDocumentAsync(
              UriFactory.CreateDocumentUri(Constants.dbName, Constants.DeviceCollectionName, Id),
              new RequestOptions { PartitionKey = new PartitionKey(DeviceId) }).Result ;

            T reading = (T)(dynamic)result;

            return reading;
        }
        public  List<T> Get(string DeviceId)
        {

            // Query using partition key
            IQueryable<T> query = client.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(Constants.dbName , Constants.DeviceCollectionName ))
                .Where(m => m.DeviceId == DeviceId);
            return query.ToList();
        }
        public async Task<bool> Update(T reading)
        {
            // Read document. Needs the partition key and the Id to be specified
            var result = await client.ReplaceDocumentAsync(
   UriFactory.CreateDocumentUri(Constants.dbName, Constants.DeviceCollectionName, reading.Id),
   reading);

            if (result != null)
                return true;
            else
                return false;
        }

        public async Task<bool> Delete(T reading)
        {
            // Read document. Needs the partition key and the Id to be specified
            var result = await client.DeleteDocumentAsync(
  UriFactory.CreateDocumentUri(Constants.dbName, Constants.DeviceCollectionName, reading.Id),
  new RequestOptions { PartitionKey = new PartitionKey(reading.DeviceId) });

            if (result != null)
                return true;
            else
                return false;
        }
    }
}
