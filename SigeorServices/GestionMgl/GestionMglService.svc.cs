using Negocio.Aretina;
using Negocio.Sigeor.GestionMgl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SigeorServices.GestionMgl
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "GestionMglService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione GestionMglService.svc o GestionMglService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class GestionMglService : IGestionMglService
    {
        #region INICIO SERVICIOS DE EOR's

        public string ObtenerEorEstructuraPorNumero(string parametro)
        {
            return LecturaEorNegocio.ObtenerDetalleEorEstructuraPorNumEor(parametro);
        }


        //public string ObtenerEorMaquinariaPorNumero(string parametro)
        //{
        //    return LecturaNegocio.ObtenerDetalleEorMaquinariaPorNumEor(parametro);
        //}


        //public string ObtenerEorTransitoPorNumero(string parametro)
        //{
        //    return LecturaNegocio.ObtenerEorTransitoPorNumEor(parametro);
        //}


        #endregion FIN  SERVICIOS DE EOR's

        #region INICIO DE SERVICIO DE REPONSABLE REPARACION

        public string ObtenerResponsablesReparaciones()
        {
            return ResponsableReparacionNegocio.ObtenerResponsablesReparacion();
        }

        #endregion FIN DE SERVICIO DE REPONSABLE REPARACION

        #region INICIO DE SERVICIO DE DEPOSITOS

        public string ObtenerDepositos()
        {
            return DepositoNegocio.ObtenerDepositos();
        }

        public string ObtenerDepositosPorEstado(string estado)
        {
            return DepositoNegocio.ObtenerDepositosPorEstado(estado);
        }

        public string ObtenerDespositoPorId(string parametro)
        {
            return DepositoNegocio.ObtenerDespositoPorId(parametro);
        }


        #endregion FIN DE SERVICIO DE DEPOSITOS

        #region INICIO SERVICIO DE TIPO DE EOR

        //public string ObtenerTiposEorPorEstado(bool estado)
        //{
        //    return TipoEorNegocio.ObtenerTiposEorPorEstado(estado);
        //}

        #endregion FIN SERVICIO DE TIPO DE EOR


        #region INICIO DE SERVICIO GESTION TIPO DE CONTENEDOR
        public string ObtenerTipoContenedorPorEstado(string estado)
        {
            return TipoContenedor.ObtenerTipoContenedorPorEstado(estado);
        }

        public string ObtenerTipoContenedorPorTipoEstado(string parametroSerializado)
        {
            return TipoContenedor.ObtenerTipoContenedorPorTipoEstado(parametroSerializado);
        }
        #endregion FIN DE SERVICIO GESTION TIPO DE CONTENEDOR




        #region INICIO DE SERVICIO GESTION DE LINEAS

        public string ObtenerLineas()
        {
            return LineaNegocio.ObtenerLineas();
        }

        public string ObtenerLineasPorEstado(string estado)
        {
            return LineaNegocio.ObtenerLineasPorEstado(estado);
        }

        public string ObtenerLineaPorCodigo(string parametro)
        {
            return LineaNegocio.ObtenerLineaPorCodigo(parametro);
        }



        #endregion FIN DE SERVICIO GESTION DE LINEAS



        #region INICIO DE GESTION DE PROVEEDORES

        public string ObtenerProveedores()
        {
            return ProveedorNegocio.ObtenerProveedores();
        }

        public string ObtenerProveedoresPorEstado(string estado)
        {
            return ProveedorNegocio.ObtenerProveedoresPorEstado(estado);
        }

        public string ObtenerProveedoresPorEstadoPaginado(bool estado, int pageSize, int pageIndex, out int totalRegistros)
        {
            return ProveedorNegocio.ObtenerProveedoresPorEstadoPaginado(estado, pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerProveedoresPorCoincidenciaPaginado(string value, bool estado, int pagesize, int pageIndex, out int totalRegistros)
        {
            return ProveedorNegocio.ObtenerProveedoresPorCoincidenciaPaginado(value, estado, pagesize, pageIndex, out totalRegistros);
        }

        public string ObtenerProveedorPorId(string parametro)
        {
            return ProveedorNegocio.ObtenerProveedorPorId(parametro);
        }

        public void InsertarProveedor(string proveedor)
        {
            ProveedorNegocio.Insertar(proveedor);
        }
        public void ModificarProveedor(string proveedor)
        {
            ProveedorNegocio.Modificar(proveedor);
        }

        public void EliminarProveedor(string proveedor)
        {
            ProveedorNegocio.Eliminar(proveedor);
        }

        public void ModificarProveedorEstadoMasivamente(string parametroProveedor)
        {
            ProveedorNegocio.ModificarEstadoMasivamente(parametroProveedor);
        }

        #endregion FIN DE GESTION DE PROVEEDORES



        #region INICIO DE GESTION DE AGENCIAS

        //public string ObtenerAgencias()
        //{
        //    return AgenciaNegocio.ObtenerAgencias();
        //}

        //public string ObtenerAgenciasPorEstado(string estado)
        //{
        //    return AgenciaNegocio.ObtenerAgenciasPorEstado(estado);
        //}

        //public string ObtenerAgenciaPorCodigo(string parametro)
        //{
        //    return AgenciaNegocio.ObtenerAgenciaPorCodigo(parametro);
        //}



        #endregion INICIO DE GESTION DE AGENCIAS
    }
}
