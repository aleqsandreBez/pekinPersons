namespace ConsoleApp281
{
    internal class Program
    {
        static void Main()
        {
			PersonList personList = new PersonList();
			Person[] tempPersons = new Person[1];
			string answer = "";

			while (answer != "1" || answer != "2" || answer != "3")
			{

				Console.Write("Would you like to work with Persons, Lists, or text files? 1/2/3 ");
				answer = Console.ReadLine();

				if (answer == "1")
				{
					tempPersons = Persons(tempPersons);
				}

				if (answer == "2")
				{
					ListsPerson(personList, tempPersons);
				}

				if (answer == "3")
				{
					FileWork(personList);
				}

			}

			static Person[] Persons(Person[] tempPersons)
			{
				string answer = "";
				while (answer != "3")
				{
					Console.Write("Make new person, leave and save current persons, leave and discard 1/2/3 ");
					answer = Console.ReadLine();

					if (answer == "1")
					{
						if (tempPersons[tempPersons.Length - 1] != null)
						{
							Array.Resize(ref tempPersons, tempPersons.Length * 2);
						}

						Person person = new Person();
						person = person.PersonMaker(person);
						tempPersons[tempPersons.Length - 1] = person;
					}

					if (answer == "2")
					{
						return tempPersons;
					}
				}
				return null;
			}

			static void ListsPerson(PersonList personList, Person[] tempPersons)
			{
				string answer = "";

				while (answer != "1" && answer != "2")
				{
					Console.Write("Would you like to Add or Insert the current Persons into a list 1/2 ");
					answer = Console.ReadLine();
				}
				if (answer == "1")
				{
					foreach (Person person in tempPersons)
					{
						personList.Add(person);
					}
				}
			}

			static void FileWork(PersonList personList)
			{
				Console.Write("Would you like to save list to file or override list with file 1/2");
				string answer = Console.ReadLine();

				if (answer == "1")
				{
					Console.Write("write filepath");
					string filePath = Console.ReadLine();
					personList.Save(filePath);
				}
				
				if (answer == "2")
				{
					Console.Write("write filepath");
					string filePath = Console.ReadLine();
					personList.Load(filePath);
				}
			}
        }
    }
}
