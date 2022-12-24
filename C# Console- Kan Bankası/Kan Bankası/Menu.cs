using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kan_Bankası
{
    class Menu
    {
        static void Main(string[] args)
        {
            int menu, exit = 0, due=3;
            string login, password;

            //Tanımlamalar
            AddingData add = new AddingData();
            UpdateData update = new UpdateData();
            DataSearch search = new DataSearch();
            DeleteData delete = new DeleteData();
            DonorList list = new DonorList();
            Menu load = new Menu();

            //Consol Görsel Ayarlar
            Console.Title = " BLOOD BANK";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            while(due!=0)
            {
                // Giriş Ekranı
                Console.Clear();
                Console.WriteLine("----------------------------------------------------");
                Console.Write("\t...Welcome to the Blood Bank Database...");
                Console.WriteLine("\n----------------------------------------------------");
                Console.Write("\n\nPlease enter your username: ");
                login = Console.ReadLine();
                //Kullanıcı adı yanlış ise;
                if (login != "admin" && login != "user")
                {
                    Console.Clear();
                    due--;
                    Console.WriteLine("Wrong username. Please try again...");
                    Console.WriteLine($"\nYour remaining right: {due}");
                    System.Threading.Thread.Sleep(1000);
                }
                //Kullanıcı adı doğru ise;
                else
                {
                    Console.Write("Please enter your password: ");
                    password = Password();

                    //Şifre yanlış ise;
                    if (password != "admin" && password != "user")
                    {
                        Console.Clear();
                        due--;
                        Console.WriteLine("Wrong password. Please try again...");
                        Console.WriteLine($"\nYour remaining right: {due}");
                        System.Threading.Thread.Sleep(1000);
                    }
                    //Şifre doğru ise;
                    else
                    {
                        //Kullanıcı girişi
                        if (login == "user" && password == "user")
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t\tUser is logging in....");
                            System.Threading.Thread.Sleep(700);

                            //Menü 
                            while (exit != 5)
                            {
                                Console.Title = " BLOOD BANK ---> Menu";
                                Console.Clear();
                                Console.WriteLine("----------------------------------------------------");
                                Console.WriteLine("\tAdding Donor\t[1] \n\tDonor Search\t[2]\n\tDonor Update\t[3] \n\tDonor List\t[4] \n\tExit\t\t[5]");   //MENU
                                Console.WriteLine("----------------------------------------------------");
                                Console.WriteLine("Please press the number of the transaction you want to do on your keyboard.[1-4]");
                                menu = Convert.ToInt16(Console.ReadLine());
                                switch (menu)
                                {
                                    case 1:               //Donör Ekleme
                                        load.Loading();
                                        add.AddingDonor();
                                        break;
                                    case 2:                //Donör Arama
                                        load.Loading();
                                        search.DonorSearch();
                                        break;
                                    case 3:                 //Donör Güncelleme
                                        load.Loading();
                                        update.UpdateDonor();
                                        break;
                                    case 4:                 //Donör Listeleme
                                        load.Loading();
                                        list.List();
                                        break;
                                    case 5:                 //Çıkış yapılma işlemi
                                        Console.Title = " BLOOD BANK ---> Exit";
                                        Console.Clear();
                                        Console.WriteLine("\n\tPress \"5\" button again to exit.\nIf you want to return to the menu, press any number except \"5\".");
                                        exit = Convert.ToInt32(Console.ReadLine());
                                        break;

                                    default:                //Olmayan sayı girildiğinde
                                        Console.WriteLine("----------------------------------------------------");
                                        if (menu != 5)
                                            Console.WriteLine("Please enter the number in the correct range. [1-5]");
                                        System.Threading.Thread.Sleep(1000);
                                        break;
                                }
                            }
                            break;
                        }
                        //Yönetici girişi
                        else if (login == "admin" && password == "admin")
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t\tAdmin is logging in....");
                            System.Threading.Thread.Sleep(700);
                            
                            //Menü 
                            while (exit != 6)
                            {
                                Console.Title = " BLOOD BANK ---> Menu";
                                Console.Clear();
                                Console.WriteLine("----------------------------------------------------");
                                Console.WriteLine("\tAdding Donor\t[1] \n\tDonor Search\t[2]\n\tDonor Update\t[3] \n\tDonor Deletion\t[4] \n\tDonor List\t[5]\n\tExit\t\t[6]");   //MENU
                                Console.WriteLine("----------------------------------------------------");
                                Console.WriteLine("Please press the number of the transaction you want to do on your keyboard.[1-5]");
                                menu = Convert.ToInt16(Console.ReadLine());
                                switch (menu)
                                {
                                    case 1:             //Donör Ekleme
                                        load.Loading();
                                        add.AddingDonor();
                                        break;
                                    case 2:             //Donör Arama
                                        load.Loading();
                                        search.DonorSearch();
                                        break;
                                    case 3:             //Donör Güncelleme
                                        load.Loading();
                                        update.UpdateDonor();
                                        break;
                                    case 4:             //Donör Silme
                                        load.Loading();
                                        delete.DeleteDonor();
                                        break;
                                    case 5:             //Donör Listeleme
                                        load.Loading();
                                        list.List();
                                        break;
                                    case 6:             //Çıkış yapılma işlemi
                                        Console.Title = " BLOOD BANK ---> Exit";
                                        Console.Clear();
                                        Console.WriteLine("\n\tPress \"6\" button again to exit.\nIf you want to return to the menu, press any number except \"6\".");
                                        exit = Convert.ToInt32(Console.ReadLine());
                                        break;

                                    default:            //Olmayan sayı girildiğinde
                                        Console.WriteLine("----------------------------------------------------");
                                        if (menu != 6)
                                            Console.WriteLine("Please enter the number in the correct range. [1-6]");
                                        System.Threading.Thread.Sleep(1000);
                                        break;
                                }
                            }
                            break;
                        }
                        //Kullanıcı adı ve şifre uyuşmadığında
                        else
                        {
                            Console.Clear();
                            due--;
                            Console.WriteLine("Wrong password. Please try again...");
                            Console.WriteLine($"\nYour remaining right: {due}");
                            System.Threading.Thread.Sleep(1000);
                        }
                    }
                }
            }

            ///Çıkış yapılmıştır metni
            Console.Title = " BLOOD BANK ---> Exit";
            Console.Clear();
            if (due==0)
            {
                Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Please make sure you remember the username and password, re-open the blood bank automation system and try again.!");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("----------------------------------------------------");
                Console.Write("\tYOUR EXIT HAS BEEN COMPLETED!");
                Console.WriteLine("\n----------------------------------------------------");
                Console.ReadKey();
            }
        }

        //Loading Metodu
        public void Loading()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t...Loading...");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

        //Yıldızlı şifre yazdırma 
        private static string Password()
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            return pass;
        }
    }
}
