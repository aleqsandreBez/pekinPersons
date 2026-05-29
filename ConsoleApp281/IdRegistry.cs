public static class IdRegistry
{
	private static HashSet<int> ids = new();

	public static void Register(int id)
	{
		if (!ids.Add(id))
			throw new Exception("Duplicate ID");
	}
}