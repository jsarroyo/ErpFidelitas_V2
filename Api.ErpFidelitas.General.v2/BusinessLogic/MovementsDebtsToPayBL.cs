using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;

namespace Api.ErpFidelitas.General.v2.BusinessLogic
{
    public class MovementsDebtsToPayBL : IGeneralBase<MovementsDebtsToPay>
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
                    var Entidades = (from u in dBEntities.MovementsDebtsToPay
                                     where u.DebtsToPayId == (short)id
                                      && u.CompanyId == CompanyId
                                     select u).FirstOrDefault();
                    if (Entidades == null)
                    {
                        return request.DoWarning($"No se encontraron entidades por borrar.");
                    }

                    dBEntities.MovementsDebtsToPay.Remove(Entidades);
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
                    var Entidades = (from u in dBEntities.MovementsDebtsToPay
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
                    var Entidades = (from u in dBEntities.MovementsDebtsToPay
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
                    var Entidades = (from u in dBEntities.MovementsDebtsToPay
                                     where u.DebtsToPayId == (short)id
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

        public Request Insert(MovementsDebtsToPay insertar)
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
                    var Entidades = (from u in dBEntities.MovementsDebtsToPay
                                     where u.DebtsToPayId == insertar.DebtsToPayId
                                     && u.CompanyId == insertar.CompanyId
                                     select u).FirstOrDefault();
                    if (Entidades == null)
                    {
                        dBEntities.MovementsDebtsToPay.Add(insertar);
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

        public Request UpdateById(MovementsDebtsToPay actualizar)
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
                    var Entidades = (from u in dBEntities.MovementsDebtsToPay
                                     where u.DebtsToPayId == actualizar.DebtsToPayId
                                     && u.CompanyId == actualizar.CompanyId
                                     select u).FirstOrDefault();
                    if (Entidades == null)
                    {
                        return request.DoWarning($"No se encontraron entidades por actualizar.");
                    }

                    Entidades.Amount = actualizar.Amount;

                    var count = dBEntities.SaveChanges();
                    return request.DoSuccess(Entidades, $"Se insertó {count} registro correctamente");
                }
                catch (Exception ex)
                {

                    return request.DoError(ex.Message);
                }
            }
        }

        public Request Validations(MovementsDebtsToPay verificar)
        {
            Request request = new Request();

            if (verificar.Amount == null)
            {
                return request.DoError("El monto no puede estar vacio");
            }
            return request.DoSuccess();
        }
    }
}