using System;
using System.Linq;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using Negocio.Reportes;
using Sigeor.Utilidades;
using PersistenciaSigeor;
using System.Collections.Generic;

namespace Sigeor
{
    public class EorDetalleConsolidadoReport
    {
        public static void Show(ref ReportViewer reportViewer, ref LocalReport localReport, Page page, string idReporte, ref DrillthroughEventArgs e)
        {

            try
            {
                localReport.ReportPath
                    = localReport.ReportPath.Replace("EstimacionEirReport", "EorCabeceraEstructuraReport");// += "\\EorCabeceraEstructuraReport\\EorDetalleEstructuraReport.rdlc";

                if (localReport.GetParameters().Any())
                {

                    reportViewer.LocalReport.DisplayName = string.Concat(idReporte, "_", DateTime.Now.ToString("yyyyMMdd"));

                    var numeroEor = localReport.GetParameters().FirstOrDefault().Values.FirstOrDefault();

                    var listaDetalleEstructura = ReporteEorEstructuraNegocio.ObtenerEorDetallePorNumeroEor(numeroEor);

                    var listaDetalleMaquinaria = ReporteEorMaquinariaNegocio.ObtenerEorDetallePorNumeroEor(numeroEor);

                    var listaDetalleTransito = ReporteEorTransitoNegocio.ObtenerEorDetallePorNumeroEor(numeroEor);

                    GET_DETALLE_EOR_ESTRUCTURA_Result detalleEstructura;
                    var lista = new List<GET_DETALLE_EOR_ESTRUCTURA_Result>();

                    if (!listaDetalleEstructura.Any())
                    {


                        foreach (var itemMaquinaria in listaDetalleMaquinaria)
                        {
                            detalleEstructura = new GET_DETALLE_EOR_ESTRUCTURA_Result
                            {
                                NUM_EOREST = itemMaquinaria.NUM_EORMAQ,
                                ID_EIR = itemMaquinaria.ID_EIR,
                                FECHA_EIR = itemMaquinaria.FECHA_EIR,
                                COD_TIPCONT = itemMaquinaria.COD_TIPCONT,
                                FECHA_EOR = itemMaquinaria.FECHA_EORMAQ,
                                CONTAINER = itemMaquinaria.CONTAINER,
                                ESTADO = itemMaquinaria.ESTADO,
                                //TOTAL_COSTOHH = itemMaquinaria.TOTAL_COSTOHH,
                                NOM_LINEA = itemMaquinaria.NOM_LINEA,
                                NOMBRE_DEPOSITO = itemMaquinaria.NOMBRE_DEPOSITO,
                                ID_EGRPRODUCTO = itemMaquinaria.ID_EGRPRODUCTO,
                                ID_SECEGRESO = itemMaquinaria.ID_SECEGRESO,
                                COD_DEPOSITO = itemMaquinaria.COD_DEPOSITO,
                                ID_BODEGA = itemMaquinaria.ID_BODEGA,
                                ID_PRODUCTO = itemMaquinaria.ID_PRODUCTO,
                                NOMBRE = itemMaquinaria.NOMBRE,
                                TIPO = itemMaquinaria.TIPO,
                                CANTIDAD = itemMaquinaria.CANTIDAD,
                                COSTO = itemMaquinaria.COSTO,
                                TOTAL = itemMaquinaria.TOTAL,
                                COSTO_IVA = itemMaquinaria.COSTO_IVA,
                                TOTAL_IVA = itemMaquinaria.TOTAL_IVA,
                                ID_SECDANIO = itemMaquinaria.ID_SECDANIO,
                                CANTIDADREAL = itemMaquinaria.CANTIDADREAL,
                                COSTOREAL = itemMaquinaria.COSTOREAL,
                                TOTALREAL = itemMaquinaria.TOTALREAL,
                                DIFERENCIA = itemMaquinaria.DIFERENCIA
                            };
                            lista.Add(detalleEstructura);
                        }
                        if (!lista.Any())
                        {
                            foreach (var itemTransito in listaDetalleTransito)
                            {
                                detalleEstructura = new GET_DETALLE_EOR_ESTRUCTURA_Result
                                {
                                    NUM_EOREST = itemTransito.NUM_EORTRANSITO,
                                    ID_EIR = string.Empty,
                                    //FECHA_EIR = null,
                                    COD_TIPCONT = string.Empty,
                                    //FECHA_EOR = detalleTransito.FECHA_EOR,
                                    CONTAINER = itemTransito.CONTAINER,
                                    ESTADO = "REPARADO",//detalleTransito.APROBADOEST,detalleTransito.APROBADOMAQ
                                   // TOTAL_COSTOHH = itemTransito.TOTAL_COSTOHH,
                                    NOM_LINEA = itemTransito.NOM_LINEA,
                                    NOMBRE_DEPOSITO = itemTransito.NOMBRE_DEPOSITO,
                                    ID_EGRPRODUCTO = itemTransito.ID_EGRPRODUCTO,
                                    ID_SECEGRESO = itemTransito.ID_SECEGRESO,
                                    COD_DEPOSITO = itemTransito.COD_DEPOSITO,
                                    ID_BODEGA = itemTransito.ID_BODEGA,
                                    ID_PRODUCTO = itemTransito.ID_PRODUCTO,
                                    NOMBRE = itemTransito.NOMBRE,
                                    TIPO = itemTransito.TIPO,
                                    CANTIDAD = itemTransito.CANTIDAD,
                                    COSTO = itemTransito.COSTO,
                                    TOTAL = itemTransito.TOTAL,
                                    COSTO_IVA = itemTransito.COSTO_IVA,
                                    TOTAL_IVA = itemTransito.TOTAL_IVA,
                                    ID_SECDANIO = itemTransito.ID_SECDANIO,
                                    CANTIDADREAL = itemTransito.CANTIDADREAL,
                                    COSTOREAL = itemTransito.COSTOREAL,
                                    TOTALREAL = itemTransito.TOTALREAL,
                                    DIFERENCIA = itemTransito.TOTAL_IVA - itemTransito.TOTALREAL
                                };
                                lista.Add(detalleEstructura);
                            }
                        }

                    }
                    else
                    {
                        foreach (var itemEstructura in listaDetalleEstructura)
                        {
                            detalleEstructura = new GET_DETALLE_EOR_ESTRUCTURA_Result
                            {
                                NUM_EOREST = itemEstructura.NUM_EOREST,
                                ID_EIR = itemEstructura.ID_EIR,
                                FECHA_EIR = itemEstructura.FECHA_EIR,
                                COD_TIPCONT = itemEstructura.COD_TIPCONT,
                                FECHA_EOR = itemEstructura.FECHA_EOR,
                                CONTAINER = itemEstructura.CONTAINER,
                                ESTADO = itemEstructura.ESTADO,
                               // TOTAL_COSTOHH = itemEstructura.TOTAL_COSTOHH,
                                NOM_LINEA = itemEstructura.NOM_LINEA,
                                NOMBRE_DEPOSITO = itemEstructura.NOMBRE_DEPOSITO,
                                ID_EGRPRODUCTO = itemEstructura.ID_EGRPRODUCTO,
                                ID_SECEGRESO = itemEstructura.ID_SECEGRESO,
                                COD_DEPOSITO = itemEstructura.COD_DEPOSITO,
                                ID_BODEGA = itemEstructura.ID_BODEGA,
                                ID_PRODUCTO = itemEstructura.ID_PRODUCTO,
                                NOMBRE = itemEstructura.NOMBRE,
                                TIPO = itemEstructura.TIPO,
                                CANTIDAD = itemEstructura.CANTIDAD,
                                COSTO = itemEstructura.COSTO,
                                TOTAL = itemEstructura.TOTAL,
                                COSTO_IVA = itemEstructura.COSTO_IVA,
                                TOTAL_IVA = itemEstructura.TOTAL_IVA,
                                ID_SECDANIO = itemEstructura.ID_SECDANIO,
                                CANTIDADREAL = itemEstructura.CANTIDADREAL,
                                COSTOREAL = itemEstructura.COSTOREAL,
                                TOTALREAL = itemEstructura.TOTALREAL,
                                DIFERENCIA = itemEstructura.DIFERENCIA
                            };
                            lista.Add(detalleEstructura);
                        }
                    }


                    if (!string.IsNullOrEmpty(numeroEor) && lista.Any())
                    {

                        var detEstructura = listaDetalleEstructura.FirstOrDefault();
                        var detMaquinaria = listaDetalleMaquinaria.FirstOrDefault();
                        var detTransito = listaDetalleTransito.FirstOrDefault();

                        var nombreLinea = detEstructura != null ? detEstructura.NOM_LINEA : detMaquinaria != null ? detMaquinaria.NOM_LINEA : detTransito != null ? detTransito.NOM_LINEA : string.Empty;
                        var container = detEstructura != null ? detEstructura.CONTAINER : detMaquinaria != null ? detMaquinaria.CONTAINER : detTransito != null ? detTransito.CONTAINER : string.Empty;
                        var codTipCont = detEstructura != null ? detEstructura.COD_TIPCONT : detMaquinaria != null ? detMaquinaria.COD_TIPCONT : string.Empty;
                        var nombreDeposito = detEstructura != null ? detEstructura.NOMBRE_DEPOSITO : detMaquinaria != null ? detMaquinaria.NOMBRE_DEPOSITO : detTransito != null ? detTransito.NOMBRE_DEPOSITO : string.Empty;
                        var nombreEstadoEstructura = detEstructura != null ? detEstructura.ESTADO : detTransito != null ? (detTransito.APROBADOEST.Equals("8") ? "REPAIR" : string.Empty) : string.Empty;
                        var nombreEstadoMaquinaria = detMaquinaria != null ? detMaquinaria.ESTADO : detTransito != null ? (detTransito.APROBADOMAQ.Equals("8") ? "REPAIR" : string.Empty) : string.Empty;
                        var fechaEir = detEstructura != null ? detEstructura.FECHA_EIR.ToString("dd/MMM/yyyy") : detMaquinaria != null ? detMaquinaria.FECHA_EIR.ToString("dd/MMM/yyyy") : string.Empty;
                        var numEir = detEstructura != null ? detEstructura.ID_EIR : detMaquinaria != null ? detMaquinaria.ID_EIR : string.Empty;



                        //reportViewer.LocalReport.SetParameters(new ReportParameter("numEor", detalle.NUM_EOREST));
                        localReport.SetParameters(new ReportParameter("numEor", numeroEor));
                        localReport.SetParameters(new ReportParameter("LineParam", nombreLinea));
                        localReport.SetParameters(new ReportParameter("ContainerParam", container));
                        localReport.SetParameters(new ReportParameter("TypeParam", codTipCont));
                        localReport.SetParameters(new ReportParameter("LocationParam", nombreDeposito));

                        //var nombreEstado = detalle.ESTADO.Equals("D") ? "DAMAGE" : detalle.ESTADO.Equals("R") ? "REPAIR" : detalle.ESTADO.Equals("A") ? "AUTORIZADO" : string.Empty;

                        localReport.SetParameters(new ReportParameter("BoxParam", nombreEstadoEstructura));
                        localReport.SetParameters(new ReportParameter("MachineryParam", nombreEstadoMaquinaria));
                        localReport.SetParameters(new ReportParameter("LaborRateBoxParam", detEstructura.COSTOMAOBRA.ToString()));
                        localReport.SetParameters(new ReportParameter("LaborRateMacParam", string.Empty));
                        localReport.SetParameters(new ReportParameter("DateEstimateBoxParam", detEstructura.FECHA_EOR != null ? detEstructura.FECHA_EOR.Value.ToString("dd/MMM/yyyy") : string.Empty));
                        localReport.SetParameters(new ReportParameter("DateEstimateMacParam", detMaquinaria.FECHA_EORMAQ != null ? detEstructura.FECHA_EOR.Value.ToString("dd/MMM/yyyy") : string.Empty));
                        localReport.SetParameters(new ReportParameter("DateEirParam", fechaEir));
                        localReport.SetParameters(new ReportParameter("NumEirParam", numEir));



                        localReport.SetParameters(new ReportParameter("TotalHHEstructuraEstimado", (detEstructura != null ? detEstructura.COSTOMAOBRA.Value.ToString() : string.Empty)));
                        localReport.SetParameters(new ReportParameter("TotalHHMaquinariaEstimado", (detMaquinaria != null ? detMaquinaria.COSTOMAOBRA.Value.ToString() : string.Empty)));
                        localReport.SetParameters(new ReportParameter("TotalHHTransitoEstimado", (detTransito != null ? detTransito.COSTOMAOBRA.Value.ToString() : string.Empty)));

                        //localReport.SetParameters(new ReportParameter("TotalHHEstructuraReal", (detEstructura != null ? detEstructura.TOTAL_COSTOHH.Value.ToString() : string.Empty)));
                        //localReport.SetParameters(new ReportParameter("TotalHHMaquinariaReal", (detMaquinaria != null ? detMaquinaria.TOTAL_COSTOHH.Value.ToString() : string.Empty)));
                        localReport.SetParameters(new ReportParameter("TotalHHTransitoReal", (detTransito != null ? detTransito.TOTAL_COSTOHH.Value.ToString() : string.Empty)));

                        //localReport.SetParameters(new ReportParameter("diferenciaEstructura", (detEstructura != null ? ((detEstructura.COSTOMAOBRA ?? new decimal(0)) - (detEstructura.TOTAL_COSTOHH ?? new decimal(0))).ToString() : string.Empty)));
                        //localReport.SetParameters(new ReportParameter("diferenciaMaquinaria", (detMaquinaria != null ? ((detMaquinaria.COSTOMAOBRA ?? new decimal(0)) - (detMaquinaria.TOTAL_COSTOHH ?? new decimal(0))).ToString() : string.Empty)));
                        localReport.SetParameters(new ReportParameter("diferenciaTransito", (detTransito != null ? ((detTransito.COSTOMAOBRA ?? new decimal(0)) - (detTransito.TOTAL_COSTOHH ?? new decimal(0))).ToString() : string.Empty)));



                        localReport.DataSources.Add(new ReportDataSource(string.Concat(idReporte, "DataSet"), lista));
                        //reportViewer.DataBind();
                        //reportViewer.LocalReport.Refresh();
                    }
                    else
                    {
                        e.Cancel = true;
                        GestionUtil.MostrarNotificacion(page, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "El EOR \"" + numeroEor + "\" no tiene Detalle");
                    }
                    //var lista = !string.IsNullOrEmpty(result)
                    //    ? Serializador.DeSerializeEntity<List<GET_CABECERA_EOR_ESTRUCTURA_Result>>(result)
                    //    : new List<GET_CABECERA_EOR_ESTRUCTURA_Result>();

                    //reportViewer.DataBind();
                    //reportViewer.LocalReport.Refresh();

                }
                else
                {
                    GestionUtil.MostrarNotificacion(page, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "No se encontró datos para cargar el reporte");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar el reporte de EOR por Estructura: " + ex.Message);
            }
        }
    }
}