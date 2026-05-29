using System.ComponentModel.DataAnnotations;

namespace ConsoleApp281;

public class PersonList : List<Person>
{
	//TODO: Implement such logic for the similar methods like Insert, InsertRange, etc.
	public new void Add(Person person) 
	{ 
		if (person == null) 
		{ 
			throw new ArgumentException("Person cannot be null."); 
		} 
		foreach (var p in this) 
		{ 
			if (p.Id == person.Id) 
			{ 
				throw new ArgumentException($"A person with Id {person.Id} already exists."); 
			} 
			if (!p.FirstName.All(char.IsLetter) || !p.LastName.All(char.IsLetter)) 
			{ throw new Exception("Invalid info."); 
			} 
		} base.Add(person); 
	}

	/// <summary>
	/// Writes the current List data to the specified stream.
	/// </summary>
	/// <param name="stream">The stream to which the data will be written. The stream must be writable and remain open for the duration of
	/// the operation.</param>
	/// <exception cref="NotImplementedException">This method is not implemented.</exception>
	public void Save(Stream stream)
    {
		using StreamWriter writer = new StreamWriter(stream);

		foreach (Person person in this)
		{
            if (person == null)
            {
                break;
            }
			writer.WriteLine($"{person.Id},{person.FirstName},{person.LastName},{person.DateOfBirth},{person.Gender},{person.ParentId}");
			if (person.Children.Count > 0)
			{
				foreach (Person child in person.Children)
				{
					writer.WriteLine($"{child.Id},{child.FirstName},{child.LastName},{child.DateOfBirth},{child.Gender},{child.ParentId}");
				}
			}
		}
	}

    /// <summary>
    /// Loads data from the specified stream into the current instance.
    /// </summary>
    /// <param name="stream">The stream from which to read the data. The stream must be readable and positioned at the beginning of the data
    /// to load.</param>
    /// <exception cref="NotImplementedException">Thrown in all cases. This method is not yet implemented.</exception>
    public void Load(Stream stream)
    {
        this.Clear();
		using StreamReader reader = new StreamReader(stream);
		Person[] tempPersonsLoad = new Person[1];
		string line;

		while ((line = reader.ReadLine()) != null)
		{
			string[] parts = line.Split(',');
			Person[] tempPersons = new Person[1];

			Person person = new Person
			{
				Id = int.Parse(parts[0]),
				FirstName = parts[1],
				LastName = parts[2],
				DateOfBirth = DateTime.Parse(parts[3]),
				Gender = Enum.Parse<Gender>(parts[4]),
                ParentId = int.Parse(parts[5]),
			};
            if (int.Parse(parts[5]) > 0)
            {
				foreach (Person p in this)
				{
					if (p.Id == person.ParentId)
					{
						p.Children.Add(person);
					}
				}
			}
            else
            {
				this.Add(person);
			}
		}
	}

    public void Save(string filePath)
    {
        ArgumentException.ThrowIfNullOrEmpty(filePath, nameof(filePath));
        
        using FileStream fileStream = new(filePath, FileMode.Create);
        Save(fileStream);
    }

    public void Load(string filePath)
    {
        ArgumentException.ThrowIfNullOrEmpty(filePath, nameof(filePath));
        if(!File.Exists(filePath))
            throw new FileNotFoundException($"The file '{filePath}' does not exist.");
        
        using FileStream fileStream = new(filePath, FileMode.Open);
        Load(fileStream);
    }
}