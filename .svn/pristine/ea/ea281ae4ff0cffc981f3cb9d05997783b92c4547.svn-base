<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAlertas.aspx.cs" Inherits="Sigeor.Menu.MenuAlertas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alertas</title>

    <script type='text/javascript' src="../Resources/Scripts/jquery.js"> </script>
        
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
                            <table id="Table1" width="100%" runat="server" cellpadding="0">
                                <tr id="Tr1" style="border: 1px" runat="server">
                                    <td id="Td1" runat="server">
                                        <h4>
                                            <asp:Label ID="lblCabecera" runat="server"></asp:Label></h4>

                                    </td>
                                    <td id="Td2" align="right" runat="server">
                                        <table id="Table2" runat="server" cellpadding="0">
                                            <tr id="Tr2" runat="server">
                                                <td id="Td3" runat="server">
                                                    <asp:LinkButton ID="ReporteLinkButton" runat="server" ToolTip="Ver Reporte" OnClick="VerReporte" CssClass="lblTabla">
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

                                        <%--<div class="col-xs-12" style="height: 2px;"/>--%>
                                        <!-- Espacio en blanco entre filas-->

                                        <br />

                                        <div class="row" style="width: 60%; margin: auto; margin-top: auto;">
                                            <div class="input-group">
                                                <asp:TextBox autocomplete="off" Width="100%" runat="server" ID="BuscarTextBox" CssClass="form-control"
                                                    TabIndex="1" placeholder="Buscar por: Num. Eor, Tipo Eor, Descripción" ToolTip="Ingrese el campo a buscar." MaxLength="50" />
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
                                        <asp:GridView ID="AlertasGridView" runat="server" AllowSorting="false"
                                            CssClass="table table-striped table-bordered table-condensed table-hover small table-hover table-responsive"
                                            OnRowDataBound="AlertasGridView_RowDataBound" AlternatingRowStyle-BackColor="#E6E6FA"
                                            AutoGenerateColumns="false" Width="98%" DataKeyNames="Id">
                                            <EmptyDataRowStyle BackColor="LightBlue" />
                                            <EmptyDataTemplate>
                                                No se encontraron registros Disponibles.
                                            </EmptyDataTemplate>

                                            <Columns>
                                                <asp:TemplateField SortExpression="NumEorSort">
                                                    <HeaderTemplate>
                                                        <center>
                                                            <asp:LinkButton runat="server" Text="EOR" CommandName="Sort" CommandArgument="NUM_EOR" />
                                                        </center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("NUMEOR")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="TipoEorSort">
                                                    <HeaderTemplate>
                                                        <center>
                                                            <asp:LinkButton runat="server" Text="TIPO EOR" CommandName="Sort" CommandArgument="TIPO_EOR" />
                                                        </center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("TIPOEOR")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="DescripcionSort">
                                                    <HeaderTemplate>
                                                        <center>
                                                            <asp:LinkButton runat="server" Text="DESCRIPCION" CommandName="Sort" CommandArgument="DESCRIPCION" />
                                                        </center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="left">
                                                            <%#Eval("DESCRIPCION")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="FechaEmisionSort">
                                                    <HeaderTemplate>
                                                        <center>
                                                            <asp:LinkButton runat="server" Text="FECHA EMISION" CommandName="Sort" CommandArgument="FECHA_EMISION" />
                                                        </center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center">
                                                            <%#Eval("FechaEmision")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="ValorEstimadoSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="MAT. EST." CommandName="Sort" CommandArgument="VALOR_ESTIMADO" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <%#Eval("ValorMatEstimado")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="ValorRealSort">
                                                    <HeaderTemplate>
                                                        <center>
                                                            <asp:LinkButton runat="server" Text="MAT. REAL" CommandName="Sort" CommandArgument="VALOR_REAL" />
                                                        </center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <%#Eval("ValorMatReal")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>


                                             <Columns>
                                                <asp:TemplateField SortExpression="ValorEstimadoSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="M.O EST." CommandName="Sort" CommandArgument="VALOR_ESTIMADO" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <%#Eval("ValorHHEstimado")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="ValorRealSort">
                                                    <HeaderTemplate>
                                                        <center>
                                                            <asp:LinkButton runat="server" Text="M.O REAL" CommandName="Sort" CommandArgument="VALOR_REAL" />
                                                        </center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <%#Eval("ValorHHReal")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>











                                             <Columns>
                                                <asp:TemplateField SortExpression="ValorEstimadoSort">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" Text="PTI EST." CommandName="Sort" CommandArgument="VALOR_ESTIMADO" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <%#Eval("ValorPtiEstimado")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField SortExpression="ValorRealSort">
                                                    <HeaderTemplate>
                                                        <center>
                                                            <asp:LinkButton runat="server" Text="PTI REAL" CommandName="Sort" CommandArgument="VALOR_REAL" />
                                                        </center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <%#Eval("ValorPtiReal")%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>








                                            <Columns>
                                                <asp:TemplateField SortExpression="CampoTipoAlertaSort">
                                                    <HeaderTemplate>
                                                        <center>
                                                            <asp:LinkButton runat="server" Text="TIPO ALERTA" CommandName="Sort" CommandArgument="CAMPO_TIPO_ALERTA" />
                                                        </center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>

                                                        <div align="center">
                                                            <%#Eval("TIPOALERTA")%>
                                                        </div>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <center>
                                                            <asp:LinkButton ID="lbItemEditar" runat="server" Text="REVISAR" />
                                                        </center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div style="text-align: center;">
                                                            <asp:LinkButton ID="lnkEdit" OnClick="lnkEdit_Click" runat="server" ToolTip="Marcar Alerta como Revisada"> 
                                                                <img src="../Resources/Imagenes/Paginas/un_check_blue.png"  height="15px"  alt="Marcar Alerta como Revisada" />
                                                            </asp:LinkButton>
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
                    <nav class="navbar navbar-fixed-bottom" style="height: 0%;" style="background-color: background-color: #337ab7; vertical-align: central;">
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
                                    runat="server" MaxLength="7" OnTextChanged="paginaActualTextBox_OnTextChanged"
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
                         <asp:DropDownList ID="RegistrosVisiblesDropDownList1" AutoPostBack="True" OnSelectedIndexChanged="RegistrosVisiblesDropDownList_SelectedIndexChanged"
                            runat="server" />
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
