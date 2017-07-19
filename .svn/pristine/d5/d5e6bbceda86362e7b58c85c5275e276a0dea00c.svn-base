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
    public partial class GestionReparacionesWebForm : System.Web.UI.Page
    {
        private readonly ControlServiceClient _clienteControl;
        private GestionMglServiceClient _clienteMgl;
        private List<DanioReparacion> _listaReparaciones;
        private List<ClaseBasica> _listaRegistrosVisibles;
        private S_ESTIMATE_REPAIR_CODE _reparacion;

        private int _totalRegistros;

        private ClaseBasica _clave;

        public string IdReparacion
        {
            set { Session["Id"] = value; }
            get
            {
                if (Session["Id"] != null)
                    return Session["Id"].ToString();
                return string.Empty;
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

        private int PageIndexActual
        {
            set
            {
                if (value > 0 && value <= int.Parse(totalPaginasLbl.Text))
                {
                    paginaActualTextBox.Text = GestionUtil.VerificarPaginaActual(value.ToString());
                }

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


        private ClaseBasica IdRegistro
        {
            set { ViewState["IdRegistro"] = value; }
            get
            {
                if (ViewState["IdRegistro"] == null)
                    ViewState["IdRegistro"] = new ClaseBasica();
                return ViewState["IdRegistro"] as ClaseBasica;
            }
        }




        private bool EsNuevoRegistro
        {
            set
            {

                ViewState["IsNuevoRep"] = value;
            }
            get
            {
                if (ViewState["IsNuevoRep"] == null)
                    ViewState["IsNuevoRep"] = false;

                return (bool)ViewState["IsNuevoRep"];
            }
        }

        public GestionReparacionesWebForm()
        {
            try
            {
                _clienteControl = new ControlServiceClient();
                _clienteMgl = new GestionMglServiceClient();
                _listaRegistrosVisibles = GestionUtil.CargarNumeroRegistrosGridView();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // ReSharper disable once FunctionComplexityOverflow
        private void InicializarComponentes()
        {
            try
            {


                var resultLineas = _clienteMgl.ObtenerLineasPorEstado("A");
                var listaLineas = !string.IsNullOrEmpty(resultLineas) ? Serializador.DeSerializeEntity<List<SM_LINEA>>(resultLineas) : new List<SM_LINEA>();

                if (listaLineas != null && listaLineas.Count > 0)
                    listaLineas.Insert(0, new SM_LINEA { COD_LINEA = string.Empty, NOM_LINEA = "--  Seleccione --" });
                ddlLinea.DataValueField = "COD_LINEA";
                ddlLinea.DataTextField = "NOM_LINEA";
                ddlLinea.DataSource = listaLineas;
                ddlLinea.DataBind();


                var resultTipoDanios = _clienteControl.CargarTipoDanios();
                var listaTipoDanios = !string.IsNullOrEmpty(resultTipoDanios) ? Serializador.DeSerializeEntity<List<ClaseBasica>>(resultTipoDanios) : new List<ClaseBasica>();

                if (listaTipoDanios != null && listaTipoDanios.Count > 0)
                    listaTipoDanios.Insert(0, new ClaseBasica { IdString = string.Empty, Nombre = "--  Seleccione --" });




                var listaReparacion = new List<S_ESTIMATE_REPAIR_CODE>
                {
                    new S_ESTIMATE_REPAIR_CODE {COD_REPAIR = string.Empty, DESCRIP = "-- Seleccione --"}
                };


                var resultComponentes = _clienteControl.ObtenerComponentesPorEstado("A");
                var listaComponentes = !string.IsNullOrEmpty(resultComponentes) ? Serializador.DeSerializeEntity<List<S_ESTIMATE_COMPONENT_CODE>>(resultComponentes) : new List<S_ESTIMATE_COMPONENT_CODE>();
                if (listaComponentes != null && listaComponentes.Count > 0)
                    listaComponentes.Insert(0,
                        new S_ESTIMATE_COMPONENT_CODE
                        {
                            COD_TIPOCOMPO = string.Empty,
                            DESCRIPCION = "--  Seleccione --"
                        });




                EstadoCheckBox.Checked = true;


                var listaDanios = new List<S_ESTIMATE_DAMAGE_CODE>
                {
                    new S_ESTIMATE_DAMAGE_CODE {COD_DAMAGE = string.Empty, DESCRIP = "--  Seleccione --"}
                };


            }
            catch (Exception ex)
            {
                string error = ex.Message;
                throw;
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
                    ReparacionesGridView.PageSize = _listaRegistrosVisibles.First().IdInt;
                    List<S_ESTIMATE_REPAIR_CODE> listareparaciones = null;
                    string result = _clienteControl.ObtenerReparaciones();
                    listareparaciones = result != null ? Serializador.DeSerializeEntity<List<S_ESTIMATE_REPAIR_CODE>>(result) : null;

                    ReparacionesGridView.DataSource = listareparaciones.ToList();
                    ReparacionesGridView.DataBind();


                    RegistrosVisiblesDropDownList.DataSource = _listaRegistrosVisibles;
                    RegistrosVisiblesDropDownList.DataValueField = "IdInt";
                    RegistrosVisiblesDropDownList.DataTextField = "Descripcion";
                    RegistrosVisiblesDropDownList.DataBind();
                    RegistrosVisiblesDropDownList.SelectedValue = "20";



                    EstadoCheckBox.Checked = true;
                    EsNuevoRegistro = false;
                    EvaluarHabilitarCampos();

                    CargarDatosPorEstadoCoincidencia();
                    //  InicializarComponentes();             
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "Reparación", ConstantesUtil.MENSAJE_ERROR_LOAD);
            }
        }

        protected void ReparacionesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
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
                ReparacionesGridView.PageSize = int.Parse(RegistrosVisiblesDropDownList.SelectedValue);
                CargarDatosPorEstadoCoincidencia();
                //CargarDataDaniosReparacionesGridView(EstadoCheckBox.Checked, null);
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PAGE_SIZE);
            }
        }


        private void CargarProductos()
        {


        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = sender as LinkButton;
                GridViewRow gr = linkButton.NamingContainer as GridViewRow;

                IdReparacion = ObtenerClave(gr);

                _reparacion = null;
                var result = _clienteControl.ObtenerReparacionPorClave(IdReparacion);
                if (!string.IsNullOrEmpty(result))
                    _reparacion = Serializador.DeSerializeEntity<S_ESTIMATE_REPAIR_CODE>(result);



                txtdescripcion.Text = _reparacion.DESCRIP;
                EstadoReparacion.Checked = _reparacion.ESTADO.Equals("A");
                txtcodigo.Text = _reparacion.COD_REPAIR;
                ddlLinea.SelectedIndex = ddlLinea.Items.IndexOf(ddlLinea.Items.FindByValue(_reparacion.COD_LINEA));





                CargarCombos(true);

                EsNuevoRegistro = false;
                TituloModalPanel.Text = ConstantesUtil.TITULO_EDITAR_DANIO;
                GestionUtil.MostrarModal(this);

            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_ABRIR_DIALOGO_EDICION);
            }
        }


        private void CargarCombos(bool esEditable)
        {
            try
            {
                ddlLinea.Items.Clear();
                // TipoDanioDropDownList.Items.Clear();
                BuscarTextBox.Attributes.Add("ReadOnly", esEditable.ToString());
                if (esEditable)
                {

                    BuscarTextBox.Attributes.Remove("ReadOnly");



                    var resultLineas = _clienteMgl.ObtenerLineasPorEstado("A");
                    var listaLineas = !string.IsNullOrEmpty(resultLineas) ? Serializador.DeSerializeEntity<List<SM_LINEA>>(resultLineas) : null;

                    if (listaLineas != null && listaLineas.Count > 0)
                        listaLineas.Insert(0, new SM_LINEA { COD_LINEA = string.Empty, NOM_LINEA = "--  Seleccione --" });
                    ddlLinea.DataValueField = "COD_LINEA";
                    ddlLinea.DataTextField = "NOM_LINEA";
                    ddlLinea.DataSource = listaLineas;
                    ddlLinea.DataBind();





                    var resultTipoDanio = _clienteControl.CargarTipoDanios();

                    if (!string.IsNullOrEmpty(resultTipoDanio))
                    {
                        var listaTipoDanios = Serializador.DeSerializeEntity<List<ClaseBasica>>(resultTipoDanio);
                        listaTipoDanios.Insert(0, new ClaseBasica { IdString = string.Empty, Nombre = "-- SELECCIONE --" });
                    }
                    else
                    {
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo cargar los tipo de daños disponibles");
                    }

                }
                else
                {

                    var danioDeserializado = Serializador.DeSerializeEntity<ClaseBasica>(IdReparacion);
                    var idLineaSerializado = Serializador.SerializeEntity(new ClaseBasica { IdStringUno = danioDeserializado.IdStringDos });
                    var resultLinea = _clienteMgl.ObtenerLineaPorCodigo(idLineaSerializado);
                    if (!string.IsNullOrEmpty(resultLinea))
                    {
                        var linea = Serializador.DeSerializeEntity<SM_LINEA>(resultLinea);

                        ListItem item = new ListItem { Text = linea.NOM_LINEA, Value = linea.COD_LINEA, Selected = true };

                        ddlLinea.Items.Add(item);
                        //LineaDropDownList.Items.Add(new ListItem(linea.NOM_LINEA, linea.COD_LINEA));
                        //LineaDropDownList.ToolTip = linea.DESC_LINEA;
                        ddlLinea.DataBind();
                    }
                    else
                    {
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo cargar la línea de este registro");
                    }

                    var resultTipoDanio = _clienteControl.CargarTipoDanios();

                    if (!string.IsNullOrEmpty(resultTipoDanio))
                    {
                        var listaTipoDanios = Serializador.DeSerializeEntity<List<ClaseBasica>>(resultTipoDanio);
                        //  var tipoDanio = listaTipoDanios.Find(ent => ent.IdString != null && ent.IdString.Equals(_reparacion.));
                        /*  TipoDanioDropDownList.Items.Add(new ListItem(tipoDanio.Nombre, tipoDanio.IdString));
                          //TipoDanioDropDownList.ToolTip = tipoDanio.Nombre;
                          TipoDanioDropDownList.DataBind();*/
                    }
                    else
                    {
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo cargar el tipo de daño de este registro");
                    }
                }

            }
            catch (Exception ex)
            {
                string errror = ex.Message;
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_COMBOS);
            }
        }





        private string ObtenerClave(GridViewRow fila)
        {
            if (_clave == null)
                _clave = new ClaseBasica();
            _clave.IdStringUno = ReparacionesGridView.DataKeys[fila.RowIndex].Values[0].ToString();
            _clave.IdStringDos = ReparacionesGridView.DataKeys[fila.RowIndex].Values[1].ToString();

            return Serializador.SerializeEntity(_clave);
        }


        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (EsNuevoRegistro)//Es nuevo registro
                {
                    S_ESTIMATE_REPAIR_CODE obj = new S_ESTIMATE_REPAIR_CODE
                    {
                        COD_LINEA = ddlLinea.SelectedValue,
                        COD_REPAIR = txtcodigo.Text,
                        DESCRIP = txtdescripcion.Text,
                        ESTADO = (EstadoReparacion.Checked == false) ? "A" : "I",
                        USUARIO_CREA = GestionUtil.UsuarioSesion.Cedula,
                        //  USUARIO_CREA = "0603950718",
                        FECHA_CREACION = DateTime.Parse(DateTime.Today.ToString(CultureInfo.InvariantCulture)),
                        CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula,
                        CampoIpUsuario = GestionUtil.IpCliente

                    };

                    _clienteControl.InsertarReparacion(Serializador.SerializeEntity(obj));
                    GestionUtil.OcultarModal(this);
                    CargarDatosPorEstadoCoincidencia();

                }
                else
                {
                    var result = _clienteControl.ObtenerReparacionPorClave(IdReparacion);
                    if (!string.IsNullOrEmpty(result))
                        _reparacion = Serializador.DeSerializeEntity<S_ESTIMATE_REPAIR_CODE>(result);

                    var clavePrimaria = new ClaseBasica
                    {
                        IdStringUno = _reparacion.COD_REPAIR,
                        IdStringDos = _reparacion.COD_LINEA

                    };

                    var busqueda = _clienteControl.ObtenerReparacionPorClave(Serializador.SerializeEntity(clavePrimaria));

                    if (busqueda != null)
                    {
                        _reparacion = Serializador.DeSerializeEntity<S_ESTIMATE_REPAIR_CODE>(busqueda);
                        _reparacion.COD_REPAIR = txtcodigo.Text.ToUpper();
                        _reparacion.COD_LINEA = ddlLinea.SelectedValue;

                        _reparacion.DESCRIP = txtdescripcion.Text.ToUpper();
                        _reparacion.USUARIO_MOD = GestionUtil.UsuarioSesion.Cedula;
                        //  _reparacion.EMCCode = EMCCodETxt.Text ?? null;
                        _reparacion.ESTADO = EstadoReparacion.Checked ? "A" : "I";

                        _reparacion.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                        _reparacion.CampoIpUsuario = GestionUtil.IpCliente;
                        _clienteControl.ModificarReparacion(Serializador.SerializeEntity(_reparacion));
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Reparación", ConstantesUtil.mensajeRegistroGuardado);
                        GestionUtil.OcultarModal(this);
                        CargarDatosPorEstadoCoincidencia();
                    }
                    else
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "El daño ingresado ya se encuentra registrado");

                }


            }




            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_GUARDAR);
            }
        }


        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                TituloModalPanel.Text = "NUEVA REPARACIÓN";
                InicializarComponentes();

                EsNuevoRegistro = true;
                txtcodigo.Text = txtdescripcion.Text = "";
                GestionUtil.MostrarModal(this);


            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ex.Message);
            }

        }



        protected void EstadoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDatosPorEstadoCoincidencia();
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_BUSQUEDA_POR_ESTADO);

            }
        }

        protected void EstadoCheckBoxGridView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                CheckBox checkboxEstado = sender as CheckBox;
                GridViewRow gr = (GridViewRow)checkboxEstado.NamingContainer;

                IdReparacion = ObtenerClave(gr);

                _reparacion = null;
                var result = _clienteControl.ObtenerReparacionPorClave(IdReparacion);
                if (!string.IsNullOrEmpty(result))
                    _reparacion = Serializador.DeSerializeEntity<S_ESTIMATE_REPAIR_CODE>(result);

                _reparacion.ESTADO = _reparacion.ESTADO.Equals("A") ? "I" : "A";
                _reparacion.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                _reparacion.CampoIpUsuario = GestionUtil.IpCliente;

                _clienteControl.ModificarReparacion(Serializador.SerializeEntity(_reparacion));

                //CargarDataDaniosGridView(EstadoCheckBox.Checked, null);
                BuscarTextBox.Text = string.Empty;
                CargarDatosPorEstadoCoincidencia();
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_EDICION_POR_ESTADO_GRIDVIEW);
            }
        }

        protected void EstadoCabeceraGridView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var clave = new ClaseBasica
                {
                    Descripcion = BuscarTextBox.Text.Trim(),
                    Estado = EstadoCheckBox.Checked,
                    CedulaUsuario = GestionUtil.UsuarioSesion.Cedula,
                    IpUsuario = GestionUtil.IpCliente
                };
                _clienteControl.ModificarReparacionMasivo(Serializador.SerializeEntity(clave));
                CargarDatosPorEstadoCoincidencia();

            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_EDICION_POR_ESTADO_CABECERA);
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

        private void EvaluarHabilitarCampos()
        {


        }

        private void CargarReparacionesExistentes()
        {
            try
            {
                EvaluarHabilitarCampos();

            }
            catch (Exception ex)
            {

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ex.Message);
            }
        }

        protected void SeleccionarCheckBox_OnCheckedChanged(object sender, EventArgs e)
        {

        }

        protected void TipoDanioDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDanioExistente();
        }

        private void CargarDanioExistente()
        {
            try
            {

            }
            catch (Exception)
            {

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo cargar los daños existentes");
            }
        }



        protected void LineaDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDanioExistente();
            CargarReparacionesExistentes();
        }

        protected void ProductosCheckBox_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo cargar los productos");
            }
        }


        protected void ReparacionDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EvaluarHabilitarCampos();

            }
            catch (Exception)
            {

                throw;
            }
        }

        ////////////////////////////////////////////////
        /// TODO: PRUEBA DEL NUEVO PAGINADOR
        /// ///////////////////////////////////////////


        private void BindingDatosPaginadosPorLista(List<S_ESTIMATE_REPAIR_CODE> lista, int totalRegistros)
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

                ReparacionesGridView.DataSource = lista;
                ReparacionesGridView.DataBind();
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
                    List<S_ESTIMATE_REPAIR_CODE> lista = null;

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

                    if (!string.IsNullOrEmpty(BuscarTextBox.Text))
                    {
                        result = _clienteControl.ObtenerReparacionesPorCoincidenciaPaginado(out _totalRegistros, BuscarTextBox.Text, EstadoCheckBox.Checked ? "A" : "I", PageSizeActual, PageIndexActual);
                    }
                    else
                    {
                        result = _clienteControl.ObtenerReparacionesPorCoincidenciaPaginado(out _totalRegistros, BuscarTextBox.Text, EstadoCheckBox.Checked ? "A" : "I", PageSizeActual, PageIndexActual);
                    }

                    var aux = _totalRegistros / PageSizeActual;

                    if ((aux > 0 && totalPaginas == 0) || (aux == 0 && _totalRegistros > 0))
                        aux = 1;

                    if ((_totalRegistros % PageSizeActual > 0) && (_totalRegistros > PageSizeActual))
                        aux++;

                    totalPaginas = (int)Math.Round(new decimal(aux), 0, MidpointRounding.AwayFromZero);
                    totalPaginasLbl.Text = totalPaginas.ToString();

                    lista = result != null ? Serializador.DeSerializeEntity<List<S_ESTIMATE_REPAIR_CODE>>(result) : null;

                    ReparacionesGridView.DataSource = lista;
                    ReparacionesGridView.DataBind();
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
                string result = null;
                List<S_ESTIMATE_REPAIR_CODE> lista = null;



                if (!string.IsNullOrEmpty(BuscarTextBox.Text.Trim()))
                {
                    result = _clienteControl.ObtenerReparacionesPorCoincidenciaPaginado(out _totalRegistros, BuscarTextBox.Text, EstadoCheckBox.Checked ? "A" : "I", PageSizeActual, PageIndexActual);
                    lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<S_ESTIMATE_REPAIR_CODE>>(result) : null;
                }
                else
                {
                    result = _clienteControl.ObtenerReparacionesPorCoincidenciaPaginado(out _totalRegistros, BuscarTextBox.Text, EstadoCheckBox.Checked ? "A" : "I", PageSizeActual, PageIndexActual);
                    lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<S_ESTIMATE_REPAIR_CODE>>(result) : null;
                }

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

        protected void BuscarButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                totalPaginasLbl.Text = "1";
                CargarDatosPorEstadoCoincidencia();
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_BUSQUEDA_POR_COINCIDENCIAS);
            }
        }


        protected void principalForm_OnPreRender(object sender, EventArgs e)
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
