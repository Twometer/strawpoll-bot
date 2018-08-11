using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace StrawpollBot.Proxy
{
    internal class ProxyList
    {

        private static readonly IWebProxy NoProxy = new WebProxy();

        private readonly List<IWebProxy> _proxies;
        private int _idx;

        public ProxyList(List<IWebProxy> proxies)
        {
            _proxies = proxies;
        }

        public ProxyList()
        {
        }

        public IWebProxy NextProxy()
        {
            if (_proxies == null)
                return NoProxy;
            var proxy = _proxies[_idx];
            Interlocked.Increment(ref _idx);
            return proxy;
        }
    }
}
