using domain.Entities;

namespace Application.Models
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NumberPhone { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Dni { get; set; }

        public static ClientDTO Create(Client client)
        {
            return new ClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email,
                Password = client.Password,
                NumberPhone = client.NumberPhone,
                DocumentType = client.DocumentType,
                Dni = client.Dni,
            };


        }

        public static List<ClientDTO> CreateList(IEnumerable<Client> client)
        {
            if (client == null || !client.Any())
            {
                return null;
            }

            return client.Select(c => new ClientDTO
            {
                Id = c.Id,
                Name = c.Name,
                Surname = c.Surname,
                Email = c.Email,
                Password = c.Password,
                NumberPhone = c.NumberPhone,
                DocumentType = c.DocumentType,
                Dni = c.Dni,
            }).ToList();
        
        }
    }
}