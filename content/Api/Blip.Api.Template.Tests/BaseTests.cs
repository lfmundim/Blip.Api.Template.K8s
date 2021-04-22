
using Bogus;

namespace Blip.Api.Template.Tests
{
    public abstract class BaseTests
    {
        private const string LOCALE = "pt_BR";
        protected readonly Faker Faker;

        public BaseTests()
        {
            Faker = new Faker(LOCALE);
        }
    }
}
