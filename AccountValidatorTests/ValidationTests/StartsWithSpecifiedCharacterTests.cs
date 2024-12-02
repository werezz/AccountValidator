using AccountValidator.Services.Validations.BasicValidations;

namespace AccountValidatorTests.ValidationTests
{
    internal class StartsWithSpecifiedCharacterTests
    {
        const char AccountNumberStartFirstCase = '3';
        StartsWithSpecifiedCharacter startsWithSpecifiedCharacter = new StartsWithSpecifiedCharacter();

        [Test]
        public void ValidaString_ReturnsTrue_WhenStringDoesStartWithSpecifiedCharacter()
        {
            var content = "3299992";
            var result = startsWithSpecifiedCharacter.CheckIfStringStartsWihtSpecifiedCharacter(content, AccountNumberStartFirstCase);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidaString_ReturnsFalse_WhenStringDoesNotStartWithSpecifiedCharacter()
        {
            var content = "12999921";
            var result = startsWithSpecifiedCharacter.CheckIfStringStartsWihtSpecifiedCharacter(content, AccountNumberStartFirstCase);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
