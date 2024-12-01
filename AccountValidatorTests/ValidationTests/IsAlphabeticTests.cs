
using AccountValidator.Services.validations;

namespace AccountValidatorTests.ValidationTests
{
    internal class IsAlphabeticTests
    {
        IsAlphaBetic isAlphaBetic = new IsAlphaBetic();

        [Test]
        public void ValidateString_ReturnsTrue_WhenStringIsAlphabetical()
        {
            var content = "Rob";
            var result = isAlphaBetic.CheckIfStringIsAlphabetic(content);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateString_ReturnsFalse_WhenStringIsNotAlphabetical()
        {
            var content = "XAEA-12";
            var result = isAlphaBetic.CheckIfStringIsAlphabetic(content);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
