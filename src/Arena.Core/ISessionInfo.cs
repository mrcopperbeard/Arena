using System;

namespace Arena.Core
{
	public interface ISessionInfo
	{
		Guid SessionUid { get; }
		long CurrentTurn { get; }
		Chip Chip { get; }
		SessionState State { get; }
		string Winner { get; }
	}
}