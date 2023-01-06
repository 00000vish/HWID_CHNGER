using HWID_CHANGER.Helper;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWID_CHANGER.ViewModels
{
    public class OsInfoViewModel : ReactiveObject
    {
        [Reactive]
        public string OsDetials { get; private set; }

        public OsInfoViewModel()
        {
            var os = RegistryController.ReadKeyValue(RegistryKeyList.OsKey);
            var version = Environment.OSVersion.ToString();
            OsDetials = $"{os} ( {version} )";
        }

    }
}
