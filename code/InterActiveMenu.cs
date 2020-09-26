﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomNameGenerator
{
    public class Menu  //basic menu logic gotten from https://codereview.stackexchange.com/questions/198153/navigation-with-arrow-keys and then modified for my task
    //  logic for selecting specific option
    {
        public Menu(IEnumerable<string> items)
        {
            Items = items.ToArray();
        }

        public IReadOnlyList<string> Items { get; }

        public int SelectedIndex { get; private set; } = 0; // first item selected by default

        public string SelectedOption => SelectedIndex != -1 ? Items[SelectedIndex] : null;


        public void MoveUp() => SelectedIndex = Math.Max(SelectedIndex - 1, 0);

        public void MoveDown() => SelectedIndex = Math.Min(SelectedIndex + 1, Items.Count - 1);

        // Recieves a string array and x and y coordinates to create the interactive menu at the x and y coordinates
        public static int Selection(string[] menuItems, int x, int y)
        {
            var menu = new Menu(menuItems);

            var countOfMenuItems = menuItems.Count();

            var menuPainter = new ConsoleMenuPainter(menu);

            bool done = false;

            do
            {
                menuPainter.Paint(x, y);

                var keyInfo = Console.ReadKey(true);

                menu.SelectedIndex = AlternateInputSelection(ref done, keyInfo, menu.SelectedIndex, countOfMenuItems);
                if (done)
                {
                    return menu.SelectedIndex;
                }

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: menu.MoveUp(); break;
                    case ConsoleKey.DownArrow: menu.MoveDown(); break;
                    case ConsoleKey.Enter:
                        done = true;
                        Console.ResetColor();
                        return (menu.SelectedIndex);
                    default:
                        break;
                }
            }
            while (!done);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Selected option: " + (menu.SelectedOption ?? "(nothing)"));
            Console.ReadKey();
            return (9);
        }

        private static int AlternateInputSelection(ref bool done, ConsoleKeyInfo keyInfo, int selectedIndex, int countOfMenuItems)
        {
            int selection = selectedIndex;

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1: selection = 0; break;
                case ConsoleKey.D2: selection = 1; break;
                case ConsoleKey.D3: selection = 2; break;
                case ConsoleKey.D4: selection = 3; break;
                case ConsoleKey.D5: selection = 4; break;
                case ConsoleKey.D6: selection = 5; break;
                case ConsoleKey.D7: selection = 6; break;
                case ConsoleKey.D8: selection = 7; break;
                case ConsoleKey.D9: selection = 8; break;
                case ConsoleKey.D0: selection = 9; break;
                default: return selection;
            }

            if (selection > countOfMenuItems - 1)
            {
                selection = selectedIndex;
            }

            done = true;
            return selection;
        }
    }

    // logic for drawing menu list
    public class ConsoleMenuPainter
    {
        readonly Menu menu;
        public ConsoleMenuPainter(Menu menu)
        {
            this.menu = menu;
        }

        public void Paint(int x, int y)
        {
            for (int i = 0; i < menu.Items.Count; i++)
            {
                Console.SetCursorPosition(x, y + i);

                if (menu.SelectedIndex == i)
                {
                    TextColor(11, 1);
                }
                else
                {
                    TextColor();
                }

                Console.WriteLine(menu.Items[i]);
            }
        }
        public static void TextColor(int fore = 15, int back = 0) //main way I change text color, set for overloading
        {
            Console.ForegroundColor = (ConsoleColor)(fore);
            Console.BackgroundColor = (ConsoleColor)(back);
        }
    }

    public class MenuData
    {

    }
}
