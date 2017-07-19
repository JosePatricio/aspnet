using System;
using System.Diagnostics;
using System.Web.UI.WebControls;
using Negocio.Utilidades;
using Sigeor.Utilidades;

namespace Sigeor.Menu
{
    public partial class MenuControl : System.Web.UI.Page
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
                subEstructura.Visible = false;
                subMaquinaria.Visible = false;
                subTransito.Visible = false;
                subReparacion.Visible = false;
                subRepositorio.Visible = false;
                subNegociaciones.Visible = false;

                if (!Page.IsPostBack)
                {
                    var menuSeleccionado = GestionUtil.MenuSeleccionado;

                    if (menuSeleccionado.ToString().Equals("hlinkCalculoEstructura"))
                    {
                        MostarSubMenuEstructura();
                    }
                    if (menuSeleccionado.ToString().Equals("hlinkCalculoMaquinaria"))
                    {
                        MostarSubMenuMaquinaria();
                    }
                    //if (menuSeleccionado.ToString().Equals("hlinkDanos"))
                    //{
                    //    MostarSubMenuTransito();
                    //}
                    if (menuSeleccionado.ToString().Equals("hlinkReparaciones") || menuSeleccionado.ToString().Equals("hlinkDanos"))
                    {
                        MostarSubMenuReparacion();
                    }
                    if (menuSeleccionado.ToString().Equals("hlinkDocumental"))
                    {
                        MostarSubMenuRepositorio();
                    }
                    if (menuSeleccionado.ToString().Equals("hlinkNegociacionLinea") ||
                        menuSeleccionado.ToString().Equals("hlinkNegociacionProveedor") ||
                        menuSeleccionado.ToString().Equals("hlinkGestionProveedor"))
                    {
                        MostrarSubMenuNegociaciones();
                    }
                    //if (menuSeleccionado.ToString().Equals("hlinkNegociacionProveedor"))
                    //{
                    //    MostrarSubMenuNegociaciones();
                    //}

                }

            }
            catch (Exception ex)
            {
                Log.WriteEntry("Ocurrió un error al iniciar la pagina " + this.NamingContainer + " " + ex, EventLogEntryType.Error);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "Ocurrió un error al recuprar la sesión en el Menu Reportes");
            }
        }

        private void MostarSubMenuEstructura()
        {
            estructura.Visible = false;
            subEstructura.Visible = true;
            maquinaria.Visible = true;
            subMaquinaria.Visible = false;
            danos.Visible = true;
            subTransito.Visible = false;
            subReparacion.Visible = false;
            reparacion.Visible = true;
            repositorio.Visible = true;
            subRepositorio.Visible = false;
            negociaciones.Visible = true;
            subNegociaciones.Visible = false;
        }
        private void MostarSubMenuMaquinaria()
        {
            estructura.Visible = true;
            subEstructura.Visible = false;
            maquinaria.Visible = false;
            subMaquinaria.Visible = true;
            danos.Visible = true;
            subTransito.Visible = false;
            subReparacion.Visible = false;
            reparacion.Visible = true;
            repositorio.Visible = true;
            subRepositorio.Visible = false;
            negociaciones.Visible = true;
            subNegociaciones.Visible = false;
        }
        private void MostarSubMenuTransito()
        {
            estructura.Visible = true;
            subEstructura.Visible = false;
            maquinaria.Visible = true;
            subMaquinaria.Visible = false;
            danos.Visible = false;
            subTransito.Visible = true;
            subReparacion.Visible = false;
            reparacion.Visible = true;
            repositorio.Visible = true;
            subRepositorio.Visible = false;
            negociaciones.Visible = true;
            subNegociaciones.Visible = false;
        }
        private void MostarSubMenuReparacion()
        {
            estructura.Visible = true;
            subEstructura.Visible = false;
            maquinaria.Visible = true;
            subMaquinaria.Visible = false;
            danos.Visible = true;
            subTransito.Visible = false;
            subReparacion.Visible = true;
            reparacion.Visible = false;
            repositorio.Visible = true;
            subRepositorio.Visible = false;
            negociaciones.Visible = true;
            subNegociaciones.Visible = false;
        }
        private void MostarSubMenuRepositorio()
        {
            estructura.Visible = true;
            subEstructura.Visible = false;
            maquinaria.Visible = true;
            subMaquinaria.Visible = false;
            danos.Visible = true;
            subTransito.Visible = false;
            subReparacion.Visible = false;
            reparacion.Visible = true;
            repositorio.Visible = false;
            subRepositorio.Visible = true;
            negociaciones.Visible = true;
            subNegociaciones.Visible = false;
        }
        private void MostrarSubMenuNegociaciones()
        {
            estructura.Visible = true;
            subEstructura.Visible = false;
            maquinaria.Visible = true;
            subMaquinaria.Visible = false;
            danos.Visible = true;
            subTransito.Visible = false;
            subReparacion.Visible = false;
            reparacion.Visible = true;
            repositorio.Visible = true;
            subRepositorio.Visible = false;
            negociaciones.Visible = false;
            subNegociaciones.Visible = true;

        }
        protected void OnClickEventControl(object sender, EventArgs e)
        {
            ImageButton b = sender as ImageButton;

            if (sender != null)
            {
                if (b.ID.Equals("imgEstructura"))
                {

                    MostarSubMenuEstructura();
                }
                if (b.ID.Equals("imgMaquinaria"))
                {

                    MostarSubMenuMaquinaria();
                }
                if (b.ID.Equals("imgCalculoTransito"))
                {
                    MostarSubMenuTransito();
                }

                if (b.ID.Equals("imgReparacion"))
                {
                    MostarSubMenuReparacion();

                }
                if (b.ID.Equals("imgRepositorio"))
                {

                    MostarSubMenuRepositorio();
                }
                if (b.ID.Equals("imgNegociaciones"))
                {
                    MostrarSubMenuNegociaciones();
                }
            }
        }

        protected void OnClickNavegacion(object sender, EventArgs e)
        {

            try
            {
                if (sender is LinkButton)
                {
                    LinkButton linkButton = (LinkButton)sender;
                    GestionUtil.MenuSeleccionado = linkButton.ID; 

                    Session["TituloMenu"] = linkButton.ToolTip;

                    if (linkButton.ID.Equals("hlinkCalculoEstructura"))
                    {
                        GestionUtil.Redireccionar(ConstantesUtil.URL_ESTIMACION_ESTRUCTURA);
                    }
                    if (linkButton.ID.Equals("hlinkCalculoMaquinaria"))
                    {
                        GestionUtil.Redireccionar(ConstantesUtil.URL_ESTIMACION_MAQUINARIA);
                    }
                    if (linkButton.ID.Equals("hlinkCalculoTransito"))
                    {
                        GestionUtil.Redireccionar(ConstantesUtil.URL_ESTIMACION_TRANSITO);
                    }
                    if (linkButton.ID.Equals("hlinkReparaciones"))
                    {
                        GestionUtil.Redireccionar(ConstantesUtil.URL_GESTION_REPARACIONES);
                    }
                    if (linkButton.ID.Equals("hlinkNegociacionLinea"))
                    {
                        GestionUtil.Redireccionar(ConstantesUtil.URL_GESTION_NEGOCIACIONES_LINEA);
                    }
                    if (linkButton.ID.Equals("hlinkNegociacionProveedor"))
                    {
                        GestionUtil.Redireccionar(ConstantesUtil.URL_GESTION_NEGOCIACIONES_PROVEEDOR);
                    }
                    if (linkButton.ID.Equals("hlinkGestionProveedor"))
                    {
                        GestionUtil.Redireccionar(ConstantesUtil.URL_GESTION_PROVEEDOR);
                    }
                    if (linkButton.ID.Equals("hlinkDocumental"))
                    {
                        GestionUtil.Redireccionar(ConstantesUtil.URL_GESTION_DOCUMENTOS);
                    }
                    if (linkButton.ID.Equals("hlinkDanos"))
                    {
                        GestionUtil.Redireccionar(ConstantesUtil.URL_GESTION_DANIOS);
                    }


                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_NAVEGACION_MENU);
            }
        }
    }
}