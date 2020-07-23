using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace LazyLoaderLib
{
    /// <summary>
    /// 提供内容事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void OnProvideContentHandler(object sender, ProvideContentEventArgs args);

    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    [ContentProperty("LazyLoadContentProvider")]
    public partial class LazyLoader : UserControl
    {

        /// <summary>
        /// 提供内容事件
        /// </summary>
        public event OnProvideContentHandler ProvideContent;

        /// <summary>
        /// 懒加载内容
        /// </summary>
        public ILazyLoadContentProvider LazyLoadContentProvider
        {
            get { return (ILazyLoadContentProvider)GetValue(LazyLoadContentProperty); }
            set { SetValue(LazyLoadContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LayzyLoadContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LazyLoadContentProperty =
            DependencyProperty.Register("LazyLoadContentProvider", typeof(ILazyLoadContentProvider), typeof(LazyLoader), new PropertyMetadata(null));



        public LazyLoader()
        {
            InitializeComponent();

            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, new Action(LoadContent));

        }

        /// <summary>
        /// 加载内容
        /// </summary>
        private void LoadContent()
        {
            if (container.Content == null && LazyLoadContentProvider != null)
            {
                var content = LazyLoadContentProvider.ProvideContent();
                ProvideContentEventArgs args = new ProvideContentEventArgs(content);
                ProvideContent?.Invoke(this, args);
                if (!args.Cancel)
                {
                    container.Content = args.Content;
                }
            }
        }
    }
}
