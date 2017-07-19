using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;
using Negocio.Utilidades;

using PersistenciaSigeor;
using Sigeor.Utilidades;
using Sigeor.GestionControlServiceReference;
using Sigeor.GestionMglServiceReference;
using System.Globalization;

namespace Sigeor.GestionControl
{
    public partial class GestionNegociacionesLineaWebForm : System.Web.UI.Page
    {
        private ControlServiceClient _clienteControl;
        private GestionMglServiceClient _clienteMgl;
        private List<ClaseBasica> _listaRegistrosVisibles;
        private int _totalRegistros;
        private NegociacionLinea _negociacion;
        private Guid IdRegistro
        {
            set
            {
                ViewState["IdGestLin"] = value;
            }
            get
            {
                return Guid.Parse(ViewState["IdGestLin"].ToString());
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
        private bool EsNuevoRegistro
        {
            set
            {
                ViewState["IsNuevoNegLin"] = value;
            }
            get
            {
                return bool.Parse(ViewState["IsNuevoNegLin"].ToString());
            }
        }
        public GestionNegociacionesLineaWebForm()
        {
            try
            {
                _clienteControl = new ControlServiceClient();
                _clienteMgl = new GestionMglServiceClient();
                _listaRegistrosVisibles = GestionUtil.CargarNumeroRegistrosGridView();

            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_VARIABLES);
            }
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
                    lblCabecera.Text = GestionUtil.tituloPagina(this.Request.Url.LocalPath); ;

                    var result = _clienteControl.CargarEstadosNegociaciones();

                    var listaEstados = !string.IsNullOrEmpty(result)
                        ? Serializador.DeSerializeEntity<List<ClaseBasica>>(result)
                        : new List<ClaseBasica>();

                    //listaEstados.Insert(0, new ClaseBasica { IdString = string.Empty, Nombre = "TODOS LOS ESTADOS" });
                    ddlEstado.DataSource = listaEstados;
                    ddlEstado.DataValueField = "IdString";
                    ddlEstado.DataTextField = "Nombre";
                    ddlEstado.DataBind();

                    NegociacionesGridView.PageSize = _listaRegistrosVisibles.First().IdInt;
                    RegistrosVisiblesDropDownList.DataSource = _listaRegistrosVisibles;
                    RegistrosVisiblesDropDownList.DataValueField = "IdInt";
                    RegistrosVisiblesDropDownList.DataTextField = "Descripcion";
                    RegistrosVisiblesDropDownList.DataBind();
                    RegistrosVisiblesDropDownList.SelectedValue = "20";


                    var resultDepositos = _clienteMgl.ObtenerDepositosPorEstado("A");
                    var listaDepositos = !string.IsNullOrEmpty(resultDepositos)
                       ? Serializador.DeSerializeEntity<List<SM_DEPOSITO>>(resultDepositos)
                       : null;

                    listaDepositos?.Insert(0, new SM_DEPOSITO { COD_DEPOSITO = string.Empty, NOMBRE_DEPOSITO = "Elija un Depósito..." });
                    DepositoDropDownList.DataSource = listaDepositos;
                    DepositoDropDownList.DataValueField = "COD_DEPOSITO";
                    DepositoDropDownList.DataTextField = "NOMBRE_DEPOSITO";
                    DepositoDropDownList.DataBind();

                    //CargarDataNegociacionesGridView(EstadoCheckBox.Checked, null);
                    var resultLineas = _clienteMgl.ObtenerLineasPorEstado("A");
                    var listaLineas = !string.IsNullOrEmpty(resultLineas)
                        ? Serializador.DeSerializeEntity<List<SM_LINEA>>(resultLineas)
                        : null;

                    listaLineas?.Insert(0, new SM_LINEA { COD_LINEA = string.Empty, NOM_LINEA = "Elija una Línea..." });
                    LineaDropDownList.DataSource = listaLineas;
                    LineaDropDownList.DataTextField = "NOM_LINEA";
                    LineaDropDownList.DataValueField = "COD_LINEA";
                    LineaDropDownList.DataBind();

                    txtFechaInicio.Text = DateTime.Now.AddDays(-30).ToShortDateString();
                    txtFechaFin.Text = DateTime.Now.ToShortDateString();

                    CargarDatosPorEstadoCoincidencia();
                }
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "Eor's por Tránsito", ConstantesUtil.MENSAJE_ERROR_LOAD);
            }

        }
        private void CargarDatosPorEstadoCoincidencia()
        {
            try
            {
                string result;

                txtFechaInicio.Text = Request.Form[txtFechaInicio.ID] != null ? Request.Form[txtFechaInicio.ID].ToString() : txtFechaInicio.Text;
                txtFechaFin.Text = Request.Form[txtFechaFin.ID] != null ? Request.Form[txtFechaFin.ID].ToString() : txtFechaFin.Text;


                var filtro = new ClaseBasica
                {

                    FechaDateTimeStringUno = DateTime.Parse(txtFechaInicio.Text).ToString(CultureInfo.InvariantCulture),
                    FechaDateTimeStringDos = DateTime.Parse(txtFechaFin.Text).AddDays(1).ToString(CultureInfo.InvariantCulture),
                    EstadoUno = HistorialChk.Checked,
                    EstadoString = ddlEstado.SelectedValue
                };

                if (!string.IsNullOrEmpty(BuscarTextBox.Text.Trim()))
                {
                    filtro.Descripcion = BuscarTextBox.Text;
                    result = _clienteControl.ObtenerNegociacionesLineaHistoricoPaginado(out _totalRegistros, Serializador.SerializeEntity(filtro), PageSizeActual, PageIndexActual);
                    //lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<NegociacionLinea>>(result) : null;
                }
                else
                {
                    result = _clienteControl.ObtenerNegociacionesLineaHistoricoPaginado(out _totalRegistros, Serializador.SerializeEntity(filtro), PageSizeActual, PageIndexActual);
                }

                var lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<GET_HISTORIAL_NEG_LINEAS_Result>>(result) : new List<GET_HISTORIAL_NEG_LINEAS_Result>();
                BindingDatosPaginadosPorLista(lista, _totalRegistros);
            }
            catch (Exception ex)
            {

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }
        }
        //private void CargarDataNegociacionesGridView(Boolean? estado, List<NegociacionLinea> lista)
        //{
        //    try
        //    {
        //        RegistrosVisiblesDropDownList.Visible = false;
        //        if (estado != null)
        //        {
        //            var result = _clienteControl.ObtenerNegociacionesPorEstado(estado.Value);
        //            lista = null;
        //            if (!string.IsNullOrEmpty(result))
        //                lista = Serializador.DeSerializeEntity<List<NegociacionLinea>>(result);
        //        }

        //        if (lista != null)
        //        {
        //            if (lista.Count > Int16.Parse(RegistrosVisiblesDropDownList.SelectedValue))
        //                RegistrosVisiblesDropDownList.Visible = true;
        //        }


        //        NegociacionesGridView.DataSource = lista;
        //        NegociacionesGridView.PageSize = int.Parse(RegistrosVisiblesDropDownList.SelectedValue);
        //        NegociacionesGridView.DataBind();
        //        ViewState[ConstantesUtil.Registros] = lista;
        //    }
        //    catch (Exception ex)
        //    {
        //        GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
        //    }
        //}
        protected void NegociacionesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void EstadoCabeceraGridView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //_clienteControl.ModificarNegociacionLineaMasivamente(BuscarTextBox.Text, EstadoCheckBox.Checked);
                CargarDatosPorEstadoCoincidencia();
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_EDICION_POR_ESTADO_CABECERA);
            }
        }
        protected void EstadoCheckBoxGridView_CheckedChangedPrincipal(object sender, EventArgs e)
        {
            try
            {

                CheckBox checkboxEstado = sender as CheckBox;
                GridViewRow gr = (GridViewRow)checkboxEstado.NamingContainer;
                IdRegistro = Guid.Parse(NegociacionesGridView.DataKeys[gr.RowIndex].Value.ToString());

                var _negociacion =
                    Serializador.DeSerializeEntity<NegociacionLinea>(
                        _clienteControl.ObtenerNegociacionesLineaPorId(
                            Serializador.SerializeEntity(IdRegistro)));
                _negociacion.CampoIpUsuario = GestionUtil.IpCliente;
                _negociacion.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                _negociacion.Estado = !_negociacion.Estado;
                _clienteControl.ModificarNegociacionLinea(
                    Serializador.SerializeEntity(_negociacion));

                CargarDatosPorEstadoCoincidencia();
                BuscarTextBox.Text = string.Empty;

            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_EDICION_POR_ESTADO_GRIDVIEW);
            }

        }
        protected void RegistrosVisiblesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                paginaActualTextBox.Text = "1";
                NegociacionesGridView.PageSize = PageSizeActual;
                CargarDatosPorEstadoCoincidencia();
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
                GestionUtil.Redireccionar(ConstantesUtil.URL_MENU_CONTROL);
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_NAVEGACION_MENU);
            }
        }
        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (LineaDropDownList.Items.Count > 0)
                    LineaDropDownList.SelectedIndex = 0;

                if (DepositoDropDownList.Items.Count > 0)
                    DepositoDropDownList.SelectedIndex = 0;

                TituloModalPanel.Text = ConstantesUtil.TITULO_NUEVA_NEGOCIACION;
                DescripcionModalTxt.Text = string.Empty;
                //PrecioHHEstTxt.Text = PrecioHHMaqTxt.Text = string.Empty;
                NegociacionEstTxt.Text = NegociacionMaqTxt.Text = string.Empty;
                PtiNormalTextBox.Text = PtiLargoTextBox.Text = string.Empty;
                EsPorcNegEst.Text = EsPorcNegMaq.Text = string.Empty;
                txtFechaInicioModal.Text = DateTime.Now.ToShortDateString();
                txtFechaFinModal.Text = DateTime.Now.AddDays(1).ToShortDateString();
                EsPorcNegEst.Checked = EsPorcNegMaq.Checked = false;
                EstadoModal.Enabled = EstadoModal.Checked = EsNuevoRegistro = true;
                GestionUtil.MostrarModal(this);
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_ABRIR_DIALOGO_NUEVO);
            }
        }

        private bool ValidarCampos()
        {
            var validacionCamposCorrecta = true;

            if (string.IsNullOrEmpty(LineaDropDownList.SelectedValue))
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Línea", ConstantesUtil.mensajeCampoObligatorio);
                validacionCamposCorrecta = false;

            }

            if (string.IsNullOrEmpty(DepositoDropDownList.SelectedValue))
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Depósito", ConstantesUtil.mensajeCampoObligatorio);
                validacionCamposCorrecta = false;

            }

            if (string.IsNullOrEmpty(DescripcionModalTxt.Text.Trim()))
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Descripción", ConstantesUtil.mensajeCampoObligatorio);
                validacionCamposCorrecta = false;
            }


            //if (string.IsNullOrEmpty(PrecioHHEstTxt.Text.Trim()))
            //{
            //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Precio H/H Estructura", ConstantesUtil.mensajeCampoObligatorio);
            //    validacionCamposCorrecta = false;
            //}

            //if (string.IsNullOrEmpty(PrecioHHMaqTxt.Text.Trim()))
            //{
            //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Precio H/H Maquinaria", ConstantesUtil.mensajeCampoObligatorio);
            //    validacionCamposCorrecta = false;
            //}

            if (string.IsNullOrEmpty(NegociacionEstTxt.Text.Trim()))
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Negociación Estructura", ConstantesUtil.mensajeCampoObligatorio);
                validacionCamposCorrecta = false;
            }

            if (string.IsNullOrEmpty(NegociacionMaqTxt.Text.Trim()))
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Negociación Maquinaria", ConstantesUtil.mensajeCampoObligatorio);
                validacionCamposCorrecta = false;
            }


            //if (!string.IsNullOrEmpty(PrecioHHEstTxt.Text.Trim()) && !ValidacionesUtil.ValidarNumeros(PrecioHHEstTxt.Text))
            //{
            //    PrecioHHEstTxt.Text = string.Empty;
            //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Precio H/H Estructura", ConstantesUtil.mensajeFormatoNumericoIncorrecto);
            //    validacionCamposCorrecta = false;
            //}

            //if (!string.IsNullOrEmpty(PrecioHHMaqTxt.Text.Trim()) && !ValidacionesUtil.ValidarNumeros(PrecioHHMaqTxt.Text))
            //{
            //    PrecioHHMaqTxt.Text = string.Empty;
            //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Precio H/H Maquinaria", ConstantesUtil.mensajeFormatoNumericoIncorrecto);
            //    validacionCamposCorrecta = false;
            //}

            if (!string.IsNullOrEmpty(NegociacionEstTxt.Text.Trim()) && !ValidacionesUtil.ValidarNumeros(NegociacionEstTxt.Text))
            {
                NegociacionEstTxt.Text = string.Empty;
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Costo H/H Maquinaria", ConstantesUtil.mensajeFormatoNumericoIncorrecto);
                validacionCamposCorrecta = false;
            }

            if (!string.IsNullOrEmpty(NegociacionEstTxt.Text.Trim()) && ValidacionesUtil.ValidarNumeros(NegociacionEstTxt.Text) && EsPorcNegEst.Checked)
            {
                var valorNegociacion = decimal.Parse(NegociacionEstTxt.Text);
                if (!(valorNegociacion >= 0 && valorNegociacion <= 100))
                {
                    NegociacionEstTxt.Text = "00,00";
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El porcentaje de Negociación \"Neg. H/H Est.\" debe estar en el rango de 0 a 100");
                    validacionCamposCorrecta = false;
                }
            }

            if (!string.IsNullOrEmpty(NegociacionMaqTxt.Text.Trim()) && ValidacionesUtil.ValidarNumeros(NegociacionMaqTxt.Text) && EsPorcNegMaq.Checked)
            {
                var valorNegociacion = decimal.Parse(NegociacionMaqTxt.Text);
                if (!(valorNegociacion >= 0 && valorNegociacion <= 100))
                {
                    NegociacionMaqTxt.Text = "00,00";
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El porcentaje de Negociación \"Neg. H/H Maq.\" debe estar en el rango de 0 a 100");
                    validacionCamposCorrecta = false;
                }
            }

            if (!string.IsNullOrEmpty(PtiNormalTextBox.Text.Trim()) &&
                !ValidacionesUtil.ValidarNumeros(PtiNormalTextBox.Text.Trim()))
            {
                PtiNormalTextBox.Text = "00,00";
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Pti Normal", ConstantesUtil.mensajeFormatoNumericoIncorrecto);
                validacionCamposCorrecta = false;

            }

            if (!string.IsNullOrEmpty(PtiLargoTextBox.Text.Trim()) &&
               !ValidacionesUtil.ValidarNumeros(PtiLargoTextBox.Text.Trim()))
            {
                PtiLargoTextBox.Text = "00,00";
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Pti Largo", ConstantesUtil.mensajeFormatoNumericoIncorrecto);
                validacionCamposCorrecta = false;

            }

            return validacionCamposCorrecta;
        }

        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {



                if (!ValidarCampos())
                    return;

                if (EsNuevoRegistro)//Es nuevo registro
                {

                    var nuevaNegociacion = new NegociacionLinea
                    {
                        Id = Guid.NewGuid(),
                        CodLinea = LineaDropDownList.SelectedValue,
                        IdDeposito = DepositoDropDownList.SelectedValue,
                        FechaInicioVal = DateTime.Parse(Request.Form[txtFechaInicioModal.UniqueID].ToString()),
                        FechaFinVal = DateTime.Parse(Request.Form[txtFechaFinModal.UniqueID].ToString()),
                        Descripcion = DescripcionModalTxt.Text,
                        //PrecioHHEstructura = string.IsNullOrEmpty(PrecioHHEstTxt.Text) ? 0 : decimal.Parse(PrecioHHEstTxt.Text),
                        //PrecioHHMaquinaria = string.IsNullOrEmpty(PrecioHHMaqTxt.Text) ? 0 : decimal.Parse(PrecioHHMaqTxt.Text),
                        ValorNegoHHEst = string.IsNullOrEmpty(NegociacionEstTxt.Text) ? 0 : decimal.Parse(NegociacionEstTxt.Text),
                        ValorNegoHHMaq = string.IsNullOrEmpty(NegociacionMaqTxt.Text) ? 0 : decimal.Parse(NegociacionMaqTxt.Text),
                        PtiNormal = string.IsNullOrEmpty(PtiNormalTextBox.Text) ? 0 : decimal.Parse(PtiNormalTextBox.Text),
                        PtiLargo = string.IsNullOrEmpty(PtiLargoTextBox.Text) ? 0 : decimal.Parse(PtiLargoTextBox.Text),
                        UsuarioCrea = GestionUtil.UsuarioSesion.Cedula,
                        CampoIpUsuario = GestionUtil.IpCliente,
                        CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula,
                        EsPorcNegoHHEst = EsPorcNegEst.Checked,
                        EsPorcNegoHHMaq = EsPorcNegMaq.Checked,
                        Estado = EstadoModal.Checked
                    };
                    _clienteControl.InsertarNegociacionLinea(Serializador.SerializeEntity(nuevaNegociacion));
                    CargarDatosPorEstadoCoincidencia();
                    GestionUtil.OcultarModal(this);
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Negociación", ConstantesUtil.mensajeRegistroGuardado);

                }
                else//Se debe editar el registro
                {
                    if (!EsNuevoRegistro)
                    {

                        var result = _clienteControl.ObtenerNegociacionesLineaPorId(Serializador.SerializeEntity(IdRegistro));
                        _negociacion = !string.IsNullOrEmpty(result)
                            ? Serializador.DeSerializeEntity<NegociacionLinea>(result)
                            : null;
                        var resultLinea = _clienteMgl.ObtenerLineaPorCodigo(Serializador.SerializeEntity(new ClaseBasica { IdStringUno = LineaDropDownList.SelectedValue }));

                        if (_negociacion != null)
                        {
                            _negociacion.CodLinea = LineaDropDownList.SelectedValue;
                            _negociacion.IdDeposito = DepositoDropDownList.SelectedValue;
                            //_negociacion.PrecioHHEstructura = decimal.Parse(PrecioHHEstTxt.Text);
                            //_negociacion.PrecioHHMaquinaria = decimal.Parse(PrecioHHMaqTxt.Text);
                            _negociacion.ValorNegoHHEst = decimal.Parse(NegociacionEstTxt.Text);
                            _negociacion.ValorNegoHHMaq = decimal.Parse(NegociacionMaqTxt.Text);
                            _negociacion.PtiNormal = decimal.Parse(PtiNormalTextBox.Text);
                            _negociacion.PtiLargo = decimal.Parse(PtiLargoTextBox.Text);
                            _negociacion.EsPorcNegoHHEst = EsPorcNegEst.Checked;
                            _negociacion.EsPorcNegoHHMaq = EsPorcNegMaq.Checked;
                            _negociacion.FechaInicioVal = DateTime.Parse(Request.Form[txtFechaInicioModal.UniqueID].ToString());
                            _negociacion.FechaFinVal = DateTime.Parse(Request.Form[txtFechaFinModal.UniqueID].ToString());
                            _negociacion.Descripcion = DescripcionModalTxt.Text;
                            _negociacion.CampoIpUsuario = GestionUtil.IpCliente;
                            _negociacion.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                            _negociacion.SM_LINEA = !string.IsNullOrEmpty(resultLinea) ? Serializador.DeSerializeEntity<SM_LINEA>(resultLinea) : null;
                            _clienteControl.ModificarNegociacionLinea(Serializador.SerializeEntity(_negociacion));
                            GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Negociación por Línea", ConstantesUtil.mensajeRegistroGuardado);
                            GestionUtil.OcultarModal(this);
                            CargarDatosPorEstadoCoincidencia();
                        }


                    }
                }


            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_GUARDAR);
            }
        }
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = sender as LinkButton;
                GridViewRow gr = (GridViewRow)linkButton.NamingContainer;
                IdRegistro = Guid.Parse(NegociacionesGridView.DataKeys[gr.RowIndex].Value.ToString());
                var result = _clienteControl.ObtenerNegociacionesLineaPorId(Serializador.SerializeEntity(IdRegistro));
                _negociacion = !string.IsNullOrEmpty(result)
                    ? Serializador.DeSerializeEntity<NegociacionLinea>(result)
                    : null;

                var index = LineaDropDownList.Items.IndexOf(LineaDropDownList.Items.FindByValue(_negociacion.CodLinea));
                LineaDropDownList.SelectedIndex = index;

                index = DepositoDropDownList.Items.IndexOf(DepositoDropDownList.Items.FindByValue(_negociacion.IdDeposito));
                DepositoDropDownList.SelectedIndex = index;

                txtFechaInicioModal.Text = _negociacion.FechaInicioVal.ToShortDateString();
                txtFechaFinModal.Text = _negociacion.FechaFinVal.ToShortDateString();
                DescripcionModalTxt.Text = _negociacion.Descripcion;
                //PrecioHHEstTxt.Text = _negociacion.PrecioHHEstructura.ToString();
                //PrecioHHMaqTxt.Text = _negociacion.PrecioHHMaquinaria.ToString();
                NegociacionEstTxt.Text = _negociacion.ValorNegoHHEst.ToString();
                NegociacionMaqTxt.Text = _negociacion.ValorNegoHHMaq.ToString();
                PtiNormalTextBox.Text = _negociacion.PtiNormal.ToString();
                PtiLargoTextBox.Text = _negociacion.PtiLargo.ToString();
                EsPorcNegEst.Checked = _negociacion.EsPorcNegoHHEst;
                EsPorcNegMaq.Checked = _negociacion.EsPorcNegoHHMaq;
                EstadoModal.Checked = _negociacion.Estado;

                EsNuevoRegistro = false;
                TituloModalPanel.Text = ConstantesUtil.TITULO_EDITAR_NEGOCIACION;
                GestionUtil.MostrarModal(this);
                CargarDatosPorEstadoCoincidencia();
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_ABRIR_DIALOGO_EDICION);
            }
        }
        protected void EstadoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                BuscarTextBox.Text = string.Empty;
                CargarDatosPorEstadoCoincidencia();
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_BUSQUEDA_POR_ESTADO);

            }


        }

        private void BindingDatosPaginadosPorLista(List<GET_HISTORIAL_NEG_LINEAS_Result> lista, int totalRegistros)
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

                NegociacionesGridView.DataSource = lista;
                NegociacionesGridView.DataBind();
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

                    string result;

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

                    var filtro = new ClaseBasica
                    {

                        FechaDateTimeStringUno = DateTime.Parse(txtFechaInicio.Text).ToString(CultureInfo.InvariantCulture),
                        FechaDateTimeStringDos = DateTime.Parse(txtFechaFin.Text).AddDays(1).ToString(CultureInfo.InvariantCulture),
                        EstadoUno = HistorialChk.Checked,
                        EstadoString = ddlEstado.SelectedValue
                    };

                    if (!string.IsNullOrEmpty(BuscarTextBox.Text))
                    {
                        filtro.Descripcion = BuscarTextBox.Text;
                        result = _clienteControl.ObtenerNegociacionesLineaHistoricoPaginado(out _totalRegistros, Serializador.SerializeEntity(filtro), PageSizeActual, PageIndexActual);
                    }
                    else
                    {
                        result = _clienteControl.ObtenerNegociacionesLineaHistoricoPaginado(out _totalRegistros, Serializador.SerializeEntity(filtro), PageSizeActual, PageIndexActual);
                    }

                    var lista = result != null ? Serializador.DeSerializeEntity<List<GET_HISTORIAL_NEG_LINEAS_Result>>(result) : new List<GET_HISTORIAL_NEG_LINEAS_Result>();
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

        protected void formularioPrincipal_OnPreRender(object sender, EventArgs e)
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

        protected void BtnBuscar_OnClick(object sender, EventArgs e)
        {
            try
            {
                CargarDatosPorEstadoCoincidencia();
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_BUSQUEDA_POR_COINCIDENCIAS);
            }
        }

        protected void EsPorcNegEst_OnCheckedChanged(object sender, EventArgs e)
        {
            if (EsPorcNegEst.Checked)
            {
                NegociacionEstTxt.Attributes.Add("placeholder", "Rango del 0 al 100");
            }

            else
            {
                NegociacionEstTxt.Attributes.Add("placeholder", "Ejem. 10,00");
            }
        }


        protected void EsPorcNegMaq_OnCheckedChanged(object sender, EventArgs e)
        {
            if (EsPorcNegMaq.Checked)
            {
                NegociacionMaqTxt.Attributes.Add("placeholder", "Rango del 0 al 100");
            }

            else
            {
                NegociacionMaqTxt.Attributes.Add("placeholder", "Ejem. 10,00");
            }
        }

    }
}
