using Microsoft.AspNetCore.Mvc;
using PSoft.Libraryd.Application.Services;
using System;

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

        [HttpGet]
        public IActionResult GetLibrosClientes([FromQuery] bool? stock, [FromQuery] string autor, [FromQuery] string titulo)
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
