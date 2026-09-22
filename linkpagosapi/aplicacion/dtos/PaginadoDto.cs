namespace linkpagosapi.aplicacion.dtos
{   

    public class PaginadoDto<T>
    {
        public List<T> Data { get; set; }

        public int PaginaActual { get; set; }

        public int TamanoPagina { get; set; }

        public int TotalRegistros { get; set; }

        public int TotalPaginas { get; set; }


    }


}
