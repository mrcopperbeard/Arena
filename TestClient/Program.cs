using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR.Client;

namespace TestClient
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Tester is awaken");

			var connection = new HubConnectionBuilder()
				.WithUrl(new Uri("http://localhost:51818/sessionHub"))
				.Build();

			await connection.StartAsync(CancellationToken.None);

			Console.WriteLine("Tester connected");

			var isExecuting = true;

			while (isExecuting)
			{
				var input = Console.ReadLine();

				switch (input)
				{
					case null:
						break;
					case "q":
						isExecuting = false;
						break;
					case "turn":
						await connection.InvokeAsync("RequestTurn");
						break;
				}
			}

			await connection.StopAsync();
			await connection.DisposeAsync();

			Console.WriteLine("Tester disconnected");
		}
	}
}
