using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System; 
using System.Linq; 

namespace Api.ErpFidelitas.General.v2.BusinessLogic
{
	public class RolUsersBL : IGeneralBase<RolUsers>
	{
		public RolUsersBL()
		{
		}
		public Request GetById(int Company = 0,object id=null)
		{
			Request request = new Request();
			using (var dBEntities = new ErpDBEntities())
			{
				dBEntities.Configuration.ProxyCreationEnabled = false;
				dBEntities.Configuration.LazyLoadingEnabled = false;
				try
				{
					var Entidades = (from u in dBEntities.RolUsers
									 where u.RolId == (int)id
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
		public Request Insert(RolUsers insertar)
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
					var Entidades = (from u in dBEntities.RolUsers
									 where u.RolId == insertar.RolId
									 select u).FirstOrDefault();
					if (Entidades == null)
					{
						dBEntities.RolUsers.Add(insertar);
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
		public Request Delete(int Company = 0,object id=null)
		{

			Request request = new Request();
			using (var dBEntities = new ErpDBEntities())
			{
				dBEntities.Configuration.ProxyCreationEnabled = false;
				dBEntities.Configuration.LazyLoadingEnabled = false;
				try
				{
					var Entidades = (from u in dBEntities.RolUsers
									 where u.RolId == (int)id
									 select u).FirstOrDefault();
					if (Entidades == null)
					{
						return request.DoWarning($"No se encontraron entidades por borrar.");
					}

					dBEntities.RolUsers.Remove(Entidades);
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
					var Entidades = (from u in dBEntities.RolUsers
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
					var Entidades = (from u in dBEntities.RolUsers
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
		public Request UpdateById(RolUsers actualizar)
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
					var Entidades = (from u in dBEntities.RolUsers
									 where u.RolId == actualizar.RolId
									 select u).FirstOrDefault();
					if (Entidades == null)
					{
						return request.DoWarning($"No se encontraron entidades por actualizar.");
					}

					Entidades.TypeRol = actualizar.TypeRol; 

					var count = dBEntities.SaveChanges();
					return request.DoSuccess(Entidades, $"Se insertó {count} registro correctamente");
				}
				catch (Exception ex)
				{

					return request.DoError(ex.Message);
				}
			}
		}
		public Request Validations(RolUsers verificar)
		{
			Request request = new Request();

			if (string.IsNullOrEmpty(verificar.TypeRol))
			{
				return request.DoError("El tipo de roll no puede estar vacio");
			}
			return request.DoSuccess();
		}

	}
}