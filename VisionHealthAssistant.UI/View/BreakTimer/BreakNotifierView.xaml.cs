using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VisionHealthAssistant.UI.View.BreakTimer
{
    /// <summary>
    /// Interaction logic for BreakNotifierView.xaml
    /// </summary>
    public partial class BreakNotifierView : Window
    {
        public BreakNotifierView()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Sets the window location to bottom right above the taskbar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender,RoutedEventArgs e)
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;
        }
    }
}
