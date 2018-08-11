using System.IO;
using System.Linq;
using System.Net;

namespace StrawpollBot.Proxy
{
    internal class ProxyListParser
    {
        public static ProxyList ParseProxyList(FileInfo info)
        {
            if (info == null)
                return new ProxyList();
            var proxies = File.ReadAllLines(info.FullName).Select(line => new WebProxy(line)).Cast<IWebProxy>().ToList();
            return new ProxyList(proxies);
        }
    }
}
