<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuReportes.aspx.cs" Inherits="Sigeor.Menu.MenuReportes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Menú Reportes</title>

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

    <form autocomplete="on"  id="form1" runat="server" style="width: 90%; float: right; height: 99%;">

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
                        <li>
                            <div id="repEIR" runat="server">
                                <asp:ImageButton ID="imgRepEir" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Reporte EIR.png"
                                    PostBackUrl="#subrepEIR" Class="image" OnClick="OnClickEventReportes" ToolTip="Reportes EIR" />
                                <br />
                                <asp:Label runat="server" Text="Reportes EIR" Font-Size="Large" ForeColor="#337AB7" />
                            </div>
                            <div id="subRepEir" class="sub" runat="server">
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkEir" ToolTip="Reporte EIR" Text="Reporte EIR" runat="server" OnClick="OnClickNavegacion" />
                            </div>

                        </li>
                        <li>
                            <div id="repEor" runat="server">
                                <asp:ImageButton ID="imgRepEor" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Reporte PTI.png"
                                    PostBackUrl="#subRepEor" Class="image" OnClick="OnClickEventReportes" ToolTip="Reportes EOR" />
                                <br />

                                <asp:Label runat="server" Text="Reportes EOR" Font-Size="Large" ForeColor="#337AB7" />
                            </div>
                            <div id="subRepEor" class="sub" runat="server">
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkCabEst" ToolTip="EOR Por Estructura" Text="EOR Por Estructura" runat="server" OnClick="OnClickNavegacion" />
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkCabMaq" ToolTip="EOR Por Maquinaria" Text="EOR Por Maquinaria" runat="server" OnClick="OnClickNavegacion" />
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkCabTran" ToolTip="EOR Por Transito" Text="EOR Por Transito" runat="server" OnClick="OnClickNavegacion" />
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkConsolidado" ToolTip="Consolidado EOR's" Text="Consolidado EOR's" runat="server" OnClick="OnClickNavegacion" />
                                <br />
                            </div>
                        </li>
                        <li>
                            <div id="repPti" runat="server">
                                <asp:ImageButton ID="imgRepPti" runat="server" ImageUrl="../Resources/Imagenes/SubMenus/Reporte EOR.png"
                                    PostBackUrl="#subRepPti" Class="image" OnClick="OnClickEventReportes" ToolTip="Reportes PTI" />
                                <br />
                                <asp:Label runat="server" Text="Reportes PTI" Font-Size="Large" ForeColor="#337AB7" />
                            </div>
                            <div id="subRepPti" class="sub" runat="server">
                                <br />
                                <br />
                                <asp:LinkButton ID="hlinkPti" ToolTip="Reporte PTI" Text="Reporte PTI" runat="server" OnClick="OnClickNavegacion" />
                            </div>
                        </li>
                    </ul>
                </div>
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


