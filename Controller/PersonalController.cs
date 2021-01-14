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
				else if (passwordValidator(newUser.password))
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
                    if (modifiedUser.password.Length >= 8)
                    {
						if (passwordValidator(modifiedUser.password))
						{
							PersonalModel.editUser(modifiedUser);
                        }
                        else
                        {
							throw new Exception("Contraseña Invalida");
						}
                    }
                    else
                    {
						throw new Exception("Contraseña debe contener al menos 8 caracteres");
					}
					
				}
				else
				{
					throw new Exception("Datos inválidos");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message.ToString());
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

		public static bool passwordValidator(string password)
        {			
			char[] charPassword = password.ToCharArray();
			int symbolCount = 0;
			int lowerLetterCount = 0;
			int numberCount = 0;
			int upperLetterCount = 0;
			
			List<char> upperLetters = new List<char>()
			{
				'A','B','C','D','E','F','G','H','I','J','K','L','M','N','Ñ',
				'O','P','Q','R','S','T','U','V','W','X','Y','Z'
			};
			List<char> lowerLetters = new List<char>()
			{
				'a','b','c','d','e','f','g','h','i','j','k','l','m','n',
				'ñ','o','p','q','r','s','t','u','v','w','x','y','z'
			};
			List<char> numbers = new List<char>()
			{
				'0','1','2','3','4','5','6','7','8','9'
			};
			List<char> symbols = new List<char>()
			{
				'`','~','!','@','#','$','%','^','&','*',
				'(',')','-','_','=','+','[',']','{','}',
				';',':','"','<','.','>','/','?','\'','|'
			};
            for (int i = 0; i < charPassword.Length; i++)
            {
                if (lowerLetters.Contains(charPassword[i]))
                {
					lowerLetterCount = lowerLetterCount + 1;
				}
                if (numbers.Contains(charPassword[i]))
                {
					numberCount = numberCount + 1;
				}
                if (symbols.Contains(charPassword[i]))
                {
					symbolCount = symbolCount + 1;
                }
                if (upperLetters.Contains(charPassword[i]))
                {
					upperLetterCount = upperLetterCount + 1;
                }
            }
			int passwordCharCount = lowerLetterCount + numberCount + symbolCount + upperLetterCount;
			if (passwordCharCount == charPassword.Length && lowerLetterCount > 0
				&& numberCount > 0 && symbolCount > 0 && upperLetterCount > 0)
            {
				return true;
            }
            else
            {
				return false;
            }
		}
	}
}
