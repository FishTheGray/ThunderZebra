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
    public partial class dcqp : Form
    {
        int result = 1;
        Zebra game;
        public dcqp()
        {
            InitializeComponent();
        }
        public dcqp(Zebra game) 
            :this()
        {
            this.game = game;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            game.record.export(textBox4.Text,textBox2.Text,textBox5.Text,textBox3.Text,result);
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                result = 0;
            }
            if (radioButton2.Checked)
            {
                result = 1;
            }
            if (radioButton3.Checked)
            {
                result = 2;
            }
        }
    }
}
