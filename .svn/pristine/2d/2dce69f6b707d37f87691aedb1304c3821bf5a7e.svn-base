using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using PersistenciaSigeor;
using Sigeor.Utilidades;
using Negocio.Utilidades;
using System.IO;
using Sigeor.GestionReportesServiceReference;

namespace Sigeor.Reportes.EirMaquinariaReport
{
    public class EirMaquinariaReport
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

                    List<GET_EIR_ESTRUCTURA_Result> lista = null;
                    String result = "";

                    result = new ReportesServiceClient().ObtenerDatosEirMaquinariaReporte(xml);
                    lista = result != null ? Serializador.DeSerializeEntity<List<GET_EIR_ESTRUCTURA_Result>>(result) : null;


                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource(string.Concat(idReporte, "DataSet"), lista));

                    reportViewer.DataBind();
                    reportViewer.LocalReport.Refresh();

                }
                else
                {
                    GestionUtil.MostrarNotificacion(page, ConstantesUtil.notificacionInfo, string.Empty, "No se encontró datos para cargar el reporte");
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
                localReport.ReportPath = serverPath + "\\EirMaquinariaReport\\EirMaquinariaReport.rdlc";

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

                        bool reporte=localReport.IsDrillthroughReport;
                        string path = serverPath + "\\EstimacionEirReport\\EstimacionEirReport.rdlc";
                        string text = File.ReadAllText(path);
                        text = text.Replace("EorCabeceraEstructuraReport", "EirMaquinariaReport");
                        File.WriteAllText(path, text);
                        
                        localReport.DataSources.Add(new ReportDataSource(string.Concat(idReporte, "DataSet"), lista));

                        text = text.Replace("EirMaquinariaReport", "EorCabeceraEstructuraReport");
                        File.WriteAllText(path, text);
                    }
                    else
                    {
                        e.Cancel = true;
                        GestionUtil.MostrarNotificacion(page, ConstantesUtil.notificacionInfo, string.Empty, "El EIR \"" + numeroPti + "\" no tiene Detalle");
                    }

                }
                else
                {
                    GestionUtil.MostrarNotificacion(page, ConstantesUtil.notificacionInfo, string.Empty, "No se encontró datos para cargar el reporte");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar el reporte de EIR por Estructura: " + ex.Message);
            }
        }
    

    }
}