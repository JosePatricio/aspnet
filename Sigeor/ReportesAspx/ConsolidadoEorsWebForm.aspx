﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsolidadoEorsWebForm.aspx.cs"
    Inherits="Sigeor.GestionMgl.ConsolidadoEorsWebForm" MaintainScrollPositionOnPostback="true" Culture="es-EC" %>



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
                                            <tr id="Tr2" runat="server">
                                                <td id="Td3" runat="server">
                                                    <asp:LinkButton ID="ReporteLinkButton" runat="server" ToolTip="Ver Reporte" CssClass="lblTabla"
                                                        OnClick="VerReporte">
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
                                                <asp:Label  runat="server" Text="Depósito: " CssClass="form-search" />
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
                                                <asp:Label runat="server" Text="Estado: " CssClass="form-search" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:DropDownList data-placeholder="Elija un Estado..." runat="server" ID="ddlEstado"
                                                    CssClass="form-control" />

                                            </div>
                                            <div class="col-xs-12" style="height: 2px;" />
                                        </div>
                                        <div class="row" style="text-align: right; margin: auto;">
                                            <div class="col-sm-1 col-md-offset-1">
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
                                        <%--  <table align="center" style="width: 50%; border-spacing: 2px; border-collapse: separate;">
                                        <tr align="center">
                                            <td>
                                                
                                            </td>
                                            <td>
                                                
                                            </td>
                                            <td>
                                                
                                            </td>
                                            <td>
                                                <div class="side-by-side clearfix">
                                                    <div>
                                                        
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>--%>
                                        <%--  <table style="width: 50%; border-spacing: 2px; border-collapse: separate;" align="center">
                                        <tr>
                                            <td>
                                                <div class="input-group">
                                                    <asp:TextBox autocomplete="off"  Width="100%" runat="server" ID="BuscarTextBox" CssClass="form-control"
                                                        TabIndex="1" placeholder="Buscar..." ToolTip="Ingrese el texto buscar." MaxLength="50" />
                                                    <span class="input-group-btn">
                                                        <asp:Button ID="BuscarButton" Style="background-image: url(../Resources/Imagenes/Paginas/find.png);
                                                            background-position: center; background-repeat: no-repeat;" ToolTip="Buscar"
                                                            runat="server" class=" btn btn-default" OnClick="BuscarButton_OnClick" />
                                                    </span>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>--%>
                                    </div>
                                </div>
                            </div>
                            <%-- <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseITF">Cabecera EOR</a>
                                </h4>
                            </div>
                            <div id="collapseITF" class="panel-collapse collapse">
                                <div class="panel-body">
                                </div>
                            </div>
                        </div>--%>
                        </div>
                        <div class="row" style="margin-right: 0.5%">
                            <%-- <div id="Tabs" role="tabpanel">--%>
                            <!-- Nav tabs -->
                            <%-- <ul class="nav nav-tabs small btn-default" role="tablist">
                                <li><a href="#eorAretina" aria-controls="eorAretina" role="tab" data-toggle="tab">EOR-ESTRUCTURA
                                </a></li>
                                <li><a href="#eorEstimado" aria-controls="eorEstimado" role="tab" data-toggle="tab">
                                    ESTIMADO EOR</a></li>
                            </ul>--%>
                            <!-- Tab panes -->
                            <div class="tab-content" style="padding-top: 20px">
                                <div role="tabpanel" class="tab-pane active" id="eorAretina" align="right">
                                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                                        <asp:GridView ID="EorCabeceraEstructuraGridView" runat="server" AllowSorting="false"
                                            CssClass="table table-striped table-bordered table-condensed table-hover small table-hover table-responsive"
                                            OnRowDataBound="EorCabeceraEstructuraGridView_RowDataBound" AlternatingRowStyle-BackColor="#E6E6FA"
                                            AutoGenerateColumns="false" Width="98%" Font-Size="8">
                                            <EmptyDataRowStyle BackColor="LightBlue" />
                                            <EmptyDataTemplate>
                                                No se encontraron registros disponibles.
                                            </EmptyDataTemplate>

                                            <Columns>
                                                <asp:TemplateField SortExpression="NumEorSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="EOR" CommandName="Sort" CommandArgument="NUM_EOR" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("NUM_EOR")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                                                                        <Columns>
                                                <asp:TemplateField SortExpression="IdEirSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="EIR" CommandName="Sort" CommandArgument="ID_EIR"
                                                            />
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
                                                        <%#Eval("CONTAINER")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="LineaSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="TIPO CNTR" CommandName="Sort" CommandArgument="COD_TIPCONT" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("COD_TIPCONT")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="FechaEorSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="FEC. EOR." CommandName="Sort" CommandArgument="FECHA_EOR" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center">
                                                            <%#Eval("FEC_EOR")%>
                                                        </div>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                           
                                            <Columns>
                                                <asp:TemplateField SortExpression="FecIniRepEstSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" Text="INI. REP. EST." CommandName="Sort"
                                                            CommandArgument="INI_REP_EST" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center">
                                                            <%#Eval("FEC_INIREP_EST")%>
                                                        </div>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <Columns>
                                                <asp:TemplateField SortExpression="FecIniRepMaqSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="INI. REP. MAQ." CommandName="Sort" CommandArgument="INI_REP_MAQ" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center">
                                                            <%#Eval("FEC_INIREP_MAQ")%>
                                                        </div>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="FecFinRepEstSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="FIN. REP. EST." CommandName="Sort"
                                                            CommandArgument="FIN_REP_EST" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center">
                                                            <%#Eval("FEC_FINREP_EST")%>
                                                        </div>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="FecFinRepMaqSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="FIN. REP. MAQ." CommandName="Sort" CommandArgument="INI_REP_MAQ" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%--<div align="center">--%>
                                                        <%#Eval("FEC_FINREP_MAQ")%>
                                                        <%--</div>--%>
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

                                            <Columns>
                                                <asp:TemplateField SortExpression="TotalRealSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="TIPO" CommandName="Sort" CommandArgument="VALORREAL" />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="left">
                                                            <%#Eval("ESTADO_FINAL")%>
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
                                <%--<asp:DropDownList ID="paginaActualDdl" AutoPostBack="True" OnSelectedIndexChanged="paginaActualDdl_OnSelectedIndexChanged"
                                    runat="server" />--%>
                                <asp:TextBox autocomplete="off"  ID="paginaActualTextBox" Width="55px" AutoPostBack="True"
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
                        <%-- <asp:DropDownList ID="RegistrosVisiblesDropDownList1" AutoPostBack="True" OnSelectedIndexChanged="RegistrosVisiblesDropDownList_SelectedIndexChanged"
                            runat="server" />--%>
                    </div>
                </nav>
                </div>
                <%-- <asp:DropDownList ID="RegistrosVisiblesDropDownList" runat="server" AutoPostBack="true"
                CssClass="comboBoxTable" OnSelectedIndexChanged="RegistrosVisiblesDropDownList_SelectedIndexChanged" />--%>
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
