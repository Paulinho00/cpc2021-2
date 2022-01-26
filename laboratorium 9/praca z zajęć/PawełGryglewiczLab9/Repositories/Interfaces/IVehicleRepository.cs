using System.Collections.Generic;

namespace KredekTests_Template
{
    public interface IVehicleRepository
    {
        List<Vehicle> Get();
        Vehicle GetById(int id);
        int Add(Vehicle vehicle);
        Vehicle Update(Vehicle vehicle, int id);
        void Delete(int id);
    }
}
