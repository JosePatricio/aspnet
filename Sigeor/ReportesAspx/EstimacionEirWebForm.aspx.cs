using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.GestionMglServiceReference;
using Sigeor.Utilidades;
using Sigeor.GestionConfiguracionServiceReference;
using System.Web.UI;
using Sigeor.GestionReportesServiceReference;
using System.Globalization;

namespace Sigeor.ReportesAspx
{
    public partial class EstimacionEirWebForm : System.Web.UI.Page
    {
        private ReportesServiceClient _clienteReportes = new ReportesServiceClient();
        private GestionMglServiceClient _clienteMgl = new GestionMglServiceClient();

        private GestionMglServiceClient _clienteSigeor;

        private int _totalRegistros;
        private List<ClaseBasica> _listaRegistrosVisibles;
        private string fechainicio = String.Empty;
        private string fechafin = String.Empty;
        private string cod_agencia = String.Empty;
        private string cod_deposito = String.Empty;
        private string cod_linea = String.Empty;
        private string estado = String.Empty;
        private string cod_eir = String.Empty;

        public EstimacionEirWebForm()
        {
            try
            {
                _listaRegistrosVisibles = GestionUtil.CargarNumeroRegistrosGridView();

            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_VARIABLES);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.Page.User.Identity.IsAuthenticated)
            {
                GestionUtil.RedireccionarSesionExpirada();
                return;
            }

            if (!IsPostBack)
            {
                GestionUtil.ControlAccesoPerfil(GestionUtil.UsuarioSesion.Cedula, this.Request.Url.LocalPath);
                Inicializar();
            }
        }



        private void Inicializar()
        {
            //estimadoEorDiv.Visible = false;
            Session["TotalEirDepositoReport"] = null;
            Session["EirDepositoReport"] = null;

            lblCabecera.Text = GestionUtil.tituloPagina(this.Request.Url.LocalPath);


            calendarExtenderInicio.EndDate = DateTime.Now;
            calendarExtenderFin.EndDate = DateTime.Now;

            txtfechainicio.Text = DateTime.Now.AddDays(-30).ToShortDateString();
            txtfechafin.Text = DateTime.Now.ToShortDateString();


            _clienteSigeor = new GestionMglServiceClient();

            //String estados = new DatosCreados().CargarEstadosEstimacionEir();
            //var listaEstados = estados != null ? Serializador.DeSerializeEntity<List<ClaseBasica>>(estados) : null;



            String estados = _clienteReportes.ObtenerEstadosEorEstructuraMaquinaria();

            var listaEstados = !string.IsNullOrEmpty(estados)
                ? Serializador.DeSerializeEntity<List<ClaseBasica>>(estados)
                : new List<ClaseBasica>();

            //listaEstados.Add(new ClaseBasica { IdString = "P", Nombre = "PENDIENTES" });

            listaEstados.Insert(0, new ClaseBasica { IdString = string.Empty, Nombre = "TODOS LOS ESTADOS" });


            String depositos = _clienteSigeor.ObtenerDepositosPorEstado("A");
            var listaDepositos = depositos != null ? Serializador.DeSerializeEntity<List<SM_DEPOSITO>>(depositos) : null;

            String linea = _clienteSigeor.ObtenerLineasPorEstado("A");
            var listaLineas = linea != null ? Serializador.DeSerializeEntity<List<SM_LINEA>>(linea) : null;



            ddlEstado.DataSource = listaEstados;
            ddlEstado.DataTextField = "Nombre";
            ddlEstado.DataValueField = "IdString";
            ddlEstado.DataBind();




            ddlDeposito.DataSource = listaDepositos;
            ddlDeposito.DataTextField = "NOMBRE_DEPOSITO";
            ddlDeposito.DataValueField = "COD_DEPOSITO";
            ddlDeposito.DataBind();
            ddlDeposito.Items.Insert(0, new ListItem("Todos", string.Empty));
            ddlDeposito.SelectedIndex = 0;


            var parametro = new ClaseBasica { EstadoString = "A", Descripcion = string.Empty };
            var result = _clienteMgl.ObtenerTipoContenedorPorTipoEstado(Serializador.SerializeEntity(parametro));

            var listaTipoContenedores = !string.IsNullOrEmpty(result)
                 ? Serializador.DeSerializeEntity<List<SM_TIPCONTAINER>>(result)
                 : new List<SM_TIPCONTAINER>();


            TipoContenedorListBox.DataSource = listaTipoContenedores;
            TipoContenedorListBox.DataTextField = "NOM_TIPCONT";
            TipoContenedorListBox.DataValueField = "COD_TIPCONT";
            TipoContenedorListBox.DataBind();


            ddlLinea.DataSource = listaLineas;
            ddlLinea.DataTextField = "NOM_LINEA";
            ddlLinea.DataValueField = "COD_LINEA";
            ddlLinea.DataBind();
            ddlLinea.Items.Insert(0, new ListItem("Todos", string.Empty));
            ddlLinea.SelectedIndex = 0;



            gridEirdeposito.PageSize = _listaRegistrosVisibles.First().IdInt;

            txtfechainicio.Attributes.Add("readonly", "readonly");
            txtfechafin.Attributes.Add("readonly", "readonly");
            RegistrosVisiblesDropDownList.DataSource = _listaRegistrosVisibles;
            RegistrosVisiblesDropDownList.DataValueField = "IdInt";
            RegistrosVisiblesDropDownList.DataTextField = "Descripcion";
            RegistrosVisiblesDropDownList.DataBind();
            RegistrosVisiblesDropDownList.SelectedValue = "20";
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

        protected void VerReporte(object sender, EventArgs e)
        {
            try
            {
                GestionUtil.VerReporte(this, "EstimacionEirReport", RecuperarFiltros());



            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo cargar el reporte: " + ex.Message);
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

        protected void formularioPrincipal_OnLoad(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Inicializar();
                    _clienteSigeor = new GestionMglServiceClient();

                    lblCabecera.Text = GestionUtil.tituloPagina(this.Request.Url.LocalPath);


                }
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ex.Message);
            }
        }

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
        protected void Paginador_OnClick(object sender, EventArgs e)
        {
            CargarDatosPaginadosPorNavegacion(sender);
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

        private void CargarDatosPaginadosPorNavegacion(object sender)
        {
            try
            {
                var control = sender as LinkButton;

                if (control != null)
                {

                    string result = null;
                    List<GET_ESTIMACION_EIR_Result> lista = null;



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

                    result = _clienteReportes.ObtenerDatosEstimacionEirPaginado(out _totalRegistros, RecuperarFiltros(), PageSizeActual, PageIndexActual);
                    lista = result != null ? Serializador.DeSerializeEntity<List<GET_ESTIMACION_EIR_Result>>(result) : new List<GET_ESTIMACION_EIR_Result>();
                    BindingDatosPaginadosPorLista(lista, _totalRegistros);
                }
            }
            catch (Exception)
            {

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_NAVEGAR_PAGINACION);
            }
        }
        protected void PerfilesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
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


        public string f(string fecha)
        {
            return DateTime.Parse(fecha).ToString(CultureInfo.InvariantCulture);
        }

        private void CargarDatosPorEstadoCoincidencia()
        {
            try
            {
                string result = null;
                List<GET_ESTIMACION_EIR_Result> lista = null;
                result = _clienteReportes.ObtenerDatosEstimacionEirPaginado(out _totalRegistros, RecuperarFiltros(), PageSizeActual, PageIndexActual);
                lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<GET_ESTIMACION_EIR_Result>>(result) : new List<GET_ESTIMACION_EIR_Result>();
                BindingDatosPaginadosPorLista(lista, _totalRegistros);


            }
            catch (Exception e)
            {
                Response.Write(e);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }
        }


        private string RecuperarFiltros()
        {
            string result = null;
            try
            {
                fechainicio = txtfechainicio.Text;
                fechafin = txtfechafin.Text;
                var filtros = new ClaseBasica
                {

                    /*  DescripcionUno ="0",
                       DescripcionDos = "9280",
                       DescripcionTres =  "PB",
                       DescripcionCuatro = "04",
                       FechaDateTimeStringUno = "2009-04-04",
                       FechaDateTimeStringDos ="2010-09-18",
                       EstadoString = "F"*/

                    DescripcionUno = BuscarTextBox.Text.Trim().ToUpper(),
                    DescripcionDos = ddlLinea.SelectedValue,
                    DescripcionTres = ddlDeposito.SelectedValue,
                    //DescripcionCuatro = ddlagencia.SelectedValue,
                    FechaDateTimeStringUno = !string.IsNullOrEmpty(fechainicio) ? DateTime.Parse(fechainicio).ToString(CultureInfo.InvariantCulture) : string.Empty,
                    FechaDateTimeStringDos = !string.IsNullOrEmpty(fechafin) ? DateTime.Parse(fechafin).ToString(CultureInfo.InvariantCulture) : string.Empty,
                    EstadoString = ddlEstado.SelectedValue
                };

                var listaContenedores = TipoContenedorListBox.Items.Cast<ListItem>().ToList().Where(ent => ent.Selected);

                if (listaContenedores.Any())
                {
                    foreach (ListItem item in listaContenedores)
                    {
                        filtros.DescripcionCinco += "'" + item.Value + "',";
                    }
                    filtros.DescripcionCinco = filtros.DescripcionCinco.Substring(0, filtros.DescripcionCinco.Length - 1);
                }

                result = Serializador.SerializeEntity(filtros);
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo recuperar los filtros seleccionados");
            }

            return result;
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
        protected void RegistrosVisiblesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                paginaActualTextBox.Text = "1";
                gridEirdeposito.PageSize = PageSizeActual;
                CargarDatosPorEstadoCoincidencia();
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PAGE_SIZE);
            }
        }
        private void BindingDatosPaginadosPorLista(List<GET_ESTIMACION_EIR_Result> lista, int totalRegistros)
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
                gridEirdeposito.DataSource = lista;
                gridEirdeposito.DataBind();
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }

        }




    }
}