using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using System;
using System.ComponentModel.DataAnnotations;


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
        /// <summary>
        /// Finds Alquileres by estado
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAlquileres([FromQuery][Required] int estado)
        {
            try
            {
                return new JsonResult(_service.GetAlquileres(estado)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = true, message = e.Message });
            }
        }

        // GET: api/<ClientesController>/cliente/id
        /// <summary>
        /// Get Alquileres by Cliente Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("cliente/{id?}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new JsonResult(_service.GetAlquileresByCliente(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = true, message = e.Message });
            }
        }

        // POST: api/<ClientesController>
        /// <summary>
        /// Create a Alquiler or Reserva
        /// </summary>
        /// <param name="alquiler"></param>
        /// <returns></returns>
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
                return BadRequest(new { error = true, message = e.Message });
            }
        }
        /// <summary>
        /// Update Reserva into Alquiler.
        /// </summary>
        /// <param name="alquilerUpdate"></param>
        /// <returns></returns>
        [HttpPut()]
        public IActionResult Put([Required] RequestAlquilerUpdate alquilerUpdate)
        {
            try
            {
                return new JsonResult(_service.UpdateAlquiler(alquilerUpdate)) { StatusCode = 204 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = true, message = e.Message });
            }
        }
    }
}
