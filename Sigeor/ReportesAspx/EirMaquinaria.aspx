<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EirMaquinaria.aspx.cs" Inherits="Sigeor.ReportesAspx.EirMaquinaria" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Resources/Styles/EstiloCheckBox/CheckBoxHeaderStyle.css" rel="stylesheet"
        type="text/css" />
    <link href="../Resources/Styles/CargandoStyle.css" rel="stylesheet" type="text/css" />
    <script type='text/javascript' src="../Resources/Scripts/jquery.js"> </script>
    <link href="../Resources/Bootstrap/css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/Bootstrap/css/bootstrap-theme.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Resources/Bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Resources/Bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <script src="../Resources/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Resources/Styles/EstiloHeaderPaginas/HeaderStyle.css" rel="stylesheet"
        type="text/css" />
    <script src="../Resources/Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function MostrarModal() {
            $("#modalPanel").modal('show');
        }

    </script>
    <script type="text/javascript">
        function OcultarModal() {
            $("#modalPanel").modal('hide');
        }
    </script>
    <script type='text/javascript'>
        $(document).ready(function () {

            $(document)[0].oncontextmenu = function () { return false; }

        });
    </script>
    <script type="text/javascript">
        function MostrarMensajeSuccess(mensaje) {
            $().toastmessage('showSuccessToast', mensaje);
        }
        function MostrarMensajeInfo(mensaje) {
            $().toastmessage('showNoticeToast', mensaje);
        }
        function MostrarMensajeWarning(mensaje) {
            $().toastmessage('showWarningToast', mensaje);
        }
        function MostrarMensajeError(mensaje) {
            $().toastmessage('showErrorToast', mensaje);
        }
    </script>
    <script type="text/javascript">
        function RefreshUpdatePanel() {
            //__doPostBack('BuscarTextBox', '');
        };
    </script>
    <script type="text/javascript">
        function ValidaSoloNumeros() {
            if ((event.keyCode < 48) || (event.keyCode > 57))
                event.returnValue = false;
        }
    </script>
    <style type="text/css">
        .calendar {
            background: url(../Resources/images/calendar_gray.png) no-repeat;
            background-position: right;
            display: block;
            width: 100%;
            height: 35px;
            padding: 6px 12px;
            font-size: 12px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
    </style>
</head>
<body>
    <link href="../Resources/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/Bootstrap/css/bootstrap-theme.min.css" rel="stylesheet"
        type="text/css" />
    <script src="../Resources/Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../Resources/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Resources/Styles/jquery.toastmessage.css" rel="stylesheet" />
    <script src="../Resources/Scripts/jquery.toastmessage.js" type="text/javascript"></script>
    <form id="formularioPrincipal" runat="server" style="width: 100%; height: 100%;"
        onprerender="formularioPrincipal_OnPreRender">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" EnableScriptLocalization="True" />
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
        <asp:UpdatePanel ID="GridViewUpdatePanel" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div class="containerPrueba" style="width: 100%; height: 100%;">
                    <div class="panel panel-default" style="border-bottom: 2px solid #c1c1c1; width: 100%;">
                        <div class="panel-heading">
                            <table width="100%" runat="server">
                                <tr style="border: 1px" runat="server">
                                    <td runat="server">
                                        <h3>
                                            <asp:Label ID="lblCabecera" ForeColor="#337ab7" runat="server"></asp:Label>
                                        </h3>
                                    </td>
                                    <td align="center" runat="server">
                                        <table runat="server">
                                            <tr runat="server">
                                                <td runat="server">
                                                    <asp:LinkButton ID="ReporteLinkButton" runat="server" ToolTip="Ver Reporte" OnClick="VerReporte">
                                                    <span class="glyphicon glyphicon-export"></span> Ver Reporte
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server">
                                                    <asp:LinkButton ID="RegresarLinkButton" OnClick="OnClickNavegacion" runat="server"
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
                <div class="container" style="width: 100%;">
                    <div class="row">
                        <div class="panel-group" id="accordion">
                            <div class="panel">
                                <div class="panel-heading btn-default">
                                    <h3 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#filtros">Filtros</a>
                                    </h3>
                                </div>
                                <div id="filtros" class="panel-collapse collapse in">
                                    <div class="panel-body center-block">



                                        <div class="row" style="text-align: right;">
                                            <div class="col-sm-1 col-md-offset-1">
                                                <asp:Label ID="Label1" runat="server" Text="Estado: " CssClass="form-search" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:DropDownList data-placeholder="Elija un Depósito..." runat="server" ID="ddlestado"
                                                    CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label ID="Label5" runat="server" Text="Línea: " />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:DropDownList data-placeholder="Elija una Línea..." runat="server" ID="ddllinea"
                                                    CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label ID="Label7" runat="server" Text="Depósito: " />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:DropDownList data-placeholder="Elija depósito..." runat="server" ID="ddltipodeposito"
                                                    CssClass="form-control" />
                                            </div>

                                            <div class="col-xs-12" style="height: 2px;" />
                                        </div>





                                        <div class="col-md-1 col-md-offset-1">
                                            <asp:Label ID="Label6" runat="server" Text="Agencia: " />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:DropDownList data-placeholder="Elija Tipo de Contenedor..." runat="server" ID="ddlagencia"
                                                CssClass="form-control" />
                                        </div>
                                        <div class="col-md-1">
                                            <asp:Label ID="Label8" runat="server" Text="Fecha: " />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtfechainicio" runat="server" CssClass="calendar" placeholder="Fecha inicio"
                                                BackColor="White" />
                                            <ajaxToolkit:CalendarExtender ID="calendarExtenderInicio" TargetControlID="txtfechainicio" runat="server" CssClass="btn-default" />

                                        </div>
                                        <div class="col-md-1">
                                            <asp:Label ID="Label9" runat="server" Text="Fecha: " />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:TextBox placeholder="Fecha fin" ID="txtfechafin"
                                                runat="server" CssClass="calendar"
                                                BackColor="White" />
                                            <ajaxToolkit:CalendarExtender ID="calendarExtenderFin" TargetControlID="txtfechafin" runat="server" CssClass="btn-default" />

                                        </div>


                                        <div class="row" style="width: 60%; margin: auto; margin-top: auto;">
                                            <div class="input-group">
                                                <asp:TextBox Width="100%" runat="server" ID="BuscarTextBox" CssClass="TextBoxBusqueda form-control"
                                                    TabIndex="1" placeholder="Buscar..." ToolTip="Ingrese el texto buscar." MaxLength="50" />
                                                <span class="input-group-btn" style="horiz-align: left">
                                                    <asp:Button ID="Button1" Style="background-image: url(../Resources/images/find.png); background-position: center; background-repeat: no-repeat;" ToolTip="Buscar"
                                                        runat="server" class=" btn btn-default" OnClick="BuscarButton_OnClick" />
                                                </span>

                                            </div>
                                        </div>
                                    </div>



                                </div>
                            </div>
                        </div>
                    </div>
                </div>





                <br />
                <div class="tab-content" style="padding-top: 20px">
                    <div role="tabpanel" class="tab-pane active" id="eorAretina" align="right">
                        <asp:Panel runat="server" ScrollBars="Auto">

                            <asp:GridView ID="gridEirdeposito" runat="server" AllowSorting="false"
                                CssClass="table table-bordered table-striped  table-condensed table-hover small"
                                OnRowDataBound="PerfilesGridView_RowDataBound" DataKeyNames="ID_EIR"
                                AlternatingRowStyle-BackColor="LightGray" AutoGenerateColumns="false" Width="98%">
                                <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />
                                <EmptyDataTemplate>
                                    No se encontraron registros Disponibles.
                                </EmptyDataTemplate>

                                <Columns>
                                    <asp:TemplateField SortExpression="ID_EIRSort">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" Text="ID EIR" CommandName="Sort" CommandArgument="ID_EIR"
                                                CssClass="lblTabla" />
                                            <br />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#Eval("ID_EIR")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <Columns>
                                    <asp:TemplateField SortExpression="COD_DEPOSITOSort">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" Text="CÓDIGO DE DEPOSITO" CommandName="Sort" CommandArgument="COD_DEPOSITO"
                                                CssClass="lblTabla" />
                                            <br />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#Eval("COD_DEPOSITO")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <Columns>
                                    <asp:TemplateField SortExpression="NOM_LINEASort">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" Text="NOMBRE DE LINEA" CommandName="Sort" CommandArgument="NOM_LINEA"
                                                CssClass="lblTabla" />
                                            <br />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#Eval("NOM_LINEA")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <Columns>
                                    <asp:TemplateField SortExpression="NOMBRE_AGENCIASort">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" Text="NOMBRE DE AGENCIA" CommandName="Sort" CommandArgument="NOMBRE_AGENCIA"
                                                CssClass="lblTabla" />
                                            <br />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#Eval("NOMBRE_AGENCIA")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <Columns>
                                    <asp:TemplateField SortExpression="NUM_CONTAINERSort">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" Text="NÚMERO DE CONTENEDOR" CommandName="Sort" CommandArgument="NUM_CONTAINER"
                                                CssClass="lblTabla" />
                                            <br />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#Eval("NUM_CONTAINER")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <Columns>
                                    <asp:TemplateField SortExpression="NOM_TIPCONTSort">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" Text="NOMBRE DE CONTENDOR" CommandName="Sort" CommandArgument="NOM_TIPCONT"
                                                CssClass="lblTabla" />
                                            <br />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#Eval("NOM_TIPCONT")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <Columns>
                                    <asp:TemplateField SortExpression="ESTADOSort">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" Text="ESTADO" CommandName="Sort" CommandArgument="ESTADO"
                                                CssClass="lblTabla" />
                                            <br />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#Eval("ESTADO")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
                </div>
                <br />
                <div align="center">
                    <nav class="navbar navbar-fixed-bottom" style="height: 0%;" style="vertical-align: central;">
                    <div class="container" style="vertical-align: central;">
                        <div class="pagination" style="vertical-align: central;">
                            <li>
                                <asp:LinkButton runat="server" OnClick="Paginador_OnClick" ID="Inicio" ToolTip="Inicio"><span aria-hidden="true">
                        |<</span> </asp:LinkButton></li>
                            <li>
                                <asp:LinkButton runat="server" OnClick="Paginador_OnClick" ID="Anterior" ToolTip="Anterior"><span aria-hidden="true">
                        <<</span> </asp:LinkButton></li>
                            <li><a href="#"><span aria-hidden="true">Página
                                <asp:TextBox ID="paginaActualTextBox" OnClick="" Width="55px" AutoPostBack="True"
                                    runat="server" MaxLength="7" Text="1" OnTextChanged="paginaActualTextBox_OnTextChanged"
                                    onkeypress="ValidaSoloNumeros();" />
                                de
                                <asp:Label runat="server" ID="totalPaginasLbl" Text="0" />
                                Página(s)</span> </a></li>
                            <li>
                                <asp:LinkButton runat="server" OnClick="Paginador_OnClick" ID="Siguiente"><span
                        aria-hidden="true">>></span> </asp:LinkButton></li>
                            <li>
                                <asp:LinkButton runat="server" OnClick="Paginador_OnClick" ID="Final"><span aria-hidden="true">
                        >|</span>
                                </asp:LinkButton></li>
                            <li><a href="#"><span aria-hidden="true">Num. Registros:
                                <asp:DropDownList ID="RegistrosVisiblesDropDownList" AutoPostBack="True" OnSelectedIndexChanged="RegistrosVisiblesDropDownList_SelectedIndexChanged"
                                    runat="server" />
                            </span></a></li>
                        </div>
                    </div>
                </nav>
                </div>
                </label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div align="center" id="modalPanel" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h4>
                                    <asp:Label ID="TituloModalPanel" runat="server" />
                                </h4>
                            </div>
                            <div class="modal-body" align="center">
                                <table style="border-spacing: 2px; border-collapse: separate; margin-left: 15px"
                                    cellpadding="50">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Código" CssClass="lbl" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="CodigoModalTxt" CssClass="form-control" runat="server" MaxLength="10" />
                                        </td>
                                        <td />
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Descripción" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="DescripcionModalTxt" CssClass="form-control" runat="server" TextMode="multiline"
                                                Columns="20" Rows="3" MaxLength="10" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Estado" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="EstadoModal" runat="server" />
                                            <ajaxToolkit:ToggleButtonExtender ID="EstadoModalToggleButtonExtender" runat="server"
                                                TargetControlID="EstadoModal" CheckedImageUrl="~/Resources/IconosGridView/CheckedGridViewEnabled.png"
                                                UncheckedImageUrl="~/Resources/IconosGridView/UnCheckedGridViewEnabled.png" ImageHeight="16"
                                                ImageWidth="16" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="GuardarButton" class="btn btn-primary" Text="Guardar" runat="server" />
                                <button type="button" class="btn btn-primary" data-dismiss="modal">
                                    Cancelar</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div id="myLoading" class="modal fade" style="pointer-events: none; margin-top: 23%;">
            <div class="modal-dialog modal-sm">
                <div class="modal-content ">
                    <h5 style="text-align: center;">Procesando...</h5>
                    <center>
                        <div class="progress progress-striped active" style="width: 95%;">
                            <div class="progress-bar" style="width: 100%;" aria-valuenow="100" aria-valuemax="100" />
                        </div>
                    </center>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
