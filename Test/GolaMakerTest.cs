using Domain.Services.Implementations;

namespace Test
{
    public class GolaMakerTest
    {
        [Fact]
        public void MakeGoal_Return_String()
        {
            var chekcer = new GoalMaker();
            var result = chekcer.MakeGoal();
            
            int n;
            bool isNumeric = int.TryParse(result, out n);



            Assert.True(isNumeric);

            Assert.True(result.Length == 4);
        }
    }
}