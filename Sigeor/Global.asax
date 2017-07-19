<%@ Application Language="C#" %>
<%@ Import Namespace="Negocio.Job" %>
<%@ Import Namespace="Negocio.Reportes" %>
<%@ Import Namespace="Sigeor.Utilidades" %>
<%@ Import Namespace="Negocio.Configuracion" %>
<%@ Import Namespace="PersistenciaSigeor" %>
<%@ Import Namespace="Negocio.Utilidades" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="System.Threading" %>

<script RunAt="server">



    void Application_Start(object sender, EventArgs e)
    {
        //Code that runs on application startup
        EjecutarJob.EjecutarProceso();
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
    }




    void Application_AcquireRequestState(object sender, EventArgs e)
    {
       
    }

    void Application_AuthorizeRequest(object sender, EventArgs e)
    {
        // Response.Write("Authorizing request...<br>");
    }

    void Application_PostRequestHandlerExecute(object sender, EventArgs e)
    {
        // Response.Write("Request handler executed...<br>");
    }

    void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
        // Response.Write("Request handler executed...<br>");
    }

    void Application_PreSendRequestContent(object sender, EventArgs e)
    {
        // Response.Write("Receiving request content...<br>");
    }

    void Application_PreSendRequestHeaders(object sender, EventArgs e)
    {
        //Response.Write("Receiving request headers...<br>");
    }

    void Application_ReleaseRequestState(object sender, EventArgs e)
    {
        // Response.Write("Releasing request state...<br>");
    }

    void Application_ResolveRequestCache(object sender, EventArgs e)
    {
        // Response.Write("Resolving request cache...<br>");
    }

    void Application_UpdateRequestCache(object sender, EventArgs e)
    {
        // Response.Write("Updating request cache...<br>");
    }

    void Session_Start(object sender, EventArgs e)
    {
    }

    void Application_BeginRequest(object sender, EventArgs e)
    {
        HttpContext.Current.Response.AddHeader("p3p", "CP=\"IDC DSP COR ADM DEVi TAIi PSA PSD IVAi IVDi CONi HIS OUR IND CNT\"");
        //if (!HttpContext.Current.Request.IsAuthenticated)
        //{
        //    HttpContext.Current.Response.Redirect("/Autenticacion/Login.aspx");
        //    //FormsAuthentication.RedirectToLoginPage();
        //}


        try
        {
            //List<String> lista = PerfilNegocio.PerfilesSession();
            /*   if (HttpContext.Current.Session!=null)
               {
               string cedulausuario = HttpContext.Current.Session["Usuario"].ToString();
               }   */


        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }

    }

    void Application_EndRequest(object sender, EventArgs e)
    {
        //Response.Write("Request is ending...<br>");
    }


    protected void Application_OnEndRequest()
    {
        //Response.Write("<hr>This page was served at " +
        //  DateTime.Now.ToString());
    }

    protected void Application_Error(Object sender, EventArgs e)
    {
        //Response.Write("<font face=\"Tahoma\" size=\"2\" color=\"red\">");
        //Response.Write("Oops! Looks like an error occurred!!<hr></font>");
        //Response.Write("<font face=\"Arial\" size=\"2\">");
        //Response.Write(Server.GetLastError().Message.ToString());
        //Response.Write("<hr>" + Server.GetLastError().ToString());
        //Server.ClearError();

    }

    void Session_End(Object sender, EventArgs e)
    {
        if (Session["Usuario"] != null)
        {
            try
            {
                var usuario = Session["Usuario"] as Usuario;
                Sigeor.GestionConfiguracionServiceReference.ConfiguracionServiceClient _clienteConfiguracion =
                    new Sigeor.GestionConfiguracionServiceReference.ConfiguracionServiceClient();

                var auditoria = new Auditoria
                {
                    Id = Guid.NewGuid(),
                    Cedula = usuario.Cedula,
                    CodigoTipo = "AUTOLOGOUT",
                    IdObjeto = usuario.Cedula,
                    NombreTabla = string.Empty,
                    NombreCampo = string.Empty,
                    Ip = usuario.CampoIpUsuario,
                    Descripcion = "LOGOUT AUTOMATICO"
                };
                _clienteConfiguracion.InsertarAuditoria(Serializador.SerializeEntity(auditoria));
                //Response.Write("Alert('Su sesión a caducado, será redireccionado </br> a la página de Login.')");
                //Trace.WriteLine("Alert('Su sesión a caducado, será redireccionado </br> a la página de Login.')");
                //Server.ClearError();
                //Server.Transfer("/Autenticacion/SesionExpirada.aspx");
                //RegisterRoutes(RouteTable.Routes);
                //RouteTable.Routes.MapPageRoute("Key", "Home", "~/Public/Pages/Default.aspx");

                //System.Web.UI.Page mypage = (System.Web.UI.Page)HttpContext.Current.Handler;
                //StringBuilder script = new StringBuilder();
                //script.Append("<script language=javascript>alert('test')");
                //script.Append(";</");
                //script.Append("script>");

                //mypage.RegisterStartupScript("alert", script.ToString());



            }
            catch (Exception)
            {

            }
        }

        //Session.Remove("Usuario");
        //Session.Remove("ListaCoordenadas");
    }
    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
    }

</script>
