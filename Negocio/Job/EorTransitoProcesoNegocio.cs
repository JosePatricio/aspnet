using System;using System.Collections.Generic;using System.Diagnostics;using System.Linq;using System.Text;using System.Transactions;using Negocio.Sigeor.Configuracion;using Negocio.Utilidades;using PersistenciaAretina;using PersistenciaSigeor;using Negocio.LecturaSap;using Negocio.LecturaAretina;using System.Data.Objects.SqlClient;using Negocio.Sigeor.GestionControl;using System.Globalization;using System.Threading;using Negocio.LecturaSigeor;namespace Negocio.Job{    public class EorTransitoProcesoNegocio    {


        public static void VerificarEorTransito(string numEor)        {            try            {                if (!string.IsNullOrEmpty(numEor))                {                    var eorSigeor = ObtenerEorCabeceraSigeorPorId(numEor);                    if (eorSigeor == null) //No existe EOR en SIGEOR
                    {                        var eorAretina = ObtenerEorCabeceraAretinaPorId(numEor);                        if (eorAretina != null) // Existe EOR en Aretina
                        {                            eorSigeor = new SC_EORTRANSITO();                            var entity = Reflection.ClonarEntidad(eorAretina, eorSigeor);                            eorSigeor = entity != null ? (SC_EORTRANSITO)entity : null;                            if (eorSigeor != null)                            {                                GuardarEorSigeor(eorSigeor);                                var listaEorSigeor = new List<SC_EORTRANSITO> { eorSigeor };                                ProcesarEorTransito(listaEorSigeor);                            }                        }                    }                }                else                {                    ProcesarEorTransito(null);                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo verificar el EOR por Transito (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo verificar el EOR por Transito: " + ex, EventLogEntryType.Error);            }        }        public static SC_EORTRANSITO ObtenerEorCabeceraSigeorPorId(string numEor)        {            SC_EORTRANSITO result = null;            try            {                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {
                        result = (from eor in context.SC_EORTRANSITO
                                  where eor.NUM_EORTRANSITO == numEor &&
                                        (eor.ESTADOEST == 8 && eor.ESTADOMAQ == null) ||
                                        (eor.ESTADOEST == null && eor.ESTADOMAQ == 8) ||
                                        (eor.ESTADOEST == 8 && eor.ESTADOMAQ == 8)
                                  select eor).FirstOrDefault();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener el EOR de Transito del Sistema Sigeor por Id (ThreadAbortException): " + numEor + " " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener el EOR de Transito del Sistema Sigeor por Id: " + numEor + " " + ex, EventLogEntryType.Error);            }            return result;        }        public static List<SC_EORTRANSITO> ObtenerEorsCabeceraSigeor()        {            var result = new List<SC_EORTRANSITO>();            try            {                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {
                        result = (from eor in context.SC_EORTRANSITO                                  select eor).ToList();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener los EOR's Transito del Sitema SIGEOR (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener los EOR's Transito del Sitema SIGEOR: " + ex, EventLogEntryType.Error);            }            return result;        }        public static void GuardarEorSigeor(SC_EORTRANSITO eor)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted,

                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    using (var contextSigeor = new SigeorEntities())
                    {
                        eor.ESTADO_PROCESO = 0;
                        contextSigeor.SC_EORTRANSITO.AddObject(eor);

                        using (var contextAretina = new AretinaEntities())
                        {
                            var detalleEor = (from det in contextAretina.D_EORTRANSITO
                                              where det.NUM_EORTRANSITO == eor.NUM_EORTRANSITO
                                              select det).ToList();

                            foreach (var detalleAretina in detalleEor)
                            {
                                var detalleSigeor = new SD_EORTRANSITO();
                                var entity = Reflection.ClonarEntidad(detalleAretina, detalleSigeor);

                                detalleSigeor = entity != null ? (SD_EORTRANSITO)entity : null;
                                if (detalleSigeor != null)
                                {
                                    contextSigeor.SD_EORTRANSITO.AddObject(detalleSigeor);
                                }
                            }




                            #region VERIFICACION DE DATOS COMPLEMENATARIOS AL EOR

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

                            var cabeceraEgresoSigeor = LecturaEntidadesSigeor.ObtenerCabeceraEgresoPorEor(eor.NUM_EORTRANSITO);

                            if (cabeceraEgresoSigeor == null)
                            {
                                var cabeceraEgresoAretina = LecturaEntidadesAretina.ObtenerCabeceraEgresoPorEor(eor.NUM_EORTRANSITO);

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

                            var detalleEgresoSigeor = LecturaEntidadesAretina.ObtenerDetallesEgresoPorEor(eor.NUM_EORTRANSITO);

                            if (!detalleEgresoSigeor.Any())
                            {
                                var listaDetalleEgresoAretina = LecturaEntidadesAretina.ObtenerDetallesEgresoPorEor(eor.NUM_EORTRANSITO);

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

                            #endregion

                        }
                        contextSigeor.SaveChanges();
                        transactionScope.Complete();
                        Log.WriteEntry("Se agrego 1 registro a las Estimaciones de Transito", EventLogEntryType.Information);
                    }
                }
            }

            catch (System.Data.UpdateException ex)
            {
                Log.WriteEntry("No se pudo guardar el EOR Transito " + eor.NUM_EORTRANSITO + " el Sistema SIGEOR (UpdateException): " + ex, EventLogEntryType.Error);
            }
            catch (ThreadAbortException ex)
            {
                Log.WriteEntry("No se pudo guardar el EOR Transito " + eor.NUM_EORTRANSITO + " el Sistema SIGEOR (ThreadAbortException): " + ex, EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo guardar el EOR Transito " + eor.NUM_EORTRANSITO + " el Sistema SIGEOR: " + ex, EventLogEntryType.Error);
            }
        }

        public static void GuardarEorSigeor(IEnumerable<C_EORTRANSITO> listaEorsAretina)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted,

                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    using (var contextSigeor = new SigeorEntities { CommandTimeout = 3600 })
                    {
                        foreach (var eorAretina in listaEorsAretina)
                        {
                            var eorSigeor = new SC_EORTRANSITO();
                            var entityEor = Reflection.ClonarEntidad(eorAretina, eorSigeor);

                            eorSigeor = entityEor != null ? (SC_EORTRANSITO)entityEor : null;

                            eorSigeor.ESTADO_PROCESO = 0;
                            contextSigeor.SC_EORTRANSITO.AddObject(eorSigeor);

                            using (var contextAretina = new AretinaEntities())
                            {
                                var detalleEor = (from det in contextAretina.D_EORTRANSITO
                                                  where det.NUM_EORTRANSITO == eorSigeor.NUM_EORTRANSITO
                                                  select det).ToList();

                                foreach (var detalleAretina in detalleEor)
                                {
                                    var detalleSigeor = new SD_EORTRANSITO();
                                    var entityDetalle = Reflection.ClonarEntidad(detalleAretina, detalleSigeor);

                                    detalleSigeor = entityDetalle != null ? (SD_EORTRANSITO)entityDetalle : null;
                                    if (detalleSigeor != null)
                                    {
                                        contextSigeor.SD_EORTRANSITO.AddObject(detalleSigeor);
                                    }
                                }

                                #region VERIFICACION DE DATOS COMPLEMENATARIOS AL EOR

                                #region  VERIFICA LA EXISTENCIA DEL DEPOSITO EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA

                                var depositoSigeor = LecturaEntidadesSigeor.ObtenerDepositoPorId(eorAretina.COD_DEPOSITO);

                                if (depositoSigeor == null)
                                {
                                    var depositoAretina = LecturaEntidadesAretina.ObtenerDepositoPorId(eorAretina.COD_DEPOSITO);

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

                                var cabeceraEgresoSigeor = LecturaEntidadesSigeor.ObtenerCabeceraEgresoPorEor(eorAretina.NUM_EORTRANSITO);

                                if (cabeceraEgresoSigeor == null)
                                {
                                    var cabeceraEgresoAretina = LecturaEntidadesAretina.ObtenerCabeceraEgresoPorEor(eorAretina.NUM_EORTRANSITO);

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

                                var detalleEgresoSigeor = LecturaEntidadesAretina.ObtenerDetallesEgresoPorEor(eorAretina.NUM_EORTRANSITO);

                                if (!detalleEgresoSigeor.Any())
                                {
                                    var listaDetalleEgresoAretina = LecturaEntidadesAretina.ObtenerDetallesEgresoPorEor(eorAretina.NUM_EORTRANSITO);

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

                                #endregion
                            }
                        }
                        contextSigeor.SaveChanges();
                        transactionScope.Complete();
                        Log.WriteEntry("Se agregaron " + listaEorsAretina.Count() + " registros a las Estimaciones de Transito", EventLogEntryType.Information);
                    }
                }
            }

            catch (System.Data.UpdateException ex)
            {
                Log.WriteEntry("No se pudo guardar la lista de EORs Transito el Sistema SIGEOR (UpdateException): " + ex, EventLogEntryType.Error);
            }
            catch (ThreadAbortException ex)
            {
                Log.WriteEntry("No se pudo guardar la lista de EORs Transito el Sistema SIGEOR (ThreadAbortException): " + ex, EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo guardar la lista de EORs Transito el Sistema SIGEOR: " + ex, EventLogEntryType.Error);
            }
        }


        public static C_EORTRANSITO ObtenerEorCabeceraAretinaPorId(string numEor)        {            C_EORTRANSITO result = null;            try            {                var politicaDiferenciaValor = PoliticasCorporativasNegocio.ObtenerPoliticaPorCodigoDesSerializada(ConstantesNegocioUtil.COD_FEC_RESTRICION_BUSQUEDA);                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new AretinaEntities())                    {
                        //result = (from eor in context.C_EORTRANSITO
                        //          where eor.NUM_EORMAQ == numEor &&
                        //                //eor.ESTADO == "R" &&
                        //                eor.FECHA_FINREPARA >= politicaDiferenciaValor.FechaValueUno
                        //          select eor).FirstOrDefault();

                        result = (from eor in context.C_EORTRANSITO                                  where eor.NUM_EORTRANSITO == numEor &&                                        eor.FECHA_CREACION >= politicaDiferenciaValor.FechaValueUno                                  select eor).FirstOrDefault();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener el EOR Cabecera del Sistema Aretina por Id (ThreadAbortException): " + numEor + " " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener el EOR Cabecera del Sistema Aretina por Id: " + numEor + " " + ex, EventLogEntryType.Error);            }            return result;        }        public static List<C_EORTRANSITO> ObtenerEorsCabeceraAretina()        {            var result = new List<C_EORTRANSITO>();            try            {                var politicaResticcionFecha = PoliticasCorporativasNegocio.ObtenerPoliticaPorCodigoDesSerializada(ConstantesNegocioUtil.COD_FEC_RESTRICION_BUSQUEDA);                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new AretinaEntities())                    {
                        //result = (from eor in context.C_EORTRANSITO
                        //          where 
                        //          eor.ESTADO == "R" &&
                        //          eor.FECHA_FINREPARA != null
                        //          select eor)
                        //          .Where(ent => ent.FECHA_CREACION.Value >= politicaDiferenciaValor.FechaValueUno.Value).ToList();

                        result = (from eor in context.C_EORTRANSITO                                  where eor.FECHA_CREACION.Value >= politicaResticcionFecha.FechaValueUno.Value                                  select eor).ToList();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener los EOR's Transito del Sitema Aretina (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener los EOR's Transito del Sitema Aretina: " + ex, EventLogEntryType.Error);            }            return result;        }

        public static List<SC_EORTRANSITO> DiscriminarEorsTransitoAretinaSigeor()
        {
            IEnumerable<C_EORTRANSITO> result = new List<C_EORTRANSITO>();

            var listaSigeor = new List<SC_EORTRANSITO>();

            try
            {
                var listaEorSigeor = ObtenerEorsCabeceraSigeor();
                var listaEorAretina = ObtenerEorsCabeceraAretina();

                result = from eorAretina in listaEorAretina
                         join eorSigeor in listaEorSigeor on eorAretina.NUM_EORTRANSITO equals eorSigeor.NUM_EORTRANSITO
                         into temporal
                         from left in temporal.DefaultIfEmpty()
                         where left == null
                         select eorAretina;

                GuardarEorSigeor(result);

                //foreach (var eorSigeor in from eorAretina in result
                //                          let eorSigeor = new SC_EORTRANSITO()
                //                          let entidad = Reflection.ClonarEntidad(eorAretina, eorSigeor)
                //                          select entidad != null ? (SC_EORTRANSITO)entidad : null)
                //{
                //    GuardarEorSigeor(eorSigeor);
                //}

                var politicaMaxEstadoProceso = PoliticasCorporativasNegocio.ObtenerPoliticaPorCodigoDesSerializada(ConstantesNegocioUtil.COD_NUM_BUSQUEDA_PROC);

                var numeroMaximoEstadoProceso = politicaMaxEstadoProceso != null ? politicaMaxEstadoProceso.NumericValueUno : 2;


                var transactionOptions = new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted, };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    using (var context = new SigeorEntities())
                    {
                        listaSigeor = (from eorSigeor in context.SC_EORTRANSITO
                                       where eorSigeor.ESTADO_PROCESO < numeroMaximoEstadoProceso && (
                                              (eorSigeor.ESTADOEST == 8 && eorSigeor.ESTADOMAQ == null && eorSigeor.FECHA_FINREPARAEST != null) ||
                                              (eorSigeor.ESTADOMAQ == 8 && eorSigeor.ESTADOEST == null && eorSigeor.FECHA_FINREPARAMAQ != null) ||
                                              (eorSigeor.ESTADOEST == 8 && eorSigeor.ESTADOMAQ == 8 &&
                                              (eorSigeor.FECHA_FINREPARAEST != null && eorSigeor.FECHA_FINREPARAMAQ != null)))
                                       select eorSigeor).ToList();
                    }
                    transactionScope.Complete();
                }
            }
            catch (ThreadAbortException ex)
            {
                Log.WriteEntry("No se pudo Discriminar los EOR's de Transito del Sistema SIGEOR vs. Sistema Aretina (Listas/ThreadAbortException): " + ex, EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo Discriminar los EOR's de Transito del Sistema SIGEOR vs. Sistema Aretina (Listas): " + ex, EventLogEntryType.Error);
            }
            return listaSigeor;
        }

        public static decimal ObtenerTotalManoObraEstimada(string numEor)        {            decimal? result = null;            try            {                var transactionOptions = new TransactionOptions                {                    IsolationLevel = IsolationLevel.ReadUncommitted
                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from cab in context.SC_EORTRANSITO                                  join det in context.SD_EORTRANSITO on cab.NUM_EORTRANSITO equals det.NUM_EORTRANSITO                                  where cab.NUM_EORTRANSITO == numEor                                  select det).Select(ent => ent.HORAS * ent.COSTOMAOBRA).Sum();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener la suma de la mano de obra estimada del EOR " + numEor + " por Transito (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener la suma de la mano de obra estimada del EOR " + numEor + " por Transito: " + ex, EventLogEntryType.Error);            }            return result ?? 0;        }        public static decimal ObtenerManoObraNegociacionProveedor(string numEor, GET_NEGOCIACION_PROVEEDOR_X_FECHA_Result negociacionProveedor)        {            decimal? result = new decimal(0);            try            {

                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    var contextSigeor = new SigeorEntities();                    var resultJoinCabeceraDetalle = (from cab in contextSigeor.SC_EORTRANSITO                                                     from det in                                                         contextSigeor.SD_EORTRANSITO.Where(                                                             det =>                                                                 cab.NUM_EORTRANSITO == det.NUM_EORTRANSITO)                                                     where cab.NUM_EORTRANSITO == numEor                                                     select new { cab, det }).ToList();                    if (resultJoinCabeceraDetalle.Any())                    {
                        if (negociacionProveedor != null)
                            result = resultJoinCabeceraDetalle.Select(eor => eor.det.HORAS * negociacionProveedor.ValorNegoHHEst).Sum();
                        else // si no existe una negociacion para esta linea deposito proveedor utiliza el total de la mano de obra estimada
                            result = ObtenerTotalManoObraEstimada(numEor);


                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener la suma Real de la mano de obra del EOR " + numEor + " por Transito (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener la suma Real de la mano de obra del EOR " + numEor + " por Transito: " + ex, EventLogEntryType.Error);            }            return result.Value;        }        public static decimal ObtenerTotalMaterialEstimado(string numEor)        {            decimal? result = null;            try            {                var transactionOptions = new TransactionOptions                {                    IsolationLevel = IsolationLevel.ReadUncommitted
                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from cab in context.SC_EORTRANSITO                                  join det in context.SD_EORTRANSITO on cab.NUM_EORTRANSITO equals det.NUM_EORTRANSITO                                  where cab.NUM_EORTRANSITO == numEor                                  select det).Select(ent => ent.CANTIDAD * ent.COSTOMATERIAL).Sum();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener la suma de la mano de obra estimada del EOR " + numEor + " por Transito (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener la suma de la mano de obra estimada del EOR " + numEor + " por Transito: " + ex, EventLogEntryType.Error);            }            return result ?? 0;        }        public static GET_NEGOCIACION_LINEA_X_FECHA_Result ObtenerNegociacionLinea(string numEor)        {            var result = new GET_NEGOCIACION_LINEA_X_FECHA_Result();            try            {                var transactionOptions = new TransactionOptions                {                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    var contextSigeor = new SigeorEntities();                    var resultJoinCabeceraDetalle = (from cab in contextSigeor.SC_EORTRANSITO                                                     from det in                                                         contextSigeor.SD_EORTRANSITO.Where(                                                             det =>                                                                 cab.NUM_EORTRANSITO == det.NUM_EORTRANSITO)                                                     where cab.NUM_EORTRANSITO == numEor                                                     select new { cab, det }).FirstOrDefault();                    if (resultJoinCabeceraDetalle != null)                    {                        var cabeceraEor = resultJoinCabeceraDetalle.cab;                        var detalleEor = resultJoinCabeceraDetalle.det;                        if (cabeceraEor != null && detalleEor != null)                            result =                               contextSigeor.GET_NEGOCIACION_LINEA_X_FECHA(detalleEor.COD_LINEA, cabeceraEor.COD_DEPOSITO, cabeceraEor.FECHA_FINREPARAEST ?? cabeceraEor.FECHA_FINREPARAMAQ).FirstOrDefault();                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener la suma Real de la mano de obra del EOR " + numEor + " por Transito (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener la suma Real de la mano de obra del EOR " + numEor + " por Transito: " + ex, EventLogEntryType.Error);            }            return result;        }        public static void ProcesarEorTransito(List<SC_EORTRANSITO> listaEorsNoProcesados)        {            try            {                int i = 0;

                if (listaEorsNoProcesados == null)
                    listaEorsNoProcesados = DiscriminarEorsTransitoAretinaSigeor();                else
                    listaEorsNoProcesados = new List<SC_EORTRANSITO>();


                using (var context = new SigeorEntities())
                {
                    foreach (var eor in listaEorsNoProcesados)
                    {
                        i++;
                        Log.WriteEntry(i + " => NumEor: " + eor.NUM_EORTRANSITO, EventLogEntryType.Information);

                        var negociacionProveedor = ObtenerNegociacionProveedor(eor.NUM_EORTRANSITO) ??
                            new GET_NEGOCIACION_PROVEEDOR_X_FECHA_Result { ValorNegoMaterialEstructura = 0, ValorNegoHHEst = 0 };
                        var negociacionLinea = ObtenerNegociacionLinea(eor.NUM_EORTRANSITO) ??
                            new GET_NEGOCIACION_LINEA_X_FECHA_Result { ValorNegoHHEst = 0 };

                        eor.TOTAL_ESTICOSTOHH = ObtenerTotalManoObraEstimada(eor.NUM_EORTRANSITO);
                        eor.TOTAL_REALCOSTOHH = ObtenerManoObraNegociacionProveedor(eor.NUM_EORTRANSITO, negociacionProveedor);

                        var resultEgresoSigeor = EgresosNegocio.ObtenerEgresosEorSigeor(eor.NUM_EORTRANSITO);
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
                            var valorMaterialEstimado = ObtenerTotalMaterialEstimado(eor.NUM_EORTRANSITO);
                            var porcentajeNegociacion = valorMaterialEstimado * ((negociacionProveedor.ValorNegoMaterialEstructura) / 100);
                            eor.TOTAL_REALMAT = valorMaterialEstimado + porcentajeNegociacion;
                        }
                        else
                        {
                            var porcentajeNegociacion = sumaEgresosSapPorEor * (negociacionProveedor.ValorNegoMaterialEstructura / 100);
                            eor.TOTAL_REALMAT = sumaEgresosSapPorEor + porcentajeNegociacion;
                        }
                        eor.TOTAL_ESTIMAT = ObtenerTotalMaterialEstimado(eor.NUM_EORTRANSITO);

                        eor.ESTADO_PROCESO++;
                        //eor.TOTAL_REALMAT = sumaEgresosPorEor;
                        //eor.tot
                        context.SC_EORTRANSITO.Attach(eor);
                        context.ObjectStateManager.ChangeObjectState(eor, System.Data.EntityState.Modified);
                        context.SC_EORTRANSITO.ApplyCurrentValues(eor);


                    }
                    context.SaveChanges();
                    // transactionScope.Complete();
                    Log.WriteEntry("Se procesaron " + listaEorsNoProcesados.Count + " registros en las Estimaciones de Transito", EventLogEntryType.Information);
                }
                //}
            }            catch (System.Data.UpdateException ex)            {                Log.WriteEntry("No se pudo procesar el EOR por Transito (UpdateException): " + ex, EventLogEntryType.Error);            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo procesar el EOR por Transito (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo procesar el EOR por Transito: " + ex, EventLogEntryType.Error);            }        }        public static void VerificarEliminaciones()        {            try            {



                var codigo = "COD_EST";                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        var politicaEliminacionEstructura = (from pol in context.PoliticasCorporativas                                                             where pol.Codigo == codigo && pol.Estado                                                             select pol).FirstOrDefault();                        if (politicaEliminacionEstructura != null && politicaEliminacionEstructura.Estado)                        {                            var fechaInicio = politicaEliminacionEstructura.FechaValueUno.Value.ToString(CultureInfo.InvariantCulture);                            var fechaFin = politicaEliminacionEstructura.FechaValueDos.Value.ToString(CultureInfo.InvariantCulture);                            var countEliminados = context.ELMINACION_REPARACIONES(fechaInicio, fechaFin, codigo).FirstOrDefault();                            Log.WriteEntry("Se eliminaron <<" + countEliminados.ToString() + ">> registros de la tabla SC_EORTRANSITO" +                                            " desde la fecha " + fechaInicio + " a la fecha del Sistema SIGEOR" + fechaFin, EventLogEntryType.Information);                        }                    }                    transactionScope.Complete();                }            }            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo eliminar automaticamente  las Estimaciones de SC_EORTRANSITO (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo eliminar automaticamente  las Estimaciones de SC_EORTRANSITO: " + ex, EventLogEntryType.Error);            }        }        public static GET_NEGOCIACION_PROVEEDOR_X_FECHA_Result ObtenerNegociacionProveedor(string numEor)
        {            GET_NEGOCIACION_PROVEEDOR_X_FECHA_Result result = null;            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    var contextSigeor = new SigeorEntities();                    var resultJoinCabeceraDetalle = (from cab in contextSigeor.SC_EORTRANSITO                                                     from det in                                                         contextSigeor.SD_EORTRANSITO.Where(                                                             det =>                                                                 cab.NUM_EORTRANSITO == det.NUM_EORTRANSITO)                                                     where cab.NUM_EORTRANSITO == numEor                                                     select new { cab, det }).FirstOrDefault();                    if (resultJoinCabeceraDetalle != null)                    {                        var cabeceraEor = resultJoinCabeceraDetalle.cab;                        var detalleEor = resultJoinCabeceraDetalle.det;                        if (cabeceraEor != null && detalleEor != null)                        {                            result =                                contextSigeor.GET_NEGOCIACION_PROVEEDOR_X_FECHA(detalleEor.COD_LINEA, cabeceraEor.COD_RESPONSABLEEST ?? cabeceraEor.COD_RESPONSABLEMAQ,
                                cabeceraEor.COD_DEPOSITO, cabeceraEor.FECHA_FINREPARAEST ?? cabeceraEor.FECHA_FINREPARAMAQ).FirstOrDefault();
                        }                    }                    transactionScope.Complete();                }
            }
            catch (ThreadAbortException ex)            {                Log.WriteEntry("No se pudo obtener la negociacion por proveedor de SC_EORTRANSITO (ThreadAbortException): " + ex, EventLogEntryType.Error);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener la negociacion por proveedor de SC_EORTRANSITO: " + ex, EventLogEntryType.Error);            }
            return result;
        }    }}