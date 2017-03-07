using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CoffeeCostinator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        double total;
        string totalText = "Balance Outstanding: £";

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            if(localSettings.Values["total"] != null)
            {
                total = Convert.ToDouble(localSettings.Values["total"]);
            } else
            {
                total = 0;
            }

            txtTotalTitle.Text = totalText + Convert.ToString(total);
        }

        private void updateTotal(double value)
        {
            total = total + value;
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["total"] = total;
            txtTotalTitle.Text = totalText + Convert.ToString(total);
        }

        private void btnItem1_Click(object sender, RoutedEventArgs e)
        {
            updateTotal(1.5);
        }

        private void btnItem2_Click(object sender, RoutedEventArgs e)
        {
            updateTotal(1.8);
        }

        private void btnItem3_Click(object sender, RoutedEventArgs e)
        {
            updateTotal(2.2);
        }

        private void btn5Credit_Click(object sender, RoutedEventArgs e)
        {
            updateTotal(-5);
        }

        private void btn10Credit_Click(object sender, RoutedEventArgs e)
        {
            updateTotal(-10);
        }

        private void btnReset1_Click(object sender, RoutedEventArgs e)
        {
            btnResetConfirm.Opacity = 100;
            btnResetConfirm.IsEnabled = true;
            btnResetCancel.Opacity = 100;
            btnResetCancel.IsEnabled = true;
        }

        private void btnResetConfirm_Click(object sender, RoutedEventArgs e)
        {
            updateTotal(-total);
            btnResetConfirm.IsEnabled = false;
            btnResetConfirm.Opacity = 0;
            btnResetCancel.IsEnabled = false;
            btnResetCancel.Opacity = 0;
        }

        private void btnResetCancel_Click(object sender, RoutedEventArgs e)
        {
            btnResetConfirm.Opacity = 0;
            btnResetConfirm.IsEnabled = false;
            btnResetCancel.Opacity = 0;
            btnResetCancel.IsEnabled = false;
        }
    }
}
