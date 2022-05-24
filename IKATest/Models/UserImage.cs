using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Emgu.CV;
using Emgu.CV.Structure;

namespace IKATest.Models
{
    public class UserImage : INotifyPropertyChanged
    {
        #region Конструктор по умолчанию
        //Конструктор по умолчанию для загрузки изображений из JSON файла
        public UserImage() { }
        #endregion

        #region Конструктор с перегрузкой
        //Конструктор с перегрузкой при добавлении изображения через приложение с последующей выгрузкой нужных свойств из него
        public UserImage(string filePath){
            FilePath = filePath;
            Image<Rgb, byte> CVimage = new Image<Rgb, byte>($"{filePath}");

            System.Drawing.Point[] minLocation;
            System.Drawing.Point[] maxLocation;
            CVimage.MinMax(out minValues, out maxValues, out minLocation, out maxLocation);
            RGB = CVimage.GetAverage();

            MinR = Convert.ToByte(minValues[0]);
            MinG = Convert.ToByte(minValues[1]);
            MinB = Convert.ToByte(minValues[2]);
            minRGB = Convert.ToByte(minValues.Min());

            MaxR = Convert.ToByte(maxValues[0]);
            MaxG = Convert.ToByte(maxValues[1]);
            MaxB = Convert.ToByte(maxValues[2]);
            MaxRGB = Convert.ToByte(maxValues.Max());

            AvgR = Convert.ToByte(RGB.Red);
            AvgG = Convert.ToByte(RGB.Green);
            AvgB = Convert.ToByte(RGB.Blue);
            AvgRGB = Convert.ToByte((RGB.Red + RGB.Green + RGB.Blue) / 3);
        }
        #endregion

        private string filePath;
        private string imageName;
        private double[] minValues, maxValues;
        private Rgb RGB;

        private byte minR, minG, minB, minRGB, maxR, maxG, maxB, maxRGB, avgR, avgG, avgB, avgRGB;

        #region Свойства
        //Публичные свойства изображения с привязкой к обработчику интерфейса INotifyPropertyChanged для отображения данных в окне формы
        public string FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                OnPropertyChanged("FilePath");
            }
        }
        public string ImageName
        {
            get { return imageName; }
            set
            {
                imageName = value;
                OnPropertyChanged("ImageName");
            }
        }

        public byte MinR
        {
            get { return minR; }
            set
            {
                minR = value;
                OnPropertyChanged("MinR");
            }
        }

        public byte MaxR
        {
            get { return maxR; }
            set
            {
                maxR = value;
                OnPropertyChanged("MaxR");
            }
        }

        public byte AvgR
        {
            get { return avgR; }
            set
            {
                avgR = value;
                OnPropertyChanged("AvgR");
            }
        }

        public byte MinG
        {
            get { return minG; }
            set
            {
                minG = value;
                OnPropertyChanged("MinG");
            }
        }

        public byte MaxG
        {
            get { return maxG; }
            set
            {
                maxG = value;
                OnPropertyChanged("MaxG");
            }
        }

        public byte AvgG
        {
            get { return avgG; }
            set
            {
                avgG = value;
                OnPropertyChanged("AvgG");
            }
        }

        public byte MinB
        {
            get { return minB; }
            set
            {
                minB = value;
                OnPropertyChanged("MinB");
            }
        }

        public byte MaxB
        {
            get { return maxB; }
            set
            {
                maxB = value;
                OnPropertyChanged("MaxB");
            }
        }

        public byte AvgB
        {
            get { return avgB; }
            set
            {
                avgB = value;
                OnPropertyChanged("AvgB");
            }
        }

        public byte MinRGB
        {
            get { return minRGB; }
            set
            {
                minRGB = value;
                OnPropertyChanged("MinRGB");
            }
        }

        public byte MaxRGB
        {
            get { return maxRGB; }
            set
            {
                maxRGB = value;
                OnPropertyChanged("MaxRGB");
            }
        }

        public byte AvgRGB
        {
            get { return avgRGB; }
            set
            {
                avgRGB = value;
                OnPropertyChanged("AvgRGB");
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
