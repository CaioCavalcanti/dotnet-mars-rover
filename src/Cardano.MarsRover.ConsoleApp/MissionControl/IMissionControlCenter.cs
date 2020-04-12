using System.Threading.Tasks;

namespace Cardano.MarsRover.ConsoleApp.MissionControl
{
    public interface IMissionControlCenter
    {
        Task SendCommandAsync(string command);
        void GetMissionResults();
    }
}
