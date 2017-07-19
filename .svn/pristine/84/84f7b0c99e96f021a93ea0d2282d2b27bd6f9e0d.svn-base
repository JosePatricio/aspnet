using System;
using System.Diagnostics;
using System.Web.UI;
using Negocio.Seguridad;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.GestionConfiguracionServiceReference;
using Sigeor.Utilidades;
using System.Globalization;
using System.Collections.Generic;

namespace Sigeor.Configuracion
{
    public partial class EliminacionReparacionesWebForm : System.Web.UI.Page
    {
        private readonly ConfiguracionServiceClient _clienteConfiguracion;
        private PoliticasCorporativas _politica;
        private List<PoliticasCorporativas> lista = null;
        private static readonly string COD_EST = string.Format(ConstantesUtil.COD_POL_DEL, "EST");
        private static readonly string COD_MAQ = string.Format(ConstantesUtil.COD_POL_DEL, "MAQ");
        private static readonly string COD_TRA = string.Format(ConstantesUtil.COD_POL_DEL, "TRA");

        protected EliminacionReparacionesWebForm()
        {
            try
            {
                _clienteConfiguracion = new ConfiguracionServiceClient();
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
                    lblCabecera.Text = GestionUtil.tituloPagina(this.Request.Url.LocalPath);

                    //lblCabecera.Text = Session["TituloMenu"].ToString();

                    var result = _clienteConfiguracion.ObtenerPoliticaPorcodigo(Serializador.SerializeEntity(new ClaseBasica { IdString = COD_EST }));
                    _politica = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<PoliticasCorporativas>(result) : null;
                    txtFecIniEst.Text = _politica?.FechaValueUno != null ? _politica.FechaValueUno.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    txtFecFinEst.Text = _politica?.FechaValueDos != null ? _politica.FechaValueDos.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    checkEstadoEstructura.Checked = _politica?.Estado == true;


                    result = _clienteConfiguracion.ObtenerPoliticaPorcodigo(Serializador.SerializeEntity(new ClaseBasica { IdString = COD_MAQ }));
                    _politica = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<PoliticasCorporativas>(result) : null;
                    txtFecIniMaq.Text = _politica?.FechaValueUno != null ? _politica.FechaValueUno.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    txtFecFinMaq.Text = _politica?.FechaValueDos != null ? _politica.FechaValueDos.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    checkEstadoMaquinaria.Checked = _politica?.Estado == true;


                    result = _clienteConfiguracion.ObtenerPoliticaPorcodigo(Serializador.SerializeEntity(new ClaseBasica { IdString = COD_TRA }));

                    _politica = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<PoliticasCorporativas>(result) : null;
                    txtFecIniTran.Text = _politica?.FechaValueUno != null ? _politica.FechaValueUno.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    txtFecFinTran.Text = _politica?.FechaValueDos != null ? _politica.FechaValueDos.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    checkEstadoTransito.Checked = _politica?.Estado == true;

                }
            }
            catch (Exception)
            {

            }
        }

        protected void principalForm_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                //GestionUtil.AplicarFocoBusqueda(this, emailTxt);
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PRERENDER);

            }
        }

        private bool ValidarCampos()
        {
            var esValido = true;

            try
            {
                //emailTxt.Text = emailTxt.Text.Trim();
                //hostTxt.Text = hostTxt.Text.Trim();
                //puertoTxt.Text = puertoTxt.Text.Trim();


                //if (string.IsNullOrEmpty(emailTxt.Text))
                //{
                //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El email es obligatorio");
                //    esValido = false;
                //}

                //if (!string.IsNullOrEmpty(emailTxt.Text) && !ValidacionesUtil.validacionCorreo(emailTxt.Text))
                //{
                //    emailTxt.Text = string.Empty;
                //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El email no válido");
                //    esValido = false;
                //}

                //if (string.IsNullOrEmpty(hostTxt.Text))
                //{
                //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El host es obligatorio");
                //    esValido = false;
                //}

                //if (string.IsNullOrEmpty(puertoTxt.Text))
                //{
                //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El host es obligatorio");
                //    esValido = false;
                //}

                //if (!string.IsNullOrEmpty(puertoTxt.Text) && !ValidacionesUtil.ValidacionNumerosEnteros(puertoTxt.Text))
                //{
                //    puertoTxt.Text = string.Empty;
                //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El host es obligatorio");
                //    esValido = false;
                //}

                //if (string.IsNullOrEmpty(passwordTxt.Text))
                //{
                //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El password es obligatorio");
                //    esValido = false;
                //}

                //if (string.IsNullOrEmpty(confirmPasswordTxt.Text))
                //{
                //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "Confirmar el password es obligatorio");
                //    esValido = false;
                //}

                //if (!string.IsNullOrEmpty(passwordTxt.Text) && !string.IsNullOrEmpty(confirmPasswordTxt.Text) && !passwordTxt.Text.Equals(confirmPasswordTxt.Text))
                //{
                //    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "Las contraseñas son diferentes");
                //    passwordTxt.Text = string.Empty;
                //    confirmPasswordTxt.Text = string.Empty;
                //    passwordTxt.Attributes.Add("Value", string.Empty);
                //    confirmPasswordTxt.Attributes.Add("Value", string.Empty);
                //    esValido = false;
                //}


            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo validar los campos");
            }

            return esValido;
        }

        protected void aceptarButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                var fechaInicial = string.Empty;
                var fechaFinal = string.Empty;

                var result = _clienteConfiguracion.ObtenerPoliticaPorcodigo(Serializador.SerializeEntity(new ClaseBasica { IdString = COD_EST }));


                if (!string.IsNullOrEmpty(result))
                {
                    fechaInicial = Request.Form["txtFecIniEst"];
                    fechaFinal = Request.Form["txtFecFinEst"];

                    _politica = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<PoliticasCorporativas>(result) : null;
                    if (_politica != null)
                    {
                        _politica.FechaValueUno = fechaInicial != null ? DateTime.Parse(fechaInicial) : DateTime.Now;
                        _politica.FechaValueDos = fechaFinal != null ? DateTime.Parse(fechaFinal) : DateTime.Now;
                        _politica.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                        _politica.CampoIpUsuario = GestionUtil.IpCliente;
                        _politica.Estado = checkEstadoEstructura.Checked;

                        _clienteConfiguracion.ModificarPolitica(Serializador.SerializeEntity(_politica));
                    }
                }
                else
                {
                    _politica = new PoliticasCorporativas
                    {
                        Codigo = COD_EST,
                        Nombre = string.Format(ConstantesUtil.NOM_POL_DEL, "EST"),
                        Descripcion = string.Format(ConstantesUtil.DESC_POL_DEL, "EST"),
                        Grupo = string.Format(ConstantesUtil.GR_POL, "DIF"),
                        FechaValueUno = DateTime.Parse(txtFecIniEst.Text),
                        FechaValueDos = DateTime.Parse(txtFecFinEst.Text),
                        CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula,
                        CampoIpUsuario = GestionUtil.IpCliente,
                        Estado = checkEstadoEstructura.Checked
                    };
                    _clienteConfiguracion.InsertarPolitica(Serializador.SerializeEntity(_politica));
                }




                result = _clienteConfiguracion.ObtenerPoliticaPorcodigo(Serializador.SerializeEntity(new ClaseBasica { IdString = COD_MAQ }));
                if (!string.IsNullOrEmpty(result))
                {
                    fechaInicial = Request.Form["txtFecIniMaq"];
                    fechaFinal = Request.Form["txtFecFinMaq"];

                    _politica = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<PoliticasCorporativas>(result) : null;
                    if (_politica != null)
                    {
                        _politica.FechaValueUno = fechaInicial != null ? DateTime.Parse(fechaInicial) : DateTime.Now;
                        _politica.FechaValueDos = fechaFinal != null ? DateTime.Parse(fechaFinal) : DateTime.Now;
                        _politica.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                        _politica.CampoIpUsuario = GestionUtil.IpCliente;
                        _politica.Estado = checkEstadoMaquinaria.Checked;

                        _clienteConfiguracion.ModificarPolitica(Serializador.SerializeEntity(_politica));
                    }
                }
                else
                {
                    _politica = new PoliticasCorporativas
                    {
                        Codigo = COD_MAQ,
                        Nombre = string.Format(ConstantesUtil.NOM_POL_DEL, "MAQ"),
                        Descripcion = string.Format(ConstantesUtil.DESC_POL_DEL, "MAQ"),
                        Grupo = string.Format(ConstantesUtil.GR_POL, "DIF"),
                        FechaValueUno = DateTime.Parse(txtFecIniEst.Text),
                        FechaValueDos = DateTime.Parse(txtFecFinEst.Text),
                        CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula,
                        CampoIpUsuario = GestionUtil.IpCliente,
                        Estado = checkEstadoMaquinaria.Checked

                    };
                    _clienteConfiguracion.InsertarPolitica(Serializador.SerializeEntity(_politica));
                }


                result = _clienteConfiguracion.ObtenerPoliticaPorcodigo(Serializador.SerializeEntity(new ClaseBasica { IdString = COD_TRA }));
                if (!string.IsNullOrEmpty(result))
                {
                    fechaInicial = Request.Form["txtFecIniTran"];
                    fechaFinal = Request.Form["txtFecFinTran"];

                    _politica = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<PoliticasCorporativas>(result) : null;
                    if (_politica != null)
                    {
                        _politica.FechaValueUno = fechaInicial != null ? DateTime.Parse(fechaInicial) : DateTime.Now;
                        _politica.FechaValueDos = fechaFinal != null ? DateTime.Parse(fechaFinal) : DateTime.Now;
                        _politica.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                        _politica.CampoIpUsuario = GestionUtil.IpCliente;
                        _politica.Estado = checkEstadoTransito.Checked;

                        _clienteConfiguracion.ModificarPolitica(Serializador.SerializeEntity(_politica));
                    }
                }
                else
                {
                    _politica = new PoliticasCorporativas
                    {
                        Codigo = COD_TRA,
                        Nombre = string.Format(ConstantesUtil.NOM_POL_DEL, "TRA"),
                        Descripcion = string.Format(ConstantesUtil.DESC_POL_DEL, "TRA"),
                        Grupo = string.Format(ConstantesUtil.GR_POL, "DIF"),
                        FechaValueUno = DateTime.Parse(txtFecIniEst.Text),
                        FechaValueDos = DateTime.Parse(txtFecFinEst.Text),
                        CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula,
                        CampoIpUsuario = GestionUtil.IpCliente,
                        Estado = checkEstadoTransito.Checked

                    };
                    _clienteConfiguracion.InsertarPolitica(Serializador.SerializeEntity(_politica));
                }
                
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, string.Empty, "La configuración se almacenó correctamente");
                GestionUtil.OcultarModal(this, "myLoading");
            }
            catch (Exception ex)
            {
                Log.WriteEntry("Error al guardar la configuracion del Email: " + ex, EventLogEntryType.Error);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "Ocurrió un error al guardar la configuración");
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


        protected void testButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                const string bodyEmail = "Este es un correo de prueba. Verifica la configuración ingesada al sistema.";
                //GestionUtil.TestEnviarEmail(emailTxt.Text, hostTxt.Text, int.Parse(puertoTxt.Text), passwordTxt.Text, enableSsl.Checked, bodyEmail, false);
                //GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, string.Empty, "El email de prueba fue enviado con éxito.");
                //passwordTxt.Attributes.Add("Value", passwordTxt.Text);
                //confirmPasswordTxt.Attributes.Add("Value", confirmPasswordTxt.Text);
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo enviar el email de prueba. Verifique la configuración");
            }
        }
    }
}