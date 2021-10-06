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
    public partial class ProductionForm : Form
    {

        int selectedID;

        public ProductionForm()
        {
            InitializeComponent();

            selectedID = 0;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (!textBox2.Text.Equals("") && !textBox3.Text.Equals("") && !richTextBox1.Text.Equals(""))
            {

                if (!ProgramVariables.CheckProductionExists(textBox2.Text))
                {

                    string name = textBox2.Text, author = textBox3.Text;
                    string description = richTextBox1.Text;
                    DateTime premier = dateTimePicker1.Value, denier = dateTimePicker2.Value;

                    int ID = DatabaseClass.AddProduction(name, author, premier, denier, description);

                    ProductionInstance product = new ProductionInstance(ID, name, author, premier, denier, description);
                    ProgramVariables.Productions.Add(product);

                    MessageBox.Show("Production successfully created!");

                }
                else
                    MessageBox.Show("Production with this name already exists!");

            }
            else
                MessageBox.Show("All parameters needed!");

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            if (textBox2.Text.Length > 0 || textBox3.Text.Length > 0 || richTextBox1.Text.Length > 0)
            {

                List<ProductionInstance> productions = ProgramVariables.GetProductions(textBox2.Text, textBox3.Text, dateTimePicker1.Value, dateTimePicker2.Value, checkBox1.Checked);

                if (productions.Count == 0)
                {
                    MessageBox.Show("Product with these arguments does not exist!");
                }
                else if (productions.Count == 1)
                {
                    selectedID = productions[0].ID;
                    textBox2.Text = productions[0].Name;
                    textBox3.Text = productions[0].Author;
                    richTextBox1.Text = productions[0].Description;
                    dateTimePicker1.Value = productions[0].Premier;
                    dateTimePicker2.Value = productions[0].Denier;
                }
                else
                {
                    string searchedActors = "";
                    productions.ForEach(x =>
                    {
                        searchedActors += "\n" + x.Name + ", " + x.Author + ", " + x.Premier.ToString("yyyy-MM-dd HH:mm:ss") + ", " + x.Premier.ToString("yyyy-MM-dd HH:mm:ss");
                    });

                    MessageBox.Show("Searched many productions with those arguments" + searchedActors);

                }

            }
            else
                MessageBox.Show("Minimum one parameter is needed!");

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            if (selectedID != -1)
            {

                DatabaseClass.RemoveProduction(selectedID);
                ProgramVariables.RemoveProduction(selectedID);
                textBox2.Text = textBox3.Text = richTextBox1.Text = "";
                MessageBox.Show("You successfully removed production!");

            }
            else
                MessageBox.Show("You have to select production!");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (selectedID != -1)
            {

                DatabaseClass.UpdateProduction(selectedID, textBox2.Text, textBox3.Text, dateTimePicker1.Value, dateTimePicker2.Value, richTextBox1.Text);
                ProgramVariables.UpdateProduction(selectedID, textBox2.Text, textBox3.Text, dateTimePicker1.Value, dateTimePicker2.Value, richTextBox1.Text);
                MessageBox.Show("You successfully updated actor");

            }
            else
                MessageBox.Show("You do not have selected actor");
        }
    }
}
