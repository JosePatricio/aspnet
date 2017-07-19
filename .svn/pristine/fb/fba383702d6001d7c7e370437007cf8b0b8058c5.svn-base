using System;
using System.Collections.Generic;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using Negocio.Utilidades;
using Sigeor.Utilidades;

namespace Sigeor
{
    public class AdminDashBoardReport
    {
        public partial class DashBoardClass
        {
            public string Id { set; get; }
            public string Nombre { set; get; }
            public string Descripcion { set; get; }
            public decimal Valor { set; get; }


        }

        public static void Show(ref ReportViewer reportViewer, Page page, string idReporte, string serverPath)
        {
            try
            {
                // var valueFiltro = HttpContext.Current.Session[String.Concat(idReporte, "Value")] != null ? HttpContext.Current.Session[String.Concat(idReporte, "Value")].ToString() : String.Empty;
                var listaEor = new List<DashBoardClass>();
                var random = new Random();
                for (var i = 0; i < 30; i++)
                {
                   
                    var valor = random.Next(1000, 10000);
                    listaEor.Add(new DashBoardClass
                    {


                        Id = i.ToString(),
                        Nombre = "EOR00" + i,
                        Descripcion = "Descripcion00" + i,
                        Valor = new decimal(valor)

                    });
                }

                //var cliente = new GestionConfiguracionServiceClient();
                var result = Serializador.SerializeEntity(listaEor);
                if (!String.IsNullOrEmpty(result))
                {
                    var lista = Serializador.DeSerializeEntity<List<DashBoardClass>>(result);
                    var pathReporte = String.Concat(serverPath, "\\", idReporte, ".rdlc");
                    reportViewer.LocalReport.DisplayName = String.Concat(idReporte, "_", DateTime.Now.ToString("yyyyMMdd"));
                    reportViewer.LocalReport.ReportPath = pathReporte;
                    reportViewer.LocalReport.DataSources.Clear();
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource(String.Concat(idReporte, "DataSet"), listaEor));
                    reportViewer.LocalReport.Refresh();
                }
                else
                {
                    GestionUtil.MostrarNotificacion(page, ConstantesUtil.NOTIFICACION_INFO, String.Empty, "No se encontró datos para cargar el reporte");
                }
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(page, ConstantesUtil.NOTIFICACION_ERROR, String.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);

            }
        }
    }
}