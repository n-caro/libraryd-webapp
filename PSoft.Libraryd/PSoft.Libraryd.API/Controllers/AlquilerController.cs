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

        // POST: api/<ClientesController>
        [HttpPost()]
        public IActionResult Post(AlquilerDTO alquiler)
        {
            try
            {
                if (alquiler.FechaReserva.HasValue)
                {
                    return new JsonResult(_service.CreateReserva(alquiler)) { StatusCode = 201 };
                }
                else
                {
                    return new JsonResult(_service.CreateAlquiler(alquiler)) { StatusCode = 201 };
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // PUT
        [HttpPut()]
        public IActionResult Put([Required] RequestAlquilerUpdate alquilerUpdate)
        {
            try
            {
                //bool result = _service.UpdateAlquiler(alquilerUpdate);
                return new JsonResult(_service.UpdateAlquiler(alquilerUpdate)) { StatusCode = 204 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
