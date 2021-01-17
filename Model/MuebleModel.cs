using System;
using System.Collections;
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
					mueble.cantidad_stock = muebleToUpdate.cantidad_stock;
					mueble.categoria = muebleToUpdate.categoria;
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
						 || mueble.color.Contains(criteria) || mueble.categoria.Contains(criteria))).ToList();
					return result;
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public static List<Mueble> searchMuebleByMultipleId(List<int> muebleList)
		{
			try
			{
				using (var model = new oficinasymasEntities())
				{
					foreach (var item in muebleList)
					{
						List<Mueble> result = model.Muebles.Where(mueble => (mueble.idMueble == item)).ToList();
						return result;
						
					}
					return null;
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
