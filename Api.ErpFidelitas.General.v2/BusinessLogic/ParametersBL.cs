using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
namespace Api.ErpFidelitas.General.v2.BusinessLogic
{
    public class ParametersBL : IGeneralBase<Parameters>
    {
        public Request Delete(int CompanyId = 0, object id = null)
        {
            Request request = new Request();
            using (var dBEntities = new ErpDBEntities())
            {
                dBEntities.Configuration.ProxyCreationEnabled = false;
                dBEntities.Configuration.LazyLoadingEnabled = false;
                try
                {
                    var Entidades = (from u in dBEntities.Parameters
                                     where u.ParameterId == (int)id
                                      && u.CompanyId == CompanyId
                                     select u).FirstOrDefault();
                    if (Entidades == null)
                    {
                        return request.DoWarning($"No se encontraron entidades por borrar.");
                    }

                    dBEntities.Parameters.Remove(Entidades);
                    var count = dBEntities.SaveChanges();
                    return request.DoSuccess(Entidades, $"Se eliminó {count} registro correctamente");
                }
                catch (Exception ex)
                {

                    return request.DoError(ex.Message);
                }
            }
        }

        public Request GetAll(int CompanyId = 0)
        {
            Request request = new Request();
            using (var dBEntities = new ErpDBEntities())
            {
                dBEntities.Configuration.ProxyCreationEnabled = false;
                dBEntities.Configuration.LazyLoadingEnabled = false;
                try
                {
                    var Entidades = (from u in dBEntities.Parameters
                                     where u.CompanyId == CompanyId
                                     select u).ToList();
                    if (Entidades == null)
                    {
                        return request.DoWarning($"No se obtuvieron resultados en la búsqueda");
                    }
                    return request.DoSuccess(Entidades, $"Se encontraron {Entidades.Count} resultados");
                }
                catch (Exception ex)
                {
                    return request.DoError(ex.Message);
                }
            }
        }

        public Request GetByCondition()
        {
            Request request = new Request();
            using (var dBEntities = new ErpDBEntities())
            {
                dBEntities.Configuration.ProxyCreationEnabled = false;
                dBEntities.Configuration.LazyLoadingEnabled = false;
                try
                {
                    var Entidades = (from u in dBEntities.Parameters
                                     select u).ToList();
                    if (Entidades == null)
                    {
                        return request.DoWarning($"No se obtuvieron resultados en la búsqueda");
                    }
                    return request.DoSuccess(Entidades, $"Se encontraron {Entidades.Count} resultados");
                }
                catch (Exception ex)
                {
                    return request.DoError(ex.Message);
                }
            }
        }

        public Request GetById(int CompanyId = 0, object id = null)
        {
            Request request = new Request();
            using (var dBEntities = new ErpDBEntities())
            {
                dBEntities.Configuration.ProxyCreationEnabled = false;
                dBEntities.Configuration.LazyLoadingEnabled = false;
                try
                {
                    var Entidades = (from u in dBEntities.Parameters
                                     where u.ParameterId == (int)id
                                     && u.CompanyId == CompanyId
                                     select u).FirstOrDefault();
                    if (Entidades == null)
                    {
                        return request.DoWarning($"No se obtuvieron resultados en la búsqueda del ID {id}");
                    }
                    return request.DoSuccess(Entidades, $"Se encontró {1} resultado");
                }
                catch (Exception ex)
                {

                    return request.DoError(ex.Message);
                }
            }
        }

        public Request Insert(Parameters insertar)
        {
            Request request = new Request();
            request = Validations(insertar);
            if (!request.Success)
            {
                return request;
            }

            using (var dBEntities = new ErpDBEntities())
            {

                dBEntities.Configuration.ProxyCreationEnabled = false;
                dBEntities.Configuration.LazyLoadingEnabled = false;
                try
                {
                    var Entidades = (from u in dBEntities.Parameters
                                     where u.ParameterId == insertar.ParameterId
                                     && u.CompanyId == insertar.CompanyId
                                     select u).FirstOrDefault();
                    if (Entidades == null)
                    {
                        dBEntities.Parameters.Add(insertar);
                        var count = dBEntities.SaveChanges();
                        return request.DoSuccess(Entidades, $"Se inserto {count} registro correctamente");
                    }
                    return request.DoWarning($"Ya se encuentra registrado. No se insertó.");
                }
                catch (Exception ex)
                {

                    return request.DoError(ex.Message);
                }
            }
        }

        public Request UpdateById(Parameters actualizar)
        {
            Request request = new Request();
            request = Validations(actualizar);
            if (!request.Success)
            {
                return request;
            }
            using (var dBEntities = new ErpDBEntities())
            {
                dBEntities.Configuration.ProxyCreationEnabled = false;
                dBEntities.Configuration.LazyLoadingEnabled = false;
                try
                {
                    var Entidades = (from u in dBEntities.Parameters
                                     where u.ParameterId == actualizar.ParameterId
                                     && u.CompanyId == actualizar.CompanyId
                                     select u).FirstOrDefault();
                    if (Entidades == null)
                    {
                        return request.DoWarning($"No se encontraron entidades por actualizar.");
                    }

                    Entidades.Details = actualizar.Details;
                    Entidades.Name = actualizar.Name;
                    Entidades.Value = actualizar.Value;

                    var count = dBEntities.SaveChanges();
                    return request.DoSuccess(Entidades, $"Se insertó {count} registro correctamente");
                }
                catch (Exception ex)
                {

                    return request.DoError(ex.Message);
                }
            }
        }

        public Request Validations(Parameters verificar)
        {
            Request request = new Request();

            if (verificar.Name == null)
            {
                return request.DoError("El monto no puede estar vacio");
            }
            return request.DoSuccess();
        }
    }
}