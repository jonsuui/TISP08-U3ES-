using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Producto
/// </summary>
public class Producto
{
    public int IdProducto { get; set; }
    public string Nombre { get; set; }
    public string Marca { get; set; }
    public decimal Precio { get; set; }

    public string Descripcion { get; set; }
    public string  UrlImagen { get; set; }
    public Producto()
    {
        //
        // TODO: Add constructor logic here
        //
       
    }
}