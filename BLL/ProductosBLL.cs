using System;
using Jeremy_Castillo_Ap1_p1_.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Jeremy_Castillo_Ap1_p1_.BLL
{
    public class ProductosBLL
    {
        public static bool Existe(int ProductoId)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try{
                encontrado = contexto.Productos.Any(l => l.ProductoId == ProductoId);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;     
        }

        public static bool Guardar(Productos productos)
        {
            if(!Existe(productos.ProductoId))
            return Insertar(productos);
            else
               return Modificar(productos);
        }

        public static bool Insertar(Productos productos)
        {
            Contexto contexto = new Contexto();
            bool pasa = false;

            try
            {
                contexto.Productos.Add(productos);
                pasa = contexto.SaveChanges() > 0;

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return pasa;
        }

        private static bool Modificar(Productos productos)
        {
            Contexto contexto = new Contexto();
            bool pasa = false;
            try{
                contexto.Entry(productos).State = EntityState.Modified;
                pasa = contexto.SaveChanges() > 0; 
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return pasa;
        }

        public static bool Eliminar(int ProductoId)
        {
            Contexto contexto = new Contexto();
            bool pasa = false;

            try{
                var productos = contexto.Productos.Find(ProductoId);
                if(productos != null)
                {
                    contexto.Productos.Remove(productos);
                    pasa = contexto.SaveChanges() > 0;
                }
                
            }
            catch (Exception)
            {
            throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return pasa;
        }
        public static Productos? Buscar(int ProductoId)
        {
            Contexto contexto = new Contexto();
            Productos? productos;
            try
            {
                productos = contexto.Productos.Find(ProductoId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return productos;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>>criterio)
        {
            Contexto contexto = new Contexto();
            List<Productos> MiLista = new List<Productos>();

            try{
            MiLista = contexto.Productos.Where(criterio).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return MiLista;
        }

        public static bool BuscarDescripcion(string Nombre)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try{
                encontrado = contexto.Productos.Any(l => l.Descripcion == Nombre);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;     
        }
        
}
}