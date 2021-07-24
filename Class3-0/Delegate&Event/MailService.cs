using System;

namespace Delegate_Event
{
   public class MailService
   {
       public void OnAccountCreated(object sender, AccountEventArgs args)
       {
           Console.WriteLine("MailService: Mail is sending..." + args.person.Name);
       }
   }
}
