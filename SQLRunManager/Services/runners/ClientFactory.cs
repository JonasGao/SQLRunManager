using System.Collections.Generic;
using SQLRunManager.Models;

namespace SQLRunManager.Services.runners
{
    public class ClientFactory
    {
        private static readonly Dictionary<string, IClient> Clients = new Dictionary<string, IClient>();

        public static void Registe(IClient client)
        {
            Clients.Add(client.Name, client);
        }

        public static bool HasClient(DatabaseItem databaseItem)
        {
            return Clients.ContainsKey(databaseItem.Type);
        }

        public static IClient GetClient(DatabaseItem databaseItem)
        {
            return Clients[databaseItem.Type];
        }
    }
}
