using ReneMartinez.Interfaces;
using ReneMartinez.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReneMartinez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private IArticuloApplication _articuloApplication { get; set; }

        public ArticulosController(IArticuloApplication articuloApplication)
        {
            _articuloApplication = articuloApplication;
        }

        /// <summary>
        /// Obtener la lista de articulos
        /// </summary>
        /// <returns>Regresa objeto de tipo <see cref="List{T}<"/></returns>
        [HttpGet, Route("")]
        [ProducesResponseType(typeof(List<Articulo>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Articulo>>> ObtenerArticulosAsync()
        {
            try
            {
                var response = await _articuloApplication.ObtenerArticulosAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Obtener un articulo por articuloId
        /// </summary>
        /// <returns>Regresa objeto de tipo <see cref="List{T}<"/></returns>
        [HttpGet, Route("{articuloId}")]
        [ProducesResponseType(typeof(Articulo), StatusCodes.Status200OK)]
        public async Task<ActionResult<Articulo>> ObtenerArticuloAsync(int articuloId)
        {
            try
            {
                var response = await _articuloApplication.ObtenerArticuloAsync(articuloId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Agregar un articulo
        /// </summary>
        /// <param name="payload">Parametro de tipo <see cref="Articulo"/>.Modelo para agregar un articulo</param>
        /// <returns>Regresa objeto de tipo <see cref="{T}<"/></returns>
        [HttpPost, Route("")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> AgregarArticuloAsync(ArticuloDTO articulo)
        {
            try
            {
                var response = _articuloApplication.AgregarArticuloAsync(articulo);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Eliminar un articulo por articuloId
        /// </summary>
        /// <returns>Regresa objeto de tipo <see cref="bool<"/></returns>
        [HttpDelete, Route("{articuloId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> EliminarArticuloAsync(int articuloId)
        {
            try
            {
                var response = await _articuloApplication.EliminarArticuloAsync(articuloId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
