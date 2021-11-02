namespace BE
{
    public class BEEAmbulancia 
    {
        public int NumAmbulancia { get; set; }
        public bool EnServicio { get; set; }
        public bool Emergencia { get; set; }
        public int CantPasajeros { get; set; }

        public BEEAmbulancia()
        {
        }

        public BEEAmbulancia(int num, bool serv, bool emerg, int pas)
        {
            NumAmbulancia = num;
            EnServicio = serv;
            Emergencia = emerg;
            CantPasajeros = pas;
        }
    }
}