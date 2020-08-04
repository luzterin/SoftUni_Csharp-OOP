﻿using System;

namespace ProductCatalog.Utils
{
    public class Application
    {
        private readonly Menu menu;

        public Application(Menu _menu)
        {
            this.menu = _menu;
        }
        public void Run(string[] args)
        {
            bool running = true;
            while (running)
            {
                running = menu.MainMenu();
            }
        }
    }
}