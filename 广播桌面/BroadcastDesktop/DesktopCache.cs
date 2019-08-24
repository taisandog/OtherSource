using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using Buffalo.Win32Kernel.Win32;
using Buffalo.Kernel;
using System.Threading;
using Buffalo.Kernel.Win32;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace BroadcastDesktop
{
    /// <summary>
    /// ���滺��
    /// </summary>
    public class DesktopCache
    {
        private byte[] _msCache = null;
        private Thread _updateThread;
        private bool _isRunning=false;
        private int _sleeptime;
        private bool _isDrawMouse;
        private long _qty=100L;
        ImageCodecInfo _codecInfo = null;
        /// <summary>
        /// ����
        /// </summary>
        public long Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        /// <summary>
        /// ��Ļ���滺��
        /// </summary>
        /// <param name="sleeptime">��ȡʱ����(����)</param>
        /// <param name="isDrawMouse">�Ƿ�������</param>
        public DesktopCache(int sleeptime,bool isDrawMouse) 
        {
            _sleeptime = sleeptime;
            _isDrawMouse = isDrawMouse;
            _codecInfo = Picture.GetEncoder(ImageFormat.Png);
        }

        

        /// <summary>
        /// ��ǰ����
        /// </summary>
        public byte[] CurrentDesktop 
        {
            get 
            {
                return _msCache;
            }
        }

        /// <summary>
        /// ��ʼ����
        /// </summary>
        public void StarUpdate() 
        {
            _isRunning = true;
            _updateThread = new Thread(new ThreadStart(UpdatePrintScreen));
            _updateThread.Start();
        }

        /// <summary>
        /// ˢ����Ļ����
        /// </summary>
        private void UpdatePrintScreen()
        {
            while (_isRunning)
            {
                Image img = WindowsApplication.PrintScreen();
                if (_isDrawMouse) 
                {
                    DrawMousePoint(img);
                }
                if (_qty > 0)
                {
                    _msCache = Picture.PictureToBytes(img, _codecInfo, _qty);
                }
                else 
                {
                    _msCache = Picture.PictureToBytes(img,ImageFormat.Png);
                }
                Thread.Sleep(_sleeptime);
            }
        }

        /// <summary>
        /// ��ʼ����
        /// </summary>
        public void StopUpdate()
        {
            _isRunning = false;
            if (_updateThread != null)
            {
                _updateThread.Abort();
                _updateThread = null;
                Thread.Sleep(100);
            }
        }

        private void DrawMousePoint(Image img) 
        {
            CURSORINFO pci;
            pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
            WindowsAPI.GetCursorInfo(out pci);
            using (Graphics grp = Graphics.FromImage(img)) 
            {
                
                pci.DrawMouseIcon(grp);
            }
        }

    }
}
