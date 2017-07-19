




//obtenerTotalesEorEstructuraTodosEstimado
function obtenerTotalesEorEstructuraTodosEstimadoPorLinea(linea) {
    $.ajax({
        title: "Estructura",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorEstructuraTodosEstimadoPorLinea",
        data: "{'linea':'" + linea + "'}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                data.push(serie);
            }
            DrawChartEstructura2(data, "Total estimado por Estructura", "Años", linea);
        },
        error: function (error) {
            console.log(error);
        }
    }
    );
}

//obtenerTotalesEorMaquinariaTodosEstimadoPorLinea
function obtenerTotalesEorMaquinariaTodosEstimadoPorLinea(linea) {
    $.ajax({
        title: "Maquinaria",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorMaquinariaTodosEstimadoPorLinea",
        data: "{'linea':'" + linea + "'}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                data.push(serie);
            }
            DrawChartMaquinaria2(data, "Total estimados por Maquinaria", "Años", linea);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

//obtenerTotalesEorTransitoTodosEstimadoPorLinea
function obtenerTotalesEorTransitoTodosEstimadoPorLinea(linea) {
    $.ajax({
        title: "Maquinaria",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorTransitoTodosEstimadoPorLinea",
        data: "{'linea':'" + linea + "'}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                data.push(serie);
            }
            DrawChartTransito2(data, "Total estimado por Tránsito", "Años", linea);
        },
        error: function (error) {
            console.log(error);
        }
    });
}


//obtenerTotalesEorEstructuraTodosReal
function obtenerTotalesEorEstructuraTodosRealPorLinea(linea) {
    $.ajax({
        title: "Estructura",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorEstructuraTodosRealPorLinea",
        data: "{'linea':'" + linea + "'}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                data.push(serie);
            }
            DrawChartEstructuraReal2(data, "Total real por Estructura", "Años", linea);
        },
        error: function (error) {
            console.log(error);
        }
    });
}


//obtenerTotalesEorMaquinariaTodosReal
function obtenerTotalesEorMaquinariaTodosRealPorLinea(linea) {
    $.ajax({
        title: "Maquinaria",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorMaquinariaTodosRealPorLinea",
        data: "{'linea':'" + linea + "'}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                data.push(serie);
            }
            DrawChartMaquinariaReal2(data, "Total real  por Maquinaria", "Años", linea);
        },
        error: function (error) {
            console.log(error);
        }
    });
}


//obtenerTotalesEorTransitoTodosReal
function obtenerTotalesEorTransitoTodosRealPorLinea(linea) {
    $.ajax({
        title: "Tránsito",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorTransitoTodosRealPorLinea",
        data: "{'linea':'" + linea + "'}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                data.push(serie);
            }
            DrawChartTransitoReal2(data, "Total real por Transito", "Años", linea);
        },
        error: function (error) {
            console.log(error);
        }
    });
}














function DrawChartEstructura2(series, titulo, nombreEjeX, linea) {
    $('#containerEorEstructura2').highcharts({

        //chart: {
        //    plotBorderWidth: 1,
        //    plotShadow: true,
        //    margin: 75,
        //    options3d: {
        //        enabled: true,
        //        alpha: 2,
        //        beta: 4,
        //        depth: 0,
        //        viewDistance: 25
        //    }
        //},
        //plotLines: [{
        //    value: 0,
        //    width: 1,
        //    color: '#808080'
        //}],
        title: {
            text: titulo == null || titulo == '' ? 'Estimados por Estructura' : titulo
        },

        xAxis: {
            categories: true,
            labels: {
                //rotation: -45,
                style: {
                    fontSize: '11px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        tooltip: {
            pointFormat: '{series.name}: <b>${point.y}</b>'
        },
        plotOptions: {
            plotLines: {
                cursor: 'pointer',
                color: '#6094DB',
                enabled: true,
                point: {
                    events: {
                        click: function (event) {
                            var drilldown = this.drilldown;
                            var split_drill = drilldown.split('?');
                            if (split_drill[1] == '1') { // drill down
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorEstructuraPorAnioEstimadoPorLinea",
                                    data: "{'Year':'" + split_drill[0] + "' , 'linea':'" + linea + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];

                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }

                                        DrawChartEstructura2(data, "Total estimado por Estructura - Año " + split_drill[0], "Meses", linea);
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }

                            if (split_drill[1] == '2') { // drill down
                                var e = document.getElementById("ddllinea");
                                linea = e.options[e.selectedIndex].value;
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorEstructuraTodosEstimadoPorLinea",
                                    data: "{'linea':'" + linea + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                                        DrawChartEstructura2(data, "Total estimado por Estructura - Seleccion " + split_drill[0], "Días", linea);
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }
                        }
                    }
                },

                dataLabels: {
                    rotation: -45,
                    enabled: true,
                    format: '<b>${point.y:,.2f}</b>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black',
                        reserverSpace: true
                    }
                }
            }
        },
        series: [{
            type: 'column',
            align: 'right',
            name: nombreEjeX == null || nombreEjeX == '' ? 'Años' : nombreEjeX,
            data: series,
        }],
        exporting: {
            enabled: true
        }
    }
    );
}


function DrawChartMaquinaria2(series, titulo, nombreEjeX, linea) {
    $('#containerEorMaquinaria2').highcharts({
        chart: {
            plotBorderWidth: 1,
            plotShadow: true,
            margin: 75,
            options3d: {
                enabled: true,
                alpha: 2,
                beta: 4,
                depth: 0,
                viewDistance: 100
            }

        },
        title: {
            text: titulo == null || titulo == '' ? 'Estimados por Maquinaria' : titulo,
        },
        xAxis: {
            categories: true,
            labels: {
                rotation: -45,
                style: {
                    fontSize: '11px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        tooltip: {
            pointFormat: '{series.name}: <b>${point.y}</b>',
            borderColor: '#74C365',
            borderRadius: 10,
            borderWidth: 1
        },
        plotOptions: {
            column: {
                color: '#6094DB',
                cursor: 'pointer',
                enabled: true,
                point: {
                    events: {
                        click: function (event) {
                            var drilldown = this.drilldown;
                            var split_drill = drilldown.split('?');
                            if (split_drill[1] == '1') { // drill down
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorMaquinariaPorAnioEstimadoPorLinea",
                                    data: "{'Year':'" + split_drill[0] + "' , 'linea':'" + linea + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }

                                        DrawChartMaquinaria2(data, "Total estimado por Maquinaria - Año " + split_drill[0], "Meses", linea);
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }
                            if (split_drill[1] == '2') { // drill down
                                var e = document.getElementById("ddllinea");
                                linea = e.options[e.selectedIndex].value;
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorMaquinariaTodosEstimadoPorLinea",
                                    data: "{'linea':'" + linea + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }

                                        DrawChartMaquinaria2(data, "Total estimado por Maquinaria " + split_drill[0], "Días", linea);
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }
                        }
                    }
                },

                dataLabels: {
                    rotation: -45,
                    enabled: true,
                    format: '<b>${point.y:,.2f}</b>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black',
                        reserverSpace: true
                    }
                }
            }
        },
        series: [{
            type: 'column',
            align: 'right',
            name: nombreEjeX == null || nombreEjeX == '' ? 'Años' : nombreEjeX,
            data: series,
        }],
        exporting: {
            enabled: true
        }

    });
}


function DrawChartTransito2(series, titulo, nombreEjeX, linea) {
    $('#containerEorTransito2').highcharts({
        chart: {
            plotBorderWidth: 1,
            plotShadow: true,
            margin: 75,
            options3d: {
                enabled: true,
                alpha: 2,
                beta: 4,
                depth: 0,
                viewDistance: 100
            }

        },
        title: {
            text: titulo == null || titulo == '' ? 'Estimados por Tránsito' : titulo,
        },
        xAxis: {
            categories: true,
            labels: {
                rotation: -45,
                style: {
                    fontSize: '11px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        tooltip: {
            pointFormat: '{series.name}: <b>${point.y}</b>',
            borderColor: '#74C365',
            borderRadius: 10,
            borderWidth: 1
        },
        plotOptions: {
            column: {
                color: '#6094DB',
                cursor: 'pointer',
                enabled: true,
                point: {
                    events: {
                        click: function (event) {
                            var drilldown = this.drilldown;
                            var split_drill = drilldown.split('?');
                            if (split_drill[1] == '1') { // drill down
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorTransitoPorAnioEstimado",
                                    data: "{'Year':'" + split_drill[0] + "' , 'linea':'" + linea + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }


                                        DrawChartTransito2(data, "Total estimados por Tránsito - Año " + split_drill[0], "Meses", linea);
                                    },
                                    error: function (Result) {
                                        alert("Error");
                                    }
                                });
                            }
                            if (split_drill[1] == '2') { // drill down
                                var e = document.getElementById("ddllinea");
                                linea = e.options[e.selectedIndex].value;
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorTransitoTodosEstimadoPorLinea",
                                    data: "{'linea':'" + linea + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                                        DrawChartTransito2(data, "Total estimados por Tránsito " + split_drill[0], "Días", linea);
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }
                        }
                    }
                },

                dataLabels: {
                    rotation: -45,
                    enabled: true,
                    format: '<b>${point.y:,.2f}</b>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black',
                        reserverSpace: true
                    }
                }
            }
        },
        series: [{
            type: 'column',
            align: 'right',
            name: nombreEjeX == null || nombreEjeX == '' ? 'Años' : nombreEjeX,
            data: series,
        }],
        exporting: {
            enabled: true
        }

    });
}


function DrawChartEstructuraReal2(series, titulo, nombreEjeX, linea) {
    $('#containerEorEstructuraReal2').highcharts({

        //chart: {
        //    plotBorderWidth: 1,
        //    plotShadow: true,
        //    margin: 75,
        //    options3d: {
        //        enabled: true,
        //        alpha: 2,
        //        beta: 4,
        //        depth: 0,
        //        viewDistance: 25
        //    }
        //},
        plotLines: [{
            value: 0,
            width: 1,
            color: '#808080'
        }],
        title: {
            text: titulo == null || titulo == '' ? 'Total real por Estructura' : titulo
        },

        xAxis: {
            categories: true,
            labels: {
                rotation: -45,
                style: {
                    fontSize: '11px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        tooltip: {
            pointFormat: '{series.name}: <b>${point.y}</b>'
        },
        plotOptions: {
            column: {
                cursor: 'pointer',
                color: '#59955C',
                enabled: true,
                point: {
                    events: {
                        click: function (event) {
                            var drilldown = this.drilldown;
                            var split_drill = drilldown.split('?');
                            if (split_drill[1] == '1') { // drill down
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorEstructuraRealPorAnioPorLinea",
                                    data: "{'Year':'" + split_drill[0] + "' , 'linea':'" + linea + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];

                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }




                                        DrawChartEstructuraReal2(data, "Total real por Estructura - Año " + split_drill[0], "Meses", linea);
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }

                            if (split_drill[1] == '2') { // drill down
                                var e = document.getElementById("ddllinea");
                                linea = e.options[e.selectedIndex].value;
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorEstructuraTodosEstimadoPorLinea",
                                    data: "{'linea':'" + linea + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                                        DrawChartEstructuraReal2(data, "Total real por Estructura " + split_drill[0], "Días", linea);
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }
                        }
                    }
                },

                dataLabels: {
                    rotation: -45,
                    enabled: true,
                    format: '<b>${point.y:,.2f}</b>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black',
                        reserverSpace: true
                    }
                }
            }
        },
        series: [{
            type: 'column',
            align: 'right',
            name: nombreEjeX == null || nombreEjeX == '' ? 'Años' : nombreEjeX,
            data: series,
        }],
        exporting: {
            enabled: true
        }
    }
    );
}


function DrawChartMaquinariaReal2(series, titulo, nombreEjeX, linea) {

    $('#containerEorMaquinariaReal2').highcharts({
        chart: {
            plotBorderWidth: 1,
            plotShadow: true,
            margin: 75,
            options3d: {
                enabled: true,
                alpha: 2,
                beta: 4,
                depth: 0,
                viewDistance: 100
            }

        },
        title: {
            text: titulo == null || titulo == '' ? 'Total real por Maquinaria' : titulo,
        },
        xAxis: {
            categories: true,
            labels: {
                rotation: -45,
                style: {
                    fontSize: '11px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        tooltip: {
            pointFormat: '{series.name}: <b>${point.y}</b>',
            borderColor: '#74C365',
            borderRadius: 10,
            borderWidth: 1
        },
        plotOptions: {
            column: {
                color: '#59955C',
                cursor: 'pointer',
                enabled: true,
                point: {
                    events: {
                        click: function (event) {
                            var drilldown = this.drilldown;
                            var split_drill = drilldown.split('?');
                            if (split_drill[1] == '1') { // drill down
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorMaquinariaRealPorAnioPorLinea",
                                    data: "{'Year':'" + split_drill[0] + "' , 'linea':'" + linea + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }

                                        DrawChartMaquinariaReal2(data, "Total real por Maquinaria  - Año " + split_drill[0], "Meses", linea);
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }
                            if (split_drill[1] == '2') { // drill down
                                var e = document.getElementById("ddllinea");
                                linea = e.options[e.selectedIndex].value;
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorMaquinariaTodosEstimadoPorLinea",
                                    data: "{'linea':'" + linea + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                                        DrawChartMaquinariaReal2(data, "Total real por Maquinaria " + split_drill[0], "Días", linea);
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }
                        }
                    }
                },

                dataLabels: {
                    rotation: -45,
                    enabled: true,
                    format: '<b>${point.y:,.2f}</b>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black',
                        reserverSpace: true
                    }
                }
            }
        },
        series: [{
            type: 'column',
            align: 'right',
            name: nombreEjeX == null || nombreEjeX == '' ? 'Años' : nombreEjeX,
            data: series,
        }],
        exporting: {
            enabled: true
        }

    });
}


function DrawChartTransitoReal2(series, titulo, nombreEjeX, linea) {
    $('#containerEorTransitoReal2').highcharts({
        chart: {
            plotBorderWidth: 1,
            plotShadow: true,
            margin: 75,
            options3d: {
                enabled: true,
                alpha: 2,
                beta: 4,
                depth: 0,
                viewDistance: 100
            }

        },
        title: {
            text: titulo == null || titulo == '' ? 'Estimados Real por Transito' : titulo,
        },
        xAxis: {
            categories: true,
            labels: {
                rotation: -45,
                style: {
                    fontSize: '11px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        tooltip: {
            pointFormat: '{series.name}: <b>${point.y}</b>',
            borderColor: '#74C365',
            borderRadius: 10,
            borderWidth: 1
        },
        plotOptions: {
            column: {
                color: '#59955C',
                cursor: 'pointer',
                enabled: true,
                point: {
                    events: {
                        click: function (event) {
                            var drilldown = this.drilldown;
                            var split_drill = drilldown.split('?');
                            if (split_drill[1] == '1') { // drill down
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorTransitoRealPorAnioPorLinea",
                                    data: "{'Year':'" + split_drill[0] + "' , 'linea':'" + linea + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }

                                        DrawChartTransitoReal2(data, "Total real por Tránsito  - Año " + split_drill[0], "Meses", linea);
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }
                            if (split_drill[1] == '2') { // drill down
                                var e = document.getElementById("ddllinea");
                                linea = e.options[e.selectedIndex].value;
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorTransitoTodosRealPorLinea",
                                    data: "{'linea':'" + linea + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                                        DrawChartTransitoReal2(data, "Total real por Tránsito " + split_drill[0], "Días", linea);
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }
                        }
                    }
                },

                dataLabels: {
                    rotation: -45,
                    enabled: true,
                    format: '<b>${point.y:,.2f}</b>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black',
                        reserverSpace: true
                    }
                }
            }
        },
        series: [{
            type: 'column',
            align: 'right',
            name: nombreEjeX == null || nombreEjeX == '' ? 'Años' : nombreEjeX,
            data: series,
        }],
        exporting: {
            enabled: true
        }

    });
}


