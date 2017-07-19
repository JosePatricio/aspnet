using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Negocio.Aretina;
using Negocio.Reportes;
using Negocio.Utilidades;

namespace SigeorServices.Reportes
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ReportesService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ReportesService.svc o ReportesService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ReportesService : IReportesService
    {
       

        #region INICIO DE SERVICIO DE CABECERA DE EOR POR ESTRUCTURA

        public string ObtenerEorCabeceraEstructuraPorFiltrosPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros)
        {
            return ReporteEorEstructuraNegocio.ObtenerEorCabeceraPorFiltrosPaginado(parametros, pagesize, pageIndex, out totalRegistros);
        }

        #endregion INICIO DE SERVICIO DE CABECERA DE EOR POR ESTRUCTURA

        #region INICIO DE SERVICIO DE CABECERA DE EOR POR MAQUINARIA

        public string ObtenerEorCabeceraMaquinariaPorFiltrosPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros)
        {
            return ReporteEorMaquinariaNegocio.ObtenerEorCabeceraPorFiltrosPaginado(parametros, pagesize, pageIndex, out totalRegistros);
        }

        #endregion INICIO DE SERVICIO DE CABECERA DE EOR POR MAQUINARIA


        #region INICIO DE SERVICIO DE CABECERA DE EOR POR TRANSITO

        public string ObtenerEorCabeceraTransitoPorFiltrosPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros)
        {
            return ReporteEorTransitoNegocio.ObtenerEorCabeceraPorFiltrosPaginado(parametros, pagesize, pageIndex, out totalRegistros);
        }

        #endregion INICIO DE SERVICIO DE CABECERA DE EOR POR TRANSITO

        #region SERVICIO REPORTE EIR ESTRUCTURA
        public string ObtenerDatosEirEstructuraPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros)
        {
            return ReportesEIR.ObtenerDatosEirEstructuraPaginados(parametros, pagesize, pageIndex, out totalRegistros);
        }
        #endregion SERVICIO REPORTE EIR ESTRUCTURA

        #region SERVICIO REPORTE ESTIMACION EIR 
        public string ObtenerDatosEstimacionEirPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros)
        {
            return ReportesEIR.ObtenerDatosEstimacionEirPaginados(parametros, pagesize, pageIndex, out totalRegistros);
        }
        #endregion SERVICIO REPORTE ESTIMACION EIR 

        #region SERVICIO REPORTE EIR MAQUINARIA
        public string ObtenerDatosEirMaquinariaPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros)
        {
            return ReportesEIR.ObtenerDatosEirMaquinariaPaginado(parametros, pagesize, pageIndex, out totalRegistros);
        }
        #endregion SERVICIO REPORTE EIR MAQUINARIA

        #region INICIO DE SERVICIO CONSOLIDADO EORS
        public string ObtenerConsolidadoEorsPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros)
        {
            return ReporteConsolidadoNegocio.ObtenerConsolidadoEorsPaginado(parametros, pagesize, pageIndex, out totalRegistros);
        }

        #endregion FIN DE SERVICIO CONSOLIDADO EORS

        #region SERVICIO REPORTE PTI
        public string ObtenerDatosPTIPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros)
        {
            return ReportesPTI.ObtenerDatosPTIPaginado(parametros, pagesize, pageIndex, out totalRegistros);
        }
        #endregion SERVICIO REPORTE PTI

        #region SERVICIO REPORTES DASHBOARD
        //public string obtenerTotalesEorEstructuraTodosEstimado()
        //{
        //    return ReportesGraficos.obtenerTotalesEorEstructuraTodosEstimado();
        //}

        //public string obtenerTotalesEorEstructuraPorAnioEstimado(string year)
        //{
        //    return ReportesGraficos.obtenerTotalesEorEstructuraPorAnioEstimado(year);
        //}

        //public string obtenerTotalesEorEstructuraTodosReal()
        //{
        //    return ReportesGraficos.obtenerTotalesEorEstructuraTodosReal();
        //}
        //public string obtenerTotalesEorEstructuraRealPorAnio(string year)
        //{
        //    return ReportesGraficos.obtenerTotalesEorEstructuraRealPorAnio(year);
        //}



        //public string obtenerTotalesEorMaquinariaTodosEstimado()
        //{
        //    return ReportesGraficos.obtenerTotalesEorMaquinariaTodosEstimado();
        //}

        //public string obtenerTotalesEorMaquinariaPorAnioEstimado(string year)
        //{
        //    return ReportesGraficos.obtenerTotalesEorMaquinariaPorAnioEstimado(year);
        //}

        //public string obtenerTotalesEorMaquinariaTodosReal()
        //{
        //    return ReportesGraficos.obtenerTotalesEorMaquinariaTodosReal();
        //}

        //public string obtenerTotalesEorMaquinariaRealPorAnio(string year)
        //{
        //    return ReportesGraficos.obtenerTotalesEorMaquinariaRealPorAnio(year);
        //}

        //public string obtenerTotalesEorTransitoTodosEstimado()
        //{
        //    return ReportesGraficos.obtenerTotalesEorTransitoTodosEstimado();
        //}

        //public string obtenerTotalesEorTransitoPorAnioEstimado(string year)
        //{
        //    return ReportesGraficos.obtenerTotalesEorTransitoPorAnioEstimado(year);
        //}

        //public string obtenerTotalesEorTransitoTodosReal()
        //{
        //    return ReportesGraficos.obtenerTotalesEorTransitoTodosReal();
        //}

        //public string obtenerTotalesEorTransitoRealPorAnio(string year)
        //{
        //    return ReportesGraficos.obtenerTotalesEorTransitoRealPorAnio(year);
        //}


        //Reportes Estimados - Real Por Linea

        //public string obtenerTotalesEorEstructuraTodosEstimadoPorLinea(string linea)
        //{
        //    return ReportesGraficos.obtenerTotalesEorEstructuraTodosEstimadoPorLinea(linea);
        //}

        //public string obtenerTotalesEorEstructuraPorAnioEstimadoPorLinea(string year, string linea)
        //{
        //    return ReportesGraficos.obtenerTotalesEorEstructuraPorAnioEstimadoPorLinea(year, linea);
        //}

        //public string obtenerTotalesEorEstructuraTodosRealPorLinea(string linea)
        //{
        //    return ReportesGraficos.obtenerTotalesEorEstructuraTodosRealPorLinea(linea);
        //}

        //public string obtenerTotalesEorEstructuraRealPorAnioPorLinea(string year, string linea)
        //{
        //    return ReportesGraficos.obtenerTotalesEorEstructuraRealPorAnioPorLinea(year, linea);
        //}

        //public string obtenerTotalesEorMaquinariaTodosEstimadoPorLinea(string linea)
        //{
        //    return ReportesGraficos.obtenerTotalesEorMaquinariaTodosEstimadoPorLinea(linea);
        //}

        //public string obtenerTotalesEorMaquinariaPorAnioEstimadoPorLinea(string year, string linea)
        //{
        //    return ReportesGraficos.obtenerTotalesEorMaquinariaPorAnioEstimadoPorLinea(year, linea);
        //}

        //public string obtenerTotalesEorMaquinariaTodosRealPorLinea(string linea)
        //{
        //    return ReportesGraficos.obtenerTotalesEorMaquinariaTodosRealPorLinea(linea);
        //}

        //public string obtenerTotalesEorMaquinariaRealPorAnioPorLinea(string year, string linea)
        //{
        //    return ReportesGraficos.obtenerTotalesEorMaquinariaRealPorAnioPorLinea(year, linea);
        //}

        //public string obtenerTotalesEorTransitoTodosEstimadoPorLinea(string linea)
        //{
        //    return ReportesGraficos.obtenerTotalesEorTransitoTodosEstimadoPorLinea(linea);
        //}

        //public string obtenerTotalesEorTransitoPorAnioEstimadoPorLinea(string year, string linea)
        //{
        //    return ReportesGraficos.obtenerTotalesEorTransitoPorAnioEstimadoPorLinea(year, linea);
        //}

        //public string obtenerTotalesEorTransitoTodosRealPorLinea(string linea)
        //{
        //    return ReportesGraficos.obtenerTotalesEorTransitoTodosRealPorLinea(linea);
        //}

        //public string obtenerTotalesEorTransitoRealPorAnioPorLinea(string year, string linea)
        //{
        //    return ReportesGraficos.obtenerTotalesEorTransitoRealPorAnioPorLinea(year, linea);
        //}

        #endregion SERVICIO REPORTE DASHBOARD

        #region SERVICIO REPORTE EIR ESTRUCTURA RDLC
        public string ObtenerDatosEirEstructuraReporte(string parametros)
        {
            return ReportesEIR.ObtenerDatosEirEstructuraReporte(parametros);
        }
        #endregion SERVICIO REPORTES ESTRUCTURA RDLC

        #region SERVICIO REPORTE EIR MAQUINARIA RDLC
        public string ObtenerDatosEirMaquinariaReporte(string parametros)
        {
            return ReportesEIR.ObtenerDatosEirMaquinariaReporte(parametros);
        }
        #endregion SERVICIO REPORTES MAQUINARIA RDLC

        #region SERVICIO REPORTE ESTIMACION EIR RDLC
        public string ObtenerDatosEstimacionEirReporte(string parametros)
        {
            return ReportesEIR.ObtenerDatosEstimacionEirReporte(parametros);
        }
        #endregion SERVICIO REPORTE ESTIMACION EIR RDLC

        #region SERVICIO REPORTE PTI  RDLC
        public string ObtenerDatosPTIReporte(string parametros)
        {
            return ReportesPTI.ObtenerDatosPTIReporte(parametros);
        }
        #endregion SERVICIO REPORTES MAQUINARIA RDLC

        #region SERVICIO REPORTE PTIEIR  RDLC
        public string ObtenerDatosPTI_EIR_Reporte(string parametros)
        {
            return ReportesPTI.ObtenerDatosPTI_EIR_Reporte(parametros);
        }
        #endregion SERVICIO REPORTES MAQUINARIA RDLC

        #region INICIO SERVICIO PARA CARGAR ESTADOS DE EOR


        public string ObtenerEstadosEorEstructuraMaquinaria()
        {
            return DatosCreados.ObtenerEstadosEorEstructuraMaquinaria();
        }

        public string CargarTipoAlertas()
        {
            return DatosCreados.CargarTipoAlertas();
        }

        #endregion FIN SERVICIO PARA CARGAR ESTADOS DE EOR

        #region INICIO DEL SERVICIO PARA FABRICANTES

        public string ObtenerFabricantesPorEstado(string parametro)
        {
            return FabricanteNegocio.ObtenerFabricantesPorEstado(parametro);
        }

        #endregion FIN DEL SERVICIO PARA FABRICANTES

    }
}
