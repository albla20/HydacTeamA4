using System;
using System.Collections.Generic;
using System.Text;

namespace KomGåSystem
{
    public class Menu
    {
        private int _itemCount = 0;
        private MenuItem[] _menuItems = new MenuItem[10];
        
        public Menu(string title)
        {
            Title = title;
        }

        public string Title { get; }
        public int ItemCount => _itemCount;

        public void Show()
        {
            Console.WriteLine(Title);
            Console.WriteLine();
            for (int i = 0; i < _itemCount; i++)
            {
                Console.WriteLine($"{_menuItems[i].Title}");
            }
            Console.WriteLine();
            //Console.WriteLine("(Indtast ønskede menu valg, efterfult af Enter)");
        }

        public void AddMenuItem(string menuTitle)
        {
            MenuItem newItem = new(menuTitle);
            _menuItems[_itemCount] = newItem;
            _itemCount++;
        }
    }
}
