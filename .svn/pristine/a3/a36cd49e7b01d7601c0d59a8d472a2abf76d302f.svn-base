using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.GestionConfiguracionServiceReference;
using Sigeor.Utilidades;

namespace Sigeor.Configuracion
{
    public partial class GestionDocumentosWebForm : System.Web.UI.Page
    {

        private ConfiguracionServiceClient _clienteConfiguracion;
        private List<ClaseBasica> _listaRegistrosVisibles;
        private Documento _documento;
        private int _totalRegistros;

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

        private Guid IdRegistro
        {
            set
            {
                Session["IdGestDoc"] = value;
            }
            get
            {
                return Guid.Parse(Session["IdGestDoc"].ToString());
            }
        }
        public GestionDocumentosWebForm()
        {
            try
            {
                _clienteConfiguracion = new ConfiguracionServiceClient();
                _listaRegistrosVisibles = GestionUtil.CargarNumeroRegistrosGridView();

            }
            catch (Exception ex)
            {
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
                    Page.MaintainScrollPositionOnPostBack = true;
                    lblCabecera.Text = GestionUtil.tituloPagina(this.Request.Url.LocalPath);
                    //lblCabecera.Text = Session["TituloMenu"].ToString();
                    DocumentosGridView.PageSize = _listaRegistrosVisibles.First().IdInt;
                    RegistrosVisiblesDropDownList.DataSource = _listaRegistrosVisibles;
                    RegistrosVisiblesDropDownList.DataValueField = "IdInt";
                    RegistrosVisiblesDropDownList.DataTextField = "Descripcion";
                    RegistrosVisiblesDropDownList.DataBind();
                    RegistrosVisiblesDropDownList.SelectedValue = "20";

                    CargarDatosPorEstadoCoincidencia();
                    //CargarDataDocumentosGridView(true, null);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DocumentosGridView_RowDataBound(object sender, GridViewRowEventArgs e)
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
                DocumentosGridView.PageSize = int.Parse(RegistrosVisiblesDropDownList.SelectedValue);
                CargarDatosPorEstadoCoincidencia();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            lblTituloDocumento.Text = ConstantesUtil.TITULO_NUEVO_DOCUMENTO;
            GestionUtil.MostrarModal(this);


        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    Directory.CreateDirectory(Server.MapPath("../Documentos/"));
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("../Documentos/") + FileUpload1.FileName);
                    Documento nuevoDocumento = new Documento();
                    nuevoDocumento.Id = Guid.NewGuid();
                    nuevoDocumento.CampoIpUsuario = GestionUtil.IpCliente;
                    nuevoDocumento.Cedula = nuevoDocumento.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                    nuevoDocumento.Nombre = FileUpload1.FileName;
                    nuevoDocumento.Extension = Path.GetExtension(FileUpload1.FileName);
                    nuevoDocumento.Tamano = FileUpload1.FileContent.Length;
                    nuevoDocumento.Tamano = Math.Round((nuevoDocumento.Tamano / 1024), 2);
                    string fileBasePath = Server.MapPath("~/Documentos/");
                    string fileName = Path.GetFileName(FileUpload1.FileName);
                    string fullFilePath = fileBasePath + fileName;
                    nuevoDocumento.Ubicacion = fullFilePath;
                    nuevoDocumento.Fecha = DateTime.Today;
                    nuevoDocumento.Estado = true;
                    _clienteConfiguracion.Insertar(Serializador.SerializeEntity(nuevoDocumento));
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Documento", ConstantesUtil.mensajeRegistroGuardado);
                    CargarDatosPorEstadoCoincidencia();
                }



            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void lnkEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                LinkButton linkButton = sender as LinkButton;
                GridViewRow gr = (GridViewRow)linkButton.NamingContainer;
                IdRegistro = Guid.Parse(DocumentosGridView.DataKeys[gr.RowIndex].Value.ToString());
                var result = _clienteConfiguracion.ObtenerDocumentosPorId(Serializador.SerializeEntity(IdRegistro));
                if (!string.IsNullOrEmpty(result))
                {
                    _documento = Serializador.DeSerializeEntity<Documento>(result);
                    _documento.CampoIpUsuario = GestionUtil.IpCliente;
                    _documento.CampoCedulaUsuario = _documento.Cedula;
                    _clienteConfiguracion.Eliminar(Serializador.SerializeEntity(_documento));
                    string filePath = _documento.Ubicacion;
                    if (File.Exists(_documento.Ubicacion))
                        File.Delete(filePath);
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Documento", ConstantesUtil.mensajeRegistroEliminado);
                    CargarDatosPorEstadoCoincidencia();
                }
                else
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, "Documento", "No pudo ser encontrado");
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        protected void PostBackBind_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            this.ScriptManager1.RegisterPostBackControl(lb);

        }
        protected void lnkDescargar_Click(object sender, EventArgs e)
        {

            try
            {

                LinkButton linkButton = sender as LinkButton;
                GridViewRow gr = (GridViewRow)linkButton.NamingContainer;
                IdRegistro = Guid.Parse(DocumentosGridView.DataKeys[gr.RowIndex].Value.ToString());
                var result = _clienteConfiguracion.ObtenerDocumentosPorId(Serializador.SerializeEntity(IdRegistro));
                if (!string.IsNullOrEmpty(result))
                {
                    _documento = Serializador.DeSerializeEntity<Documento>(result);
                    if (File.Exists(_documento.Ubicacion))
                    {
                        _documento.CampoIpUsuario = GestionUtil.IpCliente;
                        _documento.CampoCedulaUsuario = _documento.Cedula;

                        Response.ContentType = ContentType;
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + _documento.Nombre);
                        Response.WriteFile(_documento.Ubicacion);
                        Response.End();
                    }
                    else
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El documento \"" + _documento.Nombre + "\" no se puede descargar, fué removido.");
                }
            }
            catch (Exception ex)
            {

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo descargar el archivo seleccionado");
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
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty,
                    ConstantesUtil.MENSAJE_ERROR_NAVEGACION_MENU);
            }
        }




        private void BindingDatosPaginadosPorLista(List<Documento> lista, int totalRegistros)
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

                DocumentosGridView.DataSource = lista;
                DocumentosGridView.DataBind();
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
                    List<Documento> lista = null;

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

                    result = _clienteConfiguracion.ObtenerDocumentosPorCoincidenciaPaginado(out _totalRegistros, BuscarTextBox.Text.Trim(),
                            PageSizeActual,
                            PageIndexActual);


                    lista = result != null ? Serializador.DeSerializeEntity<List<Documento>>(result) : new List<Documento>();
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
                var result = _clienteConfiguracion.ObtenerDocumentosPorCoincidenciaPaginado(out _totalRegistros, BuscarTextBox.Text.Trim(),
                    PageSizeActual,
                    PageIndexActual);

                List<Documento> lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<Documento>>(result) : new List<Documento>();
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