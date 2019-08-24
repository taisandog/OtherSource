using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.IO;
using SharpDX.Mathematics.Interop;
using SharpDX.WIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buffalo.D2DTools
{
    public class GifPlayer:IDisposable
    {
        private int _currentIndex = 0;
        /// <summary>
        /// 显示广告的控件
        /// </summary>
        private Control _picContainer;
        /// <summary>
        /// 每帧时间
        /// </summary>
        private int _fpsMilliseconds;

        private SharpDX.Direct2D1.Factory _d2dFactory;
        private WindowRenderTarget _renderTarget;

        private ImagingFactory _imgFactory;


        private List<SharpDX.Direct2D1.Bitmap> _currentImage;

        private Thread _thdMain;

        private bool _running = false;
        /// <summary>
        /// gif播放器
        /// </summary>
        /// <param name="picContainer"></param>
        /// <param name="fps"></param>
        public GifPlayer(Control picContainer)
        {
            _picContainer = picContainer;
           
            InitDX();
            _thdMain = new Thread(new ThreadStart(TimePlay));
        }
        private void InitDX()
        {
            _d2dFactory = new SharpDX.Direct2D1.Factory(FactoryType.MultiThreaded);
            SharpDX.Direct2D1.PixelFormat p = new SharpDX.Direct2D1.PixelFormat(SharpDX.DXGI.Format.Unknown, SharpDX.Direct2D1.AlphaMode.Premultiplied);

            HwndRenderTargetProperties h = new HwndRenderTargetProperties();
            h.Hwnd = _picContainer.Handle;
            h.PixelSize = new Size2(_picContainer.Width, _picContainer.Height);
            h.PresentOptions = SharpDX.Direct2D1.PresentOptions.None;

            RenderTargetProperties r = new RenderTargetProperties(RenderTargetType.Hardware, p, 0, 0, RenderTargetUsage.None, FeatureLevel.Level_DEFAULT);
            _renderTarget = new WindowRenderTarget(_d2dFactory, r, h);
            _imgFactory = new ImagingFactory();
        }

        public void Play(string gifPath, int fps = 24)
        {
            DisposeImage();
            _fpsMilliseconds = 1000 / fps;
            _currentImage = new List<SharpDX.Direct2D1.Bitmap>();

            BitmapDecoder decoder = new BitmapDecoder(_imgFactory, gifPath, NativeFileAccess.Read, DecodeOptions.CacheOnLoad);
            for (int i = 0; i < decoder.FrameCount; i++)
            {
                using (FormatConverter imgConvert = new FormatConverter(_imgFactory))
                {
                    BitmapFrameDecode source = decoder.GetFrame(i);
                    imgConvert.Initialize(source, SharpDX.WIC.PixelFormat.Format32bppPBGRA);

                    _currentImage.Add(SharpDX.Direct2D1.Bitmap.FromWicBitmap(_renderTarget, imgConvert));
                }
            }
            _running = true;
            _thdMain.Start();
        }
        public void Pause() 
        {
            if (_thdMain.ThreadState == ThreadState.Running)
            {
                _thdMain.Suspend();
            }
        }
        public void Continue() 
        {
            if (_thdMain.ThreadState == ThreadState.Suspended)
            {
                _thdMain.Resume();
            }
        }
        private void TimePlay()
        {
            int curIndex = 0;
            while (_running)
            {
                curIndex=curIndex%_currentImage.Count;
                SharpDX.Direct2D1.Bitmap curImg = _currentImage[curIndex];
                DrawPicture(curImg);
                curIndex++;
                Thread.Sleep(_fpsMilliseconds);
            }
        }
        /// <summary>
        /// 释放图片
        /// </summary>
        private void DisposeImage()
        {
            //释放旧的图片
            if (_currentImage != null)
            {
                foreach (SharpDX.Direct2D1.Image img in _currentImage)
                {
                    try
                    {
                        img.Dispose();
                    }
                    catch { }
                }
            }
        }
        /// <summary>
        /// 绘制图片
        /// </summary>
        /// <param name="pic1"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="pic2"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        private void DrawPicture(SharpDX.Direct2D1.Bitmap pic)
        {

            _renderTarget.BeginDraw();
            _renderTarget.Clear(SharpDX.Color.White.ToColor4());

            RawRectangleF point = new RawRectangleF(0, 0, _picContainer.Width, _picContainer.Height);
                _renderTarget.DrawBitmap(pic, point, 1.0f, SharpDX.Direct2D1.BitmapInterpolationMode.NearestNeighbor);
            
            _renderTarget.EndDraw();
        }

        public void Dispose()
        {
            _running = false;
            try
            {
                _d2dFactory.Dispose();
            }
            catch { }
            try
            {
                _thdMain.Abort();
                Thread.Sleep(100);
            }
            catch { }
            try
            {
                _renderTarget.Dispose();

            }
            catch { }
            
        }
    }
}
