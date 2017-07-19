using System;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Utilidades;
using Sigeor.Utilidades;

namespace Sigeor.Menu
{
    public partial class MenuConfiguracion : System.Web.UI.Page
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


                subUser.Visible = false;
                subPerfil.Visible = false;
                subDocumental.Visible = false;
                subAuditoria.Visible = false;
                subConfEmail.Visible = false;

                if (!Page.IsPostBack)
                {
                    GestionUtil.ControlAccesoPerfil(GestionUtil.UsuarioSesion.Cedula, this.Request.Url.LocalPath);
                    
                    var menuSeleccionado = GestionUtil.MenuSeleccionado;

                    if (menuSeleccionado.ToString().Equals("User"))
                    {
                        MostrarSubMenuUsuario();
                    }
                    if (menuSeleccionado.ToString().Equals("hlinkPerfil") || menuSeleccionado.ToString().Equals("hlinkModulos"))
                    {
                        MostrarSubMenuPerfiles();
                    }
                    if (menuSeleccionado.ToString().Equals("hlinkAlertas"))
                    {
                        MostrarSubMenuAlertas();
                    }
                    if (menuSeleccionado.ToString().Equals("hlinkAuditoria"))
                    {
                        MostrarSubMenuAuditoria();
                    }
                    if (menuSeleccionado.ToString().Equals("hlynkAlmacenamiento"))
                    {
                        MostrarSubMenuDocumental();
                    }
                    if (menuSeleccionado.ToString().Equals("hlynkConfiguracionEmail"))
                    {
                        MostrarSubMenuConfiguracionEmail();
                    }

                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("Ocurrió un error al iniciar la pagina " + this.NamingContainer + " " + ex, EventLogEntryType.Error);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "Ocurrió un error al recuprar la sesión en el Menu Reportes");
            }

        }

        #region INICIO MOSTRAR Y OCULTAR MENUS DE ACUERDO A OPCION

        private void MostrarSubMenuUsuario()
        {
            divUser.Visible = false;
            subUser.Visible = true;
            perfil.Visible = true;
            alertas.Visible = true;
            documental.Visible = true;
            auditoria.Visible = true;
            confEmail.Visible = true;

            subPerfil.Visible = false;
            subDocumental.Visible = false;
            subAuditoria.Visible = false;
            subConfEmail.Visible = false;
        }
        private void MostrarSubMenuPerfiles()
        {
            divUser.Visible = true;
            subUser.Visible = false;
            perfil.Visible = false;
            alertas.Visible = true;
            documental.Visible = true;
            auditoria.Visible = true;
            confEmail.Visible = true;

            subPerfil.Visible = true;
            subDocumental.Visible = false;
            subAuditoria.Visible = false;
            subConfEmail.Visible = false;
        }
        private void MostrarSubMenuAlertas()
        {
            divUser.Visible = true;
            subUser.Visible = false;
            perfil.Visible = true;
            alertas.Visible = false;
            documental.Visible = true;
            auditoria.Visible = true;
            confEmail.Visible = true;

            subPerfil.Visible = false;
            subDocumental.Visible = false;
            subAuditoria.Visible = false;
            subConfEmail.Visible = false;
        }
        private void MostrarSubMenuAuditoria()
        {
            divUser.Visible = true;
            subUser.Visible = false;
            perfil.Visible = true;
            alertas.Visible = true;
            documental.Visible = true;
            auditoria.Visible = false;
            confEmail.Visible = true;

            subPerfil.Visible = false;
            subDocumental.Visible = false;
            subAuditoria.Visible = true;
            subConfEmail.Visible = false;
        }
        private void MostrarSubMenuDocumental()
        {
            divUser.Visible = true;
            subUser.Visible = false;
            perfil.Visible = true;
            alertas.Visible = true;
            documental.Visible = false;
            auditoria.Visible = true;
            confEmail.Visible = true;

            subPerfil.Visible = false;
            subDocumental.Visible = true;
            subAuditoria.Visible = false;
            subConfEmail.Visible = false;
        }

        private void MostrarSubMenuConfiguracionEmail()
        {
            divUser.Visible = true;
            subUser.Visible = false;
            perfil.Visible = true;
            alertas.Visible = true;
            documental.Visible = true;
            auditoria.Visible = true;
            confEmail.Visible = false;

            subPerfil.Visible = false;
            subDocumental.Visible = false;
            subAuditoria.Visible = false;
            subConfEmail.Visible = true;
        }

        #endregion FIN MOSTRAR Y OCULTAR MENUS DE ACUERDO A OPCION

        protected void OnClickNavegacion(object sender, EventArgs e)
        {
            var button = sender as LinkButton;
            if (button != null)
            {
                LinkButton linkButton = button;


                if (linkButton.ID.Equals("User"))
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_GESTION_Usuario);
                }

                if (linkButton.ID.Equals("hlinkPerfil"))
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_GESTION_PERFILES);

                }

                if (linkButton.ID.Equals("hlinkModulos"))
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_GESTION_MODULOS);

                }

                if (linkButton.ID.Equals("hlinkAuditoria"))
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_GESTION_AUDITORIA);
                }

                if (linkButton.ID.Equals("hlynkAlmacenamiento"))
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_GESTION_DOCUMENTOS);
                }

                if (linkButton.ID.Equals("hlynkConfiguracionEmail"))
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_GESTION_EMAIL);
                }

                if (linkButton.ID.Equals("hlynkEliminacionRep"))
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_ELIMINACION_REPARACIONES);
                }

                if (linkButton.ID.Equals("hlynkDifValoresRep"))
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_DIFERENCIA_VALORES_REPARACIONES);
                }
            }
        }

        protected void OnClickEventConfiguracion(object sender, ImageClickEventArgs e)
        {
            var imageButton = (ImageButton)sender;

            if (imageButton.ID.Equals("imgUser"))
                MostrarSubMenuUsuario();
            else
                if (imageButton.ID.Equals("imgPerfil"))
                MostrarSubMenuPerfiles();
            else
                    if (imageButton.ID.Equals("imgAuditoria"))
                MostrarSubMenuAuditoria();
            else
                        if (imageButton.ID.Equals("imgAlertas"))
                MostrarSubMenuAlertas();
            else
                            if (imageButton.ID.Equals("imgDocumental"))
                MostrarSubMenuDocumental();
            else
                                if (imageButton.ID.Equals("imgEmail"))
                MostrarSubMenuConfiguracionEmail();
        }
    }
}