using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kan_Bankası
{
    class AddingData
    {
        public string Name = " ", LastName = "", PhoneNumber = "", LastBloodDonation = "", Address = "", BloodGroup = "";
        public int ID, Age;

        BinaryWriter dataWriter;
        BinaryReader dataReader;

        public void AddingDonor()
        {
            Console.Title = " BLOOD BANK ---> Adding Donor";

            Menu load = new Menu();

            //Ekleme kısmı
            try
            {
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

                    //ID çekme kısmı
                    try
                    {
                        for (; ; )
                        {
                            Read();
                        }
                    }
                    catch (EndOfStreamException)
                    {
                        //Sonunda yazı yazmaması için burayı boş bıraktık.
                    }
                    dataReader.Close();
                    //Olan dosyayı açma
                    dataWriter = new BinaryWriter(new FileStream("Data", FileMode.Append));
                }
                //Yeni dosya yaratma
                else
                {
                    dataWriter = new BinaryWriter(new FileStream("Data", FileMode.Create));
                    ID = 0;
                }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Error encountered while creating The File...");
                Console.WriteLine("-----------------------------------------------------------------");
                return;
            }
            try
            {
                char menu;
                do
                {
                    //Veri Giriş Ekranı
                    Console.Clear();
                    Console.WriteLine("..................................................................................................");
                    Console.WriteLine("\tYou are currently on the screen where the Persons' İnformation is entered..");
                    Console.WriteLine("\n\t\tPlease fill in the Person's İnformation Completely!");
                    Console.WriteLine("..................................................................................................");

                    Console.WriteLine("\n---> Personal Identity Information");
                    Console.Write("\n-Name of the Person: ");
                    Name = (Console.ReadLine());

                    Console.Write("\n-Person's Last Name: ");
                    LastName = (Console.ReadLine());

                    Console.Write("\n-Person's Age: ");
                    Age = int.Parse(Console.ReadLine());

                    Console.Write("\n-Person's Blood Group: ");
                    BloodGroup = (Console.ReadLine());

                    Console.Write("\n-Last Blood Donation Date (Day/Month/Year) : ");
                    LastBloodDonation = (Console.ReadLine());

                    Console.WriteLine("\n---> Contact Information \n");

                    Console.Write("-Contact's Phone Number: ");
                    PhoneNumber = (Console.ReadLine());

                    Console.Write("\n-Person's City: ");
                    Address = (Console.ReadLine());

                    //Ekleme onayı alması
                    Console.WriteLine("\n-----------------------------------------------------------------");
                    Console.Write("Are you sure you want to add it? If you are sure, press the letter [a/A].\nIf you don't want to add it, press any key on the keyboard except the [a/A] key. ");
                    char add = char.Parse(Console.ReadLine());
                    if (add == 'A' || add == 'a')
                    {
                        ID++;
                        //Veritabanına yazma
                        dataWriter.Write(ID);
                        dataWriter.Write(Name);
                        dataWriter.Write(LastName);
                        dataWriter.Write(BloodGroup);
                        dataWriter.Write(LastBloodDonation);
                        dataWriter.Write(Age);
                        dataWriter.Write(PhoneNumber);
                        dataWriter.Write(Address);
                        Console.WriteLine("\n-----------------------------------------------------------------");
                        Console.WriteLine("...YOUR TRANSACTION HAS BEEN COMPLETED SUCCESSFULLY...");
                        Console.WriteLine("-----------------------------------------------------------------");
                        System.Threading.Thread.Sleep(1000);
                    }
                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("If you want to continue adding donors, press any key on the keyboard except [M/m] key.\nIf you want to return to the previous Menu, enter the letter [M/m].");
                    Console.WriteLine("-----------------------------------------------------------------\n");
                    menu = char.Parse(Console.ReadLine());

                } while (menu != 'M' && menu != 'm');
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Error encountered while writing the file..");
                Console.WriteLine("-----------------------------------------------------------------");
                return;
            }
            dataWriter.Close();
            load.Loading();
        }

        private void Read()
        {
            ID = dataReader.ReadInt32();
            Name = dataReader.ReadString();
            LastName = dataReader.ReadString();
            BloodGroup = dataReader.ReadString();
            LastBloodDonation = dataReader.ReadString();
            Age = dataReader.ReadInt32();
            PhoneNumber = dataReader.ReadString();
            Address = dataReader.ReadString();
        }
    }
}
