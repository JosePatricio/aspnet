﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionNegociacionesProveedorWebForm.aspx.cs"
    Inherits="Sigeor.GestionControl.GestionNegociacionesProveedorWebForm" MaintainScrollPositionOnPostback="true" Culture="es-EC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Negociaciones Proveedor</title>

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

    <form autocomplete="on" id="principalForm" runat="server" style="width: 100%;" onprerender="formularioPrincipal_OnPreRender">
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
                <div class="containerPrueba" style="width: 100%;">
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
                                                    <asp:LinkButton ID="NuevoLinkButton" runat="server" OnClick="NuevoLinkButton_Click" CssClass="lblTabla"
                                                        ToolTip="Nuevo Registro"><span class="glyphicon glyphicon-plus-sign"></span> Nuevo</asp:LinkButton>
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
                                    </h4>
                                </div>
                                <div id="filtros" class="panel-collapse collapse in">
                                    <div class="panel-body center-block">
                                        <div class="row" align="center">

                                            <div class="col-sm-1 col-sm-offset-0">
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
                                                <ajaxToolkit:CalendarExtender ID="calendarExtender1" TargetControlID="txtFechaInicio"
                                                    runat="server" CssClass="btn-default" />
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label runat="server" Text="Fecha Fin: " />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:TextBox autocomplete="off" ID="txtFechaFin" runat="server" CssClass="calendar" BackColor="White"
                                                    ReadOnly="True" />
                                                <ajaxToolkit:CalendarExtender ID="calendarExtender2" TargetControlID="txtFechaFin"
                                                    runat="server" CssClass="btn-default" />
                                            </div>
                                            <div class="col-sm-2" style="vertical-align: middle;">
                                                <asp:Label runat="server" Text="Ver Historial: " />
                                            </div>
                                            <div class="col-sm-1" style="text-align: left;">
                                                <asp:CheckBox ID="HistorialChk" runat="server" ToolTip="Realiza búsquedas con históricos" />
                                                <ajaxToolkit:ToggleButtonExtender runat="server"
                                                    TargetControlID="HistorialChk" UncheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png" CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png" ImageHeight="16"
                                                    ImageWidth="16" />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row" style="width: 60%; margin: auto; margin-top: auto;">

                                            <div class="col-sm-12">
                                                <div class="input-group">
                                                    <asp:TextBox autocomplete="off" Width="100%" runat="server" ID="BuscarTextBox" CssClass="form-control"
                                                        TabIndex="1" placeholder="Buscar..." ToolTip="Ingrese el texto buscar." MaxLength="50" />
                                                    <span class="input-group-btn" style="horiz-align: left">
                                                        <asp:Button ID="BuscarButton" Style="background-image: url(../Resources/Imagenes/Paginas/find.png); background-position: center; background-repeat: no-repeat;"
                                                            ToolTip="Buscar"
                                                            runat="server" class=" btn btn-default" OnClick="BtnBuscar_OnClick" />
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
                    <div class="row">
                        <div align="left">
                            <asp:Panel ID="Panel1" ScrollBars="Auto" runat="server" CssClass="col-xs-offset-025">
                                <asp:GridView ID="NegociacionesGridView" runat="server" AllowSorting="false"
                                    CssClass="table table-striped table-bordered table-condensed table-hover small table-hover table-responsive"
                                    AlternatingRowStyle-BackColor="#E6E6FA" OnRowDataBound="NegociacionesGridView_RowDataBound"
                                    AutoGenerateColumns="false" DataKeyNames="IdNegociacionProveedor" Width="98%">
                                    <EmptyDataRowStyle BackColor="LightBlue" />
                                    <EmptyDataTemplate>
                                        No se encontraron registros disponibles.
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItemProveedor" runat="server" Text="PROVEEDOR" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("NombreProveedor")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItemDeposito" runat="server" Text="DEPÓSITO" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("NombreDeposito")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItemLinea" runat="server" Text="LÍNEA" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("NombreLinea")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <div align="center">
                                                    <asp:LinkButton ID="lbItemDescripcion" runat="server" Text="DESCRIPCIÓN" />
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("Descripcion")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <div align="center">
                                                    <asp:LinkButton ID="lbItemvigencia" runat="server" Text="VIGENCIA" />
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="text-align: center;">
                                                    <%#Eval("FechaInicioVal","{0:dd/MM/yyyy}")%> - <%#Eval("FechaFinVal","{0:dd/MM/yyyy}")%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--  <asp:TemplateField>
                                            <HeaderTemplate>
                                                <div align="center">
                                                    <asp:LinkButton ID="lbItemPorcentajeNegociacion" runat="server" Text="NEG. H/H EST." />
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="text-align: right">
                                                    <%#Eval("EsPorcNegoMatEst").ToString().ToLower() == "true" ? Eval("ValorNegoMaterialEstructura","{0:f2}"+" %") : Eval("ValorNegoMaterialEstructura","{0:c}")%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <div align="center">
                                                    <asp:LinkButton ID="lbItemPorcentajeNegociacion" runat="server" Text="NEG. H/H MAQ." />
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="text-align: right">
                                                    <%#Eval("EsPorcNegoMatMaq").ToString().ToLower() == "true" ? Eval("ValorNegoMaterialMaquinaria","{0:f2}"+" %") : Eval("ValorNegoMaterialMaquinaria", "{0:c}")%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>





                                        <%-- <asp:TemplateField>
                                        <HeaderTemplate>
                                            <div align="center">
                                                <asp:LinkButton ID="lbItemUsuarioCrea" runat="server" Text="USUARIO CREADOR" />
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#Eval("UsuarioCrea")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                        <%--   <asp:TemplateField>
                                            <HeaderTemplate>
                                                <div align="center">
                                                    <asp:LinkButton ID="lbItemFechaCrea" runat="server" Text="F. CREACIÓN" />
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="text-align: center;">
                                                    <%#Eval("FechaCrea", "{0:dd/MM/yyyy}")%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <%--<asp:TemplateField>
                                        <HeaderTemplate>
                                            <div align="center">
                                                <asp:LinkButton ID="lbItemUsuarioMod" runat="server" Text="USUARIO MODIFICADOR" />
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#Eval("UsuarioModifica")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>



                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <div align="center">
                                                    <asp:LinkButton ID="lbItemFechaMod" runat="server" Text="MODIFICACIÓN" />
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="text-align: center;">
                                                    <%#Eval("FechaModifica", "{0:dd/MM/yyyy}")%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <div align="center">
                                                    <asp:LinkButton ID="lbItemEstado" runat="server" Text="ESTADO" CommandName="Sort"
                                                        CommandArgument="Estado" />
                                                    <%--<br />
                                                    <asp:CheckBox Width="5%" ID="EstadoCabeceraGridView" runat="server" AutoPostBack="true"
                                                        OnCheckedChanged="EstadoCabeceraGridView_CheckedChanged" Checked='<%#ddlEstado.SelectedValue.Equals(1)%>'
                                                        ToolTip='<%#ddlEstado.SelectedValue.Equals(1)?"Inactivar Todos":"Activar Todos"%>' />
                                                    <ajaxToolkit:ToggleButtonExtender ID="ToggleButtonExtender2" runat="server" TargetControlID="EstadoCabeceraGridView"
                                                        CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png" UnCheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png"
                                                        ImageHeight="16" ImageWidth="16" />--%>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div align="center">
                                                    <asp:CheckBox Width="5%" ID="EstadoCheckBoxGridView" runat="server" AutoPostBack="true"
                                                        Checked='<%#Eval("Estado")%>' OnCheckedChanged="EstadoCheckBoxGridView_CheckedChangedPrincipal"
                                                        ToolTip="Activar/Inactivar" />
                                                </div>
                                                <ajaxToolkit:ToggleButtonExtender ID="ToggleButtonExtender2" runat="server" TargetControlID="EstadoCheckBoxGridView"
                                                    CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png" UncheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png"
                                                    ImageHeight="16" ImageWidth="16" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <center>
                                                    <asp:LinkButton ID="lbItemEditar" runat="server" Text="EDITAR" />
                                                </center>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <center>
                                                    <asp:LinkButton ID="LinkButtonEditar" runat="server" OnClick="lnkEdit_Click" ToolTip="Editar Registro"> 
                                                    <img src="../Resources/Imagenes/Paginas/edit_blue.png"  height="15px"  alt="edit" />
                                                    </asp:LinkButton>
                                                </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
                <br />
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
                                <asp:TextBox autocomplete="off"  ID="paginaActualTextBox" Width="55px" AutoPostBack="True" runat="server"
                                    MaxLength="7" Text="1" OnTextChanged="paginaActualTextBox_OnTextChanged" onkeypress="ValidaSoloNumeros();" ForeColor="Black" />
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
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="myModal" class="modal fade" style="pointer-events: auto;">
            <div class="modal-dialog">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h4>
                                    <asp:Label ID="TituloModalPanel" CssClass="lblTitulo" runat="server" />
                                </h4>
                            </div>
                            <div class="modal-body" align="center">
                                <table style="border-spacing: 2px; border-collapse: separate; margin-left: 15px"
                                    cellpadding="2">

                                    <tr>

                                        <td>
                                            <asp:Label runat="server" Text="Proveedor" /></td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ProveedorDropDownList" ToolTip="Seleccione un Proveedor"
                                                class="form-control" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text="Depósito" /></td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DepositoDropDownList" ToolTip="Seleccione un Depósito"
                                                class="form-control" /></td>
                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:Label runat="server" Text="Línea" /></td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="LineaDropDownList" ToolTip="Seleccione una Línea"
                                                class="form-control" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelDescripcion" runat="server" Text="Descripción" /></td>
                                        <td>
                                            <asp:TextBox autocomplete="off" ID="DescripcionModalTxt" CssClass="form-control" runat="server" placeholder="Ejem. Descripción Negociación"
                                                MaxLength="250" /></td>
                                    </tr>
                                </table>

                                <table style="border-spacing: 2px; border-collapse: separate; margin-left: 15px"
                                    cellpadding="2">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text="M. Est.:" ToolTip="Material Estructura" /></td>
                                        <td>
                                            <asp:TextBox autocomplete="off" ID="NegociacionMaterialEstTxt" runat="server" CssClass="form-control small" placeholder="Ejem. 10,00" Style="text-align: right;" ToolTip="Negociación de Material Estructura" /></td>
                                        <td>
                                            <asp:Label runat="server" Text="Porcentual:" ToolTip="Seleccione si el valor negociación es porcentual" /></td>
                                        <td>
                                            <asp:CheckBox ID="EsPorcNegEst" Enabled="false" runat="server" ToolTip="Seleccione si el valor negociación es porcentual" OnCheckedChanged="EsPorcNegEst_OnCheckedChanged" AutoPostBack="true" />
                                            <ajaxToolkit:ToggleButtonExtender ID="ToggleButtonExtender1" runat="server"
                                                TargetControlID="EsPorcNegEst" CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png" UncheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png" ImageHeight="16"
                                                ImageWidth="16" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text="M. Maq:" ToolTip="Material Maquinaria" /></td>
                                        <td>
                                            <asp:TextBox autocomplete="off" ID="NegociacionMaterialMaqTxt" runat="server" CssClass="form-control small" placeholder="Ejem. 10,00" Style="text-align: right;" ToolTip="Negociación de Material Maquinaria" /></td>
                                        <td>
                                            <asp:Label runat="server" Text="Porcentual:" ToolTip="Seleccione si el valor negociación es porcentual" /></td>
                                        <td>
                                            <asp:CheckBox ID="EsPorcNegMaq" Enabled="false" runat="server" ToolTip="Seleccione si el valor negociación es porcentual" OnCheckedChanged="EsPorcNegMaq_OnCheckedChanged" AutoPostBack="True" />
                                            <ajaxToolkit:ToggleButtonExtender ID="ToggleButtonExtender3" runat="server"
                                                TargetControlID="EsPorcNegMaq" CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png" UncheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png" ImageHeight="16"
                                                ImageWidth="16" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text="M.O Est.:" ToolTip="Mano de Obra Estructura" /></td>
                                        <td>
                                            <asp:TextBox autocomplete="off" ID="NegociacionManoObraEstTxt" runat="server" CssClass="form-control small" placeholder="Ejem. 10,00" Style="text-align: right;" ToolTip="Negociación Mano de Obra Estructura" /></td>
                                        <td>
                                            <asp:Label runat="server" Text="M.O Maq.:" ToolTip="Mano de Obra Maquinaria" /></td>
                                        <td>
                                            <asp:TextBox autocomplete="off" ID="NegociacionManoObraMaqTxt" runat="server" CssClass="form-control small" placeholder="Ejem. 10,00" Style="text-align: right;" ToolTip="Negociación Mano de Obra Maquinaria" /></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text="PTI Normal:" /></td>
                                        <td>
                                            <asp:TextBox autocomplete="off" ID="PtiNormalTextBox" runat="server" CssClass="form-control small" placeholder="Ejem. 10,00" Style="text-align: right;" />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="PTI Rap:" /></td>
                                        <td>
                                            <asp:TextBox autocomplete="off" ID="PtiRapTextBox" runat="server" CssClass="form-control small" placeholder="Ejem. 10,00" Style="text-align: right;" />
                                        </td>
                                    </tr>


                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text="Inicio:" /></td>
                                        <td>
                                            <asp:TextBox autocomplete="off" ID="txtFechaInicioModal" runat="server" CssClass="calendar" ReadOnly="True"
                                                BackColor="White" />
                                            <ajaxToolkit:CalendarExtender ID="calendarExtenderInicio" TargetControlID="txtFechaInicioModal"
                                                runat="server" CssClass="btn-default" />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Fin:" /></td>
                                        <td>
                                            <asp:TextBox autocomplete="off" ID="txtFechaFinModal" runat="server" CssClass="calendar" ReadOnly="True"
                                                BackColor="White" />
                                            <ajaxToolkit:CalendarExtender ID="calendarExtenderFin" TargetControlID="txtFechaFinModal"
                                                runat="server" CssClass="btn-default" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text="Estado:" /></td>
                                        <td>
                                            <asp:CheckBox ID="EstadoModal" runat="server" ToolTip="Estado de la Negociación" />
                                            <ajaxToolkit:ToggleButtonExtender ID="EstadoModalToggleButtonExtender" runat="server"
                                                TargetControlID="EstadoModal" CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png" UncheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png" ImageHeight="16"
                                                ImageWidth="16" />
                                        </td>
                                        <td></td>
                                        <td></td>

                                    </tr>

                                </table>

                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="GuardarButton" class="btn btn-primary" Text="Guardar" runat="server"
                                    OnClick="AceptarButton_Click" />
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