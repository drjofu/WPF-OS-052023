using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AsynchroneProgrammierung
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class Window1 : Window
  {
    private CancellationTokenSource cancellationTokenSource;
    private CancellationToken cancellationToken;

    public Window1()
    {
      InitializeComponent();
    }

    private async void BTN_Start_Click(object sender, RoutedEventArgs e)
    {
      cancellationTokenSource = new CancellationTokenSource();
      cancellationToken = cancellationTokenSource.Token;

      BTN_Start.IsEnabled = false;
      //Task.Run(Inkrementieren)
      //  .ContinueWith(t => BTN_Start.IsEnabled = true,TaskScheduler.FromCurrentSynchronizationContext());

      var t = Task.Run(Inkrementieren, cancellationToken);

      try
      {
        await t;
      }
      catch (Exception ex)
      {

      }

      //int antwort = await AntwortAufDieFrageAllerFragen();
      //LBL.Content = antwort;

      BTN_Start.IsEnabled = true;

    }

    private async Task<int> AntwortAufDieFrageAllerFragen()
    {
      await Task.Delay(5000, cancellationToken);
      return 42;
    }

    private void Inkrementieren()
    {
      for (int i = 0; i < 5; i++)
      {
        if (cancellationToken.IsCancellationRequested)
        {
          // aufräumen...
          cancellationToken.ThrowIfCancellationRequested();
        }

        Thread.Sleep(1000); // Nur zur Demo!!!!

        //LBL.Content = i;
        int k = i;
        Dispatcher.BeginInvoke(() => LBL.Content = k);
        //Dispatcher.BeginInvoke(() => Debug.WriteLine(k));
      }
    }

    private void BTN_Stopp_Click(object sender, RoutedEventArgs e)
    {
      cancellationTokenSource.Cancel();
    }
  }
}
