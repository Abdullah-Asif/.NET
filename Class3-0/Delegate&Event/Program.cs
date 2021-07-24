using System;

namespace Delegate_Event
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person() {
                Name = "Asif Abdullah", 
                Age = 23,
                Country = "Bangladesh"
            };
            var netflix = new Netflix();
            var mailservice = new MailService();
            var smsService = new SMSService();
            netflix.AccountCreated += mailservice.OnAccountCreated;
            netflix.AccountCreated += smsService.OnAccountCreated;
            netflix.CreateAccount(person);

        }
    }
}
