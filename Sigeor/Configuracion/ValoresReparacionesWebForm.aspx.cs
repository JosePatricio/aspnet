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
    public partial class ValoresReparacionesWebForm : System.Web.UI.Page
    {
        private ConfiguracionServiceClient _clienteConfiguracion;
        private PoliticasCorporativas politica = null;
        private List<PoliticasCorporativas> lista = null;
        private static readonly string DIF_POL_EST = string.Format(ConstantesUtil.COD_DIF_POL_REP, "EST");
        private static readonly string DIF_POL_MAQ = string.Format(ConstantesUtil.COD_DIF_POL_REP, "MAQ");


        protected ValoresReparacionesWebForm()
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

                    var result = _clienteConfiguracion.ObtenerPoliticaPorcodigo(Serializador.SerializeEntity(new ClaseBasica { IdString = DIF_POL_EST }));

                    politica = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<PoliticasCorporativas>(result) : null;

                    if (politica != null)
                    {
                        txtValorEstructura.Text = politica.NumericValueUno.ToString();
                        checkEstadoEstructura.Checked = politica?.Estado == true;
                    }

                    result = _clienteConfiguracion.ObtenerPoliticaPorcodigo(Serializador.SerializeEntity(new ClaseBasica { IdString = DIF_POL_MAQ }));

                    politica = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<PoliticasCorporativas>(result) : null;

                    if (politica != null)
                    {
                        txtValorMaquinaria.Text = politica.NumericValueUno.ToString();
                        checkEstadoMaquinaria.Checked = politica?.Estado == true;
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

                var valEstructura = txtValorEstructura.Text.Trim();
                var valMaquinaria = txtValorMaquinaria.Text.Trim();

                if (string.IsNullOrEmpty(valEstructura))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El valor a restar para Estructura es obligatorio");
                    esValido = false;
                }

                if (string.IsNullOrEmpty(valMaquinaria))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, string.Empty, "El valor a restar para Maquinaria es obligatorio");
                    esValido = false;
                }

                if (!string.IsNullOrEmpty(valEstructura) && !ValidacionesUtil.ValidarNumeros(valEstructura))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Valor Estructura", ConstantesUtil.mensajeFormatoNumericoIncorrecto);
                    esValido = false;
                }

                if (!string.IsNullOrEmpty(valMaquinaria) && !ValidacionesUtil.ValidarNumeros(valMaquinaria))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_WARNING, "Valor Maquinaria", ConstantesUtil.mensajeFormatoNumericoIncorrecto);
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

                var result = _clienteConfiguracion.ObtenerPoliticaPorcodigo(Serializador.SerializeEntity(new ClaseBasica { IdString = DIF_POL_EST }));


                if (!string.IsNullOrEmpty(result))
                {
                    politica = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<PoliticasCorporativas>(result) : null;
                    if (politica != null)
                    {
                        politica.NumericValueUno = Decimal.Parse(txtValorEstructura.Text);
                        politica.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                        politica.CampoIpUsuario = GestionUtil.IpCliente;
                        politica.Estado = checkEstadoEstructura.Checked;

                        _clienteConfiguracion.ModificarPolitica(Serializador.SerializeEntity(politica));
                    }
                }
                else
                {
                    politica = new PoliticasCorporativas
                    {
                        Codigo = DIF_POL_EST,
                        Nombre = string.Format(ConstantesUtil.NOM_POL_REP, "EST"),
                        Descripcion = string.Format(ConstantesUtil.DESC_POL_REP, "EST"),
                        Grupo = string.Format(ConstantesUtil.GR_POL, "DIF"),
                        CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula,
                        CampoIpUsuario = GestionUtil.IpCliente,
                        Estado = checkEstadoEstructura.Checked
                    };
                    _clienteConfiguracion.InsertarPolitica(Serializador.SerializeEntity(politica));
                }

                result = _clienteConfiguracion.ObtenerPoliticaPorcodigo(Serializador.SerializeEntity(new ClaseBasica { IdString = DIF_POL_MAQ }));


                if (!string.IsNullOrEmpty(result))
                {
                    politica = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<PoliticasCorporativas>(result) : null;
                    if (politica != null)
                    {
                        politica.NumericValueUno = Decimal.Parse(txtValorMaquinaria.Text);
                        politica.CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula;
                        politica.CampoIpUsuario = GestionUtil.IpCliente;
                        politica.Estado = checkEstadoEstructura.Checked;

                        _clienteConfiguracion.ModificarPolitica(Serializador.SerializeEntity(politica));
                    }
                }
                else
                {
                    politica = new PoliticasCorporativas
                    {
                        Codigo = DIF_POL_EST,
                        Nombre = string.Format(ConstantesUtil.NOM_POL_REP, "MAQ"),
                        Descripcion = string.Format(ConstantesUtil.DESC_POL_REP, "MAQ"),
                        Grupo = string.Format(ConstantesUtil.GR_POL, "DIF"),
                        CampoCedulaUsuario = GestionUtil.UsuarioSesion.Cedula,
                        CampoIpUsuario = GestionUtil.IpCliente,
                        Estado = checkEstadoEstructura.Checked
                    };
                    _clienteConfiguracion.InsertarPolitica(Serializador.SerializeEntity(politica));
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