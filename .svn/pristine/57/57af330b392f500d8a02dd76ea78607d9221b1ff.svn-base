using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Utilidades;

using PersistenciaSigeor;
using Sigeor.Utilidades;
using Sigeor.GestionConfiguracionServiceReference;
using System.Diagnostics;
using System.Globalization;

namespace Sigeor.Configuracion
{
    public partial class GestionAuditoriasWebForm : System.Web.UI.Page
    {
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





        public GestionAuditoriasWebForm()
        {
            try
            {
                _clienteConfiguracion = new ConfiguracionServiceClient();
                _listaRegistrosVisibles = GestionUtil.CargarNumeroRegistrosGridView();

            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "Auditorías", ConstantesUtil.MENSAJE_ERROR_LOAD);
            }
        }


        private string RecuperarFiltros()
        {
            string result = null;
            try
            {
                string fechaInicio = txtFechaInicio.Text = Request.Form[txtFechaInicio.UniqueID] != null ? Request.Form[txtFechaInicio.UniqueID] : txtFechaInicio.Text;
                string fechaFin = txtFechaFin.Text = Request.Form[txtFechaFin.UniqueID] != null ? Request.Form[txtFechaFin.UniqueID] : txtFechaFin.Text;
                ClaseBasica filtros;
                filtros = new ClaseBasica
                {
                    FechaDateTimeStringUno = !string.IsNullOrEmpty(fechaInicio) ? DateTime.Parse(fechaInicio).ToString(CultureInfo.InvariantCulture) : string.Empty,
                    FechaDateTimeStringDos = !string.IsNullOrEmpty(fechaFin) ? DateTime.Parse(fechaFin).ToString(CultureInfo.InvariantCulture) : string.Empty,
                };


                if (!string.IsNullOrEmpty(BuscarTextBox.Text.Trim().ToUpper()))
                    filtros.Descripcion = BuscarTextBox.Text.Trim().ToUpper();

                if (!string.IsNullOrEmpty(AccionTextBox.Text.Trim().ToUpper()))
                    filtros.DescripcionUno = AccionTextBox.Text;



                result = Serializador.SerializeEntity(filtros);
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo recuperar los filtros seleccionados" + ex, EventLogEntryType.Error);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo recuperar los filtros seleccionados");
            }

            return result;
        }



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
                    GestionUtil.ControlAccesoPerfil(GestionUtil.UsuarioSesion.Cedula, this.Request.Url.LocalPath);

                    lblCabecera.Text = GestionUtil.tituloPagina(this.Request.Url.LocalPath);
                    AuditoriaGridView.PageSize = _listaRegistrosVisibles.First().IdInt;
                    RegistrosVisiblesDropDownList.DataSource = _listaRegistrosVisibles;
                    RegistrosVisiblesDropDownList.DataValueField = "IdInt";
                    RegistrosVisiblesDropDownList.DataTextField = "Descripcion";
                    RegistrosVisiblesDropDownList.DataBind();
                    RegistrosVisiblesDropDownList.SelectedValue = "20";

                    calendarExtenderInicio.EndDate = DateTime.Now;
                    calendarExtenderFin.EndDate = DateTime.Now;

                    txtFechaInicio.Text = DateTime.Now.AddDays(-1).ToShortDateString();
                    txtFechaFin.Text = DateTime.Now.ToShortDateString();

                    CargarDatosPorCoincidencia();
                }
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "Auditoria", ConstantesUtil.MENSAJE_ERROR_LOAD);
            }
        }


        protected void AuditoriaGridView_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void RegistrosVisiblesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                paginaActualTextBox.Text = "1";
                CargarDatosPorCoincidencia();
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PAGE_SIZE);
            }
        }

        protected void OnClickNavegacion(object sender, EventArgs e)
        {
            try
            {

                GestionUtil.Redireccionar(ConstantesUtil.URL_MENU_CONFIGURACION);
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_NAVEGACION_MENU);
            }
        }

        protected void VerReporte(object sender, EventArgs e)
        {
            //Session["AuditoriaReportValue"] = ;            
            GestionUtil.VerReporte(this, "AuditoriaReport", RecuperarFiltros());

        }

        ////////////////////////////////////////////////
        /// TODO: PRUEBA DEL NUEVO PAGINADOR
        /// ///////////////////////////////////////////


        private void BindingDatosPaginadosPorLista(List<GET_AUDITORIA_Result> lista, int totalRegistros)
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

                AuditoriaGridView.DataSource = lista;
                AuditoriaGridView.DataBind();
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

                    string result = null;
                    List<GET_AUDITORIA_Result> lista = null;

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

                    result = _clienteConfiguracion.ObtenerAuditoriaPorCoincidenciaPaginado(out _totalRegistros, RecuperarFiltros(),
                        PageSizeActual,
                        PageIndexActual);

                    lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<GET_AUDITORIA_Result>>(result) : new List<GET_AUDITORIA_Result>();
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

        private void CargarDatosPorCoincidencia()
        {
            try
            {
                string result = null;
                List<GET_AUDITORIA_Result> lista = null;

                result = _clienteConfiguracion.ObtenerAuditoriaPorCoincidenciaPaginado(out _totalRegistros, RecuperarFiltros(),
                   PageSizeActual,
                   PageIndexActual);
                lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<GET_AUDITORIA_Result>>(result) : new List<GET_AUDITORIA_Result>();

                BindingDatosPaginadosPorLista(lista, _totalRegistros);
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }
        }

        protected void paginaActualDdl_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosPorCoincidencia();
        }

        protected void RegistrosVisiblesDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosPorCoincidencia();
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
                    CargarDatosPorCoincidencia();
                }
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "MostrarModal", "Ocultar();", true);


            }
            catch (Exception)
            {

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_BUSQUEDA_POR_COINCIDENCIAS);
            }
        }


        protected void BuscarButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                totalPaginasLbl.Text = "1";
                CargarDatosPorCoincidencia();
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_BUSQUEDA_POR_COINCIDENCIAS);
            }
        }

        protected void principalform_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                GestionUtil.AplicarFocoBusqueda(this, BuscarTextBox);
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PRERENDER);

            }
        }
    }
}
