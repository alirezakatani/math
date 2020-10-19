using System;
using System.Linq;
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
        int delta;


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
            
            if (i % 25 == 0)
                datalable.Text = datalable.Text + "\n";
           datalable.Text = datalable.Text + " " + data[i] + ",";
           txtdata.Text = "";
            i++;


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
            int[] tea = { 0 };
            {
                double temp;
                for (int i = 0; i < num; i++)
                {
                    if(data[i+1]<data[i])
                    {
                        temp = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = temp;
                    }

                }
            }//sort
            {
                
                    if (num % 2 == 0)
                        miane = (data[(num / 2) - 1] + data[(num / 2)]) / 2;
                    else
                        miane = data[num / 2];
                
              

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
            {
                if(comboBox1.Text=="gosaste")
                {
                    delta = (int)data.Max() - (int)data.Min();
                    tea = new int[delta];
                    for(i=0;i<delta;i++)
                    {
                        tea[(int)data[i]]++;
                    }
                   
                }
                mod = tea.Max();
                
            }//mod





        }

        private void chart1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
