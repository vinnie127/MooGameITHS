using Domain.Services.Implementations;

namespace Test
{
    public class BcCheckerTest
    {
        [Fact]
        public void Check_Return_String()
        {
            var chekcer = new BcChecker();
            var result = chekcer.Check("4269", "95");

            Assert.Equal(result, ",C");
        }
    }
}