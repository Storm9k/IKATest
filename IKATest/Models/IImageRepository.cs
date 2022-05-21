using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IKATest.Models
{
    public interface IImageRepository<T>
    {
        public void SaveImages();
        public T LoadImages();

        public void AddImage(UserImage image);
        public void RemoveImage(UserImage name);
    }
}
