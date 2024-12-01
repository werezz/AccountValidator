using AccountValidator.Services.validations;

namespace AccountValidatorTests.ValidationTests
{
    internal class EndsWithSpecifiedCharacterTests
    {
        const char AcountNumberSpecialCharacter = 'p';
        EndsWithSpecifiedCharacter endsWithSpecifiedCharacter = new EndsWithSpecifiedCharacter(); 

        [Test]
        public void ValidateString_ReturnsTrue_WhenStringHasSpecifiedCharacter()
        {
            var content = "3113902p";
            var result = endsWithSpecifiedCharacter.CheckIfStringEndsWihtSpecifiedCharacter(content, AcountNumberSpecialCharacter);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateString_ReturnsFalse_WhenStringDoesNotHaveSpecifiedCharacter()
        {
            var content = "3113902t";
            var result = endsWithSpecifiedCharacter.CheckIfStringEndsWihtSpecifiedCharacter(content, AcountNumberSpecialCharacter);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
