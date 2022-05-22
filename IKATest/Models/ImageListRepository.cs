using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace IKATest.Models
{
    public class ImageListRepository : IImageRepository<ObservableCollection<UserImage>>
    {

        public ImageListRepository()
        {
            ImageList = LoadImages();
            //ImageList.Concat(LoadImages().Result);
        }

        private ObservableCollection<UserImage> imageList = new ObservableCollection<UserImage>();

        public ObservableCollection<UserImage> ImageList
        {
            get { return imageList; }
            set
            {
                imageList = value;
            }
        }

        public async void SaveImages()
        {
            using FileStream fileStream = File.Create("Images.json");
            var JsonSerializerOptions = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            await JsonSerializer.SerializeAsync(fileStream, ImageList, JsonSerializerOptions);
            await fileStream.DisposeAsync();
            //using (FileStream fs = new FileStream("Images.json", FileMode.OpenOrCreate))
            //{
            //    await JsonSerializer.SerializeAsync(fs, ImageList);
            //}
        }

        public ObservableCollection<UserImage> LoadImages()
        {
            if (File.Exists("Images.json"))
            {

                //using FileStream fileStream = File.OpenRead("Images.json");
                //var JsonSerializerOptions = new JsonSerializerOptions()
                //{
                //    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
                //};
                //return await JsonSerializer.DeserializeAsync<ObservableCollection<UserImage>>(fileStream, JsonSerializerOptions);

                //using (FileStream fs = new FileStream("Images.json", FileMode.OpenOrCreate))
                //{
                //    string ImageJson = fs.Read()
                //    ImageList = JsonSerializer.Deserialize<ObservableCollection<UserImage>>(fs);
                //}

                string ImageJson = File.ReadAllText("Images.json");
                return JsonSerializer.Deserialize<ObservableCollection<UserImage>>(ImageJson);

            }
            else return new ObservableCollection<UserImage>();
        }

        public void AddImage(UserImage image)
        {
            ImageList.Add(image);
            SaveImages();
        }

        public ObservableCollection<UserImage> GetList()
        {
            return ImageList;
        }

        public void RemoveImage(UserImage image)
        {
            ImageList.Remove(image);
            SaveImages();
        }

        

    }
}
