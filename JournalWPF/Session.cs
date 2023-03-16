using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalApp
{
    class Session
    {
        static Session()
        {
            DB =  new Entities1();
        }

        public static Entities1 DB { get; }
        public static User CurrentUser { get; set; }
    }
}
