using System.Collections.Generic;
using Negocio.GestionControl;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Negocio.Sigeor.GestionControl;

namespace SigeorServices.GestionControl
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ControlService" en el código, en svc y en el archivo de configuración a la vez.
    public class ControlService : IControlService
    {
        #region INICIO DE SERVICIO DE CONTROL

        #region INICIO SERVICIO DATOS CREADOS
        public string CargarTipoDanios()
        {
            return DatosCreados.CargarTipoDanios();
        }

        public string CargarEstadosNegociaciones()
        {
            return DatosCreados.CargarEstadosNegociaciones();
        }
        #endregion INICIO SERVICIO DATOS CREADOS

        #region INICIO GESTIÓN NEGOCIACIONES PARA LINEAS

        public void InsertarNegociacionLinea(string negociacionSerializada)
        {
            NegociacionLineaNegocio.Insertar(negociacionSerializada);
        }

        public void ModificarNegociacionLinea(string negociacionSerializada)
        {
            NegociacionLineaNegocio.Modificar(negociacionSerializada);
        }
        public void EliminarNegociacionLinea(string negociacionSerializada)
        {
            NegociacionLineaNegocio.Eliminar(negociacionSerializada);
        }
        public string ObtenerNegociacionesLineaPorEstado(bool estado)
        {
            return NegociacionLineaNegocio.ObtenerNegociacionesPorEstado(estado);
        }

        public string ObtenerNegociacionesLinea()
        {
            return NegociacionLineaNegocio.ObtenerNegociaciones();
        }

        public string ObtenerNegociacionesLineaPorCoincidencia(string value, bool estado)
        {
            return NegociacionLineaNegocio.ObtenerNegociacionesPorCoincidencia(value, estado);
        }
        public string ObtenerNegociacionesLineaPorId(string idSerialziado)
        {
            return NegociacionLineaNegocio.ObtenerNegociacionesPorId(idSerialziado);
        }

        public void ModificarNegociacionLineaMasivamente(string value, bool estado)
        {
            NegociacionLineaNegocio.ModificarMasivamente(value, estado);
        }

        public string ObtenerNegociacionesLineaPorEstadoPaginado(bool estado, int pageSize, int pageIndex, out int totalRegistros)
        {
            return NegociacionLineaNegocio.ObtenerNegociacionesPorEstadoPaginado(estado, pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerNegociacionesLineaPaginado(int pageSize, int pageIndex, out int totalRegistros)
        {
            return NegociacionLineaNegocio.ObtenerNegociacionesPaginado(pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerNegociacionesLineaPorCoincidenciaPaginado(string value, bool estado, int pagesize, int pageIndex, out int totalRegistros)
        {
            return NegociacionLineaNegocio.ObtenerNegociacionesPorCoincidenciaPaginado(value, estado, pagesize, pageIndex, out totalRegistros);
        }

        #endregion FIN GESTIÓN NEGOCIACIONES PARA LINEAS

        #region INICIO DE GESTION DE HISTORICO DE NEGOCIACIONES POR LINEA

        public string ObtenerNegociacionesLineaHistoricoPaginado(string parametro, int pagesize, int pageIndex, out int totalRegistros)
        {
            return NegociacionLineaHistoricoNegocio.ObtenerNegociacionesLineaHistoricoPaginado(parametro, pagesize, pageIndex, out totalRegistros);
        }

        public string ObtenerNegociacionesLineaHistorico(string parametro)
        {
            return NegociacionLineaHistoricoNegocio.ObtenerNegociacionesLineaHistorico(parametro);
        }

        #endregion INICIO DE GESTION DE HISTORICO DE NEGOCIACIONES POR LINEA

        #region INICIO DE GESTION DE HISTORICO DE NEGOCIACIONES POR PROVEEDOR

        public string ObtenerNegociacionesProveedorHistoricoPaginado(string parametro, int pagesize, int pageIndex, out int totalRegistros)
        {
            return NegociacionProveedorHistoricoNegocio.ObtenerNegociacionesProveedorHistoricoPaginado(parametro, pagesize, pageIndex, out totalRegistros);
        }

        public string ObtenerNegociacionesProveedorHistorico(string parametro)
        {
            return NegociacionProveedorHistoricoNegocio.ObtenerNegociacionesProveedorHistorico(parametro);
        }

        #endregion INICIO DE GESTION DE HISTORICO DE NEGOCIACIONES POR PROVEEDOR

        #region INICIO GESTIÓN NEGOCIACIONES PARA PROVEEDORES


        public void InsertarNegociacionProveedor(string negociacionSerializada)
        {
            NegociacionProveedorNegocio.Insertar(negociacionSerializada);
        }

        public void ModificarNegociacionProveedor(string negociacionSerializada)
        {
            NegociacionProveedorNegocio.Modificar(negociacionSerializada);
        }

        public void EliminarNegociacionProveedor(string negociacionSerializada)
        {
            NegociacionProveedorNegocio.Eliminar(negociacionSerializada);
        }

        public string ObtenerNegociacionesProveedorPorEstado(bool estado)
        {
            return NegociacionProveedorNegocio.ObtenerNegociacionesPorEstado(estado);
        }

        public string ObtenerNegociacionesProveedor()
        {
            return NegociacionProveedorNegocio.ObtenerNegociaciones();
        }

        public string ObtenerNegociacionesProveedorPorCoincidencia(string value, bool estado)
        {
            return NegociacionProveedorNegocio.ObtenerNegociacionesPorCoincidencia(value, estado);
        }

        public string ObtenerNegociacionesProveedorPorId(string idSerialziado)
        {
            return NegociacionProveedorNegocio.ObtenerNegociacionesPorId(idSerialziado);
        }

        //public string ObtenerNegociacionesProveedorPorCodigo(string codigo)
        //{

        //}

        public void ModificarNegociacionProveedoresMasivamente(string value, bool estado)
        {
            NegociacionProveedorNegocio.ModificarMasivamente(value, estado);
        }

        public string ObtenerNegociacionesProveedorPorEstadoPaginado(bool estado, int pageSize, int pageIndex,
            out int totalRegistros)
        {
            return NegociacionProveedorNegocio.ObtenerNegociacionesPorEstadoPaginado(estado, pageSize, pageIndex,
                out totalRegistros);
        }

        public string ObtenerNegociacionesProveedorPaginado(int pageSize, int pageIndex, out int totalRegistros)
        {
            return NegociacionProveedorNegocio.ObtenerNegociacionesPaginado(pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerNegociacionesProveedorPorCoincidenciaPaginado(string value, bool estado, int pageSize,
            int pageIndex, out int totalRegistros)
        {
            return NegociacionProveedorNegocio.ObtenerNegociacionesPorCoincidenciaPaginado(value, estado, pageSize,
                pageIndex, out totalRegistros);
        }

        #endregion FIN GESTIÓN NEGOCIACIONES PARA PROVEEDORES

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

        #region INICIO DE GESTION DE REPARACIONES

        public void InsertarReparacion(string reparacionSerializado)
        {
            ReparacionNegocio.Insertar(reparacionSerializado);
        }

        public void ModificarReparacion(string reparacionSerializado)
        {
            ReparacionNegocio.Modificar(reparacionSerializado);
        }

        public void ModificarReparacionMasivo(string parametroSerializado)
        {
            ReparacionNegocio.ModificacionMasiva(parametroSerializado);
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


        public string ObtenerReparacionesPorCoincidenciaPaginado(string value, string estado, int pagesize, int pageIndex, out int totalRegistro)
        {

            return ReparacionNegocio.ObtenerReparacionesPorCoincidenciaPaginado(value, estado, pagesize, pageIndex, out totalRegistro);
        }

        #endregion FIN DE GESTION DE REPARACIONES

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

       

        #region INICIO DE SERVICIO DE INSPECTORES

        public string ObtenerInspectoresPorEstado(string estado)
        {
            return InspectorNegocio.ObtenerInspectoresPorEstado(estado);
        }

        #endregion FIN DE SERVICIO DE INSPECTORES

        #endregion FIN SERVICIO COMPONENTE

        #endregion FIN DE SERVICIO DE CONTROL
    }
}
