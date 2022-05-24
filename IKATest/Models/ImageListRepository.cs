using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace IKATest.Models
{
    public class ImageListRepository : IImageRepository<ObservableCollection<UserImage>>
    {
        #region Constructor
        // В конструкторе происходит загрузка изображений из JSON файла. Async метод реализовать не получилось из-за зависания программы при старте
        
        public ImageListRepository()
        {
            ImageList = LoadImages();
            //ImageList.Concat(LoadImages().Result);
        }
        #endregion

        #region Repository
        //Коллекция хранения данных в приложении
        private ObservableCollection<UserImage> imageList = new ObservableCollection<UserImage>();

        public ObservableCollection<UserImage> ImageList
        {
            get { return imageList; }
            set
            {
                imageList = value;
            }
        }
        #endregion

        #region Сохранение изображений
        //Сохранения изображений в JSON файл асинхронным методом
        public async void SaveImages()
        {
            using FileStream fileStream = File.Create("Images.json");
            var JsonSerializerOptions = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            await JsonSerializer.SerializeAsync(fileStream, ImageList, JsonSerializerOptions);
            await fileStream.DisposeAsync();
        }
        #endregion

        #region Загрузка изображений
        //Загрузка изображений из JSON файла
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

                string ImageJson = File.ReadAllText("Images.json");
                return JsonSerializer.Deserialize<ObservableCollection<UserImage>>(ImageJson);

            }
            else return new ObservableCollection<UserImage>();
        }
        #endregion

        #region Добавление изображения
        //Добавление изображения в коллекцию
        public void AddImage(UserImage image)
        {
            ImageList.Add(image);
            SaveImages();
        }
        #endregion

        #region Удаления изображения
        //Удаления изображения из репозитория
        public void RemoveImage(UserImage image)
        {
            ImageList.Remove(image);
            SaveImages();
        }
        #endregion
    }
}
