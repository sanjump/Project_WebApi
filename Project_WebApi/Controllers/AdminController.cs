using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project_WebApi.DAL;

namespace Project_WebApi.Controllers
{
    public class AdminController : ApiController
    {

        Admin_DAL dl = new Admin_DAL();
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("AdminGet1")]
        public admin AdminGet1(string id)
        {
            admin obj1 = dl.AdminGetById(id);
            return obj1;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("adminuserget2")]
        public admin adminuserget2(string id)
        {

            admin obj = dl.adminsearch1(id);
            return obj;


        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.ActionName("adminupdate1")]
        public void Userupdate1(string id, [FromBody] string pwd)
        {
            dl.ResetPassword(id, pwd);

        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("userget2")]
        public IEnumerable<flightdetail> userget2()
        {
            IEnumerable<flightdetail> ls1;
            ls1 = dl.display1();
            return ls1;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("userget1")]
        public flightdetail userget1(string id)
        {

            flightdetail obj = dl.search1(id);
            return obj;


        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.ActionName("flightDetailsPut")]
        public void flightDetailsPut([FromBody] flightdetail obj)
        {
            dl.flightUpdate1(obj);


        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.ActionName("deleteflight")]
        // DELETE api/values/5
        public void deleteflight(string id,string date)
        {
            dl.delete1(id,date);


        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("passengerGet")]
        public IEnumerable<passengerdetail> passengerGet(string fid, string date)
        {
            IEnumerable<passengerdetail> ls1;
            ls1 = dl.passengerGet1(fid, date);
            return ls1;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("flightpost1")]
        public void flightpost1([FromBody] flightdetail obj)
        {
            dl.addflight(obj);


        }


    }
}