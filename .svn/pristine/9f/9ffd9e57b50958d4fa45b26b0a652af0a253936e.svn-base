using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Negocio;
using PersistenciaSigeor;
using Negocio.Dashboard;
using Negocio.Utilidades;
using System.Diagnostics;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using PersistenciaSigeor.Utilidades;

namespace Sigeor.ServiciosAsmx
{
    /// <summary>
    /// Summary description for DashboardService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DashboardService : System.Web.Services.WebService
    {
        

        #region SERVICIO PARA GRAFICOS DE COSTOS DE MATERIAL
        [WebMethod]
        public List<DatosGrafico> ObtenerEstimadoLineaPorAnioMaterial(int anio)
        {
            var result = new List<DatosGrafico>();
            try
            {

                var estimadoLineaPorAnioMaterial = DashboardNegocio.ObtenerEstimadoLineaPorAnio(anio);

                var listaAnios = estimadoLineaPorAnioMaterial.Where(ent => ent.ANIO.Value == anio).Select(ent => ent.ANIO).Distinct().ToList();

                var serieEstimado = new DatosGrafico
                {
                    name = "ESTIMADO",
                    data = estimadoLineaPorAnioMaterial.Where(ent => ent.ANIO == anio).Select(ent => ent.TOTAL_ESTIMAT.Value).ToList(),
                    categorias = estimadoLineaPorAnioMaterial.Where(ent => ent.ANIO == anio).Select(ent => ent.NOM_LINEA).Distinct().ToList()
                };

                result.Add(serieEstimado);

                var serieReal = new DatosGrafico
                {
                    name = "REAL",
                    data = estimadoLineaPorAnioMaterial.Where(ent => ent.ANIO == anio).Select(ent => ent.TOTAL_REALMAT.Value).ToList(),
                    categorias = estimadoLineaPorAnioMaterial.Where(ent => ent.ANIO == anio).Select(ent => ent.NOM_LINEA).Distinct().ToList()
                };

                result.Add(serieReal);

                return result;
            }
            catch (Exception ex)
            {
                Log.WriteEntry("DashboardService.ObtenerEstimadoLineaPorAnio: " + ex.Message, EventLogEntryType.Error);
            }
            return result;

        }

        [WebMethod]
        public List<DatosGrafico> ObtenerEstimadoLineaPorAnioMesesMaterial(int anio, string mes)
        {
            var result = new List<DatosGrafico>();
            try
            {
                var estimadoLineaPorAnioMesesMaterial = DashboardNegocio.ObtenerEstimadoLineaPorMeses(anio);

                var listaSeries = new List<DatosGrafico>();
                var listaAnios = estimadoLineaPorAnioMesesMaterial.Where(ent => ent.ANIO.Value == anio).Select(ent => ent.ANIO).Distinct().ToList();
                foreach (var item in listaAnios)
                {
                    var serie = new DatosGrafico
                    {
                        name = "ESTIMADO",
                        data = estimadoLineaPorAnioMesesMaterial.Where(ent => ent.ANIO == item && ent.MES == mes).Select(ent => ent.TOTAL_ESTIMAT.Value).ToList(),
                        categorias = estimadoLineaPorAnioMesesMaterial.Where(ent => ent.ANIO == item && ent.MES == mes).Select(ent => ent.NOM_LINEA).ToList(),
                    };
                    result.Add(serie);

                    serie = new DatosGrafico
                    {
                        name = "REAL",
                        data = estimadoLineaPorAnioMesesMaterial.Where(ent => ent.ANIO == item && ent.MES == mes).Select(ent => ent.TOTAL_REALMAT.Value).ToList(),
                        categorias = estimadoLineaPorAnioMesesMaterial.Where(ent => ent.ANIO == item && ent.MES == mes).Select(ent => ent.NOM_LINEA).ToList(),
                    };
                    result.Add(serie);
                }

            }
            catch (Exception ex)
            {
                Log.WriteEntry("DashboardService.ObtenerEstimadoLineaPorAnioMeses: " + ex.Message, EventLogEntryType.Error);
            }
            return result;

        }

        [WebMethod]
        public List<DatosGrafico> ObtenerConsolidadoLineasPorAnioMaterial(int anio)
        {
            var result = new List<DatosGrafico>();
            try
            {

                var consolidadoLineasPorAnioMaterial = DashboardNegocio.ObtenerEstimadoLineaPorAnio(anio);

                var listaSeries = new List<DatosGrafico>();
                var listaAnios = consolidadoLineasPorAnioMaterial.Where(ent => ent.ANIO.Value == anio).Select(ent => ent.ANIO).Distinct().ToList();
                foreach (var item in listaAnios)
                {
                    var serieEstimado = new DatosGrafico
                    {
                        name = "ESTIMADO",
                        data = new List<decimal> { consolidadoLineasPorAnioMaterial.Where(ent => ent.ANIO == item).Select(ent => ent.TOTAL_ESTIMAT.Value).Sum() },
                        categorias = new List<string> { item.ToString() },
                    };

                    listaSeries.Add(serieEstimado);

                    var serieReal = new DatosGrafico
                    {
                        name = "REAL",
                        data = new List<decimal> { consolidadoLineasPorAnioMaterial.Where(ent => ent.ANIO == item).Select(ent => ent.TOTAL_REALMAT.Value).Sum() },
                        categorias = new List<string> { item.ToString() },
                    };

                    listaSeries.Add(serieReal);
                }
                return listaSeries;
            }
            catch (Exception ex)
            {
                Log.WriteEntry("DashboardService.ObtenerConsolidadoLineasPorAnio: " + ex.Message, EventLogEntryType.Error);
            }
            return result;

        }
        #endregion SERVICIO EPARA GRAFICOS DE COSTOS DE MATERIAL


        #region SERVICIO PARA GRAFICOS DE COSTOS DE MANO DE OBRA
        [WebMethod]
        public List<DatosGrafico> ObtenerEstimadoLineaPorAnioManoObra(int anio)
        {
            var result = new List<DatosGrafico>();
            try
            {
                var estimadoLineaPorAnioManoObra = DashboardNegocio.ObtenerEstimadoLineaPorAnio(anio);
                var listaAnios = estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO.Value == anio).Select(ent => ent.ANIO).Distinct().ToList();

                var serieEstimado = new DatosGrafico
                {
                    name = "ESTIMADO",
                    data = estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO == anio).Select(ent => ent.TOTAL_ESTICOSTOHH.Value).ToList(),
                    categorias = estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO == anio).Select(ent => ent.NOM_LINEA).Distinct().ToList()
                };

                result.Add(serieEstimado);

                var serieReal = new DatosGrafico
                {
                    name = "REAL",
                    data = estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO == anio).Select(ent => ent.TOTAL_REALCOSTOHH.Value).ToList(),
                    categorias = estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO == anio).Select(ent => ent.NOM_LINEA).Distinct().ToList()
                };

                result.Add(serieReal);

                return result;
            }
            catch (Exception ex)
            {
                Log.WriteEntry("DashboardService.ObtenerEstimadoLineaPorAnioManoObra: " + ex.Message, EventLogEntryType.Error);
            }
            return result;

        }

        [WebMethod]

        public List<DatosGrafico> ObtenerEstimadoLineaPorAnioMesesManoObra(int anio, string mes)
        {
            var result = new List<DatosGrafico>();
            try
            {
                var estimadoLineaPorAnioMesesManoObra = DashboardNegocio.ObtenerEstimadoLineaPorMeses(anio);
                var listaSeries = new List<DatosGrafico>();
                var listaAnios = estimadoLineaPorAnioMesesManoObra.Where(ent => ent.ANIO.Value == anio).Select(ent => ent.ANIO).Distinct().ToList();
                foreach (var item in listaAnios)
                {
                    var serie = new DatosGrafico
                    {
                        name = "ESTIMADO",
                        data = estimadoLineaPorAnioMesesManoObra.Where(ent => ent.ANIO == item && ent.MES == mes).Select(ent => ent.TOTAL_ESTICOSTOHH.Value).ToList(),
                        categorias = estimadoLineaPorAnioMesesManoObra.Where(ent => ent.ANIO == item && ent.MES == mes).Select(ent => ent.NOM_LINEA).ToList(),
                    };
                    result.Add(serie);

                    serie = new DatosGrafico
                    {
                        name = "REAL",
                        data = estimadoLineaPorAnioMesesManoObra.Where(ent => ent.ANIO == item && ent.MES == mes).Select(ent => ent.TOTAL_REALCOSTOHH.Value).ToList(),
                        categorias = estimadoLineaPorAnioMesesManoObra.Where(ent => ent.ANIO == item && ent.MES == mes).Select(ent => ent.NOM_LINEA).ToList(),
                    };
                    result.Add(serie);
                }

            }
            catch (Exception ex)
            {
                Log.WriteEntry("DashboardService.ObtenerEstimadoLineaPorAnioMesesManoObra: " + ex.Message, EventLogEntryType.Error);
            }
            return result;

        }

        [WebMethod]
        public List<DatosGrafico> ObtenerConsolidadoLineasPorAnioManoObra(int anio)
        {
            var result = new List<DatosGrafico>();
            try
            {
                var estimadoLineaPorAnioManoObra = DashboardNegocio.ObtenerEstimadoLineaPorAnio(anio);
                var listaSeries = new List<DatosGrafico>();
                var listaAnios = estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO.Value == anio).Select(ent => ent.ANIO).Distinct().ToList();
                foreach (var item in listaAnios)
                {
                    var serieEstimado = new DatosGrafico
                    {
                        name = "ESTIMADO",
                        data = new List<decimal> { estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO == item).Select(ent => ent.TOTAL_ESTICOSTOHH.Value).Sum() },
                        categorias = new List<string> { item.ToString() },
                    };

                    listaSeries.Add(serieEstimado);

                    var serieReal = new DatosGrafico
                    {
                        name = "REAL",
                        data = new List<decimal> { estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO == item).Select(ent => ent.TOTAL_REALCOSTOHH.Value).Sum() },
                        categorias = new List<string> { item.ToString() },
                    };

                    listaSeries.Add(serieReal);
                }
                return listaSeries;
            }
            catch (Exception ex)
            {
                Log.WriteEntry("DashboardService.ObtenerConsolidadoLineasPorAnioManoObra: " + ex.Message, EventLogEntryType.Error);
            }
            return result;

        }

        #endregion SERVICIO EPARA GRAFICOS DE COSTOS DE MANO DE OBRA


        #region SERVICIO PARA GRAFICOS DE COSTOS DE PTI
        [WebMethod]
        public List<DatosGrafico> ObtenerEstimadoLineaPorAnioPti(int anio)
        {
            var result = new List<DatosGrafico>();
            try
            {
                var estimadoLineaPorAnioManoObra = DashboardNegocio.ObtenerEstimadoLineaPorAnio(anio);
                var listaAnios = estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO.Value == anio).Select(ent => ent.ANIO).Distinct().ToList();

                var serieEstimado = new DatosGrafico
                {
                    name = "ESTIMADO",
                    data = estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO == anio).Select(ent => ent.PTI_ESTIMADO.Value).ToList(),
                    categorias = estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO == anio).Select(ent => ent.NOM_LINEA).Distinct().ToList()
                };

                result.Add(serieEstimado);

                var serieReal = new DatosGrafico
                {
                    name = "REAL",
                    data = estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO == anio).Select(ent => ent.PTI_NEGOCIACION.Value).ToList(),
                    categorias = estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO == anio).Select(ent => ent.NOM_LINEA).Distinct().ToList()
                };

                result.Add(serieReal);

                return result;
            }
            catch (Exception ex)
            {
                Log.WriteEntry("DashboardService.ObtenerEstimadoLineaPorAnioPti: " + ex.Message, EventLogEntryType.Error);
            }
            return result;

        }

        [WebMethod]

        public List<DatosGrafico> ObtenerEstimadoLineaPorAnioMesesPti(int anio, string mes)
        {
            var result = new List<DatosGrafico>();
            try
            {
                var estimadoLineaPorAnioMesesManoObra = DashboardNegocio.ObtenerEstimadoLineaPorMeses(anio);
                var listaSeries = new List<DatosGrafico>();
                var listaAnios = estimadoLineaPorAnioMesesManoObra.Where(ent => ent.ANIO.Value == anio).Select(ent => ent.ANIO).Distinct().ToList();
                foreach (var item in listaAnios)
                {
                    var serie = new DatosGrafico
                    {
                        name = "ESTIMADO",
                        data = estimadoLineaPorAnioMesesManoObra.Where(ent => ent.ANIO == item && ent.MES == mes).Select(ent => ent.PTI_ESTIMADO.Value).ToList(),
                        categorias = estimadoLineaPorAnioMesesManoObra.Where(ent => ent.ANIO == item && ent.MES == mes).Select(ent => ent.NOM_LINEA).ToList(),
                    };
                    result.Add(serie);

                    serie = new DatosGrafico
                    {
                        name = "REAL",
                        data = estimadoLineaPorAnioMesesManoObra.Where(ent => ent.ANIO == item && ent.MES == mes).Select(ent => ent.PTI_NEGOCIACION.Value).ToList(),
                        categorias = estimadoLineaPorAnioMesesManoObra.Where(ent => ent.ANIO == item && ent.MES == mes).Select(ent => ent.NOM_LINEA).ToList(),
                    };
                    result.Add(serie);
                }

            }
            catch (Exception ex)
            {
                Log.WriteEntry("DashboardService.ObtenerEstimadoLineaPorAnioMesesPti: " + ex.Message, EventLogEntryType.Error);
            }
            return result;

        }

        [WebMethod]
        public List<DatosGrafico> ObtenerConsolidadoLineasPorAnioPti(int anio)
        {
            var result = new List<DatosGrafico>();
            try
            {
                var estimadoLineaPorAnioManoObra = DashboardNegocio.ObtenerEstimadoLineaPorAnio(anio);
                var listaSeries = new List<DatosGrafico>();
                var listaAnios = estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO.Value == anio).Select(ent => ent.ANIO).Distinct().ToList();
                foreach (var item in listaAnios)
                {
                    var serieEstimado = new DatosGrafico
                    {
                        name = "ESTIMADO",
                        data = new List<decimal> { estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO == item).Select(ent => ent.PTI_ESTIMADO.Value).Sum() },
                        categorias = new List<string> { item.ToString() },
                    };

                    listaSeries.Add(serieEstimado);

                    var serieReal = new DatosGrafico
                    {
                        name = "REAL",
                        data = new List<decimal> { estimadoLineaPorAnioManoObra.Where(ent => ent.ANIO == item).Select(ent => ent.PTI_NEGOCIACION.Value).Sum() },
                        categorias = new List<string> { item.ToString() },
                    };

                    listaSeries.Add(serieReal);
                }
                return listaSeries;
            }
            catch (Exception ex)
            {
                Log.WriteEntry("DashboardService.ObtenerConsolidadoLineasPorAnioPti: " + ex.Message, EventLogEntryType.Error);
            }
            return result;

        }

        #endregion SERVICIO EPARA GRAFICOS DE COSTOS DE PTI


        [WebMethod]
        public DatosGrafico CargarAniosEstimados()
        {
            var result = new DatosGrafico();
            try
            {
                var lista = DashboardNegocio.ObtenerAnioEstimados();

                var ultimoAnio = lista.Select(ent => ent.ANIO).Distinct().LastOrDefault();

                result.data = lista.Select(ent => decimal.Parse(ent.ANIO.Value.ToString())).Distinct().ToList();
            }

            catch (Exception ex)
            {
                Log.WriteEntry("ObtenerDetalleEstimadosLinea Servicio: " + ex.Message, EventLogEntryType.Error);
            }
            return result;
        }

        [WebMethod]
        public DatosGrafico CargarMesesEstimadosPorAnio(int anio)
        {
            var result = new DatosGrafico();
            try
            {
                var lista = DashboardNegocio.ObtenerAnioEstimados();

                result.names = lista.Where(ent => ent.ANIO == anio).Select(ent => ent.MES).ToList();
            }

            catch (Exception ex)
            {
                Log.WriteEntry("ObtenerDetalleEstimadosLinea Servicio: " + ex.Message, EventLogEntryType.Error);
            }
            return result;
        }


    }
}
