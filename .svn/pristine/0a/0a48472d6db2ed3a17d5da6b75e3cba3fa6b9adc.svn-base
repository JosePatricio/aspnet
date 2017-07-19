<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionUsuariosWebForm.aspx.cs"
    Inherits="Sigeor.Configuracion.GestionUsuariosWebForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Gestión de Usuarios</title>

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
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

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
                            <asp:Panel ID="Panel1" ScrollBars="Auto" runat="server" CssClass="col-xs-offset-025">
                                <asp:GridView ID="UsuarioGridView" Width="96%" runat="server" AllowSorting="false"
                                    CssClass="table table-striped table-bordered table-condensed table-hover small table-hover table-responsive"
                                    AlternatingRowStyle-BackColor="#E6E6FA" OnRowDataBound="UsuarioGridView_RowDataBound"
                                    AutoGenerateColumns="false" DataKeyNames="Cedula">
                                    <EmptyDataRowStyle BackColor="LightBlue" />
                                    <EmptyDataTemplate>
                                        No se encontraron registros disponibles.
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField SortExpression="CedulaSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItemCedula" runat="server" Text="CÉDULA" CommandName="Sort" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("Cedula") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="NombreSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItemNombre" runat="server" Text="NOMBRE" CommandName="Sort" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("Nombre")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="ApellidoSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItemApellido" runat="server" Text="APELLIDO" CommandName="Sort" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("Apellido")%>
                                                <%--  <%# DataBinder.Eval(ContainerType.Item,"usuarioPerfil.Usuario.Nombre")%>
                                                --%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="DireccionSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItemDireccion" runat="server" Text="DIRECCIÓN" CommandName="Sort" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("Direccion")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="CelularSort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItemCelular" runat="server" Text="CELULAR" CommandName="Sort" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("Celular")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Emailort">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItemEmail" runat="server" Text="E-MAIL" CommandName="Sort" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("Email")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItemGenerar" runat="server" Text="GENERAR" />
                                            </HeaderTemplate>
                                            <ItemTemplate>

                                                <div align="center">
                                                    <table>
                                                        <tr>
                                                            <td style="border: transparent;">
                                                                <asp:LinkButton ID="linkContrasena" runat="server" ToolTip="Generar contraseña" OnClick="linkContrasena_Click"> 
                                                                <img src="../Resources/Imagenes/Paginas/lock_blue.png" height="15px"  alt="contrasena" />
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>&nbsp;&nbsp;
                                                            </td>
                                                            <td style="border: transparent;">
                                                                <asp:LinkButton ID="linkKey" runat="server" ToolTip="Generar e-Key" OnClick="linkEkey_Click"> 
                                                                <img src="../Resources/Imagenes/Paginas/key_blue.png" height="15px"  alt="key" />
                                                                </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <div align="center">
                                                    <asp:LinkButton ID="lbItemEstado" runat="server" Text="ESTADO" CommandName="Sort"
                                                        CommandArgument="Estado" />
                                                    <br />
                                                    <asp:CheckBox Width="10%" ID="EstadoCabeceraGridView" runat="server" AutoPostBack="true"
                                                        OnCheckedChanged="EstadoCabeceraGridView_CheckedChanged" Checked='<%#EstadoCheckBox.Checked%>'
                                                        ToolTip='<%#EstadoCheckBox.Checked.Equals(true)?"Inactivar Todos":"Activar Todos"%>' />
                                                    <ajaxToolkit:ToggleButtonExtender ID="ToggleButtonExtender2" runat="server" TargetControlID="EstadoCabeceraGridView"
                                                        CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png" UncheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png"
                                                        ImageHeight="16" ImageWidth="16" />
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div align="center">
                                                    <asp:CheckBox Width="10%" ID="EstadoCheckBoxGridView" runat="server" AutoPostBack="true"
                                                        Checked='<%#Eval("Estado")%>' OnCheckedChanged="EstadoCheckBoxGridView_CheckedChanged"
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
                    </div>
                </nav>
                </div>
                </label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="myModal" align="center" class="modal fade">
            <div class="modal-lg">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h4>
                                    <asp:Label ID="TituloModalPanel" CssClass="lblTitulo" runat="server" Text="Editar Usuario"></asp:Label>
                                </h4>
                            </div>
                            <div class="modal-body" align="center">
                                <div class="table-responsive">
                                    <table style="border-spacing: 2px; border-collapse: separate; margin-left: 15px"
                                        cellpadding="2">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblModalCedula" runat="server" Text="Cédula"></asp:Label>
                                            </td>
                                            <td style="width: 50%;">
                                                <asp:TextBox autocomplete="off" ID="CedulaModalTxt" CssClass="form-control" runat="server" MaxLength="10" />
                                            </td>
                                            <td rowspan="5">&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td rowspan="5" style="width: 50%;">
                                                <div style="height: 200px; width: 100%; overflow: auto;">

                                                    <asp:GridView ID="gridviewPrueba" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                                                        Width="100%" AlternatingRowStyle-BackColor="#E6E6FA"
                                                        OnRowDataBound="PerfilesGridView_RowDataBound"
                                                        CssClass="table table-striped table-bordered table-condensed table-hover small table-hover table-responsive">
                                                        <RowStyle HorizontalAlign="Left"></RowStyle>
                                                        <EmptyDataRowStyle BackColor="LightBlue" />
                                                        <EmptyDataTemplate>
                                                            No se encontraron registros Disponibles.
                                                        </EmptyDataTemplate>
                                                        <Columns>

                                                            <asp:BoundField DataField="Codigo" HeaderText="COD. PERFIL" HtmlEncode="false" />
                                                            <asp:BoundField DataField="Descripcion" HeaderText="PERFILES DISPONIBLES" HtmlEncode="false" />



                                                            <asp:TemplateField HeaderText="Estado">
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="chkAll" onclick="javascript: SelectAllCheckboxes1(this);" runat="server" />
                                                                    <ajaxToolkit:ToggleButtonExtender ID="EstadoModalToggleButtonExtender" runat="server"
                                                                        TargetControlID="chkAll" CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png"
                                                                        UncheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png" ImageHeight="16"
                                                                        ImageWidth="16" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkestado" runat="server" Checked='<%# Eval("Estado") %>' />
                                                                    <ajaxToolkit:ToggleButtonExtender ID="EstadoModalToggleButtonExtender" runat="server"
                                                                        TargetControlID="chkestado" CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png"
                                                                        UncheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png" ImageHeight="16"
                                                                        ImageWidth="16" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>


                                                </div>
                                                <script type="text/javascript">
                                                    function SelectAllCheckboxes1(chk) {
                                                        $('#<%=gridviewPrueba.ClientID%>').find("input:checkbox").each(function () {
                                                            if (this != chk) { this.checked = chk.checked; }
                                                        });
                                                    }            </script>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblModalNombre" runat="server" Text="Nombre" />
                                            </td>
                                            <td>
                                                <asp:TextBox autocomplete="off" ID="NombreModalTxt" CssClass="form-control" runat="server" MaxLength="30" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblModalApellido" runat="server" Text="Apellido" />
                                            </td>
                                            <td>
                                                <asp:TextBox autocomplete="off" ID="ApellidoModalTxt" CssClass="form-control" runat="server" MaxLength="30" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblModalDireccion" runat="server" Text="Dirección" MaxLength="50" />
                                            </td>
                                            <td>
                                                <asp:TextBox autocomplete="off" ID="DireccionModalTxt" CssClass="form-control" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblModalCelular" runat="server" Text="Celular" />
                                            </td>
                                            <td>
                                                <asp:TextBox autocomplete="off" ID="CelularModalTxt" CssClass="form-control" runat="server" MaxLength="10" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblModalCorreo" runat="server" Text="E-mail"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox autocomplete="off" ID="CorreoModalTxt" CssClass="form-control" runat="server" MaxLength="50" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblModalEstado" runat="server" Text="Estado" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="EstadoModal" runat="server" />
                                                <ajaxToolkit:ToggleButtonExtender ID="EstadoModalToggleButtonExtender" runat="server"
                                                    TargetControlID="EstadoModal" CheckedImageUrl="~/Resources/Imagenes/Paginas/check_blue.png" UncheckedImageUrl="~/Resources/Imagenes/Paginas/un_check_blue.png" ImageHeight="16"
                                                    ImageWidth="16" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
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
