﻿using System;
                                      //where eor.ESTADO == "R"                                                 
                                  select eor).ToList();
//eor.ESTADO == "R" &&
                                                                                                        eor.FECHA_FINREPARA >= politicaDiferenciaValor.FechaValueUno
                        //result = (from eor in context.C_EORMAQUINARIA
                        //          where eor.ESTADO == "R" &&
                        //          eor.FECHA_FINREPARA != null
                        //          select eor)
                        //          .Where(ent => ent.FECHA_FINREPARA.Value >= politicaDiferenciaValor.FechaValueUno.Value).ToList();
                        result = (from eor in context.C_EORMAQUINARIA

                //foreach (var eorSigeor in from eorAretina in result
                //                          let eorSigeor = new SC_EORESTRUCTURA()
                //                          let entidad = Reflection.ClonarEntidad(eorAretina, eorSigeor)
                //                          select entidad != null ? (SC_EORESTRUCTURA)entidad : null)
                //{
                //    GuardarEorSigeor(eorSigeor);
                //}

                var transactionOptions = new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted };
                        //listaSigeor = (from eor in context.SC_EORESTRUCTURA
                        //               where eor.ESTADO_PROCESO <= 2
                        //               select eor).ToList();
                        listaSigeor = (from eor in context.SC_EORMAQUINARIA
                        //listaAretina = (from eorAretina in contextAretina.C_EORMAQUINARIA
                        //                where eorAretina.ESTADO == "R" &&
                        //                eorAretina.FECHA_FINREPARA != null &&
                        //                eorAretina.NUM_EORMAQ == numEor &&
                        //                eorAretina.FECHA_FINREPARA >= politicaDiferenciaValor.FechaValueUno
                        //                select eorAretina).ToList();
                        listaAretina = (from eorAretina in contextAretina.C_EORMAQUINARIA
                        //listaAretina = (from eorAretina in contextAretina.C_EORMAQUINARIA
                        //                where eorAretina.ESTADO == "R" &&
                        //                eorAretina.FECHA_FINREPARA != null &&
                        //                 eorAretina.FECHA_FINREPARA >= politicaDiferenciaValor.FechaValueUno
                        //                select eorAretina).ToList();
                        listaAretina = (from eorAretina in contextAretina.C_EORMAQUINARIA
                    {
                        {

                //var transactionOptions = new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted };
                //using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                //{
                using (var context = new SigeorEntities())
                {
                    foreach (var eor in listaEorsNoProcesados)
                    {
                        i++;

                        Log.WriteEntry(i + " => NumEor: " + eor.NUM_EORMAQ, EventLogEntryType.Information);

                        var resultEgresoTrinity = EgresosNegocio.ObtenerEgresosEorSigeor(eor.NUM_EORMAQ);
                        var listaEgresosAgrupados = resultEgresoTrinity.Select(ent => ent.IdEgrProducto).Distinct().ToList();


                        var sumaManoObra = ObtenerTotalManoObraEorMaquinariaReal(eor.NUM_EORMAQ);

                        var sumaNegLinea = ObtenerValorNegociacionLinea(eor.NUM_EORMAQ);

                        sumaManoObra = sumaManoObra == 0
                            ? ObtenerTotalManoObraEorMaquinariaAretina(eor.NUM_EORMAQ)
                            : sumaManoObra;

                        if (eor != null)
                        {
                            decimal? sumaEgresosPorEor = 0;
                            eor.TOTAL_COSTOHH = sumaManoObra;

                            foreach (var itemEgresoTrinity in listaEgresosAgrupados)
                            {

                                var valorSumaMaterialSap = LecturaSapNegocio.ObtenerSumaEgresosEorSap(itemEgresoTrinity);

                                sumaEgresosPorEor += valorSumaMaterialSap;

                                #region SI COINCIDE UN PRODUCTO DE SAP CON EL EGRESO DE TRINITY, GUARDA LA CANTIDAD Y PRECIO
                                var resultSap = LecturaSapNegocio.ObtenerDetalleEgresosEorSap(itemEgresoTrinity).ToList();

                                foreach (var itemSap in resultSap)
                                {
                                    var detalleEgresoResult = resultEgresoTrinity.FirstOrDefault(det => det.IdEgrProducto == itemSap.Ref2 && det.NroParte == itemSap.Sww);
                                    if (detalleEgresoResult != null)
                                    {
                                        //using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                                        //{
                                        //    using (var context = new SigeorEntities())
                                        //    {
                                        var detalleEgreso = (from det in context.SInv_H_DEgrProducto
                                                             where det.Id_EgrProducto == itemSap.Ref2 && det.id_producto == itemSap.Sww
                                                             select det).FirstOrDefault();
                                        if (detalleEgreso != null)
                                        {
                                            detalleEgreso.CantidadReal = (int?)itemSap.Quantity;
                                            detalleEgreso.CostoReal = (decimal?)itemSap.Price;
                                            context.SInv_H_DEgrProducto.ApplyCurrentValues(detalleEgreso);
                                            context.SaveChanges();
                                        }
                                        //    }
                                        //    transactionScope.Complete();
                                        //}
                                    }
                                }


                                #endregion
                            eor.ESTADO_PROCESO += 1;
                            eor.TOTAL_REALMAT = sumaEgresosPorEor;
                            eor.TOTAL_REAL = (eor.TOTAL_REALMAT ?? 0) + (eor.TOTAL_COSTOHH ?? 0);

                            eor.TOTAL_COSTOHH = sumaManoObra;
                            context.SC_EORMAQUINARIA.Attach(eor);
                            context.ObjectStateManager.ChangeObjectState(eor, System.Data.EntityState.Modified);
                            context.SC_EORMAQUINARIA.ApplyCurrentValues(eor);
                        }
                    }
                    context.SaveChanges();
                    //  transactionScope.Complete();
                }
            }
            //}
            catch (System.Data.UpdateException ex)