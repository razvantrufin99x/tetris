using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Threading;
namespace tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int[,] tabla;
        public int counter=-1;
        public int cx = 20;
        public int cy = 20;
        public int w = 1+(500 - 20) / 20;
        public int h = 1+(380 - 30) / 20;
        public List<patrat> p = new List<patrat>();
        public int posx = 4;
        public int posy = 1;
         
        public void printpositiona()
        {
            Text = h.ToString() + " : " + w.ToString();
            Text += " : ";
            Text += posx.ToString() + " : " + posy.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            //testeaza daca virful este ocupat 
                //muta varful y inspre o parte in care nu ai elemente
            p.Add(new patrat());
            counter++;
            p[counter].Top = 20; //posy = 1
            p[counter].Left = 100; //posx = 4
            Controls.Add(p[counter]);
            p[counter].Show();
            tabla = new int[h,w];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    tabla[i, j] = 0;
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            printpositiona();
            if(p[counter].Left < 380-40){
                        if (p[counter].Top < 500 && posy + 1 < w && tabla[posx, posy + 1] == 0)
                        {
                            p[counter].Top += 20;
                            posy++;

                        }
                        else if (p[counter].Top < 500 && posy + 1 < w && tabla[posx - 1, posy + 1] == 0 && posx - 1 > 0 )
                        {
                            p[counter].Top += 20;
                            p[counter].Left -= 20;
                            posy++;
                            posx--;
                        }
                        else if (p[counter].Top < 500 && posy + 1 < w && tabla[posx + 1, posy + 1] == 0  && p[counter].Left < 380-20)
                        {
                            p[counter].Top += 20;
                            p[counter].Left += 20;
                            posy++;
                            posx++;
                        }
                        else
                        {
                            //creaza un nou patrat
                            p.Add(new patrat());
                            counter++;
                            p[counter].Top = 20;
                            p[counter].Left = 100;
                            Controls.Add(p[counter]);
                            p[counter].Show();

                            tabla[posx, posy] = 1;

                            posy = 1;
                            posx = 4;
                            textBox1.Text = "";
                        for (int i = 0; i < h; i++)
                        {
                            for (int j = 0; j < w; j++)
                            {
                               textBox1.Text += tabla[i, j].ToString() + " ";
                            }
                            textBox1.Text += " \r\n ";
                        }
            
            
                        //Thread.Sleep(1);

                        }

                        if ((p[counter].Top >= 500 || posy + 1 == w - 1) && posy + 1 < w && tabla[posx, posy + 1] == 0)
                        {
                              
                            //creaza un nou patrat
                            p.Add(new patrat());
                            counter++;
                            p[counter].Top = 20;
                            p[counter].Left = 100;
                            Controls.Add(p[counter]);
                            p[counter].Show();

                            tabla[posx,posy] = 1;

                            posy = 1;
                            posx = 4;

                            textBox1.Text = "";
                        for (int i = 0; i < h; i++)
                        {
                            for (int j = 0; j < w; j++)
                            {
                               textBox1.Text += tabla[i, j].ToString() + " ";
                            }
                            textBox1.Text += " \r\n ";
                        }
            
                        }
            }
            else
            {
                //creaza un nou patrat
                p.Add(new patrat());
                counter++;
                p[counter].Top = 20;
                p[counter].Left = 100;
                Controls.Add(p[counter]);
                p[counter].Show();

                tabla[posx, posy] = 1;

                posy = 1;
                posx = 4;
                textBox1.Text = "";
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        textBox1.Text += tabla[i, j].ToString() + " ";
                    }
                    textBox1.Text += " \r\n ";
                }


                //Thread.Sleep(1);

            }

            //Thread.Sleep(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (p[counter].Left > 30 &&  posx - 1 >=0 && tabla[posx-1, posy] == 0)
            {
                p[counter].Left -= 20;
                posx--;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (p[counter].Left < 380 && posx + 1 < h && tabla[posx + 1, posy] == 0)
            {
                p[counter].Left += 20;
                posx++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (p[counter].Top < 500 && posy + 1 < w && tabla[posx, posy + 1] == 0)
            {
                p[counter].Top += 20;
                posy++;
            }
        }
    }
}
