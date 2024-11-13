using Cours.Models;

namespace Cours.View
{

    public abstract class ClientView
    {

        public static void ListClients(List<Client> clients)
        {
            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
        }

         public static void ListDetteClient(Client client)
        {
            foreach (var dette in client.Dettes)
            {
                Console.WriteLine(dette);
            }
        }

        public static Client CreateClient()
        {
            Console.Write("Surnom : ");
            string surnom = Console.ReadLine()!;
            Console.Write("Téléphone : ");
            string telephone = Console.ReadLine()!;
            Console.Write("Adresse : ");
            string adresse = Console.ReadLine()!;
            Client client = new() { Surnom = surnom, Telephone = telephone, Adresse = adresse };
            // Ajout de la dette
            do
            {
                Console.Write("Voulez-vous ajouter une dette à ce client ? (o/n) ");
                string answer = Console.ReadLine()!;
                if (answer.ToLower() == "o")
                {
                    float montant;
                    do
                    {
                        Console.Write("Montant de la dette : ");
                        montant = float.Parse(Console.ReadLine()!);
                        if (montant <= 0)
                        {
                            Console.WriteLine("Montant invalide. Merci de saisir un montant positif.");
                        }
                    } while (montant <= 0);
                    Dette dette = new()
                    {
                        Montant = montant,
                    };
                    client.AddDette(dette);
                }
                else
                {
                    break;
                    // OUI OUI
                }

            } while (true);




            return client;
        }

        public static void UpdateClient(Client client)
        {

            Console.Write("Nouveau surnom : ");
            string newSurnom = Console.ReadLine();
            Console.Write("Nouveau téléphone : ");
            string newTelephone = Console.ReadLine();
            Console.Write("Nouvelle adresse : ");
            string newAdresse = Console.ReadLine();
            client.Surnom = newSurnom;
            client.Telephone = newTelephone;
            client.Adresse = newAdresse;
            Console.WriteLine("Client modifié!");
        }

        public static int DeleteClient()
        {
            Console.Write("Voulez-vous supprimer un client ? (o/n) ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "o")
            {
                Console.Write("Id du client à supprimer : ");
                return Convert.ToInt32(Console.ReadLine());
            }
            return 0;

        }

        public static int SaisirId()
        {
            Console.WriteLine("Id du client ?");
            return Convert.ToInt32(Console.ReadLine());
        }

    }
}