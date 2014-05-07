using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forska
{
    public partial class Form2 : Form
    {
        int god = 0;
        int koef_krony = 2;
        int koef_stvola = 8;
        double Wtot = 0;
        bool volok = false;
        int delta = 0;
        //List<Tree> mass = new List<Tree>(1000);
        Tree[] mass = new Tree[1000];
        double[] SubIntgrFunTopA = new double[2000];
        double[] SubIntgrFunBottA = new double[2000];
        double[] SIntgrFun1 = new double[2000];
        double[] SIntgrFun = new double [500];
        int[,] m;
        int NodesNb = 0;
        int treeCount;
        int Spl = 10 * 10;
        Graphics g;
        
        public Form2()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            comboBox1.SelectedItem = "Сосна";
            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public void draw_tree(int x, int y, double d1, double d2)
        {
            g.FillEllipse((Brushes.Chartreuse), new Rectangle(new Point(x - Convert.ToInt32(d2) / 2, y - Convert.ToInt32(d2) / 2), new Size(Convert.ToInt32(d2), Convert.ToInt32(d2))));
            g.DrawEllipse(new Pen(Brushes.Green, 1), new Rectangle(new Point(x - Convert.ToInt32(d2) / 2, y - Convert.ToInt32(d2) / 2), new Size(Convert.ToInt32(d2), Convert.ToInt32(d2))));
            g.FillEllipse((Brushes.Brown), new Rectangle(new Point(x - Convert.ToInt32(d2) / 2 + Convert.ToInt32(d2) / 2 - Convert.ToInt32(d1) / 2, y - Convert.ToInt32(d2) / 2 + Convert.ToInt32(d2) / 2 - Convert.ToInt32(d1) / 2), new Size(Convert.ToInt32(d1), Convert.ToInt32(d1))));
        }
        public void rost(int colTree)
        {
            volok = false;
            m = new int[colTree, 2];
            Random r = new Random();
            for (int i = 0; i < colTree; i++)
            {
                int x = 0;
                int y = 0;
                bool flag = true;
                x = r.Next(0, 1000);
                y = r.Next(0, 1000);
                for (int k = 0; k <= i; k++)
                {
                    if (x >= (m[k, 0] - mass[k].L * koef_krony) && x <= (m[k, 0] + mass[k].L * koef_krony) && y >= (m[k, 1] - mass[k].L * koef_krony) && y <= (m[k, 1] + mass[k].L * koef_krony))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    m[i, 0] = x;
                    m[i, 1] = y;
                    mass[i].x = x;
                    mass[i].y = y;
                    draw_tree(x, y, mass[i].D * koef_stvola, mass[i].L * koef_krony);
                }
                else i--;
            }
        }

        public bool rostNew(int colTree, int newTree)
        {
            //volok = false;
            m = new int[colTree, 2];
            for (int i = 0; i < colTree - newTree; i++)
            {
                m[i, 0] = mass[i].x;
                m[i, 1] = mass[i].y;
            }
            int buf = 0;
            Random r = new Random();
            for (int i = colTree - newTree; i < colTree; i++)
            {
                int x = 0;
                int y = 0;
                bool flag = true;
                x = r.Next(0, 1000);
                y = r.Next(0, 1000);
                for (int k = 0; k < i; k++)
                {
                    if (x >= (m[k, 0] - mass[k].L * koef_krony) && x <= (m[k, 0] + mass[k].L * koef_krony) && y >= (m[k, 1] - mass[k].L * koef_krony) && y <= (m[k, 1] + mass[k].L * koef_krony))
                    {
                        flag = false;
                        buf++;
                        break;
                    }
                }
                if (buf == 10000)
                {
                    MessageBox.Show("Некуда сажать!");
                    draw_forest(treeCount, volok);
                    return false;

                }
                if (flag)
                {
                    buf = 0;
                    m[i, 0] = x;
                    m[i, 1] = y;
                    mass[i].x = x;
                    mass[i].y = y;
                    //draw_tree(x, y, mass[i].D * 5, mass[i].L * 2);
                }
                else i--;
            }
            for (int i = 0; i < colTree; i++)
            {
                draw_tree(mass[i].x, mass[i].y, mass[i].D * koef_stvola, mass[i].L * koef_krony);
            }
            if (volok)
            {
                g.DrawLine(new Pen(Brushes.Black, 1), 200, 0, 200, pictureBox1.Height);
                g.DrawLine(new Pen(Brushes.Black, 1), 250, 0, 250, pictureBox1.Height);
                g.DrawLine(new Pen(Brushes.Black, 1), 800, 0, 800, pictureBox1.Height);
                g.DrawLine(new Pen(Brushes.Black, 1), 850, 0, 850, pictureBox1.Height);
            }
            return true;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            god = 1;
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Сосна":
                    Graphics g = pictureBox1.CreateGraphics();
                    g.Clear(Color.White);
                    Random r = new Random();
                    treeCount = trackBar1.Value;
                    if (treeCount == 0)
                    {
                        MessageBox.Show("Укажите количество деревьев");
                        return;
                    }
                    for (int i = 0; i < trackBar1.Value; i++)
                    {
                        mass[i] = new Tree();
                        mass[i].Ke = 0.2;
                        mass[i].c = 59;
                        mass[i].alfa = 330;
                        mass[i].teta = 0.025;
                        mass[i].Hmax = 35.1;
                        mass[i].Wmax = 600;
                        mass[i].S = 1.11;
                        mass[i].Cbig = 0.08;
                        mass[i].gamma = 78;
                        mass[i].delta = 0.2;
                        mass[i].psi = 0.004;
                        mass[i].Estroke = 10;
                        mass[i].b_koef = 0.03;
                        mass[i].U0 = 0.0046;
                        mass[i].U1 = 0.46;
                        mass[i].x = r.Next(1000);
                        mass[i].y = r.Next(1000);
                        //textBox2.textBox2.Text += (Convert.ToDouble(r.Next(1000, 2000))/1000).ToString() + "\r\n";
                        mass[i].H = Convert.ToDouble(r.Next(1000, 2000)) / 1000;
                        mass[i].B = 0.6 * mass[i].H;
                        //mass[i].Cbig = r.Next(1000, 5000)/1000;
                        //if(mass[i].H > 1.3)
                        //{
                        //    mass[i].L = 0.1174 - 0.0726*mass[i].H + 0.0446*mass[i].H*mass[i].H;
                        //    mass[i].D = 0.1446 + 0.6497 * mass[i].H + 0.0099 * mass[i].H * mass[i].H;
                        //    mass[i].D2 = Math.Pow(mass[i].D,2);
                        //}
                        //else
                        //{
                        //    mass[i].D = mass[i].H/1.3;
                        //    mass[i].D2 = Math.Pow(mass[i].D,2);
                        //    mass[i].L = mass[i].Cbig*mass[i].D;
                        //}
                        mass[i].D = Convert.ToDouble(r.Next(10, 15)) / 100;
                        mass[i].D2 = Math.Pow(mass[i].D,2);
                        mass[i].L = Convert.ToDouble(r.Next(10,30))/10;
                        mass[i].W = mass[i].b_koef *mass[i].D2 * mass[i].H;
                        mass[i].T = 1;//r.Next(1, 5); 
                        
                    }
                    rost(treeCount);
                    break;
                case null:
                    MessageBox.Show("Выберите породу дерева");break;
            }
            



            
        }
        public double LAI(double z)
        {
            double LAI = 0;
            for(int i = 0; i < treeCount; i++)
            {
                if (z > mass[i].CrownTop && z <= mass[i].CrownBott) LAI += mass[i].Sl * (z - mass[i].CrownTop);
                else if (z > mass[i].CrownBott) LAI += mass[i].L;
            }
            return LAI / Spl;
        }

        public int binom(double P)
        {
            int result = 0;
            Random r = new Random();
            double buf = r.Next(100000000, 1000000000) / 1000000000;
            if (buf < P) result++;
            return result;
        }
        public double PhSynt (double LAI)
        {
            double PhSynt = 0;
            int I0 = 400;
            double Iz = I0 * Math.Exp(-mass[0].Ke * LAI);
            PhSynt = mass[0].Ke * Iz - mass[0].c;
            PhSynt = PhSynt / (PhSynt + mass[0].alfa);
            return PhSynt;
        }

        public double SubIntgrFunA1(double LAI)
        {
            double PhS = PhSynt(LAI);
            double SubIntgrFun1 = mass[0].Sl * mass[0].gamma * PhS;
            return SubIntgrFun1;
        }

        public double SubIntgrFunA2(double z)
        {
            double LAIdx = LAI(z);
            double SubIntgrFun2 = SubIntgrFunA1(LAIdx);
            return SubIntgrFun2;
        }
        public void rubka()
        {
            for(int i = 0; i < treeCount; ++i)
            {
                for(int j = i; j < treeCount;j++)
                {
                    if((mass[j].x < mass[i].x + 30 && mass[j].x > mass[i].x)&&(mass[j].y > mass[i].y - 30 && mass[j].y < mass[i].y))
                    {
                        if(mass[i].W > mass[j].W)
                        {
                            for(int k = j + 1; k < treeCount; k++)
                            {
                                mass[k - 1] = mass[k];
                            }
                            treeCount--;
                        }
                        else
                        {
                            for (int k = i + 1; k < treeCount; k++)
                            {
                                mass[k - 1] = mass[k];
                            }
                            treeCount--;
                        }
                    }
                    if ((mass[j].x < mass[i].x + 30 && mass[j].x > mass[i].x) && (mass[j].y < mass[i].y + 30 && mass[j].y > mass[i].y))
                    {
                        if (mass[i].W > mass[j].W)
                        {
                            for (int k = j + 1; k < treeCount; k++)
                            {
                                mass[k - 1] = mass[k];
                            }
                            treeCount--;
                        }
                        else
                        {
                            for (int k = i + 1; k < treeCount; k++)
                            {
                                mass[k - 1] = mass[k];
                            }
                            treeCount--;
                        }
                    }
                    if ((mass[j].x > mass[i].x - 30 && mass[j].x < mass[i].x) && (mass[j].y > mass[i].y - 30 && mass[j].y < mass[i].y))
                    {
                        if (mass[i].W > mass[j].W)
                        {
                            for (int k = j + 1; k < treeCount; k++)
                            {
                                mass[k - 1] = mass[k];
                            }
                            treeCount--;
                        }
                        else
                        {
                            for (int k = i + 1; k < treeCount; k++)
                            {
                                mass[k - 1] = mass[k];
                            }
                            treeCount--;
                        }
                    }
                    if ((mass[j].x > mass[i].x - 30 && mass[j].x < mass[i].x) && (mass[j].y < mass[i].y + 30 && mass[j].y > mass[i].y))
                    {
                        if (mass[i].W > mass[j].W)
                        {
                            for (int k = j + 1; k < treeCount; k++)
                            {
                                mass[k - 1] = mass[k];
                            }
                            treeCount--;
                        }
                        else
                        {
                            for (int k = i + 1; k < treeCount; k++)
                            {
                                mass[k - 1] = mass[k];
                            }
                            treeCount--;
                        }
                    }
                    if ((mass[j].x == mass[i].x) && ((mass[j].y < mass[i].y + 30 && mass[j].y > mass[i].y) || (mass[j].y > mass[i].y - 30 && mass[j].y < mass[i].y)))
                    {
                        if (mass[i].W > mass[j].W)
                        {
                            for (int k = j + 1; k < treeCount; k++)
                            {
                                mass[k - 1] = mass[k];
                            }
                            treeCount--;
                        }
                        else
                        {
                            for (int k = i + 1; k < treeCount; k++)
                            {
                                mass[k - 1] = mass[k];
                            }
                            treeCount--;
                        }
                    }
                    if (((mass[j].x > mass[i].x - 30 && mass[j].x < mass[i].x) || (mass[j].x < mass[i].x + 30 && mass[j].x > mass[i].x)) && (mass[j].y == mass[i].y))
                    {
                        if (mass[i].W > mass[j].W)
                        {
                            for (int k = j + 1; k < treeCount; k++)
                            {
                                mass[k - 1] = mass[k];
                            }
                            treeCount--;
                        }
                        else
                        {
                            for (int k = i + 1; k < treeCount; k++)
                            {
                                mass[k - 1] = mass[k];
                            }
                            treeCount--;
                        }
                    }
                }
            }
        }

        public bool newTree()
        {
            textBoxResult.Clear();
                int newTree = int.Parse(textBox_newTree.Text);
                treeCount += newTree;
                Array.Resize(ref mass, treeCount);
                textBoxResult.AppendText(treeCount.ToString());
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Сосна":
                        //Graphics g = pictureBox1.CreateGraphics();
                        g.Clear(Color.White);
                        Random r = new Random();
                        for (int i = treeCount - newTree; i < treeCount; i++)
                        {
                            mass[i] = new Tree();
                            mass[i].Ke = 0.2;
                            mass[i].c = 59;
                            mass[i].alfa = 330;
                            mass[i].teta = 0.025;
                            mass[i].Hmax = 35.1;
                            mass[i].Wmax = 600;
                            mass[i].S = 1.11;
                            mass[i].Cbig = 0.08;
                            mass[i].gamma = 78;
                            mass[i].delta = 0.2;
                            mass[i].psi = 0.004;
                            mass[i].Estroke = 10;
                            mass[i].b_koef = 0.03;
                            mass[i].U0 = 0.0046;
                            mass[i].U1 = 0.46;
                            mass[i].x = r.Next(1000);
                            mass[i].y = r.Next(1000);
                            //textBox2.textBox2.Text += (Convert.ToDouble(r.Next(1000, 2000))/1000).ToString() + "\r\n";
                            mass[i].H = Convert.ToDouble(r.Next(1000, 2000)) / 1000;
                            mass[i].B = 0.6 * mass[i].H;
                            //mass[i].Cbig = r.Next(1000, 5000)/1000;
                            //if(mass[i].H > 1.3)
                            //{
                            //    mass[i].L = 0.1174 - 0.0726*mass[i].H + 0.0446*mass[i].H*mass[i].H;
                            //    mass[i].D = 0.1446 + 0.6497 * mass[i].H + 0.0099 * mass[i].H * mass[i].H;
                            //    mass[i].D2 = Math.Pow(mass[i].D,2);
                            //}
                            //else
                            //{
                            //    mass[i].D = mass[i].H/1.3;
                            //    mass[i].D2 = Math.Pow(mass[i].D,2);
                            //    mass[i].L = mass[i].Cbig*mass[i].D;
                            //}
                            mass[i].D = Convert.ToDouble(r.Next(10, 15)) / 100;
                            mass[i].D2 = Math.Pow(mass[i].D, 2);
                            mass[i].L = Convert.ToDouble(r.Next(10, 30)) / 10;
                            mass[i].W = mass[i].b_koef * mass[i].D2 * mass[i].H;
                            mass[i].T = 1;//r.Next(1, 5); 

                        }
                        if (!rostNew(treeCount, newTree)) return false;
                        break;
                    case null:
                        MessageBox.Show("Выберите породу дерева"); break;
                }
                return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                progressBar1.Maximum = trackBar2.Value - 1;
                for (int q = 0; q < trackBar2.Value; q++)
                {
                    god++;
                    progressBar1.Value = q;
                    textBox2.Clear();
                    textBoxResult.Clear();
                    textBox3.Clear();
                    delta++;
                    double MaxCanopyH = 0;
                    double MinCanopyH = double.MaxValue;
                    //treeCount = int.Parse(textBox1.Text);
                    for (int i = 0; i < treeCount; i++)
                    {
                        if (mass[i].H > MaxCanopyH) MaxCanopyH = mass[i].H;
                        if (mass[i].B < MinCanopyH) MinCanopyH = mass[i].B;
                    }
                    textBox2.AppendText("MAX = " + MaxCanopyH + "\r\n");
                    textBox2.AppendText("MIN = " + MinCanopyH + "\r\n");
                    double CanopyLength = MaxCanopyH - MinCanopyH;
                    textBox2.Text += "CanopyLength = " + CanopyLength.ToString() + "\r\n";
                    int MaxNodesNb = 10;
                    double dh_min = 0.2;
                    double dh_ = 0;

                    if (CanopyLength / dh_min > MaxNodesNb) dh_ = CanopyLength / MaxNodesNb;
                    else
                    {
                        dh_ = dh_min;
                    }
                    textBox2.Text += "dh_ = " + dh_.ToString() + "\r\n";
                    NodesNb = Convert.ToInt32(CanopyLength / dh_ + 1) + 1;

                    double[] z = new double[NodesNb + 1];
                    double[] LAI_ = new double[NodesNb + 1];
                    LAI_[0] = 0;
                    z[0] = 0;
                    for (int k = 1; k <= NodesNb; k++)
                    {
                        z[k] = z[k - 1] + dh_;
                        LAI_[k] = 0;
                    }
                    textBox2.AppendText(z[z.Length - 1] + "\r\n");
                    Wtot = 0;
                    for (int i = 0; i < treeCount; i++)
                    {
                        mass[i].Sl = mass[i].L / CanopyLength;
                        mass[i].CrownTop = MaxCanopyH - mass[i].H;
                        mass[i].CrownBott = MaxCanopyH - mass[i].B;
                        mass[i].D2 = Math.Pow(mass[i].D, 2);
                        mass[i].W = mass[i].b_koef * mass[i].D2 * mass[i].H;
                        Wtot += mass[i].W;
                    }
                    for (int i = 0; i < treeCount; i++)
                    {
                        SubIntgrFunTopA[i] = SubIntgrFunA2(mass[i].CrownTop);
                        SubIntgrFunBottA[i] = SubIntgrFunA2(mass[i].CrownBott);
                        int k = 0;
                        //while (z[k] < mass[i].CrownTop && k < z.Length)
                        //{
                        //    k++;
                        //    mass[i].TopNode = k;
                        //}
                        //k = 0;

                        while (z[k] < mass[i].CrownBott && k < z.Length)
                        {
                            LAI_[k] = LAI_[k] + mass[i].Sl * (z[k] - mass[i].CrownTop);
                            k++;

                        }
                        mass[i].BottNode = k - 1;
                        while (k <= NodesNb)
                        {
                            LAI_[k] = LAI_[k] + mass[i].L;
                            k++;
                        }

                    }
                    for (int k = 0; k < NodesNb; k++)
                    {
                        LAI_[k] = LAI_[k] / Spl;
                        SIntgrFun1[k] = SubIntgrFunA1(LAI_[k]);
                    }
                    for (int i = 0; i < treeCount; i++)
                    {
                        double Intgr = 0;
                        if (mass[i].TopNode < mass[i].BottNode)
                        {
                            for (int k = Convert.ToInt32(mass[i].TopNode); k <= mass[i].BottNode; k++)
                            {
                                Intgr += SIntgrFun1[k];
                                Intgr *= dh_;
                                Intgr += SubIntgrFunTopA[i] * (z[Convert.ToInt32(mass[i].TopNode)] - mass[i].CrownTop) / 2;
                                Intgr += SubIntgrFunBottA[i] * (mass[i].CrownBott - z[Convert.ToInt32(mass[i].BottNode)]) / 2;
                            }
                        }
                        else
                        {
                            Intgr = (SubIntgrFunTopA[i] + SubIntgrFunBottA[i]) * (mass[i].CrownBott - mass[i].CrownTop) / 2;
                            //Intgr += mass[i].delta * mass[i].L * (mass[i].CrownBott + mass[i].CrownTop - 2 * mass[i].H) / 2;
                            //Intgr *= (1 - Wtot / mass[i].Wmax);
                        }
                        //Intgr += mass[i].delta * mass[i].L * (mass[i].CrownBott + mass[i].CrownTop - 2 * mass[i].H) / 2;
                        Intgr -= mass[i].delta * mass[i].L * (mass[i].H - mass[i].B) / 2;
                        Intgr *= (1 - Wtot / mass[i].Wmax);
                        //if (Intgr < 0) Intgr = 0;
                        double Erea = Intgr;
                        double Aux1 = (mass[i].Hmax - 1.3) / ((mass[i].Hmax - mass[i].H) * mass[i].S);
                        double Aux2 = Aux1 * 2;
                        Random r = new Random();
                        mass[i].dH = Convert.ToDouble(r.Next(20, 60)) / 100; //Math.Abs(Intgr / (mass[i].D * (mass[i].D + mass[i].H * Aux2)))/50;
                        mass[i].dD = Convert.ToDouble(r.Next(10, 50)) / 1000;//Math.Abs(Intgr / (mass[i].D * (mass[i].H + mass[i].H + mass[i].D / Aux1)))/50;
                        mass[i].dL = Convert.ToDouble(r.Next(20, 40)) / 100;//Math.Abs(mass[i].Cbig * Intgr / (mass[i].H + mass[i].D / Aux2) - mass[i].psi * mass[i].L);
                        if (mass[i].dL > 3) mass[i].dL = 3;
                    }
                    double PhSyntTopCanopy = PhSynt(LAI(0));
                    double PhSyntBottCanopy = PhSynt(LAI(CanopyLength));
                    double kLight = PhSyntBottCanopy / PhSyntTopCanopy;
                    double E = 0.0001;
                    double Xdeath = 0;

                    //for(int i = 0; i < treeCount; i++)
                    //{
                    //    double Erel = mass[i].Erea/(mass[i].gamma * mass[i].L * PhSyntTopCanopy);
                    //    if (Erel >= mass[i].teta + E) Xdeath = mass[i].U0;
                    //    if (Erel > mass[i].teta - E && Erel < mass[i].teta + E) Xdeath = (mass[i].U0 + mass[i].U1) / 2;
                    //    if (Erel <= mass[i].teta - E) Xdeath = mass[i].U1 + mass[i].U0;
                    //    double Pdeath = 1 - Math.Exp(-Xdeath * delta);
                    //    if(binom(Pdeath) == 1)
                    //    {
                    //        for (int k = i; k < treeCount; k++)
                    //        {
                    //            treeCount--;
                    //            mass[k] = mass[k + 1];
                    //        }                     
                    //    }          
                    //}
                    textBox2.Text += "  treeCount : " + treeCount.ToString();
                    for (int i = 0; i < treeCount; i++)
                    {
                        mass[i].H += mass[i].dH;
                        mass[i].D += mass[i].dD;
                        mass[i].L += mass[i].dL;
                        mass[i].T += 1;

                    }
                    Graphics g = pictureBox1.CreateGraphics();
                    g.Clear(Color.White);
                    for (int i = 0; i < treeCount; i++)
                    {
                        //draw_tree(mass[i].x, mass[i].y, mass[i].D, mass[i].L * 3);
                        //textBox3.AppendText(i + "dH = " + mass[i].dH + "\r\n");
                        //textBox3.AppendText(i + "dD = " + mass[i].dD + "\r\n");
                        //textBox3.AppendText(i + "dL = " + mass[i].dL + "\r\n");
                        double Bnew = 0;
                        for (int k = 0; k < NodesNb; k++)
                        {
                            SIntgrFun[k] = SIntgrFun1[k] - mass[0].teta * (mass[k].H - z[k]);
                            if (k > 0 && ((SIntgrFun[k - 1] * SIntgrFun[k]) <= 0))
                            {
                                Bnew = MaxCanopyH - z[k];
                                //textBox4.AppendText("Bnew = " + Bnew.ToString());
                            }
                        }
                        if (mass[i].B < Bnew)
                        {
                            //textBox4.AppendText("B = " + mass[i].B.ToString());
                            mass[i].B = Bnew;
                        }
                    }
                    if(!newTree()) return;
                    if (god % 10 == 0)
                    {
                        rubka();
                        for (int i = 0; i < treeCount; i++)
                        {
                            draw_tree(mass[i].x, mass[i].y, mass[i].D * koef_stvola, mass[i].L * koef_krony);
                        }
                        textBoxResult.AppendText(treeCount.ToString());
                    }
                }
                //for (int i = 0; i < treeCount; i++)
                //{
                //    if (mass[i].L > 100)
                //    {
                //        mass[i].L = mass[i - 1].L;
                //    }
                //    if (mass[i].D > 2)
                //    {
                //        mass[i].D = 1.5;
                //        draw_tree(mass[i].x, mass[i].y, mass[i].D * 5, mass[i].L * 2);
                //    }
                //    else
                //    {
                //        draw_tree(mass[i].x, mass[i].y, mass[i].D * 5, mass[i].L * 2);
                //    }
                //}


                if (volok)
                {
                    g.DrawLine(new Pen(Brushes.Black, 1), 200, 0, 200, pictureBox1.Height);
                    g.DrawLine(new Pen(Brushes.Black, 1), 250, 0, 250, pictureBox1.Height);
                    g.DrawLine(new Pen(Brushes.Black, 1), 800, 0, 800, pictureBox1.Height);
                    g.DrawLine(new Pen(Brushes.Black, 1), 850, 0, 850, pictureBox1.Height);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Укажите количество новых деревьев в год");
                for (int i = 0; i < treeCount; i++)
                {
                    draw_tree(mass[i].x, mass[i].y, mass[i].D * koef_stvola, mass[i].L * koef_krony);
                }
            }
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox4.Text = trackBar2.Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            draw_voloks();
        }
        public void draw_voloks()
        {
            volok = true;
            //g.DrawLine(new Pen(Brushes.Black, 1), 200, 0, 200, pictureBox1.Height);
            //g.DrawLine(new Pen(Brushes.Black, 1), 250, 0, 250, pictureBox1.Height);
            //g.DrawLine(new Pen(Brushes.Black, 1), 800, 0, 800, pictureBox1.Height);
            //g.DrawLine(new Pen(Brushes.Black, 1), 850, 0, 850, pictureBox1.Height);
            for (int i = 0; i < treeCount; i++)
            {
                if (mass[i].x > 195 && mass[i].x < 255 || mass[i].x > 795 && mass[i].x < 855) 
                {
                    for(int j = i + 1; j < treeCount; j++)
                    {
                        mass[j - 1] = mass[j];                      
                        i = 0;
                    }
                    treeCount--;
                }

            }

            textBoxResult.Clear();
            textBoxResult.AppendText(treeCount.ToString());
            g.Clear(Color.White);
            for (int i = 0; i < treeCount; i++)
            {
                if (mass[i].L > 100)
                {
                    mass[i].L = mass[i - 1].L;
                }
                if (mass[i].D > 2)
                {
                    mass[i].D = 1.5;
                    draw_tree(mass[i].x, mass[i].y, mass[i].D * koef_stvola, mass[i].L * koef_krony);
                }
                else
                {
                    draw_tree(mass[i].x, mass[i].y, mass[i].D * koef_stvola, mass[i].L * koef_krony);
                }
            }
            g.DrawLine(new Pen(Brushes.Black, 1), 200, 0, 200, pictureBox1.Height);
            g.DrawLine(new Pen(Brushes.Black, 1), 250, 0, 250, pictureBox1.Height);
            g.DrawLine(new Pen(Brushes.Black, 1), 800, 0, 800, pictureBox1.Height);
            g.DrawLine(new Pen(Brushes.Black, 1), 850, 0, 850, pictureBox1.Height);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxResult.Clear();
            textBoxBioMass.Clear();
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            rubka();
            for (int i = 0; i < treeCount; i++)
            {
                draw_tree(mass[i].x, mass[i].y, mass[i].D * koef_stvola, mass[i].L * koef_krony);
            }
            textBoxBioMass.AppendText(Math.Round(Wtot,3).ToString());
            textBoxResult.AppendText(treeCount.ToString());
            if (volok)
            {
                g.DrawLine(new Pen(Brushes.Black, 1), 200, 0, 200, pictureBox1.Height);
                g.DrawLine(new Pen(Brushes.Black, 1), 250, 0, 250, pictureBox1.Height);
                g.DrawLine(new Pen(Brushes.Black, 1), 800, 0, 800, pictureBox1.Height);
                g.DrawLine(new Pen(Brushes.Black, 1), 850, 0, 850, pictureBox1.Height);
            }
        }
        public void draw_forest(int treeCount, bool volok)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            textBoxResult.Clear();
            textBoxBioMass.Clear();
            for (int i = 0; i < treeCount; i++)
            {
                draw_tree(mass[i].x, mass[i].y, mass[i].D * koef_stvola, mass[i].L * koef_krony);
            }
            textBoxBioMass.AppendText(Math.Round(Wtot, 3).ToString());
            textBoxResult.AppendText(treeCount.ToString());
            if (volok)
            {
                g.DrawLine(new Pen(Brushes.Black, 1), 200, 0, 200, pictureBox1.Height);
                g.DrawLine(new Pen(Brushes.Black, 1), 250, 0, 250, pictureBox1.Height);
                g.DrawLine(new Pen(Brushes.Black, 1), 800, 0, 800, pictureBox1.Height);
                g.DrawLine(new Pen(Brushes.Black, 1), 850, 0, 850, pictureBox1.Height);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int mX = e.X;
            int mY = e.Y;
            for (int i = 0; i < treeCount; i++)
            {
                if ((mass[i].x > mX - 5 && mass[i].x < mX + 5) && (mass[i].y > mY - 5 && mass[i].y < mY + 5))
                {
                    for (int j = i + 1; j < treeCount; j++)
                    {
                        mass[j - 1] = mass[j];
                    }
                    treeCount--;
                }
            }
            draw_forest(treeCount, volok);
        }

    }
}
