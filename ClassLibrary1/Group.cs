using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Group
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int SubGroup { get; set; }
        public int ClassRoom { get; set; }
        virtual public Speciality Speciality { get; set; }
        
        public string GetCode()
        {
            int course = DateTime.Now.Year - Year;
            if (DateTime.Now.Month >= 9) course++;
            return $"{course}-{SubGroup}{Speciality.Code}{ClassRoom}";
        }
    }
}
