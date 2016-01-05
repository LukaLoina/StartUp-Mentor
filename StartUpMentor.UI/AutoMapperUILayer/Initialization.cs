using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StartUpMentor.Model.AutoMapper;
using Ninject;
using Ninject.Modules;
using AutoMapper;

namespace StartUpMentor.UI.AutoMapperUILayer
{
	public class AutoMapperModule : NinjectModule
	{
		public override void Load()
		{
			AutoMapper.Mapper.Initialize(c =>
			{
				c.ConstructServicesUsing(type => Kernel.Get(type));
				c.AddProfile<MappingConfiguration>();
				c.AddProfile<UIMappingConfiguration>();
			});
		}	  
	}
}				  
