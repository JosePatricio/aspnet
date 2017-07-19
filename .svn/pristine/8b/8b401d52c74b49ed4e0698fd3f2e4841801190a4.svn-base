





$(document).ready(function () {


    //obtenerLineasPorEstado
    $.ajax({
        title: "Estructura",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../ServiciosAsmx/HighchartService.asmx/obtenerLineasPorEstado",
        data: JSON.stringify({ intSystemId: 1, intLoggedinUserId: 1 }),
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
                
                
            for (var i in Result) {
                var serie = { Id: Result[i].Id, Name: Result[i].Name };
                
                $("#ddllinea").append($("<option></option>").val(Result[i].Id).
                 text(Result[i].Name));
            }

            Consultar();
           
           

        },
        error: function (error) {
                    console.log(error);
                }
    }
    );   });


$(document).ready(function () {

    //obtenerTotalesEorEstructuraTodosEstimado
    $.ajax({
        title: "Estructura",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorEstructuraTodosEstimado",
        data: JSON.stringify({ intSystemId: 1, intLoggedinUserId: 1 }),
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                data.push(serie);
            }
            DrawChartEstructura(data, "Total estimado por Estructura", "Años");
        },
        error: function (error) {
            console.log(error);
        }
    }
    );
    //obtenerTotalesEorMaquinariaTodosEstimado
    $.ajax({
        title: "Maquinaria",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorMaquinariaTodosEstimado",
        data: JSON.stringify({ intSystemId: 1, intLoggedinUserId: 1 }),
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                data.push(serie);
            }
            DrawChartMaquinaria(data, "Total estimados por Maquinaria", "Años");
        },
        error: function (error) {
            console.log(error);
        }
    });

    //obtenerTotalesEorTransitoTodosEstimado
    $.ajax({
        title: "Maquinaria",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorTransitoTodosEstimado",
        data: JSON.stringify({ intSystemId: 1, intLoggedinUserId: 1 }),
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                data.push(serie);
            }
            DrawChartTransito(data, "Total estimado por Tránsito", "Años");
        },
        error: function (error) {
            console.log(error);
        }
    });


    //obtenerTotalesEorEstructuraTodosReal
    $.ajax({
        title: "Estructura",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorEstructuraTodosReal",
        data: JSON.stringify({ intSystemId: 1, intLoggedinUserId: 1 }),
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                data.push(serie);
            }
            DrawChartEstructuraReal(data, "Total real por Estructura", "Años");
        },
        error: function (error) {
            console.log(error);
        }
    });


    //obtenerTotalesEorMaquinariaTodosReal
    $.ajax({
        title: "Maquinaria",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorMaquinariaTodosReal",
        data: JSON.stringify({ intSystemId: 1, intLoggedinUserId: 1 }),
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                data.push(serie);
            }
            DrawChartMaquinariaReal(data, "Total real  por Maquinaria", "Años");
        },
        error: function (error) {
            console.log(error);
        }
    });


    //obtenerTotalesEorTransitoTodosReal
    $.ajax({
        title: "Tránsito",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorTransitoTodosReal",
        data: JSON.stringify({ intSystemId: 1, intLoggedinUserId: 1 }),
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                data.push(serie);
            }
            DrawChartTransitoReal(data, "Total real por Transito", "Años");
        },
        error: function (error) {
            console.log(error);
        }
    });





});



  

function DrawChartEstructura(series, titulo, nombreEjeX) {


    $('#containerEorEstructura').highcharts({

        chart: {
            //plotBorderWidth: 1,
            plotShadow: true,
            margin: 75,
            options3d: {
                enabled: true,
                //alpha: 2,
                //beta: 4,
                //depth: 0,
                //viewDistance: 25
                alpha: 5,
                beta: 2,
                depth: 0
            }
        },
        title: {
            text: titulo == null || titulo == '' ? 'Estimados por Estructura' : titulo
        },

        xAxis: {
            categories: true,
            labels: {
                rotation: 0,
                style: {
                   // fontSize: '10px',
                    fontFamily: 'Verdana, sans-serif'
                },
                y: 6

            }
        },
        
        tooltip: {
            pointFormat: '{series.name}: <b>${point.y}</b>'
        },
        plotOptions: {
            series: {
                animation: {
                    duration: 2000,
//                    easing: 'easeOutBounce'
                }
            },
            bar: {
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
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorEstructuraPorAnioEstimado",
                                    data: "{'Year':'" + split_drill[0] + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];

                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }

                                        DrawChartEstructura(data, "Total estimado por Estructura - Año " + split_drill[0], "Meses");
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }

                            if (split_drill[1] == '2') { // drill down
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorEstructuraTodosEstimado",
                                    data: JSON.stringify({ intSystemId: 1, intLoggedinUserId: 1 }),
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                                        DrawChartEstructura(data, "Total estimado por Estructura - Seleccion " + split_drill[0], "Días");
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
                    enabled: true,
                    rotation: 1,
                    align: 'rigth',
                   
                    //borderRadius: 5,
                   // backgroundColor: 'rgba(252, 255, 197, 0.7)',
                    //borderWidth: 1,
                    //borderColor: '#6094DB',
                   // y:0,

                    
                    format: '<b>${point.y:,.2f}</b>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black',
                        reserverSpace: true                        
                    },
                    

                }
            }
        },
        series: [{
            type: 'bar',
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


function DrawChartMaquinaria(series, titulo, nombreEjeX) {
    $('#containerEorMaquinaria').highcharts({
        chart: {
           // plotBorderWidth: 1,
            plotShadow: true,
            margin: 75,
            //options3d: {
            //    enabled: true,
            //    alpha: 2,
            //    beta: 4,
            //    depth: 0,
            //    viewDistance: 100
            //}
            options3d: {
                enabled: true,
                //alpha: 2,
                //beta: 4,
                //depth: 0,
                //viewDistance: 25
                alpha: 5,
                beta: 5,
                depth: 0
            }

        },
        title: {
            text: titulo == null || titulo == '' ? 'Estimados por Maquinaria' : titulo,
        },
        xAxis: {
            categories: true,
            labels: {
                //rotation: -45,
                style: {
                    //fontSize: '11px',
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
            animation: {
                duration: 2000,
                easing: 'easeInOutQuad'
                //                    easing: 'easeOutBounce'
            },
            bar: {
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
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorMaquinariaPorAnioEstimado",
                                    data: "{'Year':'" + split_drill[0] + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                                     
                                        DrawChartMaquinaria(data, "Total estimado por Maquinaria - Año " + split_drill[0], "Meses");
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }
                            if (split_drill[1] == '2') { // drill down
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorMaquinariaTodosEstimado",
                                    data: JSON.stringify({ intSystemId: 1, intLoggedinUserId: 1 }),
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }

                                        DrawChartMaquinaria(data, "Total estimado por Maquinaria " + split_drill[0], "Días");
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
                    rotation: 1,
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
            type: 'bar',
            align: 'right',
            name: nombreEjeX == null || nombreEjeX == '' ? 'Años' : nombreEjeX,
            data: series,
        }],
        exporting: {
            enabled: true
        }

    });
}


function DrawChartTransito(series, titulo, nombreEjeX) {
    $('#containerEorTransito').highcharts({
        chart: {
          //  plotBorderWidth: 1,
            plotShadow: true,
            margin: 75,
            options3d: {
                enabled: true,
                alpha: 5,
                beta: 5,
                depth: 0,
                //viewDistance: 100
            }

        },
        title: {
            text: titulo == null || titulo == '' ? 'Estimados por Tránsito' : titulo,
        },
        xAxis: {
            categories: true,
            labels: {
                //rotation: -45,
                style: {
                   // fontSize: '11px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        tooltip: {
            pointFormat: '{series.name}: <b>${point.y}</b>',
            borderColor: '#173e4f',
            borderRadius: 10,
            borderWidth: 1
        },
        plotOptions: {
            series: {
                animation: {
                    duration: 2000,
                    //                    easing: 'easeOutBounce'
                }
            },
            bar: {
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
                                    data: "{'Year':'" + split_drill[0] + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                                       

                                        DrawChartTransito(data, "Total estimados por Tránsito - Año " + split_drill[0], "Meses");
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }
                            if (split_drill[1] == '2') { // drill down
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorTransitoTodosEstimado",
                                    data: JSON.stringify({ intSystemId: 1, intLoggedinUserId: 1 }),
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                                        DrawChartTransito(data, "Total estimados por Tránsito " + split_drill[0], "Días");
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
                    rotation: 1,
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
            type: 'bar',
            align: 'right',
            name: nombreEjeX == null || nombreEjeX == '' ? 'Años' : nombreEjeX,
            data: series,
        }],
        exporting: {
            enabled: true
        }

    });
}


function DrawChartEstructuraReal(series, titulo, nombreEjeX) {
    $('#containerEorEstructuraReal').highcharts({

        chart: {
           // plotBorderWidth: 1,
            plotShadow: true,
            margin: 75,
            options3d: {
                enabled: true,
                //alpha: 2,
                //beta: 4,
                //depth: 0,
                //viewDistance: 25
                alpha: 5,
                beta: 5,
                depth: 0
            }
        },
        title: {
            text: titulo == null || titulo == '' ? 'Total real por Estructura' : titulo
        },

        xAxis: {
            categories: true,
            labels: {
                //rotation: -45,
                style: {
                   // fontSize: '11px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        tooltip: {
            pointFormat: '{series.name}: <b>${point.y}</b>'
        },
        plotOptions: {
            series: {
                animation: {
                    duration: 2000,
                    //                    easing: 'easeOutBounce'
                }
            },
            bar: {
                cursor: 'pointer',
                color: "#59955C",
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
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorEstructuraRealPorAnio",
                                    data: "{'Year':'" + split_drill[0] + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];

                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                                         

                                              

                                        DrawChartEstructuraReal(data, "Total real por Estructura - Año " + split_drill[0], "Meses");
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }

                            if (split_drill[1] == '2') { // drill down
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorEstructuraTodosEstimado",
                                    data: JSON.stringify({ intSystemId: 1, intLoggedinUserId: 1 }),
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                                        DrawChartEstructuraReal(data, "Total real por Estructura " + split_drill[0], "Días");
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
                    rotation: 1,
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
            type: 'bar',
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


function DrawChartMaquinariaReal(series, titulo, nombreEjeX) {
    $('#containerEorMaquinariaReal').highcharts({
        chart: {
            //plotBorderWidth: 1,
            plotShadow: true,
            margin: 75,
            options3d: {
                enabled: true,
                //alpha: 2,
                //beta: 4,
                //depth: 0,
                //viewDistance: 25
                alpha: 5,
                beta: 5,
                depth: 0
            }

        },
        title: {
            text: titulo == null || titulo == '' ? 'Total real por Maquinaria' : titulo,
        },
        xAxis: {
            categories: true,
            labels: {
                //rotation: -45,
                style: {
                    //fontSize: '11px',
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
            series: {
                animation: {
                    duration: 2000,
                    //                    easing: 'easeOutBounce'
                }
            },
            bar: {
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
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorMaquinariaRealPorAnio",
                                    data: "{'Year':'" + split_drill[0] + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                               
                                        DrawChartMaquinariaReal(data, "Total real por Maquinaria  - Año " + split_drill[0], "Meses");
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }
                            if (split_drill[1] == '2') { // drill down
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorMaquinariaTodosEstimado",
                                    data: JSON.stringify({ intSystemId: 1, intLoggedinUserId: 1 }),
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                                        DrawChartMaquinariaReal(data, "Total real por Maquinaria " + split_drill[0], "Días");
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
                   // rotation: -45,
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
            type: 'bar',
            align: 'right',
            name: nombreEjeX == null || nombreEjeX == '' ? 'Años' : nombreEjeX,
            data: series,
        }],
        exporting: {
            enabled: true
        }

    });
}


function DrawChartTransitoReal(series, titulo, nombreEjeX) {
    $('#containerEorTransitoReal').highcharts({
        chart: {
            plotBorderWidth: 1,
            plotShadow: true,
            margin: 75,
            options3d: {
                enabled: true,
                //alpha: 2,
                //beta: 4,
                //depth: 0,
                //viewDistance: 25
                alpha: 5,
                beta: 5,
                depth: 0
            }

        },
        title: {
            text: titulo == null || titulo == '' ? 'Estimados Real por Transito' : titulo,
        },
        xAxis: {
            categories: true,
            labels: {
                //rotation: -45,
                style: {
                   // fontSize: '11px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        tooltip: {
            pointFormat: '{series.name}: <b>${point.y}</b>',
            borderColor: '#348db2',
            borderRadius: 10,
            borderWidth: 1
        },
        plotOptions: {
            series: {
                animation: {
                    duration: 2000,
                    //                    easing: 'easeOutBounce'
                }
            },
            bar: {
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
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorTransitoRealPorAnio",
                                    data: "{'Year':'" + split_drill[0] + "'}",
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                                
                                        DrawChartTransitoReal(data, "Total real por Tránsito  - Año " + split_drill[0], "Meses");
                                    },
                                    error: function (error) {
                                        console.log(error);
                                    }
                                });
                            }
                            if (split_drill[1] == '2') { // drill down
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "../ServiciosAsmx/HighchartService.asmx/obtenerTotalesEorTransitoTodosReal",
                                    data: JSON.stringify({ intSystemId: 1, intLoggedinUserId: 1 }),
                                    dataType: "json",
                                    success: function (Result) {
                                        Result = Result.d;
                                        var data = [];
                                        for (var i in Result) {
                                            var serie = { name: Result[i].Name, y: Result[i].Value, drilldown: Result[i].Name + '?' + Result[i].Level };
                                            data.push(serie);
                                        }
                                        DrawChartTransitoReal(data, "Total real por Tránsito " + split_drill[0], "Días");
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
                    //rotation: -45,
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
            type: 'bar',
            align: 'rigth',
            name: nombreEjeX == null || nombreEjeX == '' ? 'Años' : nombreEjeX,
            data: series,
        }],
        exporting: {
            enabled: true
        }

    });
}


