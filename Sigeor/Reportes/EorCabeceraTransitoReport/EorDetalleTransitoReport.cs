using System;
using System.Linq;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using Negocio.Reportes;
using Sigeor.Utilidades;

namespace Sigeor
{
    public class EorDetalleTransitoReport
    {
        public static void Show(ref ReportViewer reportViewer, ref LocalReport localReport, Page page, string idReporte, ref DrillthroughEventArgs e)
        {

            try
            {
                
                if (localReport.GetParameters().Any())
                {
                    

                    //var pathReporte = string.Concat(serverPath, "\\", idReporte, ".rdlc");
                    //reportViewer.LocalReport.ReportPath = pathReporte;
                    reportViewer.LocalReport.DisplayName = string.Concat(idReporte, "_", DateTime.Now.ToString("yyyyMMdd"));
                    //reportViewer.LocalReport.SetParameters(new ReportParameter("EorNumberParam", auxEor.CabeceraEstructura.NUM_EOREST));
                    //reportViewer.LocalReport.SetParameters(new ReportParameter("LineParam", auxEor.CabeceraEstructura.DetalleEorEstructura.FirstOrDefault().Linea.NOM_LINEA));
                    //reportViewer.LocalReport.SetParameters(new ReportParameter("ContainerParam", auxEor.CabeceraEstructura.PREF_CONTAINER + auxEor.CabeceraEstructura.NUM_CONTAINER));
                    //reportViewer.LocalReport.SetParameters(new ReportParameter("TypeParam", auxEor.CabeceraEstructura.CampoEir.COD_TIPCONT));
                    //reportViewer.LocalReport.SetParameters(new ReportParameter("LocationParam", auxEor.CabeceraEstructura.CampoDeposito.NOMBRE_DEPOSITO));

                    //var nombreEstado = estado.Equals("D") ? "DAMAGE" : estado.Equals("R") ? "REPAIR" : estado.Equals("A") ? "AUTORIZADO" : string.Empty;
                    //reportViewer.LocalReport.SetParameters(new ReportParameter("BoxParam", nombreEstado));
                    //reportViewer.LocalReport.SetParameters(new ReportParameter("MachineryParam", string.Empty));
                    //reportViewer.LocalReport.SetParameters(new ReportParameter("LaborRateBoxParam", auxEor.CabeceraEstructura.DetalleEorEstructura.FirstOrDefault().COSTOMAOBRA.ToString()));
                    //reportViewer.LocalReport.SetParameters(new ReportParameter("LaborRateMacParam", string.Empty));
                    //reportViewer.LocalReport.SetParameters(new ReportParameter("DateEstimateBoxParam", auxEor.CabeceraEstructura.FECHA_EOR.Value.ToString("dd/MMM/yyyy")));
                    //reportViewer.LocalReport.SetParameters(new ReportParameter("DateEstimateMacParam", string.Empty));
                    //reportViewer.LocalReport.SetParameters(new ReportParameter("DateEirParam", auxEor.CabeceraEstructura.CampoEir.FECHA_EIR.ToString("dd/MMM/yyyy")));
                    //reportViewer.LocalReport.SetParameters(new ReportParameter("NumEirParam", auxEor.CabeceraEstructura.ID_EIR));

                    //reportViewer.LocalReport.DataSources.Clear();
                    var numeroEor = localReport.GetParameters().FirstOrDefault().Values.FirstOrDefault();
                    var lista = ReporteEorTransitoNegocio.ObtenerEorDetallePorNumeroEor(numeroEor);
                    if (!string.IsNullOrEmpty(numeroEor) && lista.Any())
                    {
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
                throw new Exception("No se pudo cargar el reporte de EOR por Transito: " + ex.Message);
            }
        }
    }
}