using System;
using System.Collections.Generic;
using System.Linq;

namespace sammyfx
{
	public abstract class Router {
		Dictionary<string, Func<Request,Response>> handlers = new Dictionary<string, Func<Request, Response>> ();

		protected void Handle(string route, Func<Request, Response> handle) {
			this.handlers.Add (route.ToLower(), handle);
		}


		#region IRouteHandler implementation
		public Response Handle (Request request)
		{
			return this.handlers [request.Route.ToLower ()] (request);
		}
		#endregion
	}
}