using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using App.TableStorage;
using Microsoft.WindowsAzure.Storage.Table;

namespace NoSqlDataAccess
{
    public class DeviceInputDataAccess<T> : INoSqlDataAccess<Entity.DeviceInput>
    {
        //EntityResolver<BaseNoSqlEntity> dataResolver = (pk, rk, ts, props, etag) =>
        //{
        //    BaseNoSqlEntity resolvedEntity = null;
        //    string TableName = props["TableName"].StringValue;

        //    if (TableName == ApartmentConstants.TableName) { resolvedEntity = new Apartment(); }
        //    else if (TableName == "Address") { resolvedEntity = new Address(); }
        //    //else if (shapeType == "Line") { resolvedEntity = new LineEntity(); }
        //    // Potentially throw here if an unknown shape is detected 

        //    resolvedEntity.PartitionKey = pk;
        //    resolvedEntity.RowKey = rk;
        //    resolvedEntity.Timestamp = ts;
        //    resolvedEntity.ETag = etag;
        //    resolvedEntity.ReadEntity(props, null);

        //    return resolvedEntity;
        //};
        public List<DeviceInput> GetAll()
        {
            //TableStorageService<BaseNoSqlEntity> StorageService = new TableStorageService<BaseNoSqlEntity>(DeviceInputDataConstants.TableName);
            //string pkFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, ApartmentConstants.PartitionKey);
            //TableQuery<BaseNoSqlEntity> query = new TableQuery<BaseNoSqlEntity>().Where(pkFilter);
            //IEnumerable<BaseNoSqlEntity> data = StorageService.GetRecord(query);
            List<DeviceInput> Result = new List<DeviceInput>();
            //Apartment ApartmentAddress;
            //foreach (Apartment ent in data.Where(itm => itm.TableName == ApartmentConstants.TableName))
          //  foreach (BaseNoSqlEntity  ent in data)
            {
              //var d=  dataResolver(ent.PartitionKey, ent.RowKey, ent.Timestamp, TableEntity.Flatten(ent,new Microsoft.WindowsAzure.Storage.OperationContext() ), ent.ETag);
 
               // var d1 = ent as Address;
                //ApartmentAddress = data.FirstOrDefault(itm => itm.TableName == TableName && itm.ID == ent.AddressId);
                //ent.Address = ApartmentAddress.Address;
                //Result.Add(ent);
            }
            
            return Result;
        }

        public bool SaveBatch(List<BaseAzureTableStorage> entities)
        {
            TableStorageService<BaseAzureTableStorage> StorageService = new TableStorageService<BaseAzureTableStorage>(DeviceInputDataConstants.TableName);
            StorageService.CreateTable();
            return StorageService.BatchInsert(entities);
        }

        public bool SaveBatch(List<DeviceInput> entities)
        {
            throw new NotImplementedException();
        }

        public bool Save(DeviceInput entity)
        {
            //List<Entity.BaseNoSqlEntity> lst = new List<Entity.BaseNoSqlEntity>();
            //entity.RowKey = entity.ID.ToString();
            //entity.PartitionKey = ApartmentConstants.PartitionKey;
            //entity.TableName = "Device";

            //lst.Add(entity);

            //Entity.Address address = entity.Address;
            //address.PartitionKey = ApartmentConstants.PartitionKey;
            //address.TableName = "Address";
            //address.RowKey = address.ID.ToString();


            //lst.Add(address);
            //return SaveBatch(lst);
            TableStorageService<BaseAzureTableStorage> StorageService = new TableStorageService<BaseAzureTableStorage>(DeviceInputDataConstants.TableName);
            StorageService.CreateTable();
            return StorageService.Insert(entity);
        }

        public List<DeviceInput> GetAllReadings(string DeviceId)
        {
            throw new NotImplementedException();
        }

        public List<DeviceInput> GetReading(string Id, string DeviceId)
        {
            throw new NotImplementedException();
        }

        DeviceInput INoSqlDataAccess<DeviceInput>.GetReading(string Id, string DeviceId)
        {
            throw new NotImplementedException();
        }
    }
}
