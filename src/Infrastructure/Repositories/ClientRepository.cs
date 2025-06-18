using domain.Entities;
using domain.Interfaces;
using infrastructure.Repositories;
using Infrastructure.Repositories;

public class ClientRepository : BaseRepository<Client>, IClientRepository //esto es un mockup de lo que mas adelante será la implementación a la base de datos, en proceso
    {
            public ClientRepository(ApplicationContext context) : base(context)
            {

                
            }
    }
    