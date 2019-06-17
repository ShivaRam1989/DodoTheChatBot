using DoDo.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DoDo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        ChatSessionView cView = new ChatSessionView();
        protected override void OnStartup(StartupEventArgs e)
        {
            cView.Show();
        }



    }
}
