using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Models;

namespace CustomerService.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        devcustomerserverContext _context;

        public CustomerRepository(devcustomerserverContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteUsers(Users user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public Users GetUserByID(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Userid == id);
            return user;
        }

        public IEnumerable<Users> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public async Task<Users> NewUsers(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Users> UpdateUsers(Users user)
        {
            var id = user.Userid;
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return this.GetUserByID(id);
        }
    }
}
