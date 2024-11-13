namespace Cours.Models
{
    public class Dette
    {
        // private int id;
        // private DateTime date;
        // private float montant;

        public DateTime Date { get; set; } = DateTime.Now; // Date du jour par defaut
        public float Montant { get; set; }
        public int Id { get; set; }

        // Relation
        public Client Client { get; set; }


        public override string ToString()
        {
            return $"Dette n°{Id}, du {Date:dd/MM/yyyy} pour {Montant}";
        }


    }
}