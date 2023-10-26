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
	
			// Retrieve the connection string

			// Use the connection string in your application
			ApplicationConfiguration.Initialize();
			Application.Run(new Form1());
		}
	}
}
