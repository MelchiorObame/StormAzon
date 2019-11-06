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
    public partial class VideoGamesForm : Form
    {
        //Fields
        List<string> listItemsSelected;

        public VideoGamesForm()
        {
            InitializeComponent();
            listItemsSelected = new List<string>();
        }

        //change item name by checking checkBox
        private void addSelItemNameToList()
        {
            if (videoGa11RadioBtn.Checked)
            {
                listItemsSelected.Add("Atari 2600");
            }
            if (videoGa12RadioBtn.Checked)
            {
                listItemsSelected.Add("NES");
            }
            if (videoGa21RadioBtn.Checked)
            {
                listItemsSelected.Add("SNES");
            }
            if (videoGa22RadioBtn.Checked)
            {
                listItemsSelected.Add("Sega Genesis");
            }
        }

        //by clicking on Exit Button
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //by clicking on "add selected" Button 
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
