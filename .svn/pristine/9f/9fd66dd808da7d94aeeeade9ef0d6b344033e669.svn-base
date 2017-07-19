<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sigeor.Autenticacion.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SIGEOR - Login</title>
    
    <link href="../Resources/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/Bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <script src="../Resources/Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../Resources/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Resources/Styles/jquery.toastmessage.css" rel="stylesheet" />
    <script src="../Resources/Scripts/jquery.toastmessage.js" type="text/javascript"></script>
    <link href="../Resources/Styles/CargandoStyle.css" rel="stylesheet" />
    <link href="../Resources/Styles/LoginStyle.css" rel="stylesheet" type="text/css" />    
</head>
<body>

    <div class="card card-container">

        <%--<img alt="Logo" id="profile-img" class="logo" src="../Resources/Imagenes/Logo/logo_innovaciones.png" />--%>

        <p id="profile-name" class="profile-name-card"></p>

        <form autocomplete="on" id="principalform" class="form-signin" runat="server" onload="Load_Login" onprerender="principalform_OnPreRender" method="post">


            <asp:ScriptManager ID="ScriptManagerLogin" runat="server" />
            <script type="text/javascript">
                window.Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
                window.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

                function BeginRequestHandler(sender, args) {
                    $("#myLoading").modal('show');
                }
                function EndRequestHandler(sender, args) {
                    $("#myLoading").modal('hide');
                    $(".modal-backdrop").hide();
                }
            </script>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <span id="reauth-email" class="reauth-email"></span>

                    <br />
                    <asp:TextBox autocomplete="off" ID="UsuarioTxtBox" runat="server" CssClass="form-control" placeholder="Usuario"
                        required EnableViewState="True" MaxLength="10" />
                    <asp:TextBox autocomplete="off" ID="ContrasenaTxtBox" runat="server" CssClass="form-control" placeholder="Contraseña"
                        MaxLength="30" EnableViewState="True" TextMode="Password" />
                    <asp:TextBox autocomplete="off" ID="EKeyTxtBox" runat="server" CssClass="form-control" placeholder="Contraseña"
                        MaxLength="3" EnableViewState="True" TextMode="Password" ReadOnly="True" />

                    <br />

                    <div align="center" id="divBotones">
                        <asp:Button ID="boton0" CssClass="forgot-password" runat="server" OnClick="botonNumero_Click" />
                        <asp:Button ID="boton1" CssClass="forgot-password" runat="server" OnClick="botonNumero_Click" />
                        <asp:Button ID="boton2" CssClass="forgot-password" runat="server" OnClick="botonNumero_Click" />
                        <asp:Button ID="boton3" CssClass="forgot-password" runat="server" OnClick="botonNumero_Click" />
                        <asp:Button ID="boton4" CssClass="forgot-password" runat="server" OnClick="botonNumero_Click" />
                        <asp:Button ID="boton5" CssClass="forgot-password" runat="server" OnClick="botonNumero_Click" />
                        <asp:Button ID="boton6" CssClass="forgot-password" runat="server" OnClick="botonNumero_Click" />
                        <asp:Button ID="boton7" CssClass="forgot-password" runat="server" OnClick="botonNumero_Click" />
                        <asp:Button ID="boton8" CssClass="forgot-password" runat="server" OnClick="botonNumero_Click" />
                        <asp:Button ID="boton9" CssClass="forgot-password" runat="server" OnClick="botonNumero_Click" />
                        <asp:Button ID="botonBorrar" CssClass="forgot-password" runat="server" Text="Borrar" Width="98.5px" OnClick="botonNumero_Click" />
                    </div>
                    <div class="divContraseña">
                        <asp:Button ID="botonAcceder" runat="server" Text="Acceder" CssClass="forgot-password" OnClick="ButAcceder_Click" />
                        <br />
                        <br />
                        <br />
                        <asp:LinkButton ID="linkContrasena" runat="server" CssClass="forgot-password" OnClick="Contrasena_Click">Olvidaste tu contraseña?</asp:LinkButton>
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>

            <div id="myLoading" class="modal fade" style="pointer-events: none; margin-top: 20%;">
                <div class="modal-sm ">
                    <div class="modal-content cargandoPaginas">
                        <center>
                            <h5 style="text-align: center;">Procesando...</h5>
                            <img alt="Procesando" src="../Resources/Imagenes/Paginas/ajax-loader.gif" />
                        </center>
                    </div>
                </div>
            </div>


        </form>
        <!-- /form -->

    </div>
    <!-- /card-container -->

</body>
</html>
