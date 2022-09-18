using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ThunderZebraWinForms
{
    public struct initdata
    {
        
        public bool ispoint;
        public int Human;
        public int Type;
        public int N;
        public int Flip;
        public int Rote;
        
    };
    public struct Time
    {
        public byte b;
        public byte w;
        public float t;
        public string s;
    }
    public  struct Ndada
    {
        public int n;//n打n值
        public int i;//循环次数
        public List<int> nda_arr;

    }
    public partial class Form1 : Form
    {

        Start begin;
        public bool started = false;
        List<PictureBox> pictureBoxes;
        List<PictureBox> ndabox;
        
        initdata c1;
        Time t1;
        Ndada n1;
        


        public Form1()
        {
            InitializeComponent();
        }
        //display() is too slow
        private void showLast() {
            int x, y;
            if (begin.game.record.Step>1)
            {
                (x, y) = begin.game.record.getLast();
                if(x!= 0 && y != 0)
                {
                    (x, y) = itrasform(x, y);
                    if (begin.game.record.Step % 2 == 0)
                    {
                        addpoint(x, y, true);
                    }
                    else
                    {
                        addpoint(x, y, false);
                    }
                    showHistory();
                }                
            }   
        }
        private void showHistory() {
            if (pictureBoxes.Count>=1)
            {
                panel1.Controls.Remove(pictureBoxes[pictureBoxes.Count - 1]);
                pictureBoxes[pictureBoxes.Count - 1].BackColor = Color.Blue;
                //pictureBoxes[pictureBoxes.Count - 1].BackgroundImage = global::ThunderZebraWinForms.Properties.Resources.history;
                panel1.Controls.Add(pictureBoxes[pictureBoxes.Count - 1]);
                
            }
            if (pictureBoxes.Count >= 2)
            {
                panel1.Controls.Remove(pictureBoxes[pictureBoxes.Count - 2]);
                pictureBoxes[pictureBoxes.Count - 2].BackColor = Color.Transparent;
                //pictureBoxes[pictureBoxes.Count - 2].BackgroundImage = null;
                panel1.Controls.Add(pictureBoxes[pictureBoxes.Count - 2]);
                
            }

        }
        private void addpoint(int x,int y,bool isblack)
        {
            Bitmap im;
            if (isblack) { 
                im= global::ThunderZebraWinForms.Properties.Resources.黑;
            }
            else
            {
                im = global::ThunderZebraWinForms.Properties.Resources.白;
            }
            pictureBoxes.Add(new PictureBox());
            pictureBoxes[pictureBoxes.Count - 1].BackColor = Color.Transparent;
            pictureBoxes[pictureBoxes.Count - 1].Image = im;
            pictureBoxes[pictureBoxes.Count - 1].Location = new Point(x, y);
            pictureBoxes[pictureBoxes.Count - 1].Size = new Size(27, 27);
            pictureBoxes[pictureBoxes.Count - 1].SizeMode = PictureBoxSizeMode.StretchImage;
            panel1.Controls.Add(pictureBoxes[pictureBoxes.Count - 1]);
        }
        private void nda_addpoint(int x, int y)
        {
            (x, y) = itrasform(x,y);
            Bitmap im = global::ThunderZebraWinForms.Properties.Resources.黑;
            ndabox.Add(new PictureBox());
            ndabox[ndabox.Count - 1].BackColor = Color.Red;
            ndabox[ndabox.Count - 1].Image = im;
            ndabox[ndabox.Count - 1].Location = new Point(x, y);
            ndabox[ndabox.Count - 1].Size = new Size(27, 27);
            ndabox[ndabox.Count - 1].SizeMode = PictureBoxSizeMode.StretchImage;
            ndabox[ndabox.Count - 1].MouseClick += new MouseEventHandler(nda_click);

            panel1.Controls.Add(ndabox[ndabox.Count - 1]);
        }
        private void display() {
            panel1.Controls.Clear();
            int p_x ,p_y;
            for (int y = 14; y >= 0; y--)
            {
                for (int x = 0; x < 15; x++)
                {
                    (p_x, p_y) = itrasform(x + 1, y + 1);

                    if (begin.game.chessboard[x, y] == 1)
                    {
                        
                        addpoint(p_x,p_y,false);
                    }
                    if (begin.game.chessboard[x, y] == 2)
                    {
                        addpoint(p_x, p_y, true);
                    }

                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        private void regret(object sender, EventArgs e)
        {
            if (started)
            {
                begin.l.regret();
                display();
            }

        }
        private void pass(object sender, EventArgs e)
        {
            begin.l.pass();
            begin.l.judge(16, 16);
            showLast();
        }


        private void pointedstart(object sender, EventArgs e)
        {
            
            c1.ispoint = true;
            c1.Human = 0;
            c1.N = 2;
            c1.Rote = 0;
            c1.Flip = 0;
            c1.Type = 0;
            started = false;
            zykj form2 = new zykj(c1,begin);
            form2.FormClosed += zykjstart;
            form2.Show();
        }
        private void freestart(object sender, EventArgs e)
        {
            
            c1.ispoint = false;
            c1.Human = 0;
            c1.N = 2;
            c1.Rote = 0;
            c1.Flip = 0;
            c1.Type = 0;
            started = false;
            zykj form3 = new zykj(c1,begin);
            form3.FormClosed+= zykjstart;
            form3.Show();
        }
        private void zykjstart(object sender, EventArgs e) {
            
            begin=(sender as zykj).begin;
            started = true;

            t1.t = 0;
            t1.w = 0;
            t1.b = 0;
            t1.s = "";

            pictureBoxes = new List<PictureBox>();

            n1.n = begin.game.camp.n;
            n1.i = 0;
            n1.nda_arr = new List<int>();
            ndabox = new List<PictureBox>();

            ////测试数据
            //n1.nda_arr.Add(1);
            //n1.nda_arr.Add(1);
            //n1.nda_arr.Add(1);
            //n1.nda_arr.Add(2);

            timer1.Start();
            showStart();
            display();
            if (c1.ispoint)
            {
                begin.swap();
                
            }
            begin.l.judge(16, 16);//让人工智能走一步
            showLast();
            
            
        }
        
        private void exportrecord(object sender, EventArgs e)
        {
            //if (started) 
            //{
                dcqp form4 = new dcqp(begin.game);
                form4.Show();
            //}
            
        }


        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x, y;
            {
                position.ForeColor = Color.Red;

                position.Text = "e.x=" + e.X + "\ne.y=" + e.Y + "\n";
                (x, y) = trasform(e.X, e.Y);
                position.Text += format(x, y);
                //"x=" + x + "\ny=" + y;
                (x, y) = itrasform(x, y);
                position.Text += "\nix=" + x + "\niy=" + y;
            }
            if (begin!= null)
            {
                if (begin.game.record.Step == 5)
                {
                    nda(e.X, e.Y);
                }
                if (begin.l.jd.isEnd())
                {
                    started = false;
                }
            }
            
            if (started)
            {
                
                (x, y) = trasform(e.X, e.Y);
                for (int i = 0; i < 2; i++)
                {
                    if (begin.game.record.Step != 5)
                    {
                        begin.l.judge(x, y);

                        showLast();
                        sumTime();
                    }
                    
                    
                    
                }


            }
            
        }
        private void nda_click(object sender , MouseEventArgs e) {
            if (begin.game.camp.Human == 1)
            {
                int i = ndabox.IndexOf(sender as PictureBox);// +1;
                //string s = "选择了第" + i + "个元素";
                //position.ForeColor = Color.Blue;
                //position.Text = s;
                begin.l.nda.man_select(i);
                started = true;
                display();
            }
            


        }
        private void nda(int x,int y) {
            
            if (n1.i == 0)
            {
                started = false;
                MessageBox.Show("开始n打", "确认", MessageBoxButtons.OK);

                if (begin.game.camp.Human == 1)
                {
                    //机器生成
                    n1.nda_arr = begin.l.nda.genate();
                    //人类选择
                    for (int j = 0; j < 2 * n1.n; j += 2)
                    {
                        nda_addpoint(n1.nda_arr[j], n1.nda_arr[j + 1]);
                                 
                    }
                    n1.i++;

                }
                    
                    
            }
                


                if (n1.i == n1.n)
                {
                    
                        //机器选择
                    begin.l.nda.select();
                    
                        

                    started = true;
                    display();
                    return;
                }
        if (begin.game.camp.Human == 2)
        {
         //人工输入
                    
            (x, y) = trasform(x,y);
            begin.l.nda.input(x, y);
            n1.nda_arr.Add(x);
            n1.nda_arr.Add(y);
            nda_addpoint(x, y);

            n1.i++;

        }

            
        }
        private void sumTime() {
            if (begin.game.record.Step % 2 == 0)
            {
                t1.b += (byte)t1.t;
                t1.w += 16;
                t1.t = 0;
            }
            else
            {
                t1.w += (byte)t1.t;
                t1.b += 3;
                t1.t = 0;
            }

        } 
        private void time_kick(object sender, EventArgs e) 
        {
            if (started)
            {
                t1.t += (float)0.01;
                t1.s = "黑方:" + t1.b + "\n白方:" + t1.w + "\n当前用时:" + (int)t1.t;
                //t1.s = "总时:" + t1.w  + "\n步时:" + t1.t;
                position.Text = t1.s;

            }
        }
        private (int ,int) trasform(int x ,int y)
        {
            int ix = x - 53;
            int iy = y - 58;
            
            ix =ix / 28+1;
            iy = 15 - iy/32;
            return (ix,iy);
        }
        private (int, int) itrasform(int x, int y) {
            int ix = (int)((float)(x+1)*28.8)-4;
            int iy = (int)((float)(15-y)*31.5)+58;
            
            return (ix, iy);
        }
        private string format(int x,int y)
        {
            x +=64;
            string a = ((char)x ).ToString() +","+y ;
            return a;
        }
        private void showStart() 
        {
            if (started)
            {
                if (c1.ispoint)
                {
                    label1.ForeColor = Color.Yellow;
                    string[] op = { "寒星", "溪月","疏月","花月" ,"残月","雨月" ,"金星" ,"松月" ,"丘月" ,"新月","瑞星","山月","游星",
                        "长星","峡月","恒星","水月","流星","云月","浦月","岚月","银月","明星","斜月","名月","彗星"};
                    label1.Text = op[begin.ty - 1] + "局";

                }
            }
        }
        
    }
}
