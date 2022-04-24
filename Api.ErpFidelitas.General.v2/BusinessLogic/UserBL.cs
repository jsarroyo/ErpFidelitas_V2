using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.ErpFidelitas.General.v2.BusinessLogic
{
		public class UserBL : IGeneralBase<Users>
		{
			public Request GetById(int UserId, object id = null)
			{
				Request request = new Request();
				using (var dBEntities = new ErpDBEntities())
				{
					dBEntities.Configuration.ProxyCreationEnabled = false;
					dBEntities.Configuration.LazyLoadingEnabled = false;
					try
					{
						var Entidades = (from u in dBEntities.Users
										 where u.UserId== UserId
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
			public Request Insert(Users insertar)
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
						var Entidades = (from u in dBEntities.Users
										 where u.UserId == insertar.UserId
										 select u).FirstOrDefault();
						if (Entidades == null)
						{
							dBEntities.Users.Add(insertar);
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
			public Request Delete(int UserId, object id = null)
			{

				Request request = new Request();
				using (var dBEntities = new ErpDBEntities())
				{
					dBEntities.Configuration.ProxyCreationEnabled = false;
					dBEntities.Configuration.LazyLoadingEnabled = false;
					try
					{
						var Entidades = (from u in dBEntities.Users
										 where u.UserId == UserId
										 select u).FirstOrDefault();
						if (Entidades == null)
						{
							return request.DoWarning($"No se encontraron entidades por borrar.");
						}

						dBEntities.Users.Remove(Entidades);
						var count = dBEntities.SaveChanges();
						return request.DoSuccess(Entidades, $"Se eliminó {count} registro correctamente");
					}
					catch (Exception ex)
					{

						return request.DoError(ex.Message);
					}
				}

			}
			public Request GetAll(int Company = 0)
			{
				Request request = new Request();
				using (var dBEntities = new ErpDBEntities())
				{
					dBEntities.Configuration.ProxyCreationEnabled = false;
					dBEntities.Configuration.LazyLoadingEnabled = false;
					try
					{
						var Entidades = (from u in dBEntities.Users
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
						var Entidades = (from u in dBEntities.Users
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
			public Request UpdateById(Users actualizar)
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
						var Entidades = (from u in dBEntities.Users
										 where u.UserId == actualizar.UserId
										 select u).FirstOrDefault();
						if (Entidades == null)
						{
							return request.DoWarning($"No se encontraron entidades por actualizar.");
						}

						Entidades.UserId = actualizar.UserId;
						Entidades.RolId = actualizar.RolId;
						Entidades.FirstName = actualizar.FirstName;
						Entidades.UserName = actualizar.UserName;
						Entidades.Email = actualizar.Email;
						Entidades.Password = actualizar.Password;


						var count = dBEntities.SaveChanges();
						return request.DoSuccess(Entidades, $"Se insertó {count} registro correctamente");
					}
					catch (Exception ex)
					{

						return request.DoError(ex.Message);
					}
				}
			}
			public Request Validations(Users verificar)
			{
				Request request = new Request();

				if (string.IsNullOrEmpty(verificar.FirstName))
				{
					return request.DoError("El nombre no puede estar vacio");
				}
				return request.DoSuccess();
			}
		}
}