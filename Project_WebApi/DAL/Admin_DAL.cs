using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_WebApi.DAL
{
    public class Admin_DAL
    {
        ProjectEntities db = new ProjectEntities();

        public admin AdminGetById(string id)
        {
            admin obj = db.admins.Where(x => x.username == id).FirstOrDefault();
            return obj;
        }

        public admin adminsearch1(string id)
        {
            admin obj = db.admins.Where(x => x.username == id).FirstOrDefault();
            return obj;
        }
        public void ResetPassword(string id, string pwd)
        {
            admin obj = db.admins.Where(x => x.username == id).FirstOrDefault();
            obj.password = pwd;

            db.SaveChanges();
        }

        public IEnumerable<flightdetail> display1()
        {
            List<flightdetail> ls = db.flightdetails.ToList();
            return ls;

        }

        public flightdetail search1(string id)
        {
            flightdetail obj = db.flightdetails.Where(x => x.Flight_id == id).FirstOrDefault();
            return obj;
        }

        public void flightUpdate1(flightdetail obj1)
        {

            flightdetail obj = db.flightdetails.Where(x => x.Flight_id == obj1.Flight_id).FirstOrDefault();
            obj.Flight_id = obj1.Flight_id;

            obj.Flight_name = obj1.Flight_name;
            obj.Departure = obj1.Departure;
            obj.Destination = obj1.Destination;
            obj.Departure_time = obj1.Departure_time;
            obj.Arrival_time = obj1.Arrival_time;
            obj.Duration = obj1.Duration;
            obj.Total_Seats = Convert.ToInt32(obj1.Total_Seats);
            obj.Price = obj1.Price;
            obj.Date = obj1.Date;


            db.SaveChanges();
        }

        public void delete1(string id,string date)
        {

            List<passengerdetail> obj = db.passengerdetails.Where(x => x.Flight_id == id && x.Date == date).ToList();
            foreach(passengerdetail x in obj) { 
            db.passengerdetails.Remove(x);
            db.SaveChanges();
            }
            flightdetail obj1 = db.flightdetails.Where(x => x.Flight_id == id && x.Date == date).FirstOrDefault();
            db.flightdetails.Remove(obj1);
            db.SaveChanges();
        }

        public IEnumerable<passengerdetail> passengerGet1(string id, string date)
        {
            List<passengerdetail> ls = db.passengerdetails.Where(x => x.Flight_id == id && x.Date == date).ToList();
            return ls;

        }

        public void addflight(flightdetail obj)
        {
            db.flightdetails.Add(obj);
            db.SaveChanges();
        }


    }
}