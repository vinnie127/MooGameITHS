using Domain.Services;
using Domain.Services.Implementations;
using Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using UI.View;

namespace UI
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Setup the DI pattern
            var service = new ServiceCollection()
                .AddSingleton<IBcChecker, BcChecker>()
                .AddSingleton<IGoalMaker, GoalMaker>()
                .AddSingleton<IResultProvider, ResultProvider>()
                .BuildServiceProvider();
            ServiceProviderManager.GetInstance().SetServiceProvider(service);


            IMooGame mooGame = new MooGameConsole();

            mooGame.StartGame();
        }

    }

    
}