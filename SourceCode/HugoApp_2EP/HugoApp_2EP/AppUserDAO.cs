using System;
using System.Collections.Generic;
using System.Data;

namespace HugoApp_2EP
{
    public static class AppUserDAO
    {
        public static List<AppUser> getLista()
        {
            string sql = "select * from appuser";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<AppUser> lista = new List<AppUser>();
            foreach (DataRow fila in dt.Rows)
            {
                AppUser u = new AppUser();
                u.idUser = Convert.ToInt32(fila[0].ToString());
                u.fullName = fila[1].ToString();
                u.userName = fila[2].ToString();
                u.password = fila[3].ToString();
                u.userType = Convert.ToBoolean(fila[4].ToString());

                lista.Add(u);
            }
            return lista;
        }
        
        public static List<AppUser> getListaP(int pidUser)
        {
            string sql = $"select * from appuser app where app.idUser ='{pidUser}' and app.userType = false";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<AppUser> lista = new List<AppUser>();
            foreach (DataRow fila in dt.Rows)
            {
                AppUser u = new AppUser();
                u.idUser = Convert.ToInt32(fila[0].ToString());
                u.fullName = fila[1].ToString();
                u.userName = fila[2].ToString();
                u.password = fila[3].ToString();
                u.userType = Convert.ToBoolean(fila[4].ToString());

                lista.Add(u);
            }
            return lista;
        }
        
        public static void actualizarContra(string pUsername, string pNewPass)
        {
            string sql = String.Format(
                "update appuser set password='{0}' where username='{1}';",
                pUsername, pNewPass);
            
            Conexion.realizarAccion(sql);
        }
        public static void crearNuevo(string fullname, string username)
        {
            string sql = String.Format(
                "insert into appuser(fullname, username, password, userType) " +
                "values('{0}', '{1}', '{2}', false);",
                fullname, username, Encriptador.CrearMD5(username));
            
            Conexion.realizarAccion(sql);
        }
        
        public static void eliminar(string username)
        {
            string sql = String.Format(
                "delete from appuser where username ='{0}'; ",
                username);
            
            Conexion.realizarAccion(sql);
        }
        
        
    }
}