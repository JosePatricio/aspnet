﻿using System;


        public static void VerificarEorEstructura(string numEor)
                    {
                        {
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };
                        //result = (from eor in context.SC_EORESTRUCTURA
                        //          where eor.ESTADO == "R"                                                 
                        //          select eor).ToList();

                        result = (from eor in context.SC_EORESTRUCTURA

                };

                            #region VERIFICACION DE DATOS COMPLEMENATARIOS AL EOR
                            #region  VERIFICA LA EXISTENCIA DEL EIR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var eirSigeor = LecturaEntidadesSigeor.ObtenerEirPorId(eor.ID_EIR, eor.COD_DEPOSITO);
                            #endregion
                            #region  VERIFICA LA EXISTENCIA DEL TIPO DE CONTENEDOR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var tipoContainerSigeor = LecturaEntidadesSigeor.ObtenerTipoContainerPorId(eirSigeor.COD_TIPCONT);
                            {
                            #endregion
                            #region  VERIFICA LA EXISTENCIA DEL DEPOSITO EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var depositoSigeor = LecturaEntidadesSigeor.ObtenerDepositoPorId(eor.COD_DEPOSITO);
                            #endregion
                            #region  VERIFICA LA EXISTENCIA DE LA LINEA EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            if (listaDetalleEor.Any())
                            #endregion
                            #region  VERIFICA LA EXISTENCIA DE LA CEBECERA DEL EGRESO POR EOR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var cabeceraEgresoSigeor = LecturaEntidadesSigeor.ObtenerCabeceraEgresoPorEor(eor.NUM_EOREST);
                            #endregion
                            #region  VERIFICA LA EXISTENCIA DEL DETALLE DEL EGRESO POR EOR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var detalleEgresoSigeor = LecturaEntidadesSigeor.ObtenerDetallesEgresoPorEor(eor.NUM_EOREST);
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
            }
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };
                        //result = (from eor in context.C_EORESTRUCTURA
                        //          where eor.NUM_EOREST == numEor &&
                        //                //eor.ESTADO == "R" &&
                        //                eor.FECHA_FINREPARA >= politicaDiferenciaValor.FechaValueUno
                        //          select eor).FirstOrDefault();

                        result = (from eor in context.C_EORESTRUCTURA
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };
                        //result = (from eor in context.C_EORESTRUCTURA
                        //          where 
                        //          eor.ESTADO == "R" &&
                        //          eor.FECHA_FINREPARA != null
                        //          select eor)
                        //          .Where(ent => ent.FECHA_CREACION.Value >= politicaDiferenciaValor.FechaValueUno.Value).ToList();

                        result = (from eor in context.C_EORESTRUCTURA

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

                };
                        //listaSigeor = (from eor in context.SC_EORESTRUCTURA
                        //               where eor.ESTADO_PROCESO <= 2
                        //               select eor).ToList();
                        listaSigeor = (from eor in context.SC_EORESTRUCTURA
                };

                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };
                        if (negociacionProveedor != null) //Si existe la negociacion utiliza el valor de dicha negociacion para calcular el valor de la mano de obra
                            result = resultJoinCabeceraDetalle.Select(eor => eor.det.HORAS * negociacionProveedor.ValorNegoHHEst).Sum();
                        else // si no existe una negociacion para esta linea deposito proveedor utiliza el total de la mano de obra estimada
                            result = ObtenerTotalManoObraEstimada(numEor);
                    }
                };

                };

                if (listaEorsNoProcesados == null)
                    listaEorsNoProcesados = DiscriminarEorsEstructuraAretinaSigeor();
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
            }

                var codigo = "COD_EST";
                };
        {
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };
                        }
            }
            catch (ThreadAbortException ex)
            return result;
        }
}