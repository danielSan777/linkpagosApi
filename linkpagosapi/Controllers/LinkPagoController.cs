using linkpagosapi.aplicacion.dtos;
using linkpagosapi.aplicacion.servicios;
using Microsoft.AspNetCore.Mvc;

namespace linkpagosapi.Controllers
{
    [ApiController]
    [Route("api/linkPago")]
    public class LinkPagoController:ControllerBase
    {

        private readonly LinkPagoService _linkPagoService;

        public LinkPagoController(LinkPagoService service)
        {
            _linkPagoService=service;
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var linkPagos=await _linkPagoService.ObtenerTodos();

            return Ok(linkPagos);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CrearLinkPagoDto dto)
        {
            var linkPago=await _linkPagoService.Crear(dto);
            return Ok(linkPago);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(
        int id,
        CrearLinkPagoDto dto)
        {
            var linkPago = await _linkPagoService.Actualizar(id, dto);

            if (linkPago == null)
                return NotFound(new
                {
                    mensaje = "El link pago no existe"
                });

            return Ok(linkPago);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _linkPagoService.Eliminar(id);

            if (!eliminado)
                return NotFound(new
                {
                    mensaje = "El linkPago no existe"
                });

            return NoContent();
        }


        [HttpGet("porId/{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var linkPago=await _linkPagoService
                .ObtenerPorId(id);
            return Ok(linkPago);
        }


        [HttpGet("cedula/{cedula}")]
        public async Task<IActionResult> ObtenerPorCedula(string cedula)
        {
            var linkPago=await _linkPagoService
                .ObtenerPorCedula(cedula);

            return Ok(linkPago);
        }


        [HttpGet("paginado")]
        public async Task<IActionResult> ObtenerPaginado(
          int pagina = 1,
          int tamanoPagina = 5)
        {
            var resultado = await _linkPagoService.ObtenerPaginado(
                pagina,
                tamanoPagina
            );

            return Ok(resultado);
        }








    }
}
