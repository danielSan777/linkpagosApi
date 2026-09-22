
using System.ComponentModel.DataAnnotations.Schema;


[Table("pagos")]

public class LinkPago
    {

    public int id { get; set; }

    public string nombre { get; set; } = string.Empty;

    public string Cedula { get; set; } = string.Empty;

    public decimal valor { get; set; }



}




