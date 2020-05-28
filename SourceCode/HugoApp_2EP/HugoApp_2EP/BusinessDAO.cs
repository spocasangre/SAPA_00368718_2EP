using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace HugoApp_2EP
{
    public static class BusinessDAO
    {
        public static List<Business> getBList()
        {
            string sql = "select * from business";
            var dt = Conexion.realizarConsulta(sql);
            List<Business> lista = new List<Business>();

            foreach (DataRow fila in dt.Rows)
            {
                Business b = new Business();
                b.idBusiness = Convert.ToInt32(fila[0].ToString());
                b.name = fila[1].ToString();
                b.description = fila[2].ToString();
                lista.Add(b);
            }

            return lista;
        }
        public static void crearBusiness(string name, string des)
        {
            string sql = String.Format(
                "insert into business(name, description) " +
                "values('{0}', '{1}');",
                name, des);
            
            Conexion.realizarAccion(sql);
        }
        
        public static void eliminar(string name)
        {
            string sql = String.Format(
                "delete from business where name ='{0}'; ",
                name);
            
            Conexion.realizarAccion(sql);
        }
    }
}