using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Arena.WebAPI.Hubs
{
	/// <inheritdoc />
	public class SessionHub : Hub
	{
		private readonly ILogger<SessionHub> _logger;

		public SessionHub(ILogger<SessionHub> logger)
		{
			_logger = logger;
		}

		/// <inheritdoc />
		public override Task OnConnectedAsync()
		{
			_logger.LogInformation($"Connection {Context.UserIdentifier} ({Context.ConnectionId}) created");

			return base.OnConnectedAsync();
		}

		public override Task OnDisconnectedAsync(Exception exception)
		{
			_logger.LogInformation($"Connection {Context.UserIdentifier} ({Context.ConnectionId}) closed");

			return base.OnDisconnectedAsync(exception);
		}

		public Task RequestTurn()
		{
			_logger.LogInformation($"Server sends {nameof(RequestTurn)} message");

			return Clients.All.SendAsync("Turn");
		}
	}
}