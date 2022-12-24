using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kan_Bankası
{
    class UpdateData
    {
        public string Name = "", LastName = "", PhoneNumber = "", LastBloodDonation = "", Address = "", BloodGroup = "";
        public int ID = 0, Age = 0, counter;

        BinaryReader dataReader; 
        BinaryWriter dataWriter;

        public void UpdateDonor()
        {
            Console.Title = " BLOOD BANK ---> Donor Update";

            Menu load = new Menu();

            //Dosya mevcutsa
            if (File.Exists("Data"))
            {
                //Donör listesini görmeyi veya güncelleme istediğini sordurma
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Click on [1] to see the Donor List.\n\nTo update the Donor List, press any key except \"1 \"...");
                Console.WriteLine("-----------------------------------------------------------------\n");
                if (Console.ReadLine() == "1")
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

                    //Listeye baktıktan sonra güncelleme yapma işlemine geçme
                    Console.Write("\n\n\t...PRESS ANY BUTTON TO UPDATE...\n\n");
                    Console.ReadKey();
                }

                //Donör Güncelleme Kısmı
                Console.Clear();
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
                try
                {
                    dataWriter = new BinaryWriter(new FileStream("Data_Trash", FileMode.Create));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\t...Error encountered while creating The File...");
                    Console.WriteLine("-----------------------------------------------------------------");
                    return;
                }

                //Güncelleme ID sorma
                Console.WriteLine("-----------------------------------------------------------------");
                Console.Write("Enter the ID of the donor whose information you will update: ");
                int UpdateID = int.Parse(Console.ReadLine());

                //Güncelleme ekranı
                Console.Clear();
                Console.WriteLine("..................................................................................................");
                Console.WriteLine("\tYou are currently on the screen where the Persons' İnformation is uptaded");
                Console.WriteLine("\n\t\tPlease fill in the Person's İnformation Completely!");
                Console.WriteLine("..................................................................................................");
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

                        //İstenilen ID olmadığında aynı şekilde yazdırma
                        if (UpdateID != ID)
                            Write();

                        //İstenilen ID eşlendiğinde güncelleme yapma
                        else if (UpdateID == ID)
                        {
                            string Name2, LastName2, BloodGroup2, LastBloodDonation2, PhoneNumber2, Address2;
                            int Age2;

                            Console.WriteLine("\n---> Personal Identity Information");
                            Console.Write("\n-Name of the Person: ");
                            Name2 = (Console.ReadLine());

                            Console.Write("\n-Person's Last Name: ");
                            LastName2 = (Console.ReadLine());

                            Console.Write("\n-Person's Age: ");
                            Age2 = int.Parse(Console.ReadLine());

                            Console.Write("\n-Person's Blood Group: ");
                            BloodGroup2 = (Console.ReadLine());

                            Console.Write("\n-Last Blood Donation Date (Day/Month/Year): ");
                            LastBloodDonation2 = (Console.ReadLine());

                            Console.WriteLine("\n---> Contact Information \n");

                            Console.Write("-Contact's Phone Number: ");
                            PhoneNumber2 = (Console.ReadLine());

                            Console.Write("\n-Person's City: ");
                            Address2 = (Console.ReadLine());
                            Console.WriteLine("\n-----------------------------------------------------------");

                            //Güncelleme onayı alması
                            Console.WriteLine("\n-----------------------------------------------------------------");
                            Console.Write("Are you sure you want to update it? If you are sure, press the letter [u/U].\nIf you don't want to update it, press any key on the keyboard except the [u/U] key. ");
                            char delete = char.Parse(Console.ReadLine());
                            if (delete == 'U' || delete == 'u')
                            {
                                dataWriter.Write(ID);
                                dataWriter.Write(Name2);
                                dataWriter.Write(LastName2);
                                dataWriter.Write(BloodGroup2);
                                dataWriter.Write(LastBloodDonation2);
                                dataWriter.Write(Age2);
                                dataWriter.Write(PhoneNumber2);
                                dataWriter.Write(Address2);
                                Console.Clear();
                                Console.WriteLine("-----------------------------------------------------------------");
                                Console.WriteLine("...YOUR TRANSACTION HAS BEEN COMPLETED SUCCESSFULLY...");
                                Console.WriteLine("-----------------------------------------------------------------");
                                System.Threading.Thread.Sleep(1000);
                            }
                            else
                                Write();
                        }
                    }
                }
                catch (EndOfStreamException)
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("-----------------------------------------------------------------");
                }
                dataReader.Close();
                dataWriter.Close();
                File.Delete("Data");
                File.Move("Data_Trash", "Data");
                Console.Clear();
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

        private void Write()
        {
            dataWriter.Write(ID);
            dataWriter.Write(Name);
            dataWriter.Write(LastName);
            dataWriter.Write(BloodGroup);
            dataWriter.Write(LastBloodDonation);
            dataWriter.Write(Age);
            dataWriter.Write(PhoneNumber);
            dataWriter.Write(Address);
        }

    }
}
