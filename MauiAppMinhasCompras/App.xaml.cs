﻿using MauiAppMinhasCompras.Helpers;
using System;
using System.IO;
using SQLite;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {

         static SQLiteDatabaseHelper _db;
           public static SQLiteDatabaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3"
                    );
                    _db = new SQLiteDatabaseHelper(path);
                }

                return _db ?? throw new InvalidOperationException("Erro ao inicializar o banco de dados.");
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
