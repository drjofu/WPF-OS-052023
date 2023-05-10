using System.ComponentModel;
using System.Threading;

namespace AsynchroneProgrammierung
{
  class Data : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler? PropertyChanged;

    public int Zähler { get; set; }
    private Timer timer;

    public Data()
    {
      timer = new(TimerTick, null, 0, 1000);
    }

    private void TimerTick(object state)
    {
      Zähler++;
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Zähler)));
    }
  }
}
