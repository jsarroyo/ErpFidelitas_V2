using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System; 
using System.Linq; 

namespace Api.ErpFidelitas.General.v2.BusinessLogic
{
	public class CompaniesBL : IGeneralBase<Companies>
	{
		public CompaniesBL ()
		{ 
		}
		public Request GetById(int CompanyId,object id=null)
		{
			Request request = new Request();
			using (var dBEntities = new ErpDBEntities())
			{
				dBEntities.Configuration.ProxyCreationEnabled = false;
				dBEntities.Configuration.LazyLoadingEnabled = false;
				try
				{
					var Entidades = (from u in dBEntities.Companies
									 where u.CompanyId == CompanyId
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
		public Request Insert(Companies insertar)
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
					var Entidades = (from u in dBEntities.Companies
									 where u.CompanyId == insertar.CompanyId
									 select u).FirstOrDefault();
					if (Entidades == null)
					{
						dBEntities.Companies.Add(insertar);
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
		public Request Delete(int CompanyId, object id=null)
		{

			Request request = new Request();
			using (var dBEntities = new ErpDBEntities())
			{
				dBEntities.Configuration.ProxyCreationEnabled = false;
				dBEntities.Configuration.LazyLoadingEnabled = false;
				try
				{
					var tieneRegistrosEnCuentasCobrar = (from u in dBEntities.MovementsAccountsReceivable
									 where u.CompanyId == CompanyId
									 select u).Any();

					if (tieneRegistrosEnCuentasCobrar)
					{
						return request.DoWarning($"No se permite borrar registros por que tiene relaciones en otros modulos.");

					}


					var tieneRegistrosEnInventerio = (from u in dBEntities.MovementsInventory
													  where u.CompanyId == CompanyId
													  select u).Any();

					if (tieneRegistrosEnInventerio)
					{
						return request.DoWarning($"No se permite borrar registros por que tiene relaciones en otros modulos.");

					}
					var tieneRegistrosEnCuentasPagar = (from u in dBEntities.MovementsDebtsToPay
													  where u.CompanyId == CompanyId
													  select u).Any();

					if (tieneRegistrosEnCuentasPagar)
					{
						return request.DoWarning($"No se permite borrar registros por que tiene relaciones en otros modulos.");

					}

					var tieneParameters = (from u in dBEntities.Parameters
														where u.CompanyId == CompanyId
														select u).Any();

					if (tieneParameters)
					{
						return request.DoWarning($"No se permite borrar registros por que tiene relaciones en otros modulos.");

					}

					

					var Entidades = (from u in dBEntities.Companies
									 where u.CompanyId == CompanyId
									 select u).FirstOrDefault();
					if (Entidades == null)
					{
						return request.DoWarning($"No se encontraron entidades por borrar.");
					}

					dBEntities.Companies.Remove(Entidades);
					var count = dBEntities.SaveChanges();
					return request.DoSuccess(Entidades, $"Se eliminó {count} registro correctamente");
				}
				catch (Exception ex)
				{

					return request.DoError(ex.Message);
				}
			}

		}
		public Request GetAll(int CompanyId=0)
		{
			Request request = new Request();
			using (var dBEntities = new ErpDBEntities())
			{
				dBEntities.Configuration.ProxyCreationEnabled = false;
				dBEntities.Configuration.LazyLoadingEnabled = false;
				try
				{
					var Entidades = (from u in dBEntities.Companies 
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
					var Entidades = (from u in dBEntities.Companies
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
		public Request UpdateById(Companies actualizar)
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
					var Entidades = (from u in dBEntities.Companies
									 where u.CompanyId == actualizar.CompanyId
									 select u).FirstOrDefault();
					if (Entidades == null)
					{
						return request.DoWarning($"No se encontraron entidades por actualizar.");
					}

					Entidades.Active = actualizar.Active;
					Entidades.Mision = actualizar.Mision;
					Entidades.Vision = actualizar.Vision;
					Entidades.PrincipalEmail = actualizar.PrincipalEmail;
					Entidades.Name = actualizar.Name;


					var count = dBEntities.SaveChanges();
					return request.DoSuccess(Entidades, $"Se insertó {count} registro correctamente");
				}
				catch (Exception ex)
				{

					return request.DoError(ex.Message);
				}
			}
		}
		public Request Validations(Companies verificar)
		{
			Request request = new Request();
			 
			if (string.IsNullOrEmpty(verificar.Name)) {
				return request.DoError("El nombre no puede estar vacio");
			}
			return request.DoSuccess();
		}
	}

	

	
	
}