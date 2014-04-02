using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Loamp.ImageRender
{
    public class ImageRender
    {
        public static byte[] CreateGridImage()
        {
            // temp - will get from db values passed in
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("Hackathon.Loamp.ImageRender.image.jpg");

            var image = Image.FromStream(myStream);
  

            var width = 2100;
            var height = 2970;
            using (var bmp = new System.Drawing.Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Bisque);
                    
     
                    Matrix mx = new Matrix();

                    mx.RotateAt(40, new Point(400, 200), MatrixOrder.Append);

                    g.Transform = mx;

                    g.DrawImage(image, new Point(400, 200));

                    g.ResetTransform();

                }

                var memStream = new MemoryStream();
                bmp.Save(memStream, ImageFormat.Jpeg);
                return memStream.ToArray();
            }
        }
    }
}
