using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_WebApi.DAL
{
    public class Customer_DAL
    {
        ProjectEntities db = new ProjectEntities();

        public customer GetCustomerById(string id)
        {
            customer obj = db.customers.Where(x => x.username == id).FirstOrDefault();
            return obj;
        }

        public void RegisterCustomer(customer obj)
        {
            db.customers.Add(obj);
            db.SaveChanges();
        }

        public void RegisterPassenger(passengerdetail obj)
        {
            db.passengerdetails.Add(obj);
            db.SaveChanges();
        }


        public void ResetPassword(string id,string pwd)
        {
            customer obj = db.customers.Where(x => x.username == id).FirstOrDefault();
            obj.password = pwd;
            db.SaveChanges();
        }

        public void SetSeat(string flight_id, string date,string[] seat_nos)
        {
            foreach (string seat_no in seat_nos)
            {

                flightseat obj = db.flightseats.Where(x => x.Flight_id == flight_id && x.Date == date && x.Seat_no == seat_no).FirstOrDefault();
                obj.Value = 0;
                db.SaveChanges();
            }
        }

        public void ReduceSeat(string flight_id, string date, int Total_Seat)
        {

            flightdetail obj = db.flightdetails.Where(x => x.Flight_id == flight_id && x.Date == date).FirstOrDefault();
            obj.Total_Seats = Total_Seat;
            db.SaveChanges();
        }

        public flightdetail GetFlightById(string flight_id,string date)
        {
            flightdetail obj = db.flightdetails.Where(x => x.Flight_id == flight_id && x.Date==date).FirstOrDefault();
            return obj;
        }

        public List<flightdetail> getflightdetails(string from, string to, string date)
        {
            List<flightdetail> obj = db.flightdetails.Where(x => x.Departure == from && x.Destination == to && x.Date == date).ToList();
            return obj;

        }
        public flightdetail getflightdetails1(string flightid, string date)
        {
            flightdetail obj = db.flightdetails.Where(x => x.Flight_id == flightid && x.Date == date).FirstOrDefault();
            return obj;

        }

      

        public List<flightseat> getseatdetails1(string flightid, string date)
        {
            List<flightseat> obj = db.flightseats.Where(x => x.Flight_id == flightid && x.Date == date).ToList();
            return obj;

        }

        public flightdetail GetPassengerDetails(string passengerID)
        {
            /*flightdetail obj = db.flightdetails.Where(s => db.passengerdetails.Select(rs => rs.Passenger_id).Contains(passengerID)).FirstOrDefault();*/
            flightdetail obj = db.passengerdetails.Where(x => x.Passenger_id == passengerID).Select(s => s.flightdetail).FirstOrDefault();
            return obj;

        }
        public void DeletePassenger(string passengerid)
        {
            passengerdetail obj = db.passengerdetails.Where(x => x.Passenger_id == passengerid).FirstOrDefault();
            db.passengerdetails.Remove(obj);
            db.SaveChanges();

        }
        public void UpdatePassenger(string PassengerID, passengerdetail obj1)
        {
            passengerdetail obj = db.passengerdetails.Where(x => x.Passenger_id == PassengerID).FirstOrDefault();
            obj.Status = obj1.Status;
            obj.WaitingList = obj1.WaitingList;
            obj.Seat = obj1.Seat;
            db.SaveChanges();
        }
        public List<passengerdetail> GetPassengerDetails1(string flight_id, string Date)
        {

            List<passengerdetail> obj = db.passengerdetails.Where(x => x.WaitingList != 0 && x.Flight_id == flight_id && x.Date == Date).ToList();
            return obj;

        }
        public List<passengerdetail> GetPassengerDetails2(string Flight_id, string Date, int waitingListNo)
        {

            List<passengerdetail> obj = db.passengerdetails.Where(x => x.WaitingList > waitingListNo && x.Flight_id == Flight_id && x.Date == Date).ToList();
            return obj;

        }

        public void UpdateSeat(string Flightid, string Date, flightdetail obj1)
        {
            flightdetail obj = db.flightdetails.Where(x => x.Flight_id == Flightid && x.Date == Date).FirstOrDefault();
            obj.Total_Seats = obj1.Total_Seats;
            db.SaveChanges();
        }
        public void UpdateSeat1(string seat, passengerdetail obj1)
        {
            flightseat obj = db.flightseats.Where(x => x.Flight_id == obj1.Flight_id && x.Date == obj1.Date && x.Seat_no == seat).FirstOrDefault();
            obj.Value = 1;
            db.SaveChanges();
        }



    }
}