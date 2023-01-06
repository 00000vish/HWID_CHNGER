using HWID_CHANGER.Helper;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HWID_CHANGER.ViewModels
{
    public class HardwareProfileViewModel : ReactiveObject
    {
        [Reactive]
        public string HwidValue { get; private set; }

        public ReactiveCommand<Unit, Unit> RandomizeCommand { get; }
        public ReactiveCommand<Unit, Unit> InputHwidCommand { get; }
        public ReactiveCommand<Unit, Unit> ChangeHwidCommand { get; }

        private string _detectedHwid;
        private static readonly Random _random = new Random();

        public HardwareProfileViewModel()
        {
            _detectedHwid = RegistryController.ReadKeyValue(RegistryKeyList.HwidKey);

            HwidValue = _detectedHwid;

            RandomizeCommand = ReactiveCommand.Create(RandomizeHwid);
            InputHwidCommand = ReactiveCommand.CreateFromTask(InputHwid);

            var canChangeHwid = this.WhenAnyValue(x => x.HwidValue)
                                    .Select(x => !string.IsNullOrWhiteSpace(x) && !x.Equals(_detectedHwid));

            ChangeHwidCommand = ReactiveCommand.Create(ChangeHwid, canChangeHwid);
        }

        private void ChangeHwid()
        {
            RegistryController.UpdateKeyValue(RegistryKeyList.HwidKey, HwidValue);
        }

        private void RandomizeHwid()
        {
            HwidValue = GenerateGUI();
        }

        private async Task InputHwid()
        {
            var view = ViewFinder.GetView();

            if (view == null) return;

            //for now... once more features added dont have to do this
            var backHeight = view.MaxHeight;
            var backWidth = view.MaxWidth;
            view.MinHeight = 500;
            view.MaxHeight = 500;
            view.MinWidth = 800;
            view.MaxWidth = 800;

            var input = await view.ShowInputAsync("Enter HWID", "Please make sure its a valid GUID!\n");

            view.MinHeight = backHeight;
            view.MaxHeight = backHeight;
            view.MinWidth = backWidth;
            view.MaxWidth = backWidth;

            if (string.IsNullOrWhiteSpace(input)) return;

            HwidValue = input;
        }

        private string GenerateGUI()
        {
            return $"{{{GenerateRandomString(8)}-{GenerateRandomString(4)}-{GenerateRandomString(4)}-{GenerateRandomString(4)}-{GenerateRandomString(12)}}}";
        }

        private string GenerateRandomString(int length)
        {
            string generated = "";
            for (int i = 0; i < length; i++)
            {
                if (GetRandomNumber(0, 100) < 60)
                {
                    generated += "" + GetRandomNumber(0, 9);
                }
                else
                {
                    generated += ("" + (char)GetRandomNumber(97, 122)).ToLower();
                }
            }
            return generated;
        }

        private int GetRandomNumber(int min, int max)
        {
            lock (_random)
            {
                return _random.Next(min, max);
            }
        }

    }
}
