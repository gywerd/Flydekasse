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

namespace Flydekasse2017
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        ClassFlydekasseBizz callBizz = new ClassFlydekasseBizz();
        Window callWindow = new Window();

        public AdminWindow(object v, object b)
        {
            InitializeComponent();
            callWindow = (Window)v;
            callBizz = (ClassFlydekasseBizz)b;
            this.DataContext = callBizz.CM;
            this.groupBox.DataContext = callBizz;
        }

        /// <summary>
        /// When an entry in the groupbox list is activated, the info about the contact is shown in the textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listMaterialData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = (ListView)sender;
            ClassMaterial cm = new ClassMaterial((ClassMaterial)lv.SelectedItem);
            callBizz.UpdateDataView(cm);
            buttonUpdateFile.Visibility = Visibility.Hidden;
            buttonAddMaterial.Visibility = Visibility.Hidden;
            buttonUpdateMaterial.Visibility = Visibility.Visible;
            buttonRemoveMaterial.Visibility = Visibility.Visible;
        }


        //Button, that adds material to MaterialData
        private void buttonAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            callBizz.AddToMaterialData();
            buttonAddMaterial.Visibility = Visibility.Hidden;
            buttonUpdateMaterial.Visibility = Visibility.Hidden;
            buttonRemoveMaterial.Visibility = Visibility.Hidden;
            buttonUpdateFile.Visibility = Visibility.Visible;
        }

        //Button, that removes a material from MaterialData
        private void buttonRemoveMaterial_Click(object sender, RoutedEventArgs e)
        {
            callBizz.RemoveFromMaterialData();
            buttonAddMaterial.Visibility = Visibility.Hidden;
            buttonUpdateMaterial.Visibility = Visibility.Hidden;
            buttonRemoveMaterial.Visibility = Visibility.Hidden;
            buttonUpdateFile.Visibility = Visibility.Visible;
        }

        //Button that updates a material from MaterialData
        private void buttonUpdateMaterial_Click(object sender, RoutedEventArgs e)
        {
            callBizz.UpdateMaterial();
            buttonAddMaterial.Visibility = Visibility.Hidden;
            buttonUpdateMaterial.Visibility = Visibility.Hidden;
            buttonRemoveMaterial.Visibility = Visibility.Hidden;
            buttonUpdateFile.Visibility = Visibility.Visible;
        }

        private void buttonUpdateFile_Click(object sender, RoutedEventArgs e)
        {
            callBizz.SaveMaterialData();
            callBizz.ClearMaterialData();
            listMaterialData.SelectedItem = -1;
            textBoxMaterial.Text = "";
            textBoxWeightPerM3.Text = "0";
            buttonUpdateMaterial.Visibility = Visibility.Hidden;
            buttonRemoveMaterial.Visibility = Visibility.Hidden;
            buttonUpdateFile.Visibility = Visibility.Hidden;
            buttonAddMaterial.Visibility = Visibility.Visible;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            callWindow.Show();
        }

    }
}
