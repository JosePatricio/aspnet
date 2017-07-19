using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.Utilidades;
using Sigeor.GestionControlServiceReference;
using Sigeor.GestionMglServiceReference;

namespace Sigeor.GestionControl
{
    public partial class GestionDaniosWebForm : System.Web.UI.Page
    {
        private ControlServiceClient _clienteControl;
        private GestionMglServiceClient _clienteMgl;
        private List<ClaseBasica> _listaRegistrosVisibles;
        private S_ESTIMATE_DAMAGE_CODE _danio;
        private int _totalRegistros;
        private ClaseBasica _clave;

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


        public string IdDanio
        {
            set { ViewState["Id"] = value; }
            get
            {
                if (ViewState["Id"] != null)
                    return ViewState["Id"].ToString();
                return string.Empty;
            }
        }

        private string ObtenerClave(GridViewRow fila)
        {
            if (_clave == null)
                _clave = new ClaseBasica();
            _clave.IdStringUno = DaniosGridView.DataKeys[fila.RowIndex].Values[0].ToString();
            _clave.IdStringDos = DaniosGridView.DataKeys[fila.RowIndex].Values[1].ToString();
            _clave.IdStringTres = DaniosGridView.DataKeys[fila.RowIndex].Values[2].ToString();

            return Serializador.SerializeEntity(_clave);
        }


        private bool EsNuevoRegistro
        {
            set
            {

                ViewState["IsNuevoDanio"] = value;
            }
            get
            {
                if (ViewState["IsNuevoDanio"] == null)
                    ViewState.Add("IsNuevoDanio", false);

                return bool.Parse(ViewState["IsNuevoDanio"].ToString());
            }
        }

        public GestionDaniosWebForm()
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

                    DaniosGridView.PageSize = _listaRegistrosVisibles.First().IdInt;
                    RegistrosVisiblesDropDownList.DataSource = _listaRegistrosVisibles;
                    RegistrosVisiblesDropDownList.DataValueField = "IdInt";
                    RegistrosVisiblesDropDownList.DataTextField = "Descripcion";
                    RegistrosVisiblesDropDownList.DataBind();
                    RegistrosVisiblesDropDownList.SelectedValue = "20";

                    EstadoCheckBox.Checked = true;
                    EsNuevoRegistro = false;

                    //CargarDataDaniosGridView(EstadoCheckBox.Checked, null);

                    var result = _clienteMgl.ObtenerLineasPorEstado("A");
                    var lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<SM_LINEA>>(result) : new List<SM_LINEA>();

                    if (lista != null)
                    {
                        if (lista.Count == 0)
                            GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "No se encnotraron lineas disponibles");

                        var lineaVacia = new SM_LINEA { COD_LINEA = null, NOM_LINEA = "--- SELECCIONE ---" };
                        lista.Insert(0, lineaVacia);
                    }

                    CargarDatosPorEstadoCoincidencia();
                }
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "Daños", ConstantesUtil.MENSAJE_ERROR_LOAD);
            }
        }

        /// <summary>
        /// Carga el GridView dependiendo sólo del parámetro "Opcion".
        /// Si el "Estado" es Diferente a null se cargan los objetos de acuerdo al Estado.
        /// Si la "Lista" es Diferente a null se cargan los objetos de la lista.
        /// </summary>
        /// <param name="estado">Estado de los Registros a Buscar.</param>
        /// <param name="lista">Lista a cargar en el GridView.</param>
        private void CargarDataDaniosGridView(Boolean? estado, List<S_ESTIMATE_DAMAGE_CODE> lista)
        {
            try
            {

                if (estado != null)
                {
                    var result = _clienteControl.ObtenerDaniosPorEstadoPaginado(out _totalRegistros, estado.Value ? "A" : "I", PageSizeActual, PageIndexActual);
                    lista = null;
                    if (!string.IsNullOrEmpty(result))
                        lista = Serializador.DeSerializeEntity<List<S_ESTIMATE_DAMAGE_CODE>>(result);
                }

                if (lista != null)
                {
                    if (lista.Count > Int16.Parse(RegistrosVisiblesDropDownList.SelectedValue))
                        RegistrosVisiblesDropDownList.Visible = true;
                }
                else
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_INFO, "Daños", ConstantesUtil.mensajeNoSeEncontraronRegistros);

                BindingDatosPaginadosPorLista(lista, _totalRegistros);
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }
        }

        protected void DaniosGridView_RowDataBound(object sender, GridViewRowEventArgs e)
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


        //protected void DaniosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        DaniosGridView.PageIndex = e.NewPageIndex;
        //        CargarDataDaniosGridView(EstadoCheckBox.Checked, null);
        //    }
        //    catch
        //    {
        //        GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, string.Empty, ConstantesUtil.MENSAJE_ERROR_PAGINACION);
        //    }
        //}

        protected void RegistrosVisiblesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                paginaActualTextBox.Text = "1";
                DaniosGridView.PageSize = int.Parse(RegistrosVisiblesDropDownList.SelectedValue);
                CargarDatosPorEstadoCoincidencia();
                //CargarDataDaniosGridView(EstadoCheckBox.Checked, null);
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PAGE_SIZE);
            }
        }

        private void CargarCombos(bool esEditable)
        {
            try
            {
                LineaDropDownList.Items.Clear();
                TipoDanioDropDownList.Items.Clear();
                CodigoModalTxt.Attributes.Add("ReadOnly", esEditable.ToString());
                if (esEditable)
                {

                    CodigoModalTxt.Attributes.Remove("ReadOnly");
                    var result = _clienteMgl.ObtenerLineasPorEstado("A");

                    if (!string.IsNullOrEmpty(result))
                    {
                        var lista = Serializador.DeSerializeEntity<List<SM_LINEA>>(result);
                        var lineaVacia = new SM_LINEA { COD_LINEA = null, NOM_LINEA = "--- SELECCIONE ---" };
                        lista.Insert(0, lineaVacia);
                        LineaDropDownList.DataSource = lista;
                        LineaDropDownList.DataTextField = "NOM_LINEA";
                        LineaDropDownList.DataValueField = "COD_LINEA";
                        LineaDropDownList.DataBind();
                    }
                    else
                    {
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "No se encnotraron lineas disponibles");
                    }

                    var resultTipoDanio = _clienteControl.CargarTipoDanios();

                    if (!string.IsNullOrEmpty(resultTipoDanio))
                    {
                        var listaTipoDanios = Serializador.DeSerializeEntity<List<ClaseBasica>>(resultTipoDanio);
                        listaTipoDanios.Insert(0, new ClaseBasica { IdString = string.Empty, Nombre = "-- SELECCIONE --" });
                        TipoDanioDropDownList.DataSource = listaTipoDanios;
                        TipoDanioDropDownList.DataTextField = "Nombre";
                        TipoDanioDropDownList.DataValueField = "IdString";
                        TipoDanioDropDownList.DataBind();
                    }
                    else
                    {
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo cargar los tipo de daños disponibles");
                    }

                }
                else
                {

                    var danioDeserializado = Serializador.DeSerializeEntity<ClaseBasica>(IdDanio);
                    var idLineaSerializado = Serializador.SerializeEntity(new ClaseBasica { IdStringUno = danioDeserializado.IdStringDos });
                    var resultLinea = _clienteMgl.ObtenerLineaPorCodigo(idLineaSerializado);
                    if (!string.IsNullOrEmpty(resultLinea))
                    {
                        var linea = Serializador.DeSerializeEntity<SM_LINEA>(resultLinea);

                        ListItem item = new ListItem { Text = linea.NOM_LINEA, Value = linea.COD_LINEA, Selected = true };

                        LineaDropDownList.Items.Add(item);
                        //LineaDropDownList.Items.Add(new ListItem(linea.NOM_LINEA, linea.COD_LINEA));
                        //LineaDropDownList.ToolTip = linea.DESC_LINEA;
                        LineaDropDownList.DataBind();
                    }
                    else
                    {
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo cargar la línea de este registro");
                    }

                    var resultTipoDanio = _clienteControl.CargarTipoDanios();

                    if (!string.IsNullOrEmpty(resultTipoDanio))
                    {
                        var listaTipoDanios = Serializador.DeSerializeEntity<List<ClaseBasica>>(resultTipoDanio);
                        var tipoDanio = listaTipoDanios.Find(ent => ent.IdString != null && ent.IdString.Equals(_danio.TIPO_DANIO));
                        TipoDanioDropDownList.Items.Add(new ListItem(tipoDanio.Nombre, tipoDanio.IdString));
                        //TipoDanioDropDownList.ToolTip = tipoDanio.Nombre;
                        TipoDanioDropDownList.DataBind();
                    }
                    else
                    {
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo cargar el tipo de daño de este registro");
                    }
                }
                //LineaDropDownList.Enabled = habilitarCamposPks;
                //TipoDanioDropDownList.Enabled = habilitarCamposPks;
                ////////////////////////////////////////////////////
                /////TODO: FIN MODIFICAR PARA EL TIPO DE DANIO
                ////////////////////////////////////////////////////
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_COMBOS);
            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = sender as LinkButton;
                GridViewRow gr = linkButton.NamingContainer as GridViewRow;

                IdDanio = ObtenerClave(gr);

                _danio = null;
                var result = _clienteControl.ObtenerDanioPorCodigo(IdDanio);
                if (!string.IsNullOrEmpty(result))
                    _danio = Serializador.DeSerializeEntity<S_ESTIMATE_DAMAGE_CODE>(result);

                CodigoModalTxt.Text = _danio.COD_DAMAGE;
                TipoReparacionTextBox.Text = _danio.TIPO_REPARACION;
                DescripcionModalTxt.Text = _danio.DESCRIP;
                EstadoModal.Checked = _danio.ESTADO.Equals("A");

                CargarCombos(true);
                LineaDropDownList.SelectedIndex = LineaDropDownList.Items.IndexOf(LineaDropDownList.Items.FindByValue(_danio.COD_LINEA));
                TipoDanioDropDownList.SelectedIndex = TipoDanioDropDownList.Items.IndexOf(TipoDanioDropDownList.Items.FindByValue(_danio.TIPO_DANIO));

                EsNuevoRegistro = false;
                TituloModalPanel.Text = ConstantesUtil.TITULO_EDITAR_DANIO;
                GestionUtil.MostrarModal(this);

            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_ABRIR_DIALOGO_EDICION);
            }
        }


        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {

                var validacionCampos = false;

                if (string.IsNullOrEmpty(CodigoModalTxt.Text))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Codigo", ConstantesUtil.mensajeCampoObligatorio);
                    validacionCampos = true;
                }

                if (string.IsNullOrEmpty(LineaDropDownList.SelectedValue))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Línea", ConstantesUtil.mensajeCampoObligatorio);
                    validacionCampos = true;
                }

                if (string.IsNullOrEmpty(TipoDanioDropDownList.SelectedValue))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Tipo de Daño", ConstantesUtil.mensajeCampoObligatorio);
                    validacionCampos = true;
                }

                if (string.IsNullOrEmpty(TipoReparacionTextBox.Text))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Tipo de Reparación", ConstantesUtil.mensajeCampoObligatorio);
                    validacionCampos = true;
                }


                if (!string.IsNullOrEmpty(CantidadTxt.Text.Trim()) && !ValidacionesUtil.ValidarNumeros(CantidadTxt.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Cantidad H/H", ConstantesUtil.mensajeFormatoNumericoIncorrecto);
                    CantidadTxt.Text = string.Empty;
                    validacionCampos = true;
                }

                if (string.IsNullOrEmpty(DescripcionModalTxt.Text))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Descripción", ConstantesUtil.mensajeCampoObligatorio);
                    validacionCampos = true;
                }
                if (validacionCampos)
                {
                    return;
                }

                if (EsNuevoRegistro)//Es nuevo registro
                {
                    _danio = new S_ESTIMATE_DAMAGE_CODE
                    {
                        COD_DAMAGE = CodigoModalTxt.Text.ToUpper(),
                        COD_LINEA = LineaDropDownList.SelectedValue,
                        TIPO_DANIO = TipoDanioDropDownList.SelectedValue,
                        TIPO_REPARACION = TipoReparacionTextBox.Text,
                        DESCRIP = DescripcionModalTxt.Text.ToUpper(),
                        USUARIO_CREA = GestionUtil.UsuarioSesion.Cedula,
                        CANTHH = (short?)short.Parse(CantidadTxt.Text),
                        EMCCode = EMCCodETxt.Text ?? null,
                        ESTADO = EstadoModal.Checked ? "A" : "I",
                        //ESMIGRADO = false
                    };
                    var clavePrimaria = new ClaseBasica
                    {
                        IdStringUno = _danio.COD_DAMAGE,
                        IdStringDos = _danio.COD_LINEA,
                        IdStringTres = _danio.TIPO_DANIO
                    };

                    var busqueda = _clienteControl.ObtenerDanioPorCodigo(Serializador.SerializeEntity(clavePrimaria));

                    if (busqueda == null)
                    {
                        _danio.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                        _danio.CampoIpUsuario = GestionUtil.IpCliente;
                        _clienteControl.InsertarDanio(Serializador.SerializeEntity(_danio));
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Daño", ConstantesUtil.mensajeRegistroGuardado);
                        GestionUtil.OcultarModal(this);
                        CargarDatosPorEstadoCoincidencia();
                    }
                    else
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "El daño ingresado ya se encuentra registrado");
                }
                else//Se debe editar el registro
                {

                    var result = _clienteControl.ObtenerDanioPorCodigo(IdDanio);
                    if (!string.IsNullOrEmpty(result))
                        _danio = Serializador.DeSerializeEntity<S_ESTIMATE_DAMAGE_CODE>(result);

                    var clavePrimaria = new ClaseBasica
                    {
                        IdStringUno = _danio.COD_DAMAGE,
                        IdStringDos = _danio.COD_LINEA,
                        IdStringTres = _danio.TIPO_DANIO
                    };

                    var busqueda = _clienteControl.ObtenerDanioPorCodigo(Serializador.SerializeEntity(clavePrimaria));

                    if (busqueda != null)
                    {
                        _danio = Serializador.DeSerializeEntity<S_ESTIMATE_DAMAGE_CODE>(busqueda);
                        _danio.COD_DAMAGE = CodigoModalTxt.Text.ToUpper();
                        _danio.COD_LINEA = LineaDropDownList.SelectedValue;
                        _danio.TIPO_DANIO = TipoDanioDropDownList.SelectedValue;
                        _danio.TIPO_REPARACION = TipoReparacionTextBox.Text;
                        _danio.DESCRIP = DescripcionModalTxt.Text.ToUpper();
                        _danio.USUARIO_MOD = GestionUtil.UsuarioSesion.Cedula;
                        _danio.CANTHH = !string.IsNullOrEmpty(CantidadTxt.Text) && ValidacionesUtil.ValidarNumeros(CantidadTxt.Text.Trim()) ? ((short?)short.Parse(CantidadTxt.Text)) : null;
                        _danio.EMCCode = EMCCodETxt.Text ?? null;
                        _danio.ESTADO = EstadoModal.Checked ? "A" : "I";

                        _danio.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                        _danio.CampoIpUsuario = GestionUtil.IpCliente;
                        _clienteControl.ModificarDanio(Serializador.SerializeEntity(_danio));
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Daños", ConstantesUtil.mensajeRegistroGuardado);
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
                CodigoModalTxt.Text = string.Empty;
                DescripcionModalTxt.Text = string.Empty;
                TipoReparacionTextBox.Text = string.Empty;
                EstadoModal.Checked = false;
                CargarCombos(true);
                EstadoModal.Checked = true;
                GestionUtil.MostrarModal(this);
                TituloModalPanel.Text = ConstantesUtil.TITULO_NUEVO_DANIO;
                EsNuevoRegistro = true;
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_ABRIR_DIALOGO_NUEVO);
            }

        }


        protected void EstadoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                paginaActualTextBox.Text = "1";
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

                var clave = ObtenerClave(gr);

                var result = _clienteControl.ObtenerDanioPorCodigo(clave);
                if (!string.IsNullOrEmpty(result))
                    _danio = Serializador.DeSerializeEntity<S_ESTIMATE_DAMAGE_CODE>(result);
                _danio.ESTADO = _danio.ESTADO.Equals("A") ? "I" : "A";
                _danio.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                _danio.CampoIpUsuario = GestionUtil.IpCliente;

                _clienteControl.ModificarDanio(Serializador.SerializeEntity(_danio));

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
                var parametro = new ClaseBasica
                {
                    Descripcion = BuscarTextBox.Text.Trim(),
                    EstadoString = EstadoCheckBox.Checked ? "A" : "I",
                    IpUsuario = GestionUtil.IpCliente,
                    CedulaUsuario = GestionUtil.UsuarioSesion.Cedula
                };
                _clienteControl.ModificarDanioMasivo(Serializador.SerializeEntity(parametro));
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

        ////////////////////////////////////////////////
        /// TODO: PRUEBA DEL NUEVO PAGINADOR
        /// ///////////////////////////////////////////


        private void BindingDatosPaginadosPorLista(List<S_ESTIMATE_DAMAGE_CODE> lista, int totalRegistros)
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

                DaniosGridView.DataSource = lista;
                DaniosGridView.DataBind();
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
                    List<S_ESTIMATE_DAMAGE_CODE> lista = null;

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
                        result = _clienteControl.ObtenerDaniosPorCoincidenciaPaginado(out _totalRegistros, BuscarTextBox.Text,
                            EstadoCheckBox.Checked ? "A" : "I", PageSizeActual,
                            PageIndexActual);
                    }
                    else
                    {
                        result = _clienteControl.ObtenerDaniosPorEstadoPaginado(out _totalRegistros,
                            EstadoCheckBox.Checked ? "A" : "I", PageSizeActual,
                            PageIndexActual);
                    }

                    lista = result != null ? Serializador.DeSerializeEntity<List<S_ESTIMATE_DAMAGE_CODE>>(result) : new List<S_ESTIMATE_DAMAGE_CODE>();
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
                string result = null;
                List<S_ESTIMATE_DAMAGE_CODE> lista = null;

                if (!string.IsNullOrEmpty(BuscarTextBox.Text.Trim()))
                {
                    result = _clienteControl.ObtenerDaniosPorCoincidenciaPaginado(out _totalRegistros, BuscarTextBox.Text, EstadoCheckBox.Checked ? "A" : "I", PageSizeActual, PageIndexActual);
                    lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<S_ESTIMATE_DAMAGE_CODE>>(result) : new List<S_ESTIMATE_DAMAGE_CODE>();
                }
                else
                {
                    result = _clienteControl.ObtenerDaniosPorEstadoPaginado(out _totalRegistros, EstadoCheckBox.Checked ? "A" : "I", PageSizeActual, PageIndexActual);
                    lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<S_ESTIMATE_DAMAGE_CODE>>(result) : new List<S_ESTIMATE_DAMAGE_CODE>();
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
    }
}
