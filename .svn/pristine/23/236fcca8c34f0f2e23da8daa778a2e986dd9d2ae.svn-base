<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChartWebForm.aspx.cs" Inherits="Sigeor.ReportesAspx.ChartWebForm" %>

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
    <script type='text/javascript' src='//code.jquery.com/jquery-compat-git.js'></script>
    <script type='text/javascript' src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script type='text/javascript' src="http://mrrio.github.io/jsPDF/dist/jspdf.debug.js"></script>
    <script type='text/javascript'>//<![CDATA[

        function demoFromHTML() {
            var pdf = new jsPDF('p', 'pt', 'letter');
            source = $('#filtros')[0];
            specialElementHandlers = {
                '#bypassme': function (element, renderer) {
                    return true
                }
            };
            margins = {
                top: 80,
                bottom: 60,
                left: 40,
                width: 522
            };
            pdf.fromHTML(
            source, // HTML string or DOM elem ref.
            margins.left, // x coord
            margins.top, { // y coord
                'width': margins.width, // max width of content on PDF
                'elementHandlers': specialElementHandlers
            },

            function (dispose) {
                pdf.save('Test.pdf');
            }, margins);
        }
        //]]> 

    </script>
</head>
<body>
    <script src="../Resources/Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../Resources/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Resources/Styles/jquery.toastmessage.css" rel="stylesheet" />
    <script src="../Resources/Scripts/jquery.toastmessage.js" type="text/javascript"></script>
    <form id="formularioPrincipal" runat="server" style="width: 100%; height: 100%;">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"
        EnableScriptLocalization="True" />
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
    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" AutoPostBack="true"
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Value="0">Exportar</asp:ListItem>
        <asp:ListItem Value="1">Exportar Estimado</asp:ListItem>
        <asp:ListItem Value="2">Exportar Real</asp:ListItem>
    </asp:DropDownList>
    <asp:UpdatePanel ID="GridViewUpdatePanel" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="container" style="width: 100%;" id="customers">
                <div class="row">
                    <div class="panel-group" id="accordion" style="overflow: auto;">
                        <div class="panel">
                            <div class="panel-heading btn-default">
                                <h3 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#filtros">Estimado</a>
                                </h3>
                            </div>
                            <div id="filtros" class="panel-collapse collapse in">
                                <div class="panel-body center-block">
                                    <div>
                                        <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" Height="160px" Width="1350px"
                                            BackSecondaryColor="White" BackGradientStyle="TopBottom"
                                            BorderWidth="2px" BackColor="211, 223, 240" BorderColor="#1A3B69">
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1">
                                                    <Area3DStyle Rotation="10" Perspective="2" Inclination="0" IsRightAngleAxes="False"
                                                        WallWidth="0" IsClustered="False"></Area3DStyle>
                                                    <AxisY LineColor="64, 64, 64, 64" Title="Valores Estimados">
                                                        <LabelStyle Font="Trebuchet MS, 8.25pt" />
                                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                                    </AxisY>
                                                    <AxisX LineColor="64, 64, 64, 64" Title="Período">
                                                        <LabelStyle Font="Trebuchet MS, 8.25pt" />
                                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                                    </AxisX>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-group" id="accordion2">
                        <div class="panel">
                            <div class="panel-heading btn-default">
                                <h3 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#filtros2">Real</a>
                                </h3>
                            </div>
                            <div id="filtros2" class="panel-collapse collapse in">
                                <div class="panel-body center-block">
                                    <div>
                                        <asp:Chart ID="Chart2" runat="server" OnLoad="Chart2_Load" Height="160px" Width="1350px"
                                         BackSecondaryColor="White" BackGradientStyle="TopBottom"
                                            BorderWidth="2px" BackColor="211, 223, 240" BorderColor="#1A3B69">
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1">
                                                    <Area3DStyle Rotation="10" Perspective="2" Inclination="0" IsRightAngleAxes="False"
                                                        WallWidth="0" IsClustered="False"></Area3DStyle>
                                                    <AxisY LineColor="64, 64, 64, 64" Title="Valores Reales">
                                                        <LabelStyle Font="Trebuchet MS, 8.25pt" />
                                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                                    </AxisY>
                                                    <AxisX LineColor="64, 64, 64, 64" Title="Período">
                                                        <LabelStyle Font="Trebuchet MS, 8.25pt" />
                                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                                    </AxisX>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="myLoading" class="modal fade" style="pointer-events: none; margin-top: 23%;">
        <div class="modal-dialog modal-sm">
            <div class="modal-content ">
                <h5 style="text-align: center;">
                    Procesando...</h5>
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
