using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Negocio.Autenticacion;
using PersistenciaSigeor;

namespace SigeorServices.Autenticacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AutenticacionService" en el código, en svc y en el archivo de configuración a la vez.
    public class AutenticacionService : IAutenticacionService
    {
        #region INICIO SERVICIOS AUTENTICACION

        #region INICIO METODOS AUTENTICACCION
        public string ObtenerUsuarioPorCredenciales(string nombreUsuario, string contrasenia)
        {
            return GestionAutenticacion.ObtenerUsuarioPorCredenciales(nombreUsuario, contrasenia);
        }

        public bool CompararCoordenadaEkey(string coordenadaEKeyerializada)
        {
            return CoordenadasEkeyNegocio.CompararCoordenadaEkey(coordenadaEKeyerializada);
        }

        public string ObtenerUsuarioPorEmail(string emailUsuario, string eKey)
        {
            return GestionAutenticacion.ObtenerUsuarioPorEmail(emailUsuario, eKey);
        }

        #endregion FIN METODOS AUTENTICACCION

        #region INICIO GESTION DE EKey

        public void InsertarEKey(EKey ekey)
        {
            EkeyNegocio.Insertar(ekey);
        }

        public void InsertarEKeyCoordenadasEkey(EKey ekey, List<CoordenadasEkey> listaCoordenadasEkey)
        {
            EkeyNegocio.Insertar(ekey, listaCoordenadasEkey);
        }

        public void ModificarEKey(EKey ekey)
        {
            EkeyNegocio.Modificar(ekey);
        }

        public void EliminarEKey(EKey ekey)
        {
            EkeyNegocio.Eliminar(ekey);
        }

        public string ObtenerEkeyPorCedulaUsuario(string cedula)
        {
            return EkeyNegocio.ObtenerEkeyPorCedulaUsuario(cedula);
        }

        public string ObtenerEkeyPorId(Guid id)
        {
            return EkeyNegocio.ObtenerEkeyPorId(id);
        }


        public string ObtenerEKey()
        {
            return EkeyNegocio.ObtenerEKey();
        }

        public string ObtenerEKeyPorEstado(bool estado)
        {
            return EkeyNegocio.ObtenerEKeyPorEstado(estado);
        }

        #endregion FIN GESTION EKey

        #region INICIO DE GESTION DE COORDENADAS EKEY

        public void InsertarCoordenadasEkey(CoordenadasEkey coordenadasEkey)
        {
            CoordenadasEkeyNegocio.Insertar(coordenadasEkey);
        }

        public void InsertarListaCoordenadasEkey(List<CoordenadasEkey> listaCoordenadasEkey)
        {
            CoordenadasEkeyNegocio.Insertar(listaCoordenadasEkey);
        }

        public void ModificarCoordenadasEkey(CoordenadasEkey coordenadasEkey)
        {
            CoordenadasEkeyNegocio.Modificar(coordenadasEkey);
        }

        public void ModificarListaCoordenadasEkey(List<CoordenadasEkey> listaCoordenadasEkey)
        {
            CoordenadasEkeyNegocio.Modificar(listaCoordenadasEkey);
        }

        public void EliminarCoordenadasEkey(CoordenadasEkey coordenadasEkey)
        {
            CoordenadasEkeyNegocio.Eliminar(coordenadasEkey);
        }

        public CoordenadasEkey ObtenerCoordenadaEkeyPorId(Guid id)
        {
            return CoordenadasEkeyNegocio.ObtenerCoordenadaEkeyPorId(id);
        }

        public List<CoordenadasEkey> ObtenerCoordenadasEkeyPorIdEkey(Guid idKey)
        {
            return CoordenadasEkeyNegocio.ObtenerCoordenadasEkeyPorIdEkey(idKey);
        }



        public string GenerarCoordenadasEkey(string EKeyerializado)
        {
            return CoordenadasEkeyNegocio.GenerarCoordenadasEkey(EKeyerializado);
        }

        #endregion INICIO DE GESTION DE COORDENADAS EKEY

        #endregion FIN  SERVICIOS AUTENTICACION

    }
}
