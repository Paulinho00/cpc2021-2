using System;
using Xunit;

namespace PawełGryglewiczLab9PracDom.UnitTests
{
    public class PersonalDataTests
    {

        [Theory]
        [MemberData(nameof(PersonalDataTestsGenerator.GetPersonalDatasForTestOfCheckingIdNumberLength), MemberType = typeof(PersonalDataTestsGenerator))]
        public void CheckLengthOfIdNumberShouldReturnFalse(PersonalData personalData)
        {

            //Act
            bool result = personalData.IdNumberValidate();

            //Assert
            Assert.False(result);

        }



    }
}
