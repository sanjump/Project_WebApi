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

        [HttpPost]
        [ActionName("PassengerPost1")]
        public void Customertpost1([FromBody] passengerdetail obj)
        {
            dl.RegisterPassenger(obj);

        }



        [HttpPut]
       [ActionName("Customerupdate1")]
        public void Userupdate1(string id, [FromBody] string pwd)
        {
            dl.ResetPassword(id, pwd);
           
        }

        [HttpPut]
        [ActionName("SetSeat")]
        public void SetSeat(string flight_id, string date, [FromBody] string[] seat_no)
        {
            dl.SetSeat(flight_id, date,seat_no);

        }

        [HttpPut]
        [ActionName("ReduceSeat")]
        public void ReduceSeat(string flight_id, string date, [FromBody] int Total_Seat)
        {
            dl.ReduceSeat(flight_id, date, Total_Seat);

        }

        [HttpGet]
        [ActionName("FlightGet1")]
        public flightdetail FlightGet1(string flight_id,string date)
        {
            flightdetail obj1 = dl.GetFlightById(flight_id,date);
            return obj1;
        }

        [HttpGet]
        [ActionName("getflightdetails")]
        public List<flightdetail> getflightdetails(string from, string to, string date)
        {
            List<flightdetail> obj1 = dl.getflightdetails(from, to, date);
            return obj1;
        }


        [HttpGet]
        [ActionName("getflightdetails1")]
        public flightdetail getflightdetails1(string flightid, string date)
        {
            flightdetail obj1 = dl.getflightdetails1(flightid, date);
            return obj1;
        }

       

        [HttpGet]
        [ActionName("getseatdetails1")]
        public List<flightseat> getseatdetails1(string flightid, string date)
        {
            List<flightseat> obj1 = dl.getseatdetails1(flightid, date);
            return obj1;
        }

        [HttpGet]
        [ActionName("GetPassengerDetails")]
        public flightdetail GetPassengerDetails(string passengerID)
        {

            flightdetail obj1 = dl.GetPassengerDetails(passengerID);

            return obj1;
        }


        [HttpGet]
        [ActionName("GetPassengerDetails1")]
        public List<passengerdetail> GetPassengerDetails1(string flight_id, string Date)
        {

            List<passengerdetail> ls = dl.GetPassengerDetails1(flight_id, Date);

            return ls;
        }
        [HttpGet]
        [ActionName("GetPassengerDetails2")]
        public List<passengerdetail> GetPassengerDetails2(string Flight_id, string Date, int waitingListNo)
        {

            List<passengerdetail> ls = dl.GetPassengerDetails2(Flight_id, Date, waitingListNo);

            return ls;
        }
        [HttpPut]
        [ActionName("UpdatePassenger")]
        public void UpdatePassenger(string PassengerID, [FromBody] passengerdetail obj1)
        {
            dl.UpdatePassenger(PassengerID, obj1);

        }


        [HttpDelete]
        [ActionName("DeletePassenger")]
        public void DeletePassenger(string passengerid)
        {
            dl.DeletePassenger(passengerid);

        }

        [HttpPut]
        [ActionName("UpdateSeat")]
        public void UpdateSeat(string id, string date, [FromBody] flightdetail obj1)
        {
            dl.UpdateSeat(id, date, obj1);

        }

        [HttpPut]
        [ActionName("UpdateSeat1")]
        public void UpdateSeat1(string seat, [FromBody] passengerdetail obj1)
        {
            dl.UpdateSeat1(seat, obj1);

        }


    }
}