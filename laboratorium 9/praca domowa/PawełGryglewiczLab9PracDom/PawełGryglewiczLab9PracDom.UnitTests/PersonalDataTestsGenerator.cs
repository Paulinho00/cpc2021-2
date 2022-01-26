using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawełGryglewiczLab9PracDom.UnitTests
{
    public class PersonalDataTestsGenerator
    {
        public static IEnumerable<object[]> GetPersonalDatasForTestOfCheckingIdNumberLength()
        {
            yield return new object[]
            {
                new PersonalData(new DateTime(1975,11,9),false,true,"091175480231"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1975,11,9),false,true,"0911754802"),
            };
        }

    }
}
