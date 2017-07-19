using System;

using Negocio.Configuracion;
using Negocio.Sigeor.Configuracion;

namespace SigeorServices.Configuracion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ConfiguracionService" en el código, en svc y en el archivo de configuración a la vez.
    public class ConfiguracionService : IConfiguracionService
    {
        #region INICIO SERVICIO DE CONFIGURACION



        #region  INICIO SERVICIO DE GESTION DE PERFILES
        public void InsertarPerfil(string perfil)
        {
            PerfilNegocio.Insertar(perfil);
        }

        public void ModificarPerfil(string Perfilerializado)
        {
            PerfilNegocio.Modificar(Perfilerializado);
        }

        public void ModificarMasivamentePerfiles(string parametroSerializado)
        {
            PerfilNegocio.ModificarMasivamente(parametroSerializado);
        }

        public void EliminarPerfil(string perfil)
        {
            PerfilNegocio.Eliminar(perfil);
        }

        public string ObtenerPerfilesPorEstado(bool estado)
        {
            return PerfilNegocio.ObtenerPerfilesPorEstado(estado);
        }

        public string ObtenerPerfilesPorEstadoPaginado(bool estado, int pageSize, int pageIndex, out int totalRegistros)
        {
            return PerfilNegocio.ObtenerPerfilesPorEstadoPaginado(estado, pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerPerfiles()
        {
            return PerfilNegocio.ObtenerPerfiles();
        }

        public string ObtenerPerfilesPaginado(int pageSize, int pageIndex, out int totalRegistros)
        {
            return PerfilNegocio.ObtenerPerfilesPaginado(pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerPerfilesPorId(Guid id)
        {
            return PerfilNegocio.ObtenerPerfilesPorId(id);
        }

        public string ObtenerPerfilesPorCodigo(string codigo)
        {
            return PerfilNegocio.ObtenerPerfilesPorCodigo(codigo);
        }

        public string ObtenerPerfilesPorCoincidencia(string value, bool estado)
        {
            return PerfilNegocio.ObtenerPerfilesPorCoincidencia(value, estado);
        }

        public string ObtenerPerfilesPorCoincidenciaPaginado(string value, bool estado, int pageSize, int pageIndex, out int totalRegistros)
        {
            return PerfilNegocio.ObtenerPerfilesPorCoincidenciaPaginado(value, estado, pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerPerfilEstructuraPorPerfil(string perfil)
        {
            return EstructuraPerfilNegocio.ObtenerPerfilEstructuraPorPerfil(perfil);
        }

        #endregion  FIN SERVICIO DE GESTION DE PERFILES

        #region INICIO SERVICIO DE GESTION DE Usuario
        public void InsertarUsuario(string Usuarioerializado)
        {
            UsuarioNegocio.Insertar(Usuarioerializado);
        }


        public void ModificarUsuario(string Usuarioerializado)
        {
            UsuarioNegocio.Modificar(Usuarioerializado);
        }


        public void EliminarUsuario(string usuario)
        {
            UsuarioNegocio.Eliminar(usuario);
        }

        public string ObtenerUsuarioPorEstado(bool estado)
        {
            return UsuarioNegocio.ObtenerUsuarioPorEstado(estado);
        }


        public string ObtenerUsuario()
        {
            return UsuarioNegocio.ObtenerUsuario();
        }


        public string ObtenerUsuarioPorCedula(string cedula)
        {
            return UsuarioNegocio.ObtenerUsuarioPorCedula(cedula);

        }
        public string ObtenerUsuarioPorCorreo(string email)
        {
            return UsuarioNegocio.ObtenerUsuarioPorCorreo(email);

        }
        public string ObtenerUsuarioPorCoincidencia(string value, bool estado)
        {
            return UsuarioNegocio.ObtenerUsuarioPorCoincidencia(value, estado);
        }

        public void ModificarUsuarioMasivamente(string value, bool estado)
        {
            UsuarioNegocio.ModificarMasivamente(value, estado);
        }

        public string ObtenerUsuarioPorEstadoPaginado(bool estado, int pageSize, int pageIndex, out int totalRegistros)
        {
            return UsuarioNegocio.ObtenerUsuarioPorEstadoPaginado(estado, pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerUsuarioPaginado(int pageSize, int pageIndex, out int totalRegistros)
        {
            return UsuarioNegocio.ObtenerUsuarioPaginado(pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerUsuarioPorCoincidenciaPaginado(string value, bool estado, int pageSize, int pageIndex, out int totalRegistros)
        {
            return UsuarioNegocio.ObtenerUsuarioPorCoincidenciaPaginado(value, estado, pageSize, pageIndex, out totalRegistros);
        }
        #endregion FIN SERVICIO DE GESTION DE Usuario

        #region  INICIO SERVICIO DE GESTION DE USUARIO-PERFIL

        public void InsertarUsuarioPerfil(string usuarioPerfil)
        {

            UsuarioPerfilNegocio.Insertar(usuarioPerfil);
        }

        public void ModificarUsuarioPerfil(string usuarioPerfilerializado)
        {

            UsuarioPerfilNegocio.Modificar(usuarioPerfilerializado);
        }
        public void EliminarUsuarioPerfil(string usuarioPerfilerializado)
        {

            UsuarioPerfilNegocio.Eliminar(usuarioPerfilerializado);
        }

        public string ObtenerUsuarioPerfilPorCedula(string cedula)
        {
            return UsuarioPerfilNegocio.ObtenerUsuarioPerfilPorCedula(cedula);
        }

        #endregion FIN SERVICIO DE GESTION DE USUARIO-PERFIL

        #region  INICIO SERVICIO DE GESTION DE ESTRUCTURA

        public void InsertarEstructura(string Estructuraerializada)
        {

            EstructuraNegocio.Insertar(Estructuraerializada);
        }

        public void ModificarEstructura(string Estructuraerializada)
        {

            EstructuraNegocio.Modificar(Estructuraerializada);
        }
        public void EliminarEstructura(string Estructuraerializada)
        {

            EstructuraNegocio.Eliminar(Estructuraerializada);
        }
        public string ObtenerEstructuraPorId(string idSerializado)
        {
            return EstructuraNegocio.ObtenerEstructuraPorId(idSerializado);
        }
        public string ObtenerEstructuraPorEstado(bool estado)
        {
            return EstructuraNegocio.ObtenerEstructuraPorEstado(estado);
        }

        public string ObtenerEstructura(string id)
        {
            return EstructuraNegocio.ObtenerEstructura(id);
        }

        public string ObtenerTituloPorPagina(string pagina)
        {
            return EstructuraNegocio.ObtenerTituloPorPagina(pagina);
        }



        #endregion FIN SERVICIO DE GESTION DE ESTRUCTURA

        #region  INICIO SERVICIO DE GESTION DE ESTRUCTURA-PERFIL

        public void InsertarEstructuraPerfil(string EstructuraPerfilerializada)
        {

            EstructuraPerfilNegocio.Insertar(EstructuraPerfilerializada);
        }

        public void ModificarEstructuraPerfil(string EstructuraPerfilerializada)
        {

            EstructuraPerfilNegocio.Modificar(EstructuraPerfilerializada);
        }
        public void EliminarEstructuraPerfil(string EstructuraPerfilerializada)
        {

            EstructuraPerfilNegocio.Eliminar(EstructuraPerfilerializada);
        }
        public string ObtenerEstructuraPerfilesPorIdPerfil(string idSerializado)
        {
            return EstructuraPerfilNegocio.ObtenerEstructuraPerfilesPorIdPerfil(idSerializado);
        }

        public string ObtenerEstructuraPerfilesPorIdEstructura(string idSerializado)
        {
            return EstructuraPerfilNegocio.ObtenerEstructuraPerfilesPorIdEstructura(idSerializado);
        }
        public string ObtenerEstructuraPerfilesPorEstado(bool estado)
        {
            return EstructuraPerfilNegocio.ObtenerEstructuraPerfilesPorEstado(estado);
        }

        public string ObtenerEstructuraPerfilesPorCoincidencia(string value, bool estado)
        {
            return EstructuraPerfilNegocio.ObtenerEstructuraPerfilesPorCoincidencia(value, estado);
        }
        public void ModificarMasivamentePerfilEstructura(string value, bool estado)
        {
            EstructuraPerfilNegocio.ModificarMasivamentePerfilEstructura(value, estado);
        }

        public string ObtenerPerfilEstructuraPorEstadoPaginado(bool estado, int pageSize, int pageIndex, out int totalRegistros)
        {
            return EstructuraPerfilNegocio.ObtenerPerfilEstructuraPorEstadoPaginado(estado, pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerPerfilEstructuraPaginado(int pageSize, int pageIndex, out int totalRegistros)
        {
            return EstructuraPerfilNegocio.ObtenerPerfilEstructuraPaginado(pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerPerfilEstructuraPorCoincidenciaPaginado(string value, bool estado, int pageSize, int pageIndex, out int totalRegistros)
        {
            return EstructuraPerfilNegocio.ObtenerPerfilEstructuraPorCoincidenciaPaginado(value, estado, pageSize, pageIndex, out totalRegistros);
        }
        public string ObtenerPerfilPorCedula(string cedula)
        {
            return UsuarioPerfilNegocio.ObtenerPerfilPorCedula(cedula);
        }
        #endregion FIN SERVICIO DE GESTION DE ESTRUCTURA-PERFIL

        #region INICIO DE GESTION DE Auditoria


        public string ObtenerAuditoria()
        {
            return AuditoriaNegocio.ObtenerAuditoria();
        }


        public string ObtenerAuditoriaPorCoincidencia(string value)
        {
            return AuditoriaNegocio.ObtenerAuditoriaPorCoincidencia(value);
        }

        public string ObtenerAuditoriaPorCoincidenciaPaginado(string value, int pageSize, int pageIndex, out int totalRegistros)
        {
            return AuditoriaNegocio.ObtenerAuditoriaPorCoincidenciaPaginado(value, pageSize, pageIndex, out totalRegistros);
        }

        public void InsertarAuditoria(string Auditoriaerializado)
        {
            AuditoriaNegocio.Insertar(Auditoriaerializado);
        }

        #endregion FIN DE GESTION DE Auditoria

        #region  INICIO SERVICIO DE GESTION DE DOCUMENTOS

        public void Insertar(string documentoSerializado)
        {

            DocumentosNegocio.Insertar(documentoSerializado);
        }
        public void Modificar(string documentoSerializado)
        {

            DocumentosNegocio.Modificar(documentoSerializado);
        }
        public void Eliminar(string documentoSerializado)
        {

            DocumentosNegocio.Eliminar(documentoSerializado);
        }

        public string ObtenerDoumentos()
        {
            return DocumentosNegocio.ObtenerDocumentos();
        }

        public string ObtenerDoumentosPaginado(int pageSize, int pageIndex, out int totalRegistros)
        {
            return DocumentosNegocio.ObtenerDocumentosPaginado(pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerDocumentosPorCoincidencia(string value)
        {
            return DocumentosNegocio.ObtenerDocumentosPorCoincidencia(value);
        }

        public string ObtenerDocumentosPorCoincidenciaPaginado(string value, int pageSize, int pageIndex,
            out int totalRegistros)
        {
            return DocumentosNegocio.ObtenerDocumentosPorCoincidenciaPaginado(value, pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerDocumentosPorId(string idSerializado)
        {
            return DocumentosNegocio.ObtenerDocumentosPorId(idSerializado);
        }

        #endregion FIN SERVICIO DE GESTION DE DOCUMENTOS

        #endregion FIN SERVICIO DE CONFIGURACION

        #region INICIO SERVICIO DE CONFIGURACION DE EMAIL

        public void InsertarConfiguracionEmail(string Emailerializado)
        {
            ConfigurarEmailNegocio.InsertarConfiguracionEmail(Emailerializado);
        }

        public string ObtenerConfiguracionEmail()
        {
            return ConfigurarEmailNegocio.ObtenerConfiguracionEmail();
        }
        #endregion FIN SERVICIO DE CONFIGURACION DE EMAIL

        #region OBTENER PAGINA POR CEDULA
        public string ObtenerPaginadeInicioPorCedula(string cedula)
        {
            return Negocio.Configuracion.PerfilNegocio.ObtenerPaginadeInicioPorCedula(cedula);
        }
        #endregion OBTENER PAGINA POR CEDULA

        #region OBTENER URL POR IR
        public string ObtenerUrlPorId(string id)
        {
            return Negocio.Configuracion.EstructuraNegocio.ObtenerUrlPorId(id);
        }
        #endregion OBTENER URL POR IR

        #region INICIO DE SERVICIO DE POLITICAS CORPORATIVAS

        public void InsertarPolitica(string politicaSerializada)
        {
            PoliticasCorporativasNegocio.Insertar(politicaSerializada);
        }
        public void ModificarPolitica(string politicaSerializada)
        {
            PoliticasCorporativasNegocio.Modificar(politicaSerializada);
        }
        public string ObtenerPoliticaPorcodigo(string parametroSerializado)
        {
            return PoliticasCorporativasNegocio.ObtenerPoliticaPorCodigo(parametroSerializado);
        }
        public string ObtenerPoliticaPorGrupo(string parametroSerializado)
        {
            return PoliticasCorporativasNegocio.ObtenerPoliticasPorGrupo(parametroSerializado);
        }


        #endregion INICIO DE SERVICIO DE POLITICAS CORPORATIVAS

        #region INICIO DE SERVICIO PARA ALERTAS REPARACION

        public void ModificarAlertaReparacion(string alertaReparacionSerializada)
        {
            AlertaReparacionNegocio.Modificar(alertaReparacionSerializada);
        }

        public string ObtenerAlertaReparacion(string idAlertaReparacion)
        {
            return AlertaReparacionNegocio.ObtenerAlertaReparacion(idAlertaReparacion);
        }
        public string ObtenerAlertasReparacionPorEstadoPaginado(bool estado, int pagesize, int pageIndex, out int totalRegistros)
        {
            return AlertaReparacionNegocio.ObtenerAlertasPorEstadoPaginado(estado, pagesize, pageIndex, out totalRegistros);
        }
        public string ObtenerAlertasReparacionPorEstado(bool estado)
        {
            return AlertaReparacionNegocio.ObtenerAlertasPorEstado(estado);
        }

        public string ObtenerResumenAlertasReparacion()
        {
            return AlertaReparacionNegocio.ObtenerResumenAlertas();
        }

        public string ObtenerAlertasReparacionPorCoincidenciaPaginado(string value, bool estado, int pageSize, int pageIndex, out int totalRegistros)
        {
            return AlertaReparacionNegocio.ObtenerAlertaReparacionPorCoincidenciaPaginado(value, estado, pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerAlertasReparacionPorCoincidencia(string value, bool estado)
        {
            return AlertaReparacionNegocio.ObtenerAlertaReparacionPorCoincidencia(value, estado);
        }



        #endregion FIN DE SERVICIO PARA ALERTAS REPARACION

    }
}
