using System;

namespace Delegate_Event
{
   public class SMSService
   {
       public void OnAccountCreated(object sender, AccountEventArgs args)
       {
           Console.WriteLine("SMSService: SMS is sending..." + args.person.Name);
       }
   }
}
