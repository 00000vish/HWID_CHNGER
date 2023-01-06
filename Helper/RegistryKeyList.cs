using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWID_CHANGER.Helper
{
    public static class RegistryKeyList
    {
        public static RegistryEntry OsKey = new("Software\\Microsoft\\Windows NT\\CurrentVersion", "productName", RegistryValueKind.String);
        public static RegistryEntry HwidKey = new("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", "HwProfileGuid", RegistryValueKind.String);
    }
}
