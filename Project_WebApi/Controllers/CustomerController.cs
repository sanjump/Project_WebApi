using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project_WebApi.DAL;

namespace Project_WebApi.Controllers
{
    public class CustomerController : ApiController
    {
       
        Customer_DAL dl = new Customer_DAL();
        
        [HttpGet]
        [ActionName("CustomerGet1")]
        public customer CustomerGet1(string id)
        {
            customer obj1 = dl.GetCustomerById(id);
            return obj1;
        }

        [HttpPost]
        [ActionName("CustomerPost1")]
        public void Customertpost1([FromBody] customer obj)
        {
            dl.RegisterCustomer(obj);

        }


       [HttpPut]
       [ActionName("Customerupdate1")]
        public void Userupdate1(string id, [FromBody] string pwd)
        {
            dl.ResetPassword(id, pwd);
           
        }

        [HttpGet]
        [ActionName("FlightGet1")]
        public flightdetail FlightGet1(string flight_id,string date)
        {
            flightdetail obj1 = dl.GetFlightById(flight_id,date);
            return obj1;
        }


    }
}