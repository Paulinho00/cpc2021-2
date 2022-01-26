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

        public static IEnumerable<object[]> GetPersonalDataForTestOfChecking6FirstDigitsCorectness()
        {
            yield return new object[]
            {
                new PersonalData(new DateTime(1975,11,9),false,true,"07117548092"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1975,11,9),false,true,"09047548079"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1975,11,9),false,true,"09119848056"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1975,11,9),false,true,"02127848036"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1975,11,9),false,true,"32132148081"),
            };
        }


        public static IEnumerable<object[]> GetCorrectPersonalData()
        {
            yield return new object[]
            {
                new PersonalData(new DateTime(1979,7,11),false,true,"11077941012"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1892,4,24),true,true,"24049264980"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(2009,1,25),false,true,"25010964418"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1922,8,28),false,false,"68082226607"),
            };
        }
    }
}
