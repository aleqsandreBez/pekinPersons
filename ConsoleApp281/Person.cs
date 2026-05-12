namespace ConsoleApp281;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }

    //public List<Person> Children { get; set; } = new List<Person>();

    public override string ToString()
    {
        return $"{FirstName} {LastName} (Id: {Id}, DOB: {DateOfBirth.ToShortDateString()}, Gender: {Gender})";
    }

	public Person PersonMaker(Person person)
	{
		Console.Write("Enter Id: ");
		person.Id = int.Parse(Console.ReadLine());

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

public enum Gender
{
	Male,
	Female,
}
