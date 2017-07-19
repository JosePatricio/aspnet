using System;

using Negocio.Configuracion;

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

        public void ModificarPerfil(string perfilSerializado)
        {
            PerfilNegocio.Modificar(perfilSerializado);
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

        #endregion  FIN SERVICIO DE GESTION DE PERFILES

        #region INICIO SERVICIO DE GESTION DE USUARIOS
        public void InsertarUsuario(string usuarioSerializado)
        {
            UsuarioNegocio.Insertar(usuarioSerializado);
        }


        public void ModificarUsuario(string usuarioSerializado)
        {
            UsuarioNegocio.Modificar(usuarioSerializado);
        }


        public void EliminarUsuario(string usuario)
        {
            UsuarioNegocio.Eliminar(usuario);
        }

        public string ObtenerUsuariosPorEstado(string estado)
        {
            throw new NotImplementedException();
        }


        public string ObtenerUsuariosPorEstado(bool estado)
        {
            return UsuarioNegocio.ObtenerUsuariosPorEstado(estado);
        }


        public string ObtenerUsuarios()
        {
            return UsuarioNegocio.ObtenerUsuarios();
        }


        public string ObtenerUsuariosPorCedula(string cedula)
        {
            return UsuarioNegocio.ObtenerUsuariosPorCedula(cedula);

        }
        public string ObtenerUsuariosPorCorreo(string email)
        {
            return UsuarioNegocio.ObtenerUsuariosPorCorreo(email);

        }
        public string ObtenerUsuariosPorCoincidencia(string value, bool estado)
        {
            return UsuarioNegocio.ObtenerUsuariosPorCoincidencia(value, estado);
        }

        public void ModificarMasivamente(string value, bool estado)
        {
            UsuarioNegocio.ModificarMasivamente(value, estado);
        }

        public string ObtenerUsuariosPorEstadoPaginado(bool estado, int pageSize, int pageIndex, out int totalRegistros)
        {
            return UsuarioNegocio.ObtenerUsuariosPorEstadoPaginado(estado, pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerUsuariosPaginado(int pageSize, int pageIndex, out int totalRegistros)
        {
            return UsuarioNegocio.ObtenerUsuariosPaginado(pageSize, pageIndex, out totalRegistros);
        }

        public string ObtenerUsuariosPorCoincidenciaPaginado(string value, bool estado, int pageSize, int pageIndex, out int totalRegistros)
        {
            return UsuarioNegocio.ObtenerUsuariosPorCoincidenciaPaginado(value, estado, pageSize, pageIndex, out totalRegistros);
        }
        #endregion FIN SERVICIO DE GESTION DE USUARIOS

        #region  INICIO SERVICIO DE GESTION DE USUARIO-PERFIL

        public void InsertarUsuarioPerfil(string usuarioPerfil)
        {

            UsuarioPerfilNegocio.Insertar(usuarioPerfil);
        }

        public void ModificarUsuarioPerfil(string usuarioPerfilSerializado)
        {

            UsuarioPerfilNegocio.Modificar(usuarioPerfilSerializado);
        }
        public void EliminarUsuarioPerfil(string usuarioPerfilSerializado)
        {

            UsuarioPerfilNegocio.Eliminar(usuarioPerfilSerializado);
        }

        public string ObtenerUsuariosPerfilPorCedula(string cedula)
        {
            return UsuarioPerfilNegocio.ObtenerUsuariosPerfilPorCedula(cedula);
        }

        #endregion FIN SERVICIO DE GESTION DE USUARIO-PERFIL

        #region  INICIO SERVICIO DE GESTION DE ESTRUCTURA

        public void InsertarEstructura(string estructuraSerializada)
        {

            EstructuraNegocio.Insertar(estructuraSerializada);
        }

        public void ModificarEstructura(string estructuraSerializada)
        {

            EstructuraNegocio.Modificar(estructuraSerializada);
        }
        public void EliminarEstructura(string estructuraSerializada)
        {

            EstructuraNegocio.Eliminar(estructuraSerializada);
        }
        public string ObtenerEstructurasPorId(string idSerializado)
        {
            return EstructuraNegocio.ObtenerEstructurasPorId(idSerializado);
        }
        public string ObtenerEstructurasPorEstado(bool estado)
        {
            return EstructuraNegocio.ObtenerEstructurasPorEstado(estado);
        }

        public string ObtenerEstructuras()
        {
            return EstructuraNegocio.ObtenerEstructuras();
        }


        #endregion FIN SERVICIO DE GESTION DE ESTRUCTURA

        #region  INICIO SERVICIO DE GESTION DE ESTRUCTURA-PERFIL

        public void InsertarEstructuraPerfil(string estructuraPerfilSerializada)
        {
            EstructuraPerfilNegocio.Insertar(estructuraPerfilSerializada);
        }

        public void ModificarEstructuraPerfil(string estructuraPerfilSerializada)
        {
            EstructuraPerfilNegocio.Modificar(estructuraPerfilSerializada);
        }

        public void EliminarEstructuraPerfil(string estructuraPerfilSerializada)
        {
            EstructuraPerfilNegocio.Eliminar(estructuraPerfilSerializada);
        }
        public string ObtenerEstructurasPerfilesPorIdPerfil(string idSerializado)
        {
            return EstructuraPerfilNegocio.ObtenerEstructurasPerfilesPorIdPerfil(idSerializado);
        }

        public string ObtenerEstructurasPerfilesPorIdEstructura(string idSerializado)
        {
            return EstructuraPerfilNegocio.ObtenerEstructurasPerfilesPorIdEstructura(idSerializado);
        }

        public string ObtenerEstructurasPerfilesPorEstado(bool estado)
        {
            return EstructuraPerfilNegocio.ObtenerEstructurasPerfilesPorEstado(estado);
        }

        public string ObtenerEstructurasPerfilesPorCoincidencia(string value, bool estado)
        {
            return EstructuraPerfilNegocio.ObtenerEstructurasPerfilesPorCoincidencia(value, estado);
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

        #endregion FIN SERVICIO DE GESTION DE ESTRUCTURA-PERFIL

        #region INICIO DE GESTION DE AUDITORIAS


        public string ObtenerAuditorias()
        {
            return AuditoriaNegocio.ObtenerAuditorias();
        }


        public string ObtenerAuditoriasPorCoincidencia(string value)
        {
            return AuditoriaNegocio.ObtenerAuditoriasPorCoincidencia(value);
        }

        public string ObtenerAuditoriasPorCoincidenciaPaginado(string value, int pageSize, int pageIndex, out int totalRegistros)
        {
            return AuditoriaNegocio.ObtenerAuditoriasPorCoincidenciaPaginado(value, pageSize, pageIndex, out totalRegistros);
        }

        public void InsertarAuditoria(string auditoriaSerializado)
        {
            AuditoriaNegocio.Insertar(auditoriaSerializado);
        }

        #endregion FIN DE GESTION DE AUDITORIAS

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





        public string ObtenerUsuariosPorCoincidencia(string value, string estado)
        {
            throw new NotImplementedException();
        }
    }
}
