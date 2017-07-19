using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.Utilidades;
using Sigeor.GestionReportesServiceReference;

namespace Sigeor.Reportes.EstimacionEirReport
{
    public class EstimacionEirReport
    {
        public static void Show(ref ReportViewer reportViewer, Page page, string idReporte, string serverPath)
        {
            try
            {
                var filtrosSession = HttpContext.Current.Session[String.Concat(idReporte, "Value")];


                if (filtrosSession != null)
                {
                    string xml = (String)filtrosSession;

                    var pathReporte = string.Concat(serverPath, "\\", idReporte, ".rdlc");
                    reportViewer.LocalReport.ReportPath = pathReporte;
                    reportViewer.LocalReport.DisplayName = string.Concat(idReporte, "_", DateTime.Now.ToString("yyyyMMdd"));

                    reportViewer.LocalReport.DataSources.Clear();


                    List<GET_ESTIMACION_EIR_Result> lista = null;
                    String result = "";

                    result = new ReportesServiceClient().ObtenerDatosEstimacionEirReporte(xml);
                    lista = result != null ? Serializador.DeSerializeEntity<List<GET_ESTIMACION_EIR_Result>>(result) : null;


                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource(string.Concat(idReporte, "DataSet"), lista));


                    reportViewer.DataBind();
                    reportViewer.LocalReport.Refresh();
                    //HttpContext.Current.Session.Remove("idReporte");

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
                var filtrosSession = HttpContext.Current.Session[String.Concat(idReporte, "Value")];
                
                if (filtrosSession != null)
                {
                    string xml = (String)filtrosSession;
                }
                
                localReport.ReportPath = serverPath + "\\EorCabeceraEstructuraReport\\EorCabeceraEstructuraReport.rdlc";
             //   localReport.ReportPath = serverPath + "\\EirEstimacionReport\\SubEirEstimacionReport.rdlc";
                
                if (localReport.GetParameters().Any())
                {

                    localReport.DisplayName = string.Concat(idReporte, "_", DateTime.Now.ToString("yyyyMMdd"));

                    var numeroPti = localReport.GetParameters().FirstOrDefault().Values.FirstOrDefault();
                    var idEir = localReport.GetParameters().LastOrDefault().Values.FirstOrDefault();
                    var param = new ClaseBasica { Descripcion = idEir };


                    List<GET_PTI_EIR_Result> lista = null;
                    String result = "";
                    result = new ReportesServiceClient().ObtenerDatosPTI_EIR_Reporte(Serializador.SerializeEntity(param));
                    lista = result != null ? Serializador.DeSerializeEntity<List<GET_PTI_EIR_Result>>(result) : null;


                    if (!string.IsNullOrEmpty(numeroPti) && lista != null)
                    {
                        localReport.DataSources.Add(new ReportDataSource(string.Concat(idReporte, "DataSet"), lista));
                    }
                    else
                    {
                        e.Cancel = true;
                        GestionUtil.MostrarNotificacion(page, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "El EIR \"" + numeroPti + "\" Noooo tiene Detalle");
                    }

                }
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