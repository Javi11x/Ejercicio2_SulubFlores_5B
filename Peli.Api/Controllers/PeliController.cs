using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Peli.Infraestructure.Repositories;
using Peli.Domain.entities;
using Microsoft.AspNetCore.Http;

namespace Peli.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliController : ControllerBase
    {
        [HttpGet]
        [Route("films")]
        public IActionResult GetTodasPeliculas()
        {
            PeliSqlRepository pelis = new PeliSqlRepository();
            return Ok(pelis.GetTodasPeliculas());
        }

        [HttpGet]
        [Route("films/{id}")]
        public IActionResult ObtenerId(int id)
        {
            PeliSqlRepository pelis = new PeliSqlRepository();
            var peli = pelis.ObtenerId(id);
            if(peli == null)
            {
                return NotFound($"No existe ninguna Película con este id: {id}");
            }
            return Ok(peli);
        }

        [HttpGet]
        [Route("Director")]
        public IActionResult ObtenerDirector (string director)
        {
            PeliSqlRepository peli = new PeliSqlRepository();
            var pelis = peli.ObtenerDirector(director);
            if(pelis.Count() == 0)
            {
                return NotFound($"No existe ninguna película con el director: {director}");
            }
            return Ok(pelis);
        }
        


        [HttpPost]
        [Route("Create")]
        public IActionResult CrearPelicula(Pelicula nuevaPeli)
        {
            PeliSqlRepository pelis = new PeliSqlRepository();
            try
            {
                pelis.CrearPelicula(nuevaPeli);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "No se pudo crear la película, prueba dejar la idPeli en 0");
            }
            return Ok("Película creada correctamente");
            

        }

        [HttpPut]
        [Route("Put")]
        public IActionResult ActualizarPelicula(int id, Pelicula actualizarPelicula)
        {
            PeliSqlRepository pelis = new PeliSqlRepository();
            var validar = pelis.ObtenerId(id);
            if(validar == null)
            {
                return NotFound($"No existe ninguna película con el id: {id}");
            }
            pelis.ActualizarPelicula(id, actualizarPelicula);
            return Ok("La película se ha actualizado correctamente");
        }

        [HttpDelete]
        [Route("Detele")]
        public IActionResult BorrarPelicula(int id)
        {
            PeliSqlRepository pelis = new PeliSqlRepository();
            var validar = pelis.ObtenerId(id);
            if(validar == null)
            {
                return NotFound($"No existe ninguna película con el id: {id}");
            }
            pelis.BorrarPelicula(id);
            return Ok("La película se eliminó correctamente");
        }
    }
}