using System;
using System.Linq;
using System.Collections.Generic;
namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
           
           var words = new string[] { "falcon", "eagle", "sky", "tree", "water", "sea", "mountain" };
           
           var res = from word in words
                     where word.Contains('a')
                     select word;

            foreach (var word in res)
            {
                Console.WriteLine(word);
            }
            
            //Method syntax
            var res2 = words.Where(word => word.EndsWith('e'));
            foreach (var word in res2)
            {
                Console.WriteLine(word);
            }


            // Console.WriteLine(words.ElementAt(2));
            // Console.WriteLine("-----------");
            // Console.WriteLine(words.First());
            // Console.WriteLine(words.Last());
            // Console.WriteLine("-----------");
            // Console.WriteLine(words.First(word => word.Length == 3));
            // Console.WriteLine(words.Last(word => word.Length == 3));
            // Console.WriteLine("-----------");
            // Console.WriteLine(string.Join(", ", words));
            // Console.WriteLine("-----------");


            int[] vals = {1, 2, 3};
            vals.Prepend(0);
            vals.Append(4);

            Console.WriteLine(string.Join(", ", vals));

            var vals2 = vals.Prepend(0);
            var vals3 = vals2.Append(4);

            Console.WriteLine(string.Join(", ", vals3));
            
        }
    }
}
