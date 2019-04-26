using System;
using System.Threading.Tasks;

namespace Arena.Core
{
	public interface IGameDataProvider
	{
		Task New(Guid sessionUid);

		Task<ITurnResult> MakeTurn(ITurn turn);

		Task<IDesk> GetDesk(Guid sessionUid);
	}
}