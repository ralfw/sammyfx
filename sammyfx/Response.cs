namespace sammyfx
{
	public class Response {
		public Response(string viewname) : this(viewname, null) {}
		public Response(string viewname, object viewModel) {
			this.Viewname = viewname;
			this.ViewModel = viewModel;
		}
		public string Viewname { get;}
		public object ViewModel {get;}
	}
}