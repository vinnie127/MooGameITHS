using Domain.Models;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Implementations
{
    public class ResultProvider : IResultProvider
    {
        private const string RESULT_PATH = "result.txt";
        public void SaveResult(string name, int guess)
        {
            try
            {
                StreamWriter output = new StreamWriter(RESULT_PATH, append: true);
                output.WriteLine(name + "#&#" + guess);
                output.Close();
            }
            catch(Exception ex)
            {
                throw new FileLoadException();
            }
        }

        public List<Player> GetResults()
        {
            try
            {
                StreamReader input = new StreamReader(RESULT_PATH);
                List<Player> results = new List<Player>();
                string line;
                while ((line = input.ReadLine()) != null)
                {
                    string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                    string name = nameAndScore[0];
                    int guesses = Convert.ToInt32(nameAndScore[1]);
                    Player pd = new Player(name, guesses);
                    int pos = results.IndexOf(pd);
                    if (pos < 0)
                    {
                        results.Add(pd);
                    }
                    else
                    {
                        results[pos].Update(guesses);
                    }


                }
                results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

                return results;
            }
            catch(Exception ex)
            {
                throw new FileLoadException();
            }
           
        }
    }
}
