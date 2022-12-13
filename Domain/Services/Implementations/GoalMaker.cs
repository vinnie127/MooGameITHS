using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Implementations
{
    public class GoalMaker: IGoalMaker
    {

        private readonly Random _randomGenerator;

        public GoalMaker()
        {
            _randomGenerator = new Random();
        }

        public string MakeGoal()
        {
            string goal = "";
            for (int i = 0; i < 4; i++)
            {
                int random = _randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (goal.Contains(randomDigit))
                {
                    random = _randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                goal = goal + randomDigit;
            }
            return goal;
        }
    }
}
