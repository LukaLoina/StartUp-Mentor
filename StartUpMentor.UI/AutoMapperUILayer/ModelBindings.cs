using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace StartUpMentor.UI.AutoMapperUILayer
{
	public class ModelBindings : NinjectModule
	{
		public override void Load()
		{
			Kernel.Bind<Model.Common.IAnswer>().To<Model.Answer>();
			Kernel.Bind<Model.Common.IQuestion>().To<Model.Question>();
		}
	}
}
