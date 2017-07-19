using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using Negocio.Reportes;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.Utilidades;

namespace Sigeor
{
    public class EorCabeceraEstructuraReport
    {
        public static void Show(ref ReportViewer reportViewer, Page page, string idReporte, string serverPath)
        {

            try
            {

                //var eorSession = HttpContext.Current.Session[idReporte];

                var parametros = HttpContext.Current.Session[string.Concat(idReporte, "Value")];

                if (parametros != null)
                {

                    var pathReporte = string.Concat(serverPath, "\\", idReporte, ".rdlc");
                    reportViewer.LocalReport.ReportPath = pathReporte;
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

                    reportViewer.LocalReport.DataSources.Clear();
                    var lista = ReporteEorEstructuraNegocio.ObtenerEorCabeceraPorFiltros(parametros.ToString());
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource(string.Concat(idReporte, "DataSet"), lista));
                    reportViewer.DataBind();
                    reportViewer.LocalReport.Refresh();

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

        public static void ShowChild(ref LocalReport localReport, Page page, string idReporte, string serverPath, ref DrillthroughEventArgs e)
        {

            try
            {
                localReport.ReportPath = serverPath + "\\EorCabeceraEstructuraReport\\EorCabeceraEstructuraReport.rdlc";

                if (localReport.GetParameters().Any())
                {

                    localReport.DisplayName = string.Concat(idReporte, "_", DateTime.Now.ToString("yyyyMMdd"));

                    var numeroEir = localReport.GetParameters().FirstOrDefault().Values.FirstOrDefault();
                    var param = new ClaseBasica { Descripcion = numeroEir };
                    var lista = ReporteEorEstructuraNegocio.ObtenerEorCabeceraPorFiltros(Serializador.SerializeEntity(param));
                    if (!string.IsNullOrEmpty(numeroEir) && lista.Any())
                    {
                        //var detalle = lista.FirstOrDefault();
                        //reportViewer.LocalReport.SetParameters(new ReportParameter("numEor", detalle.NUM_EOREST));
                        //reportViewer.LocalReport.SetParameters(new ReportParameter("LineParam", detalle.NOM_LINEA));
                        //reportViewer.LocalReport.SetParameters(new ReportParameter("ContainerParam", detalle.CONTAINER));
                        //reportViewer.LocalReport.SetParameters(new ReportParameter("TypeParam", detalle.COD_TIPCONT));
                        //reportViewer.LocalReport.SetParameters(new ReportParameter("LocationParam", detalle.NOMBRE_DEPOSITO));

                        //var nombreEstado = detalle.ESTADO.Equals("D") ? "DAMAGE" : detalle.ESTADO.Equals("R") ? "REPAIR" : detalle.ESTADO.Equals("A") ? "AUTORIZADO" : string.Empty;
                        //reportViewer.LocalReport.SetParameters(new ReportParameter("BoxParam", nombreEstado));
                        //reportViewer.LocalReport.SetParameters(new ReportParameter("MachineryParam", string.Empty));
                        //reportViewer.LocalReport.SetParameters(new ReportParameter("LaborRateBoxParam", detalle.COSTOMAOBRA.ToString()));
                        //reportViewer.LocalReport.SetParameters(new ReportParameter("LaborRateMacParam", string.Empty));
                        //reportViewer.LocalReport.SetParameters(new ReportParameter("DateEstimateBoxParam", string.Empty));//detalle.ToString("dd/MMM/yyyy")));
                        //reportViewer.LocalReport.SetParameters(new ReportParameter("DateEstimateMacParam", string.Empty));
                        //reportViewer.LocalReport.SetParameters(new ReportParameter("DateEirParam", detalle.FECHA_EIR.ToString("dd/MMM/yyyy")));
                        //reportViewer.LocalReport.SetParameters(new ReportParameter("NumEirParam", detalle.ID_EIR));

                        localReport.DataSources.Add(new ReportDataSource(string.Concat(idReporte, "DataSet"), lista));
                    }
                    //else {
                    //    if (!string.IsNullOrEmpty(numeroEir) && !lista.Any())
                    //    {
                    //        Sigeor.Reportes.EirMaquinariaReport.EirMaquinariaReport.ShowChild(ref localReport, page, "EirMaquinariaReport", serverPath, ref e);
                    //    }
                    else
                    {
                        e.Cancel = true;
                        GestionUtil.MostrarNotificacion(page, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "El EIR \"" + numeroEir + "\" noooo tiene Detalle");
                    }
                }

                //var lista = !string.IsNullOrEmpty(result)
                //    ? Serializador.DeSerializeEntity<List<GET_CABECERA_EOR_ESTRUCTURA_Result>>(result)
                //    : new List<GET_CABECERA_EOR_ESTRUCTURA_Result>();

                //reportViewer.DataBind();
                //reportViewer.LocalReport.Refresh();

            
                else
                {
                GestionUtil.MostrarNotificacion(page, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "No se encontró datos para cargar el reporte");
            }
        }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar el reporte de EIR por Estructura: " + ex.Message);
    }
}

    }
}