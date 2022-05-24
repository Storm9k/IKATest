using IKATest.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IKATest.ViewModel
{
    public class ImageViewModel : INotifyPropertyChanged
    {
        #region Конструктор ViewModel
        //Получение ссылки на объект репозитория в конструкторе по умолчанию
        public ImageViewModel()
        {
            Images = ImageListRep.ImageList;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public ImageListRepository ImageListRep = new ImageListRepository();

        public ObservableCollection<UserImage> Images { get; set; }

        #region Выбранное изображение
        //Переменная и свойство выбранного избражения в главном окне приложения 
        private UserImage selectedImage;
        public UserImage SelectedImage
        {
            get { return selectedImage; }
            set
            {
                selectedImage = value;
                OnPropertyChanged("SelectedImage");
            }
        }
        #endregion

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
