using System.Collections.Generic;
using System.ServiceModel;
using PersistenciaSigeor;

namespace SigeorServices.GestionControl
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IControlService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IControlService
    {
        #region INICIO SERVICIO CONTROL

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


        #region INICIO DE GESTION DE LINEAS

        [OperationContract]
        void InsertarLinea(string lineaSerializada);
        [OperationContract]
        void ModificarLinea(string lineaSerializada);
        [OperationContract]
        void EliminarLinea(string lineaSerializada);
        [OperationContract]
        string ObtenerLineasPorEstado(string estado);
        [OperationContract]
        string ObtenerLineas();
        [OperationContract]
        string ObtenerLineaPorCodigo(string codigo);
        [OperationContract]
        string ObtenerLineasPorCoincidencia(string value, string estado);

        #endregion FIN DE GESTION DE LINEAS


        #region INICIO DE GESTION DE REPARACIONES
        [OperationContract]
        void InsertarReparacion(string reparacionSerializado);
        [OperationContract]
        void ModificarReparacion(string reparacionSerializado);
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

        #endregion FIN DE GESTION DE REPARACIONES


        #region     INICIO DE GESTION DE CATEGORIA1

        [OperationContract]
        void InsertarCategoria1(string categoriaSerializada);

        [OperationContract]
        void ModificarCategoria1(string categoriaSerializada);

        [OperationContract]
        void EliminarCategoria1(string categoriaSerializada);

        [OperationContract]
        string ObtenerCategorias1PorEstado(string estado);

        [OperationContract]
        string ObtenerCategorias1();

        [OperationContract]
        string ObtenerCategoria1PorClave(string clavePrimaria);

        [OperationContract]
        string ObtenerCategorias1PorCoincidencia(string value, string estado);


        #endregion  FIN DE GESTION DE CATEGORIA1


        #region     INICIO DE GESTION DE CATEGORIA2

        [OperationContract]
        void InsertarCategoria2(string categoriaSerializada);

        [OperationContract]
        void ModificarCategoria2(string categoriaSerializada);

        [OperationContract]
        void EliminarCategoria2(string categoriaSerializada);

        [OperationContract]
        string ObtenerCategorias2PorEstado(string estado);

        [OperationContract]
        string ObtenerCategorias2();

        [OperationContract]
        string ObtenerCategoria2PorClave(string clavePrimaria);

        [OperationContract]
        string ObtenerCategorias2PorCoincidencia(string value, string estado);

        [OperationContract]
        string ObtenerCategorias2PorIdCategoria1(string clavePrimaria);

        #endregion  FIN DE GESTION DE CATEGORIA2


        #region     INICIO DE GESTION DE CATEGORIA3
        [OperationContract]
        void InsertarCategoria3(string categoriaSerializada);

        [OperationContract]
        void ModificarCategoria3(string categoriaSerializada);

        [OperationContract]
        void EliminarCategoria3(string categoriaSerializada);

        [OperationContract]
        string ObtenerCategorias3PorEstado(string estado);

        [OperationContract]
        string ObtenerCategorias3();

        [OperationContract]
        string ObtenerCategoria3PorClave(string clavePrimaria);

        [OperationContract]
        string ObtenerCategorias3PorCoincidencia(string value, string estado);

        [OperationContract]
        string ObtenerCategorias3PorIdCat1IdCat2(string clavePrimaria);
        #endregion  FIN DE GESTION DE CATEGORIA3


        #region     INICIO DE GESTION DE PRODUCTOS


        [OperationContract]
        void InsertarProducto(string productoSerializado);

        [OperationContract]
        void ModificarProducto(string productoSerializado);

        [OperationContract]
        void EliminarProducto(string productoSerializado);

        [OperationContract]
        string ObtenerProductosPorEstado(string estado);

        [OperationContract]
        string ObtenerProductos();

        [OperationContract]
        string ObtenerProductoPorClave(string clavePrimaria);

        [OperationContract]
        string ObtenerProductosPorCoincidencia(string value, string estado);

        [OperationContract]
        string ObtenerProductoPorIdCategorias(string clavePrimaria);

        #endregion  FIN DE GESTION DE PRODUCTOS


        #region INICIO SERVICIO DATOS CREADOS

        [OperationContract]
        string CargarTipoDanios();

        #endregion FIN SERVICIO DATOS CREADOS


        #region INICIO SERVICIO COMPONENTE
        [OperationContract]
        void InsertarComponente(string componenteSerializado);
        [OperationContract]
        void ModificarComponente(string componenteSerializado);
        [OperationContract]
        void EliminarComponente(string componenteSerializado);
        [OperationContract]
        string ObtenerComponentesPorEstado(string estado);
        [OperationContract]
        string ObtenerComponentes();
        [OperationContract]
        string ObtenerComponentePorClave(string clavePrimaria);
        [OperationContract]
        string ObtenerProductosPorClaves(string clavePrimaria);
        [OperationContract]
        string ObtenerComponentesPorCoincidencia(string value, string estado);


        #endregion FIN SERVICIO COMPONENTE


        #region INICIO SERVICIO DE DANIOS REPARACION

        [OperationContract]
        void InsertarDanioReparacion(string danioReparacionSerializado);

        [OperationContract]
        void InsertarDanioReparacionListaProductos(string datos, List<Producto> lista);

        [OperationContract]
        void ModificarDanioReparacion(string danioReparacionSerializado);

        [OperationContract]
        void ModificarDanioReparacionMasivo(string parametroSerializado);

        [OperationContract]
        void EliminarDanioReparacion(string danioReparacionSerializado);

        [OperationContract]
        string ObtenerDaniosReparacionesPorCoincidencia(string value, bool estado);

        [OperationContract]
        string ObtenerDaniosReparacionesPorCoincidenciaPaginado(string value, bool estado, int pagesize, int pageIndex,
            out int totalRegistros);

        [OperationContract]
        string ObtenerDaniosReparacionesPorEstado(bool estado);

        [OperationContract]
        string ObtenerDaniosReparacionesPorEstadoPaginado(bool estado, int pagesize, int pageIndex,
            out int totalRegistros);

        [OperationContract]
        string ObtenerDaniosReparaciones();

        [OperationContract]
        string ObtenerDaniosReparacionesPaginado(int pagesize, int pageIndex, out int totalRegistros);

        [OperationContract]
        string ObtenerDanioReparacionPorId(string clavePrimaria);

        [OperationContract]
        string ObtenerDanioReparacionPorClave(string clavePrimaria);

        #endregion INICIO SERVICIO DE DANIOS REPARACION


        #region INICIO SERVICIO DE DANIO REPARACION PRODUCTOS

        [OperationContract]
        void InsertarDanioReparacionProducto(string danioReparacionProductoSerializado);

        [OperationContract]
        void ModificarDanioReparacionProducto(string danioReparacionProductoSerializado);

        [OperationContract]
        string ObtenerDanioReparacionProductoIdDanioReparacionIdProducto(string parametroSerializado);

        [OperationContract]
        string ObtenerDanioReparacionProductoIdDanioReparacion(string parametroSerializado);

        #endregion INICIO SERVICIO DE DANIO REPARACION PRODUCTOS


        #region INICIO GESTIÓN NEGOCIACIONES

        [OperationContract]
        void InsertarNegociacion(string negociacionSerializada);
        [OperationContract]
        void ModificarNegociacion(string negociacionSerializada);
        [OperationContract]
        void EliminarNegociacion(string negociacionSerializada);
        [OperationContract]
        string ObtenerNegociacionesPorEstado(bool estado);
        [OperationContract]
        string ObtenerNegociaciones();
        [OperationContract]
        string ObtenerNegociacionesPorCoincidencia(string value, bool estado);
        [OperationContract]
        string ObtenerNegociacionesPorId(string idSerialziado);
        [OperationContract]
        string ObtenerNegociacionesPorCodigo(string codigo);
        [OperationContract]
        void ModificarMasivamente(string value, bool estado);

        [OperationContract]
        string ObtenerNegociacionesPorEstadoPaginado(bool estado, int pageSize, int pageIndex,
            out int totalRegistros);

        [OperationContract]
        string ObtenerNegociacionesPaginado(int pageSize, int pageIndex, out int totalRegistros);


        [OperationContract]
        string ObtenerNegociacionesPorCoincidenciaPaginado(string value, bool estado, int pagesize, int pageIndex, out int totalRegistros);


        #endregion FIN GESTIÓN NEGOCIACIONES

        [OperationContract]
        string ObtenerEorPorNumero(string numeorEor);

        #endregion FIN SERVICIO CONTROL


    }
}
