public static class InputSingletone
{
	private static GameInput _instance = null;

	public static GameInput Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new GameInput();
			}
			return _instance;
		}
	}
}
