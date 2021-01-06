using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class MuebleModel
    {

		public static void insertMueble(Mueble newMueble)
		{
			try
			{
				using (var model = new oficinasymasEntities())
				{
					model.Muebles.Add(newMueble);
					model.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw ex;
			};
		}

		public static Mueble searchMuebleById(int idMueble)
		{
			try
			{


				using (var model = new oficinasymasEntities())
				{
					var result = model.Muebles.Where(mueble => (mueble.idMueble == idMueble)).FirstOrDefault();
					return result;
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
				using (var model = new oficinasymasEntities())
				{
					Mueble mueble = model.Muebles.Find(muebleToUpdate.idMueble);
					mueble.nombre = muebleToUpdate.nombre;
					mueble.color = muebleToUpdate.color;
					mueble.precio = muebleToUpdate.precio;
					mueble.image = muebleToUpdate.image;
					model.SaveChanges(); 
				}
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
				using (var model = new oficinasymasEntities())
				{
					List<Mueble> result = model.Muebles.Where(mueble => (mueble.nombre.Contains(criteria)
						 || mueble.color.Contains(criteria))).ToList();
					return result;
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public static void editMueble(Mueble modifiedMueble)
		{
			try
			{
				using (var model = new oficinasymasEntities())
				{
					Mueble mueble = model.Muebles.Find(modifiedMueble.idMueble);
					mueble.nombre = modifiedMueble.nombre;
					mueble.color = modifiedMueble.color;
					mueble.precio = modifiedMueble.precio;
					model.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public static void removeMueble(int idMuebleToRemove)
		{
			try
			{
				Mueble muebleToRemove = searchMuebleById(idMuebleToRemove);
				using (var model = new oficinasymasEntities())
				{
					model.Muebles.Attach(muebleToRemove);
					model.Muebles.Remove(muebleToRemove);
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
