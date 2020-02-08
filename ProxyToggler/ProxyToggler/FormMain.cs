using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ProxyToggler
{
    public partial class FormMain : Form
    {
        private readonly Thread _updateThread;
        private bool _init = true;
        private bool _cont = true;
        private int _timeoutWait;
        private const int Timeout = 5000;
        private const int Steps = 100;

        private void IncreaseProgress(int v)
        {
            try
            {
                v = v > progressBar.Maximum ? progressBar.Maximum : v;
                Invoke(new MethodInvoker(() => progressBar.Value = v));

            }
            catch (Exception)
            {
                Debug.WriteLine("Error increasing progress.");
            }
        }

        private int ProgressValue()
        {
            return progressBar.Value;
        }

        public FormMain()
        {
            InitializeComponent();
            _updateThread = new Thread(UpdateProgress);
        }

        private void UpdateProgress()
        {
            int countValue = 0;
            while (_cont && ProgressValue() < progressBar.Maximum)
            {
                IncreaseProgress(countValue);
                Thread.Sleep(_timeoutWait);
                countValue++;
            }

            if (_cont)
            {
                Proxy.CurrentProxyState = !Proxy.CurrentProxyState;
            }

            Environment.Exit(0);
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            _cont = false;
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            if (!_init) return;
            labelStatus.Text = Proxy.CurrentProxyState ? "OFF" : "ON";
            labelStatus.ForeColor = Proxy.CurrentProxyState ? Color.Red : Color.Green;
            _timeoutWait = Timeout/Steps;
            progressBar.Step = progressBar.Maximum / Steps;
            _init = false;
            _updateThread.Start();
        }

    }
}
