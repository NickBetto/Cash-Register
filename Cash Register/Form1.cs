using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Linq.Expressions;

namespace Cash_Register
{
    public partial class cashRegister : Form
    {
        //set variables
        double glovePrice = 144.99;
        double batPrice = 109.99;
        double ballPrice = 14.99;
        int gloveAmount = 0;
        int batAmount = 0;
        int ballAmount = 0;
        double taxRate = 0.13;
        double totalCost = 0;
        double subTotal = 0;
        double tax = 0;
        double tenderedAmount = 0;
        double change = 0;
        public cashRegister()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {

            try
            {
                //set receipt label to origial state
                receiptLabel.Text = "";
                receiptLabel.BackColor = Color.White;

                //Convert Amounts to Integers
                gloveAmount = Convert.ToInt32(gloveInput.Text);
                batAmount = Convert.ToInt32(batInput.Text);
                ballAmount = Convert.ToInt32(ballInput.Text);

                //do calculations
                subTotal = gloveAmount * glovePrice + batAmount * batPrice + ballAmount * ballPrice;
                tax = subTotal * taxRate;
                totalCost = subTotal + tax;

                //show outputs
                subTotalOutput.Text = $"{subTotal.ToString("c")}";
                taxOutput.Text = $"{tax.ToString("c")}";
                totalOutput.Text = $"{totalCost.ToString("c")}";
                changeButton.Enabled = true;
            }
            catch
            {
                //Error Message
                receiptLabel.BackColor = Color.Red;
                receiptLabel.Text = $"ERROR FOUND " +
                    $"PLEASE CREATE NEW RECEIPT!!!";
                receiptLabel.Text += $"";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //set receipt label to original state
                receiptLabel.Text = "";
                receiptLabel.BackColor= Color.White;

                //Convert and Calculate
                tenderedAmount = Convert.ToDouble(tenderedInput.Text);
                change = tenderedAmount - totalCost;
                
                //Error Message
                if (tenderedAmount < totalCost)
                {
                    receiptLabel.BackColor = Color.Red;
                    receiptLabel.Text = $"ERROR FOUND " +
                        $"PLEASE CREATE NEW RECEIPT!!!";
                }
                else
                {
                    //enable button
                    changeOutput.Text = $"{change.ToString("c")}";

                    receiptButton.Enabled = true;
                }
            }
            catch
            {
                //error message
                receiptLabel.BackColor = Color.Red;
                receiptLabel.Text = $"ERROR FOUND " +
                    $"PLEASE CREATE NEW RECEIPT!!!";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Checked by me. Code is fine. Not sure why it is not working.
            // Check on my computer. --- Mr. T.
            //

            SoundPlayer sp = new SoundPlayer(Properties.Resources.testSound);
            sp.Play();

            //enable buttons
            newOrderButton.Enabled = true;
            gloveInput.Enabled = false;
            ballInput.Enabled = false;
            batInput.Enabled = false;
            tenderedInput.Enabled = false;
            
            //Print to Receipt label
            receiptLabel.Text = $"Baseball Wrld";
            receiptLabel.Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\nOrder Number 27367263";
            receiptLabel.Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\nSeptember 28, 2022\n";
            receiptLabel.Refresh();
            Thread.Sleep(500);

            string testString = "";

            if (gloveAmount > 0)
            {
                testString += $"\nGloves       x{gloveAmount} @ $144.99";
            }

            if (batAmount > 0)
            {
                testString += $"\nBats         x{batAmount} @ $109.99";
            }

            if (ballAmount >= 1)
            {
                testString += $"\nBalls        x{ballAmount} @ $14.99";
            }
            receiptLabel.Text += testString;
            receiptLabel.Refresh();
            Thread.Sleep(500);

            receiptLabel.Text += $"\n\nSubTotal          {subTotal.ToString("c")}";
            receiptLabel.Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\nTax               {tax.ToString("c")}";
            receiptLabel.Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\nTotal Cost        {totalCost.ToString("c")}";
            receiptLabel.Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\n Tendered         {tenderedAmount.ToString("c")}";
            receiptLabel.Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n Change           {change.ToString("c")}";
            receiptLabel.Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\nHave A Nice Day!";

        }

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            //Reset everything
            double totalCost = 0;
            double subTotal = 0;
            double tax = 0;
            double tenderedAmount = 0;
            double change = 0;
            double gloveAmount = 0;
            double batAmount = 0;
            double ballAmount = 0;

            receiptLabel.Text = "";
            subTotalOutput.Text = "";
            taxOutput.Text = "";
            totalOutput.Text = "";
            changeOutput.Text = "";
            gloveInput.Text = "";
            batInput.Text = "";
            ballInput.Text = "";
            tenderedInput.Text = "";
            receiptLabel.BackColor = Color.White;
            receiptButton.Enabled = false;
            gloveInput.Enabled = true;
            batInput.Enabled = true;   
            ballInput.Enabled = true;
            tenderedInput.Enabled = true;  
        }
    }
}

