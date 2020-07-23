using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lazyLoader.ProvideContent += LazyLoader_ProvideContent;
        }

        private void LazyLoader_ProvideContent(object sender, LazyLoaderLib.ProvideContentEventArgs args)
        {
            var corlorControl = args.Content as ColorControl;
            if (corlorControl != null)
            {
                corlorControl.Color = Colors.Orange;
            }
        }
    }
}
