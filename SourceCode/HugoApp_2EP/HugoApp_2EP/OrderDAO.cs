using System;
using System.Collections.Generic;
using System.Data;

namespace HugoApp_2EP
{
    public static class OrderDAO
    { 
        public static List<Order> getOList()
        {
            string sql = "select * from APPORDER";
            var dt = Conexion.realizarConsulta(sql);
            List<Order> lista = new List<Order>();

            foreach (DataRow fila in dt.Rows)
            {
                Order o = new Order();
                o.idOrder = Convert.ToInt32(fila[0].ToString());
                o.createOrder = Convert.ToDateTime(fila[1].ToString());
                o.idProduct = Convert.ToInt32(fila[2].ToString());
                o.idAdress = Convert.ToInt32(fila[3].ToString());
                lista.Add(o);
            }

            return lista;
        }
        
        public static List<Order> getOListP(int pidUser)
        {
            string sql = $"SELECT ao.idOrder, ao.createDate, pr.idProduct, ad.idAddress "+
            "FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au "+
                "WHERE ao.idProduct = pr.idProduct "+
                "AND ao.idAddress = ad.idAddress "+
                "AND ad.idUser = au.idUser "+
                $"AND au.idUser = {pidUser};";
                    
            var dt = Conexion.realizarConsulta(sql);
            List<Order> lista = new List<Order>();

            foreach (DataRow fila in dt.Rows)
            {
                Order o = new Order();
                o.idOrder = Convert.ToInt32(fila[0].ToString());
                o.createOrder = Convert.ToDateTime(fila[1]);
                o.idProduct = Convert.ToInt32(fila[2].ToString());
                o.idAdress = Convert.ToInt32(fila[3].ToString());
                lista.Add(o);
            }

            return lista;
        }
        
        public static void crearOrder(DateTime ptime, int pidProduct, int pidAdress)
        {
            string sql = String.Format(
                "insert into apporder(createDate, idProduct, idAddress) " +
                "values('{0}', {1}, {2});",
                ptime, pidProduct, pidAdress);
            
            Conexion.realizarAccion(sql);
        }
        
        public static void eliminarOrden(int pIdOrder)
        {
            string sql = String.Format(
                "delete from apporder where idOrder ='{0}'; ",
                pIdOrder);
        }
    }
}