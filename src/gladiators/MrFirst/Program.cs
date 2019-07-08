using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Hosting;
using NLog.Extensions.Logging;

namespace MrFirst
{
	internal class Program
	{
		private static async Task Main()
		{
			Console.WriteLine("Raising player...");

			await new HostBuilder()
				.ConfigureAppConfiguration((_, builder) =>
				{
					builder.SetBasePath(Directory.GetCurrentDirectory());
					builder.AddJsonFile("appSettings.json", false, true);
				})
				.ConfigureServices((ctx, services) =>
				{
					services.AddSingleton<IPlayerTitleFactory, PlayerTitleFactory>();

					services.AddHostedService<PlayerService>();
				})
				.ConfigureLogging((context, builder) =>
				{
					builder.ClearProviders();
					builder.SetMinimumLevel(LogLevel.Trace);
					builder.AddNLog(context.Configuration);
				})
				.RunConsoleAsync();

			Console.WriteLine("Player stopped");
		}
	}
}
