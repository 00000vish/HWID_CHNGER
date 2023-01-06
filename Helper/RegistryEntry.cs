using Microsoft.Win32;

namespace HWID_CHANGER.Helper
{
    public class RegistryEntry
    {
        public string Key { get; }

        public string Value { get; }

        public RegistryValueKind DataType { get; }

        public RegistryEntry(string key, string value, RegistryValueKind dataType)
        {
            Key = key;
            Value = value;
            DataType = dataType;
        }
    }
}
