<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfiguracionEmailWebForm.aspx.cs"
    Inherits="Sigeor.Configuracion.ConfiguracionEmailWebForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Configuración Email</title>

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
                        <div class="panel-heading">
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
                <div class="container" style="width: 50%; margin-top: 7%">
                    <div class="form-group">
                        <asp:Label class="control-label col-sm-2" runat="server">
                        Email:</asp:Label>
                        <div class="col-sm-10">
                            <asp:TextBox autocomplete="off" ID="emailTxt" runat="server" CssClass="form-control" placeholder="Ejem: notificaciones@sbclegacy.com" />
                        </div>
                    </div>
                    <div class="form-group" style="margin-top: 20px;">
                        <asp:Label class="control-label col-sm-2" for="hostTxt" runat="server">
                        Host:</asp:Label>
                        <div class="col-sm-10">
                            <asp:TextBox autocomplete="off" ID="hostTxt" runat="server" CssClass="form-control" placeholder="Ejem: smtp.sbclegacy.com" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="control-label col-sm-2" for="puertoTxt" runat="server">
                        Puerto:</asp:Label>
                        <div class="col-sm-10">
                            <asp:TextBox autocomplete="off" ID="puertoTxt" runat="server" CssClass="form-control" placeholder="Ejem: 587" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="control-label col-sm-2" for="passwordTxt" runat="server">
                        Password:</asp:Label>
                        <div class="col-sm-10">
                            <asp:TextBox autocomplete="off" ID="passwordTxt" TextMode="Password" runat="server" CssClass="form-control"
                                placeholder="Password" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="control-label col-sm-2" for="confirmPasswordTxt" runat="server">
                        Confirmar Password:</asp:Label>
                        <div class="col-sm-10">
                            <asp:TextBox autocomplete="off" ID="confirmPasswordTxt" TextMode="Password" runat="server" CssClass="form-control"
                                placeholder="Confirmar Password" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" CssClass="chzn-default" ID="enableSsl" Text=" Habilitar SSL" />
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-offset-8 col-sm-4">
                        <asp:Button ID="testButton" runat="server" CssClass="btn btn-primary" Text="Test" OnClick="testButton_OnClick" />
                        &nbsp;
                    <asp:Button ID="aceptarButton" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="aceptarButton_OnClick" />
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
