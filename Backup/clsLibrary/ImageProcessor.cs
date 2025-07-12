using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace clsLibrary
{
    public class ImageProcessor
    {
        public Bitmap Resize(Bitmap image, int newWidth, int newHeight, string message)
        {
            try
            {
                Bitmap newImage = new Bitmap(newWidth, Calculations(image.Width, image.Height, newWidth));

                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(image, new Rectangle(0, 0, newImage.Width, newImage.Height));

                    //SolidBrush myBrush = new SolidBrush(Color.FromArgb(70, 205, 205, 205));
                    SolidBrush myBrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
                    SolidBrush myBrush2 = new SolidBrush(Color.FromArgb(255, 0, 0, 0));

                    Rectangle containerBox = new Rectangle();
                    Rectangle containerBox2 = new Rectangle();

                    Font stringFont = new Font("verdana", 15);

                    containerBox.X = 5;
                    containerBox.Y = 5;

                    containerBox2.X = 5;
                    containerBox2.Y = containerBox.Y + stringFont.Height;



                    StringFormat sf = new StringFormat();

                    //gr.RotateTransform(slope);
                    gr.DrawString(message, stringFont, myBrush, containerBox, sf);
                    gr.DrawString(message, stringFont, myBrush2, containerBox2, sf);



                    return newImage;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public int Calculations(decimal w1, decimal h1, int newWidth)
        {
            decimal height = 0;
            decimal ratio = 0;


            if (newWidth < w1)
            {
                ratio = w1 / newWidth;
                height = h1 / ratio;

                return (int)height;
            }

            if (w1 < newWidth)
            {
                ratio = newWidth / w1;
                height = h1 * ratio;

                return (int)height;
            }

            return (int)height;
        }
    }
}
