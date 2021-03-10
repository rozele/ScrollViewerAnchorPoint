using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TestScrollViewer.AnchorRequested += TestScrollViewer_AnchorRequested;
            base.OnNavigatedTo(e);
        }

        private void TestScrollViewer_AnchorRequested(ScrollViewer sender, AnchorRequestedEventArgs args)
        {
        }

        private Grid CreateView()
        {
            var r = new Random();
            var rgb = new byte[3];
            r.NextBytes(rgb);
            var color = Color.FromArgb(byte.MaxValue, rgb[0], rgb[1], rgb[2]);

            return new Grid
            {
                Width = TestScrollViewer.Width,
                Height = 100,
                Background = new SolidColorBrush(color),
            };
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            TestContent.Children.Insert(0, CreateView());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            TestContent.Children.Add(CreateView());
        }

        private void ScrollButton_Click(object sender, RoutedEventArgs e)
        {
            TestScrollViewer.ChangeView(0, TestContent.ActualHeight - TestScrollViewer.ActualHeight, 1);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(((TextBox)sender).Text, out var value) && value >= 0 && value <= 1)
            {
                TestScrollViewer.VerticalAnchorRatio = value;
            }
        }
    }
}
