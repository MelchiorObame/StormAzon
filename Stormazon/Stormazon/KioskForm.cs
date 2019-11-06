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
    public partial class KioskForm : Form
    {

        AboutForm aboutForm;
        MusicForm musicForm;
        MovieForm movieForm;
        VideoGamesForm videoGamesForm;

        //Fields
        private const double DBL_TAXRATE = 0.07;
        private double dblTax;          //Tax
        private double dblTotal;        //total price
        private double dblsubTotal;     //subtotal price
        private int intItemCount;       //Number of items in Cart

        public KioskForm()
        {
            InitializeComponent();
            aboutForm = new AboutForm();
            musicForm = new MusicForm();
            movieForm = new MovieForm();
            videoGamesForm = new VideoGamesForm();

            dblTax = 0.0;
            dblTotal = 0.0;
            intItemCount = 0;
            dblsubTotal = 0;
        }
       
        //#############     fonctions
        // Void method to handle shipping
        public void checkShippingBox()
        {
            double shippingCost = 0.0;
            if (this.shippingcheckBox.Checked)
            {
                if (intItemCount > 0 && intItemCount < 4)
                {
                    shippingCost = 9;
                }
                else if (intItemCount >= 4 && intItemCount < 7)
                {
                    shippingCost = 6;
                }
                dblTotal += shippingCost;
            }
            shippingLabel.Text = shippingCost.ToString();
            totalLabel.Text = dblTotal.ToString();
        }

        //returning method to get price of item
        public double getItemPrice(string itemName)
        {
            double price = 0.0;
            switch (itemName)
            {
                case "Back to the Future":  price = 29.99;
                    break;
                case "Can’t Buy Me Love":  price = 24.99;
                    break;
                case "Raiders of the Lost Ark": price = 22.99;
                    break;
                case "The Breakfast Club": price = 20.99;
                    break;
                case "Atari 2600": price = 19.99;
                    break;
                case "NES": price = 14.99;
                    break;
                case "SNES": price = 12.99;
                    break;
                case "Sega Genesis": price = 20.99;
                    break;
                case "Guns N Roses": price = 9.99;
                    break;
                case "Bon Jovi": price = 4.99;
                    break;
                case "Poison": price = 2.99;
                    break;
                case "Motley Crue": price = 0.99;
                    break;
                default:
                    break;
            }
            return price;
        }

        //method to remove an item from the listbox
        public void removeItem()
        {
            if (this.itemsListBox.SelectedItem !=null) {
                double price = getItemPrice(itemsListBox.SelectedItem.ToString());
                dblsubTotal -= price;
                dblTax -= DBL_TAXRATE * price;
                dblTotal = dblsubTotal + dblTax;
                intItemCount--;
                this.itemsListBox.Items.Remove(itemsListBox.SelectedItem);
                checkShippingBox();
            }
        }

        //method to calculate\update the subtotal, tax, total and item count variables
        public void calculatePrices(double itemPrice)
        {
            this.intItemCount++;
            dblsubTotal += itemPrice;
            dblTax += DBL_TAXRATE*itemPrice;
            dblTotal = dblsubTotal + dblTax;
        }

        //Void method to update the form labels
        public void updateLabels() {
            //arrondie à 2 chiffre apres la virgule.
            dblTotal = Math.Round(dblTotal,2);
            dblTax = Math.Round(dblTax, 2);
            dblsubTotal = Math.Round(dblsubTotal, 2);
            this.itemCountLabel.Text = intItemCount.ToString();
            this.subTotalLabel.Text = dblsubTotal.ToString(); ;
            this.taxLabel.Text = dblTax.ToString();
            this.totalLabel.Text = dblTotal.ToString();
        }

        //Void method to add an item to the form
        public void addItem(string itemName) {
            this.itemPictureBox.Visible = true;
            double itemPrice = this.getItemPrice(itemName);   //get the item price
            this.itemsListBox.Items.Add(itemName);            //add the item to the listbox
            calculatePrices(itemPrice);
            checkShippingBox();
            this.updateLabels();
        }

        //change l'image lorsqu'on click dans la listBox
        public void changeItemPicture()
        {      
            string itemName = this.itemsListBox.SelectedItem.ToString();
            switch (itemName)
            {
                case "Back to the Future":
                    this.itemPictureBox.Image = global::Stormazon.Properties.Resources.backToTheFure; break;
                case "Can’t Buy Me Love":
                    this.itemPictureBox.Image = global::Stormazon.Properties.Resources.cant_Buy;
                    break;
                case "Raiders of the Lost Ark":
                    this.itemPictureBox.Image = global::Stormazon.Properties.Resources.raidersOfThe;
                    break;
                case "The Breakfast Club":
                    this.itemPictureBox.Image = global::Stormazon.Properties.Resources.BreakfastClub;
                    break;
                case "Atari 2600":
                    this.itemPictureBox.Image = global::Stormazon.Properties.Resources.atari2600;
                    break;
                case "NES":
                    this.itemPictureBox.Image = global::Stormazon.Properties.Resources.NES;
                    break;
                case "SNES":
                    this.itemPictureBox.Image = global::Stormazon.Properties.Resources.SNES;
                    break;
                case "Sega Genesis":
                    this.itemPictureBox.Image = global::Stormazon.Properties.Resources.Sega_Genesis_System;
                    break;
                case "Guns N Roses":
                    this.itemPictureBox.Image = global::Stormazon.Properties.Resources.GunsNRoses;
                    break;
                case "Bon Jovi":
                    this.itemPictureBox.Image = global::Stormazon.Properties.Resources.BonJovi;
                    break;
                case "Poison":
                    this.itemPictureBox.Image = global::Stormazon.Properties.Resources.poison;
                    break;
                case "Motley Crue":
                    this.itemPictureBox.Image = global::Stormazon.Properties.Resources.motley;
                    break;
                default:
                    break;
            }
        }
        
        //########## Buttons
        //retire l'item selectionné si il y'en a un.
        private void removeSelBtn_Click(object sender, EventArgs e)
        {
            this.removeItem();
            this.updateLabels();
        }

        //à l'appui sur le shippingCheckBox. Change shinpping cost and update Total price
        private void shippingcheckBox_CheckedChanged(object sender, EventArgs e)
        {

            checkShippingBox();
            if ( !this.shippingcheckBox.Checked) {
                double shippingCost = 0.0;
                shippingLabel.Text = shippingCost.ToString();
                if (intItemCount > 0 && intItemCount < 4)
                {
                    shippingCost = -9;
                }
                else if (intItemCount >= 4 && intItemCount < 7)
                {
                    shippingCost = -6;
                }
                dblTotal += shippingCost;
                totalLabel.Text = (dblTotal).ToString();
            }
        }

        //########## show windows menuStrip
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm.Owner = this;
            aboutForm.ShowDialog();
        }

        private void musicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musicForm.Owner = this;
            musicForm.ShowDialog();
        }

        private void moviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            movieForm.Owner = this;
            movieForm.ShowDialog();
        }

        private void videoGamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoGamesForm.Owner = this;
            videoGamesForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.removeItem();
            this.updateLabels();
        }

        private void clearAllItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.itemsListBox.Items.Clear();
            this.dblsubTotal = 0;
            this.dblTax = 0;
            this.dblTotal = 0;
            this.intItemCount = 0;
            this.itemPictureBox.Visible = false;
            checkShippingBox();
            this.updateLabels();
        }

        //########## context menuStrip
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void musicToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            musicForm.Owner = this;
            musicForm.ShowDialog();
        }

        private void moviesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            movieForm.Owner = this;
            movieForm.ShowDialog();
        }

        private void videoGamesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            videoGamesForm.Owner = this;
            videoGamesForm.ShowDialog();
        }

        //clic dans la listBox : change picture
        private void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.itemsListBox.SelectedItem != null)
            {
                changeItemPicture();
            }
        }

    }

}
