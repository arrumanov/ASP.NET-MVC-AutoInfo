﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;
using AutoInfo.Services.Repository;
using AutoInfo.Infrastructure.Repository;
using AutoInfo.Services.EFContext;
using AutoInfo.Infrastructure.EFContext;
using AutoInfo.Services.UnitOfWorkEFDbContext;
using AutoInfo.Infrastructure.UnitOfWorkEFDbContext;

namespace AutoInfo.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // Здесь размещаются привязки
            kernel.Bind<ICarRepository>().To<CarRepository>();
            kernel.Bind<ICountryRepository>().To<CountryRepository>();
            kernel.Bind<IEFDbContext>().To<EFDbContext>();
            kernel.Bind<IUnitOfWorkEFDbContext>().To<UnitOfWorkEFDbContext>();
        }
    }
}