using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Models.Infrastructure
{
	public enum MethodType
	{
		POST,
		GET
	}

	public interface ISynchronizeFactory
	{
		Task BeginSynchronizeAsync(string url, MethodType methodType, string json);
		Task BeginSynchronizeAsync<T>(string url, MethodType methodType, IEnumerable<T> jsonObject);

	}

	public class SynchronizeFactory : ISynchronizeFactory
	{
		public SynchronizeFactory(ILogger logger)
		{
			Logger = logger;
		}

		public ILogger Logger { get; }

		public Task BeginSynchronizeAsync(string url, MethodType methodType, string json)
		{
			throw new NotImplementedException();
		}

		public async Task BeginSynchronizeAsync<T>(string url, MethodType methodType, IEnumerable<T> jsonObject)
		{
			try
			{

				using (var client = new WebClient())
				{
					foreach (var item in jsonObject)
					{
						var serializeJson = JsonConvert.SerializeObject(item);
						client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
						string content = await client.UploadStringTaskAsync(new Uri(url), methodType.ToString(), serializeJson);
						Log.Logger.Information("Sended " + serializeJson);
					}

				}
			}
			catch (WebException ex)
			{
				Log.Logger.Error($"ERROR WebException {ex.Message}" );

				throw new WebException(ex.Message);
			}
			catch (Exception ex)
			{
				Log.Logger.Error($"ERROR Exception {ex.Message}");
				throw new Exception(ex.Message);
			}
		}
	}
}
