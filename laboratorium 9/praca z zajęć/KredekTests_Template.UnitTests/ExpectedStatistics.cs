using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KredekTests_Template.UnitTests
{
    public class ExpectedStatistics
    {
        public decimal ExpectedMeanWorth { get; set; }

        public ExpectedStatistics(decimal expectedMeanWorth)
        {
            ExpectedMeanWorth = expectedMeanWorth;
        }
    }
}
