using BL.Handler;
using BL.Lists;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class Persona : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<clsPerson> Get()
        {
            return new clsPersonListBL().getPersons();

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public clsPerson Get(int id)
        {
            return new clsPersonListBL().getPerson(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] clsPerson value)
        {

            new clsHandlerPersonBL().insertPerson(value);

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] clsPerson value)
        {
            new clsHandlerPersonBL().updatePerson(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {


            new clsHandlerPersonBL().deletePerson(id);

        }
    }
}
