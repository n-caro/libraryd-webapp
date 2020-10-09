using Microsoft.AspNetCore.Mvc;
using PSoft.Libraryd.Application.Services;
using System;

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
        /// <summary>
        /// Get List of Libros, optional filter by stock, author (autor) and title (titulo)
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="autor"></param>
        /// <param name="titulo"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetLibros([FromQuery] bool? stock, [FromQuery] string autor, [FromQuery] string titulo)
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
