using System;

namespace Delegate_Event
{
    public class Netflix
    {
       // public delegate void AccountCreatedEventHandler(object sender, AccountEventArgs args);
        public event EventHandler<AccountEventArgs> AccountCreated;
        public void CreateAccount(Person p)
        {
            Console.WriteLine(p.Name + "Your account is created");
            OnAccountCreated(p);
        }
        protected virtual void OnAccountCreated(Person person)
        {
            if (AccountCreated != null) 
            {
                AccountCreated(this, new AccountEventArgs() { person = person});
            }
        }
    }
}
