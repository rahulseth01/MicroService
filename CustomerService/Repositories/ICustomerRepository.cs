using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Models;

namespace CustomerService.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Users> GetUsers();
        Users GetUserByID(int id);
        Task<Users> NewUsers(Users user);
        Task<Users> UpdateUsers(Users user);
        Task<bool> DeleteUsers(Users user);

    }
}
