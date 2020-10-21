using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using System.IO;

namespace math_project
{




    public partial class Form1 : Form
    {
        
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CurrencyManager cr;
        int beforcurrent;
        Region x = new Region();
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
        int satr;
        double xesatr;
        double max;
        double min;


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

           
            
                data[i] = Convert.ToInt32(txtdata.Text);

            if (i % 25 == 0)
                datalable.Text = datalable.Text + "\n";
            datalable.Text = datalable.Text + " " + data[i] + ",";
            txtdata.Text = "";
            i++;
            if(i==num)
            {
                btnadd.Enabled = false;
                btnmohasebe.Enabled = true;
            }

            
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            num = Convert.ToInt32(txtnumdata.Text);
            data = new double[num];
            txtdata.Focus();
            btnapply.Enabled = false;
            txtnumdata.Enabled = false;
        }
        private void mohasebe()
        {
            double sum = 0;
            double tavan2 = 0;
            int[] tea = { 0 };
            {
                double temp;
                for (int j = 0; j < num-1;j++)
                {
                    if (data[j + 1] < data[j])
                    {
                        temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }

                }
            }//sort
            {
                max = data[0]; min = data[0];
                for (int j = 0; j < num; j++)
                {
                    if (data[j] > max)
                        max = data[j];
                    if (data[j] < min)
                        min = data[j];

                }
                delta = (int)(max - min);
            }//min,max
            {

                if (num % 2 == 0)
                    miane = (data[(num / 2) - 1] + data[(num / 2)]) / 2;
                else
                    miane = data[num / 2];




            }//miane
            {

                for (int j = 0; j < num; j++)
                {
                    sum += data[j];
                }
                miangin = sum / num;
            }//miangin
            {
                for (int j = 0; j < num; j++)
                {
                    tavan2 += Math.Pow(data[j] - miangin, 2);
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
                if (comboBox1.Text == "gosaste")
                {
                    delta =(int)(max-min);
                    tea = new int[delta];
                    for (i = 0; i < delta; i++)
                    {
                        tea[(int)data[i]]++;
                    }

                }
                mod = tea.Max();

            }//mod
            {
                satr = (int)Math.Floor(1 + 3.32 * (Math.Log10(delta) / Math.Log10(8))) + 1;
                xesatr = (double) delta / satr;
                xesatr = xesatr - (xesatr % (0.00001)) + (0.00001);

            }//satr , xsatr
            {
                txtcv.Text = Convert.ToString(cv);
                txtmod.Text = Convert.ToString(mod);
                txtmiane.Text = Convert.ToString(miane);
                txtenheraf.Text = Convert.ToString(enheraf);
                txtmiangin.Text = Convert.ToString(miangin);
                txtvarince.Text = Convert.ToString(var);
            }//set in textboxes

            





        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\c# lrearning\New folder\math project\Database1.mdf; Integrated Security = True";
            conn.Open();
            fillgred();
        }
        void fillgred(string s = "Select * from tblmath")
        {
            cmd.CommandText = s;
            double mins = min;
            double maxs = mins + xesatr;
            cmd.Connection = conn;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds, "T1");
            dataGridView1.DataBindings.Clear();
            int numberofsatr = 0;
            dataGridView1.DataBindings.Add("datasource", ds, "T1");
            for (int i = 0; i < satr; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    if (data[j] < maxs && data[j] >= mins)
                    {
                        
                        numberofsatr++;
                        


                    }
                    if (i == satr - 1 && data[j] == maxs)
                    {
                        numberofsatr++;
                    }

                }

                mins += xesatr;
                maxs += xesatr;
                numberofsatr = 0;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            mohasebe();
            double mins = min;
            double maxs = mins + xesatr;
            int numberofsatr = 0;
            int number2 = 0;
            double flo1 = 0;
            double floe2 = 0;
            for (int i = 0; i < satr; i++)
            {
                SqlCommand c1 = new SqlCommand();
                c1.Connection = conn;
                for (int j = 0; j < num; j++)
                {
                    if (data[j] < maxs && data[j] >= mins)
                    {
                        numberofsatr++;

                    }
                    if (i == satr - 1 && data[j] == maxs)
                    {
                        numberofsatr++;
                    }
                }
                c1.CommandText = "insert into tblmath values(@p1,@p2,@p3,@p4,@p5,@p6)";
                c1.Parameters.AddWithValue("p2", (mins + maxs) / 2);
                number2 += numberofsatr;
                flo1 = (double) numberofsatr / num;
                floe2 += flo1;
                string s = mins + " - " + maxs;
                c1.Parameters.AddWithValue("p1", s);
                c1.Parameters.AddWithValue("p3", numberofsatr);
                c1.Parameters.AddWithValue("p4", number2);
                c1.Parameters.AddWithValue("p5", flo1);
                c1.Parameters.AddWithValue("p6", floe2);
                c1.ExecuteNonQuery();
                flo1 = 0;
                mins += xesatr;
                maxs += xesatr;
                numberofsatr = 0;
                fillgred();
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlCommand c1 = new SqlCommand();
            c1.Connection = conn;
            c1.CommandText = "DELETE FROM tblmath";
            c1.ExecuteNonQuery();
            fillgred();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
