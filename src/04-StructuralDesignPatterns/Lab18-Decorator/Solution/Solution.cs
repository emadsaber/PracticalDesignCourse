using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18_Decorator.Solution
{
    public abstract class Notifier{
        public abstract void Notify(string message);
    }

    class BasicNotifier : Notifier {
        public override void Notify(string message){
            Console.WriteLine("Basic Notifier: " + message);
        }
    }

    abstract class ExternalNotifierDecorator: Notifier {
        private Notifier _notifier;

        public ExternalNotifierDecorator(Notifier notifier){
            this._notifier = notifier;
        }

        public override void Notify(string message){
            _notifier.Notify(message);
        }
    }

    class FacebookNotifierDecorator : ExternalNotifierDecorator {
        public FacebookNotifierDecorator(Notifier notifier): base(notifier){}

        public override void Notify(string message)
        {
            base.Notify(message);
            Console.WriteLine("FACEBOOK : " + message);
        }
    }

    class SmsNotifierDecorator : ExternalNotifierDecorator {
        public SmsNotifierDecorator(Notifier notifier): base(notifier){}

        public override void Notify(string message)
        {
            base.Notify(message);
            Console.WriteLine("SMS : " + message);
        }
    }

    class TeamsNotifierDecorator : ExternalNotifierDecorator {
        public TeamsNotifierDecorator(Notifier notifier): base(notifier){}

        public override void Notify(string message)
        {
            base.Notify(message);
            Console.WriteLine("TEAMS : " + message);
        }
    }

    public class Application
    {
        public void Test(){
            //create a basic notifier object 
            var basicNotifier = new BasicNotifier();
            basicNotifier.Notify("Welcome to your app!");
            Console.WriteLine("--------------------------------------------");

            var facebookDecorator = new FacebookNotifierDecorator(basicNotifier);
            facebookDecorator.Notify("Message on Facebook only!");
            Console.WriteLine("--------------------------------------------");

            var smsNotifierDecorator = new SmsNotifierDecorator(facebookDecorator);
            smsNotifierDecorator.Notify("Message on Facebook + SMS!");
            Console.WriteLine("--------------------------------------------");

            var teamsNotifierDecorator = new TeamsNotifierDecorator(smsNotifierDecorator);
            teamsNotifierDecorator.Notify("Message on Facebook + SMS + Teams!");
            Console.WriteLine("--------------------------------------------");
        }
    }
}