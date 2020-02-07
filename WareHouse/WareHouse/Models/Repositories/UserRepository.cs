using WareHouse.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WareHouse.Models.Context;

namespace WareHouse.Models.Repositories
{
	public interface IUserRepository
	{
		User GetUser(string username, string password);
	}

	public class UserRepository : IUserRepository
	{
		ApplicationDbContext context;
		public UserRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public User GetUser(string username,string password)
		{
			return null;//context.Users.FirstOrDefault(x => x.UserName == username &&x.Password ==password);
		}
	}
}
