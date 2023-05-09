using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Datenbindung2
{
  class Person : INotifyPropertyChanged
  {
    public string Name { get; set; }
    public string Wohnort { get; set; }
    //public int Alter { get; set; }

    private int alter;

    public int Alter
    {
      get { return alter; }
      set
      {
        if (alter == value) return;

        alter = value;
        OnPropertyChanged();
        OnPropertyChanged(nameof(IstErfahren));
      }
    }

    protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public bool IstErfahren => Alter > 50;

    public event PropertyChangedEventHandler PropertyChanged;
  }

  class Firma
  {
    public string Name { get; set; } = "Hinz & Kunz";
    public ObservableCollection<Person> Mitarbeiter { get; set; } = new()
    {
      new Person(){ Name="Dagobert", Wohnort="Entenhausen", Alter=77},
      new Person(){ Name="Marie", Wohnort="Köln", Alter=33},
      new Person(){ Name="Petra", Wohnort="Ulm", Alter=44},
      new Person(){ Name="Karl", Wohnort="München", Alter=65},
      new Person(){ Name="Carla", Wohnort="Berlin", Alter=56}
    };
  }
}
