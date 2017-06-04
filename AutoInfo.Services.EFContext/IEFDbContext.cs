using AutoInfo.Domain.Core.Entities;
using System;
using System.Data.Entity;

namespace AutoInfo.Services.EFContext
{
    public interface IEFDbContext : IDisposable
    {
        IDbSet<Car> Cars { get; set; }
        IDbSet<Country> Countries { get; set; }

        int Save();

        void Update(Car car);
        void Update(Country country);
    }
}
