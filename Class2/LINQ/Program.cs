
using System;
using System.Linq;
using System.Collections.Generic;
namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
        //    #region select
        //    var words = new string[] { "falcon", "eagle", "sky", "tree", "water", "sea", "mountain" };
           
        //    var res = from word in words
        //              where word.Contains('a')
        //              select word;

        //     foreach (var word in res)
        //     {
        //         Console.WriteLine(word);
        //     }
            
        //     //Method syntax
        //     var res2 = words.Where(word => word.EndsWith('e'));
        //     foreach (var word in res2)
        //     {
        //         Console.WriteLine(word);
        //     }

        //     #endregion
        //    #region elementaccess
        //     Console.WriteLine(words.ElementAt(2));
        //     Console.WriteLine("-----------");
        //     Console.WriteLine(words.First());
        //     Console.WriteLine(words.Last());
        //     Console.WriteLine("-----------");
        //     Console.WriteLine(words.First(word => word.Length == 3));
        //     Console.WriteLine(words.Last(word => word.Length == 3));
        //     Console.WriteLine("-----------");
        //     Console.WriteLine(string.Join(", ", words));
        //     Console.WriteLine("-----------");
            
        //     #endregion 
    
        //    #region append

        //     int[] vals = { 1, 2, 3 };
        //     vals.Prepend(0);
        //     vals.Append(4);

        //     Console.WriteLine(string.Join(", ", vals));

        //     var vals2 = vals.Prepend(0);
        //     var vals3 = vals2.Append(4);

        //     Console.WriteLine(string.Join(", ", vals3));

        //     #endregion
        //    #region pow
        //     int[] vals = {1, 2, 3, 4, 5};
        //     var powered = vals.Select(e => Math.Pow(e, 2));
        //     Console.WriteLine(string.Join(", ", powered)); 
        //     #endregion
             #region 1
            
            User[] users =
            {
            new User(1, "John", "London", "2001-04-01"),
            new User(2, "Lenny", "New York", "1997-12-11"),
            new User(3, "Andrew", "Boston", "1987-02-22"),
            new User(4, "Peter", "Prague", "1936-03-24"),
            new User(5, "Anna", "Bratislava", "1973-11-18"),
            new User(6, "Albert", "Bratislava", "1940-12-11"),
            new User(7, "Adam", "Trnava", "1983-12-01"),
            new User(8, "Robert", "Bratislava", "1935-05-15"),
            new User(9, "Robert", "Prague", "1998-03-14")
            };

            var res = from user in users
                    where user.City == "Bratislava"
                    select new { user.Name, user.City };

            foreach (var user in res)
            {
                Console.WriteLine($" {user.City} {user.Name}");
            }
        
            #endregion

        #region SelectMany
            int[][] vals = {
                new[] {1, 2, 3},
                new[] {4},
                new[] {5, 6, 6, 2, 7, 8},
            };
            var ara = vals.SelectMany(ara => ara).OrderBy(x => x);
            int [] val1 = { 1, 2, 3, 5 };
            Array.ForEach(val1, x => Console.WriteLine(x));
            //Console.WriteLine(string.Join(", ", ara));
        #endregion

        /*
        #region Cartesian product

            char[] letters = "abcdefghi".ToCharArray();
            char[] digits = "123456789".ToCharArray();
            
            var coords =
                from letter in letters
                from digit in digits
                select $"{letter}{digit}";
            
            foreach (var coord in coords)
            {
                Console.Write($"{coord} ");

                if (coord.EndsWith("9"))
                {
                    Console.WriteLine();
                }
            }

        //     Console.WriteLine(); 
        
         #endregion    
        */
            string[] students = { "Adam", "John", "Lucia", "Tom"};
            int[] scores = { 68, 56, 90, 86, };

            var result = students.Zip(scores, (e1, e2) => e1 + "'s score: " + e2);

            foreach (var user in result)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine("---------------");
            List<Student> list1 = new List<Student> {
                new Student { Name = "Raihan",  Age = 10 },
                new Student { Name = "Asif",  Age = 11 },
                new Student { Name = "Saddam",  Age = 20 },
                new Student { Name = "Laden",  Age = 7 }
             };
            List<Student> list2 = new List<Student> { 
                new Student { Name = "Bill",  Age = 50 },
                new Student { Name = "Jeff",  Age = 41 },
                new Student { Name = "Elon",  Age = 35 },
                new Student { Name = "Richard",  Age = 54 }
            };
            List<string> result1 = (from s in list1.Union(list2)
                                orderby s.Name, s.Age
                                select s.Name).ToList();
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }

        }
            
                                    
    }

    #region  Userclass
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string DateOfBirth { get; set; }
        public User(int id, string Name, string City, string date)
        {
            this.id = id;
            this.Name = Name;
            this.City = City;
            this.DateOfBirth = date;
        }
    }
    #endregion

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
