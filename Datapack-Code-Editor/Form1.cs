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
using System.Drawing.Printing;

namespace Datapack_Code_Editor
{
    public partial class Form1 : Form
    {

        static Form f1;

        PrintDocument pDocument = new PrintDocument();
        PrintDialog pDialog = new PrintDialog();

        public Form1()
        {
            InitializeComponent();

            f1 = this;

            pDocument.PrintPage += new PrintPageEventHandler(document_PrintPage);
        }

        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(codeBox.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 20, 20);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //darkMode();

            lightMode();
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

                /*foreach (string path in folders)
                {
                    Directory.CreateDirectory(dpFolder.Text + @"\data\" + dpNamespace.Text + @"\" + path);
                }*/

                if (dpDirectory.Text == "")
                {
                    foreach (string path in folders)
                    {
                        Directory.CreateDirectory(dpFolder.Text + @"\data\" + dpNamespace.Text + @"\" + path);
                    }
                }

                else
                {
                    foreach (string path in folders)
                    {
                        Directory.CreateDirectory(dpDirectory.Text + @"\" + dpFolder.Text + @"\data\" + dpNamespace.Text + @"\" + path);
                    }
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
            open.Filter = "Mcfunction File|*.mcfunction|Mcmeta File|*.mcmeta|Json File|*.json|*.*|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                f.Text = open.FileName;
                codeBox.Text = File.ReadAllText(open.FileName);
            }

            status.Text = codeBox.Text;
            f1.Text = "Datapack creator";
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

            status.Text = codeBox.Text;
            f1.Text = "Datapack creator";
        }
        private void thing()
        {

            SaveFileDialog sd = new SaveFileDialog();
            sd.CheckPathExists = true;
            sd.Filter = "Mcfunction File|*.mcfunction|Mcmeta File|*.mcmeta|Json File|*.json|*.*|*.*";
            sd.RestoreDirectory = true;

            if (sd.ShowDialog() == DialogResult.OK)
            {
                /*switch (sd.FilterIndex)
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
                        using (StreamWriter sw = new StreamWriter(sd.FileName))
                        {
                            sw.Write(codeBox.Text);
                        }
                        break;
                }*/

                using (StreamWriter sw = new StreamWriter(sd.FileName))
                {
                    sw.Write(codeBox.Text);
                }
                f.Text = sd.FileName;

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (status.Text != codeBox.Text)
            {
                DialogResult dialogResult = MessageBox.Show("Would you like to save?", "New file", MessageBoxButtons.YesNoCancel);

                if (dialogResult.ToString() == "Yes")
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

                if (dialogResult.ToString() == "No")
                {
                    Close();
                }
            }

            else
            {
                Close();
            }

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

        private void codeBox_TextChanged(object sender, EventArgs e)
        {
            /*
            if (codeBox.Text == "")
            {
                codeBox.Text = "test";
            }
            else
            {
                
            }*/

            if (codeBox.Text != status.Text)
            {
                f1.Text = "Datapack creator *";
            }
            else
            {
                f1.Text = "Datapack creator";
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeBox.Text = Clipboard.GetText();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (status.Text != codeBox.Text)
            {
                DialogResult dialogResult = MessageBox.Show("Would you like to save?", "New file", MessageBoxButtons.YesNoCancel);

                if (dialogResult.ToString() == "Yes")
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

                    f.Text = "label1";
                    codeBox.Text = "";
                }

                if (dialogResult.ToString() == "No")
                {
                    codeBox.Text = "";
                    f.Text = "label1";
                    status.Text = "";
                    f1.Text = "Datapack creator";
                }
            }

            else
            {
                codeBox.Text = "";
                f.Text = "label1";
                status.Text = "";
                f1.Text = "Datapack creator";
            }



        }

        private void debuggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (debuggingToolStripMenuItem.Checked == true)
            {
                f.Visible = true;
                status.Visible = true;
            }
            else
            {
                f.Visible = false;
                status.Visible = false;
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("");

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            pDialog.Document = pDocument;
            if (pDialog.ShowDialog() == DialogResult.OK)
            {
                pDocument.Print();
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog pPDialog = new PrintPreviewDialog();

            pPDialog.Document = pDocument;

            pPDialog.ShowDialog();
        }
    }
}