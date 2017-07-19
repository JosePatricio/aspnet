using System;
using System.Diagnostics;
using System.Web.Security;
using System.Web.UI.WebControls;
using Negocio.Autenticacion;
using Negocio.Seguridad;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.Utilidades;
using Sigeor.GestionAutenticacionServiceReference;
using System.Web.UI;

namespace Sigeor.Autenticacion
{
    public partial class Login : System.Web.UI.Page
    {
        private AutenticacionServiceClient _clienteAutenticacion;


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


        protected Login()
        {
            _clienteAutenticacion = new AutenticacionServiceClient();

        }

        private void GenerarDatosAleatorio()
        {
            GestionUtil.GenerarNumerosBotones(this);
            EKeyTxtBox.Attributes["Value"] = string.Empty;
            GestionUtil.GenerarCoordenadasLogin(EKeyTxtBox);

        }

        protected void Load_Login(object sender, EventArgs e)
        {            
            if (!this.IsPostBack)
            {
                try
                {
                    ContrasenaTxtBox.Attributes.Add("Value", string.Empty);
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
                if (string.IsNullOrEmpty(UsuarioTxtBox.Text.Trim()))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Nombre de Usuario", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }
                if (string.IsNullOrEmpty(ContrasenaTxtBox.Text))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Contaseña", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }

                if (string.IsNullOrEmpty(EKeyTxtBox.Text) && string.IsNullOrEmpty(EKeyTxtBox.Attributes["Value"]))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Ekey", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }

                if (isEmpty) return;

                var result = _clienteAutenticacion.ObtenerUsuarioPorCredenciales(UsuarioTxtBox.Text, MetodosEncriptacion.EncriptarMD5(ContrasenaTxtBox.Text));
                //var result = GestionAutenticacion.ObtenerUsuarioPorCredenciales(UsuarioTxtBox.Text,
                //    MetodosEncriptacion.EncriptarMD5(ContrasenaTxtBox.Text));

                Usuario usuario = null;

                if (!string.IsNullOrEmpty(result))
                    usuario = Serializador.DeSerializeEntity<Usuario>(result);

                if (usuario != null)
                {
                    //_clienteAutenticacion = new GestionAutenticacionServiceClient();
                    result = _clienteAutenticacion.ObtenerEkeyPorCedulaUsuario(usuario.Cedula);
                    var idEKey = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<EKey>(result).Id : Guid.Empty;

                    var coordenadaEkey = new CoordenadasEkey
                    {
                        Id = idEKey,
                        CoordenadaX = MetodosEncriptacion.EncriptarMD5(CoordenadaX),
                        CoordenadaY = MetodosEncriptacion.EncriptarMD5(CoordenadaY),
                        Valor = MetodosEncriptacion.EncriptarMD5(EKeyTxtBox.Attributes["Value"]),
                        CampoTipoAccion = "LOGIN",
                        CampoCedulaUsuario = usuario.Cedula,
                        CampoIpUsuario = GestionUtil.IpCliente,

                    };

                    var ekeyValido = _clienteAutenticacion.CompararCoordenadaEkey(Serializador.SerializeEntity(coordenadaEkey));

                    if (true)//ekeyValido)
                    {
                        usuario.CampoIpUsuario = GestionUtil.IpCliente;
                        Session.Add("Usuario", usuario);
                        if (usuario.OlvidoContrasenia.Value) // Se redirecciona si el usuario a ingresado un clave generada
                        {
                            Session["ClaveGenerada"] = ContrasenaTxtBox.Text;
                            GestionUtil.Redireccionar(ConstantesUtil.URL_CAMBIAR_CLAVE);
                        }
                        else {
                            FormsAuthentication.RedirectFromLoginPage(usuario.Nombre, false);
                        }
                    }
                    else
                    {
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "Ekey no válido.");
                        EKeyTxtBox.Text = string.Empty;
                        GenerarDatosAleatorio();
                    }

                }
                else
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.mensajeUsuarioNoRegistrado);
                    UsuarioTxtBox.Text = string.Empty;
                    ContrasenaTxtBox.Attributes["Value"] = string.Empty;
                    EKeyTxtBox.Attributes["Value"] = string.Empty;
                    GenerarDatosAleatorio();
                }
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ex.Message);
            }
        }
        protected void Contrasena_Click(object sender, EventArgs e)
        {
            GestionUtil.Redireccionar(ConstantesUtil.URL_RECUPERAR_CLAVE);
        }

        protected void botonNumero_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(ContrasenaTxtBox.Text))
                    ContrasenaTxtBox.Attributes["Value"] = ContrasenaTxtBox.Text;

                if (!string.IsNullOrWhiteSpace(ContrasenaTxtBox.Attributes["Value"]))
                    ContrasenaTxtBox.Attributes["Value"] = ContrasenaTxtBox.Attributes["Value"];

                Button button = sender as Button;

                var valorEkey = EKeyTxtBox.Attributes["Value"];
                if (string.IsNullOrEmpty(valorEkey))
                    EKeyTxtBox.Attributes["Value"] = string.Empty;

                if (EKeyTxtBox.Attributes["Value"].Length < 3 && !button.Text.Equals("Borrar"))
                    EKeyTxtBox.Attributes["Value"] = string.Concat(valorEkey, button.Text);



                else if (button.Text.Equals("Borrar"))
                {
                    EKeyTxtBox.Text = string.Empty;
                    EKeyTxtBox.Attributes["Value"] = string.Empty;
                }
                //  GestionUtil.MostrarNotificacion(this, ConstantesUtil.notificacionError, "", "No se pudo ingresar el ekey.");

            }
            catch (Exception ex)
            {
                var x = new EventLog("SigeorLog");
                x.WriteEntry("Prueba " + ex, EventLogEntryType.Error);

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "", "No se pudo ingresar el ekey.");
            }

        }

        protected void principalform_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                GestionUtil.AplicarFocoBusqueda(this, UsuarioTxtBox);
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PRERENDER);

            }
        }

    }
}
