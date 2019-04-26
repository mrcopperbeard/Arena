using System;
using System.Threading.Tasks;

namespace Arena.Core
{
	public interface IGameDataProvider
	{
		Task New(Guid sessionUid);

		Task<ITurnResult> MakeTurn(Guid sessionUid, Guid playerToken, ITurn turn);

		Task<IDesk> GetDesk(Guid sessionUid);
	}
}