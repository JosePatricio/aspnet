using System.Collections.Generic;
using Negocio.GestionControl;
using Negocio.Utilidades;
using PersistenciaSigeor;

namespace SigeorServices.GestionControl
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ControlService" en el código, en svc y en el archivo de configuración a la vez.
    public class ControlService : IControlService
    {
        #region INICIO DE SERVICIO DE CONTROL

        #region INICIO DE SERVICIO DE DANIOS

        public void InsertarDanio(string danioSerializado)
        {
            DanioNegocio.Insertar(danioSerializado);
        }

        public void ModificarDanio(string danioSerializado)
        {
            DanioNegocio.Modificar(danioSerializado);
        }

        public void ModificarDanioMasivo(string parametroDanio)
        {
            DanioNegocio.ModificarDanioMasivo(parametroDanio);
        }

        public void EliminarDanio(string danioSerializado)
        {
            DanioNegocio.Eliminar(danioSerializado);
        }

        public string ObtenerDaniosPorEstado(string estado)
        {
            return DanioNegocio.ObtenerDaniosPorEstado(estado);
        }

        public string ObtenerDaniosPorEstadoPaginado(string estado, int pagesize, int pageIndex, out int totalRegistros)
        {
            return DanioNegocio.ObtenerDaniosPorEstadoPaginado(estado, pagesize, pageIndex, out totalRegistros);
        }

        public string ObtenerDanios()
        {
            return DanioNegocio.ObtenerDanios();
        }

        public string ObtenerDanioPorCodigo(string codigo)
        {
            return DanioNegocio.ObtenerDanioPorCodigo(codigo);
        }

        public string ObtenerDaniosPorCoincidencia(string value, string estado)
        {
            return DanioNegocio.ObtenerDaniosPorCoincidencia(value, estado);
        }

        public string ObtenerDaniosPorCoincidenciaPaginado(string value, string estado, int pagesize, int pageIndex, out int totalRegistros)
        {
            return DanioNegocio.ObtenerDaniosPorCoincidenciaPaginado(value, estado, pagesize, pageIndex, out totalRegistros);
        }

        public string ObtenerDaniosPorLinea(string idLinea, string estado)
        {
            return DanioNegocio.ObtenerDaniosPorLinea(idLinea, estado);
        }

        public string ObtenerDanioPorIdLineaIdTipoDanio(string clavePrimaria)
        {
            return DanioNegocio.ObtenerDanioPorIdLineaIdTipoDanio(clavePrimaria);
        }

        #endregion FIN DE SERVICIO DE DANIOS


        #region INICIO DE SERVICIO DE GESTION DE LINEAS
        public void InsertarLinea(string lineaSerializada)
        {
            LineaNegocio.Insertar(lineaSerializada);
        }

        public void ModificarLinea(string lineaSerializada)
        {
            LineaNegocio.Modificar(lineaSerializada);
        }

        public void EliminarLinea(string lineaSerializada)
        {
            LineaNegocio.Eliminar(lineaSerializada);
        }

        public string ObtenerLineasPorEstado(string estado)
        {
            return LineaNegocio.ObtenerLineasPorEstado(estado);
        }

        public string ObtenerLineas()
        {
            return LineaNegocio.ObtenerLineas();
        }

        public string ObtenerLineaPorCodigo(string codigo)
        {
            return LineaNegocio.ObtenerLineaPorCodigo(codigo);
        }

        public string ObtenerLineasPorCoincidencia(string value, string estado)
        {
            return LineaNegocio.ObtenerLineasPorCoincidencia(value, estado);
        }
        #endregion FIN DE SERVICIO DE GESTION DE LINEAS


        #region INICIO DE GESTION DE REPARACIONES

        public void InsertarReparacion(string reparacionSerializado)
        {
            ReparacionNegocio.Insertar(reparacionSerializado);
        }

        public void ModificarReparacion(string reparacionSerializado)
        {
            ReparacionNegocio.Modificar(reparacionSerializado);
        }

        public void EliminarReparacion(string reparacionSerializado)
        {
            ReparacionNegocio.Eliminar(reparacionSerializado);
        }

        public string ObtenerReparacionesPorEstado(string estado)
        {
            return ReparacionNegocio.ObtenerReparacionesPorEstado(estado);
        }

        public string ObtenerReparaciones()
        {
            return ReparacionNegocio.ObtenerReparaciones();
        }

        public string ObtenerReparacionPorClave(string clavePrimaria)
        {
            return ReparacionNegocio.ObtenerReparacionPorClave(clavePrimaria);
        }

        public string ObtenerReparacionesPorCoincidencia(string value, string estado)
        {
            return ReparacionNegocio.ObtenerReparacionesPorCoincidencia(value, estado);
        }

        public string ObtenerReparacionesPorIdLinea(string clavePrimaria)
        {
            return ReparacionNegocio.ObtenerReparacionesPorIdLinea(clavePrimaria);
        }

        #endregion FIN DE GESTION DE REPARACIONES


        #region     INICIO DE GESTION DE CATEGORIA1

        public void InsertarCategoria1(string categoriaSerializada)
        {
            Categoria1Negocio.Insertar(categoriaSerializada);
        }

        public void ModificarCategoria1(string categoriaSerializada)
        {
            Categoria1Negocio.Modificar(categoriaSerializada);
        }

        public void EliminarCategoria1(string categoriaSerializada)
        {
            Categoria1Negocio.Eliminar(categoriaSerializada);
        }

        public string ObtenerCategorias1PorEstado(string estado)
        {
            return Categoria1Negocio.ObtenerCategorias1PorEstado(estado);
        }

        public string ObtenerCategorias1()
        {
            return Categoria1Negocio.ObtenerCategorias1();
        }

        public string ObtenerCategoria1PorClave(string clavePrimaria)
        {
            return Categoria1Negocio.ObtenerCategoria1PorClave(clavePrimaria);
        }

        public string ObtenerCategorias1PorCoincidencia(string value, string estado)
        {
            return Categoria1Negocio.ObtenerCategorias1PorCoincidencia(value, estado);
        }

        #endregion  FIN DE GESTION DE CATEGORIA1


        #region     INICIO DE GESTION DE CATEGORIA2

        public void InsertarCategoria2(string categoriaSerializada)
        {
            Categoria2Negocio.Insertar(categoriaSerializada);
        }

        public void ModificarCategoria2(string categoriaSerializada)
        {
            Categoria2Negocio.Modificar(categoriaSerializada);
        }

        public void EliminarCategoria2(string categoriaSerializada)
        {
            Categoria2Negocio.Eliminar(categoriaSerializada);
        }

        public string ObtenerCategorias2PorEstado(string estado)
        {
            return Categoria2Negocio.ObtenerCategorias2PorEstado(estado);
        }

        public string ObtenerCategorias2()
        {
            return Categoria2Negocio.ObtenerCategorias2();
        }

        public string ObtenerCategoria2PorClave(string clavePrimaria)
        {
            return Categoria2Negocio.ObtenerCategoria2PorClave(clavePrimaria);
        }

        public string ObtenerCategorias2PorCoincidencia(string value, string estado)
        {
            return Categoria2Negocio.ObtenerCategorias2PorCoincidencia(value, estado);
        }

        public string ObtenerCategorias2PorIdCategoria1(string clavePrimaria)
        {
            return Categoria2Negocio.ObtenerCategorias2PorIdCategoria1(clavePrimaria);
        }

        #endregion  FIN DE GESTION DE CATEGORIA2


        #region     INICIO DE GESTION DE CATEGORIA3

        public void InsertarCategoria3(string categoriaSerializada)
        {
            Categoria3Negocio.Insertar(categoriaSerializada);
        }

        public void ModificarCategoria3(string categoriaSerializada)
        {
            Categoria3Negocio.Modificar(categoriaSerializada);
        }

        public void EliminarCategoria3(string categoriaSerializada)
        {
            Categoria3Negocio.Eliminar(categoriaSerializada);
        }

        public string ObtenerCategorias3PorEstado(string estado)
        {
            return Categoria3Negocio.ObtenerCategorias3PorEstado(estado);
        }

        public string ObtenerCategorias3()
        {
            return Categoria3Negocio.ObtenerCategorias3();
        }

        public string ObtenerCategoria3PorClave(string clavePrimaria)
        {
            return Categoria3Negocio.ObtenerCategoria3PorClave(clavePrimaria);
        }

        public string ObtenerCategorias3PorCoincidencia(string value, string estado)
        {
            return Categoria3Negocio.ObtenerCategorias3PorCoincidencia(value, estado);
        }

        public string ObtenerCategorias3PorIdCat1IdCat2(string clavePrimaria)
        {
            return Categoria3Negocio.ObtenerCategorias3PorIdCat1IdCat2(clavePrimaria);
        }

        #endregion  FIN DE GESTION DE CATEGORIA3


        #region     INICIO DE GESTION DE PRODUCTOS


        public void InsertarProducto(string productoSerializado)
        {
            ProductoNegocio.Insertar(productoSerializado);
        }

        public void ModificarProducto(string productoSerializado)
        {
            ProductoNegocio.Modificar(productoSerializado);
        }

        public void EliminarProducto(string productoSerializado)
        {
            ProductoNegocio.Eliminar(productoSerializado);
        }

        public string ObtenerProductosPorEstado(string estado)
        {
            return ProductoNegocio.ObtenerProductosPorEstado(estado);
        }

        public string ObtenerProductos()
        {
            return ProductoNegocio.ObtenerProductos();
        }

        public string ObtenerProductoPorClave(string clavePrimaria)
        {
            return ProductoNegocio.ObtenerProductoPorClave(clavePrimaria);
        }

        public string ObtenerProductosPorClaves(string clavePrimaria)
        {
            return ProductoNegocio.ObtenerProductosPorClaves(clavePrimaria);
        }

        public string ObtenerProductosPorCoincidencia(string value, string estado)
        {
            return ProductoNegocio.ObtenerProductosPorCoincidencia(value, estado);
        }

        public string ObtenerProductoPorIdCategorias(string clavePrimaria)
        {
            return ProductoNegocio.ObtenerProductoPorIdCategorias(clavePrimaria);
        }


        #endregion  FIN DE GESTION DE PRODUCTOS


        #region INICIO SERVICIO DATOS CREADOS
        public string CargarTipoDanios()
        {
            return DatosCreados.CargarTipoDanios();
        }
        #endregion INICIO SERVICIO DATOS CREADOS


        #region INICIO SERVICIO COMPONENTE

        public void InsertarComponente(string componenteSerializado)
        {
            ComponenteNegocio.Insertar(componenteSerializado);
        }

        public void ModificarComponente(string componenteSerializado)
        {
            ComponenteNegocio.Modificar(componenteSerializado);
        }

        public void EliminarComponente(string componenteSerializado)
        {
            ComponenteNegocio.Eliminar(componenteSerializado);
        }

        public string ObtenerComponentesPorEstado(string estado)
        {
            return ComponenteNegocio.ObtenerComponentesPorEstado(estado);
        }

        public string ObtenerComponentes()
        {
            return ComponenteNegocio.ObtenerComponentes();
        }

        public string ObtenerComponentePorClave(string clavePrimaria)
        {
            return ComponenteNegocio.ObtenerComponentePorClave(clavePrimaria);
        }

        public string ObtenerComponentesPorCoincidencia(string value, string estado)
        {
            return ComponenteNegocio.ObtenerComponentesPorCoincidencia(value, estado);
        }

        #endregion FIN SERVICIO COMPONENTE


        #region INICIO SERVICIO DE DANIOS REPARACION
        public void InsertarDanioReparacion(string danioReparacionSerializado)
        {
            DanioReparacionNegocio.Insertar(danioReparacionSerializado);
        }

        public void InsertarDanioReparacionListaProductos(string datos, List<Producto> lista)
        {
            DanioReparacionNegocio.InsertarDanioReparacionListaProductos(datos, lista);
        }

        public void ModificarDanioReparacion(string danioReparacionSerializado)
        {
            DanioReparacionNegocio.Modificar(danioReparacionSerializado);
        }

        public void ModificarDanioReparacionMasivo(string parametroSerializado)
        {
            DanioReparacionNegocio.ModificacionMasiva(parametroSerializado);
        }


        public void EliminarDanioReparacion(string danioReparacionSerializado)
        {
            DanioReparacionNegocio.Eliminar(danioReparacionSerializado);
        }

        public string ObtenerDaniosReparacionesPorCoincidencia(string value, bool estado)
        {
            return DanioReparacionNegocio.ObtenerDaniosReparacionesPorCoincidencia(value, estado);
        }

        public string ObtenerDaniosReparacionesPorCoincidenciaPaginado(string value, bool estado, int pageSize,
            int pageIndex, out int totalRegistros)
        {
            return DanioReparacionNegocio.ObtenerDaniosReparacionesPorCoincidenciaPaginado(value, estado, pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerDaniosReparacionesPorEstado(bool estado)
        {
            return DanioReparacionNegocio.ObtenerDaniosReparacionesPorEstado(estado);
        }

        public string ObtenerDaniosReparacionesPorEstadoPaginado(bool estado, int pageSize, int pageIndex,
            out int totalRegistros)
        {
            return DanioReparacionNegocio.ObtenerDaniosReparacionesPorEstadoPaginado(estado, pageSize, pageIndex,
                out totalRegistros);
        }

        public string ObtenerDaniosReparaciones()
        {
            return DanioReparacionNegocio.ObtenerDaniosReparaciones();
        }

        public string ObtenerDaniosReparacionesPaginado(int pageSize, int pageIndex, out int totalRegistros)
        {
            return DanioReparacionNegocio.ObtenerDaniosReparacionesPaginado(pageSize, pageIndex,
                out totalRegistros);
        }

        public string ObtenerDanioReparacionPorId(string clavePrimaria)
        {
            return DanioReparacionNegocio.ObtenerDanioReparacionPorId(clavePrimaria);
        }

        public string ObtenerDanioReparacionPorClave(string clavePrimaria)
        {
            return DanioReparacionNegocio.ObtenerDanioReparacionPorClave(clavePrimaria);
        }

        #endregion INICIO SERVICIO DE DANIOS REPARACION

        #region INICIO SERVICIO DE DANIO REPARACION PRODUCTOS


        public void InsertarDanioReparacionProducto(string danioReparacionProductoSerializado)
        {
            DanioReparacionProductoNegocio.Insertar(danioReparacionProductoSerializado);
        }

        public void ModificarDanioReparacionProducto(string danioReparacionProductoSerializado)
        {
            DanioReparacionProductoNegocio.Modificar(danioReparacionProductoSerializado);
        }

        public string ObtenerDanioReparacionProductoIdDanioReparacionIdProducto(string parametroSerializado)
        {
            return
                DanioReparacionProductoNegocio.ObtenerDanioReparacionProductoIdDanioReparacionIdProducto(
                    parametroSerializado);
        }

        public string ObtenerDanioReparacionProductoIdDanioReparacion(string parametroSerializado)
        {
            return DanioReparacionProductoNegocio.ObtenerDanioReparacionProductoIdDanioReparacion(parametroSerializado);
        }

        #endregion INICIO SERVICIO DE DANIO REPARACION PRODUCTOS


        #region INICIO GESTIÓN NEGOCIACIONES

        public void InsertarNegociacion(string negociacionSerializada)
        {
            
            NegociacionLineaNegocio.Insertar(negociacionSerializada);
        }

        public void ModificarNegociacion(string negociacionSerializada)
        {
            NegociacionLineaNegocio.Modificar(negociacionSerializada);
        }
        public void EliminarNegociacion(string negociacionSerializada)
        {
            NegociacionLineaNegocio.Eliminar(negociacionSerializada);
        }
        public string ObtenerNegociacionesPorEstado(bool estado)
        {
            return NegociacionLineaNegocio.ObtenerNegociacionesPorEstado(estado);
        }

        public string ObtenerNegociaciones()
        {
            return NegociacionLineaNegocio.ObtenerNegociaciones();
        }

        public string ObtenerNegociacionesPorCoincidencia(string value, bool estado)
        {
            return NegociacionLineaNegocio.ObtenerNegociacionesPorCoincidencia(value, estado);
        }
        public string ObtenerNegociacionesPorId(string idSerialziado)
        {
            return NegociacionLineaNegocio.ObtenerNegociacionesPorId(idSerialziado);
        }

        public string ObtenerNegociacionesPorCodigo(string codigo)
        {
            return NegociacionLineaNegocio.ObtenerNegociacionesPorCodigo(codigo);
        }

        public void ModificarMasivamente(string value, bool estado)
        {
            NegociacionLineaNegocio.ModificarMasivamente(value, estado);
        }

        public string ObtenerNegociacionesPorEstadoPaginado(bool estado, int pageSize, int pageIndex, out int totalRegistros)
        {
            return NegociacionLineaNegocio.ObtenerNegociacionesPorEstadoPaginado(estado, pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerNegociacionesPaginado(int pageSize, int pageIndex, out int totalRegistros)
        {
            return NegociacionLineaNegocio.ObtenerNegociacionesPaginado(pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerNegociacionesPorCoincidenciaPaginado(string value, bool estado, int pagesize, int pageIndex, out int totalRegistros)
        {
            return NegociacionLineaNegocio.ObtenerNegociacionesPorCoincidenciaPaginado(value, estado, pagesize, pageIndex, out totalRegistros);
        }


        #endregion FIN GESTIÓN NEGOCIACIONES


        public string ObtenerEorPorNumero(string numeorEor)
        {
            return EorNegocio.ObtenerEorPorNumero(numeorEor);
        }

        #endregion FIN DE SERVICIO DE CONTROL

    }
}
