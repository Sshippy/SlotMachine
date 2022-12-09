using System;

using System.Windows.Forms;

namespace SlotMachine

{

    public partial class Form1 : Form

    {

        double totalAmountEntered = 0.0;

        double totalWon = 0.0;

        public Form1()

        {

            InitializeComponent();

        }

        /// <summary>

        /// Generates random number between 1 and 3

        /// </summary>

        /// <returns></returns>

        private int getRandomImageIndex()

        {

            Random rnd = new Random();

            return rnd.Next(1, 4);

        }

        /// <summary>

        /// Load the images into source picture box based on imageindex

        /// </summary>

        /// <param name="source"></param>

        /// <param name="imageIndex"></param>

        private void loadImage(PictureBox source, int imageIndex)

        {

            switch (imageIndex)

            {

                case 1:

                    System.Drawing.Image apple = Properties.Resources.Apple;
                    {
                        source.Image = apple;
                    }

                    break;

                case 2:
                    System.Drawing.Image orange = Properties.Resources.Orange;
                    {
                        source.Image = orange;
                    }

                    break;

                case 3:
                    System.Drawing.Image avocado = Properties.Resources.Avocado;
                    {
                        source.Image = avocado;
                    }

                    break;

                case 4:

                    source.Image = null;

                    break;

            }

        }

        /// <summary>

        /// Gets number of mathces

        /// </summary>

        /// <param name="pic1"></param>

        /// <param name="pic2"></param>

        /// <param name="pic3"></param>

        /// <returns></returns>

        private int getNumberOfMatches(int pic1, int pic2, int pic3)

        {

            int numMatches = 0;

            if (pic1 == pic2)

            {

                numMatches++;

            }

            if (pic2 == pic3)

            {

                numMatches++;

            }

            if (pic1 == pic3)

            {

                numMatches++;

            }

            // if 1, then 2 pics are matching

            if (numMatches == 1)

            {

                numMatches++;

            }

            return numMatches;

        }

        private void btnSpin_Click(object sender, EventArgs e)

        {

            // check if amount enetered is valid

            double amountEntered = 0.0;

            if (double.TryParse(txtAmount.Text, out amountEntered) && amountEntered > 0)

            {

                int pic1 = getRandomImageIndex();

                loadImage(pictureBox1, pic1);

                int pic2 = getRandomImageIndex();

                loadImage(pictureBox2, pic2);

                int pic3 = getRandomImageIndex();

                loadImage(pictureBox3, pic3);

                // Caluclate winning amount

                int numberOfMatches = getNumberOfMatches(pic1, pic2, pic3);

                double amountWon = numberOfMatches * amountEntered;

                // Add the current details to totals

                totalAmountEntered += amountEntered;

                totalWon += amountWon;

                // Display to user

                MessageBox.Show("You Won " + amountWon.ToString("C"), "Winning Amount",

                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset all the picture boxes and amount text boxes

                loadImage(pictureBox1, -1);

                loadImage(pictureBox2, -1);

                loadImage(pictureBox3, -1);

                txtAmount.Text = "";

            }

            else // show error for invalid entry

            {

                MessageBox.Show("Enter valid amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtAmount.Focus();

            }

        }

        private void btnExit_Click(object sender, EventArgs e)

        {

            // Display total amount entered and total winning amount

            string displayStr = "Total Amount entered: " + totalAmountEntered.ToString("C") + "\n" + "Total Won: " + totalWon.ToString("C");

            MessageBox.Show(displayStr, "Total Winning Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Exit the application

            Application.Exit();

        }

    }

}
