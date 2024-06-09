using byte_assistant_app.util;

namespace byte_assistant_app;

public partial class GenericTrayIcon : Form
{
        private NotifyIcon _notifyIcon;
        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _exitToolStripMenuItem;
        private ToolStripMenuItem _openToolStripMenuItem;

        public GenericTrayIcon()
        {
            InitializeComponent();
            InitializeTrayIcon();
            
            //SystemFunctions.setAutoStart();

            Load += (s, e) => {
                Hide();
                ShowInTaskbar = false;
            };
            
            ApplyStyles();
        }
        
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == Constans.WM_NCHITTEST && (int)m.Result == Constans.HT_CAPTION)
            {
                m.Result = (IntPtr)0x2; 
            }
        }

        private void InitializeTrayIcon()
        {
            _contextMenuStrip = new ContextMenuStrip();
            _openToolStripMenuItem = new ToolStripMenuItem("Open", null, openToolStripMenuItem_Click);
            _exitToolStripMenuItem = new ToolStripMenuItem("Exit", null, (s, e) => Hide());
            _contextMenuStrip.Items.AddRange(new ToolStripItem[] { _openToolStripMenuItem, _exitToolStripMenuItem });

            _notifyIcon = new NotifyIcon(components)
            {
                Icon = new Icon("icon.ico"),
                ContextMenuStrip = _contextMenuStrip,
                Text = "Byte-Assistant",
                Visible = true
            };
            
            ControlBox = false;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void ApplyStyles()
        {
            BackColor = Color.DarkSlateBlue;
            PictureBox pictureBox = new PictureBox
            {
                Image = Image.FromFile("icon.ico"),
                Size = new Size(40, 40),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(10, 10)
            };
            Controls.Add(pictureBox);
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            PositionWindowBottomRight();
        }

        private void PositionWindowBottomRight()
        {
            Screen screen = Screen.PrimaryScreen;
            Rectangle workingArea = screen.WorkingArea;
            Location = new Point(workingArea.Right - Width - 10, Height);
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
}