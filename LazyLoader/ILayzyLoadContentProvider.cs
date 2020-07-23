using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoaderLib
{
    /// <summary>
    /// 懒加载对象
    /// </summary>
    public interface ILazyLoadContentProvider
    {
        /// <summary>
        /// 提供内容
        /// </summary>
        /// <returns></returns>
        object ProvideContent();
    }
}
