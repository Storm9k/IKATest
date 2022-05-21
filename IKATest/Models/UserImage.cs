using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace IKATest.Models
{
    public class UserImage : INotifyPropertyChanged
    {

        public UserImage() { }

        public UserImage(string filePath){
            FilePath = filePath;
            Image<Rgb, byte> CVimage = new Image<Rgb, byte>($"{filePath}");

            System.Drawing.Point[] minLocation;
            System.Drawing.Point[] maxLocation;
            CVimage.MinMax(out minValues, out maxValues, out minLocation, out maxLocation);
            RGB = CVimage.GetAverage();

            MinR = minValues[0];
            MinG = minValues[1];
            MinB = minValues[2];
            minRGB = minValues.Min();

            MaxR = maxValues[0];
            MaxG = maxValues[1];
            MaxB = maxValues[2];
            MaxRGB = maxValues.Max();

            AvgR = RGB.Red;
            AvgG = RGB.Green;
            AvgB = RGB.Blue;
            AvgRGB = (RGB.Red + RGB.Green + RGB.Blue) / 3;


        }

        private string filePath;
        private string imageName;
        private double[] minValues, maxValues;
        private Rgb RGB;

        private double minR, minG, minB, minRGB, maxR, maxG, maxB, maxRGB, avgR, avgG, avgB, avgRGB;

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

        //public double[] MinValues
        //{
        //    get { return minValues; }
        //    set
        //    {
        //        minValues = value;
        //        OnPropertyChanged("MinValues");
        //    }
        //}

        //public double[] MaxValues
        //{
        //    get { return maxValues; }
        //    set
        //    {
        //        maxValues = value;
        //        OnPropertyChanged("MaxValues");
        //    }
        //}

        //public Rgb AvgRGB
        //{
        //    get { return avgRGB; }
        //    set
        //    {
        //        avgRGB = value;
        //        OnPropertyChanged("MinValues");
        //    }
        //}

        public double MinR
        {
            get { return minR; }
            set
            {
                minR = value;
                OnPropertyChanged("MinR");
            }
        }

        public double MaxR
        {
            get { return maxR; }
            set
            {
                maxR = value;
                OnPropertyChanged("MaxR");
            }
        }

        public double AvgR
        {
            get { return avgR; }
            set
            {
                avgR = value;
                OnPropertyChanged("AvgR");
            }
        }

        public double MinG
        {
            get { return minG; }
            set
            {
                minG = value;
                OnPropertyChanged("MinG");
            }
        }

        public double MaxG
        {
            get { return maxG; }
            set
            {
                maxG = value;
                OnPropertyChanged("MaxG");
            }
        }

        public double AvgG
        {
            get { return avgG; }
            set
            {
                avgG = value;
                OnPropertyChanged("AvgG");
            }
        }

        public double MinB
        {
            get { return minB; }
            set
            {
                minB = value;
                OnPropertyChanged("MinB");
            }
        }

        public double MaxB
        {
            get { return maxB; }
            set
            {
                maxB = value;
                OnPropertyChanged("MaxB");
            }
        }

        public double AvgB
        {
            get { return avgB; }
            set
            {
                avgB = value;
                OnPropertyChanged("AvgB");
            }
        }

        public double MinRGB
        {
            get { return minRGB; }
            set
            {
                minRGB = value;
                OnPropertyChanged("MinRGB");
            }
        }

        public double MaxRGB
        {
            get { return maxRGB; }
            set
            {
                maxRGB = value;
                OnPropertyChanged("MaxRGB");
            }
        }

        public double AvgRGB
        {
            get { return avgRGB; }
            set
            {
                avgRGB = value;
                OnPropertyChanged("AvgRGB");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
