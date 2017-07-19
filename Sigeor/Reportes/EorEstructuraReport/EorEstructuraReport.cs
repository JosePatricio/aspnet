using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using PersistenciaSigeor;
using Sigeor.Utilidades;

namespace Sigeor
{
    public class EorEstructuraReport
    {
        public static void Show(ref ReportViewer reportViewer, Page page, string idReporte, string serverPath)
        {

            try
            {
            
                var eorSession = HttpContext.Current.Session[idReporte];

                var total = HttpContext.Current.Session[string.Concat("Total", idReporte)];

                if (eorSession != null && total != null)
                {
                    var auxEor = (AretinaEor)eorSession;

                    var count = 0;

                    var eor = new ReporteEstimadoEor
                    {
                        DetalleEor = new List<DetalleEor>()
                    };
                    foreach (var detalleEor in auxEor.DetalleEstructura.Select(item => new DetalleEor
                    {
                        Sec = ++count,
                        Loc = item.UBICA1 + item.UBICA2 + item.UBICA3 + item.UBICA4,
                        Qty = item.CANTIDAD ?? 0,
                        Comp = item.COD_ESTIMACOMPO,
                        Repair = item.COD_REPAIR,
                        Length = item.LONGITUD ?? new decimal(0),
                        Width = item.ANCHO ?? new decimal(0),
                        Damage = item.COD_DAMAGE,
                        Resp = item.COD_PARTY,
                        Hour = item.HORAS ?? new decimal(0),
                        LaborCost = item.COSTOMAOBRA ?? new decimal(0),
                        MaterialCost = item.COSTOMATERIAL ?? new decimal(0),
                        TotalMaterialCost = item.TOTALCOSTOMAT ?? new decimal(0),
                        SubTotal = item.TOTAL ?? new decimal(0),
                        Descripcion = item.DETAREPARACION
                    }))
                    {
                        eor.DetalleEor.Add(detalleEor);
                    }

                    var pathReporte = string.Concat(serverPath, "\\", idReporte, ".rdlc");
                    reportViewer.LocalReport.ReportPath = pathReporte;
                    reportViewer.LocalReport.DisplayName = string.Concat(idReporte, "_", DateTime.Now.ToString("yyyyMMdd"));
                    reportViewer.LocalReport.SetParameters(new ReportParameter("EorNumberParam", auxEor.CabeceraEstructura.NUM_EOREST));
                    reportViewer.LocalReport.SetParameters(new ReportParameter("LineParam", auxEor.CabeceraEstructura.DetalleEorEstructura.FirstOrDefault().Linea.NOM_LINEA));
                    reportViewer.LocalReport.SetParameters(new ReportParameter("ContainerParam", auxEor.CabeceraEstructura.PREF_CONTAINER + auxEor.CabeceraEstructura.NUM_CONTAINER));
                    reportViewer.LocalReport.SetParameters(new ReportParameter("TypeParam", auxEor.CabeceraEstructura.CampoEir.COD_TIPCONT));
                    reportViewer.LocalReport.SetParameters(new ReportParameter("LocationParam", auxEor.CabeceraEstructura.CampoDeposito.NOMBRE_DEPOSITO));
                    var estado = auxEor.CabeceraEstructura.ESTADO;
                    var nombreEstado = estado.Equals("D") ? "DAMAGE" : estado.Equals("R") ? "REPAIR" : estado.Equals("A") ? "AUTORIZADO" : string.Empty;
                    reportViewer.LocalReport.SetParameters(new ReportParameter("BoxParam", nombreEstado));
                    reportViewer.LocalReport.SetParameters(new ReportParameter("MachineryParam", string.Empty));
                    reportViewer.LocalReport.SetParameters(new ReportParameter("LaborRateBoxParam", auxEor.CabeceraEstructura.DetalleEorEstructura.FirstOrDefault().COSTOMAOBRA.ToString()));
                    reportViewer.LocalReport.SetParameters(new ReportParameter("LaborRateMacParam", string.Empty));
                    reportViewer.LocalReport.SetParameters(new ReportParameter("DateEstimateBoxParam", auxEor.CabeceraEstructura.FECHA_EOR.Value.ToString("dd/MMM/yyyy")));
                    reportViewer.LocalReport.SetParameters(new ReportParameter("DateEstimateMacParam", string.Empty));
                    reportViewer.LocalReport.SetParameters(new ReportParameter("DateEirParam", auxEor.CabeceraEstructura.CampoEir.FECHA_EIR.ToString("dd/MMM/yyyy")));
                    reportViewer.LocalReport.SetParameters(new ReportParameter("NumEirParam", auxEor.CabeceraEstructura.ID_EIR));

                    reportViewer.LocalReport.DataSources.Clear();
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource(string.Concat(idReporte, "DataSet"), eor.DetalleEor));
                    reportViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
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

        private static void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            try
            {
                var total =          (List<CalculoSubTotalEor>)
                        HttpContext.Current.Session[string.Concat("Total", "EorEstructuraReport")];

                //HttpContext.Current.Session.Remove("EorEstructuraReport");
                //HttpContext.Current.Session.Remove("TotalEorEstructuraReport");

                if (total != null)
                {
                    //Eliminamos el objeto que contiene el total de la lista.
                    //Por motivos de diseño del reporte y lo calculamos en el mismo reporte.
                    total.RemoveAll(ent =>
                    {
                        var calculoSubTotalEor = total.LastOrDefault();
                        return calculoSubTotalEor != null && ent.Nombre.Equals(calculoSubTotalEor.Nombre);
                    });

                    e.DataSources.Add(new ReportDataSource(string.Concat("EorEstructuraReport", "DataSet"), total));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar los totales del reporte EOR por Estructura: " + ex.Message);
            }
        }
    }
}