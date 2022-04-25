﻿using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.ErpFidelitas.General.v2.BusinessLogic
{
    public class CurrencysBL : IGeneralBase<Currencys>
    {

		public Request Insert(Currencys insertar)
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
					var Entidades = (from u in dBEntities.Currencys
									 where u.CurrencyId == insertar.CurrencyId
									 select u).FirstOrDefault();
					if (Entidades == null)
					{
						dBEntities.Currencys.Add(insertar);
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
		}//Fin Class Insert 

		public Request GetById(int CurrencyId, object id = null)
		{
			Request request = new Request();
			using (var dBEntities = new ErpDBEntities())
			{
				dBEntities.Configuration.ProxyCreationEnabled = false;
				dBEntities.Configuration.LazyLoadingEnabled = false;
				try
				{
					var Entidades = (from u in dBEntities.Currencys
									 where u.CurrencyId == CurrencyId
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
		}//Fin GetbyId

		public Request GetAll(int Company = 0)
		{
			Request request = new Request();
			using (var dBEntities = new ErpDBEntities())
			{
				dBEntities.Configuration.ProxyCreationEnabled = false;
				dBEntities.Configuration.LazyLoadingEnabled = false;
				try
				{
					var Entidades = (from u in dBEntities.Currencys
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
		}//Fin GetAll

		public Request GetByCondition()
		{
			Request request = new Request();
			using (var dBEntities = new ErpDBEntities())
			{
				dBEntities.Configuration.ProxyCreationEnabled = false;
				dBEntities.Configuration.LazyLoadingEnabled = false;
				try
				{
					var Entidades = (from u in dBEntities.Currencys
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
		}//Fin GetByCondition

		public Request UpdateById(Currencys actualizar)
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
					var Entidades = (from u in dBEntities.Currencys
									 where u.CurrencyId == actualizar.CurrencyId
									 select u).FirstOrDefault();
					if (Entidades == null)
					{
						return request.DoWarning($"No se encontraron entidades por actualizar.");
					}

					Entidades.Name= actualizar.Name;

					var count = dBEntities.SaveChanges();
					return request.DoSuccess(Entidades, $"Se insertó {count} registro correctamente");
				}
				catch (Exception ex)
				{
					return request.DoError(ex.Message);
				}
			}
		}//Fin UpdateById

		public Request Delete(int CurrencyId, object id = null)
		{

			Request request = new Request();
			using (var dBEntities = new ErpDBEntities())
			{
				dBEntities.Configuration.ProxyCreationEnabled = false;
				dBEntities.Configuration.LazyLoadingEnabled = false;
				try
				{

					var tieneRegistrosEnCuentasPorCobrar = (from u in dBEntities.MovementsAccountsReceivable
															where u.CurrencyId == CurrencyId
															select u).Any();
					if (tieneRegistrosEnCuentasPorCobrar)
					{
						return request.DoWarning($"No se permite borrar registros por que tiene relaciones en otros modulos.");
					}

					var tieneRegistrosEnCuentasPorPagar = (from u in dBEntities.MovementsDebtsToPay
														   where u.CurrencyId == CurrencyId
														   select u).Any();
					if (tieneRegistrosEnCuentasPorPagar)
					{
						return request.DoWarning($"No se permite borrar registros por que tiene relaciones en otros modulos.");
					}

					var tieneRegistrosEnInventarioUnitPrice = (from u in dBEntities.MovementsInventory
														   where u.UnitPriceCurrencyId == CurrencyId
														   select u).Any();
					if (tieneRegistrosEnInventarioUnitPrice)
					{
						return request.DoWarning($"No se permite borrar registros por que tiene relaciones en otros modulos.");
					}
					var tieneRegistrosEnInventarioCost = (from u in dBEntities.MovementsInventory
															   where u.CostCurrencyId == CurrencyId
															   select u).Any();
					if (tieneRegistrosEnInventarioCost)
					{
						return request.DoWarning($"No se permite borrar registros por que tiene relaciones en otros modulos.");
					}

					var tieneRegistrosEnProductsUnitPrice = (from u in dBEntities.Products
															   where u.UnitPriceCurrencyId == CurrencyId
															   select u).Any();
					if (tieneRegistrosEnProductsUnitPrice)
					{
						return request.DoWarning($"No se permite borrar registros por que tiene relaciones en otros modulos.");
					}

					var tieneRegistrosEnProductsUnitCost = (from u in dBEntities.Products
															 where u.UnitCostCurrencyId == CurrencyId
															 select u).Any();
					if (tieneRegistrosEnProductsUnitCost)
					{
						return request.DoWarning($"No se permite borrar registros por que tiene relaciones en otros modulos.");
					}


					var Entidades = (from u in dBEntities.Currencys
									 where u.CurrencyId == CurrencyId
									 select u).FirstOrDefault();
					if (Entidades == null)
					{
						return request.DoWarning($"No se encontraron entidades por borrar.");
					}

					dBEntities.Currencys.Remove(Entidades);
					var count = dBEntities.SaveChanges();
					return request.DoSuccess(Entidades, $"Se eliminó {count} registro correctamente");
				}
				catch (Exception ex)
				{
					return request.DoError(ex.Message);
				}
			}
		}//Fin Delete

		public Request Validations(Currencys verificar)
		{
			Request request = new Request();

			if (string.IsNullOrEmpty(verificar.Name))
			{
				return request.DoError("El nombre no puede estar vacio");
			}
			return request.DoSuccess();
		}//Fin Validations

    }


}