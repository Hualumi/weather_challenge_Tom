using System;
using System.Net;
using Java.Lang;
using weather.Droid;
using weather.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(ProxyInfoProviderDroid))]
namespace weather.Droid
{
    public class ProxyInfoProviderDroid : IProxyInfoProvider
    {
        public WebProxy GetProxySettings()
        {
            var proxyHost = JavaSystem.GetProperty("http.proxyHost");
            var proxyPort = JavaSystem.GetProperty("http.proxyPort");

            return !string.IsNullOrEmpty(proxyHost) && !string.IsNullOrEmpty(proxyPort)
                ? new WebProxy($"{proxyHost}:{proxyPort}")
                : null;
        }
    }

}
