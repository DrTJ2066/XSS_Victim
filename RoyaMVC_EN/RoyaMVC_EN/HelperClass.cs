using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace RoyaMVC_EN
{
    public static class HelperClass
    {
        public static List<string> SplitBigString(string HugeContent, int fragmentsLength) {
            var res = new List<string>();



            var hugeLen = HugeContent.Length;
            var tmpContent = HugeContent;

            var fragmentsCount = ((double)hugeLen) / ((double)fragmentsLength);

            if (fragmentsCount > (int)fragmentsCount) {
                fragmentsCount = (int)fragmentsCount;
                fragmentsCount++;
            }

            for (int step = 0; step < fragmentsCount; step++) {
                var tmp = tmpContent.Substring(0, Math.Min(fragmentsLength, tmpContent.Length));
                tmpContent = tmpContent.Substring(tmp.Length);

                res.Add(tmp);
            }

            return res;
        }

        public static List<byte[]> SplitBigBytes(byte[] HugeContent, int fragmentsLength) {
            var res = new List<byte[]>();

            var hugeLen = HugeContent.Length;
            var tmpContent = HugeContent.ToList();

            var fragmentsCount = ((double)hugeLen) / ((double)fragmentsLength);

            if (fragmentsCount > (int)fragmentsCount) {
                fragmentsCount = (int)fragmentsCount;
                fragmentsCount++;
            }

            for (int step = 0; step < fragmentsCount; step++) {
                var tmp = tmpContent.Take(Math.Min(fragmentsLength, tmpContent.Count)).ToArray();
                tmpContent.RemoveRange(0, tmp.Count());

                res.Add(tmp);
            }

            return res;
        }


        public static string RemoveHTMLTags(string htmlContent) {
            var res = "";

            if (string.IsNullOrWhiteSpace(htmlContent) == false) {
                string noHTML = Regex.Replace(htmlContent, @"<[^>]+>|&nbsp;", "").Trim();
                res = Regex.Replace(noHTML, @"\s{2,}", " ");
            }
            return res;
        }



        //public static byte[] GetResizedImageBytes(Func<byte[]> GetImageBytesFromDB, string getResourcesPath, int width, int height, ImageFormat format, string desiredFileName) {
        //    byte[] res ;

        //    var tmpFileName = desiredFileName + format.ToString();
        //    var tmpFullPath = getResourcesPath + "\\"+ tmpFileName;

        //    if (File.Exists(tmpFullPath))
        //        res = File.ReadAllBytes(tmpFullPath);
        //    else {
        //        var dbBytes = GetImageBytesFromDB();

        //    }

        //    return res;
        //}

        public static byte[] ResizeImageBytes(byte[] imageBytes, int width, int height, ImageFormat format) {
            using (var mem = new MemoryStream(imageBytes)) {
                using (var memOut = new MemoryStream()) {
                    using (var tmpBit = Bitmap.FromStream(mem)) {
                        var bitOut = ResizeImage(tmpBit, width, height);
                        bitOut.Save(memOut, format);
                    }

                    var resBytes = memOut.ToArray();
                    return resBytes;
                }
            }
        }

        public static Bitmap ResizeImage(Image inputImage, int width, int height) {
            return ResizeImage(inputImage, width, height, ImageQuality.Low);
        }

        public static Bitmap ResizeImage(Image inputImage, int width, int height, ImageQuality quality) {
            var outputImage = new Bitmap(width, height);
            using (var gr = Graphics.FromImage(outputImage)) {
                switch (quality) {
                    case ImageQuality.Low:
                        gr.CompositingQuality = CompositingQuality.HighSpeed;
                        gr.SmoothingMode = SmoothingMode.HighSpeed;
                        gr.InterpolationMode = InterpolationMode.Low;
                        break;

                    case ImageQuality.High:
                        gr.CompositingQuality = CompositingQuality.HighQuality;
                        gr.SmoothingMode = SmoothingMode.HighQuality;
                        gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        break;
                }

                gr.DrawImage(inputImage, 0, 0, width, height);
            }

            return outputImage;
        }





        public static string GetSubString(this string inputString, int maxLength, bool show3Dots) {
            if (inputString.Length < maxLength)
                return inputString;

            if (show3Dots)
                return inputString.Substring(0, maxLength - 3) + "...";
            else
                return inputString.Substring(0, maxLength);
        }

    }
}
