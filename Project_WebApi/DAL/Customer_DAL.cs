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


        public void ResetPassword(string id,string pwd)
        {
            customer obj = db.customers.Where(x => x.username == id).FirstOrDefault();
            obj.password = pwd;
            db.SaveChanges();
        }

        public flightdetail GetFlightById(string flight_id,string date)
        {
            flightdetail obj = db.flightdetails.Where(x => x.Flight_id == flight_id && x.Date==date).FirstOrDefault();
            return obj;
        }


    }
}