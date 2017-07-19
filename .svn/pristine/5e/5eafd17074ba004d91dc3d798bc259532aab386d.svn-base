using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text;
using AjaxControlToolkit;
using PersistenciaSigeor;
using System.Globalization;
using Negocio.Seguridad;
using Negocio.Utilidades;
using Sigeor.GestionConfiguracionServiceReference;
using System.Net.Sockets;
using System.Threading;

namespace Sigeor.Utilidades
{
    public class GestionUtil
    {
        /// <summary>
        /// Carga una de registros que sirve para elegir la cantidad de registros a visualizar en el GridView
        /// </summary>
        /// <returns>List<ClaseBasica></returns>
        public static List<ClaseBasica> CargarNumeroRegistrosGridView()
        {
            List<ClaseBasica> listaNumRegistros = new List<ClaseBasica>();

            listaNumRegistros.Add(new ClaseBasica { IdInt = 10, Descripcion = "10" });
            listaNumRegistros.Add(new ClaseBasica { IdInt = 20, Descripcion = "20" });
            listaNumRegistros.Add(new ClaseBasica { IdInt = 50, Descripcion = "50" });
            listaNumRegistros.Add(new ClaseBasica { IdInt = 100, Descripcion = "100" });
            listaNumRegistros.Add(new ClaseBasica { IdInt = 300, Descripcion = "300" });
            listaNumRegistros.Add(new ClaseBasica { IdInt = 500, Descripcion = "500" });
            listaNumRegistros.Add(new ClaseBasica { IdInt = 1000, Descripcion = "1000" });

            return listaNumRegistros;
        }

        /// <summary>
        /// Permite visualizar mensajes despues de realizar una acción
        /// </summary>
        /// <param name="paginaActual">Página donde se va a procesar el mensaje.</param>
        /// <param name="tipoMensaje">El mensaje puede ser Success, Info, Warning y Error. </param>
        /// <param name="objetoActual">El nombre del objeto visualizar, puede ser vacio. </param>
        /// <param name="mensaje">El contenido del mensaje.</param>
        public static void MostrarNotificacion(Page paginaActual, string tipoMensaje, string objetoActual, string mensaje)
        {
            string mensajeScript = string.Empty;// "<script language='javascript'>";
            mensaje = string.Format(mensaje, objetoActual);
            switch (tipoMensaje)
            {
                case "Success":
                    {
                        mensajeScript += "MostrarMensajeSuccess('" + mensaje + "');";
                    }
                    break;
                case "Info":
                    {
                        mensajeScript += "MostrarMensajeInfo('" + mensaje + "');";
                    }
                    break;
                case "Warning":
                    {
                        mensajeScript += "MostrarMensajeWarning('" + mensaje + "');";
                    }
                    break;
                case "Error":
                    {
                        mensajeScript += "MostrarMensajeError('" + mensaje + "');";
                    }
                    break;
            }
            ScriptManager.RegisterClientScriptBlock(paginaActual, typeof(Page), mensajeScript, mensajeScript, true);
        }

        /// <summary>
        /// Visualiza el modal panel creado en bootsptrap
        /// </summary>
        /// <param name="paginaActual">Página Actual</param>
        public static void MostrarModal(Page paginaActual)
        {
            ScriptManager.RegisterStartupScript(paginaActual, paginaActual.GetType(), "MostrarModal", "MostrarModal();", true);
        }

        /// <summary>
        /// Oculta el modal panel creado en bootsptrap
        /// </summary>
        /// <param name="paginaActual">Página Actual</param>
        public static void OcultarModal(Page paginaActual)
        {
            ScriptManager.RegisterStartupScript(paginaActual, paginaActual.GetType(), "OcultarModal", "OcultarModal();", true);
        }

        public static void OcultarModal(Page paginaActual, string nombreModalPanel)
        {
            ScriptManager.RegisterStartupScript(paginaActual, paginaActual.GetType(), nombreModalPanel, nombreModalPanel + "();", true);
        }

        public static void VerReporte(Page page, string idReporte, string valueFiltro)
        {
            try
            {
                HttpContext.Current.Session[string.Concat(idReporte, "Value")] = valueFiltro;
                var urlCompleta = string.Concat(ConstantesUtil.URL_VISOR_REPORTES, string.Concat("?Id=", idReporte));
                //ScriptManager.RegisterStartupScript(page, page.GetType(), string.Concat("Reporte", urlCompleta), "window.open('" + urlCompleta + "','_newtab');", true);
                ScriptManager.RegisterStartupScript(page, page.GetType(), string.Concat("Reporte", urlCompleta), "window.open('" + urlCompleta + "','" + idReporte + "');", true);
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(page, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo generar el reporte");
            }
        }

        #region INICIO DE GENERACION ALEATORIA DE CADENA ALFANUMERICA
        /// <summary>
        /// Genera una clave alfanumérica de manera aleatoria.
        /// </summary>
        /// <param name="length">Longitud de la clave a generar</param>
        /// <returns></returns>
        public static string GenerarClave(int longitud)
        {
            var chars = "abcdefghijkmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, longitud)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }


        #endregion FIN DE GENERACION ALEATORIA DE CADENA ALFANUMERICA

        private static SmtpClient ConfigurarEmail(string email, string host, int puerto, string password, bool ssl)
        {
            SmtpClient smtpClient = null;
            try
            {
                smtpClient = new SmtpClient
                {
                    Credentials = new NetworkCredential(email, password),
                    Port = puerto,
                    Host = host,
                    EnableSsl = ssl
                };
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo configurar el email: " + ex, EventLogEntryType.Error);
            }
            return smtpClient;
        }

        public static void TestEnviarEmail(string email, string host, int puerto, string password, bool ssl, string bodyMessage, bool mensajeEsHtml)
        {
            try
            {
                var mensajeEmail = new MailMessage
                {
                    BodyEncoding = Encoding.UTF8,
                    IsBodyHtml = mensajeEsHtml,
                    To = { email },
                    Subject = "Sistema SIGEOR - Email de Prueba ",
                    SubjectEncoding = Encoding.UTF8,
                    From =
                        new MailAddress(email, "Sistema de Gestión de EORs - SIGEOR / Prueba Mail",
                            Encoding.UTF8),
                    Body = bodyMessage
                };
                ConfigurarEmail(email, host, puerto, password, ssl).Send(mensajeEmail);

            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo enviar el email de prueba a " + email + " " + ex, EventLogEntryType.Error);
            }
        }



        /// <summary>
        /// Configuración de Email con datos almacenados.
        /// Retorna el Smtpclient configurado con los datos obtenidos desde la base de datos.
        /// </summary>
        /// <returns>SmtpClient</returns>
        private static SmtpClient ConfigurarEmailAlmacenado()
        {
            SmtpClient smtpClient = null;
            try
            {
                var clienteConfiguracion = new ConfiguracionServiceClient();

                var configuracionSerializado = clienteConfiguracion.ObtenerConfiguracionEmail();

                Email configuracion = !string.IsNullOrEmpty(configuracionSerializado) ? Serializador.DeSerializeEntity<Email>(configuracionSerializado) : null;

                if (configuracion != null)
                {
                    smtpClient = ConfigurarEmail(configuracion.DirEMail, configuracion.Host, configuracion.Puerto,
                      MetodosEncriptacion.DesencriptarBase64(configuracion.Password), configuracion.Ssl);
                }

            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo configurar el email: " + ex, EventLogEntryType.Error);
            }
            return smtpClient;
        }

        private static void EnviarEmailBase(MailMessage mensaje, bool mensajeEsHtml)
        {
            try
            {
                var clienteConfiguracion = new ConfiguracionServiceClient();

                var configuracionSerializado = clienteConfiguracion.ObtenerConfiguracionEmail();

                Email configuracion = !string.IsNullOrEmpty(configuracionSerializado) ? Serializador.DeSerializeEntity<Email>(configuracionSerializado) : null;

                if (configuracion != null)
                {
                    mensaje.SubjectEncoding = Encoding.UTF8;
                    mensaje.BodyEncoding = Encoding.UTF8;
                    mensaje.IsBodyHtml = mensajeEsHtml;
                    mensaje.From = new MailAddress(configuracion.DirEMail, "SIGEOR", System.Text.Encoding.UTF8);
                    ConfigurarEmailAlmacenado().Send(mensaje);
                }
            }
            catch (Exception ex)
            {
                var first = mensaje.To.FirstOrDefault();
                Log.WriteEntry("No se pudo enviar el email a " + first.Address + " " + ex, EventLogEntryType.Error);
            }
        }


        /// <summary>
        /// Envía un email de recuperacion de clave.
        /// </summary>
        /// <param name="emailUsuario">Email destinatario</param>
        /// <param name="claveGenerada">Clave Generada por el Sistema</param>
        /// <returns></returns>
        public static void EnviarEmail(string emailUsuario, string claveGenerada, string cedula, string nombreUsuario)
        {
            MailMessage msg = new MailMessage();
            try
            {

                msg.To.Add(emailUsuario);

                msg.Subject = "SIGEOR - Clave Generada";

                msg.SubjectEncoding = Encoding.UTF8;

                StringBuilder mensaje = new StringBuilder();

                mensaje.Append("<html>");
                mensaje.Append("<head>");
                mensaje.Append("</head>");
                mensaje.Append("<body>");
                mensaje.Append("<div align = 'center'>");
                mensaje.Append("<p><h4>CREDENCIALES PARA INGRESAR AL SISTEMA</h4></p>");
                mensaje.Append("</div>");
                mensaje.Append("<br/>");
                mensaje.Append("<br/>");
                mensaje.Append("<p>Estimado(a) ");
                mensaje.Append(nombreUsuario);
                mensaje.Append(",</p>");
                mensaje.Append("<p>Las credenciales de acceso para el Sistema SIGEOR son las siguientes: </p>");
                mensaje.Append("<p> Usuario: ");
                mensaje.Append(cedula);
                mensaje.Append("</p>");
                mensaje.Append("<p> Contraseña: ");
                mensaje.Append(claveGenerada);
                mensaje.Append("</p>");
                mensaje.Append(
                    "<p>Recuerde que esta contraseña es provisional, se solicitará cambiarla la próxima vez que ingrese al sistema.</p>");
                mensaje.Append("</body>");
                mensaje.Append("</html>");

                msg.Body = mensaje.ToString();

                EnviarEmailBase(msg, true);
            }
            catch (Exception ex)
            {
                Log.WriteEntry("Error al  enviar el email al recuperar la clave para: " + msg.To.FirstOrDefault().Address + ex, EventLogEntryType.Error);                
            }
        }

        /// <summary>
        /// Envía un email de creación de usuario.
        /// </summary>
        /// <param name="emailUsuario">Email destinatario</param>
        /// <param name="claveGenerada">Clave Generada por el Sistema</param>
        /// <param name="nombreUsuario">Nombre de usuario generado</param>
        /// <returns></returns>
        public static void EnviarEmail(string emailUsuario, string claveGenerada, string cedula, string nombreUsuario, List<CoordenadasEkey> listaCoordenadasEkey)
        {

            MailMessage msg = new MailMessage();

            try
            {
                StringBuilder mensaje = new StringBuilder();

                mensaje.Append("<!DOCTYPE html>");
                mensaje.Append("<html>");
                mensaje.Append("<head>");
                mensaje.Append("</head>");
                mensaje.Append("<body>");
                mensaje.Append("<div align = 'center'>");
                mensaje.Append("<p><h4>CREDENCIALES PARA INGRESAR AL SISTEMA</h4></p>");
                mensaje.Append("</div>");
                mensaje.Append("<br/>");
                mensaje.Append("<br/>");
                mensaje.Append("<p>Estimado(a) ");
                mensaje.Append(nombreUsuario);
                mensaje.Append(",</p>");
                mensaje.Append("<p>Las credenciales de acceso para el Sistema SIGEOR son las siguientes: </p>");
                mensaje.Append("<p> Usuario: ");
                mensaje.Append(cedula);
                mensaje.Append("</p>");
                mensaje.Append("<p>Contraseña: ");
                mensaje.Append(claveGenerada);
                mensaje.Append("</br>");
                mensaje.Append("<p>Su tabla de coordenadas E-Key es: </p>");
                mensaje.Append("</br>");
                mensaje.Append("</br>");
                mensaje.Append("</br>");
                mensaje.Append("<Div align='center'>");
                mensaje.Append("<table style=\"border-collapse:collapse;\">");
                mensaje.Append("<tr>");
                mensaje.Append("<td style=\"border:1px solid black; width:30px;\">     </td>");

                foreach (var item in ConstantesUtil.LETRAS)
                {
                    mensaje.Append("<th style=\"border:1px solid black;height:20px;width:30px;\">");
                    mensaje.Append(item);
                    mensaje.Append("</th>");
                }
                mensaje.Append("</tr>");

                foreach (var digito in ConstantesUtil.DIGITOS)
                {
                    mensaje.Append("<tr >");
                    mensaje.Append("<th style=\"border:1px solid black;height:20px;width:30px;\">");
                    mensaje.Append(digito.ToString());
                    mensaje.Append("</th>");
                    foreach (var letra in ConstantesUtil.LETRAS)
                    {
                        var valor = listaCoordenadasEkey.Find(ent => ent.CoordenadaX.Equals(letra.ToString()) && ent.CoordenadaY.Equals(digito.ToString())).Valor;
                        mensaje.Append("<td style=\"border:1px solid black;height:20px;width:30px;padding-left:10px;\">");
                        mensaje.Append(valor);
                        mensaje.Append("</td>");
                    }
                    mensaje.Append("</tr>");
                }
                mensaje.Append("</table>");
                mensaje.Append("</Div>");
                mensaje.Append("</body>");
                mensaje.Append("</html>");


                msg.To.Add(emailUsuario);

                msg.Subject = "Nuevo Usuario";


                msg.Body = mensaje.ToString();

                EnviarEmailBase(msg, true);
            }

            catch (Exception ex)
            {
                Log.WriteEntry("Error al  enviar el email al crear el usuario: " + nombreUsuario + ex, EventLogEntryType.Error);                
            }
        }

        /// <summary>
        /// Envía un email de recuperación de E-Key.
        /// </summary>
        /// <param name="emailUsuario">Email destinatario</param>
        /// /// <param name="List<CoordenadasEkey>">Coordenadas E-Key generadas</param>
        /// <returns></returns>
        public static void EnviarEmail(string emailUsuario, string cedula, string nombreUsuario, List<CoordenadasEkey> listaCoordenadasEkey)
        {

            MailMessage msg = new MailMessage();

            try
            {
                StringBuilder mensaje = new StringBuilder();

                mensaje.Append("<!DOCTYPE html>");
                mensaje.Append("<html>");
                mensaje.Append("<head>");
                mensaje.Append("</head>");
                mensaje.Append("<body>");
                mensaje.Append("<div align = 'center'>");
                mensaje.Append("<p><h4>CREDENCIALES PARA INGRESAR AL SISTEMA</h4></p>");
                mensaje.Append("</div>");
                mensaje.Append("<br/>");
                mensaje.Append("<br/>");
                mensaje.Append("<p>Estimado(a): ");
                mensaje.Append(nombreUsuario);
                mensaje.Append(",</p>");
                mensaje.Append("</br>");
                mensaje.Append("<p>Se ha generado sus nuevas coordenadas E-Key: ");
                mensaje.Append("</p>");
                mensaje.Append("<div align='center'>");
                mensaje.Append("<table style=\"border-collapse:collapse;\">");
                mensaje.Append("<tr>");
                mensaje.Append("<td style=\"border:1px solid black; width:30px;\">     </td>");

                foreach (var item in ConstantesUtil.LETRAS)
                {
                    mensaje.Append("<th style=\"border:1px solid black;height:20px;width:30px;\">");
                    mensaje.Append(item);
                    mensaje.Append("</th>");
                }
                mensaje.Append("</tr>");

                foreach (var digito in ConstantesUtil.DIGITOS)
                {
                    mensaje.Append("<tr >");
                    mensaje.Append("<th style=\"border:1px solid black;height:20px;width:30px;\">");
                    mensaje.Append(digito.ToString());
                    mensaje.Append("</th>");
                    foreach (var letra in ConstantesUtil.LETRAS)
                    {
                        var valor = listaCoordenadasEkey.Find(ent => ent.CoordenadaX.Equals(letra.ToString()) && ent.CoordenadaY.Equals(digito.ToString())).Valor;
                        mensaje.Append("<td style=\"border:1px solid black;height:20px;width:30px;padding-left:10px;\">");
                        mensaje.Append(valor);
                        mensaje.Append("</td>");
                    }
                    mensaje.Append("</tr>");
                }
                mensaje.Append("</table>");
                mensaje.Append("</Div>");
                mensaje.Append("</body>");
                mensaje.Append("</html>");

                msg.To.Add(emailUsuario);

                msg.Subject = "Coordenadas Ekey";


                msg.Body = mensaje.ToString();
                EnviarEmailBase(msg, true);
            }

            catch (Exception ex)
            {
                Log.WriteEntry("Error al  enviar el email al recuperar coordenadas para el usuario: " + nombreUsuario + ex, EventLogEntryType.Error);                
            }
        }


        /// <summary>
        /// Genera numeros aleatorios en el tablero de botones de un formulario
        /// </summary>
        /// <param name="page">Página Actual</param>
        public static void GenerarNumerosBotones(Page page)
        {
            try
            {
                Random random = new Random();

                List<int> listaNumeros = new List<int>();
                int numeroBoton = 0;
                while (listaNumeros.Count != 10)
                {
                    var numero = random.Next(0, 10);

                    if (listaNumeros.Count(num => num.Equals(numero)) == 0)
                    {
                        Control control = page.FindControl("boton" + numeroBoton.ToString());
                        Button boton = (Button)control;
                        boton.Text = numero.ToString();
                        listaNumeros.Add(numero);
                        numeroBoton++;
                    }

                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ConstantesUtil.NOTIFICACION_ERROR + "No se pudo generar los botones en la pantalla "+ page.NamingContainer +" " + ex, EventLogEntryType.Error);
                MostrarNotificacion(page, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo generar los botones en la pantalla ");
            }
        }


        //       REALIZAN LA GENERACION DE COORDENADAS
        #region GENERACION DE COORDENADAS

        public static List<String> ListaCoordenadas
        {
            set { HttpContext.Current.Session["ListaCoordenadas"] = value; }
            get
            {
                if (HttpContext.Current.Session["ListaCoordenadas"] == null)
                    HttpContext.Current.Session["ListaCoordenadas"] = new List<String>();
                object result = HttpContext.Current.Session["ListaCoordenadas"];
                var lista = (List<String>)result;
                return lista.Count > 10 ? new List<string>() : lista;
            }
        }

        public static string CoordenadaX
        {
            set
            {
                HttpContext.Current.Session["CoordenadaX"] = value;
            }
            get
            {
                return HttpContext.Current.Session["CoordenadaX"] != null ? HttpContext.Current.Session["CoordenadaX"].ToString() : string.Empty;
            }
        }

        public static string CoordenadaY
        {
            set
            {
                HttpContext.Current.Session["CoordenadaY"] = value;
            }
            get
            {
                return HttpContext.Current.Session["CoordenadaY"] != null ? HttpContext.Current.Session["CoordenadaY"].ToString() : string.Empty;
            }
        }

        /// <summary>
        /// Genera un caracter aleatorio para la coordenada
        /// </summary>
        /// <param name="opcion">Puede ser L para generar una Letra y N para generar un Número</param>
        private static string GenerarCaracterCoordenada(char opcion)
        {
            Random random = new Random();
            var chars = opcion.Equals('L') ? ConstantesUtil.LETRAS : opcion.Equals('N') ? ConstantesUtil.DIGITOS : string.Empty;

            var result = new string(
                Enumerable.Repeat(chars, 1)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;

        }

        public static void GenerarCoordenadasLogin(TextBoxWatermarkExtender marcaAgua)
        {
            CoordenadaX = GenerarCaracterCoordenada('L');
            CoordenadaY = GenerarCaracterCoordenada('N');
            marcaAgua.WatermarkText = CoordenadaX + " " + CoordenadaY;
        }

        public static void GenerarCoordenadasLogin(TextBox coordenadaEkeyGenerada)
        {
            string result = string.Empty;
            do
            {
                CoordenadaX = GenerarCaracterCoordenada('L');
                CoordenadaY = GenerarCaracterCoordenada('N');
                coordenadaEkeyGenerada.Attributes["placeholder"] = CoordenadaX + @" " + CoordenadaY;
                result = ListaCoordenadas.Find(ent => ent.Equals(coordenadaEkeyGenerada.Attributes
                    ["placeholder"]));
            } while (!string.IsNullOrEmpty(result));
            ListaCoordenadas.Add(coordenadaEkeyGenerada.Attributes["placeholder"]);
        }


        #endregion GENERACION DE COORDENADAS

        public static Usuario UsuarioSesion
        {
            get
            {
                var usuario = (Usuario)(HttpContext.Current.Session["Usuario"] ?? new Usuario());
                if (string.IsNullOrEmpty(usuario.Cedula))
                    RedireccionarSesionExpirada();

                return usuario;
            }
        }

        private static string FormatearIp(string ip)
        {
            if (ip.Equals("::1"))
                ip = "127.0.0.1";
            return ip;
        }

        public static string IpCliente
        {

            get
            {

                var variable = HttpContext.Current.Request.ServerVariables["REMOTE_HOST"];
                var direccionIp = string.Empty;

                if (direccionIp != null)
                {
                    direccionIp = variable.ToString();
                    if (direccionIp.Equals("::1"))
                        direccionIp = FormatearIp(direccionIp);
                }


                //if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                //{
                //    direccionIp = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                //}
                //else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
                //{
                //    direccionIp = HttpContext.Current.Request.UserHostAddress;
                //}


                return direccionIp;
            }


        }


        public static string MenuSeleccionado
        {
            get
            {
                var menu = HttpContext.Current.Session["MenuSeleccionado"];
                if (menu == null)
                    RedireccionarSesionExpirada();

                return menu.ToString();
            }
            set
            {
                HttpContext.Current.Session["MenuSeleccionado"] = value;
            }
        }


        public static void RedireccionarSesionExpirada()
        {
            //GestionUtil.Redireccionar(ConstantesUtil.URL_SESION_EXPIRADA);

            var direccionIp = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
            var puerto = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            var aplicacion = HttpContext.Current.Request.ServerVariables["APPL_MD_PATH"];

            var direccionCompleta = string.Empty;


            if (direccionIp != null)
            {
                var app = aplicacion.ToString().Split('/');
                direccionIp = FormatearIp(direccionIp.ToString());
                direccionCompleta = "http://" + direccionIp + ":" + puerto + "/" + app.ToList().LastOrDefault() + "/Autenticacion/SesionExpirada.aspx";
            }


            //HttpContext.Current.Response.RedirectLocation = direccionCompleta;           
            HttpContext.Current.Response.Redirect(direccionCompleta, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public static void RedireccionarLogin()
        {
            GestionUtil.Redireccionar(ConstantesUtil.URL_LOGIN);
        }


        public static void AplicarFocoBusqueda(Page paginaActual, TextBox buscarTextBox)
        {
            try
            {
                ScriptManager.RegisterStartupScript(paginaActual,
                  paginaActual.GetType(),
                  Guid.NewGuid().ToString(),
                  string.Format("var texto = document.getElementById('{0}');" +
                                "texto.selectionStart = texto.value.length;" +
                                "texto.selectionEnd = texto.value.length;" +
                                "texto.focus();", buscarTextBox.ClientID), true);
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ConstantesUtil.NOTIFICACION_ERROR + " pagina " + paginaActual.NamingContainer + " " + ex, EventLogEntryType.Error);
                MostrarNotificacion(paginaActual, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PRERENDER);
            }
        }

        public static string ConvertirStringToDivisa(decimal number)
        {
            var numero = "0";
            try
            {

                numero = "$" + number.ToString("N", new CultureInfo("is-IS"));
            }
            catch (Exception ex)
            {
                Log.WriteEntry("Error al convertir el número a divisa: " + ex, EventLogEntryType.Error);
            }
            return numero;
        }

        public static void ControlAccesoPerfil(string usuario, string pagina)
        {
            try
            {
                Autorizacion auth = new Autorizacion();
                pagina = pagina.Replace("/Sigeor", string.Empty);

                if (string.IsNullOrEmpty(usuario))
                    GestionUtil.RedireccionarSesionExpirada();
                else
                if (auth.ValidacionAcceso(usuario, pagina) != 1)
                    Redireccionar(ConstantesUtil.URL_ACCESO_NEGADO);
            }
            catch (Exception ex)
            {
                Log.WriteEntry("Error al verificar el acceso del usuario: " + usuario + " a la página: " + pagina + "  " + ex, EventLogEntryType.Error);
            }


        }


        public static void Redireccionar(string pagina)
        {
            try
            {
                if (pagina.Contains(@"/"))
                {
                    pagina = pagina.Replace("/Sigeor", string.Empty);
                    pagina = pagina.Replace("..", "~");
                }

                HttpContext.Current.Response.Redirect(pagina, false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                Log.WriteEntry("Error al cambiar de página: " + pagina + "  " + ex, EventLogEntryType.Error);
            }

        }


        public static string tituloPagina(string pagina)
        {
            pagina = pagina.Replace("/Sigeor", string.Empty);
            ConfiguracionServiceClient _clienteConfiguracion = new ConfiguracionServiceClient();
            //if (HttpContext.Current.Session["TituloMenu"] != null && !string.IsNullOrEmpty(HttpContext.Current.Session["TituloMenu"].ToString()))
            //{
            //    return HttpContext.Current.Session["TituloMenu"].ToString();
            //}
            //else 
            return _clienteConfiguracion.ObtenerTituloPorPagina(pagina); ;
        }

        public static string FormateraFecha(string fecha)
        {
            string fechaFormateada = string.Empty;
            try
            {
                fecha = fecha.Replace("/", "-");
                var date = DateTime.ParseExact(fecha, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                fechaFormateada = new DateTime(date.Year, date.Month, date.Day).ToShortDateString();
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo formatear la fecha: " + fecha + "  " + ex, EventLogEntryType.Error);
            }
            return fechaFormateada;
        }

        public static string VerificarPaginaActual(string txtPaginaActual)
        {
            var pagina = txtPaginaActual;
            try
            {
                if (pagina.Contains(","))
                    pagina = pagina.Split(',').ToList().LastOrDefault();
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo verificar la pagina Actual: " + txtPaginaActual + "  " + ex, EventLogEntryType.Error);
            }

            return pagina;
        }


    }
}