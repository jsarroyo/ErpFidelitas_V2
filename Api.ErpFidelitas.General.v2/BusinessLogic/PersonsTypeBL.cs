using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System;
using System.Linq;

namespace Api.ErpFidelitas.General.v2.BusinessLogic
{
	public class PersonsTypeBL : IGeneralBase<PersonType>
	{
		public PersonsTypeBL()
		{
		}
		public Request GetById(int CompanyId, object id=null)
		{
			Request request = new Request();
			using (var dBEntities = new ErpDBEntities())
			{
				dBEntities.Configuration.ProxyCreationEnabled = false;
				dBEntities.Configuration.LazyLoadingEnabled = false;
				try
				{
					var Entidades = (from u in dBEntities.PersonType
									 where u.PersonTypeId == (int)id
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
		public Request Insert(PersonType insertar)
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
					var Entidades = (from u in dBEntities.PersonType
									 where u.PersonTypeId == insertar.PersonTypeId
									 select u).FirstOrDefault();
					if (Entidades == null)
					{
						dBEntities.PersonType.Add(insertar);
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
		public Request Delete(int CompanyId, object id)
		{

			Request request = new Request();
			using (var dBEntities = new ErpDBEntities())
			{
				dBEntities.Configuration.ProxyCreationEnabled = false;
				dBEntities.Configuration.LazyLoadingEnabled = false;
				try
				{
					var Entidades = (from u in dBEntities.PersonType
									 where u.PersonTypeId == (int)id
									 select u).FirstOrDefault();
					if (Entidades == null)
					{
						return request.DoWarning($"No se encontraron entidades por borrar.");
					}

					dBEntities.PersonType.Remove(Entidades);
					var count = dBEntities.SaveChanges();
					return request.DoSuccess(Entidades, $"Se eliminó {count} registro correctamente");
				}
				catch (Exception ex)
				{

					return request.DoError(ex.Message);
				}
			}

		}
		public Request GetAll(int Company=0)
		{
			Request request = new Request();
			using (var dBEntities = new ErpDBEntities())
			{
				dBEntities.Configuration.ProxyCreationEnabled = false;
				dBEntities.Configuration.LazyLoadingEnabled = false;
				try
				{
					var Entidades = (from u in dBEntities.PersonType
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
					var Entidades = (from u in dBEntities.PersonType
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
		public Request UpdateById(PersonType actualizar)
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
					var Entidades = (from u in dBEntities.PersonType
									 where u.PersonTypeId == actualizar.PersonTypeId
									 select u).FirstOrDefault();
					if (Entidades == null)
					{
						return request.DoWarning($"No se encontraron entidades por actualizar.");
					}

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
		public Request Validations(PersonType verificar)
		{
			Request request = new Request();

			if (string.IsNullOrEmpty(verificar.Name))
			{
				return request.DoError("El nombre no puede estar vacio");
			}
			return request.DoSuccess();
		}

	}
}