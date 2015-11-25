using System;
using System.Collections.Generic;
using System.Linq;

namespace sammyfx
{

	public interface IView {
		Request Show (object viewModel);
	}
	
}
