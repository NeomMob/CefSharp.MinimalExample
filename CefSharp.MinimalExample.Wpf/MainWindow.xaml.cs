using System;
using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Media.Animation;

namespace CefSharp.MinimalExample.Wpf
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void animateColumn(GridLength from, GridLength to, GridUnitType unit, FrameworkContentElement element)
        {
            GridLengthAnimation gridLengthAnim = new GridLengthAnimation();
            gridLengthAnim.GridUnitType = unit;//GridUnitType.Pixel;
            gridLengthAnim.From = from;
            gridLengthAnim.To = to;
            gridLengthAnim.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 250));
            Storyboard.SetTargetName(gridLengthAnim, element.Name);
            Storyboard.SetTargetProperty(gridLengthAnim, new PropertyPath("Width"));
            Storyboard board = new Storyboard();
            board.Children.Add(gridLengthAnim);
            board.Begin(this);
        }


        private void toggleBrowserVisibilityButton_Click(object sender, RoutedEventArgs e)
        {
            if (browserGridColumn.ActualWidth <1)
            {
                animateColumn(new GridLength(0, GridUnitType.Star), new GridLength(2, GridUnitType.Star), GridUnitType.Star, browserGridColumn);
            }
            else
            {
                animateColumn(new GridLength(2, GridUnitType.Star), new GridLength(0, GridUnitType.Star), GridUnitType.Star, browserGridColumn);
            }
        }
    }
}
