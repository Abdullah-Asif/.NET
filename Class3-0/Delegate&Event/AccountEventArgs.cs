using System;

namespace Delegate_Event
{
   public class AccountEventArgs : EventArgs
   {
    //    public AccountEventArgs(Person person)
    //    {
    //        _person = person;
    //    }
       public Person person { get; set; }
   }
}
