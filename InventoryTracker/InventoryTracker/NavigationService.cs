using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
/*
 * Taken from:
 * https://stackoverflow.com/questions/30860276/return-to-previous-window-on-wpf
 * 
 * */


namespace InventoryTracker
{
    public static class NavigationService
    {
        static NavigationService()
        {
            NavigationStack.Push(Application.Current.MainWindow);
        }

        private static readonly Stack<Window> NavigationStack = new Stack<Window>();

        public static void NavigateTo(Window win)
        {
            if (NavigationStack.Count > 0)
                NavigationStack.Peek().Hide();

            NavigationStack.Push(win);
            win.Show();
        }

        public static bool HideAndNavigateBack()
        {
            if (NavigationStack.Count <= 1)
                return false;

            NavigationStack.Pop().Hide();
            NavigationStack.Peek().Show();
            return true;
        }

        public static bool CloseAndNavigateBack()
        {
            if (NavigationStack.Count <= 1)
                return false;

            NavigationStack.Pop().Close();
            NavigationStack.Peek().Show();
            return true;
        }

        public static bool CanNavigateBack()
        {
            return NavigationStack.Count > 1;
        }

        //could be useful for performing FullInventory if you want to utilize the Navigation Service
        public static bool PopAndCloseAllHiddenWindows()
        {
            if (NavigationStack.Count <= 1)
                return false;
            while (NavigationStack.Count > 1)
            {
                NavigationStack.Pop().Close();
            }
            NavigationStack.Peek().Show();
            return true;
        }
    }
}

    /*
        public void OnNextClicked(object sender, EventArgs args)
        {
            NavigationService.NavigateTo(new Window2());
        

        public void OnPreviousClicked(object sender, EventArgs args)
        {
            NavigationService.NavigateBack();
        }
    */
