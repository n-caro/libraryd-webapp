using Microsoft.AspNetCore.Mvc;
using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using System;
using System.ComponentModel.DataAnnotations;

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
        /// <summary>
        /// Get All Clientes or optional find Clientes by nombre, apellido, dni
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetClientes([FromQuery] string nombre, [FromQuery] string apellido, [FromQuery] string dni)
        {
            try
            {
                return new JsonResult(_service.GetClientes(nombre, apellido, dni)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = true, message = e.Message });
            }
        }

        /// <summary>
        /// Create a new Cliente
        /// </summary>
        /// <param name="clienteDTO"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult Post([Required] ClienteDTO clienteDTO)
        {
            try
            {
                return new JsonResult(_service.CreateCliente(clienteDTO)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = true, message = e.Message });
            }
        }
    }
}
