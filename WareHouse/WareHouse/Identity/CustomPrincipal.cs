using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace WareHouse.Identity
{
	public class CustomPrincipal : IPrincipal
	{
		private CustomIdentity _identity;

		public CustomIdentity Identity
		{
			get { return _identity ?? new AnonymousIdentity(); }
			set { _identity = value; }
		}

		#region IPrincipal Members
		IIdentity IPrincipal.Identity
		{
			get { return this.Identity; }
		}

		public bool IsInRole(string role)
		{
			var roles = Enum.GetNames(typeof(Role));
			return roles.Contains(role);
		}
		#endregion

	}


}
