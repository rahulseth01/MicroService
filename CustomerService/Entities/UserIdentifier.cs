using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Entities
{
    public class UserIdentifier
    {
        private int identifier;
        public UserIdentifier(int id)
        {
            if (id <= 0 || id >= 100)
                throw new ApplicationException("Id must ne between 1 and 100");
            identifier = id;
        }

        public int Identifier { get { return identifier; } }

    }
}
