using linkpagosapi.aplicacion.dtos;
using linkpagosapi.dominio.interfaces;
using Microsoft.EntityFrameworkCore;

namespace linkpagosapi.aplicacion.servicios
{
    public class LinkPagoService
    {

        private readonly ILinkPagoRepository _repositoryLinPago;


        public LinkPagoService(ILinkPagoRepository repository)
        {
            _repositoryLinPago = repository;
        }


        public async Task<List<LinkPagoDto>> ObtenerTodos()
        {
            var linkPago = await _repositoryLinPago.ObtenerTodos();

            return linkPago.Select(c => new LinkPagoDto
            {
                id = c.id,
                nombre = c.nombre,
                Cedula = c.Cedula,
                valor = c.valor
            }).ToList();
        }


        public async Task<LinkPagoDto> Crear(CrearLinkPagoDto dto)
        {
            // Crear la entidad
            var linkPago = new LinkPago
            {
                nombre = dto.nombre,
                Cedula = dto.Cedula,
                valor = dto.valor
            };

            // Guardar
            await _repositoryLinPago.Crear(linkPago);

            // Convertir Entity → DTO
            return new LinkPagoDto
            {
                id=linkPago.id,
                nombre=linkPago.nombre,
                Cedula=linkPago.Cedula,
                valor=linkPago.valor
            };
        }



        public async Task<LinkPagoDto?> ObtenerPorId(int id)
        {
            var linkPago = await _repositoryLinPago.ObtenerPorId(id);

            if (linkPago == null)
                return null;


            return new LinkPagoDto
            {
                id = linkPago.id,
                nombre = linkPago.nombre,
                Cedula = linkPago.Cedula,
                valor = linkPago.valor
            };
        }


        public async Task<LinkPagoDto?> Actualizar(
        int id,
        CrearLinkPagoDto dto)
        {
            var linkPago=await _repositoryLinPago.ObtenerPorId(id);

            if(linkPago==null)
                return null;

            linkPago.nombre=dto.nombre;
            linkPago.Cedula=dto.Cedula;
            linkPago.valor = dto.valor;
            
            await _repositoryLinPago.Actualizar(linkPago);

            return new LinkPagoDto
            {
                id=linkPago.id,
                nombre=linkPago.nombre,
                Cedula=linkPago.Cedula,
                valor=linkPago.valor
               
            };
        }


        public async Task<bool> Eliminar(int id)
        {
            var linkPago=await _repositoryLinPago.ObtenerPorId(id);

            if(linkPago==null)
                return false;

            await _repositoryLinPago.Eliminar(linkPago);

            return true;
        }


        public async Task<List<LinkPagoDto>> ObtenerPorCedula(string cedula)
        {
            var linkPago=await _repositoryLinPago
                .ObtenerPorCedula(cedula);

            if(linkPago==null)
                return null;

            return linkPago.Select(l => new LinkPagoDto
            {
                id = l.id,
                nombre = l.nombre,
                Cedula = l.Cedula,
                valor = l.valor
            }).ToList(); 

        }


        public async Task<PaginadoDto<LinkPagoDto>> ObtenerPaginado(
        int pagina,
        int tamanoPagina)
        {
            return await _repositoryLinPago.ObtenerPaginado(
                pagina,
                tamanoPagina
            );
        }








    }


}
