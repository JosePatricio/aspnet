using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SigeorServices.Configuracion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IConfiguracionService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IConfiguracionService
    {
        #region SERVICIO DE CONFIGURACION


        #region INICIO SERVICIO DE GESTION DE PERFILES
        [OperationContract]
        void InsertarPerfil(string perfil);

        [OperationContract]
        void ModificarPerfil(string perfilSerializado);

        [OperationContract]
        void ModificarMasivamentePerfiles(string parametroSerializado);

        [OperationContract]
        void EliminarPerfil(string perfil);

        [OperationContract]
        string ObtenerPerfilesPorEstado(bool estado);

        [OperationContract]
        string ObtenerPerfilesPorEstadoPaginado(bool estado, int pageSize, int pageIndex, out int totalRegistros);

        [OperationContract]
        string ObtenerPerfiles();

        [OperationContract]
        string ObtenerPerfilesPaginado(int pageSize, int pageIndex, out int totalRegistros);

        [OperationContract]
        string ObtenerPerfilesPorId(Guid id);

        [OperationContract]
        string ObtenerPerfilesPorCoincidencia(string value, bool estado);

        [OperationContract]
        string ObtenerPerfilesPorCoincidenciaPaginado(string value, bool estado, int pageSize, int pageIndex, out int totalRegistros);

        [OperationContract]
        string ObtenerPerfilesPorCodigo(string codigo);
        #endregion  INICIO SERVICIO DE GESTION DE PERFILES
        #region INICIO SERVICIO DE GESTION DE USUARIOS

        [OperationContract]
        void InsertarUsuario(string usuarioSerializado);

        [OperationContract]
        void ModificarUsuario(string usuarioSerializado);

        [OperationContract]
        void EliminarUsuario(string usuario);

        [OperationContract]
        string ObtenerUsuariosPorEstado(string estado);

        [OperationContract]
        string ObtenerUsuarios();

        [OperationContract]
        string ObtenerUsuariosPorCedula(string cedula);

        [OperationContract]
        string ObtenerUsuariosPorCorreo(string email);

        [OperationContract]
        string ObtenerUsuariosPorCoincidencia(string value, string estado);


        [OperationContract]
        void ModificarMasivamente(string value, bool estado);

        [OperationContract]
        string ObtenerUsuariosPorEstadoPaginado(bool estado, int pageSize, int pageIndex,
            out int totalRegistros);

        [OperationContract]
        string ObtenerUsuariosPaginado(int pageSize, int pageIndex, out int totalRegistros);


        [OperationContract]
        string ObtenerUsuariosPorCoincidenciaPaginado(string value, bool estado, int pageSize, int pageIndex, out int totalRegistros);

        #endregion FIN SERVICIO DE GESTION DE USUARIOS
        #region  INICIO SERVICIO DE GESTION DE USUARIO-PERFIL

        [OperationContract]
        void InsertarUsuarioPerfil(string usuarioPerfil);

        [OperationContract]
        void ModificarUsuarioPerfil(string usuarioPerfilSerializado);

        [OperationContract]
        void EliminarUsuarioPerfil(string usuarioPerfilSerializado);

        [OperationContract]
        string ObtenerUsuariosPerfilPorCedula(string cedula);

        #endregion FIN SERVICIO DE GESTION DE USUARIO-PERFIL
        #region  INICIO SERVICIO DE GESTION DE ESTRUCTURA

        [OperationContract]
        void InsertarEstructura(string estructuraSerializada);

        [OperationContract]
        void ModificarEstructura(string estructuraSerializada);

        [OperationContract]
        void EliminarEstructura(string estructuraSerializada);

        [OperationContract]
        string ObtenerEstructurasPorEstado(bool estado);

        [OperationContract]
        string ObtenerEstructurasPorId(string idSerializado);

        [OperationContract]
        string ObtenerEstructuras();

        #endregion FIN SERVICIO DE GESTION DE ESTRUCTURA
        #region  INICIO SERVICIO DE GESTION DE ESTRUCTURA-PERFIL

        [OperationContract]
        void InsertarEstructuraPerfil(string estructuraPerfilSerializada);

        [OperationContract]
        void ModificarEstructuraPerfil(string estructuraPerfilSerializada);

        [OperationContract]
        void EliminarEstructuraPerfil(string estructuraPerfilSerializada);

        [OperationContract]
        string ObtenerEstructurasPerfilesPorIdPerfil(string idSerializado);

        [OperationContract]
        string ObtenerEstructurasPerfilesPorIdEstructura(string idSerializado);

        [OperationContract]
        string ObtenerEstructurasPerfilesPorEstado(bool estado);

        [OperationContract]
        string ObtenerEstructurasPerfilesPorCoincidencia(string value, bool estado);


        [OperationContract]
        void ModificarMasivamentePerfilEstructura(string value, bool estado);

        [OperationContract]
        string ObtenerPerfilEstructuraPorEstadoPaginado(bool estado, int pageSize, int pageIndex,
            out int totalRegistros);

        [OperationContract]
        string ObtenerPerfilEstructuraPaginado(int pageSize, int pageIndex, out int totalRegistros);


        [OperationContract]
        string ObtenerPerfilEstructuraPorCoincidenciaPaginado(string value, bool estado, int pageSize, int pageIndex, out int totalRegistros);

        #endregion FIN SERVICIO DE GESTION DE ESTRUCTURA-PERFIL

        #region INICIO DE GESTION DE AUDITORIAS


        [OperationContract]
        string ObtenerAuditorias();

        [OperationContract]
        string ObtenerAuditoriasPorCoincidencia(string value);

        [OperationContract]
        string ObtenerAuditoriasPorCoincidenciaPaginado(string value, int pagesize, int pageIndex, out int totalRegistros);

        [OperationContract]
        void InsertarAuditoria(string auditoriaSerializado);

        #endregion FIN DE GESTION DE AUDITORIAS

        #region  INICIO SERVICIO DE GESTION DE DOCUMENTOS

        [OperationContract]
        void Insertar(string documentoSerializado);


        [OperationContract]
        void Modificar(string documentoSerializado);

        [OperationContract]
        void Eliminar(string documentoSerializado);

        [OperationContract]
        string ObtenerDoumentos();

        [OperationContract]
        string ObtenerDoumentosPaginado(int pageSize, int pageIndex, out int totalRegistros);

        [OperationContract]
        string ObtenerDocumentosPorCoincidencia(string value);

        [OperationContract]
        string ObtenerDocumentosPorCoincidenciaPaginado(string value, int pageSize, int pageIndex, out int totalRegistros);


        [OperationContract]
        string ObtenerDocumentosPorId(string idSerializado);

        #endregion FIN SERVICIO DE GESTION DE DOCUMENTOS




        #endregion  SERVICIO DE CONFIGURACION



    }
}
