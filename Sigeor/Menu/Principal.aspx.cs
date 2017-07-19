using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Utilidades;
using Sigeor.Utilidades;
using PersistenciaSigeor;
using Sigeor.GestionConfiguracionServiceReference;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sigeor
{
    public partial class Principal : System.Web.UI.Page
    {
        private string _pagina;

        private ConfiguracionServiceClient _clienteConfiguracion;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    GestionUtil.RedireccionarSesionExpirada();
                    return;
                }

                if (!Page.IsPostBack)
                {

                    if (GestionUtil.UsuarioSesion != null)
                    {
                        lblUsuario.Text = "Bienvenido: " + GestionUtil.UsuarioSesion.Nombre;
                        lblUsuario.Text += "<br/>" + "Copyright © 2015 - Innovaciones ™";

                        iframeContenido.Attributes["src"] = ".." + new ConfiguracionServiceClient().ObtenerPaginadeInicioPorCedula(GestionUtil.UsuarioSesion.Cedula);
                        GestionUtil.MenuSeleccionado = string.Empty;
                        Session["TituloMenu"] = string.Empty;
                        CargarNumeroNotificaciones();

                    }
                    else
                    {
                        GestionUtil.RedireccionarLogin();
                    }

                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("Ocurrió un error al iniciar la pagina " + this.NamingContainer + " " + ex, EventLogEntryType.Error);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "Ocurrió un error al recuprar la sesión en el Menu Reportes");
            }
        }

        private void CargarNumeroNotificaciones()
        {
            try
            {
                _clienteConfiguracion = new ConfiguracionServiceClient();

                var result = _clienteConfiguracion.ObtenerResumenAlertasReparacion();

                var listaResumenAlertas = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<GET_RESUMEN_ALERTAS_Result>>(result) : new List<GET_RESUMEN_ALERTAS_Result>();

                int totalNotificaciones = 0;

                listaResumenAlertas.ForEach(ent =>
                {
                    totalNotificaciones += ent.TOTAL.Value;
                });
                lblNotificaciones.Text = totalNotificaciones.ToString();
            }
            catch (Exception ex)
            {
                Log.WriteEntry("Ocurrió un error al cargar las noticaciones pagina " + this.NamingContainer + " " + ex, EventLogEntryType.Error);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "No se pudo cargar el numero de notificaciones generadas", ConstantesUtil.MENSAJE_ERROR_LOAD + " " + ex.Message);
            }
        }


        protected void OnClickEvent(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    GestionUtil.RedireccionarSesionExpirada();
                    return;
                }
                if (sender is LinkButton)
                {
                    CargarNumeroNotificaciones();
                    _pagina = ((LinkButton)sender).ToolTip;
                    _pagina = _pagina.Replace("Ir a Menú", "").Replace('á', 'a').Replace('é', 'e').Replace('í', 'i').Replace('ó', 'o').Replace('ú', 'u').Replace(" ", string.Empty);

                    if (!_pagina.Equals("Dashboard"))
                        _pagina = string.Concat("Menu", _pagina);

                    _pagina = string.Concat(_pagina, ".aspx");

                    iframeContenido.Attributes["src"] = _pagina;

                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry("Ocurrió un error al navegar en la pagina " + this.NamingContainer + " " + ex, EventLogEntryType.Error);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "Menú del Sistema", ConstantesUtil.MENSAJE_ERROR_NAVEGACION_MENU + " " + ex.Message);
            }
        }

        protected void LoginStatus1_OnLoggingOut(object sender, LoginCancelEventArgs e)
        {
            try
            {
                _clienteConfiguracion = new ConfiguracionServiceClient();

                var auditoria = new Auditoria
                {
                    Id = Guid.NewGuid(),
                    Cedula = GestionUtil.UsuarioSesion.Cedula,
                    IdObjeto = GestionUtil.UsuarioSesion.Cedula,
                    CodigoTipo = "LOGOUT",
                    NombreTabla = string.Empty,
                    NombreCampo = string.Empty,
                    Ip = GestionUtil.IpCliente,
                    Descripcion = "LOGOUT DEL SISTEMA"
                };
                _clienteConfiguracion.InsertarAuditoria(Serializador.SerializeEntity(auditoria));
                GestionUtil.RedireccionarSesionExpirada();
            }
            catch (Exception ex)
            {
                Log.WriteEntry("Ocurrió un error al realizar el Logout " + ex, EventLogEntryType.Error);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_LOGOUT);
            }
        }
    }
}

