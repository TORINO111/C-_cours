using Cours.Core;
using Cours.Core.Factory;
using Cours.Models;
using Cours.Repository;
using Cours.Repository.Impl;
using Cours.Service;
using Cours.Service.Impl;
using Cours.View;
using Cours.Enum;

namespace Cours
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            IClientRepository clientRepository = ClientFactory.createClientRepository(Persistence.LIST)!;
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
                    case 5:
                        Console.WriteLine("Surnom du client : ");
                        Client? client3 = clientService.FindBySurname(Console.ReadLine()!);
                        if (client3 != null)
                        {
                            ClientView.ListDetteClient(client3);
                        }
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
            Console.WriteLine("5. Afficher les dettes d'un client");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }

    /* 
        1. Correction Projet Dette avec les Listes
        2. Utilisation Base de Donnne .Net
        ____________________________________
        TAF pour le Prochain Cours

        1. Base Donne avec ORM Dapper
        2. Base Donne avec Entity Framework
        3. Creation d'un projet web ASP MVC
            a.Fonctionnalites 
                1.CRUD CLIENT
        4. Creer un Repository qui aura toutes les methodes du CRUD (Simplification)
        5. Abstract Pattern Factory
        6. Documentation Design Pattern Facade
     */

}
