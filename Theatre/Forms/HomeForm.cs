using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Theatre.Utils;

namespace Theatre.Forms
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

            label5.Text = ProgramVariables.Actors.Count.ToString();
            label7.Text = ProgramVariables.Productions.Count.ToString();
            label9.Text = ProgramVariables.Plays.Count.ToString();
            label11.Text = "0";

            ProgramVariables.Plays.ForEach(x =>
            {
                if (HasExpired(x.PlayDate))
                {
                    int index = Convert.ToInt32(label11.Text);
                    index++;
                    label11.Text = index.ToString();
                }
            });

        }

        public bool HasExpired(DateTime expires)
        {
            return DateTime.Now.CompareTo(expires.Add(new TimeSpan(2, 0, 0))) > 0;
        }

    }
}
