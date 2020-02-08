using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using DirectShowLib;

namespace DirectShow
{
    public partial class Form1 : Form
    {
        public const int WmGraphnotify = 0x8000 + 1;
        private ICaptureGraphBuilder2 _captureGraphBuilder;
        private PlayState _currentState = PlayState.Stopped;
        private IGraphBuilder _graphBuilder;
        private IMediaControl _mediaControl;
        private IMediaEventEx _mediaEventEx;
        private DsROTEntry _rot;
        private IVideoWindow _videoWindow;

        public Form1()
        {
            InitializeComponent();
            CaptureVideo();
        }

        public void CaptureVideo()
        {
            try
            {
                GetInterfaces();

                // Attach the filter graph to the capture graph
                var hr = _captureGraphBuilder.SetFiltergraph(_graphBuilder);
                DsError.ThrowExceptionForHR(hr);

                // Use the system device enumerator and class enumerator to find
                // a video capture/preview device, such as a desktop USB video camera.
                var sourceFilter = FindCaptureDevice();

                // Add Capture filter to our graph.
                hr = _graphBuilder.AddFilter(sourceFilter, "");
                DsError.ThrowExceptionForHR(hr);

                // Render the preview pin on the video capture filter
                // Use this instead of this.graphBuilder.RenderFile
                hr = _captureGraphBuilder.RenderStream(PinCategory.Preview, MediaType.Video, sourceFilter, null, null);
                DsError.ThrowExceptionForHR(hr);

                // Now that the filter has been added to the graph and we have
                // rendered its stream, we can release this reference to the filter.
                Marshal.ReleaseComObject(sourceFilter);

                // Set video window style and position
                SetupVideoWindow();

                // Add our graph to the running object table, which will allow
                // the GraphEdit application to "spy" on our graph
                _rot = new DsROTEntry(_graphBuilder);

                // Start previewing video data
                hr = _mediaControl.Run();
                DsError.ThrowExceptionForHR(hr);

                // Remember current state
                _currentState = PlayState.Running;
            }
            catch
            {
                MessageBox.Show("An unrecoverable error has occurred.");
            }
        }

        // This version of FindCaptureDevice is provide for education only.
        // A second version using the DsDevice helper class is define later.
        public IBaseFilter FindCaptureDevice()
        {
            IEnumMoniker classEnum;
            var moniker = new IMoniker[1];

            object source;

            // Create the system device enumerator
            var devEnum = (ICreateDevEnum)new CreateDevEnum();

            // Create an enumerator for the video capture devices
            var hr = devEnum.CreateClassEnumerator(FilterCategory.VideoInputDevice, out classEnum, 0);
            DsError.ThrowExceptionForHR(hr);

            // The device enumerator is no more needed
            Marshal.ReleaseComObject(devEnum);

            // If there are no enumerators for the requested type, then 
            // CreateClassEnumerator will succeed, but classEnum will be NULL.
            if (classEnum == null)
            {
                throw new ApplicationException("No video capture device was detected.\r\n\r\n" +
                                               "This sample requires a video capture device, such as a USB WebCam,\r\n" +
                                               "to be installed and working properly.  The sample will now close.");
            }

            // Use the first video capture device on the device list.
            // Note that if the Next() call succeeds but there are no monikers,
            // it will return 1 (S_FALSE) (which is not a failure).  Therefore, we
            // check that the return code is 0 (S_OK).

            if (classEnum.Next(moniker.Length, moniker, IntPtr.Zero) == 0)
            {
                // Bind Moniker to a filter object
                var iid = typeof(IBaseFilter).GUID;
                moniker[0].BindToObject(null, null, ref iid, out source);
            }
            else
            {
                throw new ApplicationException("Unable to access video capture device!");
            }

            // Release COM objects
            Marshal.ReleaseComObject(moniker[0]);
            Marshal.ReleaseComObject(classEnum);

            // An exception is thrown if cast fail
            return (IBaseFilter)source;
        }

        public void GetInterfaces()
        {
            // An exception is thrown if cast fail
            _graphBuilder = (IGraphBuilder)new FilterGraph();
            _captureGraphBuilder = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
            _mediaControl = (IMediaControl)_graphBuilder;
            _videoWindow = (IVideoWindow)_graphBuilder;
            _mediaEventEx = (IMediaEventEx)_graphBuilder;

            var hr = _mediaEventEx.SetNotifyWindow(Handle, WmGraphnotify, IntPtr.Zero);
            DsError.ThrowExceptionForHR(hr);
        }

        public void CloseInterfaces()
        {
            // Stop previewing data
            if (_mediaControl != null)
                _mediaControl.StopWhenReady();

            _currentState = PlayState.Stopped;

            // Stop receiving events
            if (_mediaEventEx != null)
                _mediaEventEx.SetNotifyWindow(IntPtr.Zero, WmGraphnotify, IntPtr.Zero);

            // Relinquish ownership (IMPORTANT!) of the video window.
            // Failing to call put_Owner can lead to assert failures within
            // the video renderer, as it still assumes that it has a valid
            // parent window.
            if (_videoWindow != null)
            {
                _videoWindow.put_Visible(OABool.False);
                _videoWindow.put_Owner(IntPtr.Zero);
            }

            // Remove filter graph from the running object table
            if (_rot != null)
            {
                _rot.Dispose();
                _rot = null;
            }

            // Release DirectShow interfaces
            if (_mediaControl != null) Marshal.ReleaseComObject(_mediaControl);
            _mediaControl = null;
            if (_mediaEventEx != null) Marshal.ReleaseComObject(_mediaEventEx);
            _mediaEventEx = null;
            if (_videoWindow != null) Marshal.ReleaseComObject(_videoWindow);
            _videoWindow = null;
            Marshal.ReleaseComObject(_graphBuilder);
            _graphBuilder = null;
            Marshal.ReleaseComObject(_captureGraphBuilder);
            _captureGraphBuilder = null;
        }

        public void SetupVideoWindow()
        {
            // Set the video window to be a child of the main window
            var hr = _videoWindow.put_Owner(Handle);
            DsError.ThrowExceptionForHR(hr);

            hr = _videoWindow.put_WindowStyle(WindowStyle.Child | WindowStyle.ClipChildren);
            DsError.ThrowExceptionForHR(hr);

            // Use helper function to position video window in client rect 
            // of main application window
            ResizeVideoWindow();

            // Make the video window visible, now that it is properly positioned
            hr = _videoWindow.put_Visible(OABool.True);
            DsError.ThrowExceptionForHR(hr);
        }

        public void ResizeVideoWindow()
        {
            // Resize the video preview window to match owner window size
            if (_videoWindow != null)
            {
                _videoWindow.SetWindowPosition(0, 0, ClientSize.Width, ClientSize.Height);
            }
        }

        public void ChangePreviewState(bool showVideo)
        {
            // If the media control interface isn't ready, don't call it
            if (_mediaControl == null)
                return;

            if (showVideo)
            {
                if (_currentState != PlayState.Running)
                {
                    // Start previewing video data
                    _mediaControl.Run();
                    _currentState = PlayState.Running;
                }
            }
            else
            {
                // Stop previewing video data
                _mediaControl.StopWhenReady();
                _currentState = PlayState.Stopped;
            }
        }

        public void HandleGraphEvent()
        {
            EventCode evCode;
            IntPtr evParam1, evParam2;

            if (_mediaEventEx == null)
                return;

            while (_mediaEventEx.GetEvent(out evCode, out evParam1, out evParam2, 0) == 0)
            {
                // Free event parameters to prevent memory leaks associated with
                // event parameter data.  While this application is not interested
                // in the received events, applications should always process them.
                var hr = _mediaEventEx.FreeEventParams(evCode, evParam1, evParam2);
                DsError.ThrowExceptionForHR(hr);

                // Insert event processing code here, if desired
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WmGraphnotify:
                    {
                        HandleGraphEvent();
                        break;
                    }
            }

            // Pass this message to the video window for notification of system changes
            if (_videoWindow != null)
                _videoWindow.NotifyOwnerMessage(m.HWnd, m.Msg, m.WParam, m.LParam);

            base.WndProc(ref m);
        }

        private void Form1Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ChangePreviewState(false);
            }

            if (WindowState == FormWindowState.Normal)
            {
                ChangePreviewState(true);
            }
                

            ResizeVideoWindow();
        }

        private enum PlayState
        {
            Stopped,
            Running
        };
    }
}
