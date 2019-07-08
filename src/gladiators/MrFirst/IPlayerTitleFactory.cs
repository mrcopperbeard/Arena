namespace MrFirst
{
	public interface IPlayerTitleFactory
	{
		string Create();
	}

	internal class PlayerTitleFactory : IPlayerTitleFactory
	{
		public string Create()
		{
			return "Bruce All Mighty";
		}
	}
}