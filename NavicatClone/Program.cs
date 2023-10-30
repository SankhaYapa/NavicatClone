using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.SqlServer.Management.Common;

namespace NavicatClone
{
	internal static class Program
	{
		[STAThread]
		static void Main()
		{
			IConfiguration configuration = new ConfigurationBuilder()
			  .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			  .AddJsonFile("appsetting.json")
			  .Build();

			// Retrieve the connection string
			string connectionString = configuration.GetConnectionString("MyConnection");

			// Use the connection string in your application
			ApplicationConfiguration.Initialize();
			Application.Run(new Form1());
		}
	}
}
