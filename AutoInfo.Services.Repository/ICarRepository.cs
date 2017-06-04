using AutoInfo.Domain.Core.Entities;
using System.Collections.Generic;

namespace AutoInfo.Services.Repository
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        Car Get(int id);
        void Create(Car item);
        void Update(Car item);
        void Delete(int id);
    }
}
