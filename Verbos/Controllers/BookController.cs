using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Verbos.Business;
using Verbos.Models;

namespace Verbos.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController:ControllerBase
    {


        private readonly ILogger<BookController> _logger;

        private IBookBusiness _IBookBusiness;
        
        public BookController(ILogger<BookController> logger, IBookBusiness ipersonBusiness)
        {
            _logger = logger;
            _IBookBusiness = ipersonBusiness;
        }

        [HttpGet]
       public IActionResult Get(){
           return Ok (_IBookBusiness.FindAllBook());
       }
    
        [HttpGet("{id}")]
       public IActionResult Get(long id){
           var person = _IBookBusiness.FindByIdBook(id);
           if (person == null) return NotFound();
           return Ok (person);
       }


        [HttpPost]
       public IActionResult Post([FromBody] Book book){ //pega o Json que vem no corpo da request e converte para um objeto person
           if (book == null) return BadRequest();
           return Ok (_IBookBusiness.CreateBook(book));
       }

        [HttpPut]
       public IActionResult Put([FromBody] Book book){ //pega o Json que vem no corpo da request e converte para um objeto person
           if (book == null) return BadRequest();
           return Ok (_IBookBusiness.UpdateBook(book));
       }

        [HttpDelete("{id}")]
       public IActionResult Delete(long id){
           _IBookBusiness.DeleteBook(id);
            return NoContent();
       }

    }
}