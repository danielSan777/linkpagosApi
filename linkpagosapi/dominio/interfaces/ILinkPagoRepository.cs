using linkpagosapi.aplicacion.dtos;

namespace linkpagosapi.dominio.interfaces
{
    public interface ILinkPagoRepository
    {   


        Task<List<LinkPago>>ObtenerTodos();

        Task Crear(LinkPago cliente);

        Task<LinkPago?> ObtenerPorId(int id);


        Task<List<LinkPago>> ObtenerPorCedula(string cedula);


        Task Actualizar(LinkPago cliente);

        Task Eliminar(LinkPago cliente);


        Task<PaginadoDto<LinkPagoDto>>ObtenerPaginado(
        int pagina,
        int tamanoPagina);






    }



}
