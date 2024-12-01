
namespace AccountValidatorTests.ValidationTests
{
    internal class StartsUpperCaseTests
    {
        StartsUpperCase startsUpperCase = new StartsUpperCase();

        [Test]
        public void ValidateString_ReturnsTrue_WhenStringStartsUpperCase()
        {
            var content = "Rob";
            var result = startsUpperCase.CheckIfStartsUpperCase(content);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateString_ReturnsTrue_WhenStringDoesNotStartsUpperCase()
        {
            var content = "michael";
            var result = startsUpperCase.CheckIfStartsUpperCase(content);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
