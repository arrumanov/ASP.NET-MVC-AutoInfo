using AutoInfo.Services.Repository;
using System;

namespace AutoInfo.Services.UnitOfWorkEFDbContext
{
    public interface IUnitOfWorkEFDbContext : IDisposable
    {
        ICarRepository Cars { get; }
        ICountryRepository Countries { get; }

        int Save();
    }
}
