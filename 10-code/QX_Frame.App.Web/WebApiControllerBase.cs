using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace QX_Frame.App.Web
{
    public abstract class WebApiControllerBase: ApiController
    {
        protected static ChannelFactory<TChannel> Wcf<TChannel>() where TChannel : class
        {
            return WcfClientManager.Create<TChannel>();
        }
    }
}
