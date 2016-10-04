using Ninject;
using System.Web.Mvc;
using System;
using System.Web.Routing;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
	public class NinjectControllerFactory : DefaultControllerFactory
	{
		private IKernel ninjectKernel;

		public NinjectControllerFactory()
		{
			ninjectKernel = new StandardKernel();
			AddBindings();
		}

		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
		}

		private void AddBindings()
		{
			ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
		}
	}
}