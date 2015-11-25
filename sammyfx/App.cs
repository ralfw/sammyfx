using System;
using System.Collections.Generic;
using System.Linq;

namespace sammyfx
{
	public class App
	{
		Func<Router> routerFactory;
		IDictionary<string, Func<IView>> viewFactories;


		public App(Func<Router> routerFactory, IDictionary<string, Func<IView>> viewFactories) {
			this.routerFactory = routerFactory;
			this.viewFactories = viewFactories;
		}


		public void Run(string[] args) {
			var req = Create_request_for_commandline (args);
			Run (req);
		}

		public void Run(Request request) {
			while (true) {
				var response = this.routerFactory().Handle (request);
				request = Display (response);
			}
		}


		static Request Create_request_for_commandline (string[] args)
		{
			var req = new Request ("/", null);
			if (args.Length > 1) req = new Request ("/" + args[0], null);
			return req;
		}


		private Request Display(Response response) {
			return this.viewFactories [response.Viewname]().Show (response.ViewModel);
		}
	}
}