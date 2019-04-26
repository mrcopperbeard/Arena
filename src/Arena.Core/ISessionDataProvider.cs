using System;
using System.Threading.Tasks;

namespace Arena.Core
{
	public interface ISessionDataProvider
	{
		Task<ISessionInfo> New();

		Task<IPlayerSessionInfo> RegisterPlayer(Guid sessionUid, string playerName);

		Task<ISessionInfo> Finish(Guid sessionUid, string winnerName);

		Task<ISessionInfo> Get(Guid sessionUid);
	}
}
