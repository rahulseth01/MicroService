using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Events
{
    public interface IEvents { }
        public class CustomerCreatedEvents: IEvents
        {

            public int CustomerId;
            public string FirstName;
            public string LastName;
            public string City;

            public CustomerCreatedEvents(int cid, string fname, string lname, string city)
            {
                CustomerId = cid;
                FirstName = fname;
                LastName = lname;
                City = city;
            }
        
    }
}
