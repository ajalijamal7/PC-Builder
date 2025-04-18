using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Builder
{
    class loggeduser
    {
    }
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
    }


    public static class Session
    {
        public static User LoggedInUser { get; set; }
    }


}
