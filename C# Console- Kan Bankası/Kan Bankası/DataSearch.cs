using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kan_Bankası
{
    class DataSearch
    {
        public string Name = " ", LastName = "", PhoneNumber = "", LastBloodDonation = "", Address = "", BloodGroup = "", researchText;
        public int ID = 0, Age = 0, search, researchNumber, ctrl;
        public bool control = false;

        BinaryReader dataReader;

        public void DonorSearch()
        {
            ctrl = 1;
            Console.Title = " BLOOD BANK ---> Donor Search";

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
                while (ctrl != 0)
                {
                    Console.Clear();
                    Console.WriteLine("..................................................................................................");
                    Console.WriteLine("\tYou are currently on the screen where the Persons' İnformation is searched");
                    Console.WriteLine("..................................................................................................\n");

                    //Arama Menüsü
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("\tID\t\t[1] \n\tName\t\t[2]\n\tLast Name\t[3] \n\tBlood Group\t[4]\n\tAge\t\t[5]\n\tCity\t\t[6]");
                    Console.WriteLine("----------------------------------------------------");

                    Console.WriteLine("Please press the number of the transaction you want to do on your keyboard.[1-6]");
                    search = int.Parse(Console.ReadLine());
                    control = false;
                    switch (search)
                    {
                        case 1:
                            Console.Write("\n\nEnter the record's ID to search:");
                            researchNumber = int.Parse(Console.ReadLine());
                            ctrl = 0;
                            break;
                        case 2:
                            Console.Write("\n\nEnter the record's Name to search:");
                            researchText = Console.ReadLine();
                            ctrl = 0;
                            break;
                        case 3:
                            Console.Write("\n\nEnter the record's Last Name to search:");
                            researchText = Console.ReadLine();
                            ctrl = 0;
                            break;
                        case 4:
                            Console.Write("\n\nEnter the record's Blood Group to search:");
                            researchText = Console.ReadLine();
                            ctrl = 0;
                            break;
                        case 5:
                            Console.Write("\n\nEnter the record's Age to search:");
                            researchNumber = int.Parse(Console.ReadLine());
                            ctrl = 0;
                            break;
                        case 6:
                            Console.Write("\n\nEnter the record's City to search:");
                            researchText = Console.ReadLine();
                            ctrl = 0;
                            break;
                        default:
                            Console.WriteLine("Please enter the number in the correct range. [1-6]");
                            System.Threading.Thread.Sleep(1000);
                            break;
                    }
                }

                //Arama Gerçekleşme Yeri
                Console.Clear();
                Console.WriteLine("The recorded data is printing...\n");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                try
                {
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

                        if (search == 1)
                        {
                            if (researchNumber == ID)
                                DonorWrite();
                        }
                        else if (search == 2)
                        {
                            if (researchText == Name)
                                DonorWrite();
                        }
                        else if (search == 3)
                        {
                            if (researchText == LastName)
                                DonorWrite();
                        }
                        else if (search == 4)
                        {
                            if (researchText == BloodGroup)
                                DonorWrite();
                        }
                        else if (search == 5)
                        {
                            if (researchNumber == Age)
                                DonorWrite();
                        }
                        else
                        {
                            if (researchText == Address)
                                DonorWrite();
                        }
                    }
                }
                catch (EndOfStreamException)
                {
                    Console.WriteLine();
                    if (control == true)
                        Console.WriteLine("Searched in all records...");
                    else
                        Console.WriteLine("No Records Found");
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
        private void DonorWrite()
        {
            control = true;
            Console.WriteLine("..........................................");
            Console.WriteLine($"Person's ID: {ID}");
            Console.WriteLine($"Person's Name: {Name}");
            Console.WriteLine($"Person's Last Name: {LastName}");
            Console.WriteLine($"Person's Age: {Age}");
            Console.WriteLine($"Person's Blood Group: {BloodGroup}");
            Console.WriteLine($"Person's Last Blood Donation Date: {LastBloodDonation}");
            Console.WriteLine($"Person's Telephone Number: {PhoneNumber}");
            Console.WriteLine($"Person's City: {Address}");
            Console.WriteLine("..........................................\n");
        }
    }
}
