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

		private readonly IPlayer _player;

		private IDisposable _turnActivity;

		public PlayerService(
			IConfiguration configuration,
			ILogger<PlayerService> logger,
			IPlayer player)
		{
			_logger = logger;
			_player = player;

			var addressString = configuration.GetConnectionString("GameApi");

			_logger.LogTrace($"Creating player {_player.Title} connecting to {addressString}");

			_connection = new HubConnectionBuilder()
				.WithUrl(new Uri(addressString))
				.Build();
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			_logger.LogTrace($"Player {_player.Title} entering arena");

			await _connection.StartAsync(cancellationToken);

			_turnActivity = _connection.On("Turn", async () => await _player.MakeTurn());
		}

		public async Task StopAsync(CancellationToken cancellationToken)
		{
			_logger.LogTrace($"Player {_player.Title} leaves arena");

			_turnActivity.Dispose();
			await _connection.StopAsync(cancellationToken).ConfigureAwait(false);
			await _connection.DisposeAsync().ConfigureAwait(false);
		}
	}
}