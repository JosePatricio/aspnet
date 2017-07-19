using System;
using System.Web.UI.WebControls;
using Negocio.Seguridad;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.Utilidades;
using Sigeor.GestionAutenticacionServiceReference;
using Sigeor.GestionConfiguracionServiceReference;

namespace Sigeor.Autenticacion
{
    public partial class RecuperarClave : System.Web.UI.Page
    {
        private readonly AutenticacionServiceClient _clienteAutenticacion;
        private ConfiguracionServiceClient _clienteConfiguracion;

        private string CoordenadaX
        {
            get
            {
                return Session["CoordenadaX"] != null ? Session["CoordenadaX"].ToString() : string.Empty;
            }
        }


        private string CoordenadaY
        {
            get
            {
                return Session["CoordenadaY"] != null ? Session["CoordenadaY"].ToString() : string.Empty;
            }
        }


        protected RecuperarClave()
        {
            _clienteAutenticacion = new AutenticacionServiceClient();
            _clienteConfiguracion = new ConfiguracionServiceClient();
        }

        private void GenerarDatosAleatorio()
        {
            GestionUtil.GenerarNumerosBotones(this);
            GestionUtil.GenerarCoordenadasLogin(EKeyTxtBox);
            EmailTxtBox.Text = string.Empty;
            EKeyTxtBox.Attributes["Value"] = string.Empty;

        }

        protected void Load_Form(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                try
                {
                    EKeyTxtBox.Attributes.Add("Value", string.Empty);
                    GenerarDatosAleatorio();
                }
                catch
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "", "No se pudo generar el tablero aleatorio.");
                }
            }

        }

        protected void ButAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                bool isEmpty = false;
                if (string.IsNullOrEmpty(EmailTxtBox.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Email", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }


                if (string.IsNullOrEmpty(EKeyTxtBox.Attributes["Value"]))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Ekey", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }

                if (!string.IsNullOrEmpty(EmailTxtBox.Text.Trim()) && !ValidacionesUtil.validacionCorreo(EmailTxtBox.Text))
                {
                    isEmpty = true;
                    EmailTxtBox.Text = string.Empty;
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "", "Email inválido");

                }


                if (isEmpty)
                {
                    GenerarDatosAleatorio();
                    return;
                }

                var result = _clienteAutenticacion.ObtenerUsuarioPorEmail(EmailTxtBox.Text, EKeyTxtBox.Text);
                Usuario usuario = null;

                if (!string.IsNullOrEmpty(result))
                    usuario = Serializador.DeSerializeEntity<Usuario>(result);

                if (usuario != null)
                {
                    result = _clienteAutenticacion.ObtenerEkeyPorCedulaUsuario(usuario.Cedula);
                    var idEKey = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<EKey>(result).Id : Guid.Empty;

                    //bool ekeyValido = _clienteAutenticacion.CompararCoordenadaEkey(idEKey, 
                    //    MetodosEncriptacion.EncriptarMD5(CoordenadaX),
                    //    MetodosEncriptacion.EncriptarMD5(CoordenadaY), 
                    //    MetodosEncriptacion.EncriptarMD5(EKeyTxtBox.Attributes["Value"]));
                    var coordenadaEkey = new CoordenadasEkey
                    {
                        Id = idEKey,
                        CoordenadaX = MetodosEncriptacion.EncriptarMD5(CoordenadaX),
                        CoordenadaY = MetodosEncriptacion.EncriptarMD5(CoordenadaY),
                        Valor = MetodosEncriptacion.EncriptarMD5(EKeyTxtBox.Attributes["Value"]),
                        CampoTipoAccion = "REC_PASS",
                        CampoCedulaUsuario = usuario.Cedula,
                        CampoIpUsuario = GestionUtil.IpCliente,

                    };

                    bool ekeyValido = _clienteAutenticacion.CompararCoordenadaEkey(Serializador.SerializeEntity(coordenadaEkey));

                    if (ekeyValido)
                    {
                        _clienteConfiguracion = new ConfiguracionServiceClient();
                        result = _clienteConfiguracion.ObtenerUsuarioPorCedula(usuario.Cedula);
                        usuario = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<Usuario>(result) : null;
                        string claveGenerada = GestionUtil.GenerarClave(8);
                        usuario.Contrasenia = MetodosEncriptacion.EncriptarMD5(claveGenerada);
                        usuario.OlvidoContrasenia = true;
                        _clienteConfiguracion.ModificarUsuario(Serializador.SerializeEntity(usuario));
                        GestionUtil.EnviarEmail(usuario.Email, usuario.Cedula, usuario.Nombre, claveGenerada);
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "La contraseña provisional fué enviada al Email registrado.");
                        GenerarDatosAleatorio();
                        GestionUtil.Redireccionar(ConstantesUtil.URL_LOGIN);
                    }
                    else
                    {
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "Ekey no válido.");
                    }
                }
                else
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.mensajeEmailNoRegistrado);
                    EmailTxtBox.Text = string.Empty;
                }
                GenerarDatosAleatorio();
            }
            catch (Exception)
            {

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "", "No se pudo recuperar la clave solicitada.");
            }

        }

        protected void botonNumero_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = sender as Button;

                var valorEkey = EKeyTxtBox.Attributes["Value"];
                if (string.IsNullOrEmpty(valorEkey))
                    EKeyTxtBox.Attributes.Add("Value", string.Empty);

                if (EKeyTxtBox.Attributes["Value"].Length < 3 && !button.Text.Equals("Borrar"))
                    EKeyTxtBox.Attributes["Value"] = string.Concat(valorEkey, button.Text);

                else if (button.Text.Equals("Borrar"))
                    EKeyTxtBox.Attributes["Value"] = string.Empty;

            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "", "No se pudo ingresar el ekey.");
            }
        }

        protected void irLogin_Click(object sender, EventArgs e)
        {
            GestionUtil.Redireccionar(ConstantesUtil.URL_LOGIN);
        }

        protected void principalform_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                GestionUtil.AplicarFocoBusqueda(this, EmailTxtBox);
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PRERENDER);

            }
        }
    }
}
