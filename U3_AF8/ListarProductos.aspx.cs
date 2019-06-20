using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListarProductos : System.Web.UI.Page
{
    ConexionDB conn = new ConexionDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserId"] == null)
        {
            U3_AF8.IdentityHelper.RedirectToReturnUrl("~/login", Response);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        gvbind();
        //conn.OpenConection();
        //SqlDataReader dr = conn.DataReader("select [Id_producto],[nombre],[marca],[precio],[imagen],[descripcion] from producto ");
        //gvwProductos.DataSource = dr;
        //gvwProductos.DataBind();
        //conn.CloseConnection();
    }

    protected void gvwProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvwProductos.PageIndex = e.NewPageIndex;
        gvbind();
    }

    protected void gvwProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvwProductos.EditIndex = -1;
        gvbind();
    }

    protected void gvwProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)gvwProductos.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblID");
        conn.OpenConection();
        conn.ExecuteQueries("delete FROM producto where id_producto=" + Convert.ToInt32(gvwProductos.DataKeys[e.RowIndex].Value.ToString()) );
        conn.CloseConnection();
        gvbind();
    }

    protected void gvwProductos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvwProductos.EditIndex = e.NewEditIndex;
        gvbind();
    }

    protected void gvwProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int productId = Convert.ToInt32(gvwProductos.DataKeys[e.RowIndex].Value.ToString());
        GridViewRow row = (GridViewRow)gvwProductos.Rows[e.RowIndex];
        Label lblID = (Label)row.FindControl("lblID");  
        TextBox textNombre = (TextBox)row.Cells[1].Controls[0];
        TextBox textMarca = (TextBox)row.Cells[2].Controls[0];
        TextBox textPrecio = (TextBox)row.Cells[3].Controls[0];
        TextBox textDesc = (TextBox)row.Cells[4].Controls[0];
        long precio = 0;
        if (Int64.TryParse(textPrecio.Text, out precio))
        {
            gvwProductos.EditIndex = -1;
            conn.OpenConection();
            conn.ExecuteQueries("update producto set nombre='" + textNombre.Text + "',marca='" + textMarca.Text + "',precio=" + precio + ",descripcion='" + textDesc.Text + "' where id_producto=" + productId.ToString());
            conn.CloseConnection();
            lblresult.Text = "";
            gvbind();
        } else
        {
            lblresult.Text = "El precio ingresado no es valido.";
        }
        
    }

    protected void gvbind()
    {
        conn.OpenConection();
        SqlDataReader dr = conn.DataReader("select [Id_producto],[nombre],[marca],[precio],[imagen],[descripcion] from producto ");
        DataTable dtCustomers = new DataTable("Productos");
        dtCustomers.Load(dr);
        
        if (dtCustomers.Rows.Count > 0)
        {
            gvwProductos.DataSource = dtCustomers;
            gvwProductos.DataBind();
        }
        else
        {
            dtCustomers.Rows.Add(dtCustomers.NewRow());
            gvwProductos.DataSource = dtCustomers;
            gvwProductos.DataBind();
            int columncount = gvwProductos.Rows[0].Cells.Count;
            gvwProductos.Rows[0].Cells.Clear();
            gvwProductos.Rows[0].Cells.Add(new TableCell());
            gvwProductos.Rows[0].Cells[0].ColumnSpan = columncount;
            gvwProductos.Rows[0].Cells[0].Text = "No hay registros";
        }
        conn.CloseConnection();
    }


}