using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public static class PersonalController
    {

		public static Personal login(Personal login)
		{
			try
			{
				if (string.IsNullOrEmpty(login.correo) == false && string.IsNullOrEmpty(login.password) == false)
				{
					var result = PersonalModel.login(login);

					if (result == null)
					{
						throw new Exception("Usuario y/o contraseña incorrectos");
					}
					else
					{
						return result;
					}
				}
				else
				{
					throw new Exception("Introduzca todos los campos");
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public static void insertUser(Personal newUser)
		{
			try
			{
				if (string.IsNullOrEmpty(newUser.nombre) || string.IsNullOrEmpty(newUser.apellido) || string.IsNullOrEmpty(newUser.correo)
					|| string.IsNullOrEmpty(newUser.password))
				{
					throw new Exception("Introduzca todos los campos");
				}
				else if (!PersonalModel.isValidEmail(newUser.correo))
				{
					throw new Exception("Correo electrónico inválido.");
				}
				else if (PersonalModel.emailExists(newUser.correo))
				{
					throw new Exception("Correo electrónico ya registrado");
				}
				else if (PersonalModel.isValidPassword(newUser.password))
				{
					PersonalModel.insertUser(newUser);
				}
				else
				{
					throw new Exception("La contraseña debe tener al menos 8 caracteres");
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

				if (userToUpdate.idPersonal > 0 && !string.IsNullOrEmpty(userToUpdate.nombre) && !string.IsNullOrEmpty(userToUpdate.apellido) && !string.IsNullOrEmpty(userToUpdate.correo))
				{
					PersonalModel.updateUser(userToUpdate);
				}
				else
				{
					throw new Exception("Faltan campos");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message.ToString());
			}
		}


		public static Personal searchUserById(int idUser)
		{
			try
			{
				return PersonalModel.searchUserById(idUser);
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
				return PersonalModel.searchUserByCriteria(criteria);
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

				if (modifiedUser.idPersonal > 0 && !string.IsNullOrEmpty(modifiedUser.nombre) && !string.IsNullOrEmpty(modifiedUser.correo) && !string.IsNullOrEmpty(modifiedUser.password)
					&& !string.IsNullOrEmpty(modifiedUser.apellido) && !string.IsNullOrEmpty(modifiedUser.area) && !string.IsNullOrEmpty(modifiedUser.telefono) 
					&& !string.IsNullOrEmpty(modifiedUser.rol.ToString()))
				{
					PersonalModel.editUser(modifiedUser);
				}
				else
				{
					throw new Exception("Datos inválidos");
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Hubo un error en la capa del Modelo: " + ex.Message.ToString());
			}
		}

		public static void removeUser(int id_user_to_remove)
		{
			try
			{
				if (id_user_to_remove > 0)
				{
					PersonalModel.removeUser(id_user_to_remove);
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
