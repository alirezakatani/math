using System;
using System.Windows.Forms;

namespace math_project
{
    public partial class Form1 : Form
    {
        double[] data;
        int num;
        int i = 0;
        double mod;
        double var;
        double enheraf;
        double miane;
        double cv;
        double miangin;


        int[] teadad;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (i > num)
            {
                btnadd.Text = "mohasebe";
                mohasebe();
                // Application.Restart();

            }
            data[i] = Convert.ToInt32(txtdata.Text);
            i++;
            datalable.Text = datalable.Text + " " + data[i] + ",";
            txtdata.Text = "";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            num = Convert.ToInt32(txtnumdata.Text);
            data = new double[num];
            txtdata.Focus();
        }
        private void mohasebe()
        {
            double sum = 0;
            double tavan2 = 0;
            {
                if (comboBox1.Text == "gosaste")
                {
                    if (num % 2 == 0)
                        miane = (data[(num / 2) - 1] + data[(num / 2)]) / 2;
                    else
                        miane = data[num / 2];
                }
                else
                {

                }

            }//miane


            {

                for (int i = 0; i < num; i++)
                {
                    sum += data[i];
                }
                miangin = sum / 2;
            }//miangin
            {
                for (int i = 0; i < num; i++)
                {
                    tavan2 += Math.Pow(data[i] - miangin, 2);
                }
                var = tavan2 / num;


            }//var
            {
                enheraf = Math.Sqrt(var);

            }//enheraf
            {
                cv = enheraf / miangin;
            }//cv





        }

        private void chart1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
