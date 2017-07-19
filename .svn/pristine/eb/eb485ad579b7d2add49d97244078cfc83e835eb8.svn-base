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
        void ModificarPerfil(string Perfilerializado);

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

        [OperationContract]
        string ObtenerPerfilEstructuraPorPerfil(string perfil);





        #endregion  INICIO SERVICIO DE GESTION DE PERFILES
        #region INICIO SERVICIO DE GESTION DE Usuario

        [OperationContract]
        void InsertarUsuario(string Usuarioerializado);

        [OperationContract]
        void ModificarUsuario(string Usuarioerializado);

        [OperationContract]
        void EliminarUsuario(string usuario);

        [OperationContract]
        string ObtenerUsuarioPorEstado(bool estado);

        [OperationContract]
        string ObtenerUsuario();

        [OperationContract]
        string ObtenerUsuarioPorCedula(string cedula);

        [OperationContract]
        string ObtenerUsuarioPorCorreo(string email);

        [OperationContract]
        string ObtenerUsuarioPorCoincidencia(string value, bool estado);


        [OperationContract]
        void ModificarUsuarioMasivamente(string value, bool estado);

        [OperationContract]
        string ObtenerUsuarioPorEstadoPaginado(bool estado, int pageSize, int pageIndex,
            out int totalRegistros);

        [OperationContract]
        string ObtenerUsuarioPaginado(int pageSize, int pageIndex, out int totalRegistros);


        [OperationContract]
        string ObtenerUsuarioPorCoincidenciaPaginado(string value, bool estado, int pageSize, int pageIndex, out int totalRegistros);

        #endregion FIN SERVICIO DE GESTION DE Usuario
        #region  INICIO SERVICIO DE GESTION DE USUARIO-PERFIL

        [OperationContract]
        void InsertarUsuarioPerfil(string usuarioPerfil);

        [OperationContract]
        void ModificarUsuarioPerfil(string usuarioPerfilerializado);

        [OperationContract]
        void EliminarUsuarioPerfil(string usuarioPerfilerializado);

        [OperationContract]
        string ObtenerUsuarioPerfilPorCedula(string cedula);

        #endregion FIN SERVICIO DE GESTION DE USUARIO-PERFIL
        #region  INICIO SERVICIO DE GESTION DE ESTRUCTURA

        [OperationContract]
        void InsertarEstructura(string Estructuraerializada);

        [OperationContract]
        void ModificarEstructura(string Estructuraerializada);

        [OperationContract]
        void EliminarEstructura(string Estructuraerializada);

        [OperationContract]
        string ObtenerEstructuraPorEstado(bool estado);

        [OperationContract]
        string ObtenerEstructuraPorId(string idSerializado);

        [OperationContract]
        string ObtenerEstructura(string id);

        [OperationContract]
        string ObtenerTituloPorPagina(string pagina);



        #endregion FIN SERVICIO DE GESTION DE ESTRUCTURA
        #region  INICIO SERVICIO DE GESTION DE ESTRUCTURA-PERFIL

        [OperationContract]
        void InsertarEstructuraPerfil(string EstructuraPerfilerializada);

        [OperationContract]
        void ModificarEstructuraPerfil(string EstructuraPerfilerializada);

        [OperationContract]
        void EliminarEstructuraPerfil(string EstructuraPerfilerializada);

        [OperationContract]
        string ObtenerEstructuraPerfilesPorIdPerfil(string idSerializado);

        [OperationContract]
        string ObtenerEstructuraPerfilesPorIdEstructura(string idSerializado);

        [OperationContract]
        string ObtenerEstructuraPerfilesPorEstado(bool estado);

        [OperationContract]
        string ObtenerEstructuraPerfilesPorCoincidencia(string value, bool estado);


        [OperationContract]
        void ModificarMasivamentePerfilEstructura(string value, bool estado);

        [OperationContract]
        string ObtenerPerfilEstructuraPorEstadoPaginado(bool estado, int pageSize, int pageIndex,
            out int totalRegistros);

        [OperationContract]
        string ObtenerPerfilEstructuraPaginado(int pageSize, int pageIndex, out int totalRegistros);


        [OperationContract]
        string ObtenerPerfilEstructuraPorCoincidenciaPaginado(string value, bool estado, int pageSize, int pageIndex, out int totalRegistros);

        [OperationContract]
        string ObtenerPerfilPorCedula(string cedula);



        #endregion FIN SERVICIO DE GESTION DE ESTRUCTURA-PERFIL

        #region INICIO DE GESTION DE Auditoria


        [OperationContract]
        string ObtenerAuditoria();

        [OperationContract]
        string ObtenerAuditoriaPorCoincidencia(string value);

        [OperationContract]
        string ObtenerAuditoriaPorCoincidenciaPaginado(string value, int pagesize, int pageIndex, out int totalRegistros);

        [OperationContract]
        void InsertarAuditoria(string Auditoriaerializado);

        #endregion FIN DE GESTION DE Auditoria

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

        #region INICIO SERVICIO DE CONFIGURACION DE EMAIL

        [OperationContract]
        void InsertarConfiguracionEmail(string Emailerializado);

        [OperationContract]
        string ObtenerConfiguracionEmail();

        #endregion FIN SERVICIO DE CONFIGURACION DE EMAIL

        #region OBTENER PAGINA POR CEDULA
        [OperationContract]
        string ObtenerPaginadeInicioPorCedula(string cedula);
        #endregion OBTENER PAGINA POR CEDULA

        #region OBTENER URL POR IR
        [OperationContract]
        string ObtenerUrlPorId(string id);
        #endregion OBTENER URL POR IR

        #region INICIO DE SERVICIO DE POLITICAS CORPORATIVAS
        [OperationContract]
        void InsertarPolitica(string politicaSerializada);

        [OperationContract]
        void ModificarPolitica(string politicaSerializada);

        [OperationContract]
        string ObtenerPoliticaPorcodigo(string parametroSerializado);

        [OperationContract]
        string ObtenerPoliticaPorGrupo(string parametroSerializado);

        #endregion INICIO DE SERVICIO DE POLITICAS CORPORATIVAS

        #region INICIO DE SERVICIO PARA ALERTAS

        [OperationContract]
        void ModificarAlertaReparacion(string alertaReparacionSerializada);
        [OperationContract]
        string ObtenerAlertaReparacion(string idAlertaReparacion);
        [OperationContract]
        string ObtenerAlertasReparacionPorEstadoPaginado(bool estado, int pagesize, int pageIndex, out int totalRegistros);
        [OperationContract]
        string ObtenerAlertasReparacionPorEstado(bool estado);
        [OperationContract]
        string ObtenerResumenAlertasReparacion();
        [OperationContract]
        string ObtenerAlertasReparacionPorCoincidenciaPaginado(string value, bool estado, int pageSize, int pageIndex, out int totalRegistros);
        [OperationContract]
        string ObtenerAlertasReparacionPorCoincidencia(string value, bool estado);

        #endregion FIN DE SERVICIO PARA ALERTAS
    }
}
