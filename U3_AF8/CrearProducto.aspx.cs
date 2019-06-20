using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CrearProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserId"] == null)
        {
            U3_AF8.IdentityHelper.RedirectToReturnUrl("~/login", Response);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ConexionDB conn = new ConexionDB();

        conn.OpenConection();
        conn.ExecuteQueries("insert into producto values ('" + Nombre.Text + "','" + Marca.Text + "'," + Precio.Text + ",'','" + Descripcion.Text + "')");
        conn.CloseConnection();
    }
}