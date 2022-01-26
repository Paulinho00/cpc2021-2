using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KredekTests_Template
{
    public class StatisticsCalculator
    {

        public decimal CalculateMeanWorth(List<Vehicle> vehicles)
        {

            if(vehicles == null)
            {
                throw new ArgumentNullException("vehicles", "vehicles should not be null");
            }

            var sum = vehicles.Sum(dto => dto.Worth);

            var result = sum / vehicles.Count;


            return decimal.Round((decimal) result, 2);
        }
    }
}
