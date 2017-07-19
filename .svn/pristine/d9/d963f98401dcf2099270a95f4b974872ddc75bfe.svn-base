using System;
using System.Diagnostics;
using System.Web.UI;
using Negocio.Seguridad;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.GestionConfiguracionServiceReference;
using Sigeor.Utilidades;

namespace Sigeor.Configuracion
{
    public partial class ConfiguracionEmailWebForm : System.Web.UI.Page
    {
        private ConfiguracionServiceClient _clienteConfiguracion;

        protected ConfiguracionEmailWebForm()
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
                    var result = _clienteConfiguracion.ObtenerConfiguracionEmail();

                    if (result != null)
                    {
                        var configuracion = Serializador.DeSerializeEntity<Email>(result);
                        emailTxt.Text = configuracion.DirEMail;
                        hostTxt.Text = configuracion.Host;
                        puertoTxt.Text = configuracion.Puerto.ToString();
                        passwordTxt.Attributes.Add("Value", MetodosEncriptacion.DesencriptarBase64(configuracion.Password));
                        enableSsl.Checked = configuracion.Ssl;

                    }
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
                GestionUtil.AplicarFocoBusqueda(this, emailTxt);
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
                emailTxt.Text = emailTxt.Text.Trim();
                hostTxt.Text = hostTxt.Text.Trim();
                puertoTxt.Text = puertoTxt.Text.Trim();


                if (string.IsNullOrEmpty(emailTxt.Text))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El email es obligatorio");
                    esValido = false;
                }

                if (!string.IsNullOrEmpty(emailTxt.Text) && !ValidacionesUtil.validacionCorreo(emailTxt.Text))
                {
                    emailTxt.Text = string.Empty;
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El email no válido");
                    esValido = false;
                }

                if (string.IsNullOrEmpty(hostTxt.Text))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El host es obligatorio");
                    esValido = false;
                }

                if (string.IsNullOrEmpty(puertoTxt.Text))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El host es obligatorio");
                    esValido = false;
                }

                if (!string.IsNullOrEmpty(puertoTxt.Text) && !ValidacionesUtil.ValidarNumeros(puertoTxt.Text))
                {
                    puertoTxt.Text = string.Empty;
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El host es obligatorio");
                    esValido = false;
                }

                if (string.IsNullOrEmpty(passwordTxt.Text))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El password es obligatorio");
                    esValido = false;
                }

                if (string.IsNullOrEmpty(confirmPasswordTxt.Text))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "Confirmar el password es obligatorio");
                    esValido = false;
                }

                if (!string.IsNullOrEmpty(passwordTxt.Text) && !string.IsNullOrEmpty(confirmPasswordTxt.Text) && !passwordTxt.Text.Equals(confirmPasswordTxt.Text))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "Las contraseñas son diferentes");
                    passwordTxt.Text = string.Empty;
                    confirmPasswordTxt.Text = string.Empty;
                    passwordTxt.Attributes.Add("Value", string.Empty);
                    confirmPasswordTxt.Attributes.Add("Value", string.Empty);
                    esValido = false;
                }


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

                var email = new Email
                {
                    DirEMail = emailTxt.Text,
                    Host = hostTxt.Text,
                    Puerto = short.Parse(puertoTxt.Text),
                    Password = MetodosEncriptacion.EncriptarBase64(passwordTxt.Text),
                    Ssl = enableSsl.Checked,
                    CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula,
                    CampoIpUsuario = GestionUtil.IpCliente,
                    
                    
                };

                
                _clienteConfiguracion.InsertarConfiguracionEmail(Serializador.SerializeEntity(email));
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
                GestionUtil.TestEnviarEmail(emailTxt.Text, hostTxt.Text, int.Parse(puertoTxt.Text), passwordTxt.Text, enableSsl.Checked, bodyEmail, false);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_SUCCESS, string.Empty, "El email de prueba fue enviado con éxito.");
                passwordTxt.Attributes.Add("Value", passwordTxt.Text);
                confirmPasswordTxt.Attributes.Add("Value", confirmPasswordTxt.Text);
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo enviar el email de prueba. Verifique la configuración");
            }
        }
    }
}