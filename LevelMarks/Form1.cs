using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelMarks
{
    public partial class Form1 : Form
    {
        public Autodesk.Revit.UI.UIDocument uiDoc { get; set; }
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeView.CheckBoxes = true;
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void TreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeView.BeginUpdate();
            foreach (TreeNode tn in e.Node.Nodes)
                tn.Checked = e.Node.Checked;
            TreeView.EndUpdate();
        }

        private void TextNoteTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
