using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace KredekTests_Template
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleDbContext _context;

        public VehicleRepository(VehicleDbContext context)
        {
            _context = context;
        }

        public List<Vehicle> Get()
        {
            return _context.Vehicles.ToList();
        }

        public Vehicle GetById(int id)
        {
            var result = _context.Vehicles.FirstOrDefault(opt => opt.Id == id);

            return result;
        }

        public int Add(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);

            _context.SaveChanges();

            return vehicle.Id;
        }

        public Vehicle Update(Vehicle vehicle, int id)
        {
            var result = _context.Vehicles.FirstOrDefault(opt => opt.Id == id);

            if (result == null) return null;

            result.Manufacturer = vehicle.Manufacturer ?? result.Manufacturer;
            result.Model = vehicle.Model ?? result.Model;
            result.YearOfProduction = vehicle.YearOfProduction ?? result.YearOfProduction;
            result.Worth = vehicle.Worth ?? result.Worth;

            _context.SaveChanges();

            return result;
        }

        public void Delete(int id)
        {
            var result = _context.Vehicles.FirstOrDefault(opt => opt.Id == id);

            if (result == null)
            {
                throw new ArgumentException($"Real Estate with id {id} does not exist");
            }

            _context.Vehicles.Remove(result);

            _context.SaveChanges();
        }
    }
}
