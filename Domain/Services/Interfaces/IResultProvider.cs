

using Domain.Models;

namespace Domain.Services.Interfaces
{
    public interface IResultProvider
    {
        public void SaveResult(string name, int guess);
        public List<Player> GetResults();
    }
}
