using PP.Library.Models;
using PP.API.Database;

namespace PP.API.Database
{
    public class ClientEC
    {
        public Client AddOrUpdate(Client client)
        {
            if (client.Id > 0)
            {
                var clientToUpdate
                    = Database.Clients
                    .FirstOrDefault(c => c.Id == client.Id);
            }
            else
            {
                client.Id = Database.LastId + 1;
                Database.Clients.Add(client);
            }
            return client;
        }

        public Client Delete(int id)
        {
            var clientToDelete = Database.Clients.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                Database.Clients.Remove(clientToDelete);
            }
            return clientToDelete;
        }


    }
}
