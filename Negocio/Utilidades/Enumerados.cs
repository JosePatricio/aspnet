﻿using System;using System.Collections.Generic;using System.ComponentModel;using System.Linq;using System.Text;namespace Negocio{    public enum TipoAuditoriaEnum    {        [Description("Tipo de Auditoria para realizar una Insercion en el Sistema")]        INS,        [Description("Tipo de Auditoria para realizar una  Actualizacion en el Sistema")]        UPD,        [Description("Tipo de Auditoria para realizar una Eliminacion en el Sistema")]        DEL,        [Description("Tipo de Auditoria para realizar una Consulta de Datos en el Sistema")]        SEL,        [Description("Tipo de Auditoria para Ingresar en el Sistema")]        LOGIN,        [Description("Tipo de Auditoria Salir del Sistema")]        LOGOUT    }}
