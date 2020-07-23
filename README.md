# WPFLazyLoader
## 描述
一个简单的利用Dispacher优先级（DispatcherPriority）实现的懒加载控件，主要用于在界面完全加载之后再加载部分控件的需求
## 使用方法
编写一个懒加载内容提供者继承子ILazyLoadContentProvider
```C#
  public class TestProvider : ILazyLoadContentProvider
    {
        public object ProvideContent()
        {
            //返回需要懒加载的控件
            return new ColorControl();
        }
    }
```
在XAML中使用LazyLoader
```C#
<Window x:Class="DemoApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:DemoApp"
        xmlns:lazyloaderlib="clr-namespace:LazyLoaderLib;assembly=LazyLoaderLib"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <lazyloaderlib:LazyLoader Name="lazyLoader" >
            <local:TestProvider/>
        </lazyloaderlib:LazyLoader>
    </Grid>
</Window>
```
给懒加载添加事件处理
```C#
...
lazyLoader.ProvideContent += LazyLoader_ProvideContent;
...
private void LazyLoader_ProvideContent(object sender, LazyLoaderLib.ProvideContentEventArgs args)
{
    var corlorControl = args.Content as ColorControl;
    if (corlorControl != null)
    {
        corlorControl.Color = Colors.Orange;
    }
}
```
