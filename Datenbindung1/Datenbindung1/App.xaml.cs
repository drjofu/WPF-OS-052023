﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Datenbindung1
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    static App()
    {
      FrameworkElement.LanguageProperty.OverrideMetadata(
       typeof(FrameworkElement),
         new FrameworkPropertyMetadata(
         XmlLanguage.GetLanguage(
            CultureInfo.CurrentCulture.Name)
        )
      );

    }
  }
}
