using System;
using System.Collections.Generic;

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

        public static IEnumerable<object[]> GetPersonalDataForTestOfCheckingSexOfPersonCorrectness()
        {
            yield return new object[]
            {
                new PersonalData(new DateTime(1979,7,11),true,true,"11077941012"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1892,4,24),false,true,"24049264980"),
            };
        }

        public static IEnumerable<object[]> GetPersonalDataForTestOfCheckingIndividualNumberCorrectness()
        {
            yield return new object[]
            {
                new PersonalData(new DateTime(1979,7,11),false,true,"11077951085"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1892,4,23),true,true,"23049249721"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(2009,1,25),false,true,"25010938875"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1979,7,11),false,true,"11077981073"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1892,4,24),true,true,"24049286755"),
            };

        }

        public static IEnumerable<object[]> GetPersonalDataForTestOfControlSumCheck()
        {
            yield return new object[]
            {
                new PersonalData(new DateTime(1979,7,11),false,true,"11077941023"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1979,7,11),false,true,"11077941009"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1979,7,11),false,true,"11077941011"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1979,7,11),false,true,"11077941013"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1979,7,11),false,true,"11077941022"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1979,7,11),false,true,"11077941002"),
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
                new PersonalData(new DateTime(1892,4,23),true,true,"23049264941"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(2009,1,25),false,true,"25010964418"),
            };
            yield return new object[]
            {
                new PersonalData(new DateTime(1922,8,27),false,false,"67082226661"),
            };
        }
    }
}
