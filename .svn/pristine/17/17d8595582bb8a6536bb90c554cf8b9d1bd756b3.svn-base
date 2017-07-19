<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuConfiguracion.aspx.cs"
    Inherits="Sigeor.Menu.MenuConfiguracion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Menú Configuración</title>
    <link href="../Resources/Styles/MenuStyle.css" rel="stylesheet" type="text/css" />
    <script type='text/javascript' src="../Resources/Scripts/jquery.js"></script>
    <link href="../Resources/Bootstrap/css/EstilosAdicionales.css" rel="stylesheet" />
    <script src="../Resources/Scripts/Utilidades.js" type="text/javascript"></script>

</head>
<body>
    <link href="../Resources/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/Bootstrap/css/bootstrap-theme.min.css" rel="stylesheet"
        type="text/css" />
    <script src="../Resources/Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../Resources/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Resources/Styles/CargandoStyle.css" rel="stylesheet" type="text/css" />
    <form autocomplete="on"  id="formReportes" runat="server" style="width: 90%; float: right; height: 100%;">
        <asp:ScriptManager runat="server" />

        <script type="text/javascript">
            ModalPanel();
            window.Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            window.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            BeginRequestHandler(End);
            EndRequestHandler(End);
        </script>

        <asp:UpdatePanel runat="server" ID="MenuConfiguracionUpdatePanel">
            <ContentTemplate>
                <div id="panel" style="width: 100%; text-align: center;">

                    <ul id="menu">
                        <li>
                            <div id="divUser" runat="server">
                                <asp:ImageButton ID="imgUser" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Usuario.png"
                                    PostBackUrl="#subUser" CssClass="image" OnClick="OnClickEventConfiguracion" />
                                <br />
                                <asp:Label runat="server" Text="Usuarios" Font-Size="Large" ForeColor="#337AB7" />
                            </div>
                            <div id="subUser" class="sub" runat="server">
                                <br />
                                <br />
                                <asp:LinkButton ID="User" Text="Gestión de Usuarios" ToolTip="Gestión de Usuario" runat="server" OnClick="OnClickNavegacion" />
                                <br />
                            </div>
                        </li>
                        <li>
                            <div id="perfil" runat="server">
                                <asp:ImageButton ID="imgPerfil" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Perfil.png"
                                    PostBackUrl="#subPerfil" CssClass="image" OnClick="OnClickEventConfiguracion" />
                                <br />
                                <asp:Label runat="server" Text="Perfiles" Font-Size="Large" ForeColor="#337AB7" />
                            </div>
                            <div id="subPerfil" class="sub" runat="server">
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkPerfil" Text="Gestión de Perfiles" ToolTip="Gestión de Perfiles" runat="server" OnClick="OnClickNavegacion" />
                                <br />

                            </div>
                        </li>
                        <li>
                            <div id="alertas" runat="server">
                                
                                <asp:ImageButton ID="imgAlertas" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Alerta.png"
                                    PostBackUrl="#subAlertas" CssClass="image" OnClick="OnClickEventConfiguracion" ToolTip="Configuración de Alertas" />
                                <br />
                                <asp:Label runat="server" Text="Alertas" Font-Size="Large" ForeColor="#337AB7" />
                            </div>

                        </li>
                        <li>
                            <div id="auditoria" runat="server">
                                <asp:ImageButton ID="imgAuditoria" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Auditoria.png"
                                    PostBackUrl="#subAuditoria" CssClass="image" OnClick="OnClickEventConfiguracion" />
                                <br />
                                <asp:Label runat="server" Text="Auditorías" Font-Size="Large" ForeColor="#337AB7" />
                            </div>
                            <div id="subAuditoria" class="sub" runat="server">
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkAuditoria" Text="Auditorías del Sistema" ToolTip="Auditorías por Usuario" runat="server"
                                    OnClick="OnClickNavegacion" />
                                <br />
                                <br />
                            </div>
                        </li>
                        <li>
                            <div id="documental" runat="server">
                                <asp:ImageButton ID="imgDocumental" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Documentos.png"
                                    PostBackUrl="#subDocumental" CssClass="image" OnClick="OnClickEventConfiguracion" />
                                <br />

                                <asp:Label runat="server" Text="Repositorio Documental" Font-Size="Large" ForeColor="#337AB7" />
                            </div>
                            <div id="subDocumental" class="sub" runat="server">
                                <br />
                                <br />
                                <asp:LinkButton ID="hlynkAlmacenamiento" Text="Configuración de Almacenamiento" ToolTip="Configuración de Almacenamiento"
                                    runat="server" OnClick="OnClickNavegacion" />
                                <br />
                            </div>
                        </li>
                        <li>
                            <div id="confEmail" runat="server">
                                <asp:ImageButton ID="imgEmail" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Configuraciones.png"
                                    PostBackUrl="#subConfEmail" CssClass="image" OnClick="OnClickEventConfiguracion" />
                                <br />

                                <asp:Label runat="server" Text="Configuraciones Generales" Font-Size="Large" ForeColor="#337AB7" />
                            </div>
                            <div id="subConfEmail" class="sub" runat="server">
                                <br />
                                <br />
                                <asp:LinkButton ID="hlynkConfiguracionEmail" Text="Configuración de Email" ToolTip="Configuración de Email"
                                    runat="server" OnClick="OnClickNavegacion" />
                                <br />
                                <br />
                                 <asp:LinkButton ID="hlynkDifValoresRep" Text="Configuración del Proceso" ToolTip="Valores a restar automáticamente en las reparaciones."
                                    runat="server" OnClick="OnClickNavegacion" />
                                
                                <br />
                                <br />
                                <asp:LinkButton ID="hlynkEliminacionRep" Text="Eliminaciones Automáticas" ToolTip="Configura un rango de fechas para eliminar reparaciones automáticamente"
                                    runat="server" OnClick="OnClickNavegacion" />
                               

                            </div>
                        </li>
                    </ul>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="myLoading" class="modal fade" style="pointer-events: none; margin-top: 20%;">
            <div class="modal-dialog modal-sm ">
                <div class="modal-content cargandoPaginas">
                    <center>
                        <h5 style="text-align: center;">Procesando...</h5>
                        <img alt="Procesando" src="../Resources/Imagenes/Paginas/ajax-loader.gif" />
                    </center>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
