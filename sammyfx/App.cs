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
			return new Request (
				args.Length >= 1 ? args[0] : "/",
				args.Skip(1)
			);
		}

		private Request Display(Response response) {
			if (this.viewFactories.ContainsKey (response.Viewname))
				return this.viewFactories [response.Viewname] ().Show (response.ViewModel);
			else
				throw new InvalidOperationException ($"Unknown view '{response.Viewname}'!");
		}
	}
}