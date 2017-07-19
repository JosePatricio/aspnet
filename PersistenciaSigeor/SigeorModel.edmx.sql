
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/08/2016 18:18:24
-- Generated from EDMX file: D:\WORKSPACE\VS.NET\SIGEOR II-APPLICATION-WCF\PersistenciaSigeor\SigeorModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Sigeor];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[Adm].[fk_alerta_base_alerta]', 'F') IS NOT NULL
    ALTER TABLE [Adm].[Alerta] DROP CONSTRAINT [fk_alerta_base_alerta];
GO
IF OBJECT_ID(N'[Adm].[fk_alerta_relations_alerta]', 'F') IS NOT NULL
    ALTER TABLE [Adm].[Alerta] DROP CONSTRAINT [fk_alerta_relations_alerta];
GO
IF OBJECT_ID(N'[Adm].[FK_Auditoria_TipoAuditoria]', 'F') IS NOT NULL
    ALTER TABLE [Adm].[Auditoria] DROP CONSTRAINT [FK_Auditoria_TipoAuditoria];
GO
IF OBJECT_ID(N'[Adm].[FK_CoordenadasEkey_EKey]', 'F') IS NOT NULL
    ALTER TABLE [Adm].[CoordenadasEkey] DROP CONSTRAINT [FK_CoordenadasEkey_EKey];
GO
IF OBJECT_ID(N'[Adm].[FK_EKey_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [Adm].[EKey] DROP CONSTRAINT [FK_EKey_Usuario];
GO
IF OBJECT_ID(N'[Adm].[fk_estructuraperfil_estructura]', 'F') IS NOT NULL
    ALTER TABLE [Adm].[EstructuraPerfil] DROP CONSTRAINT [fk_estructuraperfil_estructura];
GO
IF OBJECT_ID(N'[Adm].[fk_estructuraperfil_perfil]', 'F') IS NOT NULL
    ALTER TABLE [Adm].[EstructuraPerfil] DROP CONSTRAINT [fk_estructuraperfil_perfil];
GO
IF OBJECT_ID(N'[Mgl].[FK_NegociacionLinea_M_LINEA]', 'F') IS NOT NULL
    ALTER TABLE [Mgl].[NegociacionLinea] DROP CONSTRAINT [FK_NegociacionLinea_M_LINEA];
GO
IF OBJECT_ID(N'[Mgl].[FK_NegociacionProveedor_Inv_M_Proveedor]', 'F') IS NOT NULL
    ALTER TABLE [Mgl].[NegociacionProveedor] DROP CONSTRAINT [FK_NegociacionProveedor_Inv_M_Proveedor];
GO
IF OBJECT_ID(N'[Mgl].[FK_NegociacionProveedor_M_DEPOSITO1]', 'F') IS NOT NULL
    ALTER TABLE [Mgl].[NegociacionProveedor] DROP CONSTRAINT [FK_NegociacionProveedor_M_DEPOSITO1];
GO
IF OBJECT_ID(N'[Adm].[fk_usuarioperfil_perfil1]', 'F') IS NOT NULL
    ALTER TABLE [Adm].[UsuarioPerfil] DROP CONSTRAINT [fk_usuarioperfil_perfil1];
GO
IF OBJECT_ID(N'[Adm].[fk_usuarioperfil_usuario]', 'F') IS NOT NULL
    ALTER TABLE [Adm].[UsuarioPerfil] DROP CONSTRAINT [fk_usuarioperfil_usuario];
GO
IF OBJECT_ID(N'[Adm].[FK_usuario_alerta]', 'F') IS NOT NULL
    ALTER TABLE [Adm].[Alerta] DROP CONSTRAINT [FK_usuario_alerta];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[Adm].[Alerta]', 'U') IS NOT NULL
    DROP TABLE [Adm].[Alerta];
GO
IF OBJECT_ID(N'[Adm].[Alerta_base]', 'U') IS NOT NULL
    DROP TABLE [Adm].[Alerta_base];
GO
IF OBJECT_ID(N'[Adm].[Auditoria]', 'U') IS NOT NULL
    DROP TABLE [Adm].[Auditoria];
GO
IF OBJECT_ID(N'[Adm].[CoordenadasEkey]', 'U') IS NOT NULL
    DROP TABLE [Adm].[CoordenadasEkey];
GO
IF OBJECT_ID(N'[Adm].[EKey]', 'U') IS NOT NULL
    DROP TABLE [Adm].[EKey];
GO
IF OBJECT_ID(N'[Adm].[Email]', 'U') IS NOT NULL
    DROP TABLE [Adm].[Email];
GO
IF OBJECT_ID(N'[Adm].[Estructura]', 'U') IS NOT NULL
    DROP TABLE [Adm].[Estructura];
GO
IF OBJECT_ID(N'[Adm].[EstructuraPerfil]', 'U') IS NOT NULL
    DROP TABLE [Adm].[EstructuraPerfil];
GO
IF OBJECT_ID(N'[Adm].[Perfil]', 'U') IS NOT NULL
    DROP TABLE [Adm].[Perfil];
GO
IF OBJECT_ID(N'[Adm].[TipoAuditoria]', 'U') IS NOT NULL
    DROP TABLE [Adm].[TipoAuditoria];
GO
IF OBJECT_ID(N'[Adm].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [Adm].[Usuario];
GO
IF OBJECT_ID(N'[Adm].[UsuarioPerfil]', 'U') IS NOT NULL
    DROP TABLE [Adm].[UsuarioPerfil];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[Mgl].[C_EIR]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[C_EIR];
GO
IF OBJECT_ID(N'[Mgl].[C_EORESTRUCTURA]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[C_EORESTRUCTURA];
GO
IF OBJECT_ID(N'[Mgl].[C_EORMAQUINARIA]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[C_EORMAQUINARIA];
GO
IF OBJECT_ID(N'[Mgl].[C_EORTRANSITO]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[C_EORTRANSITO];
GO
IF OBJECT_ID(N'[Mgl].[C_PTI]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[C_PTI];
GO
IF OBJECT_ID(N'[Mgl].[D_EORESTRUCTURA]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[D_EORESTRUCTURA];
GO
IF OBJECT_ID(N'[Mgl].[D_EORMAQUINARIA]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[D_EORMAQUINARIA];
GO
IF OBJECT_ID(N'[Mgl].[D_EORTRANSITO]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[D_EORTRANSITO];
GO
IF OBJECT_ID(N'[Mgl].[Documentos]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[Documentos];
GO
IF OBJECT_ID(N'[Mgl].[ESTADO_EIR]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[ESTADO_EIR];
GO
IF OBJECT_ID(N'[Mgl].[ESTIMATE_COMPONENT_CODE]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[ESTIMATE_COMPONENT_CODE];
GO
IF OBJECT_ID(N'[Mgl].[ESTIMATE_DAMAGE_CODE]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[ESTIMATE_DAMAGE_CODE];
GO
IF OBJECT_ID(N'[Mgl].[ESTIMATE_PARTY_RESPON]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[ESTIMATE_PARTY_RESPON];
GO
IF OBJECT_ID(N'[Mgl].[ESTIMATE_REPAIR_CODE]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[ESTIMATE_REPAIR_CODE];
GO
IF OBJECT_ID(N'[Mgl].[Inv_H_CEgrProducto]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[Inv_H_CEgrProducto];
GO
IF OBJECT_ID(N'[Mgl].[Inv_H_DEgrProducto]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[Inv_H_DEgrProducto];
GO
IF OBJECT_ID(N'[Mgl].[Inv_M_Producto]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[Inv_M_Producto];
GO
IF OBJECT_ID(N'[Mgl].[M_AGENCIA]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[M_AGENCIA];
GO
IF OBJECT_ID(N'[Mgl].[M_CONTAINER]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[M_CONTAINER];
GO
IF OBJECT_ID(N'[Mgl].[M_DEPOSITO]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[M_DEPOSITO];
GO
IF OBJECT_ID(N'[Mgl].[M_LINEA]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[M_LINEA];
GO
IF OBJECT_ID(N'[Mgl].[M_TIPCONTAINER]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[M_TIPCONTAINER];
GO
IF OBJECT_ID(N'[Mgl].[NegociacionLinea]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[NegociacionLinea];
GO
IF OBJECT_ID(N'[Mgl].[NegociacionProveedor]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[NegociacionProveedor];
GO
IF OBJECT_ID(N'[Mgl].[Proveedor]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[Proveedor];
GO
IF OBJECT_ID(N'[Mgl].[TipoMantenimiento]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[TipoMantenimiento];
GO
IF OBJECT_ID(N'[Mgl].[TipoReparacionEor]', 'U') IS NOT NULL
    DROP TABLE [Mgl].[TipoReparacionEor];
GO
IF OBJECT_ID(N'[SigeorModelStoreContainer].[ESTIMATE_UOM]', 'U') IS NOT NULL
    DROP TABLE [SigeorModelStoreContainer].[ESTIMATE_UOM];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Alertas'
CREATE TABLE [dbo].[Alertas] (
    [IdAlerta] int IDENTITY(1,1) NOT NULL,
    [NombreAlerta] char(1024)  NOT NULL,
    [FechaEmisionAlerta] datetime  NOT NULL,
    [Cedula] varchar(10)  NOT NULL,
    [ActivaAlerta] bit  NOT NULL,
    [IdAlertaBase] int  NULL,
    [IdTipoAlerta] int  NOT NULL,
    [IdAlertaPadre] int  NULL
);
GO

-- Creating table 'Alerta_base'
CREATE TABLE [dbo].[Alerta_base] (
    [IdAlertaBase] int IDENTITY(1,1) NOT NULL,
    [NombreAlertaBase] char(1024)  NOT NULL,
    [AliasAlertaBase] char(50)  NOT NULL,
    [IdTipoAlertaBase] char(1)  NOT NULL,
    [NombreCortoAlertaBase] char(1024)  NOT NULL
);
GO

-- Creating table 'Auditoria'
CREATE TABLE [dbo].[Auditoria] (
    [Id] uniqueidentifier  NOT NULL,
    [CodigoTipo] varchar(10)  NOT NULL,
    [Cedula] varchar(10)  NOT NULL,
    [Ip] varchar(50)  NULL,
    [Hora] varchar(8)  NOT NULL,
    [Fecha] varchar(10)  NOT NULL,
    [NomDescObjeto] varchar(250)  NOT NULL,
    [NombreTabla] varchar(100)  NOT NULL,
    [NombreCampo] varchar(100)  NOT NULL,
    [ValorAnterior] varchar(350)  NULL,
    [ValorActual] varchar(350)  NULL,
    [Descripcion] varchar(350)  NULL
);
GO

-- Creating table 'CoordenadasEkey'
CREATE TABLE [dbo].[CoordenadasEkey] (
    [Id] uniqueidentifier  NOT NULL,
    [IdEkey] uniqueidentifier  NOT NULL,
    [CoordenadaX] varchar(40)  NOT NULL,
    [CoordenadaY] varchar(40)  NOT NULL,
    [Valor] varchar(40)  NOT NULL
);
GO

-- Creating table 'EKey'
CREATE TABLE [dbo].[EKey] (
    [Id] uniqueidentifier  NOT NULL,
    [CedulaUsuario] varchar(10)  NOT NULL,
    [Fecha_Generacion] datetime  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'Email'
CREATE TABLE [dbo].[Email] (
    [Id] uniqueidentifier  NOT NULL,
    [DirEMail] varchar(250)  NOT NULL,
    [Password] varchar(250)  NOT NULL,
    [Puerto] smallint  NOT NULL,
    [Host] varchar(250)  NOT NULL,
    [Ssl] bit  NOT NULL
);
GO

-- Creating table 'Estructura'
CREATE TABLE [dbo].[Estructura] (
    [Id] uniqueidentifier  NOT NULL,
    [IdPadre] uniqueidentifier  NULL,
    [Codigo] varchar(10)  NOT NULL,
    [Url] varchar(250)  NOT NULL,
    [Descripcion] varchar(250)  NULL,
    [Orden] int  NULL,
    [Nivel] int  NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'EstructuraPerfil'
CREATE TABLE [dbo].[EstructuraPerfil] (
    [IdEstructura] uniqueidentifier  NOT NULL,
    [IdPerfil] uniqueidentifier  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'Perfil'
CREATE TABLE [dbo].[Perfil] (
    [Id] uniqueidentifier  NOT NULL,
    [Codigo] varchar(10)  NULL,
    [Descripcion] varchar(250)  NOT NULL,
    [Estado] bit  NOT NULL,
    [PaginaInicio] varchar(250)  NULL
);
GO

-- Creating table 'TipoAuditoria'
CREATE TABLE [dbo].[TipoAuditoria] (
    [Codigo] varchar(10)  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Descripcion] varchar(250)  NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [Cedula] varchar(10)  NOT NULL,
    [Nombre] varchar(30)  NOT NULL,
    [Apellido] varchar(30)  NOT NULL,
    [Direccion] varchar(50)  NULL,
    [Telefono] varchar(15)  NULL,
    [Celular] varchar(15)  NULL,
    [Email] varchar(50)  NULL,
    [NombreUsuario] varchar(30)  NOT NULL,
    [Contrasenia] varchar(40)  NULL,
    [Estado] bit  NULL,
    [OlvidoContrasenia] bit  NULL
);
GO

-- Creating table 'UsuarioPerfil'
CREATE TABLE [dbo].[UsuarioPerfil] (
    [IdPerfil] uniqueidentifier  NOT NULL,
    [Cedula] varchar(10)  NOT NULL,
    [Fecha] nchar(10)  NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'C_EIR'
CREATE TABLE [dbo].[C_EIR] (
    [ID_EIR] varchar(15)  NOT NULL,
    [COD_DEPOSITO] char(3)  NOT NULL,
    [COD_BL] varchar(25)  NULL,
    [ESTADO] char(1)  NULL,
    [TIPO_MOV] char(1)  NOT NULL,
    [CONDICION_EST] char(1)  NULL,
    [CONDICION_MAQ] char(1)  NULL,
    [IMPEXP] char(1)  NOT NULL,
    [PREF_CONTAINER] char(4)  NULL,
    [NUM_CONTAINER] char(7)  NULL,
    [COD_TIPCONT] varchar(4)  NULL,
    [COD_LINEA] varchar(4)  NULL,
    [COD_ITINERARIO] decimal(9,0)  NULL,
    [COD_EXPORTA] int  NULL,
    [COD_IMPORTA] int  NULL,
    [COD_TRANSPORTISTA] char(13)  NULL,
    [COD_PLACA] varchar(7)  NULL,
    [COD_TRAFICO] varchar(3)  NULL,
    [COD_CHOFER] varchar(13)  NULL,
    [COD_INSPECTOR] char(15)  NULL,
    [FECHA_EIR] datetime  NOT NULL,
    [HORA_EIR] char(8)  NULL,
    [ORIDEST] varchar(100)  NULL,
    [ORIGEN] char(5)  NULL,
    [DESTINO] char(5)  NULL,
    [COD_PRODUCTO] varchar(6)  NULL,
    [COD_MOV] char(2)  NULL,
    [ORDENAPG] varchar(50)  NULL,
    [FACTURA] int  NULL,
    [SELLO1] varchar(15)  NULL,
    [SELLO2] varchar(15)  NULL,
    [SELLO3] varchar(15)  NULL,
    [SELLO4] varchar(15)  NULL,
    [NUMGUIA] varchar(30)  NULL,
    [COD_CLASIFICA] char(2)  NULL,
    [ESTADO_EIR] int  NULL,
    [ESTADO_EIRMAQ] int  NULL,
    [PESO] decimal(10,2)  NULL,
    [TARA] decimal(10,2)  NULL,
    [MAXGROSSWEIGHT] decimal(10,2)  NULL,
    [PAYLOAD] decimal(10,2)  NULL,
    [OBSERVACIONES] varchar(255)  NULL,
    [SUSTENTO] varchar(max)  NULL,
    [COD_AGENCIA] char(10)  NULL,
    [CARGO] char(1)  NULL,
    [VALOR_CARGO] decimal(10,2)  NULL,
    [FECDISPASIG] datetime  NULL,
    [APROBASIGNA] char(1)  NULL,
    [USUASIGNA] varchar(15)  NULL,
    [FECHAAUTORIZAEST] datetime  NULL,
    [HORAAUTORIZAEST] char(8)  NULL,
    [FECHAREPARAEST] datetime  NULL,
    [HORAREPARAEST] char(8)  NULL,
    [FECHAAUTORIZAMAQ] datetime  NULL,
    [HORAAUTORIZAMAQ] char(8)  NULL,
    [FECHAREPARAMAQ] datetime  NULL,
    [HORAREPARAMAQ] char(8)  NULL,
    [USUARIO_CREA] varchar(15)  NULL,
    [FECHA_CREA] datetime  NULL,
    [USUARIO_MOD] varchar(15)  NULL,
    [FECHA_MOD] datetime  NULL,
    [NROCLIPPON] varchar(10)  NULL,
    [ALMANIP] char(1)  NULL,
    [TIPO_MANIPULEO] char(1)  NULL,
    [SECUALMANIP] decimal(10,0)  NULL,
    [TIPO_SELLO1] smallint  NULL,
    [TIPO_SELLO2] smallint  NULL,
    [TIPO_SELLO3] smallint  NULL,
    [TIPO_SELLO4] smallint  NULL,
    [TIPO_SELLO5] smallint  NULL,
    [MARCAALMA] decimal(10,0)  NULL,
    [MARCA_EIRANTE] char(1)  NULL,
    [MARCA_FLORENS] char(1)  NULL,
    [USUARIO_SUBE] varchar(15)  NULL,
    [FECHA_SUBE] datetime  NULL,
    [NRO_PRECLEAR] varchar(15)  NULL,
    [FECHAEXP_PRECLEAR] datetime  NULL,
    [FECHAEXP_BOOK] datetime  NULL,
    [NRO_BOOKING] varchar(25)  NULL,
    [NOMBFILEFLORENS] varchar(20)  NULL,
    [NOMBFILECCNI] varchar(50)  NULL,
    [NOMFILEFLORENSREPAIR] varchar(20)  NULL,
    [COD_GARITERO] char(15)  NULL,
    [ID_TIPOMANTE] int  NULL,
    [VALOR_MANTE] decimal(10,2)  NULL,
    [ID_MAQUINA] int  NULL,
    [FILE_EMC] varchar(50)  NULL,
    [SERVFACT] decimal(10,0)  NULL,
    [FECHA_FILEEMC] datetime  NULL,
    [ULTIMOACTIVO] char(1)  NULL,
    [NOMBFILEHANJIN] varchar(50)  NULL,
    [COMMODITY] varchar(150)  NULL,
    [NUM_PSD] varchar(20)  NULL,
    [FECHA_SALIDAPTO] datetime  NULL,
    [OBSERV_CUTOFF] varchar(300)  NULL,
    [ALMANIP_ITI] bit  NULL,
    [SECUALMANIP_ITI] decimal(18,0)  NULL,
    [FOOD_GRADE] bit  NULL,
    [DOC_SENAE] varchar(50)  NULL,
    [NACIONALIZADO] bit  NULL,
    [TRANSPORT_SAP] bit  NULL,
    [ORDEN_CMP_SAP] varchar(30)  NULL,
    [ORDEN_VTA_SAP] varchar(30)  NULL,
    [BOOKING_LINEA] varchar(30)  NULL
);
GO

-- Creating table 'C_EORESTRUCTURA'
CREATE TABLE [dbo].[C_EORESTRUCTURA] (
    [NUM_EOREST] varchar(13)  NOT NULL,
    [ID_EIR] varchar(15)  NOT NULL,
    [COD_DEPOSITO] char(3)  NOT NULL,
    [PREF_CONTAINER] char(4)  NULL,
    [NUM_CONTAINER] char(7)  NULL,
    [COD_INSPECTOR] char(15)  NULL,
    [FECHA_EOR] datetime  NULL,
    [COD_RESPONSABLE] varchar(15)  NULL,
    [COD_CONTRATISTA] smallint  NULL,
    [APROBADO] char(1)  NULL,
    [FECHA_APROBACION] datetime  NULL,
    [OBSERVACION] varchar(200)  NULL,
    [SUSTENTO] varchar(max)  NULL,
    [FECHA_INIREPARA] datetime  NULL,
    [HORA_INIREPARA] char(8)  NULL,
    [FECHA_FINREPARA] datetime  NULL,
    [HORA_FINREPARA] char(8)  NULL,
    [ESTADO] char(1)  NULL,
    [USUARIO_CREA] varchar(15)  NULL,
    [FECHA_CREACION] datetime  NULL,
    [USUARIO_MOD] varchar(15)  NULL,
    [FECHA_MOD] datetime  NULL,
    [TOTALEST] decimal(10,2)  NULL,
    [SECREVISION] decimal(18,0)  NULL,
    [ISO_CODE] varchar(5)  NULL,
    [COSTOMAOBRA] decimal(10,2)  NULL,
    [PAS_ESTIMADO] char(1)  NULL,
    [PAS_APROBADO] char(1)  NULL,
    [PAS_REPARADO] char(1)  NULL,
    [NUM_AUTORIZA] varchar(20)  NULL,
    [INICIO_IAS] char(1)  NULL,
    [NOMBFILECCNI] varchar(50)  NULL,
    [NOMBFILECCNI_EST] varchar(50)  NULL,
    [NOMBFILECCNI_REP] varchar(50)  NULL,
    [CNT_REPO] char(1)  NULL,
    [NOMBFILE_USER] varchar(50)  NULL,
    [NOMBFILEEMCFACT] varchar(50)  NULL,
    [FACTURA] varchar(7)  NULL,
    [FECHAFACTURA] datetime  NULL,
    [NOMBFILEEMCCR] varchar(50)  NULL,
    [NOMBDESTIM] varchar(50)  NULL,
    [REFERENCIA_IAS] varchar(50)  NULL,
    [COD_INSPECTOR1] char(15)  NULL,
    [COD_INSPECTOR2] char(15)  NULL,
    [COD_INSPECTOR3] char(15)  NULL,
    [NUM_EORLINEA] varchar(13)  NULL,
    [IMPRESO] char(1)  NULL,
    [FECHA_IMPRESION] datetime  NULL,
    [NOMBEDIREPAIR] varchar(50)  NULL,
    [TOTAL_REALMAT] decimal(10,2)  NULL,
    [TOTAL_COSTOHH] decimal(10,2)  NULL,
    [ESTADO_PROCESO] smallint  NULL,
    [TOTAL_REAL] decimal(10,2)  NULL
);
GO

-- Creating table 'C_EORMAQUINARIA'
CREATE TABLE [dbo].[C_EORMAQUINARIA] (
    [NUM_EORMAQ] varchar(13)  NOT NULL,
    [ID_EIR] varchar(15)  NOT NULL,
    [COD_DEPOSITO] char(3)  NOT NULL,
    [PREF_CONTAINER] char(4)  NULL,
    [NUM_CONTAINER] char(7)  NULL,
    [COD_INSPECTOR] char(15)  NULL,
    [FECHA_EORMAQ] datetime  NULL,
    [COD_RESPONSABLE] varchar(15)  NULL,
    [COD_CONTRATISTA] smallint  NULL,
    [APROBADO] char(1)  NULL,
    [FECHA_APROBACION] datetime  NULL,
    [OBSERVACION] varchar(200)  NULL,
    [SUSTENTO] varchar(max)  NULL,
    [FECHA_INIREPARA] datetime  NULL,
    [HORA_INIREPARA] char(8)  NULL,
    [FECHA_FINREPARA] datetime  NULL,
    [HORA_FINREPARA] char(8)  NULL,
    [ESTADO] char(1)  NULL,
    [USUARIO_CREA] varchar(15)  NULL,
    [FECHA_CREACION] datetime  NULL,
    [USUARIO_MOD] char(18)  NULL,
    [FECHA_MOD] datetime  NULL,
    [TOTALMAQ] decimal(10,2)  NULL,
    [SECREVISION] decimal(18,0)  NULL,
    [ISO_CODE] varchar(5)  NULL,
    [COSTOMAOBRA] decimal(10,2)  NULL,
    [PAS_ESTIMADO] char(1)  NULL,
    [PAS_APROBADO] char(1)  NULL,
    [PAS_REPARADO] char(1)  NULL,
    [NUM_AUTORIZA] varchar(20)  NULL,
    [INICIO_IAS] char(1)  NULL,
    [NOMBFILECCNI] varchar(50)  NULL,
    [NOMBFILECCNI_EST] varchar(50)  NULL,
    [NOMBFILECCNI_REP] varchar(50)  NULL,
    [CNT_REPO] char(1)  NULL,
    [NOMBFILE_USER] varchar(50)  NULL,
    [NOMBFILEEMCFACT] varchar(50)  NULL,
    [FACTURA] varchar(7)  NULL,
    [FECHAFACTURA] datetime  NULL,
    [NOMBFILEEMCCR] varchar(50)  NULL,
    [NOMBDESTIM] varchar(50)  NULL,
    [REFERENCIA_IAS] varchar(50)  NULL,
    [COD_TIPOSELLO] smallint  NULL,
    [SELLO] varchar(15)  NULL,
    [COD_INSPECTOR1] char(15)  NULL,
    [COD_INSPECTOR2] char(15)  NULL,
    [NUM_EORLINEA] varchar(13)  NULL,
    [IMPRESO] char(1)  NULL,
    [FECHA_IMPRESION] datetime  NULL,
    [NOMBEDIREPAIR] varchar(50)  NULL,
    [TOTAL_REALMAT] decimal(10,2)  NULL,
    [TOTAL_COSTOHH] decimal(10,2)  NULL,
    [ESTADO_PROCESO] smallint  NULL,
    [TOTAL_REAL] decimal(10,2)  NULL
);
GO

-- Creating table 'C_EORTRANSITO'
CREATE TABLE [dbo].[C_EORTRANSITO] (
    [NUM_EORTRANSITO] varchar(13)  NOT NULL,
    [PREF_CONTAINER] char(4)  NULL,
    [NUM_CONTAINER] char(7)  NULL,
    [COD_INSPECTOR] char(15)  NULL,
    [COD_RESPONSABLEEST] varchar(15)  NULL,
    [COD_RESPONSABLEMAQ] varchar(15)  NULL,
    [FECHA_EOR] datetime  NULL,
    [COD_CONTRATISTA] smallint  NULL,
    [APROBADOEST] char(1)  NULL,
    [APROBADOMAQ] char(1)  NULL,
    [FECHA_APROBACIONEST] datetime  NULL,
    [FECHA_APROBACIONMAQ] datetime  NULL,
    [OBSERVACION] varchar(200)  NULL,
    [SUSTENTO] varchar(max)  NULL,
    [SUSTENTOMAQ] varchar(max)  NULL,
    [FECHA_INIREPARAEST] datetime  NULL,
    [HORA_INIREPARAEST] char(8)  NULL,
    [FECHA_FINREPARAEST] datetime  NULL,
    [HORA_FINREPARAEST] char(8)  NULL,
    [FECHA_INIREPARAMAQ] datetime  NULL,
    [HORA_INIREPARAMAQ] char(8)  NULL,
    [FECHA_FINREPARAMAQ] datetime  NULL,
    [HORA_FINREPARAMAQ] char(8)  NULL,
    [ESTADOEST] int  NULL,
    [ESTADOMAQ] int  NULL,
    [USUARIO_CREA] varchar(15)  NULL,
    [FECHA_CREACION] datetime  NULL,
    [USUARIO_MOD] varchar(15)  NULL,
    [FECHA_MOD] datetime  NULL,
    [TOTALEST] decimal(10,2)  NULL,
    [TOTALMAQ] decimal(10,2)  NULL,
    [SECREVISION] decimal(18,0)  NULL,
    [ISO_CODE] varchar(5)  NULL,
    [PAS_ESTIMADO] char(1)  NULL,
    [PAS_APROBADO] char(1)  NULL,
    [PAS_REPARADO] char(1)  NULL,
    [NOMBFILEEST] varchar(100)  NULL,
    [NOMBFILEMAQ] varchar(100)  NULL,
    [TIPO] varchar(1)  NULL,
    [COD_DEPOSITO] varchar(3)  NULL,
    [NOMBDESTIM] varchar(50)  NULL,
    [NOMBEDIREPAIR] varchar(50)  NULL,
    [TOTAL_REALMAT] decimal(10,2)  NULL,
    [TOTAL_COSTOHH] decimal(10,2)  NULL,
    [TOTAL_REAL] decimal(10,2)  NULL,
    [ESTADO_PROCESO] smallint  NULL
);
GO

-- Creating table 'C_PTI'
CREATE TABLE [dbo].[C_PTI] (
    [ID_EIR] varchar(15)  NOT NULL,
    [COD_DEPOSITO] char(3)  NOT NULL,
    [NUM_PTI] decimal(9,0)  NOT NULL,
    [FECHA_PTI] datetime  NULL,
    [COD_INSPECTOR] char(15)  NULL,
    [COD_ATMOSFERA] smallint  NULL,
    [COD_FABRICANTE] varchar(6)  NULL,
    [COD_MODELO] smallint  NULL,
    [UNIDAD_SERIE] varchar(20)  NULL,
    [VOLTAJE] varchar(10)  NULL,
    [REFRIGERANTE] varchar(40)  NULL,
    [CANTIDADMAX] varchar(10)  NULL,
    [TEMPMAX] char(10)  NULL,
    [TEMPMIN] char(10)  NULL,
    [TEMPAMBIENTE] char(10)  NULL,
    [UNIDAD_SELECTOR] varchar(10)  NULL,
    [NUM_VALVULA] char(10)  NULL,
    [DISCO] char(1)  NULL,
    [HUMEDAD] char(1)  NULL,
    [ESTADO_MAQ] char(1)  NULL,
    [MES_FABRICA] varchar(25)  NULL,
    [ANIO_FABRICA] varchar(4)  NULL,
    [OBSERVACION] varchar(100)  NULL,
    [USUARIO_CREA] varchar(15)  NULL,
    [FECHA_CREA] datetime  NULL,
    [USUARIO_MOD] varchar(15)  NULL,
    [FECHA_MOD] datetime  NULL,
    [PEND_GARANTIA] char(1)  NULL,
    [SERVFACT] decimal(10,0)  NULL,
    [COD_TIPOSELLO] smallint  NULL,
    [SELLO] varchar(15)  NULL,
    [TOTALPTI] decimal(10,2)  NULL,
    [FLAME_TEST] varchar(3)  NULL,
    [RESULT_FLAME_TEST] char(1)  NULL
);
GO

-- Creating table 'D_EORESTRUCTURA'
CREATE TABLE [dbo].[D_EORESTRUCTURA] (
    [NUM_EOREST] varchar(13)  NOT NULL,
    [ID_EIR] varchar(15)  NOT NULL,
    [COD_DEPOSITO] char(3)  NOT NULL,
    [SECUENCIAL] decimal(10,0)  NOT NULL,
    [UBICA1] char(1)  NULL,
    [UBICA2] char(1)  NULL,
    [UBICA3] char(1)  NULL,
    [UBICA4] char(1)  NULL,
    [COD_UOM] char(3)  NULL,
    [COD_LINEA] varchar(4)  NULL,
    [COD_MATERIAL] char(2)  NULL,
    [COD_PARTY] char(1)  NULL,
    [COD_REPAIR] char(2)  NULL,
    [TIPO_DANIO] char(2)  NULL,
    [COD_DAMAGE] char(2)  NULL,
    [SUBGRUPO] char(5)  NULL,
    [COD_TIPOCOMPO] char(3)  NULL,
    [COD_ESTIMACOMPO] char(3)  NULL,
    [DETAREPARACION] varchar(200)  NULL,
    [LONGITUD] decimal(8,2)  NULL,
    [ANCHO] decimal(8,2)  NULL,
    [ALTO] decimal(8,2)  NULL,
    [CANTIDAD] smallint  NULL,
    [HORAS] decimal(8,2)  NULL,
    [COSTOMAOBRA] decimal(8,2)  NULL,
    [TOTALMAOBRA] decimal(8,2)  NULL,
    [COSTOMATERIAL] decimal(8,2)  NULL,
    [TOTALCOSTOMAT] decimal(8,2)  NULL,
    [TOTAL] decimal(10,2)  NULL,
    [ESTADO] char(1)  NULL,
    [CODPARTE] varchar(3)  NULL,
    [AproRepara] char(1)  NULL,
    [COD_RESPONSABLE] varchar(15)  NULL,
    [FECHA_APROBACION] datetime  NULL,
    [SUSTENTO] varchar(max)  NULL,
    [NUM_AUTORIZA] varchar(20)  NULL,
    [EDIT_WEB] bit  NULL,
    [EDIT_USUARIOWEB] varchar(50)  NULL,
    [EDIT_FECHAWEB] datetime  NULL
);
GO

-- Creating table 'D_EORMAQUINARIA'
CREATE TABLE [dbo].[D_EORMAQUINARIA] (
    [NUM_EORMAQ] varchar(13)  NOT NULL,
    [ID_EIR] varchar(15)  NOT NULL,
    [COD_DEPOSITO] char(3)  NOT NULL,
    [SECUENCIAL] decimal(10,0)  NOT NULL,
    [COD_LINEA] varchar(4)  NULL,
    [UBICA1] char(1)  NULL,
    [UBICA2] char(1)  NULL,
    [UBICA3] char(1)  NULL,
    [UBICA4] char(1)  NULL,
    [COD_UOM] char(3)  NULL,
    [COD_MATERIAL] char(2)  NULL,
    [COD_REPAIR] char(2)  NULL,
    [COD_PARTY] char(1)  NULL,
    [TIPO_DANIO] char(2)  NULL,
    [COD_DAMAGE] char(2)  NULL,
    [SUBGRUPO] char(5)  NULL,
    [COD_TIPOCOMPO] char(3)  NULL,
    [COD_ESTIMACOMPO] char(3)  NULL,
    [DETAREPARACION] varchar(200)  NULL,
    [LONGITUD] decimal(8,2)  NULL,
    [ANCHO] decimal(8,2)  NULL,
    [ALTO] decimal(8,2)  NULL,
    [CANTIDAD] smallint  NULL,
    [HORAS] decimal(8,2)  NULL,
    [COSTOMAOBRA] decimal(8,2)  NULL,
    [TOTALMAOBRA] decimal(8,2)  NULL,
    [COSTOMATERIAL] decimal(8,2)  NULL,
    [TOTALCOSTOMAT] decimal(8,2)  NULL,
    [TOTAL] decimal(10,2)  NULL,
    [ESTADO] char(1)  NULL,
    [CODPARTE] varchar(3)  NULL,
    [AproRepara] char(1)  NULL,
    [COD_RESPONSABLE] varchar(15)  NULL,
    [FECHA_APROBACION] datetime  NULL,
    [SUSTENTO] varchar(max)  NULL,
    [NUM_AUTORIZA] varchar(20)  NULL,
    [ID_PRODUCTO] varchar(15)  NULL,
    [EDIT_WEB] bit  NULL,
    [EDIT_USUARIOWEB] varchar(50)  NULL,
    [EDIT_FECHAWEB] datetime  NULL
);
GO

-- Creating table 'D_EORTRANSITO'
CREATE TABLE [dbo].[D_EORTRANSITO] (
    [NUM_EORTRANSITO] varchar(13)  NOT NULL,
    [TIPODETALLE] char(3)  NOT NULL,
    [SECUENCIA] decimal(10,0)  NOT NULL,
    [UBICA1] char(1)  NULL,
    [UBICA2] char(1)  NULL,
    [UBICA3] char(1)  NULL,
    [UBICA4] char(1)  NULL,
    [COD_UOM] char(3)  NULL,
    [COD_LINEA] varchar(4)  NULL,
    [COD_MATERIAL] char(2)  NULL,
    [COD_PARTY] char(1)  NULL,
    [COD_REPAIR] char(2)  NULL,
    [TIPO_DANIO] char(2)  NULL,
    [COD_DAMAGE] char(2)  NULL,
    [SUBGRUPO] char(5)  NULL,
    [COD_TIPOCOMPO] char(3)  NULL,
    [COD_ESTIMACOMPO] char(3)  NULL,
    [DETAREPARACION] varchar(200)  NULL,
    [LONGITUD] decimal(8,2)  NULL,
    [ANCHO] decimal(8,2)  NULL,
    [ALTO] decimal(8,2)  NULL,
    [CANTIDAD] smallint  NULL,
    [HORAS] decimal(8,2)  NULL,
    [COSTOMAOBRA] decimal(8,2)  NULL,
    [TOTALMAOBRA] decimal(8,2)  NULL,
    [COSTOMATERIAL] decimal(8,2)  NULL,
    [TOTALCOSTOMAT] decimal(8,2)  NULL,
    [TOTAL] decimal(10,2)  NULL,
    [ESTADO] char(1)  NULL,
    [ID_PRODUCTO] varchar(15)  NULL
);
GO

-- Creating table 'Documentos'
CREATE TABLE [dbo].[Documentos] (
    [Id] uniqueidentifier  NOT NULL,
    [IdRepositorio] uniqueidentifier  NOT NULL,
    [Cedula] varchar(10)  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Extension] varchar(10)  NOT NULL,
    [Tamano] float  NOT NULL,
    [Ubicacion] varchar(max)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'ESTADO_EIR'
CREATE TABLE [dbo].[ESTADO_EIR] (
    [ESTADO_EIR1] int  NOT NULL,
    [NOM_ESTADO] varchar(50)  NULL,
    [ESTADO] char(1)  NULL,
    [TIPO_ESTADO] char(1)  NULL
);
GO

-- Creating table 'ESTIMATE_COMPONENT_CODE'
CREATE TABLE [dbo].[ESTIMATE_COMPONENT_CODE] (
    [COD_TIPOCOMPO] char(3)  NOT NULL,
    [COD_ESTIMACOMPO] char(3)  NOT NULL,
    [SUBGRUPO] char(5)  NULL,
    [DESCRIPCION] varchar(100)  NULL,
    [LOCALIZACION] char(4)  NULL,
    [ESTADO] char(1)  NULL,
    [USUARIO_CREA] varchar(15)  NULL,
    [FECHA_CREACION] datetime  NULL,
    [USUARIO_MOD] varchar(15)  NULL,
    [FECHA_MOD] datetime  NULL,
    [C20DV] char(1)  NULL,
    [C20HC] char(1)  NULL,
    [C20IS] char(1)  NULL,
    [C20OT] char(1)  NULL,
    [C20RH] char(1)  NULL,
    [C20TK] char(1)  NULL,
    [C20FR] char(1)  NULL,
    [C20VT] char(1)  NULL,
    [C20FC] char(1)  NULL,
    [C20RF] char(1)  NULL,
    [C20FL] char(1)  NULL,
    [C40DV] char(1)  NULL,
    [C40FR] char(1)  NULL,
    [C40HC] char(1)  NULL,
    [C40IS] char(1)  NULL,
    [C40OT] char(1)  NULL,
    [C40RF] char(1)  NULL,
    [C40RH] char(1)  NULL,
    [C40FC] char(1)  NULL,
    [C40FL] char(1)  NULL,
    [C40TK] char(1)  NULL,
    [C40VT] char(1)  NULL,
    [EMCCODE] varchar(3)  NULL
);
GO

-- Creating table 'ESTIMATE_DAMAGE_CODE'
CREATE TABLE [dbo].[ESTIMATE_DAMAGE_CODE] (
    [COD_LINEA] varchar(4)  NOT NULL,
    [TIPO_DANIO] char(2)  NOT NULL,
    [COD_DAMAGE] char(2)  NOT NULL,
    [DESCRIP] varchar(50)  NULL,
    [TIPO_REPARACION] char(1)  NULL,
    [CANTHH] smallint  NULL,
    [ESTADO] char(1)  NOT NULL,
    [USUARIO_CREA] varchar(15)  NULL,
    [FECHA_CREACION] datetime  NULL,
    [USUARIO_MOD] varchar(15)  NULL,
    [FECHA_MOD] datetime  NULL,
    [EMCCode] varchar(3)  NULL
);
GO

-- Creating table 'ESTIMATE_PARTY_RESPON'
CREATE TABLE [dbo].[ESTIMATE_PARTY_RESPON] (
    [COD_PARTY] char(1)  NOT NULL,
    [DESCRIP] varchar(20)  NOT NULL,
    [ESTADO] char(1)  NOT NULL,
    [EmcCode] char(1)  NULL
);
GO

-- Creating table 'ESTIMATE_REPAIR_CODE'
CREATE TABLE [dbo].[ESTIMATE_REPAIR_CODE] (
    [COD_LINEA] varchar(4)  NOT NULL,
    [COD_REPAIR] char(2)  NOT NULL,
    [DESCRIP] varchar(50)  NULL,
    [ESTADO] char(1)  NOT NULL,
    [USUARIO_CREA] varchar(15)  NULL,
    [FECHA_CREACION] datetime  NULL,
    [USUARIO_MOD] varchar(15)  NULL,
    [FECHA_MOD] datetime  NULL,
    [EmcCode] varchar(3)  NULL,
    [COD_LINEA_BAK] varchar(5)  NULL,
    [COD_REPAIR_BAK] varchar(2)  NULL,
    [DESCRIP_BAK] varchar(50)  NULL,
    [ESTADO_BAK] char(1)  NULL
);
GO

-- Creating table 'Inv_H_CEgrProducto'
CREATE TABLE [dbo].[Inv_H_CEgrProducto] (
    [Id_EgrProducto] varchar(15)  NOT NULL,
    [Id_Proveedor] varchar(13)  NULL,
    [Cod_Deposito] char(3)  NULL,
    [Id_Bodega] int  NULL,
    [Id_TipoSalida] varchar(2)  NULL,
    [Resp_Recepcion] varchar(50)  NULL,
    [Num_Eor] varchar(13)  NULL,
    [Num_Eir] varchar(15)  NULL,
    [Pref_Container] varchar(4)  NULL,
    [Num_container] varchar(7)  NULL,
    [FechaSalida] datetime  NULL,
    [UsuarioCrea] varchar(15)  NULL,
    [FechaCrea] datetime  NULL,
    [obs] varchar(max)  NULL,
    [exportSAP] bit  NOT NULL,
    [numEgrSAP] varchar(50)  NULL,
    [fechaTransferSAP] datetime  NULL,
    [usuarioTransferSAP] varchar(50)  NULL,
    [codLinea] varchar(30)  NULL,
    [codServicio] varchar(30)  NULL
);
GO

-- Creating table 'Inv_H_DEgrProducto'
CREATE TABLE [dbo].[Inv_H_DEgrProducto] (
    [Id_EgrProducto] varchar(15)  NOT NULL,
    [Id_SecEgreso] int  NOT NULL,
    [Cod_deposito] char(3)  NULL,
    [id_bodega] int  NULL,
    [id_producto] varchar(15)  NULL,
    [tipo] char(1)  NULL,
    [Cantidad] decimal(12,4)  NULL,
    [Costo] decimal(12,4)  NULL,
    [Total] decimal(12,4)  NULL,
    [Costo_Iva] decimal(12,4)  NULL,
    [Total_iva] decimal(12,4)  NULL,
    [id_Secdanio] int  NULL,
    [CostoReal] decimal(12,4)  NULL,
    [CantidadReal] int  NULL
);
GO

-- Creating table 'Inv_M_Producto'
CREATE TABLE [dbo].[Inv_M_Producto] (
    [id_Producto] varchar(15)  NOT NULL,
    [id_categoria1] varchar(4)  NULL,
    [Id_categoria2] varchar(4)  NULL,
    [Id_Categoria3] varchar(4)  NULL,
    [Id_TipoProducto] int  NULL,
    [Id_TipoCompo] varchar(3)  NULL,
    [Id_TipoMedida] int  NULL,
    [Completo] varchar(1)  NULL,
    [Area] decimal(8,2)  NULL,
    [Nombre] varchar(50)  NULL,
    [PtoReorden] decimal(8,2)  NULL,
    [Pvp] decimal(12,4)  NULL,
    [Observacion] varchar(80)  NULL,
    [UsuarioCrea] varchar(15)  NULL,
    [FechaCrea] datetime  NULL,
    [UsuarioModifica] varchar(15)  NULL,
    [FechaModifica] datetime  NULL,
    [NroParte] varchar(30)  NULL,
    [COD_SAP] varchar(30)  NULL
);
GO

-- Creating table 'M_AGENCIA'
CREATE TABLE [dbo].[M_AGENCIA] (
    [COD_AGENCIA] char(10)  NOT NULL,
    [NOMBRE_AGENCIA] varchar(50)  NULL,
    [ESTADO] char(1)  NULL,
    [CAMPO_COD1] varchar(15)  NULL,
    [CAMPO_COD2] varchar(15)  NULL,
    [EMAIL] varchar(200)  NULL
);
GO

-- Creating table 'M_CONTAINER'
CREATE TABLE [dbo].[M_CONTAINER] (
    [PREF_CONTAINER] char(4)  NOT NULL,
    [NUM_CONTAINER] char(7)  NOT NULL,
    [COD_TIPCONT] varchar(4)  NOT NULL,
    [COD_LINEA] varchar(4)  NOT NULL,
    [TAMAÑO] char(2)  NOT NULL,
    [TARA] decimal(7,2)  NULL,
    [COD_CONTAINER1] varchar(15)  NULL,
    [COD_CONTAINER2] varchar(15)  NULL,
    [COD_CONTAINER3] varchar(15)  NULL,
    [ESTADO] char(1)  NOT NULL,
    [USUARIO_CREA] varchar(15)  NOT NULL,
    [FECHA_CREACION] datetime  NOT NULL,
    [USUARIO_MOD] varchar(15)  NULL,
    [FECHA_MOD] datetime  NULL,
    [PROVEEDOR] char(1)  NULL,
    [MESFABRICA] char(15)  NULL,
    [ANIOFABRICA] char(4)  NULL,
    [MAXGROSSW] decimal(10,2)  NULL,
    [PAYLOAD] decimal(10,2)  NULL,
    [PESO] decimal(10,2)  NULL,
    [SECU_CONEX] decimal(10,0)  NULL,
    [ESTADO_CONEX] char(1)  NULL,
    [NOVALIDA_ISO] char(1)  NULL,
    [ISO_CODE] char(4)  NULL
);
GO

-- Creating table 'M_DEPOSITO'
CREATE TABLE [dbo].[M_DEPOSITO] (
    [COD_DEPOSITO] char(3)  NOT NULL,
    [NOMBRE_DEPOSITO] varchar(30)  NOT NULL,
    [DESCRIPCION] varchar(30)  NULL,
    [DIRECCION] varchar(100)  NULL,
    [ESTADO] char(1)  NOT NULL,
    [CIUDAD] char(5)  NULL,
    [MOSTREPSELLO] char(1)  NULL,
    [DEPOGENFILE] varchar(10)  NULL,
    [MARCA_DEPORPTALMA] char(1)  NULL,
    [CodIas] varchar(50)  NULL,
    [ISDEPOT] bit  NOT NULL
);
GO

-- Creating table 'M_LINEA'
CREATE TABLE [dbo].[M_LINEA] (
    [COD_LINEA] varchar(4)  NOT NULL,
    [NOM_LINEA] varchar(50)  NOT NULL,
    [DESC_LINEA] varchar(100)  NULL,
    [COD_COMERCIAL] varchar(4)  NULL,
    [COD_LINEA1] varchar(15)  NULL,
    [COD_LINEA2] varchar(15)  NULL,
    [COD_LINEA3] varchar(15)  NULL,
    [ESTADO] char(1)  NOT NULL,
    [LOG_LINEA] varbinary(max)  NULL,
    [ASIGPAGDANOP] char(1)  NULL,
    [MOSTREPSELLO] char(1)  NULL,
    [LINEGENFILE] varchar(10)  NULL,
    [REPARADEPOT] char(1)  NULL,
    [COD_SAP] varchar(50)  NULL,
    [COD_CLISAP] varchar(50)  NULL
);
GO

-- Creating table 'M_TIPCONTAINER'
CREATE TABLE [dbo].[M_TIPCONTAINER] (
    [COD_TIPCONT] varchar(4)  NOT NULL,
    [NOM_TIPCONT] varchar(50)  NOT NULL,
    [DES_TIPCONT] varchar(50)  NULL,
    [VAL_TARA] decimal(7,2)  NULL,
    [COD_TIPCONT1] varchar(15)  NULL,
    [COD_TIPCONT2] varchar(15)  NULL,
    [COD_TIPCONT3] varchar(15)  NULL,
    [ESREEFER] char(1)  NULL,
    [ESTADO] char(1)  NOT NULL,
    [TIP_CONECTADO] char(1)  NULL,
    [TIPO_EQUIPO] varchar(3)  NULL,
    [TIPO_EQUIPOFLOR] varchar(3)  NULL
);
GO

-- Creating table 'NegociacionLinea'
CREATE TABLE [dbo].[NegociacionLinea] (
    [Id] uniqueidentifier  NOT NULL,
    [CodLinea] varchar(4)  NOT NULL,
    [Codigo] varchar(10)  NOT NULL,
    [Descripcion] varchar(250)  NULL,
    [CostoHHEstructura] decimal(8,2)  NOT NULL,
    [CostoHHMaquinaria] decimal(8,2)  NOT NULL,
    [PorcentajeNegociacion] decimal(8,2)  NOT NULL,
    [UsuarioCrea] varchar(15)  NOT NULL,
    [FechaCrea] datetime  NOT NULL,
    [UsuarioMod] varchar(15)  NULL,
    [FechaMod] datetime  NULL,
    [Estado] bit  NOT NULL,
    [FechaInicioVal] datetime  NOT NULL,
    [FechaFinVal] datetime  NOT NULL
);
GO

-- Creating table 'NegociacionProveedor'
CREATE TABLE [dbo].[NegociacionProveedor] (
    [Id] uniqueidentifier  NOT NULL,
    [IdProveedor] varchar(13)  NOT NULL,
    [IdDeposito] char(3)  NOT NULL,
    [Descripcion] varchar(250)  NULL,
    [CostoHHEstructura] decimal(8,2)  NOT NULL,
    [CostoHHMaquinaria] decimal(8,2)  NOT NULL,
    [PorcentajeNegociacion] decimal(8,2)  NOT NULL,
    [UsuarioCrea] varchar(15)  NOT NULL,
    [FechaCrea] datetime  NOT NULL,
    [UsuarioModifica] varchar(15)  NULL,
    [FechaModifica] datetime  NULL,
    [EsPorcentual] bit  NOT NULL,
    [Estado] bit  NOT NULL,
    [FechaInicioVal] datetime  NOT NULL,
    [FechaFinVal] datetime  NOT NULL
);
GO

-- Creating table 'Proveedor'
CREATE TABLE [dbo].[Proveedor] (
    [Id_Proveedor] varchar(13)  NOT NULL,
    [Nombre] varchar(50)  NULL,
    [Estado] varchar(1)  NULL,
    [Representante] varchar(50)  NULL,
    [Telefono] varchar(10)  NULL,
    [Fax] varchar(15)  NULL,
    [Minimo_Dias] int  NULL,
    [Maximo_Dias] int  NULL,
    [UsuarioCrea] varchar(15)  NULL,
    [FechaCrea] datetime  NULL,
    [UsuarioModifica] varchar(15)  NULL,
    [FechaModifica] datetime  NULL,
    [Porcent_Dcto] int  NULL
);
GO

-- Creating table 'TipoMantenimientoes'
CREATE TABLE [dbo].[TipoMantenimientoes] (
    [ID_TIPOMANTE] int IDENTITY(1,1) NOT NULL,
    [NOMBRE_MANTE] varchar(100)  NOT NULL,
    [VALOR_MANTE] decimal(10,2)  NOT NULL,
    [ESTADO] char(1)  NOT NULL,
    [USUARIO_CREA] varchar(15)  NOT NULL,
    [FECHA_CREACION] datetime  NOT NULL,
    [USUARIO_MOD] varchar(15)  NULL,
    [FECHA_MOD] datetime  NULL
);
GO

-- Creating table 'TipoReparacionEor'
CREATE TABLE [dbo].[TipoReparacionEor] (
    [Id] uniqueidentifier  NOT NULL,
    [Codigo] varchar(10)  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Descripcion] varchar(250)  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'ESTIMATE_UOM'
CREATE TABLE [dbo].[ESTIMATE_UOM] (
    [COD_UOM] char(3)  NOT NULL,
    [DESCRIP] varchar(20)  NULL,
    [ESTADO] char(1)  NOT NULL,
    [EmcCode] varchar(3)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdAlerta] in table 'Alertas'
ALTER TABLE [dbo].[Alertas]
ADD CONSTRAINT [PK_Alertas]
    PRIMARY KEY CLUSTERED ([IdAlerta] ASC);
GO

-- Creating primary key on [IdAlertaBase] in table 'Alerta_base'
ALTER TABLE [dbo].[Alerta_base]
ADD CONSTRAINT [PK_Alerta_base]
    PRIMARY KEY CLUSTERED ([IdAlertaBase] ASC);
GO

-- Creating primary key on [Id] in table 'Auditoria'
ALTER TABLE [dbo].[Auditoria]
ADD CONSTRAINT [PK_Auditoria]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CoordenadasEkey'
ALTER TABLE [dbo].[CoordenadasEkey]
ADD CONSTRAINT [PK_CoordenadasEkey]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EKey'
ALTER TABLE [dbo].[EKey]
ADD CONSTRAINT [PK_EKey]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Email'
ALTER TABLE [dbo].[Email]
ADD CONSTRAINT [PK_Email]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Estructura'
ALTER TABLE [dbo].[Estructura]
ADD CONSTRAINT [PK_Estructura]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdEstructura], [IdPerfil] in table 'EstructuraPerfil'
ALTER TABLE [dbo].[EstructuraPerfil]
ADD CONSTRAINT [PK_EstructuraPerfil]
    PRIMARY KEY CLUSTERED ([IdEstructura], [IdPerfil] ASC);
GO

-- Creating primary key on [Id] in table 'Perfil'
ALTER TABLE [dbo].[Perfil]
ADD CONSTRAINT [PK_Perfil]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Codigo] in table 'TipoAuditoria'
ALTER TABLE [dbo].[TipoAuditoria]
ADD CONSTRAINT [PK_TipoAuditoria]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Cedula] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([Cedula] ASC);
GO

-- Creating primary key on [IdPerfil], [Cedula] in table 'UsuarioPerfil'
ALTER TABLE [dbo].[UsuarioPerfil]
ADD CONSTRAINT [PK_UsuarioPerfil]
    PRIMARY KEY CLUSTERED ([IdPerfil], [Cedula] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID_EIR], [COD_DEPOSITO] in table 'C_EIR'
ALTER TABLE [dbo].[C_EIR]
ADD CONSTRAINT [PK_C_EIR]
    PRIMARY KEY CLUSTERED ([ID_EIR], [COD_DEPOSITO] ASC);
GO

-- Creating primary key on [NUM_EOREST], [ID_EIR], [COD_DEPOSITO] in table 'C_EORESTRUCTURA'
ALTER TABLE [dbo].[C_EORESTRUCTURA]
ADD CONSTRAINT [PK_C_EORESTRUCTURA]
    PRIMARY KEY CLUSTERED ([NUM_EOREST], [ID_EIR], [COD_DEPOSITO] ASC);
GO

-- Creating primary key on [NUM_EORMAQ], [ID_EIR], [COD_DEPOSITO] in table 'C_EORMAQUINARIA'
ALTER TABLE [dbo].[C_EORMAQUINARIA]
ADD CONSTRAINT [PK_C_EORMAQUINARIA]
    PRIMARY KEY CLUSTERED ([NUM_EORMAQ], [ID_EIR], [COD_DEPOSITO] ASC);
GO

-- Creating primary key on [NUM_EORTRANSITO] in table 'C_EORTRANSITO'
ALTER TABLE [dbo].[C_EORTRANSITO]
ADD CONSTRAINT [PK_C_EORTRANSITO]
    PRIMARY KEY CLUSTERED ([NUM_EORTRANSITO] ASC);
GO

-- Creating primary key on [ID_EIR], [COD_DEPOSITO], [NUM_PTI] in table 'C_PTI'
ALTER TABLE [dbo].[C_PTI]
ADD CONSTRAINT [PK_C_PTI]
    PRIMARY KEY CLUSTERED ([ID_EIR], [COD_DEPOSITO], [NUM_PTI] ASC);
GO

-- Creating primary key on [NUM_EOREST], [ID_EIR], [COD_DEPOSITO], [SECUENCIAL] in table 'D_EORESTRUCTURA'
ALTER TABLE [dbo].[D_EORESTRUCTURA]
ADD CONSTRAINT [PK_D_EORESTRUCTURA]
    PRIMARY KEY CLUSTERED ([NUM_EOREST], [ID_EIR], [COD_DEPOSITO], [SECUENCIAL] ASC);
GO

-- Creating primary key on [NUM_EORMAQ], [ID_EIR], [COD_DEPOSITO], [SECUENCIAL] in table 'D_EORMAQUINARIA'
ALTER TABLE [dbo].[D_EORMAQUINARIA]
ADD CONSTRAINT [PK_D_EORMAQUINARIA]
    PRIMARY KEY CLUSTERED ([NUM_EORMAQ], [ID_EIR], [COD_DEPOSITO], [SECUENCIAL] ASC);
GO

-- Creating primary key on [NUM_EORTRANSITO], [TIPODETALLE], [SECUENCIA] in table 'D_EORTRANSITO'
ALTER TABLE [dbo].[D_EORTRANSITO]
ADD CONSTRAINT [PK_D_EORTRANSITO]
    PRIMARY KEY CLUSTERED ([NUM_EORTRANSITO], [TIPODETALLE], [SECUENCIA] ASC);
GO

-- Creating primary key on [Id] in table 'Documentos'
ALTER TABLE [dbo].[Documentos]
ADD CONSTRAINT [PK_Documentos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ESTADO_EIR1] in table 'ESTADO_EIR'
ALTER TABLE [dbo].[ESTADO_EIR]
ADD CONSTRAINT [PK_ESTADO_EIR]
    PRIMARY KEY CLUSTERED ([ESTADO_EIR1] ASC);
GO

-- Creating primary key on [COD_TIPOCOMPO], [COD_ESTIMACOMPO] in table 'ESTIMATE_COMPONENT_CODE'
ALTER TABLE [dbo].[ESTIMATE_COMPONENT_CODE]
ADD CONSTRAINT [PK_ESTIMATE_COMPONENT_CODE]
    PRIMARY KEY CLUSTERED ([COD_TIPOCOMPO], [COD_ESTIMACOMPO] ASC);
GO

-- Creating primary key on [COD_LINEA], [TIPO_DANIO], [COD_DAMAGE] in table 'ESTIMATE_DAMAGE_CODE'
ALTER TABLE [dbo].[ESTIMATE_DAMAGE_CODE]
ADD CONSTRAINT [PK_ESTIMATE_DAMAGE_CODE]
    PRIMARY KEY CLUSTERED ([COD_LINEA], [TIPO_DANIO], [COD_DAMAGE] ASC);
GO

-- Creating primary key on [COD_PARTY] in table 'ESTIMATE_PARTY_RESPON'
ALTER TABLE [dbo].[ESTIMATE_PARTY_RESPON]
ADD CONSTRAINT [PK_ESTIMATE_PARTY_RESPON]
    PRIMARY KEY CLUSTERED ([COD_PARTY] ASC);
GO

-- Creating primary key on [COD_LINEA], [COD_REPAIR] in table 'ESTIMATE_REPAIR_CODE'
ALTER TABLE [dbo].[ESTIMATE_REPAIR_CODE]
ADD CONSTRAINT [PK_ESTIMATE_REPAIR_CODE]
    PRIMARY KEY CLUSTERED ([COD_LINEA], [COD_REPAIR] ASC);
GO

-- Creating primary key on [Id_EgrProducto] in table 'Inv_H_CEgrProducto'
ALTER TABLE [dbo].[Inv_H_CEgrProducto]
ADD CONSTRAINT [PK_Inv_H_CEgrProducto]
    PRIMARY KEY CLUSTERED ([Id_EgrProducto] ASC);
GO

-- Creating primary key on [Id_EgrProducto], [Id_SecEgreso] in table 'Inv_H_DEgrProducto'
ALTER TABLE [dbo].[Inv_H_DEgrProducto]
ADD CONSTRAINT [PK_Inv_H_DEgrProducto]
    PRIMARY KEY CLUSTERED ([Id_EgrProducto], [Id_SecEgreso] ASC);
GO

-- Creating primary key on [id_Producto] in table 'Inv_M_Producto'
ALTER TABLE [dbo].[Inv_M_Producto]
ADD CONSTRAINT [PK_Inv_M_Producto]
    PRIMARY KEY CLUSTERED ([id_Producto] ASC);
GO

-- Creating primary key on [COD_AGENCIA] in table 'M_AGENCIA'
ALTER TABLE [dbo].[M_AGENCIA]
ADD CONSTRAINT [PK_M_AGENCIA]
    PRIMARY KEY CLUSTERED ([COD_AGENCIA] ASC);
GO

-- Creating primary key on [PREF_CONTAINER], [NUM_CONTAINER] in table 'M_CONTAINER'
ALTER TABLE [dbo].[M_CONTAINER]
ADD CONSTRAINT [PK_M_CONTAINER]
    PRIMARY KEY CLUSTERED ([PREF_CONTAINER], [NUM_CONTAINER] ASC);
GO

-- Creating primary key on [COD_DEPOSITO] in table 'M_DEPOSITO'
ALTER TABLE [dbo].[M_DEPOSITO]
ADD CONSTRAINT [PK_M_DEPOSITO]
    PRIMARY KEY CLUSTERED ([COD_DEPOSITO] ASC);
GO

-- Creating primary key on [COD_LINEA] in table 'M_LINEA'
ALTER TABLE [dbo].[M_LINEA]
ADD CONSTRAINT [PK_M_LINEA]
    PRIMARY KEY CLUSTERED ([COD_LINEA] ASC);
GO

-- Creating primary key on [COD_TIPCONT] in table 'M_TIPCONTAINER'
ALTER TABLE [dbo].[M_TIPCONTAINER]
ADD CONSTRAINT [PK_M_TIPCONTAINER]
    PRIMARY KEY CLUSTERED ([COD_TIPCONT] ASC);
GO

-- Creating primary key on [Id] in table 'NegociacionLinea'
ALTER TABLE [dbo].[NegociacionLinea]
ADD CONSTRAINT [PK_NegociacionLinea]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NegociacionProveedor'
ALTER TABLE [dbo].[NegociacionProveedor]
ADD CONSTRAINT [PK_NegociacionProveedor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id_Proveedor] in table 'Proveedor'
ALTER TABLE [dbo].[Proveedor]
ADD CONSTRAINT [PK_Proveedor]
    PRIMARY KEY CLUSTERED ([Id_Proveedor] ASC);
GO

-- Creating primary key on [ID_TIPOMANTE] in table 'TipoMantenimientoes'
ALTER TABLE [dbo].[TipoMantenimientoes]
ADD CONSTRAINT [PK_TipoMantenimientoes]
    PRIMARY KEY CLUSTERED ([ID_TIPOMANTE] ASC);
GO

-- Creating primary key on [Id] in table 'TipoReparacionEor'
ALTER TABLE [dbo].[TipoReparacionEor]
ADD CONSTRAINT [PK_TipoReparacionEor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [COD_UOM], [ESTADO] in table 'ESTIMATE_UOM'
ALTER TABLE [dbo].[ESTIMATE_UOM]
ADD CONSTRAINT [PK_ESTIMATE_UOM]
    PRIMARY KEY CLUSTERED ([COD_UOM], [ESTADO] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdAlertaBase] in table 'Alertas'
ALTER TABLE [dbo].[Alertas]
ADD CONSTRAINT [fk_alerta_base_alerta]
    FOREIGN KEY ([IdAlertaBase])
    REFERENCES [dbo].[Alerta_base]
        ([IdAlertaBase])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_alerta_base_alerta'
CREATE INDEX [IX_fk_alerta_base_alerta]
ON [dbo].[Alertas]
    ([IdAlertaBase]);
GO

-- Creating foreign key on [IdAlertaPadre] in table 'Alertas'
ALTER TABLE [dbo].[Alertas]
ADD CONSTRAINT [fk_alerta_relations_alerta]
    FOREIGN KEY ([IdAlertaPadre])
    REFERENCES [dbo].[Alertas]
        ([IdAlerta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_alerta_relations_alerta'
CREATE INDEX [IX_fk_alerta_relations_alerta]
ON [dbo].[Alertas]
    ([IdAlertaPadre]);
GO

-- Creating foreign key on [Cedula] in table 'Alertas'
ALTER TABLE [dbo].[Alertas]
ADD CONSTRAINT [FK_usuario_alerta]
    FOREIGN KEY ([Cedula])
    REFERENCES [dbo].[Usuario]
        ([Cedula])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_usuario_alerta'
CREATE INDEX [IX_FK_usuario_alerta]
ON [dbo].[Alertas]
    ([Cedula]);
GO

-- Creating foreign key on [CodigoTipo] in table 'Auditoria'
ALTER TABLE [dbo].[Auditoria]
ADD CONSTRAINT [FK_Auditoria_TipoAuditoria]
    FOREIGN KEY ([CodigoTipo])
    REFERENCES [dbo].[TipoAuditoria]
        ([Codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Auditoria_TipoAuditoria'
CREATE INDEX [IX_FK_Auditoria_TipoAuditoria]
ON [dbo].[Auditoria]
    ([CodigoTipo]);
GO

-- Creating foreign key on [IdEkey] in table 'CoordenadasEkey'
ALTER TABLE [dbo].[CoordenadasEkey]
ADD CONSTRAINT [FK_CoordenadasEkey_EKey]
    FOREIGN KEY ([IdEkey])
    REFERENCES [dbo].[EKey]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoordenadasEkey_EKey'
CREATE INDEX [IX_FK_CoordenadasEkey_EKey]
ON [dbo].[CoordenadasEkey]
    ([IdEkey]);
GO

-- Creating foreign key on [CedulaUsuario] in table 'EKey'
ALTER TABLE [dbo].[EKey]
ADD CONSTRAINT [FK_EKey_Usuario]
    FOREIGN KEY ([CedulaUsuario])
    REFERENCES [dbo].[Usuario]
        ([Cedula])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EKey_Usuario'
CREATE INDEX [IX_FK_EKey_Usuario]
ON [dbo].[EKey]
    ([CedulaUsuario]);
GO

-- Creating foreign key on [IdEstructura] in table 'EstructuraPerfil'
ALTER TABLE [dbo].[EstructuraPerfil]
ADD CONSTRAINT [fk_estructuraperfil_estructura]
    FOREIGN KEY ([IdEstructura])
    REFERENCES [dbo].[Estructura]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdPerfil] in table 'EstructuraPerfil'
ALTER TABLE [dbo].[EstructuraPerfil]
ADD CONSTRAINT [fk_estructuraperfil_perfil]
    FOREIGN KEY ([IdPerfil])
    REFERENCES [dbo].[Perfil]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_estructuraperfil_perfil'
CREATE INDEX [IX_fk_estructuraperfil_perfil]
ON [dbo].[EstructuraPerfil]
    ([IdPerfil]);
GO

-- Creating foreign key on [IdPerfil] in table 'UsuarioPerfil'
ALTER TABLE [dbo].[UsuarioPerfil]
ADD CONSTRAINT [fk_usuarioperfil_perfil1]
    FOREIGN KEY ([IdPerfil])
    REFERENCES [dbo].[Perfil]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Cedula] in table 'UsuarioPerfil'
ALTER TABLE [dbo].[UsuarioPerfil]
ADD CONSTRAINT [fk_usuarioperfil_usuario]
    FOREIGN KEY ([Cedula])
    REFERENCES [dbo].[Usuario]
        ([Cedula])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_usuarioperfil_usuario'
CREATE INDEX [IX_fk_usuarioperfil_usuario]
ON [dbo].[UsuarioPerfil]
    ([Cedula]);
GO

-- Creating foreign key on [IdDeposito] in table 'NegociacionProveedor'
ALTER TABLE [dbo].[NegociacionProveedor]
ADD CONSTRAINT [FK_NegociacionProveedor_M_DEPOSITO1]
    FOREIGN KEY ([IdDeposito])
    REFERENCES [dbo].[M_DEPOSITO]
        ([COD_DEPOSITO])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NegociacionProveedor_M_DEPOSITO1'
CREATE INDEX [IX_FK_NegociacionProveedor_M_DEPOSITO1]
ON [dbo].[NegociacionProveedor]
    ([IdDeposito]);
GO

-- Creating foreign key on [CodLinea] in table 'NegociacionLinea'
ALTER TABLE [dbo].[NegociacionLinea]
ADD CONSTRAINT [FK_NegociacionLinea_M_LINEA]
    FOREIGN KEY ([CodLinea])
    REFERENCES [dbo].[M_LINEA]
        ([COD_LINEA])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NegociacionLinea_M_LINEA'
CREATE INDEX [IX_FK_NegociacionLinea_M_LINEA]
ON [dbo].[NegociacionLinea]
    ([CodLinea]);
GO

-- Creating foreign key on [IdProveedor] in table 'NegociacionProveedor'
ALTER TABLE [dbo].[NegociacionProveedor]
ADD CONSTRAINT [FK_NegociacionProveedor_Inv_M_Proveedor]
    FOREIGN KEY ([IdProveedor])
    REFERENCES [dbo].[Proveedor]
        ([Id_Proveedor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NegociacionProveedor_Inv_M_Proveedor'
CREATE INDEX [IX_FK_NegociacionProveedor_Inv_M_Proveedor]
ON [dbo].[NegociacionProveedor]
    ([IdProveedor]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------