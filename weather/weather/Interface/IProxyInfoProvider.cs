using System;
using System.Net;

namespace weather.Interface
{
    public interface IProxyInfoProvider
    {
        WebProxy GetProxySettings();
    }
}
