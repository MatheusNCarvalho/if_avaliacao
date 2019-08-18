namespace IFAvaliacao.Models
{
    public class ProfileCow : EntityBase
    {
        protected ProfileCow() { }
        
        public ProfileCow(int nameCow, decimal bodyWight)
        {
            NameCow = nameCow;
            BodyWight = bodyWight;
        }


        public int NameCow { get; private set; }
        public decimal BodyWight { get; private set; }

    }
}