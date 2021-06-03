using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDoc.Entities
{
    public class UserRefreshToken
    {

        public int id { get; set; }
        public int user { get; set; }
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
