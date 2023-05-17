using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingSystem.API.CustomException
{
    public class SqlCustomException:Exception
    {
        public SqlCustomException(string message, Exception exception):base(message,exception)
        {

        }
    }
}
