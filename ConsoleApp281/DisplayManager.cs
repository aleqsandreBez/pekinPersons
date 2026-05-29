namespace ConsoleApp281;

public static class DisplayManager
{
	public static void Display(PersonList personList, Person[] tempPersons, Person[] tempChildren)
	{
		Console.WriteLine("Current *LIST* Of Persons: ");
		Console.WriteLine();
		listDisplay(personList);

		void listDisplay(PersonList personList)
		{
			int loopCounter = 0;
			foreach (Person person in personList)
			{
				if (person == null)
				{
					break;
				}

				Console.WriteLine(person);
				RecursiveSearch(person, loopCounter);
			}
		}

		Console.Write(new string('\n', 2));
		Console.WriteLine("Current *CACHE* Of Persons: ");
		Console.WriteLine();
		cacheDisplay(tempPersons, tempChildren);

		void cacheDisplay(Person[] tempPersons, Person[] tempChildren)
		{
			int loopCounter = 0;
			foreach (Person person in tempPersons)
			{
				if (person == null)
				{
					break;
				}

				Console.WriteLine(person);
				RecursiveSearch(person, loopCounter);
			}
		}

		void RecursiveSearch(Person person, int loopCounter)
		{
			loopCounter++;
			foreach (Person child in person.Children)
			{
				person = child;
				Console.WriteLine(new string(' ', loopCounter) + person);
				if (person.Children.Count > 0)
				{
					RecursiveSearch(person, loopCounter);
				}
			}
		}

		Console.Write(new string('\n', 2));
	}
}
