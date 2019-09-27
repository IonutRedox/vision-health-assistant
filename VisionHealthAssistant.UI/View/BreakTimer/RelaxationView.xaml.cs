using System;
using System.Windows;
using System.Windows.Interop;
using VisionHealthAssistant.UI.Helper;

namespace VisionHealthAssistant.UI.View
{
    /// <summary>
    /// Interaction logic for RelaxationView.xaml
    /// </summary>
    public partial class RelaxationView : Window
    {
        public RelaxationView()
        {
            InitializeComponent();
        }

        private void RelaxationWindow_Loaded(object sender,RoutedEventArgs e)
        {
            WindowInteropHelper wndHelper = new WindowInteropHelper(this);

            int exStyle = (int)WindowHelper.GetWindowLong(wndHelper.Handle,(int)WindowHelper.GetWindowLongFields.GWL_EXSTYLE);

            exStyle |= (int)WindowHelper.ExtendedWindowStyles.WS_EX_TOOLWINDOW;
            WindowHelper.SetWindowLong(wndHelper.Handle,(int)WindowHelper.GetWindowLongFields.GWL_EXSTYLE,(IntPtr)exStyle);
        }
    }
}
