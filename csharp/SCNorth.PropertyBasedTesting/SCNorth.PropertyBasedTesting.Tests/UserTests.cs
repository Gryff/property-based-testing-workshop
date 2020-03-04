using FsCheck;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SCNorth.PropertyBasedTesting.Tests
{
	public class UserTests
	{
		private readonly ITestOutputHelper _logger;

		public UserTests(ITestOutputHelper logger)
		{
			_logger = logger;
		}

		[Fact]
		public async Task GetSingleUserShouldReturn200StatusCode()
		{
			var client = new WebApplicationFactory<Startup>().CreateClient();

			var response = await client.GetAsync("/user/1");
			var status = response.StatusCode;

			Assert.Equal(HttpStatusCode.OK, status);
		}

		[Fact]
		public async Task GetSingleUserShouldContainHelicopter()
		{
			var client = new WebApplicationFactory<Startup>().CreateClient();

			var response = await client.GetAsync("/user/1");
			var body = await response.Content.ReadAsStringAsync();

			Assert.Contains("Helicopter", body);
		}

		[Fact]
		public void PropertyBasedTestShouldDoSomething()
		{
			// generators
			var generatorOutput = Gen.Sample(0, 10, Gen.Elements("foo", "bar"));
			_logger.WriteLine(string.Concat(generatorOutput));
			Assert.Contains("foo", generatorOutput);

			// properties
			Prop.ForAll<string[]>(xs => xs.Length != 0)
				.QuickCheckThrowOnFailure();
		}
	}
}
