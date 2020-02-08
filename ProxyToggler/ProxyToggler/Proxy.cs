using Microsoft.Win32;

namespace ProxyToggler
{
    class Proxy
    {
        public static bool CurrentProxyState
        {
            get
            {
                var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings");
                return key != null && (int)key.GetValue("ProxyEnable") != 0;
            }
            set
            {
                var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
                if (key != null) key.SetValue("ProxyEnable", value ? 0x01 : 0x00, RegistryValueKind.DWord);
            }
        }
    }
}
