using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity;
using Swashbuckle.Swagger.Annotations;
using IBusinessModel;

namespace WebService.Controllers
{
    public class DeviceController : ApiController
    {
        // POST api/values
        [SwaggerOperation("SaveReading")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public void Post([FromBody] DeviceReading input)
        {
            //IInputDeviceBLL<DeviceInput> context = ControllerFactory.CreateDeviceBusinessModel();

            //context.SaveModel(input);

            IDeviceBLL<DeviceReading> context = ControllerFactory.CreateDocumentdbDeviceBusinessModel();

            context.Save(input);

        }
        // POST api/values
        [SwaggerOperation("GetAllReading")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public List<DeviceReading> Get(string DeviceId)
        {
            //IInputDeviceBLL<DeviceInput> context = ControllerFactory.CreateDeviceBusinessModel();

            //context.SaveModel(input);

            IDeviceBLL<DeviceReading> context = ControllerFactory.CreateDocumentdbDeviceBusinessModel();

            return context.GetAllReadings(DeviceId);

        }
        // POST api/values
        [SwaggerOperation("GetReading")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public DeviceReading Get(string Id,string DeviceId)
        {
            //IInputDeviceBLL<DeviceInput> context = ControllerFactory.CreateDeviceBusinessModel();

            //context.SaveModel(input);

            IDeviceBLL<DeviceReading> context = ControllerFactory.CreateDocumentdbDeviceBusinessModel();

           return  context.GetReading(Id,DeviceId);

        }
    }
}
