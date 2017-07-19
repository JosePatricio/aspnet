using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.Utilidades;
using Sigeor.GestionControlServiceReference;
using Sigeor.GestionMglServiceReference;
using System.Globalization;

namespace Sigeor.GestionControl
{
    public partial class GestionNegociacionesProveedorWebForm : System.Web.UI.Page
    {
        private ControlServiceClient _clienteControl;
        private GestionMglServiceClient _clienteMgl;
        private List<ClaseBasica> _listaRegistrosVisibles;
        private int _totalRegistros;
        private NegociacionProveedor _negociacion;
        private Guid IdRegistro
        {
            set
            {
                ViewState["IdNegProv"] = value;
            }
            get
            {
                return Guid.Parse(ViewState["IdNegProv"].ToString());
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
                ViewState["IsNuevoNegProv"] = value;
            }
            get
            {
                return bool.Parse(ViewState["IsNuevoNegProv"].ToString());
            }
        }
        public GestionNegociacionesProveedorWebForm()
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


                    //lblCabecera.Text = ViewState["TituloMenu"] != null ? ViewState["TituloMenu"].ToString() : string.Empty;

                    NegociacionesGridView.PageSize = _listaRegistrosVisibles.First().IdInt;
                    RegistrosVisiblesDropDownList.DataSource = _listaRegistrosVisibles;
                    RegistrosVisiblesDropDownList.DataValueField = "IdInt";
                    RegistrosVisiblesDropDownList.DataTextField = "Descripcion";
                    RegistrosVisiblesDropDownList.DataBind();
                    RegistrosVisiblesDropDownList.SelectedValue = "20";
                    //CargarDataNegociacionesGridView(EstadoCheckBox.Checked, null);
                    var parametro = new ClaseBasica { EstadoString = "A" };
                    var resultProveedores = _clienteMgl.ObtenerProveedoresPorEstado(Serializador.SerializeEntity(parametro));
                    var listaProveedores = !string.IsNullOrEmpty(resultProveedores)
                        ? Serializador.DeSerializeEntity<List<S_OCRD>>(resultProveedores)
                        : null;

                    listaProveedores?.Insert(0, new S_OCRD { CardCode = string.Empty, CardName = "Elija un Proveedor..." });
                    ProveedorDropDownList.DataSource = listaProveedores;
                    ProveedorDropDownList.DataValueField = "CardCode";
                    ProveedorDropDownList.DataTextField = "CardName";
                    ProveedorDropDownList.DataBind();

                    var resultDepositos = _clienteMgl.ObtenerDepositosPorEstado("A");
                    var listaDepositos = !string.IsNullOrEmpty(resultDepositos)
                       ? Serializador.DeSerializeEntity<List<SM_DEPOSITO>>(resultDepositos)
                       : null;

                    var resultLineas = _clienteMgl.ObtenerLineasPorEstado("A");
                    var listaLineas = !string.IsNullOrEmpty(resultLineas)
                        ? Serializador.DeSerializeEntity<List<SM_LINEA>>(resultLineas)
                        : null;

                    listaLineas?.Insert(0, new SM_LINEA { COD_LINEA = string.Empty, NOM_LINEA = "Elija una Línea..." });
                    LineaDropDownList.DataSource = listaLineas;
                    LineaDropDownList.DataTextField = "NOM_LINEA";
                    LineaDropDownList.DataValueField = "COD_LINEA";
                    LineaDropDownList.DataBind();


                    listaDepositos?.Insert(0, new SM_DEPOSITO { COD_DEPOSITO = string.Empty, NOMBRE_DEPOSITO = "Elija un Depósito..." });
                    DepositoDropDownList.DataSource = listaDepositos;
                    DepositoDropDownList.DataValueField = "COD_DEPOSITO";
                    DepositoDropDownList.DataTextField = "NOMBRE_DEPOSITO";
                    DepositoDropDownList.DataBind();

                    txtFechaInicio.Text = DateTime.Now.AddDays(-30).ToShortDateString();
                    txtFechaFin.Text = DateTime.Now.ToShortDateString();
                    CargarDatosPorEstadoCoincidencia();

                }
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "Negociación por Proveedor", ConstantesUtil.MENSAJE_ERROR_LOAD);
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
                    result = _clienteControl.ObtenerNegociacionesProveedorHistoricoPaginado(out _totalRegistros, Serializador.SerializeEntity(filtro), PageSizeActual, PageIndexActual);
                }
                else
                {
                    result = _clienteControl.ObtenerNegociacionesProveedorHistoricoPaginado(out _totalRegistros, Serializador.SerializeEntity(filtro), PageSizeActual, PageIndexActual);
                }
                var lista = result != null ? Serializador.DeSerializeEntity<List<GET_HISTORIAL_NEG_PROVEEDORES_Result>>(result) : new List<GET_HISTORIAL_NEG_PROVEEDORES_Result>();

                BindingDatosPaginadosPorLista(lista, _totalRegistros);
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }
        }
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

                //_clienteControl.ModificarNegociacionProveedoresMasivamente(BuscarTextBox.Text, EstadoCheckBox.Checked);
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
                var clave = new ClaseBasica
                {
                    IdGuid = Guid.Parse(NegociacionesGridView.DataKeys[gr.RowIndex].Value.ToString())
                };

                NegociacionProveedor _negociacion =
                    Serializador.DeSerializeEntity<NegociacionProveedor>(
                        _clienteControl.ObtenerNegociacionesProveedorPorId(Serializador.SerializeEntity(clave)));
                _negociacion.CampoIpUsuario = GestionUtil.IpCliente;
                _negociacion.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                _negociacion.Estado = !_negociacion.Estado;
                _clienteControl.ModificarNegociacionProveedor(
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
                if (ProveedorDropDownList.Items.Count > 0)
                    ProveedorDropDownList.SelectedIndex = 0;

                if (DepositoDropDownList.Items.Count > 0)
                    DepositoDropDownList.SelectedIndex = 0;

                if (LineaDropDownList.Items.Count > 0)
                    LineaDropDownList.SelectedIndex = 0;

                TituloModalPanel.Text = ConstantesUtil.TITULO_NUEVA_NEGOCIACION;

                NegociacionMaterialEstTxt.Text = NegociacionMaterialMaqTxt.Text = string.Empty;
                DescripcionModalTxt.Text = NegociacionManoObraEstTxt.Text = NegociacionManoObraMaqTxt.Text = string.Empty;
                PtiNormalTextBox.Text = PtiRapTextBox.Text = string.Empty;

                EsPorcNegEst.Checked = EsPorcNegMaq.Checked = true;
                txtFechaInicioModal.Text = DateTime.Now.ToShortDateString();
                txtFechaFinModal.Text = DateTime.Now.AddDays(1).ToShortDateString();
                EstadoModal.Checked = true;
                EsNuevoRegistro = true;
                GestionUtil.MostrarModal(this);
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_ABRIR_DIALOGO_NUEVO);
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {

                var validacionCamposCorrecta = true;

                #region Validacion Campos Obligatorios
                if (string.IsNullOrEmpty(ProveedorDropDownList.SelectedValue))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Proveedor", ConstantesUtil.mensajeCampoObligatorio);

                }

                if (string.IsNullOrEmpty(DepositoDropDownList.SelectedValue))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Depósito", ConstantesUtil.mensajeCampoObligatorio);

                }

                if (string.IsNullOrEmpty(DescripcionModalTxt.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Descripción", ConstantesUtil.mensajeCampoObligatorio);
                    validacionCamposCorrecta = false;
                }


                //if (string.IsNullOrEmpty(PrecioHHEstTxt.Text.Trim()))
                //{
                //    PrecioHHEstTxt.Text = string.Empty;
                //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Costo H/H Estructura", ConstantesUtil.mensajeCampoObligatorio);
                //    validacionCamposCorrecta = false;
                //}

                //if (string.IsNullOrEmpty(PrecioHHMaqTxt.Text.Trim()))
                //{
                //    PrecioHHMaqTxt.Text = string.Empty;
                //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Costo H/H Maquinaria", ConstantesUtil.mensajeCampoObligatorio);
                //    validacionCamposCorrecta = false;
                //}

                //if (string.IsNullOrEmpty(NegociacionManoObraEstTxt.Text.Trim()))
                //{
                //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "\"Neg. H/H Est.\"", ConstantesUtil.mensajeCampoObligatorio);
                //    validacionCamposCorrecta = false;
                //}

                #endregion Fin Validacion Campos Obligatorios

                if (!string.IsNullOrEmpty(PtiNormalTextBox.Text.Trim()) && !ValidacionesUtil.ValidarNumeros(PtiNormalTextBox.Text.Trim()))
                {
                    PtiNormalTextBox.Text = string.Empty;
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "PTI Normal", ConstantesUtil.mensajeFormatoNumericoIncorrecto);
                    validacionCamposCorrecta = false;
                }

                if (!string.IsNullOrEmpty(PtiRapTextBox.Text.Trim()) && !ValidacionesUtil.ValidarNumeros(PtiRapTextBox.Text.Trim()))
                {
                    PtiRapTextBox.Text = string.Empty;
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "PTI Rap", ConstantesUtil.mensajeFormatoNumericoIncorrecto);
                    validacionCamposCorrecta = false;
                }



                if (!string.IsNullOrEmpty(NegociacionMaterialEstTxt.Text.Trim()) && !ValidacionesUtil.ValidarNumeros(NegociacionMaterialEstTxt.Text))
                {
                    NegociacionMaterialEstTxt.Text = string.Empty;
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Neg. Material Estructura", ConstantesUtil.mensajeFormatoNumericoIncorrecto);
                    validacionCamposCorrecta = false;
                }

                if (!string.IsNullOrEmpty(NegociacionMaterialMaqTxt.Text.Trim()) && !ValidacionesUtil.ValidarNumeros(NegociacionMaterialMaqTxt.Text))
                {
                    NegociacionMaterialMaqTxt.Text = string.Empty;
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Neg. Material Maquinaria", ConstantesUtil.mensajeFormatoNumericoIncorrecto);
                    validacionCamposCorrecta = false;
                }


                if (!string.IsNullOrEmpty(NegociacionManoObraEstTxt.Text.Trim()) && !ValidacionesUtil.ValidarNumeros(NegociacionManoObraEstTxt.Text))
                {
                    NegociacionManoObraEstTxt.Text = string.Empty;
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Neg. Mano Obra Estructura", ConstantesUtil.mensajeFormatoNumericoIncorrecto);
                    validacionCamposCorrecta = false;
                }

                if (!string.IsNullOrEmpty(NegociacionManoObraMaqTxt.Text.Trim()) && !ValidacionesUtil.ValidarNumeros(NegociacionManoObraMaqTxt.Text))
                {
                    NegociacionManoObraMaqTxt.Text = string.Empty;
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Neg. Mano Obra Maquinaria", ConstantesUtil.mensajeFormatoNumericoIncorrecto);
                    validacionCamposCorrecta = false;
                }


                if (!string.IsNullOrEmpty(NegociacionMaterialEstTxt.Text.Trim()) && ValidacionesUtil.ValidarNumeros(NegociacionMaterialEstTxt.Text))
                {
                    var valorNegociacion = decimal.Parse(NegociacionMaterialEstTxt.Text);
                    if (!(valorNegociacion > 0 && valorNegociacion < 100) && EsPorcNegEst.Checked)
                    {
                        NegociacionMaterialEstTxt.Text = string.Empty;
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El Valor Porcentual de la Neg. Material Estructura debe estar entre 0 y 100");
                        validacionCamposCorrecta = false;
                    }

                    if (valorNegociacion < 1 && !EsPorcNegEst.Checked)
                    {
                        NegociacionMaterialEstTxt.Text = string.Empty;
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El Valor Monetario de Neg. Material Estructura debe ser mayor a 0");
                        validacionCamposCorrecta = false;
                    }

                }


                if (!string.IsNullOrEmpty(NegociacionMaterialMaqTxt.Text.Trim()) && ValidacionesUtil.ValidarNumeros(NegociacionMaterialMaqTxt.Text))
                {
                    var valorNegociacion = decimal.Parse(NegociacionMaterialMaqTxt.Text);
                    if (!(valorNegociacion > 0 && valorNegociacion < 100) && EsPorcNegMaq.Checked)
                    {
                        NegociacionMaterialMaqTxt.Text = string.Empty;
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El Valor Porcentual de Neg. Material Maquinaria debe estar entre 1 y 100");
                        validacionCamposCorrecta = false;
                    }

                    if (valorNegociacion < 1 && !EsPorcNegEst.Checked)
                    {
                        NegociacionMaterialMaqTxt.Text = string.Empty;
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El Valor Monetario de Neg. Material Maquinaria debe ser mayor a 0");
                        validacionCamposCorrecta = false;
                    }

                }

                if (!validacionCamposCorrecta) return;



                if (EsNuevoRegistro)//Es nuevo registro
                {
                    var nuevaNegociacion = new NegociacionProveedor
                    {
                        Id = Guid.NewGuid(),
                        IdProveedor = ProveedorDropDownList.SelectedValue,
                        IdDeposito = DepositoDropDownList.SelectedValue,
                        CodLinea = LineaDropDownList.SelectedValue,
                        Descripcion = DescripcionModalTxt.Text,
                        ValorNegoMaterialEstructura = decimal.Parse(NegociacionMaterialEstTxt.Text),
                        ValorNegoMaterialMaquinaria = decimal.Parse(NegociacionMaterialMaqTxt.Text),
                        ValorNegoHHEst = decimal.Parse(NegociacionManoObraEstTxt.Text.Trim()),
                        ValorNegoHHMaq = decimal.Parse(NegociacionManoObraMaqTxt.Text.Trim()),
                        PtiNormal = decimal.Parse(PtiNormalTextBox.Text.Trim()),
                        PtiLargo = decimal.Parse(PtiRapTextBox.Text.Trim()),
                        FechaInicioVal = DateTime.Parse(Request.Form[txtFechaInicioModal.UniqueID].ToString()),
                        FechaFinVal = DateTime.Parse(Request.Form[txtFechaFinModal.UniqueID].ToString()),
                        UsuarioCrea = GestionUtil.UsuarioSesion.Cedula,
                        CampoIpUsuario = GestionUtil.IpCliente,
                        CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula,
                        EsPorcNegoMatEst = EsPorcNegEst.Checked,
                        EsPorcNegoMatMaq = EsPorcNegMaq.Checked,
                        Estado = EstadoModal.Checked
                    };
                    _clienteControl.InsertarNegociacionProveedor(Serializador.SerializeEntity(nuevaNegociacion));
                    CargarDatosPorEstadoCoincidencia();
                    GestionUtil.OcultarModal(this);
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Negociación por Proveedor", ConstantesUtil.mensajeRegistroGuardado);

                }
                else//Se debe editar el registro
                {
                    if (!EsNuevoRegistro)
                    {
                        var clave = new ClaseBasica { IdGuid = IdRegistro };

                        var result = _clienteControl.ObtenerNegociacionesProveedorPorId(Serializador.SerializeEntity(clave));
                        _negociacion = !string.IsNullOrEmpty(result)
                            ? Serializador.DeSerializeEntity<NegociacionProveedor>(result)
                            : null;
                        var resultProveedor = _clienteMgl.ObtenerProveedorPorId(Serializador.SerializeEntity(new ClaseBasica { IdString = ProveedorDropDownList.SelectedValue }));
                        var resultDeposito = _clienteMgl.ObtenerDespositoPorId(Serializador.SerializeEntity(new ClaseBasica { IdString = DepositoDropDownList.SelectedValue }));

                        if (_negociacion != null)
                        {
                            _negociacion.IdProveedor = ProveedorDropDownList.SelectedValue;
                            _negociacion.IdDeposito = DepositoDropDownList.SelectedValue;
                            _negociacion.CodLinea = LineaDropDownList.SelectedValue;
                            _negociacion.FechaInicioVal = DateTime.Parse(Request.Form[txtFechaInicioModal.UniqueID].ToString());
                            _negociacion.FechaFinVal = DateTime.Parse(Request.Form[txtFechaFinModal.UniqueID].ToString());
                            _negociacion.ValorNegoMaterialEstructura = decimal.Parse(NegociacionMaterialEstTxt.Text);
                            _negociacion.ValorNegoMaterialMaquinaria = decimal.Parse(NegociacionMaterialMaqTxt.Text);                            
                            _negociacion.ValorNegoHHEst = decimal.Parse(NegociacionManoObraEstTxt.Text);
                            _negociacion.ValorNegoHHMaq = decimal.Parse(NegociacionManoObraMaqTxt.Text);
                            _negociacion.PtiNormal = decimal.Parse(PtiNormalTextBox.Text);
                            _negociacion.PtiRap = decimal.Parse(PtiRapTextBox.Text);
                            _negociacion.EsPorcNegoMatEst = EsPorcNegEst.Checked;
                            _negociacion.EsPorcNegoMatMaq = EsPorcNegMaq.Checked;
                            _negociacion.Estado = EstadoModal.Checked;
                            _negociacion.Descripcion = DescripcionModalTxt.Text;

                            _negociacion.CampoIpUsuario = GestionUtil.IpCliente;
                            _negociacion.UsuarioModifica = _negociacion.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                            // _negociacion.Proveedor = !string.IsNullOrEmpty(resultProveedor) ? Serializador.DeSerializeEntity<Proveedor>(resultProveedor) : null;
                            _negociacion.SM_DEPOSITO = !string.IsNullOrEmpty(resultDeposito) ? Serializador.DeSerializeEntity<SM_DEPOSITO>(resultDeposito) : null;
                            _clienteControl.ModificarNegociacionProveedor(Serializador.SerializeEntity(_negociacion));
                            GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Negociacion por Proveedor", ConstantesUtil.mensajeRegistroGuardado);
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

                var clave = new ClaseBasica
                {
                    IdGuid = Guid.Parse(NegociacionesGridView.DataKeys[gr.RowIndex].Value.ToString())
                };
                IdRegistro = clave.IdGuid;
                var result = _clienteControl.ObtenerNegociacionesProveedorPorId(Serializador.SerializeEntity(clave));
                _negociacion = !string.IsNullOrEmpty(result)
                    ? Serializador.DeSerializeEntity<NegociacionProveedor>(result)
                    : null;
                //LineaDropDownList.Items.FindByValue(_negociacion.CodLinea)]
                //;

                TituloModalPanel.Text = ConstantesUtil.TITULO_EDITAR_NEGOCIACION;

                var indexProveedor = ProveedorDropDownList.Items.IndexOf((ProveedorDropDownList.Items.FindByValue(_negociacion.IdProveedor)));
                ProveedorDropDownList.SelectedIndex = indexProveedor;
                var indexDesposito = DepositoDropDownList.Items.IndexOf((DepositoDropDownList.Items.FindByValue(_negociacion.IdDeposito)));
                DepositoDropDownList.SelectedIndex = indexDesposito;
                var indexLinea = LineaDropDownList.Items.IndexOf((LineaDropDownList.Items.FindByValue(_negociacion.CodLinea)));
                LineaDropDownList.SelectedIndex = indexLinea;

                DescripcionModalTxt.Text = _negociacion.Descripcion;
                NegociacionMaterialEstTxt.Text = _negociacion.ValorNegoMaterialEstructura.ToString();
                NegociacionMaterialMaqTxt.Text = _negociacion.ValorNegoMaterialMaquinaria.ToString();
                NegociacionManoObraEstTxt.Text = _negociacion.ValorNegoHHEst.ToString();
                NegociacionManoObraMaqTxt.Text = _negociacion.ValorNegoHHMaq.ToString();
                PtiNormalTextBox.Text = _negociacion.PtiNormal.ToString();
                PtiRapTextBox.Text = _negociacion.PtiRap.ToString();
                txtFechaInicioModal.Text = _negociacion.FechaInicioVal.ToShortDateString();
                txtFechaFinModal.Text = _negociacion.FechaFinVal.ToShortDateString();
                EsPorcNegEst.Checked = true/*_negociacion.EsPorcNegoHHEst*/;
                EsPorcNegMaq.Checked = true/*_negociacion.EsPorcNegoHHMaq*/;
                EstadoModal.Checked = _negociacion.Estado;
                EsNuevoRegistro = false;
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

        private void BindingDatosPaginadosPorLista(List<GET_HISTORIAL_NEG_PROVEEDORES_Result> lista, int totalRegistros)
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

                        result = _clienteControl.ObtenerNegociacionesProveedorHistoricoPaginado(out _totalRegistros, Serializador.SerializeEntity(filtro), PageSizeActual, PageIndexActual);
                    }
                    else
                    {
                        result = _clienteControl.ObtenerNegociacionesProveedorHistoricoPaginado(out _totalRegistros, Serializador.SerializeEntity(filtro), PageSizeActual, PageIndexActual);
                    }

                    var lista = result != null ? Serializador.DeSerializeEntity<List<GET_HISTORIAL_NEG_PROVEEDORES_Result>>(result) : new List<GET_HISTORIAL_NEG_PROVEEDORES_Result>();
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
                NegociacionMaterialEstTxt.Attributes.Add("placeholder", "Rango del 0 al 100");
            }

            else
            {
                NegociacionMaterialEstTxt.Attributes.Add("placeholder", "Ejem. 10,00");
            }
        }


        protected void EsPorcNegMaq_OnCheckedChanged(object sender, EventArgs e)
        {
            if (EsPorcNegMaq.Checked)
            {
                NegociacionMaterialMaqTxt.Attributes.Add("placeholder", "Rango del 0 al 100");
            }

            else
            {
                NegociacionMaterialMaqTxt.Attributes.Add("placeholder", "Ejem. 10,00");
            }
        }
    }





}
