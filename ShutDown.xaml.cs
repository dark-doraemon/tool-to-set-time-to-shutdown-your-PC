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
using System.IO;
using Microsoft.Win32;
using AutoItX3Lib;
namespace WPF_CSharp
{
    /// <summary>
    /// Interaction logic for notepad.xaml
    /// </summary>
    public partial class notepad : Window
    {
        
        public notepad()
        {
            InitializeComponent();
            txtTime.IsEnabled = false;
            cbo_choose.SelectedIndex = 0;
        }

        private void start_button_function(object sender, RoutedEventArgs e)
        {
            AutoItX3 a =new AutoItX3();
            a.Run(generate(),"",a.SW_HIDE);
            if(chk_time.IsChecked == true && txtTime.Text == "")
            {
                MessageBox.Show("Please set time out");
                return;
            } 
            //MessageBox.Show(generate());
        }
        private string generate()
        {
            string cmd = "shutdown ";
            cmd = cbo_choose.SelectedIndex == 0 ? cmd += "-s " : cmd += "-r ";
            if (chk_force.IsChecked == true) cmd += "-f ";
            if (chk_time.IsChecked == true)
            {
                cmd+= "-t " +  txtTime.Text + " " ;
            }
            if (txtComment.Text != "") cmd +=  "-c " + '"' + txtComment.Text + '"';
            return cmd;
        }
        private void abort_button_function(object sender, RoutedEventArgs e)
        {
            AutoItX3 a = new   AutoItX3();
            a.Run("shutdown -a","",a.SW_HIDE);
        }

      
        private void chk_time_Checked(object sender, RoutedEventArgs e)
        {
            if(chk_time.IsChecked == true)
            {
                txtTime.IsEnabled = true;
                txtTime.Focus();
            }
        }
    }
}
