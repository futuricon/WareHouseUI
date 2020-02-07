using System.Security.Principal;

namespace WareHouse.Identity
{
	public class CustomIdentity :IIdentity
	{
		public User User { get; set; }

		public CustomIdentity(string name, string email, string password,Role role)
		{
			User = new User()
			{
				Email = email,
				Password = password,
				Role = role,
				UserName = name
			};
		}
		public CustomIdentity(User user)
		{
			User = user;
		}

		public string AuthenticationType { get { return "Custom authentication"; } }
		public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }

		public string Name => User?.UserName;
	}

	public class AnonymousIdentity : CustomIdentity
	{
		public AnonymousIdentity()
			: base(string.Empty, string.Empty, string.Empty, Role.Worker)
		{ }
	}
}
