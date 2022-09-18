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
    public partial class zdkj : Form
    {
        initdata c1;
        public Start begin;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            c1.N = Convert.ToInt32((sender as TextBox).Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = (sender as CheckBox).Checked;
            c1.Flip = check ? 1 : 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked )
            {
                c1.Rote = 1;
            }
            if (radioButton4.Checked)
            {
                c1.Rote = 2;
            }
            if (radioButton5.Checked)
            {
                c1.Rote = 3;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            c1.Type = (sender as ComboBox).SelectedIndex + 1;
        }

        public zdkj()
        {
            InitializeComponent();
        }
        public zdkj(initdata c1 , Start begin)
            :this()
        {
            this.c1 = c1;
            this.begin = begin;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            begin = new Start(c1.Human,c1.Type,c1.N,c1.Flip,c1.Rote);
            Close();
        }
    }
}
