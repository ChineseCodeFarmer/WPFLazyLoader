using System;

namespace LazyLoaderLib
{
    /// <summary>
    /// 提供内容事件参数
    /// </summary>
    public class ProvideContentEventArgs : EventArgs
    {
        public ProvideContentEventArgs()
        {
                
        }

        public ProvideContentEventArgs(object content)
        {
            Content = content;
        }

        /// <summary>
        /// 已生成的内容
        /// </summary>
        public object Content { get; set; }

        /// <summary>
        /// 是否取消本地加载
        /// </summary>
        public bool Cancel { get; set; }
    }
}
