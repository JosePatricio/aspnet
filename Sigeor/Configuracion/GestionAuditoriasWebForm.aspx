<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionAuditoriasWebForm.aspx.cs"
    Inherits="Sigeor.Configuracion.GestionAuditoriasWebForm" Culture="es-EC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Auditorías del Sistema</title>

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

    <form autocomplete="on" id="principalform" runat="server" style="width: 100%; height: 100%;" onprerender="principalform_OnPreRender">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" EnableScriptLocalization="True" />

        <script type="text/javascript">            
            ModalPanel();
            window.Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            window.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            BeginRequestHandler(End);
            EndRequestHandler(End);
        </script>

        <asp:UpdatePanel ID="GridViewUpdatePanel" runat="server">
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
                </div>
                <div class="container" style="width: 100%;">
                    <div class="panel-group" id="accordion">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#filtros">Filtros</a>
                                </h4>
                            </div>
                            <div id="filtros" class="panel-collapse collapse in">
                                <div class="panel-body center-block">
                                    <div class="row">
                                        <div class="col-sm-1 col-sm-offset-3">
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
                                    <div class="row">
                                        <%--<div class="col-xs-8">--%>
                                        <div class="col-xs-3 col-xs-offset-1" style="text-align: right; padding-top: 7px;">
                                            <asp:Label ID="lblBuscar" runat="server" Text="Búsqueda por acción/coincidencia:" />
                                        </div>
                                        <div class="col-xs-2">
                                            <asp:TextBox autocomplete="off" Width="100%" runat="server" ID="AccionTextBox" CssClass="form-control"
                                                TabIndex="1" placeholder="Buscar Acción..." ToolTip="Ingrese el texto buscar." MaxLength="50" />
                                        </div>
                                        <div class="col-xs-3">
                                            <div class="input-group">
                                                <asp:TextBox autocomplete="off" Width="100%" runat="server" ID="BuscarTextBox" CssClass="form-control"
                                                    TabIndex="1" placeholder="Buscar por Coincidencia..." ToolTip="Ingrese el texto buscar." MaxLength="50" />
                                                <span class="input-group-btn">
                                                    <asp:Button ID="BuscarButton" Style="background-image: url(../Resources/Imagenes/Paginas/find.png); background-position: center; background-repeat: no-repeat;"
                                                        ToolTip="Buscar"
                                                        runat="server" class=" btn btn-default" OnClick="BuscarButton_OnClick" />
                                                </span>
                                            </div>
                                        </div>
                                        <%--</div>--%>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div align="center">
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                                <asp:GridView ID="AuditoriaGridView" Width="96%" runat="server"
                                    CssClass="table table-striped table-bordered table-condensed table-hover small table-hover table-responsive"
                                    AlternatingRowStyle-BackColor="#E6E6FA"
                                    OnRowDataBound="AuditoriaGridView_RowDataBound" AutoGenerateColumns="false"
                                    DataKeyNames="Id">
                                    <EmptyDataRowStyle BackColor="LightBlue" />
                                    <EmptyDataTemplate>
                                        No se encontraron registros Disponibles.
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField SortExpression="Usuarioort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItem1" runat="server" Text="USUARIO" CommandName="Sort" CommandArgument="Cedula" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div align="center">
                                                    <%#Eval("Cedula")%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="IpSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItem1" runat="server" Text="IP" CommandName="Sort" CommandArgument="Ip" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div align="center">
                                                    <%#Eval("Ip")%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="FechaSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItem1" runat="server" Text="FECHA" CommandName="Sort" CommandArgument="Fecha" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div align="center">
                                                    <%#Eval("Fecha","{0:dd/MM/yyyy}")%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="HoraSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItem1" runat="server" Text="HORA" CommandName="Sort" CommandArgument="Hora" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div align="center">
                                                    <%#Eval("Hora")%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="TablaSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItem1" runat="server" Text="TABLA" CommandName="Sort" CommandArgument="Tabla" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("NombreTabla")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="IdObjetoSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton runat="server" Text="ID OBJETO" CommandName="IdObjetoSort"
                                                    CommandArgument="IdObjeto" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("IdObjeto")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="CampoSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItem1" runat="server" Text="CAMPO" CommandName="Sort" CommandArgument="Campo" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("NombreCampo")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="ValorAnteriorSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItem1" runat="server" Text="VAL. ANTERIOR" CommandName="Sort"
                                                    CommandArgument="ValorAnterior" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("ValorAnterior")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="ValorActualSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItem1" runat="server" Text="VAL. ACTUAL" CommandName="Sort"
                                                    CommandArgument="ValorActual" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("ValorActual")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="NombreSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton runat="server" Text="ACCION" CommandName="Sort"
                                                    CommandArgument="ACCION" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("Nombre")%>
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
                                <asp:LinkButton runat="server" OnClick="Paginador_OnClick" ID="Siguiente" ><span
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
