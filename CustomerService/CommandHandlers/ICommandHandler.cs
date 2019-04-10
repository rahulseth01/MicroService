using CustomerService.Commands;
using CustomerService.Repositories;
using CustomerService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Models;
using CustomerService.Events;
using CustomerService.EventStore;

namespace CustomerService.CommandHandlers
{
    public interface ICustomerCommandHandler
    {
        void HandleCustomerCreated(ICustomerCommand command);
    }

    public class CustomerCommandHandler: ICustomerCommandHandler
    {
        private ICustomerRepository _repo;

        public CustomerCommandHandler(ICustomerRepository repo)
        {
            _repo =repo;
        }

        public async void HandleCustomerCreated(ICustomerCommand command)
        {
            CustomerCreatedCommand c = command as CustomerCreatedCommand;
            UserIdentifier u = new UserIdentifier(c.Userid);

            CustomerEntity cust = new CustomerEntity(u, c.Firstname, c.Lastname, c.Age, c.City, 10);
            Users us = cust.GetCustomrModelFromEntity();

            //Check if user exists
            //if (_repo.GetUserByID(c.Userid) != null)
            //{
                await _repo.NewUsers(us);
            //}
            //creta a new event
            CustomerCreatedEvents e = new CustomerCreatedEvents(u.Identifier, c.Firstname, c.Lastname, c.City);
            //save the customer
            //raise the event
            ServiceBusQueueStore.SendEvents(e);
        }
    }
}
