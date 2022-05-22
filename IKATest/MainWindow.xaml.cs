using Emgu.CV;
using Emgu.CV.Structure;
using IKATest.Models;
using IKATest.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace IKATest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageViewModel ImageViewModel = new ImageViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = ImageViewModel;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                UserImage userImage = new UserImage(openFileDialog.FileName) { ImageName = openFileDialog.SafeFileName };
                ImageViewModel.ImageListRep.AddImage(userImage);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var item = ImageList.SelectedItem as UserImage;
            ImageViewModel.ImageListRep.RemoveImage(item);
        }
    }
}
