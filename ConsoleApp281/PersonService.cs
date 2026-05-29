namespace ConsoleApp281;

public static class PersonService
{
	public static Person ChildMaker(Person person, Person[] tempPersons)
	{
		person = PersonMaker(person);

		Console.Write("Enter parent ID: ");
		int parentId = int.Parse(Console.ReadLine());
		person.ParentId = parentId;

		foreach (Person p in tempPersons)
		{
			if (p.Id == parentId)
			{
				p.Children.Add(person);
				return person;
			}
		}

		throw new ArgumentException("Parent ID not found in cache.");
	}

	public static Person PersonMaker(Person person)
	{
		Console.Write("Enter Id: ");
		person.Id = int.Parse(Console.ReadLine());
		IdRegistry.Register(person.Id);

		Console.Write("Enter first name: ");
		person.FirstName = Console.ReadLine();

		Console.Write("Enter last name: ");
		person.LastName = Console.ReadLine();

		Console.Write("Enter birth year: ");
		int year = int.Parse(Console.ReadLine());

		Console.Write("Enter birth month: ");
		int month = int.Parse(Console.ReadLine());

		Console.Write("Enter birth day: ");
		int day = int.Parse(Console.ReadLine());

		person.DateOfBirth = new DateTime(year, month, day);

		Console.Write("Enter gender (Male/Female): ");
		person.Gender = Enum.Parse<Gender>(Console.ReadLine());

		return person;
	}
}