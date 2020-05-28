namespace HugoApp_2EP
{
    public class Address
    {
        public int idAddres { get; set; }
        public int idUser { get; set; }
        public string address { get; set; }

        public Address()
        {
            idAddres = 0;
            idUser = 0;
            address = "";
        }
    }
}