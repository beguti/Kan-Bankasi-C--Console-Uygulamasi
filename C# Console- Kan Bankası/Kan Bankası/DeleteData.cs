using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kan_Bankası
{
    class DeleteData
    {
		public string Name = "", LastName = "", PhoneNumber = "", LastBloodDonation = "", Address = "", BloodGroup = "";
		public int ID=0, Age=0, counter;

		BinaryReader dataReader;
		BinaryWriter dataWriter;

		public void DeleteDonor()
		{
			Console.Title = " BLOOD BANK ---> Donor Delete";

			Menu load = new Menu();

			//Dosya mevcutsa
			if (File.Exists("Data"))
			{
				//Donör listesini görmeyi veya silmeyi istediğini sordurma
				Console.WriteLine("-----------------------------------------------------------------");
				Console.WriteLine("Click on [1] to see the Donor List.\n\nTo delete the Donor List, press any key except \"1 \"...");
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
					Console.Write("\n\n\t...PRESS ANY BUTTON TO DELETE...\n\n");
					Console.ReadKey();
				}

				//Donör Silme Kısmı
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

				//Kayıt silme kısmı başlangıç 
				Console.WriteLine("..................................................................................................");
				Console.WriteLine("\tYou are currently on the screen where the Persons' İnformation is deleted");
				Console.WriteLine("..................................................................................................\n\n");

				try
				{
					//Silinecek kayıtın ID'sini isteme
					Console.WriteLine("-----------------------------------------------------------------");
					Console.Write("Enter the ID of the donor whose information you will delete: ");
					int DeleteID = int.Parse(Console.ReadLine());
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

						//Aynı ID olmadıkça veri tabanına yaz
						if (DeleteID != ID)
							Write();
						else
						{
							//Silme onayı alması
							Console.Clear();
							Console.WriteLine("\n-----------------------------------------------------------------");
							Console.Write("Are you sure you want to delete it? If you are sure, press the letter [d/D].\nIf you don't want to delete it, press any key on the keyboard except the [d/D] key. ");
							char delete = char.Parse(Console.ReadLine());
							if (delete != 'd' && delete != 'D')
								Write();
							else
                            {
								Console.Clear();
								Console.WriteLine("-----------------------------------------------------------------");
								Console.WriteLine("...YOUR TRANSACTION HAS BEEN COMPLETED SUCCESSFULLY...");
								Console.WriteLine("-----------------------------------------------------------------");
								System.Threading.Thread.Sleep(1000);
							}
						}
					}
				}
				catch (EndOfStreamException)
				{
					Console.WriteLine("-----------------------------------------------------------------");

				}
				dataReader.Close();
				dataWriter.Close();
				File.Delete("Data");
				File.Move("Data_Trash", "Data");
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
