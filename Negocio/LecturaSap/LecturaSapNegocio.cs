﻿using System;

namespace Negocio.LecturaSap
                        //result = (from cab in context.OIGE
                        //          join det in context.IGE1 on cab.DocEntry equals det.DocEntry
                        //          where cab.Ref2 == egresoTrinity
                        //          select new EgresoEorSap
                        //          {
                        //              DocEntry = cab.DocEntry,
                        //              LineNum = det.LineNum,
                        //              DocDate = cab.DocDate,
                        //              DocDueDate = cab.DocDueDate,
                        //              DocTotal = cab.DocTotal,
                        //              DocTotalFC = cab.DocTotalFC,
                        //              DocTotalSy = cab.DocTotalSy,
                        //              UpdateDate = cab.UpdateDate,
                        //              CreateDate = cab.CreateDate,
                        //              Max1099 = cab.Max1099,
                        //              ItemCode = det.ItemCode,
                        //              Quantity = det.Quantity,
                        //              Price = det.Price,
                        //              LineTotal = det.LineTotal

                        //          }).ToList();
                    }

                    decimal valorMaterial = 0;
                    decimal valorPorcentaje = 0;


                    //if (!result.Any())
                    //{
                    //    valorMaterial = result.Sum(ent => ent.LineTotal) ?? 0;
                    //    valorPorcentaje = valorMaterial * (negociacionProveedor.PrecioHHEstructura / 100);
                    //    suma = valorMaterial + valorPorcentaje;
                    //}
                    suma = result.Sum(ent => ent.LineTotal) ?? 0;
                    transactionScope.Complete();

                }
                        //result = context.GET_EGRESO_EOR_SAP(egresoTrinity).ToList();
                        result = (from cab in context.OIGE
                        //result = context.GET_DETALLE_EGRESO_EOR_SAP(egresoTrinity).ToList();
                        result = (from cab in context.OIGE