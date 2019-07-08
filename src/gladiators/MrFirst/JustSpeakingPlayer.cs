using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MrFirst
{
	public class JustSpeakingPlayer : IPlayer
	{
		private readonly ILogger<JustSpeakingPlayer> _logger;

		public JustSpeakingPlayer(IPlayerTitleFactory titleFactory, ILogger<JustSpeakingPlayer> logger)
		{
			_logger = logger;
			Title = titleFactory.Create();
		}


		public string Title { get; }
		public Task MakeTurn()
		{
			_logger.LogInformation($"{Title} says: arrgh!");

			return Task.CompletedTask;
		}
	}
}