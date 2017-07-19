using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Sigeor.Utilidades;
using Negocio.Seguridad;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.GestionAutenticacionServiceReference;
using Sigeor.GestionConfiguracionServiceReference;
using Negocio.Configuracion;

namespace Sigeor.Configuracion
{
    public partial class GestionUsuariosWebForm : System.Web.UI.Page
    {
        private ConfiguracionServiceClient _clienteConfiguracion;
        private AutenticacionServiceClient _clienteAutenticacion;
        private int _totalRegistros;
        private List<ClaseBasica> _listaRegistrosVisibles;
        private List<CoordenadasEkey> _listaCoordenadasEkey;
        private List<Perfil> _listaPerfiles;
        private Usuario usuario;
        private EKey _nuevoEkey;
        private UsuarioPerfil _usuarioPerfil;



        private bool EsNuevoRegistro
        {
            set
            {
                ViewState["IsNuevoUsu"] = value;
            }
            get
            {
                return bool.Parse(ViewState["IsNuevoUsu"].ToString());
            }
        }

        private List<Perfil> ListaPerfilesGridView
        {
            set
            {
                ViewState["seccionGrid"] = value;
            }
            get
            {
                if (ViewState["seccionGrid"] == null)
                    ViewState["seccionGrid"] = new List<Perfil>();
                return (List<Perfil>)ViewState["seccionGrid"];

            }

        }
        private string cedulaRegistro
        {
            set
            {
                ViewState["IdUsuario"] = value;
            }
            get
            {
                return ViewState["IdUsuario"].ToString();
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
        public GestionUsuariosWebForm()
        {
            try
            {
                _clienteConfiguracion = new ConfiguracionServiceClient();
                _clienteAutenticacion = new AutenticacionServiceClient();
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
                    inicializar();

                }
            }
            catch (Exception es)
            {
                String error = es.Message + "   " + es.StackTrace;
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "Usuario", ConstantesUtil.MENSAJE_ERROR_LOAD);
            }
        }




        void inicializar()
        {
            //lblCabecera.Text = ViewState["TituloMenu"].ToString();
            lblCabecera.Text = GestionUtil.tituloPagina(this.Request.Url.LocalPath);
            UsuarioGridView.PageSize = _listaRegistrosVisibles.First().IdInt;
            RegistrosVisiblesDropDownList.DataSource = _listaRegistrosVisibles;
            RegistrosVisiblesDropDownList.DataValueField = "IdInt";
            RegistrosVisiblesDropDownList.DataTextField = "Descripcion";
            RegistrosVisiblesDropDownList.DataBind();
            RegistrosVisiblesDropDownList.SelectedValue = "20";
            EstadoCheckBox.Checked = true;
            EsNuevoRegistro = false;
            //CargarDataUsuarioGridView(EstadoCheckBox.Checked, null);
            CargarDatosPorEstadoCoincidencia();
            var result = _clienteConfiguracion.ObtenerPerfilesPorEstado(true);
            _listaPerfiles = !string.IsNullOrEmpty(result)
                ? Serializador.DeSerializeEntity<List<Perfil>>(result)
                : new List<Perfil>();

            gridviewPrueba.DataSource = _listaPerfiles;
            gridviewPrueba.DataBind();


            cargarPerfilesTodos();

            var item = new Perfil();
            item.Id = Guid.Empty;
            item.Descripcion = "-- SELECCIONE --";
            _listaPerfiles.Insert(0, item);

        }


        void cargarPerfilesTodos()
        {
            var result = _clienteConfiguracion.ObtenerPerfilesPorEstado(true);
            _listaPerfiles = !string.IsNullOrEmpty(result)
             ? Serializador.DeSerializeEntity<List<Perfil>>(result)
             : new List<Perfil>();
            gridviewPrueba.DataSource = _listaPerfiles;
            gridviewPrueba.DataBind();
        }



        private void CargarDatosPorEstadoCoincidencia()
        {
            try
            {
                string result = null;
                List<Usuario> lista = null;

                if (!string.IsNullOrEmpty(BuscarTextBox.Text.Trim()))
                {
                    result = _clienteConfiguracion.ObtenerUsuarioPorCoincidenciaPaginado(out _totalRegistros, BuscarTextBox.Text, EstadoCheckBox.Checked, PageSizeActual, PageIndexActual);
                    lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<Usuario>>(result) : new List<Usuario>();
                }
                else
                {


                    result = _clienteConfiguracion.ObtenerUsuarioPorEstadoPaginado(out _totalRegistros, EstadoCheckBox.Checked, PageSizeActual, PageIndexActual);
                    lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<Usuario>>(result) : new List<Usuario>();
                }

                BindingDatosPaginadosPorLista(lista, _totalRegistros);
            }
            catch (Exception)
            {

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }
        }
       
        protected void UsuarioGridView_RowDataBound(object sender, GridViewRowEventArgs e)
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
                UsuarioGridView.PageSize = PageSizeActual;
                CargarDatosPorEstadoCoincidencia();
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PAGE_SIZE);
            }
        }
        private void llenarPerfilesPorCedula(string cedula)
        {
            try
            {
                string result = _clienteConfiguracion.ObtenerPerfilPorCedula(cedula);
                List<Negocio.Configuracion.UsuarioPerfilNegocio.UsuarioPerfilModelo> lista = null;
                lista = !string.IsNullOrEmpty(result)
                    ? Serializador.DeSerializeEntity<List<UsuarioPerfilNegocio.UsuarioPerfilModelo>>(result)
                    : new  List<UsuarioPerfilNegocio.UsuarioPerfilModelo>();
                gridviewPrueba.DataSource = lista;
                gridviewPrueba.DataBind();
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }
        }
        protected void PerfilesGridViewModal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                //   GridViewPerfiles.PageIndex = e.NewPageIndex;
                //  llenarPerfilesPorCedula();
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PAGINACION);
            }
        }
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            try
            {

                CedulaModalTxt.Enabled = false;
                LinkButton linkButton = sender as LinkButton;
                GridViewRow gr = (GridViewRow)linkButton.NamingContainer;
                cedulaRegistro = UsuarioGridView.DataKeys[gr.RowIndex].Value.ToString();
                usuario = Serializador.DeSerializeEntity<Usuario>(_clienteConfiguracion.ObtenerUsuarioPorCedula(cedulaRegistro));
                CedulaModalTxt.Text = usuario.Cedula;
                NombreModalTxt.Text = usuario.Nombre;
                ApellidoModalTxt.Text = usuario.Apellido;
                DireccionModalTxt.Text = usuario.Direccion;
                CelularModalTxt.Text = usuario.Celular;
                CorreoModalTxt.Text = usuario.Email;
                EstadoModal.Checked = usuario.Estado.Value;
              
                llenarPerfilesPorCedula(usuario.Cedula);
                EsNuevoRegistro = false;
                TituloModalPanel.Text = ConstantesUtil.TITULO_EDITAR_USUARIO;
                GestionUtil.MostrarModal(this);

            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_ABRIR_DIALOGO_EDICION);
            }
        }
        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {

            try
            {
                GestionUtil.MostrarModal(this);
                CedulaModalTxt.Enabled = true;
                CedulaModalTxt.Text = string.Empty;
                CedulaModalTxt.Text = string.Empty;
                NombreModalTxt.Text = string.Empty;
                ApellidoModalTxt.Text = string.Empty;
                DireccionModalTxt.Text = string.Empty;
                CelularModalTxt.Text = string.Empty;
                CorreoModalTxt.Text = string.Empty;
                EstadoModal.Checked = true;
                TituloModalPanel.Text = ConstantesUtil.TITULO_NUEVO_USUARIO;
                cargarPerfilesTodos();
                EsNuevoRegistro = true;
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

                bool isEmpty = false;

                if (string.IsNullOrEmpty(CedulaModalTxt.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Cedula", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }
                if (ValidacionesUtil.validacionCedulaCelular(CedulaModalTxt.Text) == false)
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "", ConstantesUtil.mensajeCedulaErronea);
                    isEmpty = true;
                }

                if (string.IsNullOrEmpty(NombreModalTxt.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Nombre", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }
                if (ValidacionesUtil.validacionStrings(NombreModalTxt.Text) == false)
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "", ConstantesUtil.mensajeNombreErroneo);
                    isEmpty = true;
                }
                if (string.IsNullOrEmpty(ApellidoModalTxt.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Apellido", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }
                if (ValidacionesUtil.validacionStrings(ApellidoModalTxt.Text) == false)
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "", ConstantesUtil.mensajeApellidoErroneo);
                    isEmpty = true;
                }
                if (string.IsNullOrEmpty(DireccionModalTxt.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Dirección", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }
                if (string.IsNullOrEmpty(CelularModalTxt.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Celular", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }
                if (ValidacionesUtil.validacionCedulaCelular(CelularModalTxt.Text) == false)
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "", ConstantesUtil.mensajeClularErroneo);
                    isEmpty = true;
                }
                if (string.IsNullOrEmpty(CorreoModalTxt.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Correo Electrónico", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }
                if (ValidacionesUtil.validacionCorreo(CorreoModalTxt.Text) == false)
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "", ConstantesUtil.mensajeCorreoErroneo);
                    isEmpty = true;
                }
                if (isEmpty) return;

                if (EsNuevoRegistro)//Es nuevo registro
                {

                    var result1 = _clienteConfiguracion.ObtenerUsuarioPorCedula(CedulaModalTxt.Text);

                    if (result1 != null)
                    {
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "", ConstantesUtil.mensajeCedulaErronea);
                        isEmpty = true;
                    }
                    if (_clienteConfiguracion.ObtenerUsuarioPorCorreo(CorreoModalTxt.Text) != null)
                    {
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "", ConstantesUtil.mensajeCorreoErroneo);
                        isEmpty = true;
                    }

                    if (isEmpty) return;

                    usuario = new Usuario();
                    usuario.Cedula = CedulaModalTxt.Text;
                    usuario.Nombre = NombreModalTxt.Text;
                    usuario.Apellido = ApellidoModalTxt.Text;
                    usuario.Direccion = DireccionModalTxt.Text;
                    usuario.Celular = CelularModalTxt.Text;
                    usuario.Email = CorreoModalTxt.Text;
                    usuario.CampoIpUsuario = GestionUtil.IpCliente;
                    usuario.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                    //  _usuario.CampoCedulaUsuario = "0603950719";
                    usuario.NombreUsuario = usuario.Cedula;
                    usuario.OlvidoContrasenia = true;
                    string claveGenerada = GestionUtil.GenerarClave(8);
                    usuario.Contrasenia = MetodosEncriptacion.EncriptarMD5(claveGenerada);
                    usuario.Estado = EstadoModal.Checked;
                    _nuevoEkey = new EKey
                    {
                        Id = Guid.NewGuid(),
                        CedulaUsuario = CedulaModalTxt.Text,
                        // CedulaUsuario = "0603950719",
                        Fecha_Generacion = DateTime.Today,
                        Estado = true
                    };
                    _listaCoordenadasEkey = new List<CoordenadasEkey>();
                    if (!string.IsNullOrWhiteSpace(usuario.Cedula) &&
                        !string.IsNullOrWhiteSpace(usuario.Nombre))
                    {
                        if (ValidacionPerfileleccion())
                        {
                            _clienteConfiguracion.InsertarUsuario(Serializador.SerializeEntity(usuario));
                            var result = _clienteAutenticacion.GenerarCoordenadasEkey(Serializador.SerializeEntity(_nuevoEkey));
                            if (!string.IsNullOrEmpty(result))
                                _listaCoordenadasEkey = Serializador.DeSerializeEntity<List<CoordenadasEkey>>(result);

                            InsertarPerfilUsuario(CedulaModalTxt.Text);


                            GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Usuario", ConstantesUtil.mensajeRegistroGuardado);
                            // _listaCoordenadasEkey = _clienteAutenticacion.ObtenerCoordenadasEkeyPorIdEkey(_nuevoEkey.Id);
                            GestionUtil.EnviarEmail(CorreoModalTxt.Text, claveGenerada, usuario.Nombre, _listaCoordenadasEkey);
                            GestionUtil.OcultarModal(this);
                            CargarDatosPorEstadoCoincidencia();
                        }
                        else
                        {
                            GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "", ConstantesUtil.mensajeEliminarPerfil);
                        }

                    }

                }
                else//Se debe editar el registro
                {
                    if (!EsNuevoRegistro)
                    {

                        usuario = Serializador.DeSerializeEntity<Usuario>(_clienteConfiguracion.ObtenerUsuarioPorCedula(cedulaRegistro));


                        usuario.Nombre = NombreModalTxt.Text;
                        usuario.Apellido = ApellidoModalTxt.Text;
                        usuario.Direccion = DireccionModalTxt.Text;
                        usuario.Celular = CelularModalTxt.Text;
                        usuario.Email = CorreoModalTxt.Text;
                        usuario.Estado = EstadoModal.Checked;

                        usuario.CampoIpUsuario = GestionUtil.IpCliente;
                        usuario.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;


                        _clienteConfiguracion.ModificarUsuario(Serializador.SerializeEntity(usuario));
                        ActualizarPerfilUsuario(usuario.Cedula);

                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Usuario", ConstantesUtil.mensajeRegistroModificado);
                        GestionUtil.OcultarModal(this);
                        CargarDatosPorEstadoCoincidencia();




                    }
                }


            }
            catch (Exception es)
            {
                String error = es.Message + "    " + es.StackTrace;
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_GUARDAR);
            }


        }




        public void InsertarPerfilUsuario(string cedula)
        {
            int k = 0;
            foreach (GridViewRow row in gridviewPrueba.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkestado") as CheckBox);
                    if (chkRow.Checked)
                    {
                        _usuarioPerfil = new UsuarioPerfil();
                        _usuarioPerfil.IdPerfil = (Guid)gridviewPrueba.DataKeys[k].Values["Id"]; ;
                        _usuarioPerfil.Cedula = cedula;
                        _usuarioPerfil.Fecha = DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd");
                        _usuarioPerfil.Estado = true;
                        _clienteConfiguracion.InsertarUsuarioPerfil(Serializador.SerializeEntity(_usuarioPerfil));
                    }
                    k++;
                }
            }

        }


        public void ActualizarPerfilUsuario(string cedula)
        {
            int k = 0;
            foreach (GridViewRow row in gridviewPrueba.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkestado") as CheckBox);
                    if (chkRow.Checked)
                    {
                        UsuarioPerfil up = new UsuarioPerfil();
                        up.Cedula = cedula;
                        up.IdPerfil = (Guid)gridviewPrueba.DataKeys[k].Values["Id"];
                        up.Fecha = DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd");
                        up.Estado = true;
                        _clienteConfiguracion.InsertarUsuarioPerfil(Serializador.SerializeEntity(up));
                    }
                    if (!chkRow.Checked)
                    {
                        UsuarioPerfil up = new UsuarioPerfil();
                        up.Cedula = cedula;
                        up.IdPerfil = (Guid)gridviewPrueba.DataKeys[k].Values["Id"];
                        up.Fecha = DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd");
                        up.Estado = false;
                        _clienteConfiguracion.EliminarUsuarioPerfil(Serializador.SerializeEntity(up));
                    }
                    k++;
                }
            }

        }



        bool ValidacionPerfileleccion()
        {
            int seleccionados = 0;
            foreach (GridViewRow row in gridviewPrueba.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkestado") as CheckBox);
                    if (chkRow.Checked)
                    {
                        seleccionados++;
                    }
                }
            }
            if (seleccionados > 0)
            {
                return true;
            }
            return false;
        }




        protected void CancelButton_Click(object sender, EventArgs e)
        {
            GestionUtil.MostrarModal(this);
            EsNuevoRegistro = false;

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
                cedulaRegistro = UsuarioGridView.DataKeys[gr.RowIndex].Value.ToString();
                usuario = Serializador.DeSerializeEntity<Usuario>(_clienteConfiguracion.ObtenerUsuarioPorCedula(cedulaRegistro));
                usuario.Estado = !usuario.Estado;
                usuario.CampoIpUsuario = GestionUtil.IpCliente;
                usuario.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                _clienteConfiguracion.ModificarUsuario(Serializador.SerializeEntity(usuario));
                CargarDatosPorEstadoCoincidencia();
                BuscarTextBox.Text = string.Empty;
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_EDICION_POR_ESTADO_GRIDVIEW);
            }
        }
        protected void OnClickNavegacion(object sender, EventArgs e)
        {

            try
            {

                GestionUtil.Redireccionar(ConstantesUtil.URL_MENU_CONFIGURACION);
            }

            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty,
                    ConstantesUtil.MENSAJE_ERROR_NAVEGACION_MENU);
            }
        }
        protected void linkContrasena_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = sender as LinkButton;
                GridViewRow gr = (GridViewRow)linkButton.NamingContainer;
                cedulaRegistro = UsuarioGridView.DataKeys[gr.RowIndex].Value.ToString();
                usuario =
                    Serializador.DeSerializeEntity<Usuario>(
                        _clienteConfiguracion.ObtenerUsuarioPorCedula(cedulaRegistro));
                string claveGenerada = GestionUtil.GenerarClave(8);
                usuario.Contrasenia = MetodosEncriptacion.EncriptarMD5(claveGenerada);
                usuario.OlvidoContrasenia = true;
                usuario.CampoIpUsuario = GestionUtil.IpCliente;
                usuario.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                _clienteConfiguracion.ModificarUsuario(Serializador.SerializeEntity(usuario));
                GestionUtil.EnviarEmail(usuario.Email, claveGenerada, usuario.Cedula, usuario.Nombre);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_INFO, string.Empty,
                    ConstantesUtil.mensajeClaveGenerada);
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty,
                    ConstantesUtil.mensajeContraseniaNoGenerada);
            }
        }
        protected void linkEkey_Click(object sender, EventArgs e)
        {
            try
            {

                var linkButton = sender as LinkButton;
                var gr = (GridViewRow)linkButton.NamingContainer;
                cedulaRegistro = UsuarioGridView.DataKeys[gr.RowIndex].Value.ToString();
                usuario = Serializador.DeSerializeEntity<Usuario>(_clienteConfiguracion.ObtenerUsuarioPorCedula(cedulaRegistro));
                usuario.CampoIpUsuario = GestionUtil.IpCliente;
                usuario.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                var result = _clienteAutenticacion.ObtenerEkeyPorCedulaUsuario(usuario.Cedula);
                _nuevoEkey = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<EKey>(result) : null;

                if (_nuevoEkey != null)
                    result = _clienteAutenticacion.GenerarCoordenadasEkey(Serializador.SerializeEntity(_nuevoEkey));
                if (!string.IsNullOrEmpty(result))
                    _listaCoordenadasEkey = Serializador.DeSerializeEntity<List<CoordenadasEkey>>(result);
                GestionUtil.EnviarEmail(usuario.Email, usuario.Cedula, usuario.Nombre, _listaCoordenadasEkey);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_INFO, string.Empty, ConstantesUtil.mensajeEKeyGenerado);
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty,
                    ConstantesUtil.mensajeEkeyNoGenerado);
            }
        }
        protected void lnkEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                LinkButton linkButton = sender as LinkButton;
                GridViewRow gr = (GridViewRow)linkButton.NamingContainer;
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty,
                    ConstantesUtil.mensajeErrorEliminarRegistro);
            }
        }

        protected void EstadoCabeceraGridView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _clienteConfiguracion.ModificarUsuarioMasivamente(BuscarTextBox.Text, EstadoCheckBox.Checked);
                CargarDatosPorEstadoCoincidencia();
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_EDICION_POR_ESTADO_CABECERA);
            }
        }

        private void BindingDatosPaginadosPorLista(List<Usuario> lista, int totalRegistros)
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

                UsuarioGridView.DataSource = lista;
                UsuarioGridView.DataBind();
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
                    List<Usuario> lista = null;

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
                        result = _clienteConfiguracion.ObtenerUsuarioPorCoincidenciaPaginado(out _totalRegistros, BuscarTextBox.Text,
                            EstadoCheckBox.Checked, PageSizeActual,
                            PageIndexActual);
                    }
                    else
                    {
                        result = _clienteConfiguracion.ObtenerUsuarioPorEstadoPaginado(out _totalRegistros,
                            EstadoCheckBox.Checked, PageSizeActual,
                            PageIndexActual);
                    }

                    lista = result != null ? Serializador.DeSerializeEntity<List<Usuario>>(result) : null;
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
    }

}