<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SesionExpirada.aspx.cs"
    Inherits="Sigeor.Autenticacion.SessionExpirada" %>

<%@ Register TagPrefix="asp" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: #FFFFFF !important;>
<head id="Head1" runat="server">
    <title>SIGEOR - Login</title>
    <link href="../Resources/Styles/LoginStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/Styles/CargandoLoginStyle.css" rel="stylesheet"
        type="text/css" />
    <script type='text/javascript' src="../Resources/Scripts/jquery.js"></script>
    <script type='text/javascript'>
        $(document).ready(function () {
            $(document)[0].oncontextmenu = function () { return false; }

        });
    </script>

    <script type='text/javascript'>       
            function maximize() {
            window.top.location.href = window.location.href;
            window.parent.location.href = window.location.href;
            window.top.location.replace(window.location.href);
        }
    </script>

</head>
<body>
    <%--<asp:Image ID="imgLogo" ImageUrl="../Resources/Imagenes/Logo/logo_innovaciones.png" runat="server"
        CssClass="logo" />--%>
    <form autocomplete="on" id="formLogin" runat="server" onload="Load_SessionExpirada">
        <asp:ScriptManager ID="ScriptManagerLogin" runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="divContenedor">
                    <br />
                    <div class="divLogin">
                        <br />
                        <h1 id="tituloLogin">SU SESION A EXPIRADO
                        </h1>
                        Por favor, vuelva a ingresar al sistema.
                    </div>
                    <div>
                        <asp:LinkButton runat="server" OnClick="OnClick">Ir a Login</asp:LinkButton>
                        <p>
                            &nbsp;
                        </p>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
