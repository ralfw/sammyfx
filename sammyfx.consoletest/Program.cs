using System;
using System.Collections.Generic;
using System.Linq;


namespace sammyfx.consoletest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var app = new sammyfx.App (
				() => new Test(),
				new Dictionary<string,Func<sammyfx.IView>>{
					{"LoginView", () => new LoginView()},
					{"MainView", () => new MainView()}
				}
			);

			app.Run (args);
		}
	}


	class Test : Router {
		public Test() {
			Handle ("/", _ => new Response ("LoginView"));
			Handle ("/login", request => new Response ("MainView", request.Data));
			Handle ("/exit", _ => {Environment.Exit (0); return null; });
		}
	}


	class LoginView : sammyfx.IView {
		#region IView implementation
		public Request Show (object viewModel)
		{
			Console.Write ("user name: ");
			var username = Console.ReadLine ();

			return new Request ("/login", username);
		}
		#endregion
	}

	class MainView : sammyfx.IView {
		#region IView implementation
		public Request Show (object viewModel)
		{
			Console.WriteLine ($"welcome, {viewModel}");
			return new Request ("/exit");
		}
		#endregion
	}
}