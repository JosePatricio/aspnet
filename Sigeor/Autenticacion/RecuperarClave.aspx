<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarClave.aspx.cs"
    Inherits="Sigeor.Autenticacion.RecuperarClave" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SIGEOR - Recuperar Clave</title>
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
        <%--<img id="profile-img" class="logo" src="../Resources/Imagenes/Logo/logo_innovaciones.png" />--%>
        <h1 id="tituloLogin">
            <asp:Label runat="server" Text="RECUPERAR  CONTRASEÑA" ForeColor="White" />
        </h1>

        <form autocomplete="on" id="principalform" runat="server" style="width: 100%; height: 100%;" onload="Load_Form"
            onprerender="principalform_OnPreRender" method="post">
            <asp:ScriptManager runat="server" />
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
                    <div class="cuadroLogin">

                        <br />
                        <asp:TextBox autocomplete="off" ID="EmailTxtBox" runat="server" CssClass="form-control" placeholder="Email"
                            MaxLength="30" EnableViewState="True">
                        </asp:TextBox>
                        <asp:TextBox autocomplete="off" ID="EKeyTxtBox" runat="server" CssClass="form-control" TextMode="Password"
                            MaxLength="3" EnableViewState="True" ReadOnly="True">
                        </asp:TextBox>
                        <div id="divBotones">
                            <asp:Button ID="boton0" runat="server" OnClick="botonNumero_Click" />
                            <asp:Button ID="boton1" runat="server" OnClick="botonNumero_Click" />
                            <asp:Button ID="boton2" runat="server" OnClick="botonNumero_Click" />
                            <asp:Button ID="boton3" runat="server" OnClick="botonNumero_Click" />
                            <asp:Button ID="boton4" runat="server" OnClick="botonNumero_Click" />
                            <asp:Button ID="boton5" runat="server" OnClick="botonNumero_Click" />
                            <asp:Button ID="boton6" runat="server" OnClick="botonNumero_Click" />
                            <asp:Button ID="boton7" runat="server" OnClick="botonNumero_Click" />
                            <asp:Button ID="boton8" runat="server" OnClick="botonNumero_Click" />
                            <asp:Button ID="botonBorrar" runat="server" Text="Borrar" Width="98.5px" OnClick="botonNumero_Click" />
                            <asp:Button ID="boton9" runat="server" OnClick="botonNumero_Click" />
                        </div>
                        <div class="divContraseña">
                            <asp:Button ID="botonAcceder" runat="server" Text="Enviar" OnClick="ButAcceder_Click" />
                            <br />
                            <br />
                            <br />
                            <asp:LinkButton ID="linkContrasena" runat="server" OnClick="irLogin_Click">Ir a página Login</asp:LinkButton>
                        </div>
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
    </div>
</body>
</html>
