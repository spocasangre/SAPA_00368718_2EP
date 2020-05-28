using System;
using System.Collections.Generic;
using System.Data;

namespace HugoApp_2EP
{
    public static class ProductDAO
    {
        public static List<Product> getPList(int PidBusiness)
        {
            string sql = $"select * from product where idBusiness = {PidBusiness} ";
            var dt = Conexion.realizarConsulta(sql);
            List<Product> listaa = new List<Product>();

            foreach (DataRow fila in dt.Rows)
            {
                Product p = new Product();
                p.idProduct = Convert.ToInt32(fila[0].ToString());
                p.idBusiness = Convert.ToInt32(fila[1].ToString());
                p.name = fila[2].ToString();
                listaa.Add(p);
            }

            return listaa;
        }
        
        public static void crearProduct(int pidBusiness, string pname)
        {
            string sql = String.Format(
                "insert into product(idBusiness, name) " +
                "values('{0}', '{1}');",
                pidBusiness, pname);
            
            Conexion.realizarAccion(sql);
        }
        
        public static void eliminar(int idProducto, int idBusiness)
        {
            string sql = String.Format(
                "delete from product where idProduct = {0} AND idBusiness = {1};",
                idProducto, idBusiness);
            
            Conexion.realizarAccion(sql);
        }
    }
}