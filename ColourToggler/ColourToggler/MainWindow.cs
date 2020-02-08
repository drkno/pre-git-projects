using System.Drawing;
using System.Windows.Forms;

namespace ColourToggler
{
    public partial class MainWindow : Form
    {
        private readonly Color _firstColour, _secondColour;

        public MainWindow()
        {
            InitializeComponent();
            _firstColour = Color.FromArgb(255, 0, 255);
            _secondColour = Color.FromArgb(0, 255, 0);
            BackColor = _firstColour;
        }

        public override sealed Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        private void MainWindowKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Space) return;
            BackColor = (BackColor == _firstColour) ? _secondColour : _firstColour;
        }
    }
}
