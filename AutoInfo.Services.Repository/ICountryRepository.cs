using AutoInfo.Domain.Core.Entities;
using System.Collections.Generic;

namespace AutoInfo.Services.Repository
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAll();
        Country Get(int id);
        void Create(Country item);
        void Update(Country item);
        void Delete(int id);
    }
}
