using application.Interfaces;
using Application.Models.Request;
using domain.Entities;
using domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<List<Client>> GetAll()
        {
            return /*await*/ _clientRepository.GetAll();
        }
        public async Task<Client?> GetById(int id)
        {
            return /*await*/ _clientRepository.GetById(id);
        }
        public async Task<Client?> Create(AddClientRequest dto)
        {
            var existingClient = /*await*/ _clientRepository.GetAll();
            if (existingClient.Any(c => c.Email == dto.Email))
            {
                return null;
            }

            var client = new Client
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                Password = dto.Password, //hashear
                NumberPhone = dto.NumberPhone,
                DocumentType = dto.DocumentType,
                Dni = dto.Dni
            };

            return /*await*/ _clientRepository.Create(client);
        }
        public async Task Update(int id, AddClientRequest request)
        {
            var client = await GetClientById(id);
            client.Name = request.Name;
            client.Surname = request.Surname;
            client.Email = request.Email;
            client.Password = request.Password;
            client.NumberPhone = request.NumberPhone;
            client.DocumentType = request.DocumentType;
            client.Dni = request.Dni;

            /*await*/
            _clientRepository.Update(client);

            return /*client cuando se haga asincronica*/;
        }
        public async Task Delete(Client client)
        {
            /*await*/ _clientRepository.Delete(client);   
        }
    }
}