<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EorCabeceraMaquinariaWebForm.aspx.cs"
    Inherits="Sigeor.GestionMgl.EorCabeceraMaquinariaWebForm" MaintainScrollPositionOnPostback="true" Culture="es-EC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script type='text/javascript' src="../Resources/Scripts/jquery.js"> </script>

    <link href="../Resources/Bootstrap/css/EstilosGridView.css" rel="stylesheet" />
    <link href="../Resources/Bootstrap/css/EstilosAdicionales.css" rel="stylesheet" />
    <script src="../Resources/Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
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


    <link href="../Resources/Bootstrap/MultiSelect/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="../Resources/Bootstrap/MultiSelect/js/bootstrap-multiselect.js" type="text/javascript"></script>


    <form autocomplete="on" id="formularioPrincipal" runat="server" style="width: 100%; height: 100%;"
        onprerender="formularioPrincipal_OnPreRender" onload="formularioPrincipal_OnLoad">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" EnableScriptLocalization="True" />

        <script type="text/javascript">
            $(document).ready(function () {
                $('[id*=TipoContenedorListBox]').multiselect({
                    includeSelectAllOption: true,
                    enableFiltering: true,
                    maxHeight: 250,
                    enableCaseInsensitiveFiltering: true,
                    buttonWidth: '100%',

                });
            });
            ModalPanel();
            window.Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            window.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            BeginRequestHandler(End);
            EndRequestHandler(End);
        </script>
        <asp:UpdatePanel ID="GridViewUpdatePanel" runat="server" UpdateMode="Always">
            <ContentTemplate>
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
                                        <tr id="Tr2" runat="server">
                                            <td id="Td3" runat="server">
                                                <asp:LinkButton ID="ReporteLinkButton" runat="server" ToolTip="Ver Reporte" CssClass="lblTabla" OnClick="VerReporte">
                                                    <span class="glyphicon glyphicon-export"></span> Ver Reporte
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
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
                <div class="container" style="width: 100%;">
                    <div class="row">
                        <div class="panel-group" id="accordion">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#filtros">Filtros</a>
                                    </h3>
                                </div>
                                <div id="filtros" class="panel-collapse collapse in">
                                    <div class="panel-body center-block">
                                        <div class="row" style="text-align: right; margin: auto;">
                                            <div class="col-sm-1 col-md-offset-1">
                                                <asp:Label runat="server" Text="Depósito: " CssClass="form-search" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:DropDownList runat="server" ID="ddlDeposito" CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label ID="Label2" runat="server" Text="Línea: " />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:DropDownList runat="server" ID="ddlLinea" CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label ID="Label3" runat="server" Text="Tipo Contenedor: " />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:ListBox ID="TipoContenedorListBox" runat="server" SelectionMode="Multiple" CssClass="form-control" />

                                            </div>
                                            <div class="col-xs-12" style="height: 2px;" />
                                        </div>
                                        <div class="row" style="text-align: right; margin: auto;">
                                            <div class="col-sm-1 col-md-offset-1">
                                                <asp:Label runat="server" Text="Estado: " CssClass="form-search" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:DropDownList data-placeholder="Elija un Estado..." runat="server" ID="ddlEstado"
                                                    CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label runat="server" Text="Fecha Inicio: " />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:TextBox autocomplete="off" ID="txtFechaInicio" runat="server" CssClass="calendar" ReadOnly="True"
                                                    BackColor="White" />
                                                <ajaxToolkit:CalendarExtender ID="calendarExtenderInicio" TargetControlID="txtFechaInicio"
                                                    runat="server" CssClass="btn-default" />
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label runat="server" Text="Fecha Fin: " />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:TextBox autocomplete="off" ID="txtFechaFin" runat="server" CssClass="calendar" BackColor="White"
                                                    ReadOnly="True" />
                                                <ajaxToolkit:CalendarExtender ID="calendarExtenderFin" TargetControlID="txtFechaFin"
                                                    runat="server" CssClass="btn-default" />
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row" style="width: 60%; margin: auto; margin-top: auto;">
                                            <div class="input-group">
                                                <asp:TextBox autocomplete="off" Width="100%" runat="server" ID="BuscarTextBox" CssClass="form-control"
                                                    TabIndex="1" placeholder="Buscar por: Num. Eor, Num. Eir, Container" ToolTip="Ingrese el campo a buscar." MaxLength="50" />
                                                <span class="input-group-btn" style="horiz-align: left">
                                                    <asp:Button ID="BuscarButton" Style="background-image: url(../Resources/Imagenes/Paginas/find.png); background-position: center; background-repeat: no-repeat;"
                                                        ToolTip="Buscar"
                                                        runat="server" class=" btn btn-default" OnClick="BuscarButton_OnClick" />
                                                </span>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>
                        <div runat="server" class="row" style="margin-right: 0.5%">

                            <div class="tab-content" style="padding-top: 20px">
                                <div role="tabpanel" class="tab-pane active" id="eorAretina" align="right">
                                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                                        <asp:GridView ID="EorCabeceraMaquinariaGridView" runat="server" AllowSorting="false"
                                            CssClass="table table-striped table-bordered table-condensed table-hover small table-hover table-responsive"
                                            OnRowDataBound="EorCabeceraMaquinariaGridView_RowDataBound" AlternatingRowStyle-BackColor="#E6E6FA"
                                            AutoGenerateColumns="false" Width="98%">
                                            <EmptyDataRowStyle BackColor="LightBlue" />
                                            <EmptyDataTemplate>
                                                No se encontraron registros Disponibles.
                                            </EmptyDataTemplate>

                                            <Columns>
                                                <asp:TemplateField SortExpression="NumEorSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="NUM. EOR" CommandName="Sort" CommandArgument="NUM_EOR" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("NUM_EORMAQ")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <Columns>
                                                <asp:TemplateField SortExpression="IdEirSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="NUM. EIR" CommandName="Sort" CommandArgument="ID_EIR" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("ID_EIR")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <Columns>
                                                <asp:TemplateField SortExpression="NumContainerSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="CONTAINER" CommandName="Sort" CommandArgument="NUM_CONTAINER" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("NUM_CONTAINER")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <Columns>
                                                <asp:TemplateField SortExpression="CodTipContainerSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="LinkButton5" runat="server" Text="T. CNTR" CommandName="Sort"
                                                            CommandArgument="TIP_CONTAINER" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center">
                                                            <%#Eval("COD_TIPCONT")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <Columns>
                                                <asp:TemplateField SortExpression="CiudadSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" Text="CIUDAD" CommandName="Sort"
                                                            CommandArgument="CIUDAD" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("CIUDAD")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <Columns>
                                                <asp:TemplateField SortExpression="LineaSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="LINEA" CommandName="Sort" CommandArgument="LINEA" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("NOM_LINEA")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="FechaeEorSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="FECHA EOR" CommandName="Sort" CommandArgument="FECHA_EOR" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center"><%#Eval("FECHA_EORMAQ")%></div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="FechaAprobacionSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" Text="F. APROBA." CommandName="Sort"
                                                            CommandArgument="FECHA_REPARACION" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center"><%#Eval("FECHA_APROBACION")%></div>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <Columns>
                                                <asp:TemplateField SortExpression="FechaReparacionSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" Text="F. REPARA." CommandName="Sort"
                                                            CommandArgument="FECHA_REPARACION" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center"><%#Eval("FECHA_REPARACION")%> </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="EstadoSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="ESTADO" CommandName="Sort"
                                                            CommandArgument="ESTADO" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("ESTADO")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <Columns>
                                                <asp:TemplateField SortExpression="PtiEstimado">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="PTI ESTIMADO" CommandName="Sort" CommandArgument="PTI_ESTIMADO" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <%#Eval("PTI_ESTIMADO")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="PtiNegociacion">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="PTI NEGOCIACION" CommandName="Sort" CommandArgument="PTI_NEGOCIACION" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <%#Eval("PTI_NEGOCIACION")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>


                                            <Columns>
                                                <asp:TemplateField SortExpression="CmEstimado">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="CM. ESTIMADO" CommandName="Sort" CommandArgument="TOTAL_ESTIMAT" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <%#Eval("TOTAL_ESTIMAT")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="CmReal">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="CM. REAL" CommandName="Sort" CommandArgument="TOTAL_REALMAT" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <%#Eval("TOTAL_REALMAT")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="CmoEstimado">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="CMO. ESTIMADO" CommandName="Sort" CommandArgument="TOTAL_ESTICOSTOHH" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <%#Eval("TOTAL_ESTICOSTOHH")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="CmoReal">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="CMO. REAL" CommandName="Sort" CommandArgument="TOTAL_REALCOSTOHH" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <%#Eval("TOTAL_REALCOSTOHH")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <br />
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
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
                                <asp:TextBox autocomplete="off"  ID="paginaActualTextBox" OnClick="" Width="55px" AutoPostBack="True"
                                    runat="server" MaxLength="7" Text="1" OnTextChanged="paginaActualTextBox_OnTextChanged"
                                    onkeypress="ValidaSoloNumeros();" ForeColor="Black" />
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
                                    runat="server" ForeColor="Black" />
                            </span></a></li>
                        </div>
                    </div>
                </nav>
                </div>
            </label>
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
