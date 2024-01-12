using Microsoft.AspNetCore.Mvc;
using PP.API.Database;


namespace PP.Library.Models
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Client> Get()
        {
            return Database.Clients;
        }


        [HttpGet("/{id}")]
        public Client GetId(int id)
        {
            return Database.Clients.FirstOrDefault(c=> c.Id == id) ?? new Client();
        }


        [HttpDelete("Delete/{id}")]
        public Client? Delete(int id)
        {
            return new ClientEC().Delete(id);
        }



        [HttpPost]
        public Client AddOrUpdate([FromBody]Client client)
        {
            return new ClientEC().AddOrUpdate(client);

        }

    }
}