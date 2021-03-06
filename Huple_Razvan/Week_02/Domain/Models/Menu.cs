﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{

    public enum MenuType
    {
        Vegan,
        Meat,
        Beverages
    }

    public class Menu
    {
        public string Name { get; }
        public MenuType MenuType { get; }
        
        public List<MenuItem> menuItems { get; }

        public Menu(string name, MenuType menuType)
        {
            Name = name;
            MenuType = menuType;
            menuItems = new List<MenuItem>();
        }
    }
}
