using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using Negocio.Configuracion;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.Utilidades;

namespace Sigeor
{
    public class AuditoriaReport
    {
        public static void Show(ref ReportViewer reportViewer, Page page, string idReporte, string serverPath)
        {
            try
            {
                var valueFiltro = HttpContext.Current.Session[string.Concat(idReporte, "Value")] != null ? HttpContext.Current.Session[string.Concat(idReporte, "Value")].ToString() : string.Empty;


                var result = AuditoriaNegocio.ObtenerAuditoriaPorCoincidencia(valueFiltro);
                if (!string.IsNullOrEmpty(result))
                {
                    var lista = Serializador.DeSerializeEntity<List<GET_AUDITORIA_Result>>(result);
                    var pathReporte = string.Concat(serverPath, "\\", idReporte, ".rdlc");
                    reportViewer.LocalReport.DisplayName = string.Concat(idReporte, "_", DateTime.Now.ToString("yyyyMMdd"));
                    reportViewer.LocalReport.ReportPath = pathReporte;
                    reportViewer.LocalReport.DataSources.Clear();
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource(string.Concat(idReporte, "DataSet"), lista));
                    reportViewer.LocalReport.Refresh();
                }
                else
                {
                    GestionUtil.MostrarNotificacion(page, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "No se encontró datos para cargar el reporte");
                }
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(page, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }
        }
    }
}