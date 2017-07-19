<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuControl.aspx.cs" Inherits="Sigeor.Menu.MenuControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menú Control</title>

    <link href="../Resources/Styles/MenuStyle.css" rel="stylesheet" type="text/css" />
    <script type='text/javascript' src="../Resources/Scripts/jquery.js"></script>
    <link href="../Resources/Bootstrap/css/EstilosAdicionales.css" rel="stylesheet" />
    <script src="../Resources/Scripts/Utilidades.js" type="text/javascript"></script>

</head>
<body>
    <link href="../Resources/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/Bootstrap/css/bootstrap-theme.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Resources/Bootstrap/MultiSelect/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="../Resources/Bootstrap/MultiSelect/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <script src="../Resources/Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../Resources/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Resources/Styles/CargandoStyle.css" rel="stylesheet" type="text/css" />
    <form autocomplete="on" id="form1" runat="server" style="width: 90%; float: right; height: 99%;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <script type="text/javascript">

            ModalPanel();
            window.Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            window.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            BeginRequestHandler(End);
            EndRequestHandler(End);

        </script>

        <asp:UpdatePanel runat="server" ID="MenuConfiguracionUpdatePanel">
            <ContentTemplate>
                <div id="panel">
                    <ul id="menu">
                        <%-- style="margin-left: 5%; margin-top: 3%; margin-right: 2%; margin-bottom: 2%;">--%>
                        <li>
                            <div id="estructura" runat="server">
                                <asp:ImageButton ID="imgEstructura" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Estructura.png"
                                    PostBackUrl="#subEstructura" Class="image" OnClick="OnClickEventControl" />
                                <br />
                                <asp:Label runat="server" Text="Estimados Estructura" Font-Size="Large" ForeColor="#337AB7" />
                            </div>
                            <div id="subEstructura" class="sub" runat="server">
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkCalculoEstructura" ToolTip="Estimación Eor Estructura" runat="server"
                                    OnClick="OnClickNavegacion" Text="Estimación Eor Estructura"></asp:LinkButton>
                                <br />
                                <br />

                            </div>
                        </li>
                        <li>
                            <div id="maquinaria" runat="server">
                                <asp:ImageButton ID="imgMaquinaria" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Maquinaria.png"
                                    PostBackUrl="#subMaquinaria" Class="image" OnClick="OnClickEventControl" />
                                <br />
                                <asp:Label runat="server" Text="Estimados Maquinaria" Font-Size="Large" ForeColor="#337AB7" />
                            </div>
                            <div id="subMaquinaria" class="sub" runat="server">
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkCalculoMaquinaria" Text="Estimación Eor Maquinaria" ToolTip="Estimación Eor Maquinaria" runat="server"
                                    OnClick="OnClickNavegacion" />
                                <br />
                                <br />
                            </div>
                        </li>
                        <li>
                            <div id="danos" runat="server">
                                <asp:ImageButton ID="imgCalculoTransito" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Estructura.png"
                                    PostBackUrl="#subTransito" Class="image" OnClick="OnClickEventControl" />
                                <br />

                                <asp:Label runat="server" Text="Estimados Tránsito" Font-Size="Large" ForeColor="#337AB7" />

                            </div>
                            <div id="subTransito" class="sub" runat="server">
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkCalculoTransito" Text="Estimación Eor Tránsito" ToolTip="Gestión de Daños" runat="server" OnClick="OnClickNavegacion" />
                                <br />
                                <br />
                            </div>
                        </li>

                        <li>
                            <div id="reparacion" runat="server">
                                <asp:ImageButton ID="imgReparacion" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Reparacion.png"
                                    PostBackUrl="#subReparacion" Class="image" OnClick="OnClickEventControl" />
                                <br />

                                <asp:Label runat="server" Text="Daños / Reparaciones" Font-Size="Large" ForeColor="#337AB7" />
                            </div>
                            <div id="subReparacion" class="sub" runat="server">
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkReparaciones" Text="Gestión de Reparaciones" ToolTip="Gestión de Reparaciones" runat="server"
                                    OnClick="OnClickNavegacion" />
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkDanos" Text="Gestión de Daños" ToolTip="Gestión de Daños" runat="server" OnClick="OnClickNavegacion" />
                            </div>
                        </li>
                        <li>
                            <div id="repositorio" runat="server">
                                <asp:ImageButton ID="imgRepositorio" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Repositorio.png"
                                    PostBackUrl="#subRepositorio" Class="image" OnClick="OnClickEventControl" />
                                <br />
                                <asp:Label runat="server" Text="Repositorio Documental" Font-Size="Large" ForeColor="#337AB7" />
                            </div>
                            <div id="subRepositorio" class="sub" runat="server">
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkDocumental" Text="Gestión Documental" ToolTip="Gestión Documental" runat="server"
                                    OnClick="OnClickNavegacion" />
                                <br />
                                <br />
                            </div>
                        </li>
                        <li>
                            <div id="negociaciones" runat="server">
                                <asp:ImageButton ID="imgNegociaciones" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Negocio.png"
                                    PostBackUrl="#subNegociaciones" Class="image" OnClick="OnClickEventControl" />
                                <br />
                                <asp:Label runat="server" Text="Negociaciones" Font-Size="Large" ForeColor="#337AB7" />
                            </div>
                            <div id="subNegociaciones" class="sub" runat="server">
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkGestionProveedor" Text="Gestión Proveedores" ToolTip="Gestión Proveedores"
                                    runat="server" OnClick="OnClickNavegacion" />
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkNegociacionLinea" Text="Negociaciones por Líneas" ToolTip="Negociaciones por Líneas" runat="server"
                                    OnClick="OnClickNavegacion" />
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkNegociacionProveedor" Text="Negociaciones por Proveedores" ToolTip="Negociaciones por Proveedores"
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
