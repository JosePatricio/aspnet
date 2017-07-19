using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using PersistenciaSigeor;
using Sigeor.Utilidades;
using Negocio.Utilidades;
using Sigeor.GestionReportesServiceReference;

namespace Sigeor.Reportes.PTIReport
{
    public class PTIReport
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

                    List<GET_PTI_Result> lista = null;
                    String result = "";
                    result = new ReportesServiceClient().ObtenerDatosPTIReporte(xml);
                    lista = result != null ? Serializador.DeSerializeEntity<List<GET_PTI_Result>>(result) : null;
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

      
    }
}