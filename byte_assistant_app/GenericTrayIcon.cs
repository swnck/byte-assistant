using Microsoft.Win32;

namespace byte_assistant_app;

public partial class GenericTrayIcon : Form
{
    private NotifyIcon notifyIcon;
        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _exitToolStripMenuItem;
        private ToolStripMenuItem _openToolStripMenuItem;

        public GenericTrayIcon()
        {
            InitializeComponent();
            InitializeTrayIcon();
            SetAutostart();

            // Verstecke das Fenster und zeige es nicht in der Taskleiste an
            Hide();
            ShowInTaskbar = false;
        }

        private void InitializeTrayIcon()
        {
            _contextMenuStrip = new ContextMenuStrip();
            _openToolStripMenuItem = new ToolStripMenuItem("Open", null, openToolStripMenuItem_Click);
            _exitToolStripMenuItem = new ToolStripMenuItem("Exit", null, closeToolStripMenuItem_Click);
            _contextMenuStrip.Items.AddRange(new ToolStripItem[] { _openToolStripMenuItem, _exitToolStripMenuItem });

            notifyIcon = new NotifyIcon(components)
            {
                Icon = new Icon("icon.ico"),
                ContextMenuStrip = _contextMenuStrip,
                Text = "Byte-Assistant",
                Visible = true
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hide();
            ShowInTaskbar = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            PositionWindowBottomRight();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            ShowInTaskbar = false;
        }

        private void PositionWindowBottomRight()
        {
            Screen screen = Screen.PrimaryScreen;
            Rectangle workingArea = screen.WorkingArea;
            Location = new Point(workingArea.Right - Width, workingArea.Bottom - Height);
        }

        private void SetAutostart()
        {
            const string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            const string appName = "ByteAssistant";
            string appPath = Application.ExecutablePath;

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(runKey, true))
            {
                if (key != null)
                {
                    key.SetValue(appName, appPath);
                }
                else
                {
                    using (RegistryKey newKey = Registry.CurrentUser.CreateSubKey(runKey))
                    {
                        newKey.SetValue(appName, appPath);
                    }
                }
            }
        }
}