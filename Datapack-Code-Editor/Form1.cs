using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Datapack_Code_Editor
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            darkThemeToolStripMenuItem.Checked = false;
            lightThemeToolStripMenuItem.Checked = true;

            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thing();
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> folders = new List<string>();
                folders.Add("functions");
                folders.Add("advancements");
                folders.Add("loot_tables");
                folders.Add("predicates");
                folders.Add("recipes");
                folders.Add("structures");
                folders.Add("dimension");
                folders.Add("dimension_type");

                if (dpFolder.Text == "")
                {
                    dpFolder.Text = "Datapack";
                }
                if (dpNamespace.Text == "")
                {
                    dpNamespace.Text = "dp";
                }

                foreach (string path in folders)
                {
                    Directory.CreateDirectory(dpFolder.Text + @"\data\" + dpNamespace.Text + @"\" + path);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not write to disk. Original error: " + ex.Message);
            }
            finally
            {
                dpFolder.Text = "";
                dpNamespace.Text = "";
            }
        }

        private void datapackStructureGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //codeBox.Visible = false;
        }

        private void codeEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeBox.Visible = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open File";
            open.Filter = "Mcfunction File|*.mcfunction|Mcmeta File|*.mcmeta|Json File|*.json";
            if (open.ShowDialog() == DialogResult.OK)
            {
                f.Text = open.FileName;
                codeBox.Text = File.ReadAllText(open.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.Text == "label1")
            {
                thing();
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(f.Text))
                {
                    sw.Write(codeBox.Text);
                }
            }


        }
        private void thing()
        {

            SaveFileDialog sd = new SaveFileDialog();
            sd.CheckPathExists = true;
            sd.Filter = "Mcfunction File|*.mcfunction|Mcmeta File|*.mcmeta|Json File|*json";
            sd.RestoreDirectory = true;

            if (sd.ShowDialog() == DialogResult.OK)
            {
                switch (sd.FilterIndex)
                {
                    case 1:
                        using (StreamWriter sw = new StreamWriter(sd.FileName))
                        {
                            sw.Write(codeBox.Text);
                        }
                        break;
                    case 2:
                        using (StreamWriter sw = new StreamWriter(sd.FileName))
                        {
                            sw.Write(codeBox.Text);
                        }
                        break;
                    case 3:
                        using (StreamWriter sw = new StreamWriter(sd.FileName + ".json"))
                        {
                            sw.Write(codeBox.Text);
                        }
                        break;
                }
                f.Text = sd.FileName;

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.Text == "label1")
            {
                thing();
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(f.Text))
                {
                    sw.Write(codeBox.Text);
                }
            }
            Close();

        }

        private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            darkMode();
        }

        private void lightThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lightMode();
        }

        private void darkMode()
        {
            //sets it to dark theme
            darkThemeToolStripMenuItem.Checked = true;
            lightThemeToolStripMenuItem.Checked = false;

            codeBox.BackColor = Color.Black;
            codeBox.ForeColor = Color.White;

            menuStrip1.BackColor = Color.DarkGray;
            menuStrip1.ForeColor = Color.White;

        }

        private void lightMode()
        {
            //sets it to light theme
            darkThemeToolStripMenuItem.Checked = false;
            lightThemeToolStripMenuItem.Checked = true;

            codeBox.BackColor = Color.White;
            codeBox.ForeColor = Color.Black;
            menuStrip1.BackColor = Color.White;
            menuStrip1.ForeColor = Color.Black;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dpNamespace_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}