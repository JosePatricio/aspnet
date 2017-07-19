using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using Negocio.Reportes;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.Utilidades;
using System.Collections.Generic;

namespace Sigeor
{
    public class EorsPorEirReport
    {
        public static void Show(ref LocalReport localReport, Page page, string idReporte, string serverPath, ref DrillthroughEventArgs e)
        {
            try
            {
                localReport.ReportPath = serverPath + "\\EstimacionEirReport\\EorsPorEirReport.rdlc";

                if (localReport.GetParameters().Any())
                {

                    localReport.DisplayName = string.Concat(idReporte, "_", DateTime.Now.ToString("yyyyMMdd"));

                    var numeroEir = localReport.GetParameters().FirstOrDefault().Values.FirstOrDefault();
                    var param = new ClaseBasica { Descripcion = numeroEir };

                    var listaEorEstructura = ReporteEorEstructuraNegocio.ObtenerEorCabeceraPorFiltros(Serializador.SerializeEntity(param));

                    List<EorPersonalizado> listaEor = new List<EorPersonalizado>();

                    listaEorEstructura.ForEach(item =>
                    {
                        listaEor.Add(new EorPersonalizado
                        {
                            NumeroEor = item.NUM_EOREST,
                            TipoEor = "ESTRUCTURA",
                            TipoContainer = item.COD_TIPCONT,
                            Ciudad = item.NOMBRE_DEPOSITO,
                            Linea = item.NOM_LINEA,
                            FechaAprobacion = item.FECHA_APROBACION,
                            FechaReparacion = item.FECHA_INIREPARA,
                            Aprobado = item.APROBADO,
                            Estado = item.ESTADO,
                            ValorEstimadoHH = item.TOTAL_ESTICOSTOHH,
                            ValorRealHH = item.TOTAL_REALCOSTOHH,
                            ValorEstimadoMaterial = item.TOTAL_ESTIMAT,
                            ValorRealMaterial = item.TOTAL_REALMAT

                        });

                    });

                    var listaEorMaquinaria = ReporteEorMaquinariaNegocio.ObtenerEorCabeceraPorFiltros(Serializador.SerializeEntity(param));

                    listaEorMaquinaria.ForEach(item =>
                    {
                        listaEor.Add(new EorPersonalizado
                        {
                            NumeroEor = item.NUM_EORMAQ,
                            TipoEor = "MAQUINARIA",
                            TipoContainer = item.COD_TIPCONT,
                            Ciudad = item.NOMBRE_DEPOSITO,
                            Linea = item.NOM_LINEA,
                            FechaAprobacion = item.FECHA_APROBACION,
                            FechaReparacion = item.FECHA_INIREPARA,
                            Aprobado = item.APROBADO,
                            Estado = item.ESTADO,
                            //ValorEstimado = item.TOTALMAQ ?? 0,
                            //ValorReal = item.TOTAL_REAL ?? 0

                        });

                    });

                    localReport.DisplayName = string.Concat(idReporte, "_", DateTime.Now.ToString("yyyyMMdd"));

                    localReport.DataSources.Add(new ReportDataSource(string.Concat(idReporte, "DataSet"), listaEor));

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

        public static void ShowChild(ref LocalReport localReport, Page page, string idReporte, string serverPath, ref DrillthroughEventArgs e)
        {


        }

    }
}