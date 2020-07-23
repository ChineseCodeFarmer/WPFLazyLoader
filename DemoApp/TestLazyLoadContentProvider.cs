using LazyLoaderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{

    public class TestLazyLoadContentProvider : ILazyLoadContentProvider
    {
        public object ProvideContent()
        {
            return new ColorControl();
        }
    }
}
