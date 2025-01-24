using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Bank.Classes_Bank;

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
        //asosiy method
        public void BankYarat()
        {
            BankCustomers bankCustomer = new BankCustomers();
            do
            {
                Console.WriteLine("Assalomu alaykum, bizning bankga xush kelibsiz.");
                Console.Write("0.Bank ochish va bankga kirish," +
                            "\n1.Bank hisob ochish," +
                            "\n2.Bank hisob yopish," +
                            "\n3.Bank hisob raqamga depozit kiritish," +
                            "\n4.Bank hisob raqamidan pul yechish," +
                            "\n5.Bank hisob raqam ma'lumotlarini ko'rish," +
                            "\n6.Bank hisob raqamdan tranzikatsiya amalga oshirish." +
                            "\nTanlovingizni raqamda kiriting:");
                int inputSwitch = int.Parse(Console.ReadLine());
                
                switch (inputSwitch)
                {
                    case 0:
                        {
                            CreateBank();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 1:
                        {
                            bankCustomer.CreateAccount();
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            bankCustomer.CloseAccount();
                            Console.Clear();
                            break;
                        }
                    case 3:
                        {
                            bankCustomer.AddDeposit();
                            Console.Clear();
                            break;
                        }
                    case 4:
                        {
                            bankCustomer.CashOut();
                            Console.Clear();
                            break;
                        }
                    case 5:
                        {
                            bankCustomer.ViewCardBalance();
                            Console.Clear();
                            break;
                        }
                    case 6:
                        {
                            bankCustomer.cardTransaction();
                            Console.Clear();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Mumkin bo'lmagan buyruq kiritdingiz.");
                            Console.ReadKey();
                           Console.Clear();
                            break;
                        }
                }
            }
            while (true);
        }

        //bank ochish
        private void CreateBank()
        {
            string doWhileTekshir;
            do
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
                    BanksList.Add(new Bank_shot(bankAccountNumber: BankAccountNumber,
                                            bankName: BankName, bankBalance: BankBalance,
                                            bankPassword: BankPassword));
                    Console.WriteLine("Bank yaratildi. Ma'lumotlar saqlandi.");

                }
                else if (tanlovCreate == 2)
                {
                    Console.Write("Bank nomini kiriting:");
                    string bankNameInput = Console.ReadLine();
                    foreach (var bankForeach in BanksList)
                    {
                        if (bankForeach.BankName == bankNameInput)
                        {
                            string checkPassword;
                            do
                            {
                                Console.Write("Maxfiy codni kiriting:");
                                string checkPasswordInput = Console.ReadLine();
                                checkPassword = checkPasswordInput;

                            }
                            while (bankForeach.BankPassword != checkPassword);
                            Console.WriteLine($"{bankForeach.BankName}dagi pul miqdori:{bankForeach.BankBalance}");
                        }
                    }
                    
                }
                Console.Write("Bosh menyuga qaytmoqchi bo'lsangiz (0) buyrug'ini kiriting," +
                    "Shu bankda davom etish uchun (1) raqamini kiriting:");
                doWhileTekshir = Console.ReadLine();
            }
            while (doWhileTekshir == "0");

        }
             
        
    }
}
