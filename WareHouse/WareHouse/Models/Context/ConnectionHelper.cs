using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Models.Context
{
	public class ConnectionHelper: IConnectionHelper, IConfigurationHelper
	{
		public ConnectionHelper(IConfigurationRoot  configuration)
		{
			ConnectionString = configuration.GetConnectionString("WareHouseDb");
			Url = configuration.GetSection("Url").GetSection("address").Value;
		}

		public string ConnectionString { get; }

		public string Url { get; }
	}

	public interface IConnectionHelper
	{
		string ConnectionString { get; }
	}
	public interface IConfigurationHelper
	{
		string Url { get; }
	}
}
