namespace sammyfx
{
	public class Request {
		public Request(string route) : this(route, null) {}
		public Request(string route, object data) {
			this.Route = route;
			this.Data = data;
		}
		public string Route {get;}
		public object Data {get;}
	}
}