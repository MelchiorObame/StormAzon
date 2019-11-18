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
    public partial class MovieForm : Form
    {
        //Fields
        List<string> listItemsSelected;
        private Boolean movie11Selected;
        private Boolean movie12Selected;
        private Boolean movie21Selected;
        private Boolean movie22Selected;

        public MovieForm()
        {
            InitializeComponent();
            listItemsSelected = new List<string>();
            movie11Selected = false;
            movie12Selected = false;
            movie21Selected = false;
            movie22Selected = false;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addSelBtn_Click(object sender, EventArgs e)
        {
            foreach (string itemName in listItemsSelected)
            {
                ((KioskForm)this.Owner).addItem(itemName);
            }
            //Clear all items
            listItemsSelected.Clear();
            //restore properties after cleaning
            movie11Selected = false;
            movie12Selected = false;
            movie21Selected = false;
            movie22Selected = false;
            check11PicBox.Visible = false;
            check12PicBox.Visible = false;
            check21PicBox.Visible = false;
            check22PicBox.Visible = false;
        }

        //##### on click
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            movie11Selected = !movie11Selected;
            if (movie11Selected)
            {
                check11PicBox.Visible = true;
                listItemsSelected.Add("Back to the Future");
            }
            else
            {
                check11PicBox.Visible = false;
                listItemsSelected.Remove("Back to the Future");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            movie12Selected = !movie12Selected;
            if (movie12Selected)
            {
                check12PicBox.Visible = true;
                listItemsSelected.Add("Can’t Buy Me Love");
            }
            else
            {
                check12PicBox.Visible = false;
                listItemsSelected.Remove("Can’t Buy Me Love");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            movie21Selected = !movie21Selected;
            if (movie21Selected)
            {
                check21PicBox.Visible = true;
                listItemsSelected.Add("Raiders of the Lost Ark");
            }
            else
            {
                check21PicBox.Visible = false;
                listItemsSelected.Remove("Raiders of the Lost Ark");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            movie22Selected = !movie22Selected;
            if (movie22Selected)
            {
                check22PicBox.Visible = true;
                listItemsSelected.Add("The Breakfast Club");
            }
            else
            {
                check22PicBox.Visible = false;
                listItemsSelected.Remove("The Breakfast Club");
            }
        }

    }
}
