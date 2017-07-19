<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Sigeor.Principal" %>

<!DOCTYPE html >
<html>
<head id="Head1" runat="server">
    <title>SIGEOR - Sistema de Gestión de EOR's</title>

    <script type='text/javascript' src="../Resources/Scripts/jquery.js"> </script>
    <link href="../Resources/Bootstrap/css/EstilosGridView.css" rel="stylesheet" />
    <link href="../Resources/Bootstrap/css/EstilosAdicionales.css" rel="stylesheet" />
    <script src="../Resources/Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <link href="../Resources/Styles/Utilidades.css" rel="stylesheet" />
    <script src="../Resources/Scripts/Utilidades.js" type="text/javascript"></script>


    <script type="text/javascript">
        RestringirMouse();
    </script>


</head>
<body style="background: #eaeaea;">
    <link href="../Resources/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/Bootstrap/css/bootstrap-theme.min.css" rel="stylesheet"
        type="text/css" />
    <script src="../Resources/Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../Resources/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Resources/Styles/jquery.toastmessage.css" rel="stylesheet" />
    <script src="../Resources/Scripts/jquery.toastmessage.js" type="text/javascript"></script>


    <form autocomplete="on" id="formPrincipal" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManagerPrincipal" runat="server" />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container-fluid" style="height: 70px; background-color: #eaeaea; border-color: #337ab7;">
                    <div class="row-fluid">

                        <div class="panel-heading">
                            <div class="col-xs-12">
                                <div class="col-xs-2 col-xs-offset-1">
                                    <div id="home" class="text-center">
                                        <asp:LinkButton ID="homeLink" runat="server" Text="Home" OnClick="OnClickEvent" Style="text-decoration: none;"
                                            ToolTip="Ir a Menú Dashboard">
                                    <img id="home1" src="../Resources/Imagenes/Menu/Home.png" alt="Home" height="70px" />
                                    <br />
                                        <asp:Label ForeColor="#337ab7" runat="server" Text="Dashboard" Font-Bold="true" />
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-xs-2">
                                    <div id="control" class="text-center">
                                        <asp:LinkButton ID="controlLink" runat="server" Text="Control" OnClick="OnClickEvent"
                                            Style="text-decoration: none;" ToolTip="Ir a Menú Control">
                                    <img id="control1" src="../Resources/Imagenes/Menu/Monitor.png" alt="Control"
                                    height="70px" >
                                    <br/>
                                         <asp:Label ForeColor="#337ab7" runat="server" Text="Control" Font-Bold="true" />
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-xs-2">
                                    <div id="reporte" class="text-center">
                                        <asp:LinkButton ID="reportsLink" runat="server" Text="Reportes" OnClick="OnClickEvent"
                                            Style="text-decoration: none;" ToolTip="Ir a Menú Reportes">
                                    <img id="reporte1" src="../Resources/Imagenes/Menu//Reports.png" alt="Reportes"
                                    height="70" />
                                    <br />
                                    <asp:Label ForeColor="#337ab7" runat="server" Text="Reportes" Font-Bold="true" />

                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-xs-2">
                                    <div id="alerta" class="text-center">

                                        <asp:LinkButton ID="alertLink" runat="server" Text="Alertas" OnClick="OnClickEvent"
                                            Style="text-decoration: none;" ToolTip="Ir a Menú Alertas">
                                            <img id="alerta1" src="../Resources/Imagenes/Menu/Alert.png" alt="Alertas"
                                                height="70px" />
                                            <br />
                                            <asp:Label ForeColor="#337ab7" runat="server" Text="Alertas" Font-Bold="true" />
                                            <span class="badge">
                                                <asp:Label ID="lblNotificaciones" runat="server" /></span>
                                        </asp:LinkButton>
                                        <%--<a href="#rightpanel3">
                                            <span class="badge">
                                                <asp:Label ID="lblNotificaciones" runat="server" /></span>
                                        </a>--%>
                                    </div>
                                </div>
                                <div class="col-xs-2">
                                    <div id="configuracion" class="text-center">
                                        <asp:LinkButton ID="confLink" runat="server" Text="Configuración" OnClick="OnClickEvent"
                                            Style="text-decoration: none;" ToolTip="Ir a Menú Configuración">
                                    <img id="configuracion1" src="../Resources/Imagenes/Menu/Configuration.png" alt="Configuracion"
                                    height="70px" />
                                    <br/>
                                        <asp:Label ForeColor="#337ab7" runat="server" Text="Configuración" Font-Bold="true" />
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="contenido">
                    <iframe id="iframeContenido" scrolling="auto" runat="server" style="border-style: inset;"
                        width="100%" height="100%"></iframe>
                </div>

                <div class="navbar-fixed-bottom text-center small" style="height: 35px; width: 100%; background-color: white !important; border-color: red !important;">
                    <div class="col-xs-2">
                        <a href="http://www.innovaciones.ec" target="_blank">
                            <%--<img id="imglogoPrincipal" src="../Resources/Imagenes/Logo/logo_innovaciones.png" alt="Logo" width="150px"
                                height="35px" />--%>
                        </a>
                    </div>
                    <div class="col-xs-8">
                        <asp:Label ID="lblUsuario" runat="server" Height="35px" ForeColor="#337ab7" />
                    </div>

                    <div class="col-xs-2" style="horiz-align: right;">
                        <asp:LoginStatus ID="LoginStatus1" Height="36px" OnLoggingOut="LoginStatus1_OnLoggingOut"
                            ToolTip="Salir del Sistema" LogoutImageUrl="~/Resources/Imagenes/Menu/Exit.png"
                            runat="server" />
                        &nbsp;
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Resources/Imagenes/Menu/Help.png"
                        Height="36px" ToolTip="Ayuda" />&nbsp;
                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Resources/Imagenes/Menu/Information.png"
                        Height="36px" ToolTip="Acerca de" />
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

</body>
</html>


