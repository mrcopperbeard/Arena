using System.Threading.Tasks;

namespace MrFirst
{
	public interface IPlayer
	{
		string Title { get; }

		Task MakeTurn();
	}
}