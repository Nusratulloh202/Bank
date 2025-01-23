using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Bank.Classes_bank
{
    internal class Bank_shot
    {
        
        //Propirte
        public Guid BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public int BankBalance { get; set; }
        public string BankPassword { get; set; }


        //List yaratdim har ehtimolga qarshi
        List<Bank_shot> BanksList = new List<Bank_shot>();

        //Construktor

        private Bank_shot(Guid bankAccountNumber, int bankBalance, 
                           string bankName, string bankPassword)
        {
            this.BankAccountNumber = bankAccountNumber;
            this.BankName = bankName;
            this.BankBalance = bankBalance;
            this.BankPassword = bankPassword;
        }
        //Constructor 
        public Bank_shot()
        {
        }

        public void BankYarat()
        {
            Console.WriteLine("Assalomu alaykum, bizning bankga xush kelibsiz.");
            CreateBank();
        }
        private void CreateBank()
        {
            Console.Write("1.Bank shot yaratish.\n" +
                              "2.Mavjud Bank shotga kirish.\n" +
                              "Tanlovni raqamda kiriting:");
            int tanlovCreate = int.Parse(Console.ReadLine());
            if (tanlovCreate == 1)
            {
                Console.Write("Bankni nomini kiriting:");
                BankName = Console.ReadLine();
                Console.Write("Bank hisobiga kirish uchun Maxfiy cod kiriting:");
                BankPassword = Console.ReadLine();
                Console.Write("Bankdagi boshlang'ich pul miqdorini kiriting($ da):");
                BankBalance = int.Parse(Console.ReadLine());
                BankAccountNumber = Guid.NewGuid();
                BanksList.Add(new Bank_shot(bankAccountNumber:BankAccountNumber,
                                            bankName:BankName, bankBalance:BankBalance,
                                            bankPassword:BankPassword));
                Console.WriteLine("Bank yaratildi. Ma'lumotlar saqlandi.");
            }
            else if (tanlovCreate == 2)
            {
                Console.Write("Bank nomini kiriting:");
                string bankNameInput = Console.ReadLine();
                foreach (var bankForeach in BanksList)
                {
                    if (bankForeach.BankName==bankNameInput)
                    {
                        string checkPassword;
                        do
                        {
                            Console.Write("Maxfiy codni kiriting:");
                            string checkPasswordInput = Console.ReadLine();
                            checkPassword = checkPasswordInput;
                            
                        }
                        while (bankForeach.BankPassword!=checkPassword);
                    }
                }
            }
        }
        
        
        private void BankShot()
        {


        }

        
        
    }
}
