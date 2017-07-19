﻿using System;using System.Collections.Generic;using System.ComponentModel;using System.Data;using System.Diagnostics;using System.Linq;using System.Text;using Negocio.Configuracion;using Negocio.Seguridad;using Negocio.Utilidades;using PersistenciaSigeor;using CoordenadasEkey = PersistenciaSigeor.CoordenadasEkey;using System.Transactions;namespace Negocio.Autenticacion{    public class CoordenadasEkeyNegocio    {        private static SigeorEntities _context;        /// <summary>        /// Inserta una CoordenadaEkey        /// </summary>        /// <param name="coordenadasEkey">CoordenadaEkey</param>        public static void Insertar(CoordenadasEkey coordenadasEkey)        {            try            {                _context = new SigeorEntities();                _context.CoordenadasEkey.AddObject(coordenadasEkey);                _context.SaveChanges();            }            catch (Exception e)            {                Log.WriteEntry("No se pudo registrar la coordenadas del Ekey: " + e, EventLogEntryType.Error);                throw new Exception("No se pudo registrar la coordenadas del Ekey: " + e.Message);            }        }        /// <summary>        /// Inserta una lista de CoordenadaEkey's        /// </summary>        /// <param name="listaCoordenadasEkey">List<CoordenadasEkey>listacoordenadasEkey</param>        public static void Insertar(List<CoordenadasEkey> listaCoordenadasEkey)        {            try            {                _context = new SigeorEntities();                foreach (var item in listaCoordenadasEkey)                {                    _context.CoordenadasEkey.AddObject(item);                    _context.SaveChanges();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo registrar la lista de coordenadas Ekey: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo registrar la lista de coordenadas Ekey: " + ex.Message);            }        }        /// <summary>        /// Inserta una CoordenadaEkey        /// </summary>        /// <param name="coordenadasEkey">CoordenadaEkey</param>        public static void Modificar(CoordenadasEkey coordenadasEkey)        {            try            {                _context = new SigeorEntities();                _context.CoordenadasEkey.ApplyCurrentValues(coordenadasEkey);                _context.SaveChanges();            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo modificar la coordenadas del Ekey: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo modificar la coordenadas del Ekey: " + ex.Message);            }        }        /// <summary>        /// Inserta una lista de CoordenadaEkey's        /// </summary>        /// <param name="listaCoordenadasEkey">List<CoordenadasEkey> listacoordenadasEkey</param>        public static void Modificar(List<CoordenadasEkey> listaCoordenadasEkey)        {            try            {                _context = new SigeorEntities();                foreach (var item in listaCoordenadasEkey)                {                    _context.CoordenadasEkey.ApplyCurrentValues(item);                    _context.SaveChanges();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo modificar la lista coordenadas del Ekey: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo modificar la lista coordenadas del Ekey: " + ex.Message);            }        }        public static void Eliminar(CoordenadasEkey coordenadasEkey)        {            try            {                _context = new SigeorEntities();                if (!coordenadasEkey.EntityState.Equals(EntityState.Deleted))                {                    //_context.CoordenadasEkey.Attach(coordenadasEkey);                    _context.ObjectStateManager.ChangeObjectState(coordenadasEkey, EntityState.Deleted);                }                _context.CoordenadasEkey.DeleteObject(coordenadasEkey);                _context.SaveChanges();            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo eliminar la coordenada Ekey: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo eliminar las coordenadasEkey: " + ex.Message);            }        }        /// <summary>        /// Retorna una CoordenadaEkey por el Id de un Ekey        /// </summary>        /// <param name="id">Id del Ekey</param>        /// <returns>CoordenadasEkey</returns>        public static CoordenadasEkey ObtenerCoordenadaEkeyPorId(Guid id)        {            CoordenadasEkey result = null;            try            {                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from coordenada in _context.CoordenadasEkey                                          where coordenada.Id == id                                          select coordenada).FirstOrDefault();                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo buscar la coordenada  Ekey por Id: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo buscar la coordenada  Ekey por Id: " + ex.Message);            }            return result;        }        /// <summary>        /// Retorna las  CoordenadaEKey por el Id de Ekey.        /// </summary>        /// <param name="idKey">Id del Ekey</param>        /// <returns>List<CoordenadasEkey></returns>        public static List<CoordenadasEkey> ObtenerCoordenadasEkeyPorIdEkey(Guid idKey)        {            List<CoordenadasEkey> result = null;            try            {                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from coordenada in _context.CoordenadasEkey                                  where coordenada.IdEkey == idKey                                  orderby coordenada.CoordenadaX, coordenada.CoordenadaY                                  select coordenada).ToList();                    }                    transactionScope.Complete();                }                //listaCoordenadasEkey = _context.CoordenadasEkey.ToList().FindAll(ent => ent.IdEkey.Equals(idKey));                //listaCoordenadasEkey.OrderBy(ent => ent.CoordenadaX);                //listaCoordenadasEkey.OrderBy(ent => ent.CoordenadaY);                //return listaCoordenadasEkey;            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo buscar las coordenadas por el IdEkey: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo buscar las coordenadas por el IdEkey: " + ex.Message);            }            return result;        }        /// <summary>        /// Compara la coordenada ingresada, retorna true si es correcta de lo contrario false.        /// A excepcion del campo Id, todos son obligatorios para la comparacion.        /// </summary>        /// <param name="CoordenadasEkey">Entidad Coordenada Ekey</param>                /// <returns>bool</returns>        //public static bool CompararCoordenadaEkey(Guid idEKey, string coordenadaX, string coordenadaY, string valor)        public static bool CompararCoordenadaEkey(string coordenadaEkey)        {            bool flag = false;            try            {                var param = Serializador.DeSerializeEntity<CoordenadasEkey>(coordenadaEkey);                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        var coordenada = (from query in context.CoordenadasEkey                                          where query.IdEkey == param.Id                                                && query.CoordenadaX == param.CoordenadaX                                                && query.CoordenadaY == param.CoordenadaY                                                && query.Valor == param.Valor                                          select query).FirstOrDefault();                        var tipoAuditoria = (from tipo in context.TipoAuditoria                                             where tipo.Codigo == param.CampoTipoAccion                                             select tipo).FirstOrDefault();                        Auditoria auditoria = null;                        if (tipoAuditoria != null && tipoAuditoria.Descripcion != null)                        {                            auditoria = new Auditoria                            {                                Id = Guid.NewGuid(),                                Cedula = param.CampoCedulaUsuario,                                Fecha = DateTime.Today,                                Hora = DateTime.Now.ToString("HH:mm:ss"),                                IdObjeto = param.CampoCedulaUsuario,                                NombreTabla = string.Empty,                                NombreCampo = string.Empty,                                CodigoTipo = param.CampoTipoAccion,                                Ip = param.CampoIpUsuario                            };                        }                        if (coordenada != null)                        {                            auditoria.Descripcion = "LOGIN EXITOSO";                            flag = true;                            AuditoriaNegocio.Insertar(Serializador.SerializeEntity(auditoria));                        }                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo comparar las Coordenadas del Ekey: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo comparar las Coordenadas del Ekey: " + ex.Message);            }            return flag;        }        /// <summary>        /// Elimina El Ekey y las Coordenadas realizando una busqueda por la cedula un usuario        /// </summary>        /// <param name="cedula">Cedula del Usuario</param>        private static void EliminarCoordenadaEkeyPorCedulaUsuario(string cedula)        {            try            {                _context = new SigeorEntities();                var result = EkeyNegocio.ObtenerEkeyPorCedulaUsuario(cedula);                var ekey = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<EKey>(result) : new EKey();                if (ekey != null)                {                    var listaCoordenadasEkey = (from ekeyResult in _context.CoordenadasEkey                                                where ekeyResult.Id == ekey.Id                                                select ekeyResult).ToList();                    //_context.CoordenadasEkey.ToList().FindAll(ent => ent.IdEkey.Equals(ekey.Id));                    foreach (var coordenada in listaCoordenadasEkey)                    {                        _context.DeleteObject(coordenada);                    }                    _context.SaveChanges();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo eliminar el ekey, ni las Coordenadas: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo eliminar el ekey, ni las Coordenadas: " + ex.Message);            }        }        /// <summary>        /// Genera las coordenadas por Ekey        /// </summary>        /// <param name="EKeyerializado">Ekey</param>        public static string GenerarCoordenadasEkey(string EKeyerializado)        {            List<CoordenadasEkey> lista = null;            try            {                _context = new SigeorEntities();                lista = new List<CoordenadasEkey>();                const string letrasEkey = "ABCDEFGHIJ";                var ekey = Serializador.DeSerializeEntity<EKey>(EKeyerializado);                EKey result;                using (var context = new SigeorEntities())                {                    result = (from ekeyResult in context.EKey                              where ekeyResult.CedulaUsuario == ekey.CedulaUsuario                              select ekeyResult).FirstOrDefault();                }                //if (_context.EKey.ToList().Find(ent => ent.CedulaUsuario.Equals(ekey.CedulaUsuario)) == null)                if (result == null)                {                    _context.EKey.AddObject(ekey);                    _context.SaveChanges();                }                EliminarCoordenadaEkeyPorCedulaUsuario(ekey.CedulaUsuario);//Primero busca si el usuario ya tiene ekey con coordenadas                 foreach (var letra in letrasEkey)                {                    for (var i = 1; i <= 9; i++)                    {                        var coordenadaEkey = new CoordenadasEkey();                        var coordenadaEkeyEncriptado = new CoordenadasEkey();                        var numero = string.Empty;                        while (lista.Count(num => num.Valor.Equals(numero)) != 0 || string.IsNullOrEmpty(numero))                        {                            var random = new Random();                            numero = random.Next(100, 1000).ToString();                        }                        coordenadaEkey.Id = Guid.NewGuid();                        coordenadaEkey.IdEkey = ekey.Id;                        coordenadaEkey.CoordenadaX = letra.ToString();                        coordenadaEkey.CoordenadaY = i.ToString();                        coordenadaEkey.Valor = numero;                        lista.Add(coordenadaEkey);                        coordenadaEkeyEncriptado.Id = Guid.NewGuid();                        coordenadaEkeyEncriptado.IdEkey = ekey.Id;                        coordenadaEkeyEncriptado.CoordenadaX = MetodosEncriptacion.EncriptarMD5(letra.ToString());                        coordenadaEkeyEncriptado.CoordenadaY = MetodosEncriptacion.EncriptarMD5(i.ToString());                        coordenadaEkeyEncriptado.Valor = MetodosEncriptacion.EncriptarMD5(numero);                        _context.CoordenadasEkey.AddObject(coordenadaEkeyEncriptado);                        _context.SaveChanges();                    }                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo generar el Ekey para el usuario ingresado: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo generar el Ekey para el usuario ingresado: " + ex.Message);            }            return lista.Any() ? Serializador.SerializeEntity(lista) : null;        }    }}
