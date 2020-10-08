using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSoft.Libraryd.Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PSoft.Libraryd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _service;

        public LibrosController(ILibroService service)
        {
            _service = service;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public IActionResult GetClientes([FromQuery] bool? stock, [FromQuery] string autor, [FromQuery] string titulo)
        {
            try
            {
                return new JsonResult(_service.GetLibros(stock, autor, titulo)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
