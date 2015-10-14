using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi103.Data;
using WebApi103.Models;

namespace WebApi103.Controllers
{
    public class PersonController : ApiController
    {
      
        [Route("api/{person}")]
        public string Get()
        {
            return "test";
        }


        [Route("api/{person}/{id}")]
        public Person Get(int id)
        {
            IUOW uofwork = new UOW();

            return uofwork.person.GetId(id);

        }


        //header = Content-type: application/json
        [Route("api/{person}")]
        public HttpResponseMessage Post([FromBody] Person person)
        {


            IUOW uofwork = new UOW();

            uofwork.person.Create(person);
            uofwork.Commit();
            var response = Request.CreateResponse<Person>(HttpStatusCode.Created, person);
           
            return response;
        }

    }
}
