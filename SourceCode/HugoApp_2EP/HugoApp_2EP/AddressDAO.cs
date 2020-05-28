using System;
using System.Collections.Generic;
using System.Data;

namespace HugoApp_2EP
{
    public static class AddressDAO
    {
        public static List<Address> getPList(int pidUser)
        {
            string sql = $"select * from address where idUser = {pidUser}";
            var dt = Conexion.realizarConsulta(sql);
            List<Address> listaa = new List<Address>();

            foreach (DataRow fila in dt.Rows)
            {
                Address a = new Address();
                a.idAddres = Convert.ToInt32(fila[0].ToString());
                a.idUser = Convert.ToInt32(fila[1].ToString());
                a.address = fila[2].ToString();
                listaa.Add(a);
            }

            return listaa;
        }

        public static void createAddress(int pidUser, string pAddress)
        {
            string sql = String.Format(
                "insert into address(idUser, address) " +
                "values({0}, '{1}');",
                pidUser, pAddress);
            
            Conexion.realizarAccion(sql);
        }
    }
}