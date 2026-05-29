using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp281;

public class Person
{
	private int _id;
	private string _firstName;
	private string _lastName;
	private DateTime _dateOfBirth;
	private Gender _gender;

	public int ParentId { get; set; }
	public int Id
	{
		get => _id;
		set
		{
			if (value <= 0)
			{
				throw new ArgumentException("Id must be positive.");
			}
			_id = value;
		}
	}

	public string FirstName
	{
		get => _firstName;
		set
		{
			if (string.IsNullOrWhiteSpace(value) || !value.All(char.IsLetter))
			{
				throw new ArgumentException("Invalid first name.");
			}
			_firstName = value;
		}
	}

	public string LastName
	{
		get => _lastName;
		set
		{
			if (string.IsNullOrWhiteSpace(value) || !value.All(char.IsLetter))
			{
				throw new ArgumentException("Invalid last name.");
			}
			_lastName = value;
		}
	}

	public DateTime DateOfBirth
	{
		get => _dateOfBirth;
		set
		{
			if (value > DateTime.Now)
			{
				throw new ArgumentException("Date of birth cannot be in the future.");
			}
			_dateOfBirth = value;
		}
	}

	public Gender Gender
	{
		get => _gender;
		set
		{
			if (!Enum.IsDefined(typeof(Gender), value))
			{
				throw new ArgumentException("Invalid gender.");
			}
			_gender = value;
		}
	}

	public List<Person> Children { get; set; } = new();

    public override string ToString()
    {
        return $"{FirstName} {LastName} (Id: {Id}, DOB: {DateOfBirth.ToShortDateString()}, Gender: {Gender})";
    }
}

public enum Gender
{
	Male,
	Female,
}
