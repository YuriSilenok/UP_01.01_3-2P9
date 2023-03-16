using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.Data.Entity;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new dbContext32p9())
            {
                db.Database.Delete();
                while (true)
                {
                    Console.Clear();
                    db.Users.ToList().ForEach(u => Console.WriteLine($"{u.Username}--{ u.Password}"));
                    db.Groups.ToList().ForEach(g => Console.WriteLine($"{g.GetCode()}"));
                    db.Specialities.ToList().ForEach(s => Console.WriteLine($"{s.Code}-{s.Name}"));
                    User user = new User { Username = Console.ReadLine(), Password = Console.ReadLine() };
                    db.Users.Add(user);

                    Speciality speciality = new Speciality { Code = 'П', Name = "Программисты" };
                    db.Specialities.Add(speciality);
                    for (int y = 0; y < 4; y++)
                    {
                        for (int sg = 1; sg <= 2; sg++)
                        {
                            Group group = new Group
                            {
                                Speciality = speciality,
                                ClassRoom = 9,
                                SubGroup = sg,
                                Year = 2019 + y
                            };
                            db.Groups.Add(group);

                        }
                    }

                    db.SaveChanges();

                }
            }
        }
    }
}
