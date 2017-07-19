using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SigeorServices.Reportes
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IReportesService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IReportesService
    {
       
        #region INICIO DE SERVICIO DE CABECERA DE EOR POR ESTRUCTURA

        [OperationContract]
        string ObtenerEorCabeceraEstructuraPorFiltrosPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros);

        #endregion FIN DE SERVICIO DE CABECERA DE EOR POR ESTRUCTURA
        
        #region INICIO DE SERVICIO DE CABECERA DE EOR POR MAQUINARIA

        [OperationContract]
        string ObtenerEorCabeceraMaquinariaPorFiltrosPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros);

        #endregion FIN DE SERVICIO DE CABECERA DE EOR POR MAQUINARIA

        #region INICIO DE SERVICIO DE CABECERA DE EOR POR TRANSITO

        [OperationContract]
        string ObtenerEorCabeceraTransitoPorFiltrosPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros);
        #endregion FIN DE SERVICIO DE CABECERA DE EOR POR TRANSITO



        #region INICIO DE SERVICIO CONSOLIDADO EORS
        [OperationContract] 
        string ObtenerConsolidadoEorsPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros);

        #endregion FIN DE SERVICIO CONSOLIDADO EORS

        #region SERVICIO REPORTE EIR ESTRUCTURA
        [OperationContract]
        string ObtenerDatosEirEstructuraPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros);
        #endregion SERVICIO REPORTE EIR ESTRUCTURA
        
        #region SERVICIO REPORTE EIR MAQUINARIA
        [OperationContract]
        string ObtenerDatosEirMaquinariaPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros);
        #endregion SERVICIO REPORTE EIR MAQUINARIA

        #region SERVICIO REPORTE ESTIMACION EIR 
        [OperationContract]
        string ObtenerDatosEstimacionEirPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros);
        #endregion SERVICIO REPORTE ESTIMACION EIR 

        #region SERVICIO REPORTE PTI
        [OperationContract]
        string ObtenerDatosPTIPaginado(string parametros, int pagesize, int pageIndex, out int totalRegistros);
        #endregion SERVICIO REPORTE PTI
        
        #region SERVICIO REPORTES DASHBOARD
        //[OperationContract]
        //string obtenerTotalesEorEstructuraTodosEstimado();

        //[OperationContract]
        //string obtenerTotalesEorEstructuraPorAnioEstimado(string year);

        //[OperationContract]
        //string obtenerTotalesEorEstructuraTodosReal();

        //[OperationContract]
        //string obtenerTotalesEorEstructuraRealPorAnio(string year);




        //[OperationContract]
        //string obtenerTotalesEorMaquinariaTodosEstimado();

        //[OperationContract]
        //string obtenerTotalesEorMaquinariaPorAnioEstimado(string year);

        //[OperationContract]
        //string obtenerTotalesEorMaquinariaTodosReal();

        //[OperationContract]
        //string obtenerTotalesEorMaquinariaRealPorAnio(string year);




        //[OperationContract]
        //string obtenerTotalesEorTransitoTodosEstimado();

        //[OperationContract]
        //string obtenerTotalesEorTransitoPorAnioEstimado(string year);

        //[OperationContract]
        //string obtenerTotalesEorTransitoTodosReal();

        //[OperationContract]
        //string obtenerTotalesEorTransitoRealPorAnio(string year);










        ////Reportes Estimado real Por Linea

        //[OperationContract]
        //string obtenerTotalesEorEstructuraTodosEstimadoPorLinea(string linea);

        //[OperationContract]
        //string obtenerTotalesEorEstructuraPorAnioEstimadoPorLinea(string year, string linea);

        //[OperationContract]
        //string obtenerTotalesEorEstructuraTodosRealPorLinea(string linea);

        //[OperationContract]
        //string obtenerTotalesEorEstructuraRealPorAnioPorLinea(string year, string linea);




        //[OperationContract]
        //string obtenerTotalesEorMaquinariaTodosEstimadoPorLinea(string linea);

        //[OperationContract]
        //string obtenerTotalesEorMaquinariaPorAnioEstimadoPorLinea(string year, string linea);

        //[OperationContract]
        //string obtenerTotalesEorMaquinariaTodosRealPorLinea(string linea);

        //[OperationContract]
        //string obtenerTotalesEorMaquinariaRealPorAnioPorLinea(string year, string linea);




        //[OperationContract]
        //string obtenerTotalesEorTransitoTodosEstimadoPorLinea(string linea);

        //[OperationContract]
        //string obtenerTotalesEorTransitoPorAnioEstimadoPorLinea(string year, string linea);

        //[OperationContract]
        //string obtenerTotalesEorTransitoTodosRealPorLinea(string linea);

        //[OperationContract]
        //string obtenerTotalesEorTransitoRealPorAnioPorLinea(string year, string linea);





        #endregion SERVICIO REPORTES DASHBOARD
        
        #region SERVICIO REPORTE EIR ESTRUCTURA RDLC
        [OperationContract]
        string ObtenerDatosEirEstructuraReporte(string parametros);
        #endregion SERVICIO REPORTES ESTRUCTURA RDLC

        #region SERVICIO REPORTE EIR MAQUINARIA RDLC
        [OperationContract]
        string ObtenerDatosEirMaquinariaReporte(string parametros);
        #endregion SERVICIO REPORTES MAQUINARIA RDLC

        #region SERVICIO REPORTE ESTIMACIONES EIR RDLC
        [OperationContract]
        string ObtenerDatosEstimacionEirReporte(string parametros);
        #endregion SERVICIO REPORTE ESTIMACIONES EIR RDLC

        #region SERVICIO REPORTE PTI  RDLC
        [OperationContract]
        string ObtenerDatosPTIReporte(string parametros);
        #endregion SERVICIO REPORTES MAQUINARIA RDLC

        #region SERVICIO REPORTE PTI-EIR  RDLC
        [OperationContract]
        string ObtenerDatosPTI_EIR_Reporte(string parametros);
        #endregion SERVICIO REPORTE PTI-EIR  RDLC

        #region INICIO SERVICIO PARA CARGAR ESTADOS 

        [OperationContract]
        string ObtenerEstadosEorEstructuraMaquinaria();

        [OperationContract]
        string CargarTipoAlertas();

        #endregion FIN SERVICIO PARA CARGAR ESTADOS 
        
        #region INICIO DEL SERVICIO PARA FABRICANTES

        [OperationContract]
        string ObtenerFabricantesPorEstado(string parametro);

        #endregion FIN DEL SERVICIO PARA FABRICANTES
    }
}
