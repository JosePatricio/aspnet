﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstimacionEirWebForm.aspx.cs" Inherits="Sigeor.ReportesAspx.EstimacionEirWebForm"
    MaintainScrollPositionOnPostback="true" Culture="es-EC" %>


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
        onprerender="formularioPrincipal_OnPreRender">
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
                        <div class="panel-heading" >
                            <table width="100%" runat="server">
                                <tr style="border: 1px" runat="server">
                                    <td runat="server">
                                        <h4>
                                            <asp:Label ID="lblCabecera" runat="server"></asp:Label>
                                        </h4>
                                    </td>
                                    <td align="right" runat="server">
                                        <table runat="server">
                                            <tr runat="server">
                                                <td runat="server">
                                                    <asp:LinkButton ID="ReporteLinkButton" runat="server" ToolTip="Ver Reporte" CssClass="lblTabla" OnClick="VerReporte">
                                                    <span class="glyphicon glyphicon-export"></span> Ver Reporte
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server">
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


                <div class="container" style="width: 100%;>
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

                                                <asp:Label ID="Label7" runat="server" Text="Depósito: " />
                                            </div>
                                            <div class="col-sm-2">

                                                <asp:DropDownList data-placeholder="Elija depósito..." runat="server" ID="ddlDeposito"
                                                    CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label ID="Label5" runat="server" Text="Línea: " />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:DropDownList data-placeholder="Elija una Línea..." runat="server" ID="ddlLinea"
                                                    CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label  runat="server" Text="Estado: " CssClass="form-search" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:DropDownList data-placeholder="Elija un Depósito..." runat="server" ID="ddlEstado"
                                                    CssClass="form-control" />
                                            </div>
                                            <div class="col-xs-12" style="height: 2px;" />
                                        </div>
                                        <%--<div class="col-xs-12" style="height: 2px;"/>--%>
                                        <!-- Espacio en blanco entre filas-->
                                        <div class="row" style="text-align: right; margin: auto;">
                                            <div class="col-sm-1 col-md-offset-1">
                                                <asp:Label ID="Label6" runat="server" Text="Tipo Contenedor: " />
                                            </div>
                                            <div class="col-sm-2">

                                                <asp:ListBox ID="TipoContenedorListBox" runat="server" SelectionMode="Multiple" CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label ID="Label8" runat="server" Text="Fecha inicio: " />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:TextBox autocomplete="off" ID="txtfechainicio" runat="server" CssClass="calendar" placeholder="Fecha inicio"
                                                    BackColor="White" />
                                                <ajaxToolkit:CalendarExtender ID="calendarExtenderInicio" TargetControlID="txtfechainicio" runat="server" CssClass="btn-default" />
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label ID="Label9" runat="server" Text="Fecha fin: " />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:TextBox autocomplete="off" placeholder="Fecha fin" ID="txtfechafin"
                                                    runat="server" CssClass="calendar"
                                                    BackColor="White" />
                                                <ajaxToolkit:CalendarExtender ID="calendarExtenderFin" TargetControlID="txtfechafin" runat="server" CssClass="btn-default" />

                                            </div>
                                        </div>
                                        <br />
                                        <div class="row" style="width: 60%; margin: auto; margin-top: auto;">
                                            <div class="input-group">
                                                <asp:TextBox autocomplete="off" Width="100%" runat="server" ID="BuscarTextBox" CssClass="form-control"
                                                    TabIndex="1" placeholder="Buscar por: EIR, CONTAINER" ToolTip="Ingrese el campo a buscar." MaxLength="50" />
                                                <span class="input-group-btn" style="horiz-align: left">
                                                    <asp:Button ID="Button1" Style="background-image: url(../Resources/Imagenes/Paginas/find.png); background-position: center; background-repeat: no-repeat;"
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
                                        <asp:GridView ID="gridEirdeposito" runat="server" AllowSorting="false"
                                            CssClass="table table-striped table-bordered table-condensed table-hover small table-hover table-responsive"
                                            OnRowDataBound="PerfilesGridView_RowDataBound" DataKeyNames="ID_EIR"
                                            AlternatingRowStyle-BackColor="#E6E6FA" AutoGenerateColumns="false" Width="98%">
                                           <EmptyDataRowStyle BackColor="LightBlue" />

                                            <EmptyDataTemplate>
                                                No se encontraron registros Disponibles.
                                            </EmptyDataTemplate>

                                            <Columns>
                                                <asp:TemplateField SortExpression="NOM_DEPOSITOSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="DEPOSITO" CommandName="Sort" CommandArgument="NOMBRE_DEPOSITO"
                                                            />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("NOMBRE_DEPOSITO")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="NOM_LINEASort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="LINEA" CommandName="Sort" CommandArgument="NOM_LINEA"
                                                            />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("NOM_LINEA")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            
                                            <Columns>
                                                <asp:TemplateField SortExpression="FECHA_EIRort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="FECHA EIR" CommandName="Sort" CommandArgument="FECHA_EIR"
                                                            />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center">
                                                            <%#Eval("FECHA_EIR", "{0:yyyy-MM-dd}")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="ID_EIRSort">
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
                                                <asp:TemplateField SortExpression="NUM_CONTAINERSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="CONTAINER" CommandName="Sort" CommandArgument="NUM_CONTAINER"
                                                            />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("NUM_CONTAINER")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="COD_TIPCONT">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="TIPO CONTENEDOR" CommandName="Sort" CommandArgument="COD_TIPCONT"
                                                            />
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
                                                <asp:TemplateField SortExpression="NUM_EOREST_sort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="EOR EST." CommandName="Sort" CommandArgument="NUM_EOREST"
                                                            />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center">
                                                            <%#Eval("NUM_EOREST")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            
                                            <Columns>
                                                <asp:TemplateField SortExpression="EOR_MAQ_sort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="EOR MAQ." CommandName="Sort" CommandArgument="EOR_MAQ"
                                                            />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center">
                                                            <%#Eval("NUM_EORMAQ")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="ESTADO_EST_Sort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="ESTADO EST." CommandName="Sort" CommandArgument="ESTADO_EST"
                                                            />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center">
                                                            <%#Eval("ESTADO_EST")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>


                                            

                                            <Columns>
                                                <asp:TemplateField SortExpression="ESTADO_MAQ_Sort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="ESTADO MAQ." CommandName="Sort" CommandArgument="ESTADO_MAQ"
                                                            />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center">
                                                            <%#Eval("ESTADO_MAQ")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>


                                            <Columns>
                                                <asp:TemplateField SortExpression="ESTADOSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="ESTADO" CommandName="Sort" CommandArgument="ESTADO"
                                                            />
                                                        <br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center">
                                                            <%#Eval("ESTADO")%>
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
                                    onkeypress="ValidaSoloNumeros();" ForeColor="Black"/>
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
                                <asp:DropDownList ID="RegistrosVisiblesDropDownList" ForeColor="Black" AutoPostBack="True" OnSelectedIndexChanged="RegistrosVisiblesDropDownList_SelectedIndexChanged"
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
                <div class="modal-content" >
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="modal-header" >
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
                                            <asp:Label ID="Label2" runat="server" Text="Código" CssClass="lbl" Font-Bold="True" />
                                        </td>
                                        <td>
                                            <asp:TextBox autocomplete="off" ID="CodigoModalTxt" CssClass="form-control" runat="server" MaxLength="10" />
                                        </td>
                                        <td />
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Descripción" Font-Bold="True" />
                                        </td>
                                        <td>
                                            <asp:TextBox autocomplete="off" ID="DescripcionModalTxt" CssClass="form-control" runat="server" TextMode="multiline"
                                                Columns="20" Rows="3" MaxLength="10" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Estado" Font-Bold="True" />
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
