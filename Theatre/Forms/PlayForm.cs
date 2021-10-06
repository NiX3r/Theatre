using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Theatre.Instances;
using Theatre.Utils;

namespace Theatre.Forms
{
    public partial class PlayForm : Form
    {

        private int selectedID;

        public PlayForm()
        {
            InitializeComponent();
            selectedID = -1;

            ProgramVariables.Productions.ForEach(x =>
            {
                listBox1.Items.Add(x.Name);
            });

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem != null && !textBox3.Text.Equals(""))
            {

                if (!ProgramVariables.CheckPlayExists(selectedID, dateTimePicker1.Value))
                {

                    int participate = Convert.ToInt32(textBox3.Text);
                    DateTime playDate = dateTimePicker1.Value;
                    int production = ProgramVariables.GetProductionID(listBox1.SelectedItem.ToString());

                    int ID = DatabaseClass.AddPlay(playDate, participate, production);
                    selectedID = ID;

                    PlayInstance play = new PlayInstance(ID, playDate, participate, production);
                    ProgramVariables.Plays.Add(play);

                    MessageBox.Show("Play successfully created!");

                }
                else
                    MessageBox.Show("Play with this name already exists!");

            }
            else
                MessageBox.Show("All parameters needed!");

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            if (textBox3.Text.Length > 0 || listBox1.SelectedIndex >= 0)
            {

                int participate = -1;
                if (textBox3.Text.Length > 0)
                    participate = Convert.ToInt32(textBox3.Text);
                DateTime playDate = dateTimePicker1.Value;
                int production = -1;
                if (listBox1.SelectedItem != null)
                    production = ProgramVariables.GetProductionID(listBox1.SelectedItem.ToString());
                List<PlayInstance> plays = ProgramVariables.GetPlays(playDate, participate, production, checkBox1.Checked);

                if (plays.Count == 0)
                {
                    MessageBox.Show("Play with these arguments does not exist!");
                }
                else if (plays.Count == 1)
                {
                    selectedID = plays[0].ID;
                    dateTimePicker1.Value = plays[0].PlayDate;
                    textBox3.Text = plays[0].Participate.ToString();
                    listBox1.SetSelected(listBox1.Items.IndexOf(ProgramVariables.GetProductionName(plays[0].Production_ID)), true);
                }
                else
                {
                    string searchedActors = "";
                    plays.ForEach(x =>
                    {
                        searchedActors += "\n" + x.PlayDate.ToString("yyyy-MM-dd HH:mm:ss") + ", " + x.Participate + ", " + listBox1.SelectedItem.ToString();
                    });

                    MessageBox.Show("Searched many plays with those arguments" + searchedActors);

                }

            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (selectedID != -1)
            {

                DatabaseClass.RemovePlay(selectedID);
                ProgramVariables.RemovePlay(selectedID);
                textBox3.Text = "";
                MessageBox.Show("You successfully removed play!");

            }
            else
                MessageBox.Show("You have to select play!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (selectedID != -1)
            {

                DatabaseClass.UpdatePlay(selectedID, dateTimePicker1.Value ,Convert.ToInt32(textBox3.Text), ProgramVariables.GetProductionID(listBox1.SelectedItem.ToString()));
                ProgramVariables.UpdatePlay(selectedID, dateTimePicker1.Value, Convert.ToInt32(textBox3.Text), ProgramVariables.GetProductionID(listBox1.SelectedItem.ToString()));
                MessageBox.Show("You successfully updated play");

            }
            else
                MessageBox.Show("You do not have selected play");
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
