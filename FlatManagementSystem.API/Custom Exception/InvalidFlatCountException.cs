using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlatManagementSystem.API.Custom_Exception
{
    public class InvalidFlatCountException:Exception
    {
        public InvalidFlatCountException(string message) : base(message)
        {

        }
    }
}
