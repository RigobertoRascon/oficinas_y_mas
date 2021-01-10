using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class PersonalModel
    {
		public static Personal login(Personal login)
		{
			try
			{
				using (var model = new oficinasymasEntities())
				{
					var result = model.Personals.Where(user => (user.correo == login.correo && user.password == login.password)).FirstOrDefault();
					return result;
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public static bool isValidEmail(string emailToValidate)
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(emailToValidate);
				return addr.Address == emailToValidate;
			}
			catch
			{
				return false;
			}
		}

		public static bool emailExists(string emailToValidate)
		{
			try
			{
				using (var model = new oficinasymasEntities())
				{
					var result = model.Personals.Where(user => (user.correo == emailToValidate)).ToList();
					return result.Count() > 0;
				}
			}
			catch
			{
				return false;
			}
		}

		public static bool isValidPassword(string password)
		{
			try
			{
				if (password.Length >= 8)
				{
					return true;
				}
				else
				{
					return false;
				}

			}
			catch (Exception)
			{

				throw new Exception("La contraseña debe tener al menos 8 caracteres");
			}
		}

		public static void insertUser(Personal newUser)
		{
			try
			{
				using (var model = new oficinasymasEntities())
				{
					model.Personals.Add(newUser);
					model.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw ex;
			};
		}

		public static Personal searchUserById(int idUser)
		{
			try
			{


				using (var model = new oficinasymasEntities())
				{
					var result = model.Personals.Where(user => (user.idPersonal == idUser)).FirstOrDefault();
					return result;
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public static void updateUser(Personal userToUpdate)
		{
			try
			{
				using (var model = new oficinasymasEntities())
				{
					Personal user = model.Personals.Find(userToUpdate.idPersonal);
					user.nombre = userToUpdate.nombre;
					user.apellido = userToUpdate.apellido;
					user.area = userToUpdate.correo;
					user.correo = userToUpdate.correo;
					user.telefono = userToUpdate.telefono;
					user.password = userToUpdate.password;
					model.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static List<Personal> searchUserByCriteria(string criteria)
		{
			try
			{
				using (var model = new oficinasymasEntities())
				{
					List<Personal> result = model.Personals.Where(user => (user.nombre.Contains(criteria)
						 || user.correo.Contains(criteria))).ToList();
					return result;
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public static void editUser(Personal modifiedUser)
		{
			try
			{
				using (var model = new oficinasymasEntities())
				{
					Personal user = model.Personals.Find(modifiedUser.idPersonal);
					user.nombre = modifiedUser.nombre;
					user.apellido = modifiedUser.apellido;
					user.correo = modifiedUser.correo;
					user.password = modifiedUser.password;
					user.telefono = modifiedUser.telefono;
					user.rol = modifiedUser.rol;
					user.area = modifiedUser.area;
					model.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public static void removeUser(int idUserToRemove)
		{
			try
			{
				Personal userToRemove = searchUserById(idUserToRemove);
				using (var model = new oficinasymasEntities())
				{
					model.Personals.Attach(userToRemove);
					model.Personals.Remove(userToRemove);
					model.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
