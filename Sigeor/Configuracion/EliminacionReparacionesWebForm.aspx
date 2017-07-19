<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminacionReparacionesWebForm.aspx.cs"
    Inherits="Sigeor.Configuracion.EliminacionReparacionesWebForm" MaintainScrollPositionOnPostback="true" Culture="es-EC" %>

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

    <form autocomplete="on"  id="principalForm" runat="server" style="width: 100%; height: 100%;" onprerender="principalForm_OnPreRender">
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

                    <div class="row" style="width: 90%;">
                        <div class="form-group">
                            <div class="col-sm-2">
                                <asp:Label class="control-label" runat="server" Text="REP. ESTRUCTURA" Font-Bold="True" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Label class="control-label" runat="server" Text="FECHA INICIO: " />
                            </div>
                            <div class="col-sm-2">
                                <asp:TextBox autocomplete="off"  ID="txtFecIniEst" CssClass="calendar" class="form-control" runat="server" ReadOnly="true" />
                                <ajaxToolkit:CalendarExtender ID="calendarExtender6" TargetControlID="txtFecIniEst"
                                    runat="server" CssClass="btn-default" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Label class="control-label" runat="server" Text="FECHA FIN: " />
                            </div>
                            <div class="col-sm-2">
                                <asp:TextBox autocomplete="off"  ID="txtFecFinEst" CssClass="calendar" class="form-control" runat="server" ReadOnly="true" />
                                <ajaxToolkit:CalendarExtender ID="calendarExtender7" TargetControlID="txtFecFinEst"
                                    runat="server" CssClass="btn-default" />
                            </div>
                            <div class="col-sm-1">
                                <asp:Label class="control-label" runat="server" Text="ESTADO: " />
                            </div>
                            <div class="col-sm-1">
                                <asp:CheckBox Width="10%" runat="server" ID="checkEstadoEstructura"
                                    AutoPostBack="true" />

                                <ajaxToolkit:ToggleButtonExtender runat="server" TargetControlID="checkEstadoEstructura"
                                    UnCheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png" CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png"
                                    ImageHeight="16" ImageWidth="16" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <hr style="color: #333333; height: 0.2px; background-color: #333333;" />
                        </div>
                    </div>
                    <br />
                    <div class="row" style="width: 90%;">
                        <div class="form-group">
                            <div class="col-sm-2">
                                <asp:Label class="control-label" runat="server" Text="REP. MAQUINARIA" Font-Bold="True" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Label class="control-label" runat="server" Text="FECHA INICIO: " />
                            </div>
                            <div class="col-sm-2">
                                <asp:TextBox autocomplete="off"  ID="txtFecIniMaq" CssClass="calendar" class="form-control" runat="server" ReadOnly="true" />
                                <ajaxToolkit:CalendarExtender ID="calendarExtender1" TargetControlID="txtFecIniMaq"
                                    runat="server" CssClass="btn-default" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Label class="control-label" runat="server" Text="FECHA FIN: " />
                            </div>
                            <div class="col-sm-2">
                                <asp:TextBox autocomplete="off"  ID="txtFecFinMaq" CssClass="calendar" class="form-control" runat="server" ReadOnly="true" />
                                <ajaxToolkit:CalendarExtender ID="calendarExtender8" TargetControlID="txtFecFinMaq"
                                    runat="server" CssClass="btn-default" />
                            </div>
                            <div class="col-sm-1">
                                <asp:Label class="control-label" runat="server" Text="ESTADO: " />
                            </div>
                            <div class="col-sm-1">
                                <asp:CheckBox Width="10%" runat="server" ID="checkEstadoMaquinaria"
                                    AutoPostBack="true" />

                                <ajaxToolkit:ToggleButtonExtender runat="server" TargetControlID="checkEstadoMaquinaria"
                                    UnCheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png" CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png"
                                    ImageHeight="16" ImageWidth="16" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <hr style="color: #333333; height: 0.2px; background-color: #333333;" />
                        </div>
                    </div>
                    <br />
                    <div class="row" style="width: 90%;">
                        <div class="form-group">
                            <div class="col-sm-2">
                                <asp:Label class="control-label" runat="server" Text="REP. TRANSITO" Font-Bold="True" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Label class="control-label" runat="server" Text="FECHA INICIO: " />
                            </div>
                            <div class="col-sm-2">
                                <asp:TextBox autocomplete="off"  ID="txtFecIniTran" CssClass="calendar" class="form-control" runat="server" ReadOnly="true" />
                                <ajaxToolkit:CalendarExtender ID="calendarExtender2" TargetControlID="txtFecIniTran"
                                    runat="server" CssClass="btn-default" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Label class="control-label" runat="server" Text="FECHA FIN: " />
                            </div>
                            <div class="col-sm-2">
                                <asp:TextBox autocomplete="off"  ID="txtFecFinTran" CssClass="calendar" class="form-control" runat="server" ReadOnly="true" />
                                <ajaxToolkit:CalendarExtender ID="calendarExtender3" TargetControlID="txtFecFinTran"
                                    runat="server" CssClass="btn-default" />
                            </div>
                            <div class="col-sm-1">
                                <asp:Label class="control-label" runat="server" Text="ESTADO: " />
                            </div>
                            <div class="col-sm-1">
                                <asp:CheckBox Width="10%" runat="server" ID="checkEstadoTransito"
                                    AutoPostBack="true" />

                                <ajaxToolkit:ToggleButtonExtender runat="server" TargetControlID="checkEstadoTransito"
                                    UnCheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png" CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png"
                                    ImageHeight="16" ImageWidth="16" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <hr style="color: #333333; height: 0.2px; background-color: #333333;" />
                        </div>
                    </div>


                    <br />
                    <div class="col-sm-offset-11 col-sm-">
                        <%--<asp:Button ID="testButton" runat="server" CssClass="btn btn-primary" Text="Test Email" OnClick="testButton_OnClick" />--%>

                        <asp:Button ID="aceptarButton" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="aceptarButton_OnClick" />
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
