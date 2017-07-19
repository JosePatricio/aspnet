using System.Collections.Generic;
using System.ServiceModel;
using PersistenciaSigeor;

namespace SigeorServices.GestionControl
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IControlService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IControlService
    {
        #region INICIO SERVICIO DATOS CREADOS

        [OperationContract]
        string CargarTipoDanios();

        [OperationContract]
        string CargarEstadosNegociaciones();


        #endregion FIN SERVICIO DATOS CREADOS

        #region INICIO GESTIÓN NEGOCIACIONES PARA LINEAS

        [OperationContract]
        void InsertarNegociacionLinea(string negociacionSerializada);

        [OperationContract]
        void ModificarNegociacionLinea(string negociacionSerializada);

        [OperationContract]
        void EliminarNegociacionLinea(string negociacionSerializada);

        [OperationContract]
        string ObtenerNegociacionesLineaPorEstado(bool estado);

        [OperationContract]
        string ObtenerNegociacionesLinea();

        [OperationContract]
        string ObtenerNegociacionesLineaPorCoincidencia(string value, bool estado);

        [OperationContract]
        string ObtenerNegociacionesLineaPorId(string idSerialziado);

        

        [OperationContract]
        void ModificarNegociacionLineaMasivamente(string value, bool estado);

        [OperationContract]
        string ObtenerNegociacionesLineaPorEstadoPaginado(bool estado, int pageSize, int pageIndex,
            out int totalRegistros);

        [OperationContract]
        string ObtenerNegociacionesLineaPaginado(int pageSize, int pageIndex, out int totalRegistros);

        [OperationContract]
        string ObtenerNegociacionesLineaPorCoincidenciaPaginado(string value, bool estado, int pagesize, int pageIndex, out int totalRegistros);


        #endregion FIN GESTIÓN NEGOCIACIONES PARA LINEAS

        #region INICIO DE GESTION DE HISTORICO DE NEGOCIACIONES POR LINEA

        [OperationContract]
        string ObtenerNegociacionesLineaHistoricoPaginado(string parametro, int pagesize, int pageIndex, out int totalRegistros);

        [OperationContract]
        string ObtenerNegociacionesLineaHistorico(string parametro);

        #endregion INICIO DE GESTION DE HISTORICO DE NEGOCIACIONES POR LINEA
        
        #region INICIO DE GESTION DE HISTORICO DE NEGOCIACIONES POR PROVEEDOR

        [OperationContract]
        string ObtenerNegociacionesProveedorHistoricoPaginado(string parametro, int pagesize, int pageIndex, out int totalRegistros);

        [OperationContract]
        string ObtenerNegociacionesProveedorHistorico(string parametro);

        #endregion INICIO DE GESTION DE HISTORICO DE NEGOCIACIONES POR PROVEEDOR
        
        #region INICIO GESTIÓN NEGOCIACIONES PARA PROVEEDORES

        [OperationContract]
        void InsertarNegociacionProveedor(string negociacionSerializada);

        [OperationContract]
        void ModificarNegociacionProveedor(string negociacionSerializada);

        [OperationContract]
        void EliminarNegociacionProveedor(string negociacionSerializada);

        [OperationContract]
        string ObtenerNegociacionesProveedorPorEstado(bool estado);

        [OperationContract]
        string ObtenerNegociacionesProveedor();

        [OperationContract]
        string ObtenerNegociacionesProveedorPorCoincidencia(string value, bool estado);

        [OperationContract]
        string ObtenerNegociacionesProveedorPorId(string idSerialziado);

        [OperationContract]
        void ModificarNegociacionProveedoresMasivamente(string value, bool estado);

        [OperationContract]
        string ObtenerNegociacionesProveedorPorEstadoPaginado(bool estado, int pageSize, int pageIndex,
            out int totalRegistros);

        [OperationContract]
        string ObtenerNegociacionesProveedorPaginado(int pageSize, int pageIndex, out int totalRegistros);

        [OperationContract]
        string ObtenerNegociacionesProveedorPorCoincidenciaPaginado(string value, bool estado, int pagesize, int pageIndex, out int totalRegistros);


        #endregion FIN GESTIÓN NEGOCIACIONES PARA PROVEEDORES
        
        #region INICIO DE GESTION DE DANIOS

        [OperationContract]
        void InsertarDanio(string danioSerializado);
        [OperationContract]
        void ModificarDanio(string danioSerializado);
        [OperationContract]
        void ModificarDanioMasivo(string parametroDanio);
        [OperationContract]
        void EliminarDanio(string danioSerializado);
        [OperationContract]
        string ObtenerDaniosPorEstado(string estado);
        [OperationContract]
        string ObtenerDaniosPorEstadoPaginado(string estado, int pagesize, int pageIndex, out int totalRegistros);
        [OperationContract]
        string ObtenerDanios();
        [OperationContract]
        string ObtenerDanioPorCodigo(string codigo);
        [OperationContract]
        string ObtenerDaniosPorCoincidencia(string value, string estado);
        [OperationContract]
        string ObtenerDaniosPorCoincidenciaPaginado(string value, string estado, int pagesize, int pageIndex, out int totalRegistros);
        [OperationContract]
        string ObtenerDaniosPorLinea(string idLinea, string estado);
        [OperationContract]
        string ObtenerDanioPorIdLineaIdTipoDanio(string clavePrimaria);

        #endregion FIN DE GESTION DE DANIOS
        
        #region INICIO DE GESTION DE REPARACIONES
        [OperationContract]
        void InsertarReparacion(string reparacionSerializado);
        [OperationContract]
        void ModificarReparacion(string reparacionSerializado);

        [OperationContract]
        void ModificarReparacionMasivo(string parametroSerializado);

        [OperationContract]
        void EliminarReparacion(string reparacionSerializado);
        [OperationContract]
        string ObtenerReparacionesPorEstado(string estado);
        [OperationContract]
        string ObtenerReparaciones();
        [OperationContract]
        string ObtenerReparacionPorClave(string clavePrimaria);
        [OperationContract]
        string ObtenerReparacionesPorCoincidencia(string value, string estado);

        [OperationContract]
        string ObtenerReparacionesPorIdLinea(string clavePrimaria);

        [OperationContract]
        string ObtenerReparacionesPorCoincidenciaPaginado(string value, string estado, int pagesize, int pageIndex, out int totalRegistro);


        #endregion FIN DE GESTION DE REPARACIONES
        
        #region INICIO SERVICIO COMPONENTE
        [OperationContract]
        void InsertarComponente(string componenteSerializado);
        [OperationContract]
        void ModificarComponente(string componenteSerializado);
        [OperationContract]
        void EliminarComponente(string componenteSerializado);
        [OperationContract]
        string ObtenerComponentesPorEstado(string estado);

        #endregion FIN SERVICIO COMPONENTE

        #region INICIO DE SERVICIO DE INSPECTORES
        [OperationContract]
        string ObtenerInspectoresPorEstado(string estado);

        #endregion FIN DE SERVICIO DE INSPECTORES


    }
}
