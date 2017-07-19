using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SigeorServices.GestionMgl
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IGestionMglService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IGestionMglService
    {
        #region INICIO SERVICIO BUSQUEDA DE EOR'S

        [OperationContract]
        string ObtenerEorEstructuraPorNumero(string parametro);

        //[OperationContract]
        //string ObtenerEorMaquinariaPorNumero(string parametro);

        //[OperationContract]
        //string ObtenerEorTransitoPorNumero(string parametro);

        #endregion FIN SERVICIO BUSQUEDA DE EOR'S

        #region INICIO DE SERVICIO DE REPONSABLE REPARACION

        [OperationContract]
        string ObtenerResponsablesReparaciones();

        #endregion FIN DE SERVICIO DE REPONSABLE REPARACION

        #region INICIO DE SERVICIO DE DEPOSITOS

        [OperationContract]
        string ObtenerDepositos();

        [OperationContract]
        string ObtenerDepositosPorEstado(string estado);

        [OperationContract]
        string ObtenerDespositoPorId(string parametro);

        #endregion FIN DE SERVICIO DE DEPOSITOS

        #region INICIO SERVICIO DE TIPO DE EOR

        //[OperationContract]
        //string ObtenerTiposEorPorEstado(bool estado);

        #endregion FIN SERVICIO DE TIPO DE EOR

        #region INICIO DE SERVICIO GESTION TIPO DE CONTENEDOR
        [OperationContract]
        string ObtenerTipoContenedorPorEstado(string estado);

        [OperationContract]
        string ObtenerTipoContenedorPorTipoEstado(string parametroSerializado);
        #endregion FIN DE SERVICIO GESTION TIPO DE CONTENEDOR


        #region INICIO DE SERVICIO GESTION DE LINEAS

        [OperationContract]
        string ObtenerLineas();

        [OperationContract]
        string ObtenerLineasPorEstado(string estado);

        [OperationContract]
        string ObtenerLineaPorCodigo(string parametro);

        #endregion FIN DE SERVICIO GESTION DE LINEAS



        #region INICIO DE GESTION DE GESTION DE PROVEEDORES

        [OperationContract]
        string ObtenerProveedores();

        [OperationContract]
        string ObtenerProveedoresPorEstado(string estado);

        [OperationContract]
        string ObtenerProveedoresPorEstadoPaginado(bool estado, int pageSize, int pageIndex, out int totalRegistros);

        [OperationContract]
        string ObtenerProveedoresPorCoincidenciaPaginado(string value, bool estado, int pagesize, int pageIndex, out int totalRegistros);
        [OperationContract]
        string ObtenerProveedorPorId(string parametro);


        [OperationContract]
        void InsertarProveedor(string proveedor);

        [OperationContract]
        void ModificarProveedor(string proveedor);

        [OperationContract]
        void EliminarProveedor(string proveedor);

        [OperationContract]
        void ModificarProveedorEstadoMasivamente(string parametroProveedor);

        #endregion FIN DE GESTION DE GESTION DE PROVEEDORES



        #region INICIO DE GESTION DE AGENCIAS

        //[OperationContract]
        //string ObtenerAgencias();

        //[OperationContract]
        //string ObtenerAgenciasPorEstado(string estado);

        //[OperationContract]
        //string ObtenerAgenciaPorCodigo(string parametro);

        #endregion INICIO DE GESTION DE AGENCIAS
    }
}
