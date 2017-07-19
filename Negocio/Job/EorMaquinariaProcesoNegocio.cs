﻿using System;


        public static void VerificarEorMaquinaria(string numEor)
                    {
                        {
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };
                        //result = (from eor in context.SC_EORMAQUINARIA
                        //          where eor.ESTADO == "R"                                                 
                        //          select eor).ToList();

                        result = (from eor in context.SC_EORMAQUINARIA

                };



                            #region VERIFICACION DE DATOS COMPLEMENATARIOS AL EOR
                            #region  VERIFICA LA EXISTENCIA DEL EIR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var eirSigeor = LecturaEntidadesSigeor.ObtenerEirPorId(eor.ID_EIR, eor.COD_DEPOSITO);

                            if (eirSigeor == null)
                                {
                                    contextSigeor.SC_EIR.AddObject(eirSigeor);
                                    idEir = eirSigeor.ID_EIR;
                                }

                            }
                            else
                                idEir = eirSigeor.ID_EIR;

                            #endregion
                            #region  VERIFICA LA EXISTENCIA DEL TIPO DE CONTENEDOR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var tipoContainerSigeor = LecturaEntidadesSigeor.ObtenerTipoContainerPorId(eirSigeor.COD_TIPCONT);
                            {
                            #endregion
                            #region  VERIFICA LA EXISTENCIA DEL DEPOSITO EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var depositoSigeor = LecturaEntidadesSigeor.ObtenerDepositoPorId(eor.COD_DEPOSITO);
                                {
                                    contextSigeor.SM_DEPOSITO.AddObject(depositoSigeor);
                                    codDeposito = depositoSigeor.COD_DEPOSITO;
                                }

                            }
                            else
                                codDeposito = depositoSigeor.COD_DEPOSITO;




                            #endregion

                            #region  VERIFICA LA EXISTENCIA DEL PTI EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                                    contextSigeor.SC_PTI.AddObject(ptiSigeor);
                            }

                            #endregion


                            #region  VERIFICA LA EXISTENCIA DE LA LINEA EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            if (listaDetalleEor.Any())
                            #endregion
                            #region  VERIFICA LA EXISTENCIA DE LA CEBECERA DEL EGRESO POR EOR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var cabeceraEgresoSigeor = LecturaEntidadesSigeor.ObtenerCabeceraEgresoPorEor(eor.NUM_EORMAQ);
                            #endregion
                            #region  VERIFICA LA EXISTENCIA DEL DETALLE DEL EGRESO POR EOR EN EL SISTEMA SIGEOR, SINO LO BUSCA Y LO GUARDA
                            var detalleEgresoSigeor = LecturaEntidadesSigeor.ObtenerDetallesEgresoPorEor(eor.NUM_EORMAQ);
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
                            //var productosEgresoSigeor = LecturaEntidadesSigeor.ObtenerProductosEgresoPorEor(eor.NUM_EORMAQ);

                            //if (!productosEgresoSigeor.Any())
                            //{
                            //    var productosEgresoAretina = LecturaEntidadesAretina.ObtenerProductosEgresoPorEor(eor.NUM_EORMAQ);

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


                using (var contextSigeor = new SigeorEntities { CommandTimeout = 3600 })
                {
                    int i = 0;
                    foreach (var eor in listaEorsAretina)
                    {
                        Log.WriteEntry(i + ": Procesando para Guardar: " + eor.NUM_EORMAQ, EventLogEntryType.Information);
                        i++;
                        var eorSigeor = new SC_EORMAQUINARIA();
                        var entityEor = Reflection.ClonarEntidad(eor, eorSigeor);

                        eorSigeor = entityEor != null ? (SC_EORMAQUINARIA)entityEor : null;

                        eorSigeor.ESTADO_PROCESO = 0;
                        contextSigeor.SC_EORMAQUINARIA.AddObject(eorSigeor);

                        using (var contextAretina = new AretinaEntities())
                        {
                            var detalleEor = (from det in contextAretina.D_EORMAQUINARIA
                                              where det.NUM_EORMAQ == eorSigeor.NUM_EORMAQ
                                              select det).ToList();

                            foreach (var detalleAretina in detalleEor)
                            {
                                var detalleSigeor = new SD_EORMAQUINARIA();
                                var entityDetalle = Reflection.ClonarEntidad(detalleAretina, detalleSigeor);

                                detalleSigeor = entityDetalle != null ? (SD_EORMAQUINARIA)entityDetalle : null;
                                if (detalleSigeor != null)
                                {
                                    contextSigeor.SD_EORMAQUINARIA.AddObject(detalleSigeor);
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
                            var cabeceraEgresoSigeor = LecturaEntidadesSigeor.ObtenerCabeceraEgresoPorEor(eor.NUM_EORMAQ);

                            if (cabeceraEgresoSigeor == null)
                            {
                                var cabeceraEgresoAretina = LecturaEntidadesAretina.ObtenerCabeceraEgresoPorEor(eor.NUM_EORMAQ);


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
                            var detalleEgresoSigeor = LecturaEntidadesSigeor.ObtenerDetallesEgresoPorEor(eor.NUM_EORMAQ);

                            if (!detalleEgresoSigeor.Any())
                            {
                                var listaDetalleEgresoAretina = LecturaEntidadesAretina.ObtenerDetallesEgresoPorEor(eor.NUM_EORMAQ);

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
                            //var productosEgresoSigeor = LecturaEntidadesSigeor.ObtenerProductosEgresoPorEor(eor.NUM_EORMAQ);

                            //if (!productosEgresoSigeor.Any())
                            //{
                            //    var productosEgresoAretina = LecturaEntidadesAretina.ObtenerProductosEgresoPorEor(eor.NUM_EORMAQ);

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
                    Log.WriteEntry("Iniciando a accion guardar " + listaEorsAretina.Count() + " registros a las Estimaciones de Maquinaria", EventLogEntryType.Information);

                    contextSigeor.SaveChanges();
                    Log.WriteEntry("Se agregaron " + listaEorsAretina.Count() + " registros a las Estimaciones de Maquinaria", EventLogEntryType.Information);
                }
            }
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };
                        //result = (from eor in context.C_EORMAQUINARIA
                        //          where eor.NUM_EORMAQ == numEor &&
                        //                //eor.ESTADO == "R" &&
                        //                eor.FECHA_FINREPARA >= politicaDiferenciaValor.FechaValueUno
                        //          select eor).FirstOrDefault();

                        result = (from eor in context.C_EORMAQUINARIA
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };
                        //result = (from eor in context.C_EORMAQUINARIA
                        //          where 
                        //          eor.ESTADO == "R" &&
                        //          eor.FECHA_FINREPARA != null
                        //          select eor)
                        //          .Where(ent => ent.FECHA_CREACION.Value >= politicaDiferenciaValor.FechaValueUno.Value).ToList();

                        result = (from eor in context.C_EORMAQUINARIA

                //foreach (var eorSigeor in from eorAretina in result
                //                          let eorSigeor = new SC_EORMAQUINARIA()
                //                          let entidad = Reflection.ClonarEntidad(eorAretina, eorSigeor)
                //                          select entidad != null ? (SC_EORMAQUINARIA)entidad : null)
                //{
                //    GuardarEorSigeor(eorSigeor);
                //}


                var politicaMaxEstadoProceso = PoliticasCorporativasNegocio.ObtenerPoliticaPorCodigoDesSerializada(ConstantesNegocioUtil.COD_NUM_BUSQUEDA_PROC);

                var numeroMaximoEstadoProceso = politicaMaxEstadoProceso != null ? politicaMaxEstadoProceso.NumericValueUno : 2;

                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };
                        //listaSigeor = (from eor in context.SC_EORMAQUINARIA
                        //               where eor.ESTADO_PROCESO <= 2
                        //               select eor).ToList();



                        listaSigeor = (from eor in context.SC_EORMAQUINARIA
                };

                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted

                };
                        if (negociacionProveedor != null)
                            result = resultJoinCabeceraDetalle.Select(eor => eor.det.HORAS * negociacionProveedor.ValorNegoHHEst).Sum();
                        else // si no existe una negociacion para esta linea deposito proveedor utiliza el total de la mano de obra estimada
                            result = ObtenerTotalManoObraEstimada(numEor);
                    }
                };

                };

                if (listaEorsNoProcesados == null)
                    listaEorsNoProcesados = DiscriminarEorsMaquinariaAretinaSigeor();
                    listaEorsNoProcesados = new List<SC_EORMAQUINARIA>();


                using (var context = new SigeorEntities())
                {
                    foreach (var eor in listaEorsNoProcesados)
                    {
                        i++;
                        Log.WriteEntry(i + " => NumEor: " + eor.NUM_EORMAQ, EventLogEntryType.Information);

                        var negociacionProveedor = ObtenerNegociacionProveedor(eor.NUM_EORMAQ) ??
                            new GET_NEGOCIACION_PROVEEDOR_X_FECHA_Result { ValorNegoMaterialEstructura = 0, ValorNegoHHEst = 0 };
                        var negociacionLinea = ObtenerNegociacionLinea(eor.NUM_EORMAQ) ??
                            new GET_NEGOCIACION_LINEA_X_FECHA_Result { ValorNegoHHEst = 0 };

                        eor.TOTAL_ESTICOSTOHH = ObtenerTotalManoObraEstimada(eor.NUM_EORMAQ);
                        eor.TOTAL_REALCOSTOHH = ObtenerManoObraNegociacionProveedor(eor.NUM_EORMAQ, negociacionProveedor);

                        var resultEgresoSigeor = EgresosNegocio.ObtenerEgresosEorSigeor(eor.NUM_EORMAQ);
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
                            if (negociacionProveedor.EsPorcNegoMatMaq)
                            {
                                var valorMaterialEstimado = ObtenerTotalMaterialEstimado(eor.NUM_EORMAQ);
                                var porcentajeNegociacion = valorMaterialEstimado * ((negociacionProveedor.ValorNegoMaterialMaquinaria) / 100);
                                eor.TOTAL_REALMAT = valorMaterialEstimado + porcentajeNegociacion;
                            }
                        }
                        else
                        {
                            var porcentajeNegociacion = sumaEgresosSapPorEor * (negociacionProveedor.ValorNegoMaterialMaquinaria / 100);
                            eor.TOTAL_REALMAT = sumaEgresosSapPorEor + porcentajeNegociacion;
                        }

                        decimal valorPtiNegociacion = 0;
                        if (negociacionProveedor.PtiNormal != null)
                            valorPtiNegociacion = negociacionProveedor.PtiNormal != 0 ? negociacionProveedor.PtiNormal.Value : 0;
                        else
                        {
                            if (negociacionProveedor.PtiRap != null)
                                valorPtiNegociacion = negociacionProveedor.PtiRap != 0 ? negociacionProveedor.PtiRap.Value : 0;
                        }

                        eor.PTI_NEGOCIACION = valorPtiNegociacion;

                        eor.TOTAL_ESTIMAT = ObtenerTotalMaterialEstimado(eor.NUM_EORMAQ);

                        eor.ESTADO_PROCESO++;
                        //eor.TOTAL_REALMAT = sumaEgresosPorEor;
                        //eor.tot
                        context.SC_EORMAQUINARIA.Attach(eor);
                        context.ObjectStateManager.ChangeObjectState(eor, System.Data.EntityState.Modified);
                        context.SC_EORMAQUINARIA.ApplyCurrentValues(eor);


                    }
                    context.SaveChanges();
                    // transactionScope.Complete();
                    Log.WriteEntry("Se procesaron " + listaEorsNoProcesados.Count + " registros en las Estimaciones de Maquinaria", EventLogEntryType.Information);
                }
                //}
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