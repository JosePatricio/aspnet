<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionDocumentosWebForm.aspx.cs"
    Inherits="Sigeor.Configuracion.GestionDocumentosWebForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Gestión de Documentos</title>

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
                                                    <asp:LinkButton ID="NuevoLinkButton" runat="server" OnClick="NuevoLinkButton_Click" CssClass="lblTabla"
                                                        ToolTip="Nuevo Registro"><span class="glyphicon glyphicon-plus-sign"></span> Cargar Documento</asp:LinkButton>
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
                                <asp:GridView ID="DocumentosGridView" Width="96%" runat="server"
                                    AllowSorting="false" CssClass="table table-striped table-bordered table-condensed table-hover small table-hover table-responsive" AlternatingRowStyle-BackColor="#E6E6FA"
                                    OnRowDataBound="DocumentosGridView_RowDataBound" AutoGenerateColumns="false"
                                    DataKeyNames="Id">
                                    <EmptyDataRowStyle BackColor="LightBlue" />
                                    <EmptyDataTemplate>
                                        No se encontraron registros Disponibles.
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField Visible="False">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbItemId" runat="server" Text="Id" />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("Id")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <div align="center">
                                                    <asp:LinkButton ID="lbItemCedula" runat="server" Text="USUARIO" />
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div align="center">
                                                    <%#Eval("Cedula")%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <div align="center">
                                                    <asp:LinkButton ID="lbItemNombre" runat="server" Text="NOMBRE DOCUMENTO" />
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("Nombre")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <div align="center">
                                                    <asp:LinkButton ID="lbItemTmano" runat="server" Text="TAMAÑO (Kb)" />
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div align="right">
                                                    <%#Eval("Tamano")%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <div align="center">
                                                    <asp:LinkButton ID="lbItemDescargar" runat="server" Text="DESCARGAR" />
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <center>
                                                    <asp:LinkButton ID="a3" runat="server" OnDataBinding="PostBackBind_DataBinding" ToolTip="Descargar"
                                                        OnClick="lnkDescargar_Click">
                                                        <img src="../Resources/Imagenes/Paginas/download_blue.png"  height="15px"  alt="edit" />
                                                    </asp:LinkButton>
                                                </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <div align="center">
                                                    <asp:LinkButton ID="lbItemEliminar" runat="server" Text="ELIMINAR" />
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <center>
                                                    <asp:LinkButton ID="lnkEdit" OnClick="lnkEliminar_Click" runat="server" ToolTip="Eliminar Documento"> 
                                                    <img src="../Resources/Imagenes/Paginas/delete_blue.png" height="15px"  alt="Delete" /></asp:LinkButton></center>
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
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="myModal" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h4>
                                    <asp:Label ID="lblTituloDocumento" CssClass="lblTitulo" runat="server"></asp:Label>
                                </h4>
                            </div>
                            <br />
                            <div class="modal-body" align="center">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <br />
                                <asp:RegularExpressionValidator ID="REGEXFileUploadLogo" runat="server" ForeColor="white"
                                    ErrorMessage="Tipo de archivo no admitido" BackColor="#333333" ControlToValidate="FileUpload1" ValidationExpression="(.*).(.pptx|.html|.xlm|.xlsx|.xls|.csv|.dothtml|.docx|.dot|.pohtml|.ppt|
                            .pps|.back|.log|.exc|.dochtml|.pdf|.txt|.doc|.zip|.tar|.rar|.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.bmp|.BMP|.png|.PNG)$" />
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="SaveButton" class="btn btn-primary" Text="Cargar" runat="server"
                                    OnClick="AceptarButton_Click" />
                                <button type="button" class="btn btn-primary" data-dismiss="modal">
                                    Cancelar</button>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="SaveButton" />
                        </Triggers>
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
