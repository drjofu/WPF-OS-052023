using System.Windows;
using System.Windows.Media;

namespace RessourcenBeispiel2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void Ändern1(object sender, RoutedEventArgs e)
    {
      var brush = (LinearGradientBrush)this.Resources["LGB"];
      brush.GradientStops[0].Color = Colors.Red;
    }

    private void Ändern2(object sender, RoutedEventArgs e)
    {
      this.Resources["LGB"] = new LinearGradientBrush(Colors.Orange, Colors.Olive, 30);
    }
  }
}
