using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class Owner : User
    { 
       
        public int Cvu { get; set; }

        public Owner() { }

        public Owner(string name, string surname, string email, string password, string numberphone, DocumentType documentType, string dni, int cvu)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            NumberPhone = numberphone;
            DocumentType = documentType;
            Dni = dni;
            Cvu = cvu;
            UserType = "owner";
        }
    }
}
