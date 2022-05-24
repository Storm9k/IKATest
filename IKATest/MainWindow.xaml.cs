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

        #region Конструктор класса главного окна
        //Инцилизация окна и присвоение объекта DataContext к нашей ViewModel
        public MainWindow()
        {
            InitializeComponent();

            DataContext = ImageViewModel;
        }
        #endregion

        #region Кнопка добавления
        //Добавление изображения в приложение. Добавление в коллекцию и файл с последующим отображением в DataGrid
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
        #endregion

        #region Кнопка удаления
        // Удаление изображения из приложения. Удаление из коллекции и файла
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var item = ImageList.SelectedItem as UserImage;
            ImageViewModel.ImageListRep.RemoveImage(item);
        }
        #endregion
    }
}
