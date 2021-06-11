using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOGO
{
    public partial class MainForm : Form
    {
        readonly int target;
        int counter = 0;

        public static string text { private set; get; }  //This variable is called by 'WinnerForm' 
        public static Image img { private set; get; }  //This also

        public MainForm()
        {
            Random k = new Random();
            target = k.Next(-1, 1001);  //grabs random number betwween 0 and 1000

            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int guess = Convert.ToInt16(textBox1.Text);  //takes input from user                   

                if (guess < target)
                {
                    label4.Text = string.Format("My number is greater than {0}!", guess);
                    counter++;
                }

                else if (guess > target)
                {
                    label4.Text = string.Format("My number is less than {0}!", guess);
                    counter++;
                }

                else if (guess == target)
                {
                    counter++;
                    label4.Text = "THE NUMBER WAS GUESSED!";

                    text = string.Format("Congratulations! The number was {0}!", guess);
                    if (counter == 1)
                    {
                        text += (string.Format("\n {0} try? Your're the king of kings!", counter));
                        img = Properties.Resources.king_of_kings;
                    }
                    else if (counter > 1 && counter <= 5)
                    {
                        text += (string.Format("\n {0} tries? Such a legend!", counter));
                        img = Properties.Resources.hacker;
                    }
                    else if (counter > 5 && counter <= 10)
                    {
                        text += (string.Format("\n {0} tries? You did it tho!", counter));
                        img = Properties.Resources.moutaineer_celebrating;
                    }
                    else if (counter > 10)
                    {
                        text += (string.Format("\n {0} tries? You're not that good of a Guesser.", counter));
                        img = Properties.Resources.guess_i_failed;
                    }

                    WinnerForm form = new WinnerForm();  //calls 'WinnerForm' 
                    form.ShowDialog();
                }

                else
                {
                    label4.Text = "Type a number BETWEEN 0 and 1000!";
                }
            }
            catch
            {
                label4.Text = "Please type a NUMBER!";
            }
        }
    }
}

