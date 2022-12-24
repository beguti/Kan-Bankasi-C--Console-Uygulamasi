using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kan_Bankası
{
    class DonorList
    {
        public string Name = "", LastName = "", PhoneNumber = "", LastBloodDonation = "", Address = "", BloodGroup = "";
        public int ID = 0, Age = 0, counter;

        BinaryReader dataReader;

        public void List()
        {
            Console.Title = " BLOOD BANK ---> Donor List";

            Menu load = new Menu();

            //Dosya mevcutsa
            if (File.Exists("Data"))
            {
                try
                {
                    dataReader = new BinaryReader(new FileStream("Data", FileMode.Open));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\t...Error encountered while reading The File...");
                    Console.WriteLine("-----------------------------------------------------------------");
                    return;
                }

                //Donör listesi yazdırma
                try
                {
                    Console.Clear();
                    Console.WriteLine("\t---DONOR LIST---");
                    Console.WriteLine("-----------------------------------");
                    counter = 1;

                    for (; ; )
                    {
                        ID = dataReader.ReadInt32();
                        Name = dataReader.ReadString();
                        LastName = dataReader.ReadString();
                        BloodGroup = dataReader.ReadString();
                        LastBloodDonation = dataReader.ReadString();
                        Age = dataReader.ReadInt32();
                        PhoneNumber = dataReader.ReadString();
                        Address = dataReader.ReadString();

                        Console.WriteLine($"\n{counter}. Donor");
                        Console.WriteLine(".......................................");
                        Console.WriteLine($"ID: {ID}");
                        Console.WriteLine($"Name and Last Name: {Name} {LastName}");
                        Console.WriteLine($"Age: {Age}");
                        Console.WriteLine($"Blood Group: {BloodGroup}");
                        Console.WriteLine($"Last Blood Donation Date: {LastBloodDonation}");
                        Console.WriteLine($"Phone Number: {PhoneNumber}");
                        Console.WriteLine($"Person's Address: {Address}");
                        Console.WriteLine(".......................................");
                        counter++;
                    }
                }
                catch (EndOfStreamException)
                {
                    Console.WriteLine("\n\n-----------------------------------------");
                    Console.WriteLine("\tEnd of Donor List");
                    Console.WriteLine("-----------------------------------------\n\n");
                }
                dataReader.Close();
            }

            //Dosya mevcut değilse
            else
            {
                Console.WriteLine("\n-----------------------------------------------------------------");
                Console.WriteLine("\n\tThe file does not exist.");
                Console.WriteLine("\n-----------------------------------------------------------------\n");
            }

            //Ana menüye dönme işlemi
            Console.WriteLine("\n-----------------------------------------------------------------");
            Console.WriteLine("\n\tPress any key to return to the main menu.");
            Console.WriteLine("\n-----------------------------------------------------------------\n");
            Console.ReadKey();
            load.Loading();
        }
    }
}

