using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace BitmapCutter.Core.API
{
    /// <summary>
    /// Bitmap operations
    /// </summary>
    public class Callback
    {
        /// <summary>
        /// create a new BitmapCutter.Core.API.BitmapOPS instance
        /// </summary>
        public Callback() { }

        /// <summary>
        /// rotate bitmap with any angle
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public string RotateBitmap(string src)
        {
            try
            {
                HttpContext context = HttpContext.Current;
                float angle = float.Parse(context.Request["angle"]);
                Image oldImage = Bitmap.FromFile(src);
                Bitmap newBmp = Helper.RotateImage(oldImage, angle);
                oldImage.Dispose();
                int nw = newBmp.Width;
                int nh = newBmp.Height;
                newBmp.Save(src);
                newBmp.Dispose();
                return "{msg:'success',size:{width:" + nw.ToString() + ",height:" + nh.ToString() + "}}";
            }
            catch (Exception ex)
            {
                return "{msg:'" + ex.Message + "'}";
            }
        }

        public string GenerateBitmap(string src)
        {
            try
            {
                //src = "D:\\项目\\C#Project\\PandoraBox\\Pages\\UploadFile" + src.Substring()
                int len = src.IndexOf("UploadFile");
                string src1 = src.Substring(0, len - 1);
                string src2 = src.Substring(len + 10, src.Length - src1.Length - 11);
                src = src1 + "\\Pages\\UploadFile" + src2;
                FileInfo fi = new FileInfo(src);
                string ext = fi.Extension;

                string newfileName = "portraits/" + Guid.NewGuid().ToString("N") + ".png";

                try
                {
                    if (File.Exists(@"D:\imagename.txt"))
                    {
                        //如果存在则删除
                        File.Delete(@"D:\imagename.txt");
                    }
                }
                catch (Exception ex)
                {

                }
                FileStream fs = new FileStream("D://imagename.txt", FileMode.CreateNew);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(newfileName);
                sw.Close();//写入

                //Image.GetThumbnailImageAbort abort = null;
                Bitmap oldBitmap = new Bitmap(src);
               
                HttpContext context = HttpContext.Current;
                Cutter cut = new Cutter(
                    double.Parse(context.Request["zoom"]),
                    -int.Parse(context.Request["x"]),
                    -int.Parse(context.Request["y"]),
                    int.Parse(context.Request["width"]),
                    int.Parse(context.Request["height"]),
                    oldBitmap.Width,
                    oldBitmap.Height);

                Bitmap bmp = Helper.GenerateBitmap(oldBitmap, cut);
                oldBitmap.Dispose();
                
                string temp = Path.Combine(context.Server.MapPath("~/"), newfileName);
                bmp.Save(temp, ImageFormat.Png);
                bmp.Dispose();
                return "{msg:'success',src:'" + newfileName + "'}";
            }
            catch (Exception ex)
            {
                return "{msg:'" + ex.Message + "'}";
            }
        }
    }
}
