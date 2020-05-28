namespace HugoApp_2EP
{
    public class AppUser
    {
        public int idUser { get; set; }
        public string fullName { get; set; }
        public string userName { get; set; }
        
        public string password { get; set; }
        public bool userType { get; set; }

        public AppUser()
        {
            idUser = 0;
            fullName = "";
            userName = "";
            password = "";
            userType = false;
        }
    }
}