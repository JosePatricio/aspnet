using System;
using System.Web.UI;
using Sigeor.Utilidades;
using Sigeor.GestionMglServiceReference;
using Sigeor.GestionReportesServiceReference;
using System.Collections.Generic;
using PersistenciaSigeor;
using Negocio.Utilidades;
using System.Web.UI.WebControls;
using System.Linq;
using System.Diagnostics;
using System.Globalization;
using System.Drawing;
using System.Data;
using Negocio.Reportes;
using Sigeor.GestionConfiguracionServiceReference;
using Negocio.Configuracion;

namespace Sigeor.Menu
{
    public partial class MenuAlertas : System.Web.UI.Page
    {
        private GestionMglServiceClient _clienteSigeor;
        private ReportesServiceClient _clienteReportes;
        private GestionMglServiceClient _clienteMgl;
        private ConfiguracionServiceClient _clienteConfiguracion;
        private List<ClaseBasica> _listaRegistrosVisibles;
        private int _totalRegistros;

        private int PageSizeActual
        {
            get
            {
                var result = RegistrosVisiblesDropDownList.SelectedValue;
                if (!string.IsNullOrEmpty(result))
                    return int.Parse(result);
                return 0;
            }
        }

        private int PageIndexActual
        {
            set
            {
                if (value > 0 && value <= int.Parse(totalPaginasLbl.Text))
                    paginaActualTextBox.Text = value.ToString();
            }
            get
            {
                if (string.IsNullOrEmpty(paginaActualTextBox.Text))
                    paginaActualTextBox.Text = "1";
                var pagina = int.Parse(GestionUtil.VerificarPaginaActual(paginaActualTextBox.Text));
                if (pagina > 0 && pagina <= int.Parse(totalPaginasLbl.Text))
                    return pagina;
                return 1;
            }
        }

        public MenuAlertas()
        {
            try
            {
                _clienteSigeor = new GestionMglServiceClient();
                _clienteReportes = new ReportesServiceClient();
                _clienteMgl = new GestionMglServiceClient();
                _clienteConfiguracion = new ConfiguracionServiceClient();

            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty,
                    ConstantesUtil.MENSAJE_ERROR_CARGA_VARIABLES + " " + ex.Message);
            }
        }

        protected void formularioPrincipal_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                GestionUtil.AplicarFocoBusqueda(this, BuscarTextBox);
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty,
                    ConstantesUtil.MENSAJE_ERROR_PRERENDER);

            }
        }

        private void Inicializar()
        {
            try
            {
                paginaActualTextBox.Text = "1";
                totalPaginasLbl.Text = "1";

                _listaRegistrosVisibles = GestionUtil.CargarNumeroRegistrosGridView();
                RegistrosVisiblesDropDownList.DataSource = _listaRegistrosVisibles;
                RegistrosVisiblesDropDownList.DataValueField = "IdInt";
                RegistrosVisiblesDropDownList.DataTextField = "Descripcion";
                RegistrosVisiblesDropDownList.DataBind();
                RegistrosVisiblesDropDownList.SelectedValue = "20";

                CargarDatosPorEstadoCoincidencia();

            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo cargar los filtros del reporte EOR por estructura: " + ex, EventLogEntryType.Error);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo cargar los filtros del reporte EOR por estructura");
            }
        }

        protected void formularioPrincipal_OnLoad(object sender, EventArgs e)
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
                    GestionUtil.ControlAccesoPerfil(GestionUtil.UsuarioSesion.Cedula, this.Request.Url.LocalPath);
                    lblCabecera.Text = GestionUtil.tituloPagina(this.Request.Url.LocalPath); ;
                    Inicializar();
                }
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "Eor's por Maquinaria", ConstantesUtil.MENSAJE_ERROR_LOAD);
            }
        }

        protected void VerReporte(object sender, EventArgs e)
        {
            try
            {
                GestionUtil.VerReporte(this, "AlertasReport", BuscarTextBox.Text.Trim());
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo cargar los reportes: " + ex.Message);
            }
        }

        protected void OnClickNavegacion(object sender, EventArgs e)
        {
            try
            {
                GestionUtil.Redireccionar(ConstantesUtil.URL_MENU_REPORTES);
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_NAVEGACION_MENU + " " + ex.Message);
            }
        }

        protected void BuscarButton_OnClick(object sender, EventArgs e)
        {
            try
            {

                CargarDatosPorEstadoCoincidencia();

            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty,
                    ConstantesUtil.MENSAJE_ERROR_BUSQUEDA_POR_COINCIDENCIAS);
            }
        }

        protected void RegistrosVisiblesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                paginaActualTextBox.Text = "1";
                AlertasGridView.PageSize = PageSizeActual;
                CargarDatosPorEstadoCoincidencia();
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PAGE_SIZE);
            }
        }

        protected void AlertasGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onMouseOver", "originalstyle=style.backgroundColor;style.backgroundColor='#d0dfea';style.cursor='pointer';");
                    e.Row.Attributes.Add("OnMouseOut", "style.backgroundColor=originalstyle;");
                }
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_ROWDATA_BOUND);
            }
        }

        private void BindingDatosPaginadosPorLista(List<GET_ALERTAS_GENERADAS_Result> lista, int totalRegistros)
        {
            try
            {
                var totalPaginas =
               (Math.Round(new decimal(totalRegistros / PageSizeActual), 0, MidpointRounding.AwayFromZero));

                if ((totalRegistros > 0 && totalPaginas == 0) || (totalPaginas == 0 && _totalRegistros > 0))
                    totalPaginas = 1;

                if ((totalRegistros % PageSizeActual > 0) && (totalRegistros > PageSizeActual))
                    totalPaginas++;

                totalPaginasLbl.Text = totalPaginas.ToString();

                AlertasGridView.DataSource = lista;
                AlertasGridView.DataBind();
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }

        }



        private void CargarDatosPaginadosPorNavegacion(object sender)
        {
            try
            {
                var control = sender as LinkButton;

                if (control != null)
                {


                    var totalPaginas = int.Parse(totalPaginasLbl.Text);


                    if (control.ID.Equals("Inicio"))
                        PageIndexActual = 1;

                    if (control.ID.Equals("Siguiente") && PageIndexActual < totalPaginas)
                        if (PageIndexActual < totalPaginas)
                            PageIndexActual++;
                        else
                            return;
                    if (control.ID.Equals("Anterior") && PageIndexActual > 0)
                        if (PageIndexActual > 0)
                            PageIndexActual--;
                        else
                            return;

                    if (control.ID.Equals("Final"))
                        PageIndexActual = totalPaginas;

                    var result = string.Empty;

                    var busqueda = BuscarTextBox.Text.Trim();

                    if (string.IsNullOrEmpty(BuscarTextBox.Text.Trim()))
                        result = _clienteConfiguracion.ObtenerAlertasReparacionPorEstadoPaginado(out _totalRegistros, true, PageSizeActual, PageIndexActual);
                    else
                        result = _clienteConfiguracion.ObtenerAlertasReparacionPorCoincidenciaPaginado(out _totalRegistros, busqueda, true, PageSizeActual, PageIndexActual);

                    var lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<GET_ALERTAS_GENERADAS_Result>>(result) : new List<GET_ALERTAS_GENERADAS_Result>();
                    BindingDatosPaginadosPorLista(lista, _totalRegistros);
                }
            }
            catch (Exception)
            {

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_NAVEGAR_PAGINACION);
            }
        }

        protected void Paginador_OnClick(object sender, EventArgs e)
        {
            CargarDatosPaginadosPorNavegacion(sender);
        }

        private void CargarDatosPorEstadoCoincidencia()
        {
            try
            {
                var result = string.Empty;
                var busqueda = BuscarTextBox.Text.Trim();
                paginaActualTextBox.Text = "1";



                if (string.IsNullOrEmpty(BuscarTextBox.Text.Trim()))
                    // result = AlertaReparacionNegocio.ObtenerAlertasPorEstadoPaginado(true, PageSizeActual, PageIndexActual, out _totalRegistros);
                    result = _clienteConfiguracion.ObtenerAlertasReparacionPorEstadoPaginado(out _totalRegistros, true, PageSizeActual, PageIndexActual);
                else
                    //result = AlertaReparacionNegocio.ObtenerAlertaReparacionPorCoincidenciaPaginado(busqueda, true, PageSizeActual, PageIndexActual, out _totalRegistros);
                    result = _clienteConfiguracion.ObtenerAlertasReparacionPorCoincidenciaPaginado(out _totalRegistros, busqueda, true, PageSizeActual, PageIndexActual);



                var lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<GET_ALERTAS_GENERADAS_Result>>(result) : new List<GET_ALERTAS_GENERADAS_Result>();

                BindingDatosPaginadosPorLista(lista, _totalRegistros);
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }
        }

        protected void paginaActualDdl_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosPorEstadoCoincidencia();
        }

        protected void RegistrosVisiblesDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosPorEstadoCoincidencia();
        }

        protected void paginaActualTextBox_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(paginaActualTextBox.Text))
                {
                    
                        

                    var index = int.Parse(GestionUtil.VerificarPaginaActual(paginaActualTextBox.Text));

                    if (index.Equals(0))
                        PageIndexActual = 1;
                    else
                    {
                        var total = int.Parse(totalPaginasLbl.Text);
                        if (index > total)
                            PageIndexActual = total;
                    }
                    CargarDatosPorEstadoCoincidencia();
                }
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_BUSQUEDA_POR_COINCIDENCIAS);
            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = sender as LinkButton;
                GridViewRow gr = (GridViewRow)linkButton.NamingContainer;
                var id = Guid.Parse(AlertasGridView.DataKeys[gr.RowIndex].Value.ToString());
                var result = _clienteConfiguracion.ObtenerAlertaReparacion(id.ToString());

                AlertaReparacion alertaReparacion = new AlertaReparacion();

                if (!string.IsNullOrEmpty(result))
                {

                    alertaReparacion = Serializador.DeSerializeEntity<AlertaReparacion>(result);
                    alertaReparacion.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                    alertaReparacion.CampoIpUsuario = GestionUtil.IpCliente;
                    _clienteConfiguracion.ModificarAlertaReparacion(Serializador.SerializeEntity(alertaReparacion));
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "La alerta para el Eor " + alertaReparacion.NumEor + " fué revisada");
                    CargarDatosPorEstadoCoincidencia();
                }
                else {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "La alerta no fué encontrada");
                }

            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_ABRIR_DIALOGO_EDICION + ": " + ex);
            }
        }

    }
}

