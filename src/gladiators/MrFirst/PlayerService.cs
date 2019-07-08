using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MrFirst
{
	public class PlayerService : IHostedService
	{
		private readonly HubConnection _connection;

		private readonly ILogger<PlayerService> _logger;

		private readonly string _title;

		public PlayerService(
			IPlayerTitleFactory titleFactory,
			IConfiguration configuration,
			ILogger<PlayerService> logger)
		{
			_title = titleFactory.Create();
			_logger = logger;

			var addressString = configuration.GetConnectionString("GameApi");

			_logger.LogTrace($"Creating player {_title} connecting to {addressString}");

			_connection = new HubConnectionBuilder()
				.WithUrl(new Uri(addressString))
				.Build();

		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			_logger.LogTrace($"Player {_title} entering arena");

			return _connection.StartAsync(cancellationToken);
		}

		public async Task StopAsync(CancellationToken cancellationToken)
		{
			_logger.LogTrace($"Player {_title} leaves arena");

			await _connection.StopAsync(cancellationToken).ConfigureAwait(false);
			await _connection.DisposeAsync().ConfigureAwait(false);
		}
	}
}