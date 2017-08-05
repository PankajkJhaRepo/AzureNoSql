using Entity;
using IBusinessModel;
using Microsoft.WindowsAzure.Storage.Table;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class ApartmentController : ApiController
    {

        // GET api/values
        [SwaggerOperation("GetParties")]
        public List<Apartment> Get()
        {
            //TableStorageService<Apartment> StorageService = new TableStorageService<Apartment>("Apartment");
            //string pkFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, PartitionKey);
            //TableQuery<Apartment> query = new TableQuery<Apartment>().Where(pkFilter);
            //IEnumerable<Apartment> data = StorageService.GetRecord(query);
            //List<Apartment> Result = new List<Apartment>();
            //Apartment ApartmentAddress;
            //foreach (Apartment ent in data.Where(itm=> itm.TableName == ApartmentTableName))
            //{
            //    ApartmentAddress = data.FirstOrDefault(itm => itm.TableName == AddressTableName && itm.ID == ent.AddressId);
            //    ent.Address = ApartmentAddress.Address;
            //    Result.Add(ent);
            //}
            //return Result;

            //GetAllApartments();
            List<Apartment> Result = new List<Apartment>();
            ////Address ApartmentAddress;
            //var aResult = data.Where(itm => itm.TableName == ApartmentTableName) as List<Apartment>;
            //foreach (Apartment ent in data.Where(itm => itm.TableName == ApartmentTableName))
            //{
            //    var ApartmentAddress = data.FirstOrDefault(itm => itm.TableName == AddressTableName && itm.ID == ent.AddressId);
            //    //ent.Address = ApartmentAddress;
            //    Result.Add(ent);
            //}


            IApartmentBLL<Apartment> context = ControllerFactory.CreateApartmentBusinessModel();

            Result=context.GetAll();
            return Result;
        }

        private static void GetAllApartments()
        {
            //TableStorageService<Apartment> StorageService = new TableStorageService<Apartment>("Apartment");
            //string pkFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, PartitionKey);
            //TableQuery<Apartment> query = new TableQuery<Apartment>().Where(pkFilter);
            //IEnumerable<Apartment> ApartmentList = StorageService.GetRecord(query);
        }

        // GET api/values/5
        [SwaggerOperation("GetPartyById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public List<Apartment> Get(String id)
        {
            //TableStorageService<Apartment> StorageService = new TableStorageService<Apartment>("Apartment");
            //string pkFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Apartment");


            //string rkLowerFilter = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, id);



            ////string rkUpperFilter = TableQuery.GenerateFilterCondition("Email", QueryComparisons.Equal, "Walter@contoso.com");
            //string rkUpperFilter = TableQuery.GenerateFilterCondition("ID", QueryComparisons.Equal, id);


            //string filter = string.Format("({0}) {1} ({2}) {3} ({4})", pkFilter, TableOperators.And, rkLowerFilter, TableOperators.And, rkUpperFilter); ;
            //TableQuery<Apartment> query = new TableQuery<Apartment>().Where(filter);

            //IEnumerable<Apartment> data = StorageService.GetRecord(query);
            List<Apartment> Result = new List<Apartment>();
            //foreach (Apartment ent in data)
            //{
            //    Result.Add(ent);
            //}
            return Result;
        }

        // POST api/values
        [SwaggerOperation("CreateApartment")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public void Post([FromBody]Apartment apartment)
        {
            //TableStorageService<TableEntity> StorageService = new TableStorageService<TableEntity>("Apartment");
            //StorageService.CreateTable();

            //List<TableEntity> lst = new List<TableEntity>();
            //apartment.RowKey = apartment.ID.ToString();
            //apartment.PartitionKey = PartitionKey;
            //apartment.AddressId = apartment.Address.ID;
            //apartment.TableName = "Apartment";
            //lst.Add(apartment);

            //Address address = apartment.Address;
            //address.TableName = "Address";
            //address.RowKey = address.ID.ToString();
            //address.PartitionKey = apartment.PartitionKey;

            //lst.Add(address);

            //StorageService.BatchInsert(lst);


            //TableStorageService<BaseEntity> StorageService = new TableStorageService<BaseEntity>("Apartment");
            //StorageService.CreateTable();

            //List<BaseEntity> lst = new List<BaseEntity>();
            //apartment.RowKey = apartment.ID.ToString();
            //apartment.PartitionKey = PartitionKey;
            //apartment.AddressId = apartment.Address.ID;
            //apartment.TableName = "Apartment";
            //lst.Add(apartment);

            //Address address = apartment.Address;
            //address.TableName = "Address";
            //address.RowKey = address.ID.ToString();
            //address.PartitionKey = apartment.PartitionKey;

            //lst.Add(address);

            //StorageService.BatchInsert(lst);

            IApartmentBLL<Apartment> context = ControllerFactory.CreateApartmentBusinessModel();

            context.SaveModel(apartment);

        }

        //// PUT api/values/5
        //[SwaggerOperation("UpdateParty")]
        //[SwaggerResponse(HttpStatusCode.OK)]
        //[SwaggerResponse(HttpStatusCode.NotFound)]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[SwaggerOperation("DeleteParty")]
        //[SwaggerResponse(HttpStatusCode.OK)]
        //[SwaggerResponse(HttpStatusCode.NotFound)]
        //public void Delete(int id)
        //{
        //}
    }
}
