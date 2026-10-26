using System.Drawing;
using System.IO;

namespace HotelManagement
{
    internal static class ResourceHelper
    {
        public static Image ToImage(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            using (var img = Image.FromStream(ms))
            {
               
                return new Bitmap(img);
            }
        }
    }
}