using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace SCNorth.PropertyBasedTesting.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private const string UsersPath = @"Resources\users.json";

		private static string GetJsonData(string path)
		{
			return System.IO.File.ReadAllText(path);
		}

		private static void SaveJsonData(string path, string data)
		{
			System.IO.File.WriteAllText(path, data);
		}

		private static IEnumerable<User> UpdateUser(IEnumerable<User> users, User newUser)
		{
			return users.Select(user => 
				user.Id == newUser.Id ? newUser : user)
				.ToList();
		}

		[HttpGet("{id}")]
		public ActionResult<User> Get(int id)
		{
			var jsonData = GetJsonData(UsersPath);
			var user = JsonConvert.DeserializeObject<IEnumerable<User>>(jsonData).FirstOrDefault(x => x.Id == id);
			if (user == null)
			{
				throw new KeyNotFoundException();
			}

			return user;
		}

		[HttpGet]
		public IEnumerable<User> Get()
		{
			var jsonData = GetJsonData(UsersPath);
			return JsonConvert.DeserializeObject<IEnumerable<User>>(jsonData);
		}

		[HttpPost("{id}")]
		public IActionResult Update(int id, User newUser)
		{
			newUser.Id = id;

			var jsonData = GetJsonData(UsersPath);
			var users = JsonConvert.DeserializeObject<IEnumerable<User>>(jsonData).ToList();

			if (users.FirstOrDefault(x => x.Id == id) == null)
			{
				throw new KeyNotFoundException();
			}

			SaveJsonData(UsersPath, JsonConvert.SerializeObject(UpdateUser(users, newUser)));

			return Ok();
		}
	}
}
