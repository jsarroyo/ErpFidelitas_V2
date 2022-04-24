using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.ErpFidelitas.General.v2.BusinessLogic
{
    public class AuthenticationBL
    {
        public Request Login(string email, string password)
        {
			Request request = new Request();
			using (var dBEntities = new ErpDBEntities())
			{
				dBEntities.Configuration.ProxyCreationEnabled = false;
				dBEntities.Configuration.LazyLoadingEnabled = false;
				try
				{
					var Entidades = (from u in dBEntities.Users
									 where u.Email == email
									 && u.Password.Equals(password)
									 select u).FirstOrDefault();
					if (Entidades == null)
					{
						return request.DoWarning("Nombre de usuario o contraseña incorrecta");
					}
					Entidades.Password = null;
					return request.DoSuccess(Entidades, $"Se encontró {1} resultado");
				}
				catch (Exception ex)
				{

					return request.DoError(ex.Message);
				}
			}
		}

        public Request Register(DataBase.Users user)
        {
			Request request = new Request();

			using (var dBEntities = new ErpDBEntities())
			{

				dBEntities.Configuration.ProxyCreationEnabled = false;
				dBEntities.Configuration.LazyLoadingEnabled = false;
				try
				{
					var Entidades = (from u in dBEntities.Users
									 where u.UserName == user.UserName
									 select u).FirstOrDefault();
					if (Entidades == null)
					{
						user.RolId = 2;
						dBEntities.Users.Add(user);
						var count = dBEntities.SaveChanges();
						return request.DoSuccess($"Se ha registrado el usuario {user.UserName} de manera satisfactoria");
					}
					return request.DoWarning($"Ya se encuentra registrado. No se insertó.");
				}
				catch (Exception ex)
				{

					return request.DoError(ex.Message);
				}
			}
        }
    }
}