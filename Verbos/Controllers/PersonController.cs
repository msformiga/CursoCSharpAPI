using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Verbos.Business;
using Verbos.Models;



namespace Verbos.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;

        private IPersonBusiness _IpersonBusiness;
        public PersonController(ILogger<PersonController> logger, IPersonBusiness ipersonBusiness)
        {
            _logger = logger;
            _IpersonBusiness = ipersonBusiness;
        }

        [HttpGet]
       public IActionResult Get(){
           return Ok (_IpersonBusiness.FindAll());
       }
    
        [HttpGet("{id}")]
       public IActionResult Get(long id){
           var person = _IpersonBusiness.FindById(id);
           if (person == null) return NotFound();
           return Ok (person);
       }


        [HttpPost]
       public IActionResult Post([FromBody] Person person){ //pega o Json que vem no corpo da request e converte para um objeto person
           if (person == null) return BadRequest();
           return Ok (_IpersonBusiness.Create(person));
       }

        [HttpPut]
       public IActionResult Put([FromBody] Person person){ //pega o Json que vem no corpo da request e converte para um objeto person
           if (person == null) return BadRequest();
           return Ok (_IpersonBusiness.Update(person));
       }

        [HttpDelete("{id}")]
       public IActionResult Delete(long id){
           _IpersonBusiness.Delete(id);
            return NoContent();
       }

    }
}
