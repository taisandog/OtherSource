using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using SharpDX.IO;
using SharpDX.Mathematics.Interop;
using SharpDX.WIC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buffalo.D2DTools
{
    public class PictureScroll:IDisposable
    {
        /// <summary>
        /// 广告集合
        /// </summary>
        private List<SharpDX.Direct2D1.Bitmap> _lstAD;
        /// 效果消耗总时间
        /// </summary>
        private double _effectTime = 2000;
        /// <summary>
        /// 广告大小
        /// </summary>
        private Size _imageSize;
        /// <summary>
        /// 显示广告的控件
        /// </summary>
        private Control _picContainer;


        private SharpDX.Direct2D1.Factory _d2dFactory;
        private WindowRenderTarget _renderTarget;

        private ImagingFactory _imgFactory;
        private FormatConverter _imgConvert;

        private Thread _thdMain;

        private bool _running = false;

        private int _currentIndex = 0;

        private int _nextIndex = 0;

        private DateTime _startDate;

        private int _changeMilliseconds=0;

        /// <summary>
        /// 每帧时间
        /// </summary>
        private double _fpsMilliseconds;

        RawRectangleF _pointImg ;
        /// <summary>
        /// 广告管理器
        /// </summary>
        /// <param name="changeMilliseconds">变更时间（毫秒）</param>
        /// <param name="fps">刷新频率</param>
       /// <param name="effectMilliseconds">特效时间</param>
       /// <param name="bmpSize">图片大小</param>
       /// <param name="picContainer">容器</param>
        public PictureScroll(int changeMilliseconds, int effectMilliseconds, Size bmpSize, Control picContainer, int fps = 24)
        {
            
            if (bmpSize != Size.Empty)
            {
                _imageSize = bmpSize;
            }
            else 
            {
                _imageSize = new Size(800, 400);
            }
            _pointImg = new RawRectangleF(0, 0, _imageSize.Width, _imageSize.Height);
            _picContainer = picContainer;
            _effectTime = effectMilliseconds;
            _changeMilliseconds = changeMilliseconds;

            _fpsMilliseconds = 1000 / fps;

            InitDX();
        }

        /// <summary>
        /// 开始滚动
        /// </summary>
        public void StartAD() 
        {
            _thdMain = new Thread(new ThreadStart(TimeScorll));
            _running = true; ;
            _thdMain.Start();
        }

        private void InitDX() 
        {
            _d2dFactory = new SharpDX.Direct2D1.Factory(FactoryType.MultiThreaded);
            SharpDX.Direct2D1.PixelFormat p = new SharpDX.Direct2D1.PixelFormat(Format.Unknown, SharpDX.Direct2D1.AlphaMode.Premultiplied);
            
            HwndRenderTargetProperties h = new HwndRenderTargetProperties();
            h.Hwnd = _picContainer.Handle;
            h.PixelSize = new Size2(_imageSize.Width, _imageSize.Height);
            h.PresentOptions = SharpDX.Direct2D1.PresentOptions.None;

            RenderTargetProperties r = new RenderTargetProperties(RenderTargetType.Hardware, p, 0, 0, RenderTargetUsage.None, FeatureLevel.Level_DEFAULT);
            _renderTarget = new WindowRenderTarget(_d2dFactory, r, h);
            //_renderTarget.AntialiasMode = AntialiasMode.PerPrimitive;
            _imgFactory = new ImagingFactory();
        }

        private void TimeScorll()
        {
            if (_lstAD == null || _lstAD.Count <= 1) 
            {
                return;
            }
            while (_running)
            {
                
                _nextIndex = (_currentIndex + 1) % _lstAD.Count;
                _startDate = DateTime.Now;
                DoEffect();
                Thread.Sleep(_changeMilliseconds);
            }
        }

        public void LoadImages(IEnumerable<string> paths) 
        {
            _lstAD = new List<SharpDX.Direct2D1.Bitmap>();
            foreach (string path in paths) 
            {
                if (File.Exists(path))
                {
                    _lstAD.Add(LoadBitmap(path, 0));
                }
            }
        }
        /// <summary>
        /// 换帧特效
        /// </summary>
        private void DoEffect()
        {
            while (_running)
            {
                
                double elapsedTime = DateTime.Now.Subtract(_startDate).TotalMilliseconds;
                
                if (elapsedTime >= _effectTime)
                {

                    DrawPicture(_lstAD[_nextIndex], 0, 0, null, 0, 0);
                    _currentIndex = _nextIndex;
                    return;
                }

                DateTime dtBegin = DateTime.Now;

                SharpDX.Direct2D1.Bitmap curImage = _lstAD[_currentIndex];
                SharpDX.Direct2D1.Bitmap nextImage = _lstAD[_nextIndex];
                double curX = -((double)_imageSize.Width * elapsedTime / _effectTime);
                double nextX = (double)_imageSize.Width + curX;
                //DrawPicture(curImage, curX, 0f, null, nextX, 0f);
                DrawPicture(curImage, Convert.ToSingle(curX), 0f, nextImage, Convert.ToSingle(nextX), 0f);
                DateTime dtEnd = DateTime.Now;
                int sleepTime = (int)(_fpsMilliseconds - dtEnd.Subtract(dtBegin).TotalMilliseconds);
                if (sleepTime > 0)
                {
                    Thread.Sleep(sleepTime);
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
        private void DrawPicture(SharpDX.Direct2D1.Bitmap pic1,float x1,float y1,
            SharpDX.Direct2D1.Bitmap pic2,float x2,float y2)
        {
            
            _renderTarget.BeginDraw();
            _renderTarget.Clear(SharpDX.Color.White.ToColor4());
            if (pic1 != null)
            {
                RawRectangleF point1 = new RawRectangleF(x1, y1, _imageSize.Width+x1, _imageSize.Height+y1);
                RawRectangleF pointdes1 = new RawRectangleF(0, 0, _imageSize.Width, _imageSize.Height);
                _renderTarget.DrawBitmap(pic1, point1, 1.0f, SharpDX.Direct2D1.BitmapInterpolationMode.NearestNeighbor, _pointImg);
            }
            if (pic2 != null)
            {
                RawRectangleF point2 = new RawRectangleF(x2, y2, _imageSize.Width + x2, _imageSize.Height+y2);
                RawRectangleF pointdes2 = new RawRectangleF(0, 0, _imageSize.Width, _imageSize.Height);
                _renderTarget.DrawBitmap(pic2, point2, 1.0f, SharpDX.Direct2D1.BitmapInterpolationMode.NearestNeighbor, _pointImg);
            }
            _renderTarget.EndDraw();
        }

        /// <summary>
        /// 加载图片
        /// </summary>
        /// <param name="path"></param>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        public SharpDX.Direct2D1.Bitmap LoadBitmap(string path, int frameIndex)
        {
            _imgConvert = new FormatConverter(_imgFactory);
            BitmapDecoder decoder = new BitmapDecoder(_imgFactory, path, NativeFileAccess.Read, DecodeOptions.CacheOnLoad);
            if (frameIndex > decoder.FrameCount - 1 || frameIndex < 0)
            {
                frameIndex = 0;
            }
            BitmapFrameDecode source = decoder.GetFrame(frameIndex);
            _imgConvert.Initialize(source, SharpDX.WIC.PixelFormat.Format32bppPBGRA);

            return SharpDX.Direct2D1.Bitmap.FromWicBitmap(_renderTarget, _imgConvert);
        }
        /// <summary>
        /// 释放图片
        /// </summary>
        private void DisposeADImage() 
        {
            //释放旧的图片
            if (_lstAD != null)
            {
                foreach (SharpDX.Direct2D1.Image img in _lstAD)
                {
                    try
                    {
                        img.Dispose();
                    }
                    catch { }
                }
            }
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
            DisposeADImage();
            
        }
    }
}
