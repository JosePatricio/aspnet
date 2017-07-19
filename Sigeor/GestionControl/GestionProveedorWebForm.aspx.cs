using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Utilidades;

using PersistenciaSigeor;
using Sigeor.Utilidades;
using Sigeor.GestionConfiguracionServiceReference;
using Sigeor.GestionControlServiceReference;
using Sigeor.GestionMglServiceReference;

namespace Sigeor.GestionControl
{
    public partial class GestionProveedorWebForm : System.Web.UI.Page
    {
        private GestionMglServiceClient _clienteMgl;
        private ControlServiceClient _clienteControl;


        private List<ClaseBasica> _listaRegistrosVisibles;
        private S_OCRD _proveedor;
        private int _totalRegistros;



        private string IdRegistro
        {
            set
            {
                ViewState["IdGestProv"] = value;
            }
            get
            {
                return ViewState["IdGestProv"].ToString();
            }
        }

        private bool EsNuevoRegistro
        {
            set
            {

                ViewState["IsNuevoProv"] = value;
            }
            get
            {
                if (ViewState["IsNuevoProv"] == null)
                    ViewState.Add("IsNuevoProv", false);

                return bool.Parse(ViewState["IsNuevoProv"].ToString());
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

        public GestionProveedorWebForm()
        {
            try
            {
                _clienteMgl = new GestionMglServiceClient();
                _clienteControl = new ControlServiceClient();
                _listaRegistrosVisibles = GestionUtil.CargarNumeroRegistrosGridView();

            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_VARIABLES);
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
                    inicializar();



                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "Eor's por Tránsito", ConstantesUtil.MENSAJE_ERROR_LOAD);
            }
        }



        void inicializar()
        {

            lblCabecera.Text = GestionUtil.tituloPagina(this.Request.Url.LocalPath);
            

            ProveedoresGridView.PageSize = _listaRegistrosVisibles.First().IdInt;
            RegistrosVisiblesDropDownList.DataSource = _listaRegistrosVisibles;
            RegistrosVisiblesDropDownList.DataValueField = "IdInt";
            RegistrosVisiblesDropDownList.DataTextField = "Descripcion";
            RegistrosVisiblesDropDownList.DataBind();
            RegistrosVisiblesDropDownList.SelectedValue = "20";
            EstadoCheckBox.Checked = true;
            EsNuevoRegistro = false;


            var result = _clienteControl.ObtenerInspectoresPorEstado("A");

            var lista = !string.IsNullOrEmpty(result)
                ? Serializador.DeSerializeEntity<List<SM_INSPECTOR>>(result) : new List<SM_INSPECTOR>();

            lista.Insert(0, new SM_INSPECTOR { COD_INSPECTOR = string.Empty, NOMBRECOMPLETO = "ELIJA UN INSPECTOR" });

            ddlInspectores.DataSource = lista;
            ddlInspectores.DataValueField = "COD_INSPECTOR";
            ddlInspectores.DataTextField = "NOMBRECOMPLETO";
            ddlInspectores.DataBind();




            //CargarDataProveedoresGridView(EstadoCheckBox.Checked, null);
            CargarDatosPorEstadoCoincidencia();

        }







        protected void ProveedoresGridView_RowDataBound(object sender, GridViewRowEventArgs e)
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
                ProveedoresGridView.PageSize = PageSizeActual;
                CargarDatosPorEstadoCoincidencia();
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PAGE_SIZE);
            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = sender as LinkButton;
                GridViewRow gr = (GridViewRow)linkButton.NamingContainer;
                IdRegistro = ProveedoresGridView.DataKeys[gr.RowIndex].Value.ToString();

                _proveedor = Serializador.DeSerializeEntity<S_OCRD>(_clienteMgl.ObtenerProveedorPorId(IdRegistro));
                txtcodigo.Text = _proveedor.CardCode;
                txtNombre.Text = _proveedor.CardName;
                txtrepresentante.Text = _proveedor.CntctPrsn;
                txtDireccion.Text = _proveedor.CardName;
                EstadoModal.Checked = !_proveedor.State1.Equals("0");
                txttelefono.Text = _proveedor.Phone1;
                // txtfax.Text = _proveedor.Fax;
                //txtmaxdias.Text = _proveedor.Maximo_Dias.ToString();
                //txtmindias.Text = _proveedor.Minimo_Dias.ToString();


                var indexDesposito = ddlInspectores.Items.IndexOf((ddlInspectores.Items.FindByValue(_proveedor.COD_INSPECTOR)));
                ddlInspectores.SelectedIndex = indexDesposito;

                EsNuevoRegistro = false;
                TituloModalPanel.Text = ConstantesUtil.TITULO_EDITAR_PROVEEDOR;
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
                bool isEmpty = false;

                if (string.IsNullOrEmpty(txtcodigo.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Código", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }

                if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Descripción", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }

                if (string.IsNullOrEmpty(txtrepresentante.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Representante", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }
                if (string.IsNullOrEmpty(txttelefono.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Teléfono", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }

                //if (string.IsNullOrEmpty(txtfax.Text.Trim()))
                //{
                //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Fax", ConstantesUtil.mensajeCampoObligatorio);
                //    isEmpty = true;
                //}

                //if (string.IsNullOrEmpty(txtmaxdias.Text.Trim()))
                //{
                //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Máximo días", ConstantesUtil.mensajeCampoObligatorio);
                //    isEmpty = true;
                //}

                //if (string.IsNullOrEmpty(txtmindias.Text.Trim()))
                //{
                //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Mínimo días", ConstantesUtil.mensajeCampoObligatorio);
                //    isEmpty = true;
                //}
                if (isEmpty) return;

                if (EsNuevoRegistro)//Es nuevo registro
                {
                    var result = _clienteMgl.ObtenerProveedorPorId(txtcodigo.Text);
                    _proveedor = !string.IsNullOrEmpty(result)
                        ? Serializador.DeSerializeEntity<S_OCRD>(result)
                        : new S_OCRD();

                    if (result != null)
                    {
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "", ConstantesUtil.mensajeCodigoDuplicado);
                        isEmpty = true;
                    }
                    if (isEmpty) return;


                    _proveedor = new S_OCRD()
                    {
                        CardCode = txtcodigo.Text,
                        CardName = txtNombre.Text,
                        State1 = (EstadoModal.Checked ? "1" : "0"),
                        CntctPrsn = txtrepresentante.Text,
                        Address = txtDireccion.Text,
                        Phone1 = txttelefono.Text,
                        //Fax = txtfax.Text,
                        //Maximo_Dias= Int32.Parse(txtmaxdias.Text.Trim()),
                        //Minimo_Dias=Int32.Parse(txtmindias.Text.Trim()),
                        //FechaCrea=DateTime.Now,
                        U_TIPO_PROVEEDOR = string.Empty,
                        U_TIPO_RUC = string.Empty,
                        U_TIPO_ID = string.Empty,
                        COD_INSPECTOR = ddlInspectores.SelectedValue,
                        CampoIpUsuario = GestionUtil.IpCliente,
                        CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula
                    };



                    if (!string.IsNullOrWhiteSpace(_proveedor.CardCode) &&
                        !string.IsNullOrWhiteSpace(_proveedor.CardName))
                    {
                        _clienteMgl.InsertarProveedor(Serializador.SerializeEntity(_proveedor));
                        GestionUtil.OcultarModal(this);
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Eor por Maquinaria", ConstantesUtil.mensajeRegistroGuardado);
                        CargarDatosPorEstadoCoincidencia();
                    }


                }
                else//Se debe editar el registro
                {
                    if (!EsNuevoRegistro)
                    {
                        var result = _clienteMgl.ObtenerProveedorPorId(IdRegistro);
                        _proveedor = !string.IsNullOrEmpty(result)
                            ? Serializador.DeSerializeEntity<S_OCRD>(result)
                            : new S_OCRD();
                        _proveedor.CardCode = txtcodigo.Text;
                        _proveedor.CardName = txtNombre.Text;
                        _proveedor.CntctPrsn = txtrepresentante.Text;
                        _proveedor.Address = txtDireccion.Text;
                        _proveedor.Phone1 = txttelefono.Text;
                        //  _proveedor.Fax = txtfax.Text;
                        _proveedor.CampoIpUsuario = GestionUtil.IpCliente;
                        _proveedor.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                        //_proveedor.Maximo_Dias = Int32.Parse(txtmaxdias.Text.Trim());
                        //_proveedor.Minimo_Dias = Int32.Parse(txtmindias.Text.Trim());
                        //_proveedor.FechaModifica = DateTime.Now;
                        // _proveedor.UsuarioCrea = GestionUtil.ObtenerUsuarioSesion.Cedula;
                        //   _proveedor.UsuarioCrea = "0603950719";
                        
                        _proveedor.State1 = (EstadoModal.Checked ? "1" : "0");
                        _proveedor.COD_INSPECTOR = ddlInspectores.SelectedValue;
                        _clienteMgl.ModificarProveedor(Serializador.SerializeEntity(_proveedor));

                        //   _clienteConfiguracion.ModificarMasivamentePerfilEstructura("",true);
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Eor por Maquinaria", ConstantesUtil.mensajeRegistroModificado);
                        GestionUtil.OcultarModal(this);
                        CargarDatosPorEstadoCoincidencia();
                    }

                }
                GestionUtil.OcultarModal(this);

            }
            catch (Exception es)
            {
                string men = es.Message + "   " + es.StackTrace;
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_GUARDAR);
            }
        }







        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            try
            {

                txtcodigo.Enabled = true;
                txtNombre.Text = string.Empty;
                txtrepresentante.Text = string.Empty;
                EstadoModal.Checked = true;




                if (ddlInspectores.Items.Count > 0)
                    ddlInspectores.SelectedIndex = 0;


                TituloModalPanel.Text = ConstantesUtil.TITULO_NUEVO_PROVEEDOR;
                GestionUtil.MostrarModal(this);
                EsNuevoRegistro = true;
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_INFO, string.Empty, ConstantesUtil.MENSAJE_ERROR_ABRIR_DIALOGO_NUEVO);
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
                IdRegistro = ProveedoresGridView.DataKeys[gr.RowIndex].Value.ToString();

                var result = _clienteMgl.ObtenerProveedorPorId(IdRegistro);
                if (!string.IsNullOrEmpty(result))
                    _proveedor = Serializador.DeSerializeEntity<S_OCRD>(result);
                _proveedor.State1 = int.Parse(_proveedor.State1) > 0 ? "0" : "1";
                // _proveedor.UsuarioCrea = GestionUtil.ObtenerUsuarioesion.Cedula;
                _proveedor.CampoIpUsuario = GestionUtil.IpCliente;
                _proveedor.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;

                _clienteMgl.ModificarProveedor(Serializador.SerializeEntity(_proveedor));
                CargarDatosPorEstadoCoincidencia();
                BuscarTextBox.Text = string.Empty;
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
                    Descripcion = BuscarTextBox.Text,
                    EstadoString = EstadoCheckBox.Checked ? "A" : "I",
                    CedulaUsuario = GestionUtil.UsuarioSesion.Cedula,
                    IpUsuario = GestionUtil.UsuarioSesion.CampoIpUsuario
                };

                _clienteMgl.ModificarProveedorEstadoMasivamente(Serializador.SerializeEntity(parametro));

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


        private void BindingDatosPaginadosPorLista(List<S_OCRD> lista, int totalRegistros)
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

                ProveedoresGridView.DataSource = lista;
                ProveedoresGridView.DataBind();
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA + ex);
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
                    List<S_OCRD> lista = null;

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
                        result = _clienteMgl.ObtenerProveedoresPorCoincidenciaPaginado(out _totalRegistros, BuscarTextBox.Text,
                            EstadoCheckBox.Checked, PageSizeActual,
                            PageIndexActual);
                    }
                    else
                    {
                        result = _clienteMgl.ObtenerProveedoresPorEstadoPaginado(out _totalRegistros,
                            EstadoCheckBox.Checked, PageSizeActual,
                            PageIndexActual);
                    }

                    lista = result != null ? Serializador.DeSerializeEntity<List<S_OCRD>>(result) : new List<S_OCRD>();
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
                List<S_OCRD> lista = null;

                if (!string.IsNullOrEmpty(BuscarTextBox.Text.Trim()))
                {
                    result = _clienteMgl.ObtenerProveedoresPorCoincidenciaPaginado(out _totalRegistros, BuscarTextBox.Text, EstadoCheckBox.Checked, PageSizeActual, PageIndexActual);
                    lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<S_OCRD>>(result) : new List<S_OCRD>();
                }
                else
                {
                    result = _clienteMgl.ObtenerProveedoresPorEstadoPaginado(out _totalRegistros, EstadoCheckBox.Checked, PageSizeActual, PageIndexActual);
                    lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<S_OCRD>>(result) : new List<S_OCRD>();
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

        protected void ddlpagina_SelectedIndexChanged(object sender, EventArgs e)
        {

            //      txturlinicio.Text = new ConfiguracionServiceClient().ObtenerUrlPorId(ddlpagina.SelectedValue.ToString());
        }


    }
}
