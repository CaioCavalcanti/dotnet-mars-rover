using System.Threading.Tasks;

namespace Cardano.MarsRover.ConsoleApp
{
    public interface IMissionControlCenter
    {
        Task SendCommandAsync(string command);
        void GetMissionResults();
    }
}
