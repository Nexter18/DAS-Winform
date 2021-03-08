using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_v1._1
{
    class jsonCredsClass
    {
        public List<User> users { get; set; }
        public List<Password> passwords { get; set; }

        public class User
        {
            public string type { get; set; }
            public string userName { get; set; }
        }

        public class Password
        {
            public string type { get; set; }
            public string userPass { get; set; }
        }
    }
}
