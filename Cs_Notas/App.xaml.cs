﻿using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Cs_Notas
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            BootStrap.Start();
        }
    }
}
