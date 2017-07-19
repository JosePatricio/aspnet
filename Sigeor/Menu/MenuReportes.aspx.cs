using System;
using System.Diagnostics;
using System.Web.UI.WebControls;
using Negocio.Utilidades;
using Sigeor.Utilidades;

namespace Sigeor.Menu
{
    public partial class MenuReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    GestionUtil.RedireccionarSesionExpirada();
                    return;
                }

                GestionUtil.ControlAccesoPerfil(GestionUtil.UsuarioSesion.Cedula, this.Request.Url.LocalPath);
                subRepEir.Visible = false;
                subRepEor.Visible = false;
                subRepPti.Visible = false;

                if (!Page.IsPostBack)
                {
                    var menuSeleccionado = GestionUtil.MenuSeleccionado;

                    if (menuSeleccionado.ToString().Equals("hlinkEir"))
                    {
                        MostrarSubMenuEIR();
                    }

                    if (menuSeleccionado.ToString().Equals("hlinkCabEst") ||
                        menuSeleccionado.ToString().Equals("hlinkCabMaq") ||
                        menuSeleccionado.ToString().Equals("hlinkCabTran"))
                    {
                        MostrarSubMenuEOR();
                    }

                    if (menuSeleccionado.ToString().Equals("hlinkPti"))
                    {
                        MostrarSubMenuPTI();
                    }

                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("Ocurrió un error al iniciar la pagina " + this.NamingContainer + " " +ex, EventLogEntryType.Error);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "Ocurrió un error al recuprar la sesión en el Menu Reportes");
            }
        }
        private void MostrarSubMenuEIR()
        {
            this.repEIR.Visible = false;
            this.repPti.Visible = true;
            this.repEor.Visible = true;
            this.subRepEir.Visible = true;
            this.subRepPti.Visible = false;
            this.subRepEor.Visible = false;
        }
        private void MostrarSubMenuEOR()
        {
            this.repEIR.Visible = true;
            this.repPti.Visible = true;
            this.repEor.Visible = false;
            this.subRepEor.Visible = true;
            this.subRepPti.Visible = false;
            this.subRepEir.Visible = false;
        }
        private void MostrarSubMenuPTI()
        {
            this.repEIR.Visible = true;
            this.repEor.Visible = true;
            this.repPti.Visible = false;
            this.subRepPti.Visible = true;
            this.subRepEir.Visible = false;
            this.subRepEor.Visible = false;
        }
        protected void OnClickEventReportes(object sender, EventArgs e)
        {
            ImageButton b = (ImageButton)sender;

            if (sender is ImageButton)
            {
                if (b.ID.Equals("imgRepEir"))
                {
                    //Session["TituloMenu"] = b.ToolTip;
                    MostrarSubMenuEIR();
                    //GestionUtil.Redireccionar(ConstantesUtil.URL_ESTIMACION_EIR);

                }
                if (b.ID.Equals("imgRepEor"))
                {
                    MostrarSubMenuEOR();
                }

                if (b.ID.Equals("imgRepPti"))
                {
                    // Session["TituloMenu"] = b.ToolTip;
                    MostrarSubMenuPTI();
                    //GestionUtil.Redireccionar(ConstantesUtil.URL_ESTIMACION_EIR_MAQUINARIA_PTI);
                }


            }

        }

        protected void OnClickNavegacion(object sender, EventArgs e)
        {
            if (sender is LinkButton)
            {
                var linkButton = (LinkButton)sender;
                GestionUtil.MenuSeleccionado = linkButton.ID;
                Session["TituloMenu"] = linkButton.ToolTip;


                if (linkButton.ID.Equals("hlinkEir"))
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_ESTIMACION_EIR);
                }
                if (linkButton.ID.Equals("hlinkCabEst"))
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_REPORTE_CABECERA_EOR_ESTRUCTURA);
                }
                if (linkButton.ID.Equals("hlinkCabMaq"))
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_REPORTE_CABECERA_EOR_MAQUINARIA);
                }
                if (linkButton.ID.Equals("hlinkCabTran"))
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_REPORTE_CABECERA_EOR_TRANSITO);
                }
                if (linkButton.ID.Equals("hlinkPti"))
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_REPORTE_EIR_MAQUINARIA_PTI);
                }
                if (linkButton.ID.Equals("hlinkConsolidado"))
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_REPORTE_CONSOLIDADO_EOR);
                }

            }


        }


    }
}
