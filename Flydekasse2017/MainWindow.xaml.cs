using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flydekasse2017
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassFlydekasseBizz CFB = new ClassFlydekasseBizz();

        //Initialisation of window
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = CFB;
            if(CFB.strMaterialDataSource == "FILE")
            {
                radioButtonFile.IsChecked = true;
                radioButtonDB.IsChecked = false;
            }
            else
            {
                radioButtonFile.IsChecked = false;
                radioButtonDB.IsChecked = true;
            }
        }

        private void radioButtonFile_Checked(object sender, RoutedEventArgs e)
        {
            radioButtonDB.IsChecked = false;
            CFB.strMaterialDataSource = "FILE";
            CFB.ClearAll();
        }

        private void radioButtonDB_Checked(object sender, RoutedEventArgs e)
        {
            radioButtonFile.IsChecked = false;
            CFB.strMaterialDataSource = "DB";
            CFB.ClearAll();
        }

        //Button, that adds material data to ChosenMaterialData
        private void buttonAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            CFB.AddToChosenMaterialData(comboBoxMaterial, textBoxThicknessInMM.Text);
        }

        //Button, that adds dimensions to BoxData
        private void buttonAddDimensions_Click(object sender, RoutedEventArgs e)
        {
            CFB.AddToDimData(Convert.ToDecimal(textBoxHeightInM.Text), Convert.ToDecimal(textBoxWidthInM.Text), Convert.ToDecimal(textBoxDepthInM.Text));
        }

        //Button, that generates a report, saves it, and opens the report in e.g. Notepad
        private void buttonMakeReport_Click(object sender, RoutedEventArgs e)
        {
            CFB.MakeReport();
            textBoxThicknessInMM.Text = "0";
            textBoxHeightInM.Text = "0";
            textBoxWidthInM.Text = "0";
            textBoxDepthInM.Text = "0";
            comboBoxMaterial.SelectedItem = -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        /// <summary>
        /// Menu item, that hides MainWindow and reveals AdminWindow. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemManageMaterialDataFile_Click(object sender, RoutedEventArgs e)
        {
            if (CFB.strMaterialDataSource == "FILE")
            {
                AdminWindow aw = new AdminWindow(this, CFB);
            this.Hide();
            aw.Show();
            }
            else
            {
                MessageBox.Show("You are currently using the database\nSwitch to File to edit data-file.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemHelp_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Method, that can contain actions do be done when clicking the X-button,
        /// Before closing the program.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">CancelEventArgs</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            App.Current.Shutdown();
        }

    }
}
