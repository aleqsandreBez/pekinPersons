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
				Console.Clear();
				Display(personList, tempPersons);
				Console.Write("Make Person | Save To List | Save/Load Text File | 1/2/3 ");
				answer = Console.ReadLine();

				if (answer == "1")
				{
					tempPersons = Persons(tempPersons, personList);
				}

				if (answer == "2")
				{
					ListsPerson(personList, ref tempPersons);
				}

				if (answer == "3")
				{
					FileWork(personList, tempPersons);
				}
			}
		}

		static Person[] Persons(Person[] tempPersons, PersonList personList)
		{
			string answer = "";

			while (true)
			{
				if (tempPersons[tempPersons.Length - 1] != null)
				{
					Array.Resize(ref tempPersons, tempPersons.Length + 1);
				}

				Console.Clear();
				Display(personList, tempPersons);
				Console.Write("Make Person | Make Child | Clear Person Cache | 1/2/3 ");
				answer = Console.ReadLine();

				if (answer == "1")
				{
					Person person = new Person();
					person = PersonService.PersonMaker(person);
					tempPersons[tempPersons.Length - 1] = person;
					return tempPersons;
				}

				if (answer == "2")
				{
					Person person = new Person();
					person = PersonService.ChildMaker(person, tempPersons);
					return tempPersons;
				}

				if (answer == "3")
				{
					tempPersons = new Person[1];
					return tempPersons;
				}
			}
		}

		static void ListsPerson(PersonList personList, ref Person[] tempPersons)
		{
			string answer = "";

			while (answer != "1" && answer != "2" && answer != "3")
			{
				Console.Clear();
				Display(personList, tempPersons);
				Console.Write("Add Person To List | Insert Person To List | Clear List | 1/2/3 ");
				answer = Console.ReadLine();
			}

			if (answer == "1")
			{
				foreach (Person person in tempPersons)
				{
					tempPersons = new Person[1];
					personList.Add(person);
				}
			}

			if (answer == "3")
			{
				personList.Clear();
			}
		}

		static void FileWork(PersonList personList, Person[] tempPersons)
		{
			Console.Clear();
			Display(personList, tempPersons);
			Console.Write("Save List To File | Load List From File | 1/2 ");
			string answer = Console.ReadLine();

			if (answer == "1")
			{
				Console.Clear();
				Display(personList, tempPersons);
				Console.Write("write filepath ");
				string filePath = Console.ReadLine();
				personList.Save(filePath);
				personList.Clear();
			}

			if (answer == "2")
			{
				Console.Clear();
				Console.Write("write filepath ");
				string filePath = Console.ReadLine();
				personList.Load(filePath);
			}
		}

		static void Display(PersonList personList, Person[] tempPersons)
		{
			Console.WriteLine("Current *LIST* Of Persons: ");
			Console.WriteLine();

			foreach (Person person in personList)
			{
				if (person == null)
				{
					break;
				}

				Console.WriteLine(person);

				if (person.Children.Count > 0)
				{
					foreach (Person child in person.Children)
					{
						Console.WriteLine("\t" + child);
					}
				}

			}

			Console.Write(new string('\n', 2));
			Console.WriteLine("Current *CACHE* Of Persons: ");
			Console.WriteLine();

			foreach (Person person in tempPersons)
			{
				if (person == null)
				{
					break;
				}

				Console.WriteLine(person);

				if (person.Children.Count > 0)
				{
					foreach (Person child in person.Children)
					{
						Console.WriteLine("\t" + child);
					}
				}

			}

			Console.Write(new string('\n', 2));
		}
	}
}