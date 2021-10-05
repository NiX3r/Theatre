using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Theatre.Forms;

namespace Theatre
{
    public partial class MainUI : Form
    {

        private Form currentChildForm = null;
        private Button currentButton = null;

        public MainUI()
        {
            InitializeComponent();

            OpenChildForm(new HomeForm(), button3);

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public void OpenChildForm(Form childForm, Button button)
        {
            // Setup child form
            if (currentChildForm != null)
                currentChildForm.Close();
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            SubFormPanel.Controls.Add(childForm);
            SubFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            // Setup button visualation
            if (currentButton != null)
            {
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.BackColor = Color.FromArgb(55,55,55);
            }
            currentButton = button;
            panel2.Location = currentButton.Location;
            currentButton.TextAlign = ContentAlignment.MiddleRight;
            currentButton.BackColor = Color.FromArgb(44, 44, 44);
            currentButton.TextAlign = ContentAlignment.MiddleRight;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            switch (((Button)sender).Text)
            {
                case "Home":
                    OpenChildForm(new HomeForm(), (Button)sender);
                    break;
                case "Actors":
                    OpenChildForm(new ActorForm(), (Button)sender);
                    break;
                case "Plays":
                    OpenChildForm(new PlayForm(), (Button)sender);
                    break;
                case "Productions":
                    OpenChildForm(new ProductionForm(), (Button)sender);
                    break;
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.flaticon.com/");
        }
    }
}
