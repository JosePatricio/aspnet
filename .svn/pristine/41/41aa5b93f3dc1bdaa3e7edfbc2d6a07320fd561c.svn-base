using System;
using System.Linq;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using Negocio.Reportes;
using Sigeor.Utilidades;

namespace Sigeor
{
    public class EorDetalleMaquinariaReport
    {
        public static void Show(ref ReportViewer reportViewer, ref LocalReport localReport, Page page, string idReporte, ref DrillthroughEventArgs e)
        {

            try
            {
                localReport.ReportPath = localReport.ReportPath.Replace("EirMaquinariaReport", "EorCabeceraMaquinariaReport");
                if (localReport.GetParameters().Any())
                {



                    var numeroEor = localReport.GetParameters().FirstOrDefault().Values.FirstOrDefault();

                    var split = numeroEor.Split('-');

                    if (split.Length > 0)
                        numeroEor = split[0];
                                                            

                    var lista = ReporteEorMaquinariaNegocio.ObtenerEorDetallePorNumeroEor(numeroEor);

                    if (!string.IsNullOrEmpty(numeroEor) && lista.Any())
                    {
                        var detalle = lista.FirstOrDefault();
                        //reportViewer.LocalReport.SetParameters(new ReportParameter("numEor", detalle.NUM_EOREST));
                        localReport.SetParameters(new ReportParameter("numEor", numeroEor));
                        localReport.SetParameters(new ReportParameter("LineParam", detalle.NOM_LINEA));
                        localReport.SetParameters(new ReportParameter("ContainerParam", detalle.CONTAINER));
                        localReport.SetParameters(new ReportParameter("TypeParam", detalle.COD_TIPCONT));
                        localReport.SetParameters(new ReportParameter("LocationParam", detalle.NOMBRE_DEPOSITO));

                        var nombreEstado = detalle.ESTADO.Equals("D") ? "DAMAGE" : detalle.ESTADO.Equals("R") ? "REPAIR" : detalle.ESTADO.Equals("A") ? "AUTORIZADO" : string.Empty;

                        localReport.SetParameters(new ReportParameter("BoxParam", string.Empty));
                        localReport.SetParameters(new ReportParameter("MachineryParam", nombreEstado));
                        localReport.SetParameters(new ReportParameter("LaborRateBoxParam", detalle.COSTOMAOBRA.ToString()));
                        localReport.SetParameters(new ReportParameter("LaborRateMacParam", string.Empty));
                        localReport.SetParameters(new ReportParameter("DateEstimateBoxParam", string.Empty));
                        localReport.SetParameters(new ReportParameter("DateEstimateMacParam", detalle.FECHA_EORMAQ != null ? detalle.FECHA_EORMAQ.Value.ToString("dd/MMM/yyyy") : string.Empty));
                        localReport.SetParameters(new ReportParameter("DateEirParam", detalle.FECHA_EIR.ToString("dd/MMM/yyyy")));
                        localReport.SetParameters(new ReportParameter("NumEirParam", detalle.ID_EIR));

                        localReport.DataSources.Add(new ReportDataSource(string.Concat(idReporte, "DataSet"), lista));
                    }
                    else
                    {
                        e.Cancel = true;
                        GestionUtil.MostrarNotificacion(page, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "El EOR " + numeroEor + " no tiene Detalle");
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
                throw new Exception("No se pudo cargar el reporte de EOR por Maquinaria: " + ex.Message);
            }
        }
    }
}