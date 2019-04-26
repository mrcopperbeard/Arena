using System;

namespace Arena.Core
{
	public interface IPlayerSessionInfo : ISessionInfo
	{
		Guid PlayerToken { get; }

		string PlayerName { get; }

		string OpponentName { get; }
	}
}