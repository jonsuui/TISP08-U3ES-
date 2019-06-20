using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using U3_AF8;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                //RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
            ConexionDB conn = new ConexionDB();
            conn.OpenConection();
            SqlDataReader dr = conn.DataReader("Select Id_usuario, nombre From usuario where usuario = '"+ UserName.Text+"' and password = '" + Password.Text + "'");
            if (dr.HasRows)
            {
                dr.Read();
                HttpContext.Current.Session["UserId"] = dr["Id_usuario"].ToString();
                HttpContext.Current.Session["UserName"] = dr["Nombre"].ToString();
                conn.CloseConnection();
                IdentityHelper.RedirectToReturnUrl("~/default", Response);
            }
            else
            {
                conn.CloseConnection();
                FailureText.Text = "Usuario o password invalidos.";
                ErrorMessage.Visible = true;
            }

            }
        }
}