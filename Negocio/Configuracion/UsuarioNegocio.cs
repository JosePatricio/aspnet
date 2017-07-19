﻿using System;using System.Collections.Generic;using System.Data;using System.Linq;using System.Transactions;using Negocio.Utilidades;using PersistenciaSigeor;using System.Diagnostics;namespace Negocio.Configuracion{    public class UsuarioNegocio    {        private static SigeorEntities _context = new SigeorEntities();        public static void Insertar(string usuarioSerializado)        {            try            {                Usuario usuario = Serializador.DeSerializeEntity<Usuario>(usuarioSerializado);                _context = new SigeorEntities();                _context.Usuario.Attach(usuario);                _context.ObjectStateManager.ChangeObjectState(usuario, EntityState.Added);                _context.SaveChanges();                AuditoriaNegocio.InsertarAuditoria(usuario, null, TipoAuditoriaEnum.INS);            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo registrar el usuario: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo registrar el usuario: " + ex.Message);            }        }        public static void Modificar(string usuarioSerializado)        {            try            {                var result = Serializador.DeSerializeEntity<Usuario>(usuarioSerializado);                if (result != null)                    _context = new SigeorEntities();                var busqueda = _context.Usuario.ToList().Find(ent => ent.Cedula.Equals(result.Cedula));                Usuario usuarioAnterior = null;                if (result != null)                    usuarioAnterior = Reflection.ClonarEntidadAuditoria(busqueda);                if (result != null)                {                    _context.Usuario.ApplyCurrentValues(result);                    _context.SaveChanges();                    AuditoriaNegocio.InsertarAuditoria(result, usuarioAnterior, TipoAuditoriaEnum.UPD);                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo modificar el usuario: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo modificar el usuario: " + ex.Message);            }        }        public static void Eliminar(string usuarioSerializado)        {            try            {                var usuario = Serializador.DeSerializeEntity<Usuario>(usuarioSerializado);                if (_context.Usuario.ToList().Find(ent => ent.Cedula.Equals(usuario.Cedula)) != null)                {                    _context.Usuario.Attach(usuario);                    _context.ObjectStateManager.ChangeObjectState(usuario, EntityState.Deleted);                    _context.SaveChanges();                    AuditoriaNegocio.InsertarAuditoria(usuario, null, TipoAuditoriaEnum.DEL);                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo eliminar el usuario: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo eliminar el usuario: " + ex.Message);            }        }        public static string ObtenerUsuarioPorEstado(bool estado)        {            List<Usuario> result;            try            {                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from usuario in context.Usuario                                  where usuario.Estado.Value.Equals(estado)                                  orderby usuario.Nombre, usuario.Apellido                                  select usuario).ToList();                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener los usuarios por estado: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener los usuarios por estado: " + ex.Message);            }            return result.Any() ? Serializador.SerializeEntity(result) : null;        }        public static string ObtenerUsuario()        {            List<Usuario> result;            try            {                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from usuario in context.Usuario                                  orderby usuario.Nombre, usuario.Apellido                                  select usuario).ToList();                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener los usuarios: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener los usuarios: " + ex.Message);            }            return result.Any() ? Serializador.SerializeEntity(result) : null;        }        public static string ObtenerUsuarioPorCedula(string cedula)        {            Usuario result;            try            {                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from usuario in context.Usuario                                  where usuario.Cedula.ToUpper().Contains(cedula.ToUpper())                                  select usuario).FirstOrDefault();                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener el usuario por cedula: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener el usuario por cedula: " + ex.Message);            }            return result != null ? Serializador.SerializeEntity(result) : null;        }        public static string ObtenerUsuarioPorCorreo(string email)        {            Usuario result;            try            {                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from usuario in context.Usuario                                  where usuario.Email.ToUpper().Contains(email.ToUpper())                                  select usuario).FirstOrDefault();                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener el usuario por el email: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener el usuarioel email: " + ex.Message);            }            return result != null ? Serializador.SerializeEntity(result) : null;        }        public static string ObtenerUsuarioPorCoincidencia(string value, bool estado)        {            List<Usuario> result;            try            {                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from usuario in context.Usuario                                  where (usuario.Cedula.ToUpper().Contains(value.ToUpper()) ||                                         usuario.Nombre.ToUpper().Contains(value.ToUpper()) ||                                         usuario.Direccion.ToUpper().Contains(value.ToUpper()) ||                                         usuario.Email.ToUpper().Contains(value.ToUpper()) ||                                         usuario.Celular.ToUpper().Contains(value.ToUpper()) ||                                         usuario.Apellido.ToUpper().Contains(value.ToUpper())) &&                                        usuario.Estado.Value.Equals(estado)                                  orderby usuario.Nombre, usuario.Apellido                                  select usuario).ToList();                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener los usuarios por coincidencia: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener los usuarios por coincidencia: " + ex.Message);            }            return result.Any() ? Serializador.SerializeEntity(result) : null;        }        public static string ObtenerUsuarioPaginado(int pagesize, int pageIndex, out int totalRegistros)        {            List<Usuario> result;            try            {                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from usuario in context.Usuario                                  orderby usuario.Nombre, usuario.Apellido                                  select usuario).ToList();                    }                    transactionScope.Complete();                }                totalRegistros = result.Count;                result = result.Skip(pagesize * (pageIndex-1)).Take(pagesize).ToList();            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener los usuarios paginado: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener los usuarios paginado: " + ex.Message);            }            return result.Any() ? Serializador.SerializeEntity(result) : null;        }        public static string ObtenerUsuarioPorCoincidenciaPaginado(string value, bool estado, int pagesize, int pageIndex, out int totalRegistros)        {            List<Usuario> result;            try            {                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from usuario in context.Usuario                                  where (usuario.Cedula.ToUpper().Contains(value.ToUpper()) ||                                         usuario.Nombre.ToUpper().Contains(value.ToUpper()) ||                                         usuario.Direccion.ToUpper().Contains(value.ToUpper()) ||                                         usuario.Email.ToUpper().Contains(value.ToUpper()) ||                                         usuario.Celular.ToUpper().Contains(value.ToUpper()) ||                                         usuario.Apellido.ToUpper().Contains(value.ToUpper())) &&                                        usuario.Estado.Value.Equals(estado)                                  orderby usuario.Nombre, usuario.Apellido                                  select usuario).ToList();                    }                    transactionScope.Complete();                }                totalRegistros = result.Count;                result = result.Skip(pagesize * (pageIndex-1)).Take(pagesize).ToList();            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener los usuarios por coincidencia paginado: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener los usuarios por coincidencia paginado: " + ex.Message);            }            return result.Any() ? Serializador.SerializeEntity(result) : null;        }        public static string ObtenerUsuarioPorEstadoPaginado(bool estado, int pagesize, int pageIndex, out int totalRegistros)        {            List<Usuario> result;            try            {                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        result = (from usuario in context.Usuario                                  where usuario.Estado.Value.Equals(estado)                                  orderby usuario.Nombre, usuario.Apellido                                  select usuario).ToList();                    }                    transactionScope.Complete();                }                totalRegistros = result.Count;                result = result.Skip(pagesize * (pageIndex-1)).Take(pagesize).ToList();            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener los usuarios por estado paginado: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener los usuarios por estado paginado: " + ex.Message);            }            return result.Any() ? Serializador.SerializeEntity(result) : null;        }        public static void ModificarMasivamente(string value, bool estado)        {            try            {                value = value.ToUpper();                TransactionOptions transactionOptions = new TransactionOptions                {                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted                };                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))                {                    using (var context = new SigeorEntities())                    {                        List<Usuario> result;                        if (!string.IsNullOrEmpty(value))                        {                            var usuario = ObtenerUsuarioPorCoincidencia(value, estado);                            result = !string.IsNullOrEmpty(usuario)                                ? Serializador.DeSerializeEntity<List<Usuario>>(usuario)                                : null;                        }                        else                        {                            var usuario = ObtenerUsuarioPorEstado(estado);                            result = !string.IsNullOrEmpty(usuario)                            ? Serializador.DeSerializeEntity<List<Usuario>>(usuario)                            : null;                        }                        if (result != null)                            foreach (var user in result)                            {                                user.Estado = !user.Estado;                                if (user.EntityState.Equals(EntityState.Detached))                                {                                    context.Usuario.Attach(user);                                    context.ObjectStateManager.ChangeObjectState(user, EntityState.Modified);                                }                                context.Usuario.ApplyCurrentValues(user);                                context.SaveChanges();                            }                    }                    transactionScope.Complete();                }            }            catch (Exception ex)            {                Log.WriteEntry("No se pudo obtener modificar los usuarios de forma masiva: " + ex, EventLogEntryType.Error);                throw new Exception("No se pudo obtener modificar los usuarios de forma masiva: " + ex.Message);            }        }    }}