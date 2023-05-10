using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMMini
{
  public class ActionCommand : ICommand
  {
    public string DisplayText { get; set; }
    public string ToolTipText { get; set; }

    private readonly Action action;

    public ActionCommand(Action action)
    {
      this.action = action;
    }

    private bool isEnabled = true;

    public bool IsEnabled
    {
      get { return isEnabled; }
      set
      {
        isEnabled = value;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
      }
    }

    // ICommand implementation
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
      return isEnabled;
    }

    public void Execute(object? parameter)
    {
      action?.Invoke();
    }
  }
}
