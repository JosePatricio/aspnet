using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PersistenciaSigeor;


namespace SigeorServices.Autenticacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAutenticacionService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAutenticacionService
    {
        #region INICIO SERVICIO ATENTICACION


        #region INICIO METODOS AUTENTICACION
        [OperationContract]
        string ObtenerUsuarioPorCredenciales(string nombreUsuario, string contrasenia);

        [OperationContract]
        bool CompararCoordenadaEkey(string coordenadaEkeySerializada);

        [OperationContract]
        string ObtenerUsuarioPorEmail(string emailUsuario, string eKey);
        #endregion FIN  METODOS AUTENTICACION METODOS AUTENTICACION

        #region INICIO GESTION DE EKEYS

        [OperationContract]
        void InsertarEKey(EKey ekey);

        [OperationContract]
        void InsertarEKeyCoordenadasEkey(EKey ekey, List<CoordenadasEkey> listaCoordenadasEkey);

        [OperationContract]
        void ModificarEKey(EKey ekey);

        [OperationContract]
        void EliminarEKey(EKey ekey);

        [OperationContract]
        EKey ObtenerEkeyPorCedulaUsuario(string cedula);

        [OperationContract]
        EKey ObtenerEkeyPorId(Guid id);

        [OperationContract]
        List<EKey> ObtenerEkeys();

        [OperationContract]
        List<EKey> ObtenerEkeysPorEstado(bool estado);

        #endregion INICIO GESTION DE EKEYS

        #region INICIO DE GESTION DE COORDENADAS EKEY

        [OperationContract]
        void InsertarCoordenadasEkey(CoordenadasEkey coordenadasEkey);

        [OperationContract]
        void InsertarListaCoordenadasEkey(List<CoordenadasEkey> listaCoordenadasEkey);

        [OperationContract]
        void ModificarCoordenadasEkey(CoordenadasEkey coordenadasEkey);

        [OperationContract]
        void ModificarListaCoordenadasEkey(List<CoordenadasEkey> listaCoordenadasEkey);

        [OperationContract]
        void EliminarCoordenadasEkey(CoordenadasEkey coordenadasEkey);

        [OperationContract]
        CoordenadasEkey ObtenerCoordenadaEkeyPorId(Guid id);

        [OperationContract]
        List<CoordenadasEkey> ObtenerCoordenadasEkeysPorIdEkey(Guid idKey);



        [OperationContract]
        string GenerarCoordenadasEkey(string ekeySerializado);

        #endregion FIN DE GESTION DE COORDENADAS EKEY


        #endregion INICIO SERVICIO ATENTICACION
 
    }
}
