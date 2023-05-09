using System.Windows;

namespace Datenbindung2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      this.DataContext = new Firma();
    }

    private void AlterAnpassen(object sender, RoutedEventArgs e)
    {
      var liste = ((Firma)DataContext).Mitarbeiter;
      foreach (var person in liste)
      {
        person.Alter++;
      }
    }

    private void NeuerMitarbeiter(object sender, RoutedEventArgs e)
    {
      var liste = ((Firma)DataContext).Mitarbeiter;
      liste.Add(new() { Name = "Der Neue", Alter = 21, Wohnort = "hier" });
    }
  }
}
