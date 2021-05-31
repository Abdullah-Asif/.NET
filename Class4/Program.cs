using System;
using System.IO;
using System.Reflection;

namespace Class4
{
    class Program
    {
        static void Main(string[] args)
        {
           
           Type y = typeof(Product);
           foreach (var property in y.GetProperties())
           {   
               Console.WriteLine(property.Name);
           }
           Console.WriteLine("....................");
           foreach (var method in y.GetMethods())
           {
               Console.WriteLine(method.Name);
           }
           /*
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
                   ConstructorInfo constructor = type.GetConstructor(new Type[0]);
                  // ConstructorInfo constructor = type.GetConstructor(new Type[] {typeof(int) });
                   var initializerInstance = constructor.Invoke(new object[0]);
                   //var initializerInstance = constructor.Invoke(new object[] { 5 });
                   MethodInfo method =  type.GetMethod("InitStartUp");
                   method.Invoke(initializerInstance, new object[0]); 
               }
           }
           
        }   
    }
}
