using linkpagosapi.aplicacion.dtos;
using linkpagosapi.dominio.interfaces;
using linkpagosapi.infraestructura.data;
using Microsoft.EntityFrameworkCore;

namespace linkpagosapi.infraestructura.repositorios
{
     
    public class LinkPagoRepository: ILinkPagoRepository
    {

        private readonly PagosDbContext _context;


        public LinkPagoRepository(PagosDbContext context)
        {
            _context = context;
        }

        public async Task<List<LinkPago>> ObtenerTodos()
        {
            return await _context.linkPagos.ToListAsync();

        }

        public async Task Crear(LinkPago cliente)
        {

            await _context.linkPagos.AddAsync(cliente);

            await _context.SaveChangesAsync();

        }

        public async Task<LinkPago?> ObtenerPorId(int id)
        {
            return await _context.linkPagos
            .FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<List<LinkPago>> ObtenerPorCedula(string cedula)
        {
            return await _context.linkPagos
            .Where(c => c.Cedula == cedula).ToListAsync();
        }


        public async Task Actualizar(LinkPago linkPago)
        {
            await _context.SaveChangesAsync();
        }


        public async Task Eliminar(LinkPago cliente)
        {
            _context.linkPagos.Remove(cliente);

            await _context.SaveChangesAsync();

        }

        public async Task<PaginadoDto<LinkPagoDto>> ObtenerPaginado(int pagina, int tamanoPagina)
        {
            var consulta=_context.linkPagos
           .AsNoTracking()//
           .OrderBy(x => x.id);

            // Cantidad total de registros
            var totalRegistros = await consulta.CountAsync();

            // Cantidad total de páginas
            var totalPaginas = (int)Math.Ceiling(
                (double)totalRegistros / tamanoPagina
            );

            // Obtener los registros de la página solicitada
            var data = await consulta
                .Skip((pagina - 1) * tamanoPagina)
                .Take(tamanoPagina)
                .Select(x => new LinkPagoDto
                {
                    id= x.id,
                    nombre = x.nombre,
                    valor = x.valor,
                    Cedula = x.Cedula
                })
                .ToListAsync();

            return new PaginadoDto<LinkPagoDto>
            {
                Data = data,
                PaginaActual = pagina,
                TamanoPagina = tamanoPagina,
                TotalRegistros = totalRegistros,
                TotalPaginas = totalPaginas
            };
        }




    }
}
