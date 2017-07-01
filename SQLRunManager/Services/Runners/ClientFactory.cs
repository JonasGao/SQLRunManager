using System.Collections.Generic;
using SQLRunManager.Models;

namespace SQLRunManager.Services.Runners
{
    public class ClientFactory
    {
        private static readonly Dictionary<string, IClientBuilder<IClient>> ClientBuilders = new Dictionary<string, IClientBuilder<IClient>>();

        static ClientFactory()
        {
            Registe(new MySqlClientBuilder());
        }

        public static void Registe(IClientBuilder<IClient> client)
        {
            ClientBuilders.Add(client.Type, client);
        }

        public static bool HasClient(DatabaseItem databaseItem)
        {
            return ClientBuilders.ContainsKey(databaseItem.Type);
        }

        public static IClient GetClient(DatabaseItem databaseItem)
        {
            return ClientBuilders[databaseItem.Type].Build(databaseItem);
        }
    }
}
