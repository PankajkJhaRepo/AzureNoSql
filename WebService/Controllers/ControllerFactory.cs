using BusinessModel.Apartment;
using BusinessModel.Device;
using Entity;
using IBusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Controllers
{
    public  class ControllerFactory
    {
        public static IApartmentBLL<Apartment> CreateApartmentBusinessModel()
        {
            // IBusinessModelContext<ApartmentBLL,Apartment> context=new 
            IApartmentBLL<Apartment> context = new ApartmentBLL<Apartment>();
            return context;

        }
        public static IInputDeviceBLL<DeviceInput> CreateDeviceBusinessModel()
        {
            // IBusinessModelContext<ApartmentBLL,Apartment> context=new 
            IInputDeviceBLL<DeviceInput> context = new InputDeviceBLL<DeviceInput>();
            return context;

        }
        public static IDeviceBLL<DeviceReading> CreateDocumentdbDeviceBusinessModel()
        {
            // IBusinessModelContext<ApartmentBLL,Apartment> context=new 
            IDeviceBLL<DeviceReading> context = new DeviceBLL<DeviceReading>();
            return context;

        }
    }
}