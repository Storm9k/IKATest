namespace IKATest.Models
{
    //Интерфейс репозитория для гибкого изменения сбора, храния и чтения массива изображений
    public interface IImageRepository<T>
    {
        public void SaveImages();
        public T LoadImages();

        public void AddImage(UserImage image);
        public void RemoveImage(UserImage name);
    }
}
