using Cours.Models;
using Cours.Repository;
using Cours.Repository.Impl;
using Cours.Service;
using Cours.Service.Impl;
using Cours.View;

namespace Cours
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IClientRepository clientRepository = new ClientRepositoryImpl();
            IClientService clientService = new ClientServiceImpl(clientRepository);


            int choice;
            do
            {
                choice = Menu();
                switch (choice)
                {
                    case 1:
                        Client client = ClientView.CreateClient();
                        clientService.Save(client);
                        break;
                    case 2:
                        ClientView.ListClients(clientService.FindAll());
                        break;
                    case 3:
                        ClientView.ListClients(clientService.FindAll());
                        Client client1 = clientService.FindById(ClientView.SaisirId());
                        if (client1 != null)
                        {
                            ClientView.UpdateClient(client1);
                            clientService.Update(client1);
                        }
                        break;
                    case 4:
                        ClientView.ListClients(clientService.FindAll());
                        Client client2 = clientService.FindById(ClientView.SaisirId());
                        if (client2 != null)
                            clientService.Delete(client2.Id);

                        break;
                    case 0:
                        Console.WriteLine("Au revoir!");
                        break;
                    default:
                        Console.WriteLine("Choix invalide!");
                        break;
                }
            } while (choice != 0);

        }


        public static int Menu()
        {
            Console.WriteLine("1. Créer un client");
            Console.WriteLine("2. Afficher tous les clients");
            Console.WriteLine("3. Modifier un client");
            Console.WriteLine("4. Supprimer un client");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");
            // return int.Parse(Console.ReadLine());
            // double.Parse(Console.ReadLine());
            return Convert.ToInt32(Console.ReadLine());
        }
    }

}
