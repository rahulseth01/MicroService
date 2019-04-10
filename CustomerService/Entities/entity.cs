using CustomerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Entities
{
    public abstract class Entity
    {
        //List<>
        //void raise();
    }

    public class CustomerEntity : Entity
    {
        public UserIdentifier Userid { get; set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public int? Age { get; private set; }
        public string City { get; private set; }
        public int? Creditrating { get; private set; }

        public CustomerEntity(UserIdentifier _userId, string _firstname, string _lastname, int _age, string _city, int _creditrating)
        {
            Userid = _userId;
            Firstname = _firstname;
            Lastname = _lastname;
            Age = _age;
            City = _city;
            Creditrating = _creditrating;
        }

        public Users GetCustomrModelFromEntity()
        {
            return new Users
            {
                Userid = this.Userid.Identifier,
                Firstname = this.Firstname,
                Lastname = this.Lastname,
                Age = this.Age,
                City = this.City,
                Creditrating = this.Creditrating
            };
        }
    }
}
