using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public static class MuebleController
    {
		public static void insertMueble(Mueble newMueble)
		{
			try
			{
				if ( string.IsNullOrEmpty(newMueble.nombre) || string.IsNullOrEmpty(newMueble.color) || string.IsNullOrEmpty(newMueble.precio.ToString())
				|| string.IsNullOrEmpty(newMueble.cantidad_stock.ToString()) )
				{
					throw new Exception("Introduzca todos los campos");
				}
				else
				{
                    if (newMueble.precio <= 0 || newMueble.cantidad_stock < 0)
                    {
						throw new Exception("Cantidad Invalida");
                    }
                    else
                    {
						MuebleModel.insertMueble(newMueble);
					}
					
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static void updateMueble(Mueble muebleToUpdate)
		{
			try
			{

				if ( muebleToUpdate.idMueble > 0 && !string.IsNullOrEmpty(muebleToUpdate.nombre) && !string.IsNullOrEmpty(muebleToUpdate.color) && !string.IsNullOrEmpty(muebleToUpdate.precio.ToString())
				&& !string.IsNullOrEmpty(muebleToUpdate.cantidad_stock.ToString()) )
				{
					MuebleModel.updateMueble(muebleToUpdate);
				}
				else
				{
					throw new Exception("Faltan campos");
				}
			}
			catch (Exception ex)
			{
				throw  ex;
			}
		}


		public static Mueble searchMuebleById(int idMueble)
		{
			try
			{
				return MuebleModel.searchMuebleById(idMueble);
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public static List<Mueble> searchMuebleByCriteria(string criteria)
		{
			try
			{
				return MuebleModel.searchMuebleByCriteria(criteria);
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public static void removeMueble(int id_mueble_to_remove)
		{
			try
			{
				if (id_mueble_to_remove > 0)
				{
					MuebleModel.removeMueble(id_mueble_to_remove);
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
