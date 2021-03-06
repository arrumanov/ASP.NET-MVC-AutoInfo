﻿using AutoInfo.Domain.Core.Entities;
using AutoInfo.Services.UnitOfWorkEFDbContext;
using Ext.Net;
using Ext.Net.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoInfo.WebUI.Controllers
{
    public class CountryController : Controller
    {
        private IUnitOfWorkEFDbContext unitOfWork;

        //библиотека Ninject конструктор объявляет зависимость
        //от интерфейсов
        public CountryController(IUnitOfWorkEFDbContext UOW)
        {
            unitOfWork = UOW;
        }

        public ActionResult Index()
        {
            return View(unitOfWork.Countries.GetAll().ToList());
        }

        public ActionResult HandleChanges(StoreDataHandler handler)
        {
            ChangeRecords<Country> persons = handler.BatchObjectData<Country>();
            var store = this.GetCmp<Store>("Store1");

            foreach (Country created in persons.Created)
            {
                unitOfWork.Countries.Create(created);

                var record = store.GetByInternalId(created.PhantomId);
                record.CreateVariable = true;
                record.SetId(created.CountryId);
                record.Commit();
                created.PhantomId = null;
            }

            foreach (Country deleted in persons.Deleted)
            {
                unitOfWork.Countries.Delete(deleted.CountryId);
                
                store.CommitRemoving(deleted.CountryId);
            }

            foreach (Country updated in persons.Updated)
            {
                unitOfWork.Countries.Update(updated);

                var record = store.GetById(updated.CountryId);
                record.Commit();
            }

            return this.Direct();
        }
    }
}