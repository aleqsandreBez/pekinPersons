namespace ConsoleApp281
{
	internal class Program
	{
		static void Main()
		{
			PersonList personList = new PersonList();
			Person[] tempPersons = new Person[1];
			Person[] tempChildren = new Person[1];

			string answer = "";

			while (answer != "1" || answer != "2" || answer != "3")
			{
				Console.Clear();
				DisplayManager.Display(personList, tempPersons, tempChildren);
				Console.Write("Make Person | Save To List | Save/Load Text File | 1/2/3 ");
				answer = Console.ReadLine();

				if (answer == "1")
				{
					Persons(ref tempPersons, ref tempChildren, personList);
				}

				if (answer == "2")
				{
					ListsPerson(personList, ref tempPersons, tempChildren);
				}

				if (answer == "3")
				{
					FileWork(personList, tempPersons, tempChildren);
				}
			}
		}

		static void Persons (ref Person[] tempPersons, ref Person[] tempChildren, PersonList personList) 
		{
			string answer = "";

			while (true)
			{
				Console.Clear();
				DisplayManager.Display(personList, tempPersons, tempChildren);
				Console.Write("Make Person | Make Child | Clear Person Cache | 1/2/3 ");
				answer = Console.ReadLine();

				if (answer == "1")
				{
					Person person = new Person();
					person = PersonService.PersonMaker(person);
					tempPersons[tempPersons.Length - 1] = person;
					Array.Resize(ref tempPersons, tempPersons.Length + 1);
					break;
				}

				if (answer == "2")
				{
					Person person = new Person();
					person = PersonService.ChildMaker(person, tempPersons, tempChildren);
					tempChildren[tempChildren.Length - 1] = person;
					Array.Resize(ref tempChildren, tempChildren.Length + 1);
					break;
				}

				if (answer == "3")
				{
					tempPersons = new Person[1];
				}
			}
		}

		static void ListsPerson(PersonList personList, ref Person[] tempPersons, Person[] tempChildren)
		{
			string answer = "";

			while (answer != "1" && answer != "2" && answer != "3")
			{
				Console.Clear();
				DisplayManager.Display(personList, tempPersons, tempChildren);
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

		static void FileWork(PersonList personList, Person[] tempPersons, Person[] tempChildren)
		{
			Console.Clear();
			DisplayManager.Display(personList, tempPersons, tempChildren);
			Console.Write("Save List To File | Load List From File | 1/2 ");
			string answer = Console.ReadLine();

			if (answer == "1")
			{
				Console.Clear();
				DisplayManager.Display(personList, tempPersons, tempChildren);
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
	}
}