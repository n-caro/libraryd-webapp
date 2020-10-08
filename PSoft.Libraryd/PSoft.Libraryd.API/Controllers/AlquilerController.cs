using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSoft.Libraryd.Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PSoft.Libraryd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly IAlquilerServices _service;
        public AlquilerController(IAlquilerServices service)
        {
            _service = service;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public IActionResult GetAlquileres([FromQuery][Required] int estado)
        {
            try
            {
                return new JsonResult(_service.GetAlquileres(estado)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // GET: api/<ClientesController>/cliente/id
        [HttpGet("cliente/{id?}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new JsonResult(_service.GetAlquileresByCliente(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
