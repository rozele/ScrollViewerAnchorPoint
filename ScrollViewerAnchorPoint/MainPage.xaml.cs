using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ScrollViewerAnchorPoint
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string LOREM = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam auctor orci ac tortor dapibus laoreet.";

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            TestContent.Children.Clear();
            TestScrollViewer.VerticalAnchorRatio = 1.0;
            Enumerable.Repeat(0, 15)
                .Select((_, i) => CreateView(extraText: LOREM))
                .ToList()
                .ForEach(TestContent.Children.Add);
        }

        private Grid CreateView(string extraText = null, bool canBeScrollAnchor = false)
        {
            var r = new Random();
            var rgb = new byte[3];
            r.NextBytes(rgb);
            var color = Color.FromArgb(byte.MaxValue, rgb[0], rgb[1], rgb[2]);

            var grid = new Grid
            {
                Width = TestScrollViewer.Width,
                Background = new SolidColorBrush(color),
            };

            var text = new TextBlock
            {
                Text = $"CanBeScrollAnchor == {canBeScrollAnchor}{(extraText != null ? "\n" + extraText : string.Empty)}",
                Margin = new Thickness(30),
                TextWrapping = TextWrapping.Wrap,
            };

            grid.Children.Add(text);

            grid.PointerPressed += Grid_PointerPressed;

            return grid;
        }

        private void Grid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var grid = (Grid)sender;
            grid.CanBeScrollAnchor = !grid.CanBeScrollAnchor;
            var textBlock = (TextBlock)grid.Children[0];
            textBlock.Text = textBlock.Text.Replace((!grid.CanBeScrollAnchor).ToString(), grid.CanBeScrollAnchor.ToString());
        }
    }
}
