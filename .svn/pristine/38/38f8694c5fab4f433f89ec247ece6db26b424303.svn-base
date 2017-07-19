using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.Utilidades;
using Sigeor.GestionConfiguracionServiceReference;

namespace Sigeor.Configuracion
{
    public partial class GestionPerfilesWebForm : System.Web.UI.Page
    {
        private ConfiguracionServiceClient _clienteConfiguracion;

        private List<ClaseBasica> _listaRegistrosVisibles;
        private Perfil _perfil;
        private int _totalRegistros;


        private Guid IdRegistro
        {
            set
            {
                ViewState["IdGestPerf"] = value;
            }
            get
            {
                return Guid.Parse(ViewState["IdGestPerf"].ToString());
            }
        }

        private bool EsNuevoRegistro
        {
            set
            {

                ViewState["IsNuevoPerf"] = value;
            }
            get
            {
                if (ViewState["IsNuevoPerf"] == null)
                    ViewState.Add("IsNuevoPerf", false);

                return bool.Parse(ViewState["IsNuevoPerf"].ToString());
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

        public GestionPerfilesWebForm()
        {
            try
            {
                _clienteConfiguracion = new ConfiguracionServiceClient();
                _listaRegistrosVisibles = GestionUtil.CargarNumeroRegistrosGridView();

            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_VARIABLES);
            }
        }
        ConfiguracionServiceClient servicio = new ConfiguracionServiceClient();


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
                    inicializar();
                }
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "Perfiles", ConstantesUtil.MENSAJE_ERROR_LOAD);
            }
        }



        void inicializar()
        {
            GestionUtil.ControlAccesoPerfil(GestionUtil.UsuarioSesion.Cedula, this.Request.Url.LocalPath);
            List<Estructura> listaEstructura = null;
            String estados = servicio.ObtenerEstructura(null);
            listaEstructura = estados != null ? Serializador.DeSerializeEntity<List<Estructura>>(estados) : new List<Estructura>();
                       
            gridviewPrueba.DataSource = listaEstructura;
            gridviewPrueba.DataBind();

            lblCabecera.Text = GestionUtil.tituloPagina(this.Request.Url.LocalPath);

            PerfilesGridView.PageSize = _listaRegistrosVisibles.First().IdInt;
            RegistrosVisiblesDropDownList.DataSource = _listaRegistrosVisibles;
            RegistrosVisiblesDropDownList.DataValueField = "IdInt";
            RegistrosVisiblesDropDownList.DataTextField = "Descripcion";
            RegistrosVisiblesDropDownList.DataBind();
            RegistrosVisiblesDropDownList.SelectedValue = "20";
            EstadoCheckBox.Checked = true;
            EsNuevoRegistro = false;
            //CargarDataPerfilesGridView(EstadoCheckBox.Checked, null);
            CargarDatosPorEstadoCoincidencia();

        }




        void llenarEstructuraPorPerfil(string idperfil)
        {
            string result = _clienteConfiguracion.ObtenerPerfilEstructuraPorPerfil(idperfil);
            List<Negocio.Configuracion.EstructuraPerfilNegocio.EstructuraPerfilModelo> lista = null;
            lista = !string.IsNullOrEmpty(result)
                ? Serializador.DeSerializeEntity<List<Negocio.Configuracion.EstructuraPerfilNegocio.EstructuraPerfilModelo>>(result)
                : null;
            gridviewPrueba.DataSource = lista;
            gridviewPrueba.DataBind();
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

        protected void RegistrosVisiblesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                paginaActualTextBox.Text = "1";
                PerfilesGridView.PageSize = PageSizeActual;
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
                IdRegistro = Guid.Parse(PerfilesGridView.DataKeys[gr.RowIndex].Value.ToString());
                _perfil = Serializador.DeSerializeEntity<Perfil>(_clienteConfiguracion.ObtenerPerfilesPorId(IdRegistro));
                CodigoModalTxt.Text = _perfil.Codigo;
                DescripcionModalTxt.Text = _perfil.Descripcion;
                EstadoModal.Checked = _perfil.Estado;
                EsNuevoRegistro = false;
                TituloModalPanel.Text = ConstantesUtil.TITULO_EDITAR_PERFIl;
                llenarEstructuraPorPerfil(IdRegistro.ToString());

                string swe = IdRegistro.ToString();

                List<Estructura> listaEstructura = null;
                String estados = servicio.ObtenerEstructura(IdRegistro.ToString());
                listaEstructura = estados != null ? Serializador.DeSerializeEntity<List<Estructura>>(estados) : new List<Estructura>();



                ddlpagina.DataSource = listaEstructura;
                ddlpagina.DataTextField = "Descripcion";
                ddlpagina.DataValueField = "id";
                ddlpagina.SelectedIndex = ddlpagina.Items.IndexOf(ddlpagina.Items.FindByValue(listaEstructura.Find(ent=>ent.Url == _perfil.PaginaInicio).Id.ToString()));
                ddlpagina.DataBind();


                txturlinicio.Text = new ConfiguracionServiceClient().ObtenerUrlPorId(ddlpagina.SelectedValue.ToString());


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

                if (string.IsNullOrEmpty(CodigoModalTxt.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Código", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }

                if (string.IsNullOrEmpty(DescripcionModalTxt.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Descripción", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }
                if (isEmpty) return;
                if (EsNuevoRegistro)//Es nuevo registro
                {
                    var result = _clienteConfiguracion.ObtenerPerfilesPorCodigo(CodigoModalTxt.Text);
                    _perfil = !string.IsNullOrEmpty(result)
                        ? Serializador.DeSerializeEntity<Perfil>(result)
                        : null;

                    if (result != null)
                    {
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "", ConstantesUtil.mensajeCodigoDuplicado);
                        isEmpty = true;
                    }
                    if (isEmpty) return;


                    _perfil = new Perfil()
                    {
                        Id = Guid.NewGuid(),
                        Codigo = CodigoModalTxt.Text,
                        Descripcion = DescripcionModalTxt.Text,
                        CampoIpUsuario = GestionUtil.IpCliente,
                        CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula,
                        //   CampoCedulaUsuario = "0603950718",
                        Estado = EstadoModal.Checked,
                        PaginaInicio = txturlinicio.Text
                    };

                    String var = _perfil.Id.ToString();


                    if (!string.IsNullOrWhiteSpace(_perfil.Codigo) &&
                        !string.IsNullOrWhiteSpace(_perfil.Descripcion))
                    {

                        if (ValidacionPerfileleccion())
                        {

                            _clienteConfiguracion.InsertarPerfil(Serializador.SerializeEntity(_perfil));

                            InsertarPerfilEstructura(_perfil.Id);
                            GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Perfil", ConstantesUtil.mensajeRegistroGuardado);
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
                        var result = _clienteConfiguracion.ObtenerPerfilesPorId(IdRegistro);
                        _perfil = !string.IsNullOrEmpty(result)
                            ? Serializador.DeSerializeEntity<Perfil>(result)
                            : null;
                        _perfil.Codigo = CodigoModalTxt.Text;
                        _perfil.Descripcion = DescripcionModalTxt.Text;
                        _perfil.PaginaInicio = txturlinicio.Text;
                        _perfil.CampoIpUsuario = GestionUtil.IpCliente;
                        _perfil.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                        _perfil.Estado = EstadoModal.Checked;
                        _clienteConfiguracion.ModificarPerfil(Serializador.SerializeEntity(_perfil));
                        ActualizarPerfilEstructura(_perfil.Id);
                        //   _clienteConfiguracion.ModificarMasivamentePerfilEstructura("",true);                        
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Perfil", ConstantesUtil.mensajeRegistroModificado);
                        GestionUtil.OcultarModal(this);
                        CargarDatosPorEstadoCoincidencia();
                        
                    }

                }                
            }
            catch (Exception es)
            {
                string men = es.Message + "   " + es.StackTrace;
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_GUARDAR);
            }
        }


        public void InsertarPerfilEstructura(Guid id)
        {
            int k = 0;
            foreach (GridViewRow row in gridviewPrueba.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkestado") as CheckBox);
                    if (chkRow.Checked)
                    {
                        EstructuraPerfil ep = new EstructuraPerfil();
                        ep.IdPerfil = id;
                        ep.IdEstructura = (Guid)gridviewPrueba.DataKeys[k].Values["Id"];
                        ep.Fecha = DateTime.Now;
                        ep.Estado = true;
                        _clienteConfiguracion.InsertarEstructuraPerfil(Serializador.SerializeEntity(ep));
                    }

                    k++;
                }
            }

        }



        public void ActualizarPerfilEstructura(Guid id)
        {
            int k = 0;
            foreach (GridViewRow row in gridviewPrueba.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkestado") as CheckBox);
                    if (chkRow.Checked)
                    {
                        EstructuraPerfil ep = new EstructuraPerfil();
                        ep.IdPerfil = id;
                        ep.IdEstructura = (Guid)gridviewPrueba.DataKeys[k].Values["Id"];
                        ep.Fecha = DateTime.Now;
                        ep.Estado = true;
                        _clienteConfiguracion.InsertarEstructuraPerfil(Serializador.SerializeEntity(ep));
                    }
                    if (!chkRow.Checked)
                    {
                        EstructuraPerfil ep = new EstructuraPerfil();
                        ep.IdPerfil = id;
                        ep.IdEstructura = (Guid)gridviewPrueba.DataKeys[k].Values["Id"];
                        ep.Fecha = DateTime.Now;
                        ep.Estado = false;
                        _clienteConfiguracion.EliminarEstructuraPerfil(Serializador.SerializeEntity(ep));
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



        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<Estructura> listaEstructura = null;
                String estados = servicio.ObtenerEstructura(null);
                listaEstructura = estados != null ? Serializador.DeSerializeEntity<List<Estructura>>(estados) : new List<Estructura>();
                ddlpagina.DataSource = listaEstructura;
                ddlpagina.DataTextField = "Descripcion";
                ddlpagina.DataValueField = "id";
                ddlpagina.DataBind();


                txturlinicio.Text = new ConfiguracionServiceClient().ObtenerUrlPorId(ddlpagina.SelectedValue.ToString());
                CodigoModalTxt.Enabled = true;
                CodigoModalTxt.Text = string.Empty;
                DescripcionModalTxt.Text = string.Empty;
                EstadoModal.Checked = true;
                TituloModalPanel.Text = ConstantesUtil.TITULO_NUEVO_PERFIL;
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
                IdRegistro = Guid.Parse(PerfilesGridView.DataKeys[gr.RowIndex].Value.ToString());

                var result = _clienteConfiguracion.ObtenerPerfilesPorId(IdRegistro);
                if (!string.IsNullOrEmpty(result))
                    _perfil = Serializador.DeSerializeEntity<Perfil>(result);
                _perfil.Estado = !_perfil.Estado;
                _perfil.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                _perfil.CampoIpUsuario = GestionUtil.IpCliente;
                _clienteConfiguracion.ModificarPerfil(Serializador.SerializeEntity(_perfil));
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
                var clave = new ClaseBasica
                {
                    Descripcion = BuscarTextBox.Text.Trim(),
                    Estado = EstadoCheckBox.Checked,
                    CedulaUsuario = GestionUtil.UsuarioSesion.Cedula,
                    IpUsuario = GestionUtil.IpCliente
                };
                _clienteConfiguracion.ModificarMasivamentePerfiles(Serializador.SerializeEntity(clave));
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
                GestionUtil.Redireccionar(ConstantesUtil.URL_MENU_CONFIGURACION);

            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_NAVEGACION_MENU);
            }
        }



        ////////////////////////////////////////////////
        /// TODO: PRUEBA DEL NUEVO PAGINADOR
        /// ///////////////////////////////////////////


        private void BindingDatosPaginadosPorLista(List<Perfil> lista, int totalRegistros)
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

                PerfilesGridView.DataSource = lista;
                PerfilesGridView.DataBind();
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
                    List<Perfil> lista = null;

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
                        result = _clienteConfiguracion.ObtenerPerfilesPorCoincidenciaPaginado(out _totalRegistros, BuscarTextBox.Text,
                            EstadoCheckBox.Checked, PageSizeActual,
                            PageIndexActual);
                    }
                    else
                    {
                        result = _clienteConfiguracion.ObtenerPerfilesPorEstadoPaginado(out _totalRegistros,
                            EstadoCheckBox.Checked, PageSizeActual,
                            PageIndexActual);
                    }

                    lista = result != null ? Serializador.DeSerializeEntity<List<Perfil>>(result) : null;
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
                List<Perfil> lista = null;

                if (!string.IsNullOrEmpty(BuscarTextBox.Text.Trim()))
                {
                    result = _clienteConfiguracion.ObtenerPerfilesPorCoincidenciaPaginado(out _totalRegistros, BuscarTextBox.Text, EstadoCheckBox.Checked, PageSizeActual, PageIndexActual);
                    lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<Perfil>>(result) : null;
                }
                else
                {
                    result = _clienteConfiguracion.ObtenerPerfilesPorEstadoPaginado(out _totalRegistros, EstadoCheckBox.Checked, PageSizeActual, PageIndexActual);
                    lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<Perfil>>(result) : null;
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
            txturlinicio.Text = new ConfiguracionServiceClient().ObtenerUrlPorId(ddlpagina.SelectedValue.ToString());
        }
    }
}
