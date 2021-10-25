using System;
using System.IO;
using System.Windows.Media.Imaging;
using ExifLib;

namespace ConsoleAppTesteDLLimg
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\User\Desktop\logo\20211020_174400_Film1.jpg";
            String make, model;
            DateTime datetime;
            double[] lt, lg;
            double degrees, minutes, seconds, lat_dd, long_dd;

            ExifReader reader = new ExifReader(sourcePath);
            if (reader.GetTagValue<String>(ExifTags.Make, out make))
                Console.WriteLine(make.ToString());

            if (reader.GetTagValue<String>(ExifTags.Model, out model))
                Console.WriteLine(model.ToString());

            if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out datetime))
                Console.WriteLine(datetime.ToString());
            if (reader.GetTagValue<double[]>(ExifTags.GPSLatitude, out lt))//latitude
            {
                degrees = lt[0];
                minutes = lt[1];
                seconds = lt[2];
                lat_dd = degrees + (minutes / 60) + (seconds / 3600);
                Console.WriteLine("lat: " + lat_dd);
            }
            if (reader.GetTagValue<double[]>(ExifTags.GPSLongitude, out lg))//longitude
            {
                degrees = lg[0];
                minutes = lg[1];
                seconds = lg[2];
                long_dd = degrees + (minutes / 60) + (seconds / 3600);
                Console.WriteLine("lon: " + long_dd);
            }

        }
    }
}
