using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class Program
    {
        int unfreezingCount = 0;
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to bank");
            Program program = new Program();
            Console.WriteLine("Opennig account");
            Account account1 = new Account(program.CountUnfreezing);
            account1.Open();
            account1.HolderVerified();
            Console.WriteLine("Freeze account");
            account1.Freeze();
            Console.WriteLine("Deposit on account");
            account1.Deposit(15.4m);
            Console.WriteLine("Freeze account");
            account1.Freeze();
            Console.WriteLine("Withdrow from account");
            account1.Withdrow(10.5m);
            Console.WriteLine("Number of unfreezing events {0}",program.unfreezingCount);

            Console.Read();
        }
        public void CountUnfreezing()
        {
            unfreezingCount++;
        }
    }
}
