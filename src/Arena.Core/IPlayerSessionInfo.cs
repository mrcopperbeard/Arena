using System;

namespace Arena.Core
{
	public interface IPlayerSessionInfo : ISessionInfo
	{


		string PlayerName { get; }

		string OpponentName { get; }
	}
}