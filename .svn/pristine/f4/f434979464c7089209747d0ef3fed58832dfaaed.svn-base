<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Sigeor.Menu.Dashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DashBoard</title>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <%--<script src="../Resources/Highcharts/highcharts/4.1.5/exporting.js" type="text/javascript"></script>--%>


    <script src="../Resources/Highcharts/api/js/jquery-1.11.3.min.js" type="text/javascript"></script>
    <script src="../Resources/Highcharts/js/highcharts.js" type="text/javascript"></script>
    <script src="../Resources/Highcharts/export/exporting.js" type="text/javascript"></script>
    <script src="../Resources/Highcharts/export/offline-exporting.js" type="text/javascript"></script>

    <link href="../Resources/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Resources/Bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="../Resources/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>

    <script type="text/javascript">


        $(document).ready(function () {

            $.ajax({
                type: "POST",
                url: "../ServiciosAsmx/DashboardService.asmx/CargarAniosEstimados",
                // data: '{name: "abc" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    $.each(data.d.data, function (indice, anio) {
                        //alert('anio item: ' + indice + '  => ' + anio);
                        $("#ddlAnios").append($("<option/>").val(anio).text(anio));
                        $("#ddlAnios").val(anio);
                    });

                    var anioSeleccionado = $('#ddlAnios').val();

                    CargarMesesPorAnio(anioSeleccionado);
                    CargarEstimadosLineaPorAnioMaterial(anioSeleccionado);
                    CargarEstimadosLineaPorAnioManoObra(anioSeleccionado);
                    CargarEstimadosLineaPorAnioPti(anioSeleccionado);
                },
                failure: function () {
                    alert("Failed!");
                }
            });

            function CargarMesesPorAnio(anio) {
                $.ajax({
                    type: "POST",
                    url: "../ServiciosAsmx/DashboardService.asmx/CargarMesesEstimadosPorAnio",
                    data: "{anio: " + anio + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $("#ddlMeses").empty();
                        $.each(data.d.names, function (indice, mes) {
                            $("#ddlMeses").append($("<option/>").val(mes).text(mes));
                            $("#ddlMeses").val(mes);
                        });
                        CargarEstimadosLineaPorAnioMesMaterial(anio, $("#ddlMeses").val());
                        CargarEstimadosLineaPorAnioMesManoObra(anio, $("#ddlMeses").val());
                        CargarEstimadosLineaPorAnioMesPti(anio, $("#ddlMeses").val());
                    },
                    failure: function () {
                        alert("Failed!");
                    }
                });
            }


            ////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////SERVICIOS DE MATERIAL/////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////

            function CargarEstimadosLineaPorAnioMaterial(anio) {
                $.ajax({
                    type: "POST",
                    url: "../ServiciosAsmx/DashboardService.asmx/ObtenerEstimadoLineaPorAnioMaterial",
                    data: "{anio: " + anio + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response, status) {
                        var lista = response.d;
                        DibujarChartLineasPorAnioMaterial('estimadoLineasPorAnioMaterial', lista);
                        CargarConsolidadLineasPorAnioMaterial(anio);
                    },
                    error: function (response) {
                        alert(response.status + " " + response.statusText);
                    }
                });
            }

            function CargarEstimadosLineaPorAnioMesMaterial(anio, mes) {
                $.ajax({
                    type: "POST",
                    url: "../ServiciosAsmx/DashboardService.asmx/ObtenerEstimadoLineaPorAnioMesesMaterial",
                    data: "{anio:" + anio + ",mes: '" + mes + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response, status) {
                        var lista = response.d;
                        DibujarChartLineasPorMesesMaterial('estimadoConsolidadLineasPorMesesMaterial', lista);
                    },
                    error: function (response) {
                        alert(response.status + " " + response.statusText);
                    }
                });
            }

            function CargarConsolidadLineasPorAnioMaterial(anio) {
                $.ajax({
                    type: "POST",
                    url: "../ServiciosAsmx/DashboardService.asmx/ObtenerConsolidadoLineasPorAnioMaterial",
                    data: "{anio:" + anio + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response, status) {
                        var lista = response.d;
                        DibujarChartConsolidadoLineasPorAnioMaterial('CargarConsolidadLineasPorAnioMaterial', lista);
                    },
                    error: function (response) {
                        alert(response.status + " " + response.statusText);
                    }
                });
            }

            function DibujarChartLineasPorAnioMaterial(idDiv, series) {
                var options = {
                    chart: {
                        renderTo: 'stats',
                        type: 'spline',
                    },
                    title: {
                        text: 'MATERIAL AÑO ' + $("#ddlAnios").val() // título
                    },
                    tooltip: {
                        pointFormat: '{series.name}: <b>${point.y}</b>'
                    },

                    yAxis: {
                        title: {
                            text: 'Valores ($)'
                        },

                        plotLines: [{
                            allowPointSelect: true,
                            cursor: 'pointer',
                            value: 0,
                            width: 1
                        }]
                    },
                    credits: {
                        enabled: false
                    },
                    xAxis: {
                        categories: [],
                        labels: {
                            rotation: -45,
                            style: {
                                fontSize: '11px',
                                fontFamily: 'Verdana, sans-serif'
                            }
                        }
                    },
                    series: []
                }
                for (var i = 0; i < series.length; i++) {

                    var serie = new Array(series[i].name, series[i].data)
                    //alert('Serie => ' + JSON.stringify(serie));
                    options.series.push(series[i]);

                    for (var j = 0; j < series[i].categorias.length; j++) {
                        var categorias = new Array(series[i].categorias[j]);
                        options.xAxis.categories.push(categorias);
                    }
                }
                $('#' + idDiv).highcharts(options);
            }

            function DibujarChartLineasPorMesesMaterial(idDiv, series) {
                var options = {
                    chart: {
                        renderTo: 'stats',
                        type: 'column',
                    },
                    title: {
                        text: 'MATERIAL ' + $("#ddlMeses").val() + '/' + $("#ddlAnios").val()// título
                    },
                    tooltip: {
                        pointFormat: '{series.name}: <b>${point.y}</b>'
                    },
                    yAxis: {
                        title: {
                            text: 'Valores ($)'
                        },
                        plotLines: [{
                            allowPointSelect: true,
                            cursor: 'pointer',
                            value: 0,
                            width: 0.5,
                        }]
                    },
                    xAxis: {
                        categories: [],
                        labels: {
                            rotation: -45,
                            style: {
                                fontSize: '11px',
                                fontFamily: 'Verdana, sans-serif'
                            }
                        }
                    },
                    credits: {
                        enabled: false
                    },
                    series: []
                }

                for (var i = 0; i < series.length; i++) {

                    var serie = new Array(series[i].name, series[i].data)
                    options.series.push(series[i]);

                    for (var j = 0; j < series[i].categorias.length; j++) {
                        var categorias = new Array(series[i].categorias[j]);
                        options.xAxis.categories.push(categorias);
                    }
                }
                $('#' + idDiv).highcharts(options);
            }

            function DibujarChartConsolidadoLineasPorAnioMaterial(idDiv, series) {

                $('#' + idDiv).highcharts({
                    chart: {
                        plotBackgroundColor: null,
                        plotBorderWidth: 0,
                        plotShadow: false
                    },
                    title: {
                        text: 'CONSOLIDADO MATERIAL ' + $("#ddlAnios").val(),
                        align: 'center',
                        //verticalAlign: 'middle',
                        //y: -60
                    },
                    //colors: ['#00FF00', '#0066FF', '#00CCFF'],
                    tooltip: {
                        pointFormat: '{series.name}: <b> ${point.y}</b>'
                    },
                    plotOptions: {
                        pie: {
                            allowPointSelect: true,
                            showInLegend: true,
                            dataLabels: {

                                enabled: true,
                                format: '{point.name}: ${point.y:.2f}',

                                //distance: -30,
                                style: {
                                    //fontWeight: 'bold',
                                    //color: 'white',
                                    //textShadow: '0px 1px 1px black'
                                }
                            },
                            //startAngle: -90,
                            //endAngle: 90,
                            //center: ['50%', '75%']
                        }
                    },
                    credits: {
                        enabled: false
                    },
                    series: [{
                        type: 'pie',
                        name: 'Total',
                        //innerSize: '50%',
                        data: [
                            ['ESTIMADO', series[0].data[0]],
                            ['REAL', series[1].data[0]],
                            //{
                                //name: 'Proprietary or Undetectable',
                                //y: 0.0,
                                //dataLabels: {
                                //    enabled: false
                                //}
                            //}
                        ]
                    }]
                });

            }

            ////////////////////////////////////////////////////////////////////////////////////////////

            $("#ddlAnios").on('change', function () {
                var anioSeleccionado = $("#ddlAnios").val();
                //alert('$("#ddlAnios"): ' + $("#ddlAnios").val());
                CargarMesesPorAnio(anioSeleccionado);
                CargarEstimadosLineaPorAnioMaterial(anioSeleccionado);
                CargarEstimadosLineaPorAnioManoObra(anioSeleccionado);
                CargarEstimadosLineaPorAnioPti(anioSeleccionado);
            });

            $("#ddlMeses").on('change', function () {
                var anioSeleccionado = $("#ddlAnios").val();
                var mesSeleccionado = $("#ddlMeses").val();
                //alert('$("#ddlAnios"): ' + $("#ddlAnios").val() + '     $("#ddlMeses"): ' + $("#ddlMeses").val());
                CargarEstimadosLineaPorAnioMesMaterial(anioSeleccionado, mesSeleccionado);
                CargarEstimadosLineaPorAnioMesManoObra(anioSeleccionado, mesSeleccionado);
                CargarEstimadosLineaPorAnioMesPti(anioSeleccionado, mesSeleccionado);
            });



            ////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////SERVICIOS DE MANO DE OBRA///////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////

            function CargarEstimadosLineaPorAnioManoObra(anio) {
                $.ajax({
                    type: "POST",
                    url: "../ServiciosAsmx/DashboardService.asmx/ObtenerEstimadoLineaPorAnioManoObra",
                    data: "{anio: " + anio + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response, status) {
                        var lista = response.d;
                        DibujarChartLineasPorAnioManoObra('estimadoLineasPorAnioManoObra', lista);
                        CargarConsolidadLineasPorAnioManoObra(anio);
                    },
                    error: function (response) {
                        alert(response.status + " " + response.statusText);
                    }
                });
            }

            function CargarEstimadosLineaPorAnioMesManoObra(anio, mes) {
                $.ajax({
                    type: "POST",
                    url: "../ServiciosAsmx/DashboardService.asmx/ObtenerEstimadoLineaPorAnioMesesManoObra",
                    data: "{anio:" + anio + ",mes: '" + mes + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response, status) {
                        var lista = response.d;
                        DibujarChartLineasPorMesesManoObra('estimadoConsolidadLineasPorMesesManoObra', lista);
                    },
                    error: function (response) {
                        alert(response.status + " " + response.statusText);
                    }
                });
            }

            function CargarConsolidadLineasPorAnioManoObra(anio) {
                $.ajax({
                    type: "POST",
                    url: "../ServiciosAsmx/DashboardService.asmx/ObtenerConsolidadoLineasPorAnioManoObra",
                    data: "{anio:" + anio + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response, status) {
                        var lista = response.d;
                        DibujarChartConsolidadoLineasPorAnioManoObra('CargarConsolidadLineasPorAnioManoObra', lista);
                    },
                    error: function (response) {
                        alert(response.status + " " + response.statusText);
                    }
                });
            }

            function DibujarChartLineasPorAnioManoObra(idDiv, series) {
                var options = {
                    chart: {
                        renderTo: 'stats',
                        type: 'spline',
                    },
                    title: {
                        text: 'MANO DE OBRA AÑO ' + $("#ddlAnios").val() // título
                    },
                    tooltip: {
                        pointFormat: '{series.name}: <b>${point.y}</b>'
                    },

                    yAxis: {
                        title: {
                            text: 'Valores ($)'
                        },

                        plotLines: [{
                            allowPointSelect: true,
                            cursor: 'pointer',
                            value: 0,
                            width: 1
                        }]
                    },
                    credits: {
                        enabled: false
                    },
                    xAxis: {
                        categories: [],
                        labels: {
                            rotation: -45,
                            style: {
                                fontSize: '11px',
                                fontFamily: 'Verdana, sans-serif'
                            }
                        }
                    },
                    series: []
                }
                for (var i = 0; i < series.length; i++) {

                    var serie = new Array(series[i].name, series[i].data)
                    //alert('Serie => ' + JSON.stringify(serie));
                    options.series.push(series[i]);

                    for (var j = 0; j < series[i].categorias.length; j++) {
                        var categorias = new Array(series[i].categorias[j]);
                        options.xAxis.categories.push(categorias);
                    }
                }
                $('#' + idDiv).highcharts(options);
            }

            function DibujarChartLineasPorMesesManoObra(idDiv, series) {
                var options = {
                    chart: {
                        renderTo: 'stats',
                        type: 'column',
                    },
                    title: {
                        text: 'MANO DE OBRA ' + $("#ddlMeses").val() + '/' + $("#ddlAnios").val()// título
                    },
                    tooltip: {
                        pointFormat: '{series.name}: <b>${point.y}</b>'
                    },
                    yAxis: {
                        title: {
                            text: 'Valores ($)'
                        },
                        plotLines: [{
                            allowPointSelect: true,
                            cursor: 'pointer',
                            value: 0,
                            width: 0.5,
                        }]
                    },
                    xAxis: {
                        categories: [],
                        labels: {
                            rotation: -45,
                            style: {
                                fontSize: '11px',
                                fontFamily: 'Verdana, sans-serif'
                            }
                        }
                    },
                    credits: {
                        enabled: false
                    },
                    series: []
                }

                for (var i = 0; i < series.length; i++) {

                    var serie = new Array(series[i].name, series[i].data)
                    options.series.push(series[i]);

                    for (var j = 0; j < series[i].categorias.length; j++) {
                        var categorias = new Array(series[i].categorias[j]);
                        options.xAxis.categories.push(categorias);
                    }
                }
                $('#' + idDiv).highcharts(options);
            }

            function DibujarChartConsolidadoLineasPorAnioManoObra(idDiv, series) {

                $('#' + idDiv).highcharts({
                    chart: {
                        plotBackgroundColor: null,
                        plotBorderWidth: 0,
                        plotShadow: false
                    },
                    title: {
                        text: 'CONSOLIDADO MANO OBRA ' + $("#ddlAnios").val(),
                        align: 'center',
                        //verticalAlign: 'middle',
                        //y: -60
                    },
                    //colors: ['#00FF00', '#0066FF', '#00CCFF'],
                    tooltip: {
                        pointFormat: '{series.name}: <b> ${point.y}</b>'
                    },
                    plotOptions: {
                        pie: {
                            allowPointSelect: true,
                            showInLegend: true,
                            dataLabels: {

                                enabled: true,
                                format: '{point.name}: ${point.y:.2f}',

                                //distance: -30,
                                style: {
                                    //fontWeight: 'bold',
                                    //color: 'white',
                                    //textShadow: '0px 1px 1px black'
                                }
                            },
                            //startAngle: -90,
                            //endAngle: 90,
                            //center: ['50%', '75%']
                        }
                    },
                    credits: {
                        enabled: false
                    },
                    series: [{
                        type: 'pie',
                        name: 'Total',
                        //innerSize: '50%',
                        data: [
                            ['ESTIMADO', series[0].data[0]],
                            ['REAL', series[1].data[0]],
                            //{
                                //name: 'Proprietary or Undetectable',
                                //y: 0.0,
                                //dataLabels: {
                                //    enabled: false
                                //}
                            //}
                        ]
                    }]
                });

            }

            ////////////////////////////////////////////////////////////////////////////////////////////



            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////SERVICIOS DE PTI///////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////

            function CargarEstimadosLineaPorAnioPti(anio) {
                $.ajax({
                    type: "POST",
                    url: "../ServiciosAsmx/DashboardService.asmx/ObtenerEstimadoLineaPorAnioPti",
                    data: "{anio: " + anio + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response, status) {
                        var lista = response.d;
                        DibujarChartLineasPorAnioPti('estimadoLineasPorAnioPti', lista);
                        CargarConsolidadLineasPorAnioPti(anio);
                    },
                    error: function (response) {
                        alert(response.status + " " + response.statusText);
                    }
                });
            }

            function CargarEstimadosLineaPorAnioMesPti(anio, mes) {
                $.ajax({
                    type: "POST",
                    url: "../ServiciosAsmx/DashboardService.asmx/ObtenerEstimadoLineaPorAnioMesesPti",
                    data: "{anio:" + anio + ",mes: '" + mes + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response, status) {
                        var lista = response.d;
                        DibujarChartLineasPorMesesPti('estimadoConsolidadLineasPorMesesPti', lista);
                    },
                    error: function (response) {
                        alert(response.status + " " + response.statusText);
                    }
                });
            }

            function CargarConsolidadLineasPorAnioPti(anio) {
                $.ajax({
                    type: "POST",
                    url: "../ServiciosAsmx/DashboardService.asmx/ObtenerConsolidadoLineasPorAnioPti",
                    data: "{anio:" + anio + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response, status) {
                        var lista = response.d;
                        DibujarChartConsolidadoLineasPorAnioPti('CargarConsolidadLineasPorAnioPti', lista);
                    },
                    error: function (response) {
                        alert(response.status + " " + response.statusText);
                    }
                });
            }

            function DibujarChartLineasPorAnioPti(idDiv, series) {
                var options = {
                    chart: {
                        renderTo: 'stats',
                        type: 'spline',
                    },
                    title: {
                        text: 'PTI AÑO ' + $("#ddlAnios").val(),
                        fontSize: '10px'
                    },
                    tooltip: {
                        pointFormat: '{series.name}: <b>${point.y}</b>'
                    },

                    yAxis: {
                        title: {
                            text: 'Valores ($)'
                        },

                        plotLines: [{
                            allowPointSelect: true,
                            cursor: 'pointer',
                            value: 0,
                            width: 1
                        }]
                    },
                    credits: {
                        enabled: false
                    },
                    xAxis: {
                        categories: [],
                        labels: {
                            rotation: -45,
                            style: {
                                fontSize: '11px',
                                fontFamily: 'Verdana, sans-serif'
                            }
                        }
                    },
                    series: []
                }
                for (var i = 0; i < series.length; i++) {

                    var serie = new Array(series[i].name, series[i].data)
                    //alert('Serie => ' + JSON.stringify(serie));
                    options.series.push(series[i]);

                    for (var j = 0; j < series[i].categorias.length; j++) {
                        var categorias = new Array(series[i].categorias[j]);
                        options.xAxis.categories.push(categorias);
                    }
                }
                $('#' + idDiv).highcharts(options);
            }

            function DibujarChartLineasPorMesesPti(idDiv, series) {
                var options = {
                    chart: {
                        renderTo: 'stats',
                        type: 'column',
                    },
                    title: {
                        text: 'PTI ' + $("#ddlMeses").val() + '/' + $("#ddlAnios").val()// título
                    },
                    tooltip: {
                        pointFormat: '{series.name}: <b>${point.y}</b>'
                    },
                    yAxis: {
                        title: {
                            text: 'Valores ($)'
                        },
                        plotLines: [{
                            allowPointSelect: true,
                            cursor: 'pointer',
                            value: 0,
                            width: 0.5,
                        }]
                    },
                    xAxis: {
                        categories: [],
                        labels: {
                            rotation: -45,
                            style: {
                                fontSize: '11px',
                                fontFamily: 'Verdana, sans-serif'
                            }
                        }
                    },
                    credits: {
                        enabled: false
                    },
                    series: []
                }

                for (var i = 0; i < series.length; i++) {

                    var serie = new Array(series[i].name, series[i].data)
                    options.series.push(series[i]);

                    for (var j = 0; j < series[i].categorias.length; j++) {
                        var categorias = new Array(series[i].categorias[j]);
                        options.xAxis.categories.push(categorias);
                    }
                }
                $('#' + idDiv).highcharts(options);
            }

            function DibujarChartConsolidadoLineasPorAnioPti(idDiv, series) {

                $('#' + idDiv).highcharts({
                    chart: {
                        plotBackgroundColor: null,
                        plotBorderWidth: 0,
                        plotShadow: false
                    },
                    title: {
                        text: 'CONSOLIDADO PTI ' + $("#ddlAnios").val(),
                        align: 'center',
                        //verticalAlign: 'middle',
                        //y: -60
                    },
                    //colors: ['#00FF00', '#0066FF', '#00CCFF'],
                    tooltip: {
                        pointFormat: '{series.name}: <b> ${point.y}</b>'
                    },
                    plotOptions: {
                        pie: {
                            allowPointSelect: true,
                            showInLegend: true,
                            dataLabels: {

                                enabled: true,
                                format: '{point.name}: ${point.y:.2f}',

                                //distance: -30,
                                style: {
                                    //fontWeight: 'bold',
                                    //color: 'white',
                                    //textShadow: '0px 1px 1px black'
                                }
                            },
                            //startAngle: -90,
                            //endAngle: 90,
                            //center: ['50%', '75%']
                        }
                    },
                    credits: {
                        enabled: false
                    },
                    series: [{
                        type: 'pie',
                        name: 'Total',
                        //innerSize: '50%',
                        data: [
                            ['ESTIMADO', series[0].data[0]],
                            ['REAL', series[1].data[0]],
                            //{
                                //name: 'Proprietary or Undetectable',
                                //y: 0.0,
                                //dataLabels: {
                                //    enabled: false
                                //}
                            //}
                        ]
                    }]
                });

            }

            ////////////////////////////////////////////////////////////////////////////////////////////

        });
    </script>

</head>
<body>


    <form autocomplete="on" id="form1" runat="server" style="width: 100%;">

        <asp:ScriptManager runat="server" />

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel-group">
                    <div class="panel panel-primary small">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" href="#filtros">Filtros Dashboards</a>
                            </h4>
                        </div>
                        <div id="filtros" class="panel-collapse collapse">
                            <div class="panel-body ">


                                <div class="col-sm-offset-3 col-sm-1">
                                    <asp:Label runat="server" CssClass="control-label" Text="Años Disponibles:" />
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList runat="server" ID="ddlAnios" CssClass="form-control small" />
                                </div>
                                <div class="col-sm-1">
                                    <asp:Label runat="server" CssClass="control-label" Text="Meses Disponibles:" />
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList runat="server" ID="ddlMeses" CssClass="form-control small" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <ul class="nav nav-tabs small">
                    <li class="active"><a data-toggle="tab" href="#dashBoardMaterial">Material</a></li>
                    <li><a data-toggle="tab" href="#dashBoardManoObra">Mano de Obra</a></li>
                    <li><a data-toggle="tab" href="#dashBoardPti">PTI</a></li>

                </ul>

                <div class="tab-content" style="text-align: center;">
                    <div id="dashBoardMaterial" class="tab-pane fade in active">

                        <div class="table-responsive">
                            <table class="table" style="width: 98%;">
                                <tr>
                                    <td style="width: 49%;">
                                        <div id="estimadoLineasPorAnioMaterial" />
                                    </td>
                                    <td style="width: 49%;">
                                        <div id="estimadoConsolidadLineasPorMesesMaterial" />
                                    </td>
                                </tr>
                            </table>

                            <table class="table" style="width: 98%; text-align: center;">
                                <tr style="width: 100%;">
                                    <td align="center">
                                        <div id="CargarConsolidadLineasPorAnioMaterial" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <div id="dashBoardManoObra" class="tab-pane fade">

                        <div class="table-responsive">
                            <table class="table" style="width: 98%;">
                                <tr>
                                    <td style="width: 49%;">
                                        <div id="estimadoLineasPorAnioManoObra" />
                                    </td>
                                    <td style="width: 49%;">
                                        <div id="estimadoConsolidadLineasPorMesesManoObra" />
                                    </td>
                                </tr>
                            </table>

                            <table class="table" style="width: 98%; text-align: center;">
                                <tr style="width: 100%;">
                                    <td align="center">
                                        <div id="CargarConsolidadLineasPorAnioManoObra" />
                                    </td>
                                </tr>
                            </table>
                        </div>

                    </div>


                    <div id="dashBoardPti" class="tab-pane fade">

                        <div class="table-responsive">
                            <table class="table" style="width: 98%;">
                                <tr>
                                    <td style="width: 49%;">
                                        <div id="estimadoLineasPorAnioPti" />
                                    </td>
                                    <td style="width: 49%;">
                                        <div id="estimadoConsolidadLineasPorMesesPti" />
                                    </td>
                                </tr>
                            </table>

                            <table class="table" style="width: 98%; text-align: center;">
                                <tr style="width: 100%;">
                                    <td align="center">
                                        <div id="CargarConsolidadLineasPorAnioPti" />
                                    </td>
                                </tr>
                            </table>
                        </div>

                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
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

