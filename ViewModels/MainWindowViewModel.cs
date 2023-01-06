using ReactiveUI;
using System.Diagnostics;
using System.Reactive;

namespace HWID_CHANGER.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        public OsInfoViewModel OsDetails { get; private set; }

        public HardwareProfileViewModel HardwareProfile { get; private set; }

        public ReactiveCommand<Unit, Unit> GithubCommand { get; }

        public MainWindowViewModel()
        {
            OsDetails = new();
            HardwareProfile = new();

            GithubCommand = ReactiveCommand.Create(OpenGithubLink);
        }

        public void OpenGithubLink()
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/00000vish/HWID_CHNGER",
                UseShellExecute = true
            });
        }
    }
}
