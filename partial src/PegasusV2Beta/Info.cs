using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PegasusV2Beta
{
    public partial class Info : Form
    {
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int WM_NCLBUTTONDBLCLK = 0x00A3;

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public Info()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Panel_MouseDown);
            this.MouseMove += new MouseEventHandler(Panel_MouseMove);
            this.MouseUp += new MouseEventHandler(Panel_MouseUp);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                return; // prevent double click full screen
            }

            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
            {
                m.Result = (IntPtr)HTCAPTION; // whole window as bar to drag
            }
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private async void link_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.me/levelek1337");
        }

        private void close_Click(object sender, EventArgs e)
        {
            // Check if the main window is already open
            main formMain = Application.OpenForms.OfType<main>().FirstOrDefault();
            formMain.FormClosed += (s, args) => this.Close();

            if (formMain == null)
            {
                // If it doesn't exist, create new form
                formMain = new main();
                formMain.FormClosed += (s, args) => this.Close();
            }
            else
            {
                // If it exists, show it again
                if (formMain.WindowState == FormWindowState.Minimized)
                {
                    formMain.WindowState = FormWindowState.Normal;
                }
                formMain.Activate();
            }

            // Hide the current window
            this.Hide();

            // Show the main window (if new instance)
            if (formMain != null && Application.OpenForms.OfType<main>().Contains(formMain))
            {
                formMain.Show();
            }
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}