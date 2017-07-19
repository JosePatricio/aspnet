using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.Utilidades;
using Sigeor.GestionConfiguracionServiceReference;
using System.Web.UI;
using Sigeor.GestionReportesServiceReference;
using Sigeor.GestionMglServiceReference;
using System.Globalization;

namespace Sigeor.ReportesAspx
{
    public partial class EstimacionPtiWebForm : System.Web.UI.Page
    {
        private readonly ReportesServiceClient _clienteReportes;
        private GestionMglServiceClient _clienteSigeor;
        private int _totalRegistros;
        private List<ClaseBasica> _listaRegistrosVisibles;
        string fechainicio = String.Empty;
        string fechafin = String.Empty;


        public EstimacionPtiWebForm()
        {
            try
            {
                _clienteReportes = new ReportesServiceClient();

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

            if (!Page.IsPostBack)
            {
                GestionUtil.ControlAccesoPerfil(GestionUtil.UsuarioSesion.Cedula, this.Request.Url.LocalPath);
                Inicializar();

            }
        }



        private void Inicializar()
        {
            lblCabecera.Text = GestionUtil.tituloPagina(this.Request.Url.LocalPath);
            calendarExtenderInicio.EndDate = DateTime.Now;
            calendarExtenderFin.EndDate = DateTime.Now;

            txtfechainicio.Text = DateTime.Now.AddDays(-30).ToShortDateString();
            txtfechafin.Text = DateTime.Now.ToShortDateString();

            List<SM_DEPOSITO> lista_depositos = null;
            List<SM_LINEA> lista_linea = null;

            _clienteSigeor = new GestionMglServiceClient();


            String depositos = _clienteSigeor.ObtenerDepositosPorEstado("A");
            lista_depositos = depositos != null ? Serializador.DeSerializeEntity<List<SM_DEPOSITO>>(depositos) : null;
            String linea = _clienteSigeor.ObtenerLineasPorEstado("A");
            lista_linea = linea != null ? Serializador.DeSerializeEntity<List<SM_LINEA>>(linea) : null;


            if (lista_depositos != null)
            {
                lista_depositos.Insert(0, new SM_DEPOSITO { COD_DEPOSITO = string.Empty, NOMBRE_DEPOSITO = "TODOS LOS DEPÓSITOS" });
                ddlDeposito.DataSource = lista_depositos;
            }
            ddlDeposito.DataTextField = "NOMBRE_DEPOSITO";
            ddlDeposito.DataValueField = "COD_DEPOSITO";
            ddlDeposito.DataBind();

            if (lista_linea != null)
            {
                lista_linea.Insert(0, new SM_LINEA { COD_LINEA = string.Empty, NOM_LINEA = "TODAS LAS LÍNEAS" });
                ddlLinea.DataSource = lista_linea;
            }
            ddlLinea.DataTextField = "NOM_LINEA";
            ddlLinea.DataValueField = "COD_LINEA";
            ddlLinea.DataBind();

            var listaEstadosPti = new List<ClaseBasica>
            {
                new ClaseBasica {IdString = string.Empty, Descripcion = "TODOS LOS ESTADOS"},
                new ClaseBasica {IdString = "D", Descripcion = "DAÑADO"},
                new ClaseBasica {IdString = "O", Descripcion = "OPTATIVO"}
            };

            ddlEstado.DataSource = listaEstadosPti;
            ddlEstado.DataTextField = "Descripcion";
            ddlEstado.DataValueField = "IdString";
            ddlEstado.DataBind();
            gridPTI.PageSize = _listaRegistrosVisibles.First().IdInt;


            var parametros = new ClaseBasica
            {
                EstadoString = "A"
            };
            var result = _clienteReportes.ObtenerFabricantesPorEstado(Serializador.SerializeEntity(parametros));
            //ddlFabricante

            var listaFabricantes = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<SM_BRAND>>(result) : new List<SM_BRAND>();
            listaFabricantes.Insert(0, new SM_BRAND { COD_BRAND = string.Empty, NOMBRE_BRAND = "TODOS LOS FABRICANTES" });
            ddlFabricante.DataSource = listaFabricantes;
            ddlFabricante.DataValueField = "COD_BRAND";
            ddlFabricante.DataTextField = "NOMBRE_BRAND";
            ddlFabricante.DataBind();

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
                GestionUtil.VerReporte(this, "PTIReport", RecuperarFiltros());



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
                    List<GET_PTI_Result> lista = null;



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

                    result = _clienteReportes.ObtenerDatosPTIPaginado(out _totalRegistros, RecuperarFiltros(), PageSizeActual, PageIndexActual);

                    lista = result != null ? Serializador.DeSerializeEntity<List<GET_PTI_Result>>(result) : new List<GET_PTI_Result>();
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
                List<GET_PTI_Result> lista = null;

                result = _clienteReportes.ObtenerDatosPTIPaginado(out _totalRegistros, RecuperarFiltros(), PageSizeActual, PageIndexActual);
                lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<GET_PTI_Result>>(result) : new List<GET_PTI_Result>();
                BindingDatosPaginadosPorLista(lista, _totalRegistros);


            }
            catch (Exception)
            {
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
                    DescripcionUno = BuscarTextBox.Text.Trim().ToUpper(),
                    DescripcionDos = ddlDeposito.SelectedValue,
                    DescripcionTres = ddlLinea.SelectedValue,
                    DescripcionCuatro = ddlEstado.SelectedValue,
                    DescripcionCinco = ddlFabricante.SelectedValue,
                    FechaDateTimeStringUno = !string.IsNullOrEmpty(fechainicio) ? DateTime.Parse(fechainicio).ToString(CultureInfo.InvariantCulture) : string.Empty,
                    FechaDateTimeStringDos = !string.IsNullOrEmpty(fechafin) ? DateTime.Parse(fechafin).ToString(CultureInfo.InvariantCulture) : string.Empty,


                };

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
                gridPTI.PageSize = PageSizeActual;
                CargarDatosPorEstadoCoincidencia();
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PAGE_SIZE);
            }
        }
        private void BindingDatosPaginadosPorLista(List<GET_PTI_Result> lista, int totalRegistros)
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
                gridPTI.DataSource = lista;
                gridPTI.DataBind();
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }

        }




    }
}