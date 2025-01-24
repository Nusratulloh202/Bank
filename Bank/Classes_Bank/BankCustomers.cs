using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes_Bank
{
    internal class BankCustomers
    {
        private static long initialCardNumber = 9860000000000000;
        //Mijozning propitelari        
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid CustomerId { get; set; }
        public long CardNumber { get; set; }
        public int CardBalance { get; set; }
        public int CardPassword { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        //List yaratish
        private static List <BankCustomers> Customers = new List<BankCustomers>();

        //Constructor
        internal BankCustomers(string name, string surname, Guid customerId, long cardNumber,
                                DateTimeOffset createTime, int cardBalance, int cardPassword)
        {
            Name = name;
            Surname = surname;
            CustomerId = Guid.NewGuid();
            CardNumber = cardNumber;
            CreateTime = DateTimeOffset.Now;
            CardBalance = cardBalance;
            CardPassword = cardPassword;
        }
        
        //overload Constructor
        internal BankCustomers()
        {

        }

        //Bank hisob va karta ochib beradigan method
        public void CreateAccount()
        {
            string newCustomer;
            do
            {
                Console.Clear();
                Console.WriteLine("Bank hisob ochishni tanladingiz.");
                Console.Write("Arizani to'ldiring!\nIsmingizni kiriting:");
                Name = Console.ReadLine();
                Console.Write("Familiyangizni kiriting:");
                Surname = Console.ReadLine();
                CustomerId = Guid.NewGuid();
                CreateTime = DateTimeOffset.Now;
                CardNumber=initialCardNumber++;
                Console.Write("Plastik kartaga qancha pul tashamoqchisiz ($):");
                CardBalance = int.Parse(Console.ReadLine());
                Console.Write("Karta uchun PIN cod kiriting(4 ta raqam):");
                CardPassword = int.Parse(Console.ReadLine());
                Customers.Add(new BankCustomers(Name, Surname, CustomerId, CardNumber, CreateTime, CardBalance, CardPassword));
                Console.Clear();
                Console.WriteLine($"Mijoz arizasi tasdiqlandi.\nMijoz ma'lumotlari saqlandi.\n" +
                              $"Mijoz ism familiyasi:{Surname} {Name},\nMijoz karta raqami:{CardNumber}," +
                              $"\nMijoz uchun bank hisob ochilgan vaqt: {CreateTime}," +
                              $"\nBank karta hisob balans:{CardBalance}$" +
                              $"\nBank karta o'rnatilgan PIN cod:{CardPassword}");
                Console.Write("Yangi hisob ochish uchun ariza kiritasizmi(ha/yoq):");
                newCustomer = Console.ReadLine();
                Console.Clear();
                
            }
            while (newCustomer=="ha");
            
        }


        //Bank accauntni yopadigan method
        public void CloseAccount()
        {
            string closeCustomer = "deault";
            do
            {
                Console.Write("Yopmoqchi bo'lgan karta raqamini kiriting:");
                long inputCloseCardNumber = long.Parse(Console.ReadLine());
                for (int i = Customers.Count - 1; i >= 0; i--)
                {
                    if (Customers[i].CardNumber == inputCloseCardNumber)
                    {
                        if (Customers[i].CardBalance != 0)
                            Console.WriteLine($"Sizning hisobingizda {Customers[i].CardBalance} $ pul bor ekan." +
                                              $"\nMarhamat pullaringizni oling.");
                        else
                            Console.WriteLine("Hisobingizda pul yo'q ekan.");
                        Customers.RemoveAt(i);
                        Console.WriteLine("Bank hisob muaffaqiyatli yopildi:");
                        Console.WriteLine("Sizni bankimizda yana kutib qolamiz.\nSog' bo'ling");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.Write("Bunday karta raqam egasi bizning ma'lumotlar bazamizda yo'q!" +
                                      "\nQayta urinib ko'rasizmi (ha/yoq)");
                        closeCustomer = Console.ReadLine().ToLower();
                        Console.Clear();
                        break;
                    }


                }
            }
            while (closeCustomer == "ha");
        }

            //tranzikatsiyalarni boshlaymiz.

            //Depozit qo'yish
        public void AddDeposit()
        {
            //Depozit miqdori
            int addMoney;
            string addMoneySelect="default";
            do
            {
                Console.Write("Karta raqamezni kiriting:");
                long inputDepositCardNumber = long.Parse(Console.ReadLine());
                Console.Write("Karta PIN cod kiriting:");
                int inputDepositPassword = int.Parse(Console.ReadLine());

                for (int i = Customers.Count-1; i >= 0; i--)
                {
                    if (Customers[i].CardNumber == inputDepositCardNumber && Customers[i].CardPassword == inputDepositPassword)
                    {
                        Console.Write("Kartangizga qancha miqdorda depozit kiritmoqchisiz($):");
                        addMoney = int.Parse(Console.ReadLine());
                        Customers[i].CardBalance += addMoney;

                        Console.WriteLine($"Pul kartaga qo'shildi.\nHozirda karta balans:{Customers[i].CardBalance}$.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.Write("Karta raqam yoki karta PIN kod noto'g'ri kiritildi.\nQayta urinib ko'rasizmi(ha/yoq):");

                        addMoneySelect = Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }

            } while (addMoneySelect == "ha");

        }

        //Pul yechib olish

        public void CashOut()
        {
            //Depozit miqdori
            int outMoney;
            string outMoneySelect = "default";
            do
            {
                Console.Write("Karta raqamezni kiriting:");
                long inputOutCardNumber = long.Parse(Console.ReadLine());
                Console.Write("Karta PIN cod kiriting:");
                int inputOutPassword = int.Parse(Console.ReadLine());

                for (int i = Customers.Count-1; i >= 0; i--)
                {
                    if (Customers[i].CardNumber == inputOutCardNumber && Customers[i].CardPassword == inputOutPassword)
                    {
                        Console.Write("Kartangizdan qancha miqdorda pul yechasiz($):");
                        outMoney = int.Parse(Console.ReadLine());
                        Customers[i].CardBalance -= outMoney;

                        Console.WriteLine($"Pul kartadan yechildi.\nHozirda karta balans:{Customers[i].CardBalance}$.");
                        Console.WriteLine($"Marhamat {outMoney}$ miqdordagi pulni oling.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.Write("Karta raqam yoki karta PIN kod noto'g'ri kiritildi.\nQayta urinib ko'rasizmi(ha/yoq):");
                        outMoneySelect = Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }

            } while (outMoneySelect == "ha");

        }


        public void ViewCardBalance()
        {
            //Depozit miqdori
            string viewMoneySelect = "default";
            do
            {
                Console.Write("Karta raqamezni kiriting:");
                long inputDepositCardNumber = long.Parse(Console.ReadLine());
                Console.Write("Karta PIN cod kiriting:");
                int inputDepositPassword = int.Parse(Console.ReadLine());

                for (int i = Customers.Count - 1; i >= 0; i--)
                {
                    if (Customers[i].CardNumber == inputDepositCardNumber && Customers[i].CardPassword == inputDepositPassword)
                    {
                        Console.WriteLine($"Hozirda kartangiz balansi: {Customers[i].CardBalance}$; ");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Write("Karta raqam yoki karta PIN kod noto'g'ri kiritildi.\nQayta urinib ko'rasizmi(ha/yoq):");
                        viewMoneySelect = Console.ReadLine();
                        Console.Clear();
                    }
                }

            } while (viewMoneySelect == "ha");

        }

        public void cardTransaction()
        {
            //Tranzaktion miqdori
            int transactionMoney;
            string transactionMoneySelect = "default";
            
            do
            {
                Console.Write("Karta raqamezni kiriting:");
                long inputTransactionCardNumber = long.Parse(Console.ReadLine());
                Console.Write("Karta PIN cod kiriting:");
                int inputTransactionPassword = int.Parse(Console.ReadLine());

                for (int i = Customers.Count - 1; i >= 0; i--)
                {
                    if (Customers[i].CardNumber == inputTransactionCardNumber && Customers[i].CardPassword == inputTransactionPassword)
                    {
                        Console.WriteLine("Pul o'tkazmoqchi bo'lgan karta raqamini kiriting:");
                        long secoundCardNumber = long.Parse(Console.ReadLine());

                        for (int a=Customers.Count - 1; a>=0; a--)
                            if (Customers[a].CardNumber == secoundCardNumber)
                            {
                                Console.Write($"Pul o'tkazmoqchi bo'lgan karta egasini" +
                                              $" Ism Familiyasi:{Customers[a].Surname} {Customers[a].Name}.");
                                Console.Write("\nO'tkazmoqchi bo'lgan pul miqdorezni kiriting($):");
                                int inpTransactionMoney = int.Parse(Console.ReadLine());

                                if (inpTransactionMoney <= Customers[i].CardBalance)
                                {
                                    Customers[a].CardBalance += inpTransactionMoney;
                                    Customers[i].CardBalance -= inpTransactionMoney;
                                    Console.WriteLine($"Pul qabul qilingan karta malumotlari:" +
                                                   $"\nIsm familiyasi:{Customers[a].Surname} {Customers[a].Name}," +
                                                   $"\nKarta raqami:{Customers[a].CardNumber}\n" +
                                                   $"\nPul yuborilgan karta ma'lumotlari." +
                                                   $"\nIsm familiya:{Customers[i].Surname} {Customers[i].Name}," +
                                                   $"\nKarta raqami:{Customers[i].CardNumber}," +
                                                   $"\nKarta Balansi:{Customers[i].CardBalance}.");

                                }

                                else
                                {
                                    Console.WriteLine($"Kartangizda o'tkazish uchun pul kam.\nKarta balansi:{Customers[i].CardBalance}");
                                }
                            }
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Write("Karta raqam yoki karta PIN kod noto'g'ri kiritildi.\nQayta urinib ko'rasizmi(ha/yoq):");
                        transactionMoneySelect = Console.ReadLine();
                        Console.Clear();
                    }
                }

            } while (transactionMoneySelect == "ha");



        

    }

    }
}
