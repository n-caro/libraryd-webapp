using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PSoft.Libraryd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClientesController(IClienteService service)
        {
            _service = service;
        }


        // GET: api/<ClientesController>
        [HttpGet]
        public IActionResult GetClientes([FromQuery] string nombre, [FromQuery] string apellido, [FromQuery] string dni)
        {
            try
            {
                return new JsonResult(_service.GetClientes(nombre, apellido, dni)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/<ClientesController>
        [HttpPost()]
        public IActionResult Post(ClienteDTO clienteDTO)
        {
            try
            {
                return new JsonResult(_service.CreateCliente(clienteDTO)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
