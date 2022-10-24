using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;


namespace WordFilter
{
    public class BlindWaterMarkUnit
    {


       

        /// <summary>
        /// 插入盲水印
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="watermarkText"></param>
        /// <returns></returns>
        public static Mat AddImageWatermarkWithText(string imagePath, string watermarkText)
        {
            HersheyFonts font = HersheyFonts.HersheySimplex;
            double fontScale = 8D;
            Scalar color = new Scalar(255, 255, 256);
            int thickness = 10;
            LineTypes lineTypes = LineTypes.AntiAlias;

            List<Mat> planes = new List<Mat>();
            List<Mat> allPlanes = new List<Mat>();
            Mat complexImage = Cv2.ImRead(imagePath);
            Mat padded = SplitSrc(complexImage, allPlanes);
            padded.ConvertTo(padded, MatType.CV_32F);
            planes.Add(padded);
            planes.Add(Mat.Zeros(padded.Size(), MatType.CV_32F));
            Cv2.Merge(planes.ToArray(), complexImage);
            // dft
            Cv2.Dft(complexImage, complexImage);
            // 添加文本水印
            
            

            Size size= Cv2.GetTextSize(watermarkText, font, fontScale, thickness, out _);
            OpenCvSharp.Point point = new OpenCvSharp.Point(5, size.Height+5);
            Cv2.PutText(complexImage, watermarkText, point, font, fontScale, color, thickness, lineTypes);
            Cv2.Flip(complexImage, complexImage, FlipMode.XY);
            Cv2.PutText(complexImage, watermarkText, point, font, fontScale, color, thickness, lineTypes);
            Cv2.Flip(complexImage, complexImage, FlipMode.XY);

            return AntitransformImage(complexImage, allPlanes);
        }

        private static Mat SplitSrc(Mat mat, List<Mat> allPlanes)
        {
            mat = optimizeImageDim(mat);
            Cv2.Split(mat, out Mat[] mv);
            allPlanes.AddRange(mv);

            Mat padded = new Mat();
            if (allPlanes.Count() > 1)
            {
                for (int i = 0; i < allPlanes.Count(); i++)
                {
                    if (i == 0)
                    {
                        padded = allPlanes[i];
                        break;
                    }
                }
            }
            else
            {
                padded = mat;
            }

            return padded;
        }

        private static Mat optimizeImageDim(Mat image)
        {
            Mat padded = new Mat();
            int addPixelRows = Cv2.GetOptimalDFTSize(image.Rows);
            int addPixelCols = Cv2.GetOptimalDFTSize(image.Cols);
            Cv2.CopyMakeBorder(image, padded, 0, addPixelRows - image.Rows, 0, addPixelCols - image.Cols, BorderTypes.Constant, Scalar.All(0));

            return padded;
        }

        private static Mat AntitransformImage(Mat complexImage, List<Mat> allPlanes)
        {
            Mat invDFT = new Mat();
            Cv2.Idft(complexImage, invDFT, DftFlags.Scale | DftFlags.RealOutput, 0);
            Mat restoredImage = new Mat();
            invDFT.ConvertTo(restoredImage, MatType.CV_8U);
            if (allPlanes.Count == 0)
            {
                allPlanes.Add(restoredImage);
            }
            else
            {
                allPlanes[0] = restoredImage;
            }
            Mat lastImage = new Mat(new OpenCvSharp.Size(complexImage.Width, complexImage.Height), MatType.CV_8U);
            Cv2.Merge(allPlanes.ToArray(), lastImage);
            return lastImage;
        }

        public static Mat GetImageWatermarkWithText(Mat image)
        {
            List<Mat> allPlanes = new List<Mat>();
            List<Mat> planes = new List<Mat>();
            Mat complexImage = new Mat();
            Mat padded = SplitSrc(image, allPlanes);
            padded.ConvertTo(padded, MatType.CV_32F);
            planes.Add(padded);
            planes.Add(Mat.Zeros(padded.Size(), MatType.CV_32F));
            Cv2.Merge(planes.ToArray(), complexImage);
            // dft
            Cv2.Dft(complexImage, complexImage);
            Mat magnitude = createOptimizedMagnitude(complexImage);
            planes.Clear();
            return magnitude;
        }

        private static Mat createOptimizedMagnitude(Mat complexImage)
        {
            List<Mat> newPlanes = new List<Mat>();
            Mat mag = new Mat();
            Cv2.Split(complexImage, out Mat[] mv);
            newPlanes.AddRange(mv);
            Cv2.Magnitude(newPlanes[0], newPlanes[1], mag);
            Cv2.Add(Mat.Ones(mag.Size(), MatType.CV_32F), mag, mag);
            Cv2.Log(mag, mag);
            ShiftDFT(mag);
            mag.ConvertTo(mag, MatType.CV_8UC1);
            Cv2.Normalize(mag, mag, 0, 255, NormTypes.MinMax, MatType.CV_8UC1);
            return mag;
        }

        private static void ShiftDFT(Mat image)
        {
            image = image.SubMat(new Rect(0, 0, image.Cols & -2, image.Rows & -2));
            int cx = image.Cols / 2;
            int cy = image.Rows / 2;

            Mat q0 = new Mat(image, new Rect(0, 0, cx, cy));
            Mat q1 = new Mat(image, new Rect(cx, 0, cx, cy));
            Mat q2 = new Mat(image, new Rect(0, cy, cx, cy));
            Mat q3 = new Mat(image, new Rect(cx, cy, cx, cy));
            Mat tmp = new Mat();
            q0.CopyTo(tmp);
            q3.CopyTo(q0);
            tmp.CopyTo(q3);
            q1.CopyTo(tmp);
            q2.CopyTo(q1);
            tmp.CopyTo(q2);
        }

        /// <summary>
        /// 输出水印
        /// </summary>
        /// <param name="file"></param>
        /// <param name="outWatermark"></param>
        public static void OutputWatermark(string filePath,string outWatermark) 
        {
            Mat image = Cv2.ImRead(filePath);
            Mat watermarkImg = GetImageWatermarkWithText(image);
            Cv2.ImWrite(outWatermark, watermarkImg);

        }
        /// <summary>
        /// 写入水印
        /// </summary>
        /// <param name="filePath">源文件</param>
        /// <param name="outFile">输出文件</param>
        /// <param name="watermark">水印文字</param>
        public static void WriteWatermark(string filePath, string outFile,string watermark,List<ImageEncodingParam> imageEncodingParams=null)
        {
            Mat outImg = AddImageWatermarkWithText(filePath, watermark);
            if (imageEncodingParams == null)
            {
                imageEncodingParams = new List<ImageEncodingParam>();

                if (watermark.EndsWith(".jpg") || watermark.EndsWith(".jpeg"))
                {
                    imageEncodingParams.Add(new ImageEncodingParam(ImwriteFlags.JpegQuality, 95));
                }
                else if(watermark.EndsWith(".png") ) 
                {
                    imageEncodingParams.Add(new ImageEncodingParam(ImwriteFlags.PngCompression, 0));
                }
                else if (watermark.EndsWith(".tiff"))
                {
                    imageEncodingParams.Add(new ImageEncodingParam(ImwriteFlags.TiffCompression, 0));
                }
            }
            Cv2.ImWrite(outFile, outImg, imageEncodingParams.ToArray());

        }
        private static string _baseRoot = null;//基目录
        /// <summary>
        /// 获取基路径
        /// </summary>
        /// <param name="configRoot"></param>
        /// <returns></returns>
        public static string GetBaseRoot(string configRoot)
        {

            if (_baseRoot == null)
            {
               
                    _baseRoot = AppDomain.CurrentDomain.BaseDirectory;
                
               
            }
            if (Path.IsPathRooted(configRoot))
            {
                return configRoot;
            }
            string retRoot = Path.Combine(_baseRoot, configRoot);
            return retRoot;
        }
    }
}
