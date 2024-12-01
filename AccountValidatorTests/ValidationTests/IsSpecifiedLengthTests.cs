using AccountValidator.Services.validations;

namespace AccountValidatorTests.ValidationTests
{
    internal class IsSpecifiedLengthTests
    {
        const int AccountNumberLength = 7;
        IsSpecifiedLength isSpecifiedLength = new IsSpecifiedLength();

        [Test]
        public void ValidateString_ReturnsTrue_WhenStringIsSpecifiedSize()
        {
            var content = "3113902";
            var result = isSpecifiedLength.CheckIfStringIsSpecificLength(content, AccountNumberLength);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateString_ReturnsFalse_WhenStringIsNotSpecifiedSize()
        {
            var content = "329999";
            var result = isSpecifiedLength.CheckIfStringIsSpecificLength(content, AccountNumberLength);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
