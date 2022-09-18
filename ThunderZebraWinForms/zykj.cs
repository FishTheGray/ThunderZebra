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
    public partial class zykj : Form
    {
        public initdata c1;
        public Start begin;
        public zykj()
        {
            InitializeComponent();
        }
        public zykj(initdata c1, Start begin)
            :this()
        {
            this.c1 = c1;
            this.begin = begin;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            c1.Human = 2;
            endwin();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            c1.Human = 1;
            endwin();
        }
        private void zdkjstart(object sender, EventArgs e)
        {
            this.begin = (sender as zdkj).begin;
            
        }
        private void cls(object sender, EventArgs e)
        {
            Close();

        }
        private void endwin() 
        {
            
            if (c1.ispoint)
            {
                if (c1.Human == 2)
                {
                    zdkj form3 = new zdkj(c1, begin);
                    form3.FormClosed += zdkjstart;
                    form3.FormClosed += cls;
                    form3.Show();
                    Hide();
                }
                else 
                {
                    begin = new Start(c1.Human, c1.Type, c1.N, c1.Flip, c1.Rote);
                    Close();
                }
                
            }
            else 
            {
                begin = new Start(c1.Human);
                Close();
            }
            
        }
    }
}
