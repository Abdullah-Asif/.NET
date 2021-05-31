using System;
using System.IO;
using System.Reflection;

namespace Class4
{
    class Program
    {
        static void Main(string[] args)
        {
           /*
           Type y = typeof(Product);
           Console.WriteLine(y.Name);
           var product = new Product();
           */
           var path = @"E:\Edge download\SWE\Github\ASP.NET\Class4\config.txt";
           var configtext = File.ReadAllText(path);
           var initClassName = configtext.Split('=')[1].Trim();

           Type[] types =  Assembly.GetExecutingAssembly().GetTypes();
           foreach (var type in types)
           {
               if (type.Name == initClassName)
        
               {
                   var constructor = type.GetConstructor(new Type[0]);
                   var initializerInstance = constructor.Invoke(new object[0]);
                   MethodInfo method =  type.GetMethod("InitStartUp");
                   method.Invoke(initializerInstance, new object[0]); 
               }
               
           }
        }   
    }
}
