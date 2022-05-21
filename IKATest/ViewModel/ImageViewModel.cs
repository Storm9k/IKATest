using IKATest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace IKATest.ViewModel
{
    public class ImageViewModel : INotifyPropertyChanged
    {
        public ImageViewModel()
        {
            Images = ImageListRep.ImageList;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ImageListRepository ImageListRep = new ImageListRepository();

        public ObservableCollection<UserImage> Images { get; set; }

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

        

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
