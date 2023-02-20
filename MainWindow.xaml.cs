using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace TestWpfFontEmbedsDotNet7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var resourceEnumerator = Application.Current.Resources.GetEnumerator();
            var fontChanger = new DispatcherTimer();
            fontChanger.Tick += (s, e) =>
            {
                if (!resourceEnumerator.MoveNext())
                {
                    resourceEnumerator.Reset();
                    resourceEnumerator.MoveNext();
                }

                if (resourceEnumerator.Value is FontFamily fontFamily)
                {
                    TestBlock.FontFamily = fontFamily;
                }
            };
            fontChanger.Start();
        }
    }
}
