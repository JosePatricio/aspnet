<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionDaniosWebForm.aspx.cs"
    Inherits="Sigeor.GestionControl.GestionDaniosWebForm" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Gestión de Daños</title>

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

    <form autocomplete="on" id="formularioPrincipal" runat="server" style="width: 100%; height: 100%;"
        onprerender="formularioPrincipal_OnPreRender">
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
                                    </h3>
                                </div>
                                <div id="filtros" class="panel-collapse collapse in">
                                    <div class="panel-body center-block">
                                        <div class="col-xs-12">
                                            <div class="col-xs-3 col-xs-offset-1" style="text-align: right; padding-top: 7px;">
                                                <asp:Label ID="lblBuscar" runat="server" Text="Búsqueda por coincidencia:" />
                                            </div>
                                            <div class="col-xs-4">
                                                <div class="input-group">
                                                    <asp:TextBox autocomplete="off" Width="100%" runat="server" ID="BuscarTextBox" CssClass="form-control"
                                                        TabIndex="1" placeholder="Buscar..." ToolTip="Ingrese el texto buscar." />
                                                    <span class="input-group-btn">
                                                        <asp:Button ID="BuscarButton" Style="background-image: url(../Resources/Imagenes/Paginas/find.png); background-position: center; background-repeat: no-repeat;"
                                                            ToolTip="Buscar"
                                                            runat="server" class=" btn btn-default" OnClick="BuscarButton_OnClick" />
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-xs-1">
                                                <div class="slideThree">
                                                    <asp:CheckBox ID="EstadoCheckBox" runat="server" OnCheckedChanged="EstadoCheckBox_CheckedChanged"
                                                        AutoPostBack="true" />
                                                    <label for="EstadoCheckBox" />
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
                        <div align="center">
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                                <asp:GridView ID="DaniosGridView" Width="96%" runat="server" CssClass="table table-striped table-bordered table-condensed table-hover small table-hover table-responsive"
                                    PagerStyle-HorizontalAlign="Center" AlternatingRowStyle-BackColor="#E6E6FA"
                                    OnRowDataBound="DaniosGridView_RowDataBound" AutoGenerateColumns="false"
                                    DataKeyNames="COD_DAMAGE,COD_LINEA,TIPO_DANIO">
                                    <EmptyDataRowStyle BackColor="LightBlue" />
                                    <EmptyDataTemplate>
                                        No se encontraron registros disponibles.
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField SortExpression="CodigoSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItem1" runat="server" Text="CODIGO" CommandName="Sort" CommandArgument="Codigo" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("COD_DAMAGE")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="NombreLineaSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItem2" runat="server" Text="LINEA" CommandName="Sort" CommandArgument="Descripcion" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("CampoNombreLinea")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="NombreTipoDanioSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItem3" runat="server" Text="TIPO DANIO" CommandName="Sort"
                                                    CommandArgument="Descripcion" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("CampoNombreTipoDanio")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="DescripcionSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItem4" runat="server" Text="DESCRIPCION" CommandName="Sort"
                                                    CommandArgument="Descripcion" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("DESCRIP")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="NombreTipoReparacionSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItemTipoReparacion" runat="server" Text="T. REPARACION" CommandName="Sort"
                                                    CommandArgument="TipoReparacion" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("TIPO_REPARACION")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="EstadoSort">
                                            <HeaderTemplate>
                                                <div align="center" style="width: 100%">
                                                    <asp:LinkButton ID="lbItem5" runat="server" Text="ESTADO" CommandName="Sort" CommandArgument="Estado" />
                                                    <br />
                                                    <asp:CheckBox Width="10%" CssClass="CheckEstado" ID="EstadoCabeceraGridView" runat="server"
                                                        AutoPostBack="true" OnCheckedChanged="EstadoCabeceraGridView_CheckedChanged"
                                                        Checked='<%#EstadoCheckBox.Checked%>' ToolTip='<%#EstadoCheckBox.Checked.Equals(true)?"Inactivar Todos":"Activar Todos"%>' />
                                                    <ajaxToolkit:ToggleButtonExtender ID="ToggleButtonExtender2" runat="server" TargetControlID="EstadoCabeceraGridView"
                                                        CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png" UnCheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png"
                                                        ImageHeight="16" ImageWidth="16" />
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div align="center">
                                                    <asp:Panel runat="server">
                                                        <asp:CheckBox Width="10%" CssClass="CheckEstado" ID="EstadoCheckBoxGridView" runat="server"
                                                            AutoPostBack="true" Checked='<%#Eval("ESTADO").ToString().Equals("A")%>' OnCheckedChanged="EstadoCheckBoxGridView_CheckedChanged"
                                                            ToolTip='<%#Eval("ESTADO").ToString().Equals("A")?"Inactivar Registro":"Activar Registro"%>' />
                                                        <ajaxToolkit:ToggleButtonExtender ID="ToggleButtonExtender1" runat="server" TargetControlID="EstadoCheckBoxGridView"
                                                            CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png" UnCheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png"
                                                            ImageHeight="16" ImageWidth="16" />
                                                    </asp:Panel>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <div align="center">
                                                    <asp:LinkButton ID="lbItem6" runat="server" Text="EDITAR" />
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="text-align: center;">
                                                    <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click" ToolTip="Editar Registro">

                                                 <img src="../Resources/Imagenes/Paginas/edit_blue.png"  height="15px"  alt="edit" />
                                                    </asp:LinkButton>
                                                </div>
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
                    <nav class="navbar navbar-fixed-bottom" style="height: 0px; vertical-align: central;">
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
                <%-- <asp:DropDownList ID="RegistrosVisiblesDropDownList" runat="server" AutoPostBack="true"
                CssClass="comboBoxTable" OnSelectedIndexChanged="RegistrosVisiblesDropDownList_SelectedIndexChanged"/>--%>
            </ContentTemplate>
            <%-- <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BuscarTextBox" EventName="TextChanged" />
        </Triggers>--%>
        </asp:UpdatePanel>
        <div align="center" id="myModal" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="False">
                                    &times;</button>
                                <h4 style="text-align: left;">
                                    <asp:Label ID="TituloModalPanel" CssClass="lblTitulo" runat="server" />
                                </h4>
                            </div>
                            <div class="modal-body">
                                <table style="border-spacing: 2px; border-collapse: separate; margin-left: 15px"
                                    cellpadding="2">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Código" Font-Bold="True" />
                                        </td>
                                        <td>
                                            <asp:TextBox autocomplete="off" ID="CodigoModalTxt" runat="server" MaxLength="2" CssClass="form-control" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LblLinea" runat="server" Text="Línea" Font-Bold="True" />
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="LineaDropDownList" CssClass="form-control" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LblTipoDanio" runat="server" Text="Tipo Daño" Font-Bold="True" />
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="TipoDanioDropDownList" CssClass="form-control" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label  runat="server" Text="Tipo Reparación" Font-Bold="True" />
                                        </td>
                                        <td>
                                            <asp:TextBox autocomplete="off" runat="server" ID="TipoReparacionTextBox" MaxLength="1" CssClass="form-control" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text="Cantidad H/H" Font-Bold="True" />
                                        </td>
                                        <td>
                                            <asp:TextBox autocomplete="off" runat="server" ID="CantidadTxt" MaxLength="10" CssClass="form-control" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text="EMC CodE" Font-Bold="True" />
                                        </td>
                                        <td>
                                            <asp:TextBox autocomplete="off" runat="server" ID="EMCCodETxt" MaxLength="2" CssClass="form-control" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Descripción" Font-Bold="True" />
                                        </td>
                                        <td>
                                            <asp:TextBox autocomplete="off" ID="DescripcionModalTxt" runat="server" CssClass="form-control" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Estado" Font-Bold="True" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="EstadoModal" runat="server" />
                                            <ajaxToolkit:ToggleButtonExtender ID="EstadoModalToggleButtonExtender" runat="server"
                                                TargetControlID="EstadoModal" CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png" UnCheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png" ImageHeight="16"
                                                ImageWidth="16" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="AceptarButton" class="btn btn-primary" Text="Guardar" runat="server"
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
