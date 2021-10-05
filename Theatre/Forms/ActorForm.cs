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
    public partial class ActorForm : Form
    {

        private int selectedID;

        public ActorForm()
        {
            InitializeComponent();

            selectedID = -1;

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                if (!ProgramVariables.CheckActorExists(textBox1.Text))
                {
                    string fullname = textBox1.Text, email = textBox2.Text, phone = textBox3.Text;
                    char sex = Convert.ToChar(textBox5.Text);
                    double salary = Convert.ToDouble(textBox4.Text);
                    int ID = DatabaseClass.AddActor(fullname, sex, email, phone, salary);
                    ActorInstance actor = new ActorInstance(ID, fullname, sex, email, phone, salary);
                    ProgramVariables.Actors.Add(actor);
                    MessageBox.Show("Actor successfully created!");
                }
                else
                    MessageBox.Show("Actor with this name already exists!");
            }
            else
                MessageBox.Show("Every parameters are needed!");
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text.Length > 0 || textBox2.Text.Length > 0 || textBox3.Text.Length > 0 || textBox4.Text.Length > 0 || textBox5.Text.Length > 0)
            {

                List<ActorInstance> actors = ProgramVariables.GetActors(textBox1.Text, textBox5.Text.Equals("") ? ' ' : Convert.ToChar(textBox5.Text) , textBox2.Text, textBox3.Text, textBox4.Text.Equals("") ? - 1.0 : Convert.ToDouble(textBox4.Text));

                if(actors.Count == 0)
                {
                    MessageBox.Show("Actor with these arguments does not exist!");
                }
                else if (actors.Count == 1)
                {
                    selectedID = actors[0].ID;
                    textBox1.Text = actors[0].Fullname;
                    textBox2.Text = actors[0].Email;
                    textBox3.Text = actors[0].Phone;
                    textBox5.Text = actors[0].Sex.ToString();
                    textBox4.Text = actors[0].Salary.ToString();
                }
                else
                {
                    string searchedActors = "";
                    actors.ForEach(x =>
                    {
                        searchedActors += "\n" + x.Fullname + ", " + x.Email + ", " + x.Phone + ", " + x.Sex + ", " + x.Salary;
                    });

                    MessageBox.Show("Searched many actors with those arguments" + searchedActors);

                }

            }
            else
                MessageBox.Show("Minimum one parameter is needed!");

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            if (selectedID != -1)
            {

                DatabaseClass.RemoveActor(selectedID);
                ProgramVariables.RemoveActor(selectedID);
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
                selectedID = -1;
                MessageBox.Show("You successfully removed actor");

            }
            else
                MessageBox.Show("You do not have selected actor");

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            if(selectedID != -1)
            {

                DatabaseClass.UpdateActor(selectedID, textBox1.Text, textBox5.Text.Equals("") ? ' ' : Convert.ToChar(textBox5.Text), textBox2.Text, textBox3.Text, textBox4.Text.Equals("") ? -1.0 : Convert.ToDouble(textBox4.Text));
                ProgramVariables.UpdateActor(selectedID, textBox1.Text, textBox5.Text.Equals("") ? ' ' : Convert.ToChar(textBox5.Text), textBox2.Text, textBox3.Text, textBox4.Text.Equals("") ? -1.0 : Convert.ToDouble(textBox4.Text));
                MessageBox.Show("You successfully updated actor");

            }
            else
                MessageBox.Show("You do not have selected actor");

        }
    }
}
