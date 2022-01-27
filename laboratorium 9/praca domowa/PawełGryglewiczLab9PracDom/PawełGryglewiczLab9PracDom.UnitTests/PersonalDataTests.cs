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

        [Theory]
        [MemberData(nameof(PersonalDataTestsGenerator.GetPersonalDataForTestOfChecking6FirstDigitsCorectness), MemberType = typeof(PersonalDataTestsGenerator))]
        public void Check6FirstDigitsShouldReturnFalse(PersonalData personalData)
        {

            //Act
            bool result = personalData.IdNumberValidate();

            //Assert
            Assert.False(result);

        }

        [Theory]
        [MemberData(nameof(PersonalDataTestsGenerator.GetPersonalDataForTestOfCheckingSexOfPersonCorrectness), MemberType =typeof(PersonalDataTestsGenerator))]
        public void CheckSexOfPersonShouldReturnFalse(PersonalData personalData)
        {
            //Act
            bool result = personalData.IdNumberValidate();

            //Assert
            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(PersonalDataTestsGenerator.GetPersonalDataForTestOfCheckingIndividualNumberCorrectness), MemberType = typeof(PersonalDataTestsGenerator))]
        public void CheckIndividualNumberCorrectnessShouldReturnFalse(PersonalData personalData)
        {
            //Act
            bool result = personalData.IdNumberValidate();

            //Assert
            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(PersonalDataTestsGenerator.GetCorrectPersonalData), MemberType = typeof(PersonalDataTestsGenerator))]
        public void CheckCorrectPersonalDataShouldReturnTrue(PersonalData personalData)
        {

            //Act
            bool result = personalData.IdNumberValidate();

            //Assert
            Assert.True(result);
        }

    }
}
