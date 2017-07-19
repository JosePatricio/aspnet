
namespace Sigeor.Utilidades
{
    public class ConstantesUtil
    {
        #region INICIO TITULOS

        #region INICIO TITULOS DOCUMENTOS

        public const string TITULO_NUEVO_DOCUMENTO = "CARGAR DOCUMENTO";

        #endregion FIN TITULOS DOCUMENTOS

        #region INICIO TITULOS PERFILES

        public const string TITULO_NUEVO_PERFIL = "NUEVO PERFIL";
        public const string TITULO_EDITAR_PERFIl = "EDITAR PERFIL";

        #endregion FIN TITULOS PERFILES

        #region INICIO TITULOS Usuario

        public const string TITULO_NUEVO_USUARIO = "NUEVO USUARIO";
        public const string TITULO_EDITAR_USUARIO = "EDITAR USUARIO";

        #endregion FIN TITULOS Usuario

        #region INICIO TITULOS DANIOS

        public const string TITULO_NUEVO_DANIO = "NUEVO DAÑO";
        public const string TITULO_EDITAR_DANIO = "EDITAR DAÑO";

        #endregion FIN TITULOS DANIOS

        #region INICIO TITULOS REPARACIONES

        public const string TITULO_NUEVA_REPARACION = "NUEVA REPARACIÓN";
        public const string TITULO_EDITAR_REPARACION = "EDITAR REPARACIÓN";

        #endregion FIN TITULOS DANIOS

        #region INICIO TITULOS Estructura

        public const string TITULO_NUEVA_ESTRUCTURA = "AÑADIR MÓDULO";
        public const string ASIGNAR_ESTRUCTURA_A_PERFIL = "ASIGNAR Estructura A PERFIL";

        #endregion FIN TITULOS Estructura

        #region INICIO TITULOS NEGOCIACIONES

        public const string TITULO_NUEVA_NEGOCIACION = "NUEVA NEGOCIACIÓN";
        public const string TITULO_EDITAR_NEGOCIACION = "EDITAR NEGOCIACIÓN";

        #endregion FIN TITULOS NEGOCIACIONES

        #region INICIO TITULOS PROVEEDORES

        public const string TITULO_NUEVO_PROVEEDOR = "NUEVO PROVEEDOR";
        public const string TITULO_EDITAR_PROVEEDOR = "EDITAR PROVEEDOR";

        #endregion FIN TITULOS NEGOCIACIONES

        #endregion FIN TITULOS

        #region INICIO TIPO NOTIFICACIONES

        public const string NOTIFICACION_SUCCESS = "Success";
        public const string NOTIFICACION_INFO = "Info";
        public const string NOTIFICACION_WARNING = "Warning";
        public const string NOTIFICACION_ERROR = "Error";

        #endregion FIN TIPO NOTIFICACIONES

        #region INICIO CONTENIDO MENSAJES NOTIFICACIONES

        public const string mensajeRegistroGuardado = "{0} almacenado con éxito.";
        public const string mensajeRegistroModificado = "{0} modificado con éxito.";
        public const string mensajeRegistroEliminado = "{0} eliminado con éxito.";
        public const string mensajeNoSeEncontraronRegistros = "No se encontraron {0} disponibles.";
        public const string mensajeCampoObligatorio = "El campo {0} es obligatorio.";
        public const string mensajeUsuarioNoRegistrado = "Usuario y/o contraseña incorrecta.";
        public const string mensajeEmailNoRegistrado = "Email no registrado.";
        public const string mensajeBienvenidaUsuario = "Bienvenido, {0}";
        public const string mensajeClaveGenerada = "La clave fué generada y enviada a su email";
        public const string mensajeClavesDiferentes = "La clave ingresada es diferente a la confirmación";
        public const string mensajeClaveErronea = "La clave generada es no fué encontrada";
        public const string mensajeCorreoErroneo = "El correo ingresado tiene un formato erroneo o está duplicado";
        public const string mensajeCedulaErronea = "La cedula ingresada tiene un formato erroneo o está duplicada";
        public const string mensajeClularErroneo = "El número celular ingresado tiene un formato erroneo";
        public const string mensajeApellidoErroneo = "El apellido ingresado tiene un formato erroneo";
        public const string mensajeNombreErroneo = "El nombre ingresado tiene un formato erroneo";
        public const string mensajeEKeyGenerado = "La lista de coordenadas E-Key fue generada y enviada a su correo";
        public const string mensajeAgregarPerfilDuplicado = "El perfíl seleccionado ya se encuentra en la lista";
        public const string mensajeEliminarPerfil = "Debe existir por lo menos un perfil agregado a la lista";
        public const string mensajeCodigoDuplicado = "El código ingresado ya se encuentra registrado";
        public const string mensajePorcentajeFueraRango = "El porcentaje ingresado se encuentra fuera del rango permitido";
        public const string mensajeContraseniaNoGenerada = "Se presentó un error al generar la contraseña";
        public const string mensajeEkeyNoGenerado = "Se presentó un error al generar el e-key";
        public const string mensajeErrorEliminarRegistro = "Se presentó un error al eliminar el registro";
        public const string mensajeErrorAgregarRegistro = "Se presentó un error al agregar el registro";
        public const string mensajeIngreseUnPerfil = "Por favor seleccione un perfil";
        public const string mensajeFormatoNumericoIncorrecto = "{0} debe ser un valor numérico";

        #region INICIO DE MENSAJES DE ERRORES GENERALES DEL SISTEMA

        public const string MENSAJE_ERROR_LOAD = "No se pudo cargar la página de Gestión de {0}";
        public const string MENSAJE_ERROR_PRERENDER = "No se pudo aplicar la funcionalidad inicial de la pantalla";
        public const string MENSAJE_ERROR_CARGA_DATA = "No se pudo cargar los registros a visualizar";
        public const string MENSAJE_ERROR_ROWDATA_BOUND = "No se pudo agregar los estilos a cada fila de los registros";
        public const string MENSAJE_ERROR_PAGINACION = "No se pudo realizar la paginación de los registros";
        public const string MENSAJE_ERROR_PAGE_SIZE = "No se pudo realizar la carga de registros de acuerdo a al número de elementos seleccionado";
        public const string MENSAJE_ERROR_CARGA_COMBOS = "No se pudo cargar los combos para selección de datos";
        public const string MENSAJE_ERROR_ABRIR_DIALOGO_EDICION = "No se pudo abrir el diálogo para la edición del registro";
        public const string MENSAJE_ERROR_ABRIR_DIALOGO_NUEVO = "No se pudo abrir la ventana para crear un nuevo registro";
        public const string MENSAJE_ERROR_GUARDAR = "No se pudo guardar el registro";
        public const string MENSAJE_ERROR_BUSQUEDA_POR_COINCIDENCIAS = "No se pudo realizar la búsqueda por coincidencias";
        public const string MENSAJE_ERROR_BUSQUEDA_POR_ESTADO = "No se pudo realizar la búsqueda por estado";
        public const string MENSAJE_ERROR_EDICION_POR_ESTADO_GRIDVIEW = "No se pudo editar el estado del registro";
        public const string MENSAJE_ERROR_EDICION_POR_ESTADO_CABECERA = "No se pudo actualizar los estados de los registros visualizados";
        public const string MENSAJE_ERROR_NAVEGACION_MENU = "No se pudo navegar en el menú del sistema";
        public const string MENSAJE_ERROR_LOGOUT = "No se pudo terminar la sesión en el sistema";
        public const string MENSAJE_ERROR_CARGA_VARIABLES = "No se pudo instanciar las variables del constructor";
        public const string MENSAJE_ERROR_NAVEGAR_PAGINACION = "No se pudo paginar los registros";

        #endregion INICIO DE MENSAJES DE ERRORES GENERALES DEL SISTEMA


        #endregion  FIN CONSTANTES MENSAJES NOTIFICACIONES

        #region INICIO CONSTANTES EKEY
        public const string LETRAS = "ABCDEFGHIJ";
        public const string DIGITOS = "123456789";
        #endregion FIN CONSTANTES EKEY

        #region INICIO CONSTANTES URL'S PAGINAS
        public const string URL_LOGIN = "../Autenticacion/Login.aspx";
        public const string URL_RECUPERAR_CLAVE = "../Autenticacion/RecuperarClave.aspx";
        public const string URL_CAMBIAR_CLAVE = "../Autenticacion/CambiarClave.aspx";
        public const string URL_SESION_EXPIRADA = "../Autenticacion/SesionExpirada.aspx";
        public const string URL_ACCESO_NEGADO = "../Autenticacion/Denegado.aspx";

        public const string URL_MENU_PRINCIPAL = "../Menu/Principal.aspx";


        public const string URL_MENU_CONFIGURACION = "../Menu/MenuConfiguracion.aspx";
        public const string URL_GESTION_PERFILES = "../Configuracion/GestionPerfilesWebForm.aspx";
        public const string URL_GESTION_Usuario = "../Configuracion/GestionUsuariosWebForm.aspx";
        public const string URL_GESTION_MODULOS = "../Configuracion/GestionModulosWebForm.aspx";

        public const string URL_GESTION_AUDITORIA = "../Configuracion/GestionAuditoriasWebForm.aspx";

        public const string URL_GESTION_DOCUMENTOS = "../Configuracion/GestionDocumentosWebForm.aspx";
        public const string URL_GESTION_EMAIL = "../Configuracion/ConfiguracionEmailWebForm.aspx";
        public const string URL_ELIMINACION_REPARACIONES = "../Configuracion/EliminacionReparacionesWebForm.aspx";
        public const string URL_DIFERENCIA_VALORES_REPARACIONES = "../Configuracion/ConfiguracionProcesoWebForm.aspx";


        public const string URL_MENU_CONTROL = "../Menu/MenuControl.aspx";
        public const string URL_ESTIMACION_ESTRUCTURA = "../GestionControl/EstimacionEstructuraWebForm.aspx";
        public const string URL_ESTIMACION_MAQUINARIA = "../GestionControl/EstimacionMaquinariaWebForm.aspx";
        public const string URL_ESTIMACION_TRANSITO = "../GestionControl/EstimacionTransitoWebForm.aspx";
        public const string URL_GESTION_DANIOS = "../GestionControl/GestionDaniosWebForm.aspx";
        public const string URL_GESTION_REPARACIONES = "../GestionControl/GestionReparacionesWebForm.aspx";
        public const string URL_GESTION_NEGOCIACIONES_LINEA = "../GestionControl/GestionNegociacionesLineaWebForm.aspx";
        public const string URL_GESTION_NEGOCIACIONES_PROVEEDOR = "../GestionControl/GestionNegociacionesProveedorWebForm.aspx";
        public const string URL_GESTION_PROVEEDOR = "../GestionControl/GestionProveedorWebForm.aspx";

        public const string URL_ESTIMACION_EIR_DEPOSITO = "../ReportesAspx/EirDeposito.aspx";

        public const string URL_MENU_REPORTES = "../Menu/MenuReportes.aspx";

        public const string URL_ESTIMACION_EIR = "../ReportesAspx/EstimacionEirWebForm.aspx";
        public const string URL_REPORTE_CABECERA_EOR_ESTRUCTURA = "../ReportesAspx/EorCabeceraEstructuraWebForm.aspx";
        public const string URL_REPORTE_CABECERA_EOR_MAQUINARIA = "../ReportesAspx/EorCabeceraMaquinariaWebForm.aspx";
        public const string URL_REPORTE_CABECERA_EOR_TRANSITO = "../ReportesAspx/EorCabeceraTransitoWebForm.aspx";
        public const string URL_REPORTE_EIR_MAQUINARIA_PTI = "../ReportesAspx/EstimacionPtiWebForm.aspx";
        public const string URL_REPORTE_CONSOLIDADO_EOR = "../ReportesAspx/ConsolidadoEorsWebForm.aspx";

        public const string URL_VISOR_REPORTES = "../Reportes/VisorForm.aspx";

        #endregion FIN CONSTANTES URL'S PAGINAS


        #region INICIO DE POLITICAS

        public const string COD_POL_DEL = "COD_{0}";

        public const string NOM_POL_DEL = "POL_DEL_{0}";

        public const string DESC_POL_DEL = "POLITICA DE ELIMINACION DE EOR'S DE {0} DE ACUERDO A LAS FECHAS INGRESADAS";

        public const string GR_POL = "GR_POL_{0}";

        public const string COD_DIF_POL_REP = "DIF_{0}";

        public const string NOM_POL_REP = "POL_DIF_{0}";

        public const string DESC_POL_REP = "POLITICA PARA RESTAR UN VALOR DE LAS REP. PARA {0}";
        

        #endregion INICIO DE POLITICAS

    }
}