<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValoresReparacionesWebForm.aspx.cs"
    Inherits="Sigeor.Configuracion.ValoresReparacionesWebForm" MaintainScrollPositionOnPostback="true" Culture="es-EC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Eliminación de Reparaciones</title>

    <link href="../Resources/Styles/CheckBoxHeaderStyle.css" rel="stylesheet"
        type="text/css" />
    <script type='text/javascript' src="../Resources/Scripts/jquery.js"> </script>
    <link href="../Resources/Bootstrap/css/EstilosGridView.css" rel="stylesheet" />
    <link href="../Resources/Styles/Utilidades.css" rel="stylesheet" />
    <script src="../Resources/Scripts/Utilidades.js" type="text/javascript"></script>


</head>
<body>

    <link href="../Resources/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/Bootstrap/css/bootstrap-theme.min.css" rel="stylesheet"
        type="text/css" />
    <script src="../Resources/Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../Resources/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Resources/Styles/jquery.toastmessage.css" rel="stylesheet" />
    <script src="../Resources/Scripts/jquery.toastmessage.js" type="text/javascript"></script>
    <link href="../Resources/Styles/CargandoStyle.css" rel="stylesheet" type="text/css" />

    <form autocomplete="on" id="principalForm" runat="server" style="width: 100%; height: 100%;" onprerender="principalForm_OnPreRender">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" EnableScriptLocalization="True" />

        <script type="text/javascript">
            ModalPanel();
            window.Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            window.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            BeginRequestHandler(End);
            EndRequestHandler(End);
        </script>

        <asp:UpdatePanel ID="GridViewUpdatePanel" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div class="containerPrueba" style="width: 100%; height: 100%;">
                    <div class="panel panel-primary" style="width: 100%;">
                        <div class="panel-heading" >
                            <table id="Table1" width="100%" runat="server">
                                <tr id="Tr1" style="border: 1px" runat="server">
                                    <td id="Td1" runat="server">
                                        <h4>
                                            <asp:Label ID="lblCabecera" runat="server"></asp:Label>
                                        </h4>
                                    </td>
                                    <td id="Td2" align="right" runat="server">
                                        <table id="Table2" runat="server">
                                            <tr id="Tr3" runat="server">
                                                <td id="Td4" runat="server">
                                                    <asp:LinkButton ID="RegresarLinkButton" OnClick="OnClickNavegacion" runat="server" CssClass="lblTabla"
                                                        ToolTip="Regresar"><span class="glyphicon glyphicon-circle-arrow-left"></span> Regresar</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="container " align="center" style="margin-top: 5%;">
                    <br />
                    <div class="row" style="width: 90%;">
                        <div class="table-responsive">
                            <table class="table" style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Label class="control-label" runat="server" Text="Valor Estructura:" Font-Bold="True" />
                                    </td>
                                    <td>
                                        <asp:TextBox autocomplete="off" ID="txtValorEstructura" Style="text-align: right;" class="form-control" runat="server"
                                            placeholder="Ejem. 10,00" />
                                    </td>
                                    <td>
                                        <asp:Label class="control-label" runat="server" Text="Estado:" Font-Bold="True" /></td>
                                    <td>
                                        <asp:CheckBox Width="10%" runat="server" ID="checkEstadoEstructura"
                                            AutoPostBack="true" />

                                        <ajaxToolkit:ToggleButtonExtender runat="server" TargetControlID="checkEstadoEstructura"
                                            UnCheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png" CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png"
                                            ImageHeight="16" ImageWidth="16" />
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label class="control-label" runat="server" Text="Valor Maquinaria: " Font-Bold="True" /></td>
                                    <td>
                                        <asp:TextBox autocomplete="off" ID="txtValorMaquinaria" Style="text-align: right;" class="form-control" runat="server"
                                            placeholder="Ejem. 10,00" /></td>
                                    <td>
                                        <asp:Label class="control-label" runat="server" Text="Estado:" Font-Bold="True" /></td>
                                    <td>
                                        <asp:CheckBox Width="10%" runat="server" ID="checkEstadoMaquinaria"
                                            AutoPostBack="true" />

                                        <ajaxToolkit:ToggleButtonExtender runat="server" TargetControlID="checkEstadoMaquinaria"
                                            UnCheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png" CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png"
                                            ImageHeight="16" ImageWidth="16" />                                        
                                    </td>
                                </tr>

                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td align="right">
                                        <asp:Button ID="aceptarButton" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="aceptarButton_OnClick" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>      
    </form>
</body>
</html>
