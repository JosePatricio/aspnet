using System;
using System.Linq;
using Microsoft.Reporting.WebForms;
using PersistenciaSigeor;
using Sigeor.Reportes.EorCabeceraTransitoReport;
using Sigeor.Utilidades;
using Sigeor.Reportes.PTIReport;
using Sigeor.Reportes.EstimacionEirReport;

namespace Sigeor
{
    public partial class VisorForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.Page.User.Identity.IsAuthenticated)
            {
                GestionUtil.RedireccionarSesionExpirada();
                return;
            }

            ReportViewer1.Drillthrough += new DrillthroughEventHandler(ReportViewer1DrillthroughEventHandler);

            if (!Page.IsPostBack)
            {

                var idReporte = Request.QueryString["Id"] ?? string.Empty;

                if (string.IsNullOrEmpty(idReporte))
                {
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "No se puede visualizar el reporte");
                    return;
                }

                Title = string.Concat("SIGEOR", "-", idReporte);
                VerReporte(idReporte);

            }
        }

        private void VerReporte(string idReporte)
        {
            switch (idReporte)
            {
                //case "EorEstructuraReport":
                //    //
                //    Session["EorEstructuraPorDepositoValue"] = new ClaseBasica { IdString = "PB", EstadoString = "R" };
                //    EorEstructuraReport.Show(ref ReportViewer1, this, idReporte, Server.MapPath(idReporte));
                //    break;

                case "AuditoriaReport":
                    AuditoriaReport.Show(ref ReportViewer1, this, idReporte, Server.MapPath(idReporte));
                    Session.Remove("AuditoriaReport");
                    break;

                //case "AdminDashBoardReport":
                //    AuditoriaReport.Show(ref ReportViewer1, this, idReporte, Server.MapPath(idReporte));

                //Session.Remove("AdminDashBoardReport");
                //break;

                case "EorCabeceraEstructuraReport":
                    EorCabeceraEstructuraReport.Show(ref ReportViewer1, this, idReporte, Server.MapPath(idReporte));
                    break;

                case "EorCabeceraMaquinariaReport":
                    EorCabeceraMaquinariaReport.Show(ref ReportViewer1, this, idReporte, Server.MapPath(idReporte));
                    break;

                case "EorCabeceraTransitoReport":
                    EorCabeceraTransitoReport.Show(ref ReportViewer1, this, idReporte, Server.MapPath(idReporte));
                    break;

                case "ConsolidadoEorReport":
                    ConsolidadoEorReport.Show(ref ReportViewer1, this, idReporte, Server.MapPath(idReporte));
                    break;
                //case "EirEstructuraReport":
                //    EirEstructuraReport.Show(ref ReportViewer1, this, idReporte, Server.MapPath(idReporte));
                //    Session.Remove("EirEstructuraReport");
                //    break;
                //case "EirMaquinariaReport":
                //    EirEstructuraReport.Show(ref ReportViewer1, this, idReporte, Server.MapPath(idReporte));
                //    Session.Remove("EirMaquinariaReport");
                //    break;

                case "PTIReport":
                    PTIReport.Show(ref ReportViewer1, this, idReporte, Server.MapPath(idReporte));
                    break;

                case "EstimacionEirReport":
                    EstimacionEirReport.Show(ref ReportViewer1, this, idReporte, Server.MapPath(idReporte));
                    break;

                default:
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "No existe ningún reporte con el nombre " + "\"" + idReporte + "\"");
                    break;
            }
        }




        private void VerReportesHijos(string idReporte, LocalReport localReport, ref DrillthroughEventArgs e)
        {
            switch (idReporte)
            {

                //case "EirMaquinariaReport":
                //    EirMaquinariaReport.ShowChild(ref localReport, this, idReporte, Server.MapPath(string.Empty), ref e);
                //    break;
                case "EorCabeceraMaquinariaReport":
                    EorCabeceraMaquinariaReport.ShowChild(ref localReport, this, idReporte, Server.MapPath(string.Empty), ref e);
                    break;
                case "EstimacionEirReport":
                    EstimacionEirReport.ShowChild(ref localReport, this, idReporte, Server.MapPath(string.Empty), ref e);
                    break;

                case "EorsPorEirReport":
                    EorsPorEirReport.Show(ref localReport, this, idReporte, Server.MapPath(string.Empty), ref e);
                    break;

                case "EorCabeceraEstructuraReport":
                    EorCabeceraEstructuraReport.ShowChild(ref localReport, this, idReporte, Server.MapPath(string.Empty), ref e);
                    break;

                case "EorDetalleEstructuraReport":
                    EorDetalleEstructuraReport.Show(ref ReportViewer1, ref localReport, this, idReporte, ref e);
                    break;

                case "EorDetalleMaquinariaReport":
                    EorDetalleMaquinariaReport.Show(ref ReportViewer1, ref localReport, this, idReporte, ref e);
                    break;

                case "EorDetalleTransitoReport":
                    EorDetalleTransitoReport.Show(ref ReportViewer1, ref localReport, this, idReporte, ref e);
                    break;
                case "EorDetalleConsolidadoReport":
                    EorDetalleConsolidadoReport.Show(ref ReportViewer1, ref localReport, this, idReporte, ref e);
                    break;




                default:
                    e.Cancel = true;
                    GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "No existe ningún reporte con el nombre " + "\"" + idReporte + "\"");
                    break;
            }

        }

        public void ReportViewer1DrillthroughEventHandler(object sender, DrillthroughEventArgs e)
        {

            var localReport = (LocalReport)e.Report;

            if (string.IsNullOrEmpty(localReport.ReportPath))
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_INFO, string.Empty, "No se puede visualizar el reporte");
                return;
            }

            var splitPath = localReport.ReportPath.Split('\\');

            var idReporte = splitPath.LastOrDefault().Replace(".rdlc", string.Empty);

            VerReportesHijos(idReporte, localReport, ref e);
        }
    }
}