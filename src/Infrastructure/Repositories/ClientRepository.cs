using domain.Entities;
using domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository //esto es un mockup de lo que mas adelante será la implementación a la base de datos, en proceso
    {

            private readonly ApplicationContext _context;
            public ClientRepository(ApplicationContext context) : base(context)
            {

                _context = context;
            }
        }
    }
