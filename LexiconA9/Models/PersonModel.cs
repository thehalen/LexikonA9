using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA9.Models
{
    public class PersonModel : CreatePersonViewModel
    {

        private static int id = 0;
        public static int getNewID()
        {            
            return id++;
        }


        public PersonModel()
        {
            Id = getNewID();
        }

        public PersonModel(string name, string city, string phonenr)
        {
            Name = name;
            City = city;
            PhoneNr = phonenr;
            Id = getNewID();
        }



    }
}
