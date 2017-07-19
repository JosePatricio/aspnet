using System;using System.Collections.Generic;using System.Diagnostics;using System.Linq;using System.Text;using System.Transactions;using Negocio.Sigeor.Configuracion;using Negocio.Utilidades;using PersistenciaAretina;using PersistenciaSigeor;using Negocio.LecturaSap;using Negocio.LecturaAretina;using System.Data.Objects.SqlClient;using Negocio.Sigeor.GestionControl;using System.Globalization;using System.Threading;using Negocio.LecturaSigeor;namespace Negocio.Job{    public class EorEstructuraProcesoNegocio    {


        public static void VerificarEorEstructura(string numEor)        {            try            {                if (!string.IsNullOrEmpty(numEor))                {                    var eorSigeor = ObtenerEorCabeceraSigeorPorId(numEor);                    if (eorSigeor == null) //No existe EOR en SIGEOR
                    {                        var eorAretina = ObtenerEorCabeceraAretinaPorId(numEor);                        if (eorAretina != null) // Existe EOR en Aretina
                        {                            eorSigeor = new SC_EORESTRUCTURA();                            var entity = Reflection.ClonarEntidad(eorAretina, eorSigeor);                            eorSigeor = entity != null ? (SC_EORESTRUCTURA)entity : null;                            if (eorSigeor != null)                            {                                GuardarEorSigeor(eorSigeor);                                var listaEorSigeor = new List<SC_EORESTRUCTURA> { eorSigeor };                                ProcesarEorEstructura(listaEorSigeor);                            }                        }                    }                }                else                {                    ProcesarEorEstructura(null);                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo verificar el EOR por Estructura (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo verificar el EOR por Estructura: " + ex, EventLogEntryType.Error);            }        }        public static SC_EORESTRUCTURA ObtenerEorCabeceraSigeorPorId(string numEor)        {            SC_EORESTRUCTURA result = null;            try            {                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from eor in context.SC_EORESTRUCTURA                                  where eor.NUM_EOREST == numEor &&                                        eor.ESTADO == "R" &&                                        eor.FECHA_FINREPARA != null                                  select eor).FirstOrDefault();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener el EOR de Estructura del Sistema Sigeor por Id (ThreadAbortException): " + numEor + " " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener el EOR de Estructura del Sistema Sigeor por Id: " + numEor + " " + ex, EventLogEntryType.Error);            }            return result;        }        public static List<SC_EORESTRUCTURA> ObtenerEorsCabeceraSigeor()        {            var result = new List<SC_EORESTRUCTURA>();            try            {                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {
                        //result = (from eor in context.SC_EORESTRUCTURA
                        //          where eor.ESTADO == "R"                                                 
                        //          select eor).ToList();

                        result = (from eor in context.SC_EORESTRUCTURA                                  select eor).ToList();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener los EOR's Estructura del Sitema SIGEOR (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener los EOR's Estructura del Sitema SIGEOR: " + ex, EventLogEntryType.Error);            }            return result;        }        public static void GuardarEorSigeor(SC_EORESTRUCTURA eor)        {            try            {                var transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var contextSigeor = new SigeorEntities())                    {                        eor.ESTADO_PROCESO = 0;                        contextSigeor.SC_EORESTRUCTURA.AddObject(eor);                        using (var contextAretina = new AretinaEntities())                        {                            var listaDetalleEor = (from det in contextAretina.D_EORESTRUCTURA                                                   where det.NUM_EOREST == eor.NUM_EOREST                                                   select det).ToList();                            foreach (var detalleAretina in listaDetalleEor)                            {                                var detalleSigeor = new SD_EORESTRUCTURA();                                var entity = Reflection.ClonarEntidad(detalleAretina, detalleSigeor);                                detalleSigeor = entity != null ? (SD_EORESTRUCTURA)entity : null;                                if (detalleSigeor != null)                                    contextSigeor.SD_EORESTRUCTURA.AddObject(detalleSigeor);                            }

                            #region VERIFICACION DE DATOS COMPLEMENATARIOS AL EOR
                            #region  VERIFICA LA EXISTENCIA DEL EIR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var eirSigeor = LecturaEntidadesSigeor.ObtenerEirPorId(eor.ID_EIR, eor.COD_DEPOSITO);                            if (eirSigeor == null)                            {                                eirSigeor = new SC_EIR();                                var eirAretina = LecturaEntidadesAretina.ObtenerEirPorId(eor.ID_EIR, eor.COD_DEPOSITO);                                var entity = Reflection.ClonarEntidad(eirAretina, eirSigeor);                                eirSigeor = entity != null ? (SC_EIR)entity : null;                                if (eirSigeor != null)                                    contextSigeor.SC_EIR.AddObject(eirSigeor);                            }
                            #endregion
                            #region  VERIFICA LA EXISTENCIA DEL TIPO DE CONTENEDOR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var tipoContainerSigeor = LecturaEntidadesSigeor.ObtenerTipoContainerPorId(eirSigeor.COD_TIPCONT);                            if (tipoContainerSigeor == null) //LA BUSQUEDA DEL TIPO DE CONTENEDOR SE BASA EN EL EIR BUSCADO
                            {                                tipoContainerSigeor = new SM_TIPCONTAINER();                                var tipoContainerAretina = LecturaEntidadesAretina.ObtenerTipoContainerPorId(eirSigeor.COD_TIPCONT);                                var entity = Reflection.ClonarEntidad(tipoContainerAretina, tipoContainerSigeor);                                tipoContainerSigeor = entity != null ? (SM_TIPCONTAINER)entity : null;                                if (tipoContainerSigeor != null)                                    contextSigeor.SM_TIPCONTAINER.AddObject(tipoContainerSigeor);                            }
                            #endregion
                            #region  VERIFICA LA EXISTENCIA DEL DEPOSITO EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var depositoSigeor = LecturaEntidadesSigeor.ObtenerDepositoPorId(eor.COD_DEPOSITO);                            if (depositoSigeor == null)                            {                                depositoSigeor = new SM_DEPOSITO();                                var depositoAretina = LecturaEntidadesAretina.ObtenerDepositoPorId(eor.COD_DEPOSITO);                                var entity = Reflection.ClonarEntidad(depositoAretina, depositoSigeor);                                depositoSigeor = entity != null ? (SM_DEPOSITO)entity : null;                                if (depositoSigeor != null)                                    contextSigeor.SM_DEPOSITO.AddObject(depositoSigeor);                            }
                            #endregion
                            #region  VERIFICA LA EXISTENCIA DE LA LINEA EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            if (listaDetalleEor.Any())                            {                                var det = listaDetalleEor.FirstOrDefault();                                var lineaSigeor = LecturaEntidadesSigeor.ObtenerLineaPorId(det.COD_LINEA);                                if (lineaSigeor == null)                                {                                    lineaSigeor = new SM_LINEA();                                    var lineaAretina = LecturaEntidadesAretina.ObtenerLineaPorId(det.COD_LINEA);                                    var entity = Reflection.ClonarEntidad(lineaAretina, lineaSigeor);                                    lineaSigeor = entity != null ? (SM_LINEA)entity : null;                                    if (lineaSigeor != null)                                        contextSigeor.SM_LINEA.AddObject(lineaSigeor);                                }                            }
                            #endregion
                            #region  VERIFICA LA EXISTENCIA DE LA CEBECERA DEL EGRESO POR EOR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var cabeceraEgresoSigeor = LecturaEntidadesSigeor.ObtenerCabeceraEgresoPorEor(eor.NUM_EOREST);                            if (cabeceraEgresoSigeor == null)                            {                                cabeceraEgresoSigeor = new SInv_H_CEgrProducto();                                var cabeceraEgresoAretina = LecturaEntidadesAretina.ObtenerCabeceraEgresoPorEor(eor.NUM_EOREST);                                var entity = Reflection.ClonarEntidad(cabeceraEgresoAretina, cabeceraEgresoSigeor);                                cabeceraEgresoSigeor = entity != null ? (SInv_H_CEgrProducto)entity : null;                                if (cabeceraEgresoSigeor != null)                                    contextSigeor.SInv_H_CEgrProducto.AddObject(cabeceraEgresoSigeor);                            }
                            #endregion
                            #region  VERIFICA LA EXISTENCIA DEL DETALLE DEL EGRESO POR EOR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var detalleEgresoSigeor = LecturaEntidadesSigeor.ObtenerDetallesEgresoPorEor(eor.NUM_EOREST);                            if (!detalleEgresoSigeor.Any())                            {                                var listaDetalleEgresoAretina = LecturaEntidadesAretina.ObtenerDetallesEgresoPorEor(eor.NUM_EOREST);                                if (listaDetalleEgresoAretina.Any())                                    foreach (var detalleAretina in listaDetalleEgresoAretina)
                                    {
                                        var detalleSigeor = LecturaEntidadesSigeor.ObtenerDetallesEgresoPorId(detalleAretina.Id_EgrProducto, detalleAretina.Id_SecEgreso);

                                        if (detalleSigeor == null)
                                        {
                                            detalleSigeor = new SInv_H_DEgrProducto();
                                            var entity = Reflection.ClonarEntidad(detalleAretina, detalleSigeor);
                                            detalleSigeor = entity != null ? (SInv_H_DEgrProducto)entity : null;

                                            if (detalleSigeor != null)
                                                contextSigeor.SInv_H_DEgrProducto.AddObject(detalleSigeor);
                                        }

                                    }                            }
                            #endregion
                            #region  VERIFICA LA EXISTENCIA DE PRODUCTOS EN EL DETALLE DEL EGRESO POR EOR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            //var productosEgresoSigeor = LecturaEntidadesSigeor.ObtenerProductosEgresoPorEor(eor.NUM_EOREST);

                            //if (!productosEgresoSigeor.Any())
                            //{
                            //    var productosEgresoAretina = LecturaEntidadesAretina.ObtenerProductosEgresoPorEor(eor.NUM_EOREST);

                            //    if (productosEgresoAretina.Any())
                            //        foreach (var productoAretina in productosEgresoAretina)
                            //        {
                            //            var productoSigeor = new SInv_M_Producto();
                            //            var entity = Reflection.ClonarEntidad(productoAretina, productoSigeor);
                            //            productoSigeor = entity != null ? (SInv_M_Producto)entity : null;

                            //            if (productoSigeor != null)
                            //                contextSigeor.SInv_M_Producto.AddObject(productoSigeor);
                            //        }
                            //}
                            #endregion
                            #endregion
                        }                        contextSigeor.SaveChanges();                        transactionScope.Complete();                        Log.WriteEntry("Se agrego 1 registro a las Estimaciones de Estructura", EventLogEntryType.Information);                    }                }            }            catch (System.Data.UpdateException ex)            {                Log.WriteEntry("No se pudo guardar el EOR Estructura " + eor.NUM_EOREST + " el Sistema SIGEOR (UpdateException): " + ex, EventLogEntryType.Error);            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo guardar el EOR Estructura " + eor.NUM_EOREST + " el Sistema SIGEOR (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo guardar el EOR Estructura " + eor.NUM_EOREST + " el Sistema SIGEOR: " + ex, EventLogEntryType.Error);            }        }        public static void GuardarEorSigeor(List<C_EORESTRUCTURA> listaEorsAretina)        {            try            {


                //var transactionOptions = new TransactionOptions
                //{
                //    IsolationLevel = IsolationLevel.ReadUncommitted

                //};
                //using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                //{
                using (var contextSigeor = new SigeorEntities { CommandTimeout = 3600 })
                {
                    int i = 0;
                    foreach (var eor in listaEorsAretina)
                    {
                        Log.WriteEntry(i + ": Procesando para Guardar: " + eor.NUM_EOREST, EventLogEntryType.Information);
                        i++;
                        var eorSigeor = new SC_EORESTRUCTURA();
                        var entityEor = Reflection.ClonarEntidad(eor, eorSigeor);

                        eorSigeor = entityEor != null ? (SC_EORESTRUCTURA)entityEor : null;

                        eorSigeor.ESTADO_PROCESO = 0;
                        contextSigeor.SC_EORESTRUCTURA.AddObject(eorSigeor);

                        using (var contextAretina = new AretinaEntities())
                        {
                            var detalleEor = (from det in contextAretina.D_EORESTRUCTURA
                                              where det.NUM_EOREST == eorSigeor.NUM_EOREST
                                              select det).ToList();

                            foreach (var detalleAretina in detalleEor)
                            {
                                var detalleSigeor = new SD_EORESTRUCTURA();
                                var entityDetalle = Reflection.ClonarEntidad(detalleAretina, detalleSigeor);

                                detalleSigeor = entityDetalle != null ? (SD_EORESTRUCTURA)entityDetalle : null;
                                if (detalleSigeor != null)
                                {
                                    contextSigeor.SD_EORESTRUCTURA.AddObject(detalleSigeor);
                                }
                            }

                            #region VERIFICACION DE DATOS COMPLEMENATARIOS AL EOR
                            #region  VERIFICA LA EXISTENCIA DEL EIR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var eirSigeor = LecturaEntidadesSigeor.ObtenerEirPorId(eor.ID_EIR, eor.COD_DEPOSITO);

                            if (eirSigeor == null)
                            {
                                var eirAretina = LecturaEntidadesAretina.ObtenerEirPorId(eor.ID_EIR, eor.COD_DEPOSITO);

                                if (eirAretina != null)
                                {
                                    eirSigeor = new SC_EIR();
                                    var entity = Reflection.ClonarEntidad(eirAretina, eirSigeor);
                                    eirSigeor = entity != null ? (SC_EIR)entity : null;
                                    contextSigeor.SC_EIR.AddObject(eirSigeor);
                                }
                            }




                            #endregion
                            #region  VERIFICA LA EXISTENCIA DEL TIPO DE CONTENEDOR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            if (eirSigeor != null)
                            {
                                var tipoContainerSigeor = LecturaEntidadesSigeor.ObtenerTipoContainerPorId(eirSigeor.COD_TIPCONT);

                                if (tipoContainerSigeor == null) //LA BUSQUEDA DEL TIPO DE CONTENEDOR SE BASA EN EL EIR BUSCADO
                                {
                                    var tipoContainerAretina = LecturaEntidadesAretina.ObtenerTipoContainerPorId(eirSigeor.COD_TIPCONT);

                                    if (tipoContainerAretina != null)
                                    {
                                        tipoContainerSigeor = new SM_TIPCONTAINER();
                                        var entity = Reflection.ClonarEntidad(tipoContainerAretina, tipoContainerSigeor);
                                        tipoContainerSigeor = entity != null ? (SM_TIPCONTAINER)entity : null;
                                        contextSigeor.SM_TIPCONTAINER.AddObject(tipoContainerSigeor);
                                    }

                                }
                            }







                            #endregion
                            #region  VERIFICA LA EXISTENCIA DEL DEPOSITO EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var depositoSigeor = LecturaEntidadesSigeor.ObtenerDepositoPorId(eor.COD_DEPOSITO);

                            if (depositoSigeor == null)
                            {
                                var depositoAretina = LecturaEntidadesAretina.ObtenerDepositoPorId(eor.COD_DEPOSITO);

                                if (depositoAretina != null)
                                {
                                    depositoSigeor = new SM_DEPOSITO();
                                    var entity = Reflection.ClonarEntidad(depositoAretina, depositoSigeor);
                                    depositoSigeor = entity != null ? (SM_DEPOSITO)entity : null;
                                    contextSigeor.SM_DEPOSITO.AddObject(depositoSigeor);
                                }
                            }




                            #endregion
                            #region  VERIFICA LA EXISTENCIA DE LA LINEA EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            if (detalleEor.Any())
                            {
                                var det = detalleEor.FirstOrDefault();
                                var lineaSigeor = LecturaEntidadesSigeor.ObtenerLineaPorId(det.COD_LINEA);

                                if (lineaSigeor == null)
                                {
                                    var lineaAretina = LecturaEntidadesAretina.ObtenerLineaPorId(det.COD_LINEA);

                                    if (lineaAretina != null)
                                    {
                                        lineaSigeor = new SM_LINEA();
                                        var entity = Reflection.ClonarEntidad(lineaAretina, lineaSigeor);
                                        lineaSigeor = entity != null ? (SM_LINEA)entity : null;
                                        contextSigeor.SM_LINEA.AddObject(lineaSigeor);
                                    }
                                }
                            }





                            #endregion
                            #region  VERIFICA LA EXISTENCIA DE LA CEBECERA DEL EGRESO POR EOR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var cabeceraEgresoSigeor = LecturaEntidadesSigeor.ObtenerCabeceraEgresoPorEor(eor.NUM_EOREST);

                            if (cabeceraEgresoSigeor == null)
                            {
                                var cabeceraEgresoAretina = LecturaEntidadesAretina.ObtenerCabeceraEgresoPorEor(eor.NUM_EOREST);


                                if (cabeceraEgresoAretina != null)
                                {
                                    cabeceraEgresoSigeor = new SInv_H_CEgrProducto();
                                    var entity = Reflection.ClonarEntidad(cabeceraEgresoAretina, cabeceraEgresoSigeor);
                                    cabeceraEgresoSigeor = entity != null ? (SInv_H_CEgrProducto)entity : null;
                                    contextSigeor.SInv_H_CEgrProducto.AddObject(cabeceraEgresoSigeor);
                                }

                            }







                            #endregion
                            #region  VERIFICA LA EXISTENCIA DEL DETALLE DEL EGRESO POR EOR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var detalleEgresoSigeor = LecturaEntidadesSigeor.ObtenerDetallesEgresoPorEor(eor.NUM_EOREST);

                            if (!detalleEgresoSigeor.Any())
                            {
                                var listaDetalleEgresoAretina = LecturaEntidadesAretina.ObtenerDetallesEgresoPorEor(eor.NUM_EOREST);

                                if (listaDetalleEgresoAretina.Any())
                                    foreach (var detalleAretina in listaDetalleEgresoAretina)
                                    {
                                        var detalleSigeor = LecturaEntidadesSigeor.ObtenerDetallesEgresoPorId(detalleAretina.Id_EgrProducto, detalleAretina.Id_SecEgreso);

                                        if (detalleSigeor == null)
                                        {
                                            detalleSigeor = new SInv_H_DEgrProducto();
                                            var entity = Reflection.ClonarEntidad(detalleAretina, detalleSigeor);
                                            detalleSigeor = entity != null ? (SInv_H_DEgrProducto)entity : null;

                                            if (detalleSigeor != null)
                                                contextSigeor.SInv_H_DEgrProducto.AddObject(detalleSigeor);
                                        }

                                    }
                            }







                            #endregion
                            #region  VERIFICA LA EXISTENCIA DE PRODUCTOS EN EL DETALLE DEL EGRESO POR EOR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            //var productosEgresoSigeor = LecturaEntidadesSigeor.ObtenerProductosEgresoPorEor(eor.NUM_EOREST);

                            //if (!productosEgresoSigeor.Any())
                            //{
                            //    var productosEgresoAretina = LecturaEntidadesAretina.ObtenerProductosEgresoPorEor(eor.NUM_EOREST);

                            //    if (productosEgresoAretina.Any())
                            //        foreach (var productoAretina in productosEgresoAretina)
                            //        {
                            //            var productoSigeor = new SInv_M_Producto();
                            //            var entity = Reflection.ClonarEntidad(productoAretina, productoSigeor);
                            //            productoSigeor = entity != null ? (SInv_M_Producto)entity : null;

                            //            if (productoSigeor != null)
                            //                contextSigeor.SInv_M_Producto.AddObject(productoSigeor);
                            //        }
                            //}
                            #endregion
                            #endregion
                        }
                    }
                    Log.WriteEntry("Iniciando a accion guardar " + listaEorsAretina.Count() + " registros a las Estimaciones de Estructura", EventLogEntryType.Information);

                    contextSigeor.SaveChanges();
                    //transactionScope.Complete();
                    Log.WriteEntry("Se agregaron " + listaEorsAretina.Count() + " registros a las Estimaciones de Estructura", EventLogEntryType.Information);
                }
                //}
            }            catch (System.Data.UpdateException ex)            {                Log.WriteEntry("No se pudo guardar la lista de EORs Estructura el Sistema SIGEOR (UpdateException): " + ex, EventLogEntryType.Error);            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo guardar la lista de EORs Estructura el Sistema SIGEOR (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo guardar la lista de EORs Estructura el Sistema SIGEOR: " + ex, EventLogEntryType.Error);            }        }        public static C_EORESTRUCTURA ObtenerEorCabeceraAretinaPorId(string numEor)        {            C_EORESTRUCTURA result = null;            try            {                var politicaDiferenciaValor = PoliticasCorporativasNegocio.ObtenerPoliticaPorCodigoDesSerializada(ConstantesNegocioUtil.COD_FEC_RESTRICION_BUSQUEDA);                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new AretinaEntities())                    {
                        //result = (from eor in context.C_EORESTRUCTURA
                        //          where eor.NUM_EOREST == numEor &&
                        //                //eor.ESTADO == "R" &&
                        //                eor.FECHA_FINREPARA >= politicaDiferenciaValor.FechaValueUno
                        //          select eor).FirstOrDefault();

                        result = (from eor in context.C_EORESTRUCTURA                                  where eor.NUM_EOREST == numEor &&                                        eor.FECHA_CREACION >= politicaDiferenciaValor.FechaValueUno                                  select eor).FirstOrDefault();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener el EOR Cabecera del Sistema Aretina por Id (ThreadAbortException): " + numEor + " " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener el EOR Cabecera del Sistema Aretina por Id: " + numEor + " " + ex, EventLogEntryType.Error);            }            return result;        }        public static List<C_EORESTRUCTURA> ObtenerEorsCabeceraAretina()        {            var result = new List<C_EORESTRUCTURA>();            try            {                var politicaResticcionFecha = PoliticasCorporativasNegocio.ObtenerPoliticaPorCodigoDesSerializada(ConstantesNegocioUtil.COD_FEC_RESTRICION_BUSQUEDA);                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new AretinaEntities())                    {
                        //result = (from eor in context.C_EORESTRUCTURA
                        //          where 
                        //          eor.ESTADO == "R" &&
                        //          eor.FECHA_FINREPARA != null
                        //          select eor)
                        //          .Where(ent => ent.FECHA_CREACION.Value >= politicaDiferenciaValor.FechaValueUno.Value).ToList();

                        result = (from eor in context.C_EORESTRUCTURA                                  where eor.FECHA_CREACION.Value >= politicaResticcionFecha.FechaValueUno.Value                                  select eor).ToList();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener los EOR's Estructura del Sitema Aretina (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener los EOR's Estructura del Sitema Aretina: " + ex, EventLogEntryType.Error);            }            return result;        }        public static List<SC_EORESTRUCTURA> DiscriminarEorsEstructuraAretinaSigeor()        {            List<C_EORESTRUCTURA> result = new List<C_EORESTRUCTURA>();            var listaSigeor = new List<SC_EORESTRUCTURA>();            try            {                var listaEorSigeor = ObtenerEorsCabeceraSigeor();                var listaEorAretina = ObtenerEorsCabeceraAretina();                result = (from eorAretina in listaEorAretina                          join eorSigeor in listaEorSigeor on eorAretina.NUM_EOREST equals eorSigeor.NUM_EOREST                          into temporal                          from left in temporal.DefaultIfEmpty()                          where left == null                          select eorAretina).ToList();                GuardarEorSigeor(result);

                //foreach (var eorSigeor in from eorAretina in result
                //                          let eorSigeor = new SC_EORESTRUCTURA()
                //                          let entidad = Reflection.ClonarEntidad(eorAretina, eorSigeor)
                //                          select entidad != null ? (SC_EORESTRUCTURA)entidad : null)
                //{
                //    GuardarEorSigeor(eorSigeor);
                //}

                var politicaMaxEstadoProceso = PoliticasCorporativasNegocio.ObtenerPoliticaPorCodigoDesSerializada(ConstantesNegocioUtil.COD_NUM_BUSQUEDA_PROC);

                var numeroMaximoEstadoProceso = politicaMaxEstadoProceso != null ? politicaMaxEstadoProceso.NumericValueUno : 2;

                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {
                        //listaSigeor = (from eor in context.SC_EORESTRUCTURA
                        //               where eor.ESTADO_PROCESO <= 2
                        //               select eor).ToList();
                        listaSigeor = (from eor in context.SC_EORESTRUCTURA                                       where eor.ESTADO == "R" && eor.FECHA_FINREPARA != null && eor.ESTADO_PROCESO < numeroMaximoEstadoProceso                                       select eor).ToList();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo Discriminar los EOR's de Estructura del Sistema SIGEOR vs. Sistema Aretina (Listas/ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo Discriminar los EOR's de Estructura del Sistema SIGEOR vs. Sistema Aretina (Listas): " + ex, EventLogEntryType.Error);            }            return listaSigeor;        }        public static decimal ObtenerTotalManoObraEstimada(string numEor)        {            decimal? result = null;            try            {                var transactionOptions = new TransactionOptions                {                    IsolationLevel = IsolationLevel.ReadUncommitted
                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from cab in context.SC_EORESTRUCTURA                                  join det in context.SD_EORESTRUCTURA on cab.NUM_EOREST equals det.NUM_EOREST                                  where cab.NUM_EOREST == numEor                                  select det).Select(ent => ent.HORAS * ent.COSTOMAOBRA).Sum();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener la suma de la mano de obra estimada del EOR " + numEor + " por Estructura (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener la suma de la mano de obra estimada del EOR " + numEor + " por Estructura: " + ex, EventLogEntryType.Error);            }            return result ?? 0;        }        public static decimal ObtenerManoObraNegociacionProveedor(string numEor, GET_NEGOCIACION_PROVEEDOR_X_FECHA_Result negociacionProveedor)        {            decimal? result = new decimal(0);            try            {

                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    var contextSigeor = new SigeorEntities();                    var resultJoinCabeceraDetalle = (from cab in contextSigeor.SC_EORESTRUCTURA                                                     from det in                                                         contextSigeor.SD_EORESTRUCTURA.Where(                                                             det =>                                                                 cab.NUM_EOREST == det.NUM_EOREST && cab.ID_EIR == det.ID_EIR &&                                                                 cab.COD_DEPOSITO == det.COD_DEPOSITO)                                                     where cab.NUM_EOREST == numEor                                                     select new { cab, det }).ToList();                    if (resultJoinCabeceraDetalle.Any())                    {
                        if (negociacionProveedor != null) //Si existe la negociacion utiliza el valor de dicha negociacion para calcular el valor de la mano de obra
                            result = resultJoinCabeceraDetalle.Select(eor => eor.det.HORAS * negociacionProveedor.ValorNegoHHEst).Sum();
                        else // si no existe una negociacion para esta linea deposito proveedor utiliza el total de la mano de obra estimada
                            result = ObtenerTotalManoObraEstimada(numEor);
                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener la suma Real de la mano de obra del EOR " + numEor + " por Estructura (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener la suma Real de la mano de obra del EOR " + numEor + " por Estructura: " + ex, EventLogEntryType.Error);            }            return result.Value;        }        public static decimal ObtenerTotalMaterialEstimado(string numEor)        {            decimal? result = null;            try            {                var transactionOptions = new TransactionOptions                {                    IsolationLevel = IsolationLevel.ReadUncommitted
                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from cab in context.SC_EORESTRUCTURA                                  join det in context.SD_EORESTRUCTURA on cab.NUM_EOREST equals det.NUM_EOREST                                  where cab.NUM_EOREST == numEor                                  select det).Select(ent => ent.CANTIDAD * ent.COSTOMATERIAL).Sum();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener la suma de la mano de obra estimada del EOR " + numEor + " por Estructura (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener la suma de la mano de obra estimada del EOR " + numEor + " por Estructura: " + ex, EventLogEntryType.Error);            }            return result ?? 0;        }        public static GET_NEGOCIACION_LINEA_X_FECHA_Result ObtenerNegociacionLinea(string numEor)        {            var result = new GET_NEGOCIACION_LINEA_X_FECHA_Result();            try            {                var transactionOptions = new TransactionOptions                {                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    var contextSigeor = new SigeorEntities();                    var resultJoinCabeceraDetalle = (from cab in contextSigeor.SC_EORESTRUCTURA                                                     from det in                                                         contextSigeor.SD_EORESTRUCTURA.Where(                                                             det =>                                                                 cab.NUM_EOREST == det.NUM_EOREST && cab.ID_EIR == det.ID_EIR &&                                                                 cab.COD_DEPOSITO == det.COD_DEPOSITO)                                                     where cab.NUM_EOREST == numEor                                                     select new { cab, det }).FirstOrDefault();                    if (resultJoinCabeceraDetalle != null)                    {                        var cabeceraEor = resultJoinCabeceraDetalle.cab;                        var detalleEor = resultJoinCabeceraDetalle.det;                        if (cabeceraEor != null && detalleEor != null)                            result =                               contextSigeor.GET_NEGOCIACION_LINEA_X_FECHA(detalleEor.COD_LINEA, cabeceraEor.COD_DEPOSITO, cabeceraEor.FECHA_FINREPARA).FirstOrDefault();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener la suma Real de la mano de obra del EOR " + numEor + " por Estructura (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener la suma Real de la mano de obra del EOR " + numEor + " por Estructura: " + ex, EventLogEntryType.Error);            }            return result;        }        public static void ProcesarEorEstructura(List<SC_EORESTRUCTURA> listaEorsNoProcesados)        {            try            {                int i = 0;

                if (listaEorsNoProcesados == null)
                    listaEorsNoProcesados = DiscriminarEorsEstructuraAretinaSigeor();                else
                    listaEorsNoProcesados = new List<SC_EORESTRUCTURA>();


                using (var context = new SigeorEntities())
                {
                    foreach (var eor in listaEorsNoProcesados)
                    {
                        i++;
                        Log.WriteEntry(i + " => NumEor: " + eor.NUM_EOREST, EventLogEntryType.Information);

                        var negociacionProveedor = ObtenerNegociacionProveedor(eor.NUM_EOREST) ??
                            new GET_NEGOCIACION_PROVEEDOR_X_FECHA_Result { ValorNegoMaterialEstructura = 0, ValorNegoHHEst = 0 };
                        var negociacionLinea = ObtenerNegociacionLinea(eor.NUM_EOREST) ??
                            new GET_NEGOCIACION_LINEA_X_FECHA_Result { ValorNegoHHEst = 0 };

                        eor.TOTAL_ESTICOSTOHH = ObtenerTotalManoObraEstimada(eor.NUM_EOREST);
                        eor.TOTAL_REALCOSTOHH = ObtenerManoObraNegociacionProveedor(eor.NUM_EOREST, negociacionProveedor);

                        var resultEgresoSigeor = EgresosNegocio.ObtenerEgresosEorSigeor(eor.NUM_EOREST);
                        var listaEgresosAgrupados = resultEgresoSigeor.Select(ent => ent.IdEgrProducto).Distinct().ToList();


                        decimal? sumaEgresosSapPorEor = 0;

                        #region SI COINCIDE UN PRODUCTO DE SAP CON EL EGRESO DE TRINITY, GUARDA LA CANTIDAD Y PRECIO
                        foreach (var itemEgresoTrinity in listaEgresosAgrupados)
                        {
                            var valorSumaMaterialSap = LecturaSapNegocio.ObtenerSumaEgresosEorSap(itemEgresoTrinity);

                            sumaEgresosSapPorEor += valorSumaMaterialSap;
                            var resultSap = LecturaSapNegocio.ObtenerDetalleEgresosEorSap(itemEgresoTrinity);

                            foreach (var itemSap in resultSap)
                            {
                                var detalleEgresoResult = resultEgresoSigeor.FirstOrDefault(det => det.IdEgrProducto == itemSap.Ref2 && det.NroParte == itemSap.Sww);
                                if (detalleEgresoResult != null)
                                {
                                    var detalleEgreso = (from det in context.SInv_H_DEgrProducto
                                                         where det.Id_EgrProducto == itemSap.Ref2 && det.id_producto == itemSap.Sww
                                                         select det).FirstOrDefault();
                                    if (detalleEgreso != null)
                                    {
                                        detalleEgreso.CantidadReal = (int?)itemSap.Quantity;
                                        detalleEgreso.CostoReal = (decimal?)itemSap.Price;
                                        context.SInv_H_DEgrProducto.ApplyCurrentValues(detalleEgreso);
                                    }
                                }
                            }
                        }

                        #endregion

                        if (sumaEgresosSapPorEor == 0) //No se encontro egresos en SAP para este EOR
                        {
                            if (negociacionProveedor.EsPorcNegoMatEst)
                            {
                                var valorMaterialEstimado = ObtenerTotalMaterialEstimado(eor.NUM_EOREST);

                                var porcentajeNegociacion = valorMaterialEstimado * ((negociacionProveedor.ValorNegoMaterialEstructura) / 100);
                                eor.TOTAL_REALMAT = valorMaterialEstimado + porcentajeNegociacion;
                            }
                        }
                        else
                        {
                            var porcentajeNegociacion = sumaEgresosSapPorEor * (negociacionProveedor.ValorNegoMaterialEstructura / 100);
                            eor.TOTAL_REALMAT = sumaEgresosSapPorEor + porcentajeNegociacion;
                        }
                        eor.TOTAL_ESTIMAT = ObtenerTotalMaterialEstimado(eor.NUM_EOREST);

                        eor.ESTADO_PROCESO++;
                        context.SC_EORESTRUCTURA.Attach(eor);
                        context.ObjectStateManager.ChangeObjectState(eor, System.Data.EntityState.Modified);
                        context.SC_EORESTRUCTURA.ApplyCurrentValues(eor);
                    }
                    context.SaveChanges();
                    Log.WriteEntry("Se procesaron " + listaEorsNoProcesados.Count + " registros en las Estimaciones de Estructura", EventLogEntryType.Information);
                }
            }            catch (System.Data.UpdateException ex)            {                Log.WriteEntry("No se pudo procesar el EOR por Maquinaria (UpdateException): " + ex, EventLogEntryType.Error);            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo procesar el EOR por Maquinaria (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo procesar el EOR por Maquinaria: " + ex, EventLogEntryType.Error);            }        }        public static void VerificarEliminaciones()        {            try            {

                var codigo = "COD_EST";                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = IsolationLevel.ReadUncommitted
                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        var politicaEliminacionEstructura = (from pol in context.PoliticasCorporativas                                                             where pol.Codigo == codigo && pol.Estado                                                             select pol).FirstOrDefault();                        if (politicaEliminacionEstructura != null && politicaEliminacionEstructura.Estado)                        {                            var fechaInicio = politicaEliminacionEstructura.FechaValueUno.Value.ToString(CultureInfo.InvariantCulture);                            var fechaFin = politicaEliminacionEstructura.FechaValueDos.Value.ToString(CultureInfo.InvariantCulture);                            var countEliminados = context.ELMINACION_REPARACIONES(fechaInicio, fechaFin, codigo).FirstOrDefault();                            Log.WriteEntry("Se eliminaron <<" + countEliminados.ToString() + ">> registros de la tabla SC_EORESTRUCTURA" +                                            " desde la fecha " + fechaInicio + " a la fecha del Sistema SIGEOR" + fechaFin, EventLogEntryType.Information);                        }                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo eliminar automaticamente  las Estimaciones de SC_EORESTRUCTURA (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo eliminar automaticamente  las Estimaciones de SC_EORESTRUCTURA: " + ex, EventLogEntryType.Error);            }        }        public static GET_NEGOCIACION_PROVEEDOR_X_FECHA_Result ObtenerNegociacionProveedor(string numEor)
        {            GET_NEGOCIACION_PROVEEDOR_X_FECHA_Result result = null;            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    var contextSigeor = new SigeorEntities();                    var resultJoinCabeceraDetalle = (from cab in contextSigeor.SC_EORESTRUCTURA                                                     from det in                                                         contextSigeor.SD_EORESTRUCTURA.Where(                                                             det =>                                                                 cab.NUM_EOREST == det.NUM_EOREST && cab.ID_EIR == det.ID_EIR &&                                                                 cab.COD_DEPOSITO == det.COD_DEPOSITO)                                                     where cab.NUM_EOREST == numEor                                                     select new { cab, det }).FirstOrDefault();                    if (resultJoinCabeceraDetalle != null)                    {                        var cabeceraEor = resultJoinCabeceraDetalle.cab;                        var detalleEor = resultJoinCabeceraDetalle.det;                        if (cabeceraEor != null && detalleEor != null)                        {                            result =                                contextSigeor.GET_NEGOCIACION_PROVEEDOR_X_FECHA(detalleEor.COD_LINEA, cabeceraEor.COD_INSPECTOR1, cabeceraEor.COD_DEPOSITO, cabeceraEor.FECHA_FINREPARA).FirstOrDefault();
                        }                    }                    transactionScope.Complete();                }
            }
            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener la negociacion por proveedor de SC_EORESTRUCTURA (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener la negociacion por proveedor de SC_EORESTRUCTURA: " + ex, EventLogEntryType.Error);            }
            return result;
        }    }
}