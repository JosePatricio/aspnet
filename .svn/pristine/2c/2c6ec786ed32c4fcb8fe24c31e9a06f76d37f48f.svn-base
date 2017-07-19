using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.AretinaServiceReference;
using Sigeor.MglServiceReference;
using Sigeor.Utilidades;
using Sigeor.GestionConfiguracionServiceReference;
using Sigeor.GestionControlServiceReference;
using System.Web.UI;
using Sigeor.ReportesServiceReference;
namespace Sigeor.ReportesAspx
{
    public partial class EirMaquinaria : System.Web.UI.Page
    {
        ReportesServiceClient servicio = new ReportesServiceClient();
        private int _totalRegistros;
        private GestionMglServiceClient _clienteSigeor;
        private GestionConfiguracionServiceClient _clienteConfiguracion;
        private List<ClaseBasica> _listaRegistrosVisibles;
        string fechainicio = String.Empty;
        string fechafin = String.Empty;
        string tipo_contenedor = String.Empty;
        string cod_deposito = String.Empty;
        string cod_linea = String.Empty;
        string estado = String.Empty;
        string cod_eir=String.Empty;

        public EirMaquinaria()
        {
            try
            {
                _clienteConfiguracion = new GestionConfiguracionServiceClient();
                _listaRegistrosVisibles = GestionUtil.CargarNumeroRegistrosGridView();

            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_VARIABLES);
            }
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
         /*  if (!Page.User.Identity.IsAuthenticated)
                {
                    GestionUtil.RedireccionarSesionExpirada();
                    return;
            }*/

                Inicializar();
            }
        }


        





        private void Inicializar()
        {


            calendarExtenderInicio.EndDate = DateTime.Now;
            calendarExtenderFin.EndDate = DateTime.Now;

            txtfechainicio.Text = DateTime.Now.ToShortDateString();
            txtfechafin.Text = DateTime.Now.ToShortDateString();


            List<M_DEPOSITO> lista_depositos = null;
            List<ClaseBasica> lista_estados = null;
            List<M_AGENCIA> lista_agencia = null;
            List<M_LINEA> lista_linea = null;

            _clienteSigeor = new GestionMglServiceClient();

            String estados = new DatosCreados().CargarEstadosEstimacionEir();
            lista_estados = estados != null ? Serializador.DeSerializeEntity<List<ClaseBasica>>(estados) : null;
            String depositos = _clienteSigeor.ObtenerDepositosPorEstado("A");
            lista_depositos = depositos != null ? Serializador.DeSerializeEntity<List<M_DEPOSITO>>(depositos) : null;
            String agencia = _clienteSigeor.ObtenerAgenciasPorEstado("A");
            lista_agencia = agencia != null ? Serializador.DeSerializeEntity<List<M_AGENCIA>>(agencia) : null;
            String linea = _clienteSigeor.ObtenerLineasPorEstado("A");
            lista_linea = linea != null ? Serializador.DeSerializeEntity<List<M_LINEA>>(linea) : null;



            ddlestado.DataSource = lista_estados.ToList();
            ddlestado.DataTextField = "Nombre";
            ddlestado.DataValueField = "IdString";
            ddlestado.DataBind();




            ddltipodeposito.DataSource = lista_depositos.ToList();
            ddltipodeposito.DataTextField = "NOMBRE_DEPOSITO";
            ddltipodeposito.DataValueField = "COD_DEPOSITO";
            ddltipodeposito.DataBind();
            ddltipodeposito.Items.Insert(0, new ListItem("Todos", "todos"));
            ddltipodeposito.SelectedIndex = 0;


            ddlagencia.DataSource = lista_agencia.ToList();
            ddlagencia.DataTextField = "NOMBRE_AGENCIA";
            ddlagencia.DataValueField = "COD_AGENCIA";
            ddlagencia.DataBind();
            ddlagencia.Items.Insert(0, new ListItem("Todos", "todos"));
            ddlagencia.SelectedIndex = 0;


            ddllinea.Items.Add(new ListItem("Todos", "todos"));
            ddllinea.DataSource = lista_linea.ToList();
            ddllinea.DataTextField = "NOM_LINEA";
            ddllinea.DataValueField = "COD_LINEA";
            ddllinea.DataBind();
            ddllinea.Items.Insert(0, new ListItem("Todos", "todos"));
            ddllinea.SelectedIndex = 0;

            lblCabecera.Text = Session["TituloMenu"] != null ? Session["TituloMenu"].ToString() : string.Empty;
            gridEirdeposito.PageSize = _listaRegistrosVisibles.First().IdInt;

            txtfechainicio.Attributes.Add("readonly", "readonly");
            txtfechafin.Attributes.Add("readonly", "readonly");
            RegistrosVisiblesDropDownList.DataSource = _listaRegistrosVisibles;
            RegistrosVisiblesDropDownList.DataValueField = "IdInt";
            RegistrosVisiblesDropDownList.DataTextField = "Descripcion";
            RegistrosVisiblesDropDownList.DataBind();
            RegistrosVisiblesDropDownList.SelectedValue = "10";


            Session["TotalEirDepositoReport"] = null;
            Session["EirDepositoReport"] = null;


        }

        protected void formularioPrincipal_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                //    GestionUtil.AplicarFocoBusqueda(this, BuscarTextBox);
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty,
                    ConstantesUtil.MENSAJE_ERROR_PRERENDER);

            }
        }

        protected void VerReporte(object sender, EventArgs e)
        {
            try
            {
                GestionUtil.VerReporte(this, "EirMaquinariaReport", RecuperarFiltros());

            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty, "No se pudo cargar los reportes: " + ex.Message);
            }
        }
        protected void OnClickNavegacion(object sender, EventArgs e)
        {
            try
            {
                if (Session["MenuSeleccionado"] != null)
                    Response.Redirect(ConstantesUtil.URL_MENU_CONTROL);

            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty, ConstantesUtil.MENSAJE_ERROR_NAVEGACION_MENU + " " + ex.Message);
            }
        }

        public string f(string fecha)
        {   
            return DateTime.Parse(fecha).ToString("yyyy-MM-dd HH:mm:ss");
        }


        protected void BuscarButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                    CargarDatosPorEstadoCoincidencia();
       }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty,
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


                    lblCabecera.Text = Session["TituloMenu"] != null
                        ? Session["TituloMenu"].ToString()
                        : string.Empty;
              
                }
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty, ex.Message);
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
                var pagina = int.Parse(paginaActualTextBox.Text);
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
                    List<GET_EIR_MAQUINARIA_Result> lista = null;

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


                    obtenerValoresCampos();

                    result = servicio.ObtenerDatosEirMaquinariaPaginado(out _totalRegistros, RecuperarFiltros(), PageSizeActual, PageIndexActual - 1);

                    lista = result != null ? Serializador.DeSerializeEntity<List<GET_EIR_MAQUINARIA_Result>>(result) : null;
                    BindingDatosPaginadosPorLista(lista, _totalRegistros);
                }
            }
            catch (Exception)
            {

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty, ConstantesUtil.MENSAJE_ERROR_NAVEGAR_PAGINACION);
            }
        }
        protected void PerfilesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onMouseOver", "originalstyle=style.backgroundColor;style.backgroundColor='darkgray';style.cursor='pointer';");
                    e.Row.Attributes.Add("OnMouseOut", "style.backgroundColor=originalstyle;");
                }
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty, ConstantesUtil.MENSAJE_ERROR_ROWDATA_BOUND);
            }
        }




        public void obtenerValoresCampos() {
            fechainicio = f(txtfechainicio.Text);
            fechafin = f(txtfechafin.Text);
            tipo_contenedor = ddlagencia.SelectedValue.Trim();
            cod_deposito = ddltipodeposito.SelectedValue.Trim();
            cod_linea = ddllinea.SelectedValue.Trim();
            estado = ddlestado.SelectedValue.Trim();
            cod_eir = BuscarTextBox.Text;
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
                   
                     DescripcionUno = BuscarTextBox.Text.Trim().ToUpper(),
                     DescripcionDos = ddllinea.SelectedValue,
                     DescripcionTres = ddltipodeposito.SelectedValue,
                     DescripcionCuatro = ddlagencia.SelectedValue,
                     FechaDateTimeStringUno = !string.IsNullOrEmpty(fechainicio) ? DateTime.Parse(fechainicio).ToString("yyyy-MM-dd HH:mm:ss") : string.Empty,
                     FechaDateTimeStringDos = !string.IsNullOrEmpty(fechafin) ? DateTime.Parse(fechafin).ToString("yyyy-MM-dd HH:mm:ss") : string.Empty,
                     EstadoString ="E"

                };

                result = Serializador.SerializeEntity(filtros);
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty, "No se pudo recuperar los filtros seleccionados");
            }

            return result;
        }


        private void CargarDatosPorEstadoCoincidencia()
        {
            try
            {
                string result = null;
                List<GET_EIR_MAQUINARIA_Result> lista = null;
               obtenerValoresCampos();

               result = servicio.ObtenerDatosEirMaquinariaPaginado(out _totalRegistros, RecuperarFiltros(), PageSizeActual, PageIndexActual - 1);
                lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<GET_EIR_MAQUINARIA_Result>>(result) : null;
                BindingDatosPaginadosPorLista(lista, _totalRegistros);
            
            }
            catch (Exception)
            {

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }
        }

        protected void paginaActualTextBox_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(paginaActualTextBox.Text))
                {
                    var index = int.Parse(paginaActualTextBox.Text);

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

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty, ConstantesUtil.MENSAJE_ERROR_BUSQUEDA_POR_COINCIDENCIAS);
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
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty, ConstantesUtil.MENSAJE_ERROR_PAGE_SIZE);
            }
        }
        private void BindingDatosPaginadosPorLista(List<GET_EIR_MAQUINARIA_Result> lista, int totalRegistros)
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
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }

        }

      


    }
        }

