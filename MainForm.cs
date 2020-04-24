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
        private int counter = 0;
        readonly int choice;
        public static string Win { private set; get; }  //'Win' string is called by 'WinnerForm' 

        public MainForm()
        {
            Random k = new Random();  
            choice = k.Next(-1, 1001);  //takes random number betwween 0 and 1000

            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int guess = Convert.ToInt16(textBox1.Text);  //takes input from user                                              

                if (guess < choice)
                {
                    label4.Text = string.Format("Meu número é maior que {0}!", guess);
                    counter++;
                }

                else if (guess > choice)
                {
                    label4.Text = string.Format("Meu número é menor que {0}!", guess);
                    counter++;
                }

                else if (guess == choice)
                {
                    counter++;
                    label4.Text = "ADIVINHAÇÃO BEM SUCEDIDA!";
                    
                    Win = string.Format ("Parabéns, meu número é {0}, e você precisou de {1} tentativas para adivinhar!", guess, counter);
                   
                    WinnerForm kkk = new WinnerForm();  //calls 'WinnerForm' 
                    kkk.ShowDialog();  
                } 

                else
                {
                    label4.Text = "Digite um número ENTRE 0 e 1000!";
                }
            }
            catch
            {
                label4.Text = "Por favor digite um NÚMERO!";
            }
        }
    }
}
