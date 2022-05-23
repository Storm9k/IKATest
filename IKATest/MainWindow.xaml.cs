using IKATest.Models;
using IKATest.ViewModel;
using Microsoft.Win32;
using System.Windows;

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
