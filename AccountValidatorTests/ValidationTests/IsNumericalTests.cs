using AccountValidator.Services.Validations.BasicValidations;

namespace AccountValidatorTests.ValidationTests
{
    internal class IsNumericalTests
    {
        IsNumerical isNumerical = new IsNumerical();

        [Test]
        public void ValidateString_ReturnsTrue_WhenStringIsNumerical()
        {
            var content = "3299992";
            var result = isNumerical.CheckIfStringIsOnlyNumerical(content);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateString_ReturnsFalse_WhenStringIsNotNumerical()
        {
            var content = "329999.";
            var result = isNumerical.CheckIfStringIsOnlyNumerical(content);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
