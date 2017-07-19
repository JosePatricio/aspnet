using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.Utilidades;

namespace Sigeor
{
    public class EorEstructuraPorDeposito
    {
        public static void Show(ref ReportViewer reportViewer, Page page, string idReporte, string serverPath)
        {

            try
            {

                var filtro = HttpContext.Current.Session[string.Concat("EorEstructuraPorDeposito", "Value")];

                var parametro = (ClaseBasica) filtro;

                if (parametro != null)
                {
                    var cliente = new GestionAretinaServiceReference.LecturaAretinaClient();

                    var result =
                        cliente.ObtenerEorEstructuraPorDeposito(Serializador.SerializeEntity(parametro));

                    if (!string.IsNullOrEmpty(result))
                    {
                        var pathReporte = string.Concat(serverPath, "\\", idReporte, ".rdlc");
                        reportViewer.LocalReport.ReportPath = pathReporte;
                        reportViewer.LocalReport.DisplayName = string.Concat(idReporte, "_", DateTime.Now.ToString("yyyyMMdd"));
                        reportViewer.LocalReport.DataSources.Clear();
                        var lista = Serializador.DeSerializeEntity<List<SC_EORESTRUCTURA>>(result);
                        reportViewer.LocalReport.DataSources.Add(new ReportDataSource(string.Concat(idReporte, "DataSet"), lista));
                        //reportViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
                        reportViewer.DataBind();
                        reportViewer.LocalReport.Refresh();
                    }
                    else
                    {
                        GestionUtil.MostrarNotificacion(page, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "No se encontraron resultados para el reporte");
                    }


                }
                else
                {
                    GestionUtil.MostrarNotificacion(page, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "No se pudo cargar los filtros del reporte");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar el reporte de EOR por Estructura: " + ex.Message);
            }
        }


    }
}