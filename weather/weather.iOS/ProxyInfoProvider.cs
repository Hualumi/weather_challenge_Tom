using System;
using System.Net;
using CoreFoundation;
using weather.Interface;
using weather.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(ProxyInfoProviderIOS))]
namespace weather.iOS
{
    public class ProxyInfoProviderIOS : IProxyInfoProvider
    {
        public WebProxy GetProxySettings()
        {
            var systemProxySettings = CFNetwork.GetSystemProxySettings();

            var proxyPort = systemProxySettings.HTTPPort;
            var proxyHost = systemProxySettings.HTTPProxy;

            return !string.IsNullOrEmpty(proxyHost) && proxyPort != 0
                ? new WebProxy($"{proxyHost}:{proxyPort}")
                : null;
        }
    }
}
