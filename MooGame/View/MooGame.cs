using Domain.Models;
using Domain.Services;
using Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.View
{
    public class MooGameConsole : IMooGame
    {

        private readonly IGoalMaker _goalMaker;
        private readonly IBcChecker _bcChecker;
        private readonly IResultProvider _resultProvider;

        public MooGameConsole()
        {
            _goalMaker = ServiceProviderManager.GetInstance()!.GetServiceProvider().GetService<IGoalMaker>();
            _bcChecker = ServiceProviderManager.GetInstance()!.GetServiceProvider().GetService<IBcChecker>();
            _resultProvider = ServiceProviderManager.GetInstance()!.GetServiceProvider().GetService<IResultProvider>();
        }

        /// <summary>
        /// This method is responsable of staring the 
        /// </summary>
        public void StartGame()
        {
            try
            {
                bool playOn = true;
                Console.WriteLine("Enter your user name:\n");
                string name = Console.ReadLine();

                while (playOn)
                {
                    string goal = _goalMaker.MakeGoal();

                    Console.WriteLine("New game:\n");
                    
                    //comment out or remove next line to play real games!
                    Console.WriteLine("For practice, number is: " + goal + "\n");
                    string guess = Console.ReadLine();
                    int nGuess = 1;

                    string bbcc = _bcChecker.Check(goal, guess);
                    Console.WriteLine(bbcc + "\n");
                    
                    while (bbcc != "BBBB,")
                    {
                        nGuess++;
                        guess = Console.ReadLine();
                        Console.WriteLine(guess + "\n");
                        bbcc = _bcChecker.Check(goal, guess);
                        Console.WriteLine(bbcc + "\n");
                    }
                    
                    //Save results
                    _resultProvider.SaveResult(name, nGuess);

                    //Show results
                    ShowTopList();
                    
                    
                    //Check if Continue
                    Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
                    string answer = Console.ReadLine();
                    if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                    {
                        playOn = false;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Faild to execute the program");
            }

        }


        private void ShowTopList()
        {
            List<Player> results = _resultProvider.GetResults();
            Console.WriteLine("Player   games average");
            foreach (Player p in results)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
        }
    }
}
