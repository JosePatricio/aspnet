﻿using Negocio.Sigeor.Configuracion;




        #region LECTURA DE EIRS-ARETINA




        #endregion
        #region LECTURA DE PTIS-ARETINA
        public static SC_PTI ObtenerPtiPorId(string idEir, string codigoDeposito)




        #endregion
        #region LECTURA DE DEPOSITOS-ARETINA
        public static SM_DEPOSITO ObtenerDepositoPorId(string codDeposito)




        #endregion
        #region LECTURA DE DEPOSITOS-ARETINA
        public static SM_LINEA ObtenerLineaPorId(string codLinea)




        #endregion
        #region LECTURA DE TIPO DE COTAINERS-ARETINA
        public static SM_TIPCONTAINER ObtenerTipoContainerPorId(string codTipocontainer)




        #endregion
        #region LECTURA DE TIPO DE CABECERA EGRESOS
        public static SInv_H_CEgrProducto ObtenerCabeceraEgresoPorEor(string numEor)




        #endregion
        #region LECTURA DE TIPO DE DETALLE EGRESOS
        public static List<SInv_H_DEgrProducto> ObtenerDetallesEgresoPorEor(string numEor)




        #endregion
        #region LECTURA DE PRODUCTOS DETALLADOS EN EGRESOS
        public static List<SInv_M_Producto> ObtenerProductosEgresoPorEor(string numEor)


        #endregion
    }