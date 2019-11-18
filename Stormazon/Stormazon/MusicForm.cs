using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stormazon
{
    public partial class MusicForm : Form
    {
        //Fields
        List<string> listItemsSelected;

        public MusicForm()
        {
            InitializeComponent();
            listItemsSelected = new List<string>();
        }

        //change item name by checking checkBox
        private void addSelItemNameToList()
        {
            if (music11checkBox.Checked)
            {
                listItemsSelected.Add("Guns N Roses");
            }
            if (music12checkBox.Checked)
            {
                listItemsSelected.Add("Bon Jovi");
            }
            if (music21checkBox.Checked)
            {
                listItemsSelected.Add("Poison");
            }
            if (music22checkBox.Checked)
            {
                listItemsSelected.Add("Motley Crue");
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addSelBtn_Click(object sender, EventArgs e)
        {
            this.addSelItemNameToList();
            foreach (string itemName in listItemsSelected)
            {
                ((KioskForm)this.Owner).addItem(itemName);
            }
            //Clear all item
            listItemsSelected.Clear();
        }
    }
}
