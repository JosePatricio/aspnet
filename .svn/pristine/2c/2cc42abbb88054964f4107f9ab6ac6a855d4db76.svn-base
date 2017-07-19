<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard2.aspx.cs" Inherits="Sigeor.Menu.Dashboard2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DashBoard</title>
    <script type='text/javascript' src="../Resources/Scripts/jquery.js"></script>
    <script src="../Resources/Scripts/Utilidades.js" type="text/javascript"></script>
    <script type="text/javascript">
        RestringirClickMouse();
    </script>

    <script src="../Resources/Highcharts/jquery.min.js" type="text/javascript"></script>
    <script src="../Resources/Highcharts/highcharts/4.1.5/highcharts.js" type="text/javascript"></script>
    <script src="../Resources/Highcharts/highcharts/4.1.5/highcharts-3d.js" type="text/javascript"></script>
    <script src="../Resources/Highcharts/highcharts/4.1.5/exporting.js" type="text/javascript"></script>





    <link href="../Resources/Carousel/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Resources/Carousel/bootstrap.min.css" rel="stylesheet" />
    <script src="../Resources/Carousel/bootstrap.min.js" type="text/javascript"></script>


    <script src="../Resources/Highcharts/ChartTotalesEstimadoReal.js" type="text/javascript"></script>
    <script src="../Resources/Highcharts/ChartTotalesEstimadoRealPorLinea.js" type="text/javascript"></script>

    <script type="text/javascript">



        function Consultar() {

            var e = document.getElementById("ddllinea");
            var CodigoLinea = e.options[e.selectedIndex].value;


            obtenerTotalesEorEstructuraTodosEstimadoPorLinea(CodigoLinea);
            obtenerTotalesEorMaquinariaTodosEstimadoPorLinea(CodigoLinea);
            obtenerTotalesEorTransitoTodosEstimadoPorLinea(CodigoLinea);
            obtenerTotalesEorEstructuraTodosRealPorLinea(CodigoLinea);
            obtenerTotalesEorMaquinariaTodosRealPorLinea(CodigoLinea);
            obtenerTotalesEorTransitoTodosRealPorLinea(CodigoLinea);


        }
    </script>

    <script type="text/javascript">
        $(function () {
            $('#myCarousel').carousel({
                interval: false,
                pause: "false"
            });
            $('#playButton').click(function () {
                $('#myCarousel').carousel('cycle');
            });
            $('#pauseButton').click(function () {
                $('#myCarousel').carousel('pause');
            });


            $('#myCarousel2').carousel({
                interval: false,
                pause: "false"
            });
            $('#playButton2').click(function () {
                $('#myCarousel2').carousel('cycle');
            });
            $('#pauseButton2').click(function () {
                $('#myCarousel2').carousel('pause');
            });

        }
        );


    </script>


    <style type="text/css">
        .tales {
            width: 100%;
        }

        .carousel-inner {
            width: 100%;
            max-height: 100% !important;
            height: 450px;
        }

        .carousel-control {
            width: 1.5%;
        }
    </style>



</head>
<body >
    <link href="../Resources/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
     
    <form autocomplete="on"  id="form1" runat="server" style="width: 100%;">

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
        <div class="panel panel-primary" style="width: 100%;">
            <div class="panel-heading" >
                <table id="Table1" width="100%" runat="server">
                    <tr id="Tr1" style="border: 1px" runat="server">
                        <td id="Td1" runat="server">
                            <h4>
                                <asp:Label ID="lblCabecera" ForeColor="#ffffff" runat="server" Text="DashBoards"></asp:Label>
                            </h4>
                        </td>                       
                    </tr>
                </table>
            </div>
        </div>

        <div class="container" style="width:100%; margin : 0 auto;">

            <ul class="nav nav-tabs small">
                <li class="active"><a data-toggle="tab" style="color: white; background-color: #333333" href="#home">Valores por Año</a></li>
                <li><a data-toggle="tab" style="color: white; background-color: #333333" href="#menu1">Valores por Líneas</a></li>

            </ul>

            <div class="tab-content small">
                <div id="home" class="tab-pane fade in active">
                    <br />
                    <div id="myCarousel" class="carousel slide" data-ride="carousel">
                        <!-- Indicators -->
                        <ol class="carousel-indicators">
                            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                            <li data-target="#myCarousel" data-slide-to="1"></li>
                            <li data-target="#myCarousel" data-slide-to="2"></li>

                        </ol>

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner" role="listbox">
                            <div class="item active">

                                <div class="table-responsive">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <div id="containerEorEstructura" class="containerEorEstructura" style="width: 670px; height: 400px"></div>
                                            </td>
                                            <td>
                                                <div id="containerEorEstructuraReal" class="containerEorEstructuraReal" style="width: 670px; height: 400px"></div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                            <div class="item">
                                <div class="table-responsive">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <div id="containerEorMaquinaria" class="containerEorMaquinaria" style="width: 670px; height: 400px"></div>
                                            </td>
                                            <td>
                                                <div id="containerEorMaquinariaReal" class="containerEorMaquinariaReal" style="width: 670px; height: 400px"></div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                            <div class="item">
                                <div class="table-responsive">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <div id="containerEorTransito" class="containerEorTransito" style="width: 670px; height: 400px"></div>
                                            </td>
                                            <td>
                                                <div id="containerEorTransitoReal" class="containerEorTransitoReal" style="width: 670px; height: 400px"></div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>


                        </div>


                        <div id="carouselButtons" align="center" style="display: none">
                            <button id="playButton" type="button" class="btn btn-default btn-xs">
                                <span class="glyphicon glyphicon-play"></span>
                            </button>
                            <button id="pauseButton" type="button" class="btn btn-default btn-xs">
                                <span class="glyphicon glyphicon-pause"></span>
                            </button>
                        </div>

                        <!-- Left and right controls -->
                        <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev" style="width: 20px;">
                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>


                        <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next" style="width: 20px;">
                            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>

                    </div>
                </div>
                <div id="menu1" class="tab-pane fade">

                    <div class="row">     
                        <br/>                   
                        <div class="col-sm-1">Lineas:</div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddllinea" runat="server" CssClass="form-control small" onchange="Consultar()" />
                        </div>
                    </div>
                    <br/>
                    <div id="myCarousel2" class="carousel slide" data-ride="carousel">
                        <!-- Indicators -->
                        <ol class="carousel-indicators">
                            <li data-target="#myCarousel2" data-slide-to="0" class="active"></li>
                            <li data-target="#myCarousel2" data-slide-to="1"></li>
                            <li data-target="#myCarousel2" data-slide-to="2"></li>

                        </ol>

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner" role="listbox">
                            <div class="item active">

                                <%--<div class="table-responsive">--%>
                                    <table>
                                        <tr>
                                            <td>
                                                <div id="containerEorEstructura2" class="containerEorEstructura" style="width: 670px; height: 400px"></div>
                                            </td>
                                            <td>
                                                <div id="containerEorEstructuraReal2" class="containerEorEstructuraReal" style="width: 670px; height: 400px"></div>
                                            </td>
                                        </tr>
                                    </table>
                                <%--</div>--%>
                            </div>

                            <div class="item">
                                <div class="table-responsive">
                                    <table >
                                        <tr>
                                            <td>
                                                <div id="containerEorMaquinaria2" class="containerEorMaquinaria" style="width: 670px; height: 400px"></div>
                                            </td>
                                            <td>
                                                <div id="containerEorMaquinariaReal2" class="containerEorMaquinariaReal" style="width: 670px; height: 400px"></div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                            <div class="item">
                                <div class="table-responsive">
                                    <table style="width: 98%;">
                                        <tr>
                                            <td>
                                                <div id="containerEorTransito2" class="containerEorTransito" style="width: 670px; height: 400px"></div>
                                            </td>
                                            <td>
                                                <div id="containerEorTransitoReal2" class="containerEorTransitoReal" style="width: 670px; height: 400px"></div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>


                        </div>


                        <div id="carouselButtons2" align="center" style="display: none">
                            <button id="playButton2" type="button" class="btn btn-default btn-xs">
                                <span class="glyphicon glyphicon-play"></span>
                            </button>
                            <button id="pauseButton2" type="button" class="btn btn-default btn-xs">
                                <span class="glyphicon glyphicon-pause"></span>
                            </button>
                        </div>

                        <!-- Left and right controls -->
                        <a class="left carousel-control" href="#myCarousel2" role="button" data-slide="prev" style="width: 20px;">
                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control " href="#myCarousel2" role="button" data-slide="next" style="width: 20px;">
                            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>





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

