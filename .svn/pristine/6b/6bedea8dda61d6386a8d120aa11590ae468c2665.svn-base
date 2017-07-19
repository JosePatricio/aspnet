using System;
using System.Web.UI.WebControls;

using PersistenciaSigeor;
using Sigeor.Utilidades;
using Sigeor.GestionAutenticacionServiceReference;
using Sigeor.GestionConfiguracionServiceReference;
using Negocio.Utilidades;
using Negocio.Seguridad;

namespace Sigeor.Autenticacion
{
    public partial class CambiarClave : System.Web.UI.Page
    {
        private AutenticacionServiceClient _clienteAutenticacion;
        private ConfiguracionServiceClient _configuracionCliente;


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

        private string ContraseniaGenerada
        {
            set
            {
                Session["ContraseniaGenerada"] = value;
            }
            get
            {
                return Session["ContraseniaGenerada"] != null ? Session["ContraseniaGenerada"].ToString() : string.Empty;
            }
        }

        private string ContraseniaNueva
        {
            set
            {
                Session["ContraseniaNueva"] = value;
            }
            get
            {
                return Session["ContraseniaNueva"] != null ? Session["ContraseniaNueva"].ToString() : string.Empty;
            }
        }

        private string ContraseniaConfirmada
        {
            set
            {
                Session["ContraseniaConfirmada"] = value;
            }
            get
            {
                return Session["ContraseniaConfirmada"] != null ? Session["ContraseniaConfirmada"].ToString() : string.Empty;
            }
        }

        public CambiarClave()
        {
            _clienteAutenticacion = new AutenticacionServiceClient();
            _configuracionCliente = new ConfiguracionServiceClient();
        }

        private void GenerarDatosAleatorio()
        {
            GestionUtil.GenerarNumerosBotones(this);
            GestionUtil.GenerarCoordenadasLogin(EKeyTxtBox);
            NuevaContraseniaTextBox.Attributes["Value"] = string.Empty;
            ConfirmarContraseniaTextBox.Attributes["Value"] = string.Empty;
            EKeyTxtBox.Attributes["Value"] = string.Empty;
        }

        protected void Load_Form(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Session["ClaveGenerada"].ToString()) &&
                   Session["Usuario"] != null)
                    {
                        ContraseniaGeneradaTextBox.Attributes.Add("Value", Session["ClaveGenerada"].ToString());
                        NuevaContraseniaTextBox.Attributes.Add("Value", string.Empty);
                        ConfirmarContraseniaTextBox.Attributes.Add("Value", string.Empty);
                        EKeyTxtBox.Attributes.Add("Value", string.Empty);
                        GenerarDatosAleatorio();
                    }
                    else
                        GestionUtil.Redireccionar(ConstantesUtil.URL_LOGIN);
                }
                catch (Exception)
                {
                    GestionUtil.Redireccionar(ConstantesUtil.URL_LOGIN);
                }
            }
        }

        protected void ButAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                var isEmpty = false;
                if (string.IsNullOrEmpty(ContraseniaGeneradaTextBox.Attributes["Value"]))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Contraseña Generada", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }
                if (string.IsNullOrEmpty(NuevaContraseniaTextBox.Attributes["Value"]))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Nueva Contraseña", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }
                if (string.IsNullOrEmpty(ConfirmarContraseniaTextBox.Attributes["Value"]))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Confirmación de Contraseña ", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }

                if (string.IsNullOrEmpty(EKeyTxtBox.Text) && string.IsNullOrEmpty(EKeyTxtBox.Attributes["Value"]))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Ekey", ConstantesUtil.mensajeCampoObligatorio);
                    isEmpty = true;
                }

                if (isEmpty) return;

                _configuracionCliente = new ConfiguracionServiceClient();

                var cedulaUsuario = ((Usuario)Session["Usuario"]).Cedula;

                var result = _configuracionCliente.ObtenerUsuarioPorCedula(cedulaUsuario);

                Usuario usuario = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<Usuario>(result) : null;


                //var coordenadaEkey = new CoordenadasEkey();
                //coordenadaEkey.EKey = _clienteAutenticacion.ObtenerEkeyPorCedulaUsuario(usuario.Cedula);

                result = _clienteAutenticacion.ObtenerUsuarioPorCredenciales(usuario.NombreUsuario,
                            MetodosEncriptacion.EncriptarMD5(ContraseniaGeneradaTextBox.Attributes["Value"]));

                Usuario usuarioAutentica = null;

                if (!string.IsNullOrEmpty(result))
                    usuarioAutentica = Serializador.DeSerializeEntity<Usuario>(result);

                if (usuarioAutentica != null)
                {
                    usuario.CampoCedulaUsuario = usuario.Cedula;
                    usuario.CampoIpUsuario = GestionUtil.IpCliente;
                    if (
                        NuevaContraseniaTextBox.Attributes["Value"].Equals(
                            ConfirmarContraseniaTextBox.Attributes["Value"]))
                    {
                        result = _clienteAutenticacion.ObtenerEkeyPorCedulaUsuario(usuario.Cedula);
                        var idEKey = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<EKey>(result).Id : Guid.Empty;

                        var coordenadaEkey = new CoordenadasEkey
                        {
                            Id = idEKey,
                            CoordenadaX = MetodosEncriptacion.EncriptarMD5(CoordenadaX),
                            CoordenadaY = MetodosEncriptacion.EncriptarMD5(CoordenadaY),
                            Valor = MetodosEncriptacion.EncriptarMD5(EKeyTxtBox.Attributes["Value"]),
                            CampoTipoAccion = "CHN_PASS",
                            CampoCedulaUsuario = usuario.Cedula,
                            CampoIpUsuario = GestionUtil.IpCliente,

                        };

                        bool ekeyValido = _clienteAutenticacion.CompararCoordenadaEkey(Serializador.SerializeEntity(coordenadaEkey));


                        if (true)// (ekeyValido)
                        {

                            usuario.Contrasenia = MetodosEncriptacion.EncriptarMD5(NuevaContraseniaTextBox.Text);
                            usuario.OlvidoContrasenia = false;
                            _configuracionCliente.ModificarUsuario(Serializador.SerializeEntity(usuario));
                            GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_INFO, "Clave",
                                ConstantesUtil.mensajeRegistroGuardado);
                            ContraseniaGeneradaTextBox.Attributes["Value"] = string.Empty;
                            Session.Remove("ClaveGenerada");
                            Session.Remove("CedulaUsuario");
                            Session.Remove("Usuario");
                            GenerarDatosAleatorio();
                            GestionUtil.Redireccionar(ConstantesUtil.URL_LOGIN);
                        }
                        else
                        {
                            GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty,
                                "Ekey no válido.");
                        }
                    }
                    else
                        GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "",
                            ConstantesUtil.mensajeClavesDiferentes);
                }
                else
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "", ConstantesUtil.mensajeClaveErronea);

                GenerarDatosAleatorio();
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "", "No se pudo cambiar la clave de usuario");
            }
        }

        protected void botonNumero_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(ContraseniaGeneradaTextBox.Attributes["Value"]))
                    ContraseniaGenerada = ContraseniaGeneradaTextBox.Attributes["Value"];
                if (!string.IsNullOrWhiteSpace(ContraseniaGenerada))
                    ContraseniaGeneradaTextBox.Attributes["Value"] = ContraseniaGenerada;

                if (!string.IsNullOrWhiteSpace(NuevaContraseniaTextBox.Text))
                    ContraseniaNueva = NuevaContraseniaTextBox.Text;
                if (!string.IsNullOrWhiteSpace(ContraseniaNueva))
                    NuevaContraseniaTextBox.Attributes["Value"] = ContraseniaNueva;

                if (!string.IsNullOrWhiteSpace(ConfirmarContraseniaTextBox.Text))
                    ContraseniaConfirmada = ConfirmarContraseniaTextBox.Text;
                if (!string.IsNullOrWhiteSpace(ContraseniaConfirmada))
                    ConfirmarContraseniaTextBox.Attributes["Value"] = ContraseniaConfirmada;

                Button button = sender as Button;

                var valorEkey = EKeyTxtBox.Attributes["Value"];
                if (string.IsNullOrEmpty(valorEkey))
                    EKeyTxtBox.Attributes["Value"] = string.Empty;

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
                GestionUtil.AplicarFocoBusqueda(this, NuevaContraseniaTextBox);
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PRERENDER);

            }
        }

    }
}
