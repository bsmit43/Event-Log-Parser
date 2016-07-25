using System;
using System.Windows;
using System.Windows.Threading;

namespace WpfApplication1
{
    //refresh method I found for update the progress bar so it doesnt get stuck during long processes
    public static class ExtensionMethods
    {
        private static Action EmptyDelegate = delegate () { };

        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
