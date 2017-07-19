using Sigeor.Utilidades;
using System;
using System.Web.UI;


namespace Sigeor.Autenticacion
{
    public partial class SessionExpirada : System.Web.UI.Page
    {

        protected void Load_SessionExpirada(Object sender, EventArgs e)
        {
            if (Request.UrlReferrer != null)
                if (!Request.UrlReferrer.ToString().Contains("Autenticacion/SesionExpirada"))
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "Maximizar Pagina", "maximize();", true);

        }

        public SessionExpirada()
        {

        }

        protected void OnClick(object sender, EventArgs e)
        {
            GestionUtil.RedireccionarLogin();
        }
    }
}
