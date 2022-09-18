using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThunderZebraWinForms
{
    public class Loop
    {
        int[,] cb;
        public Judge jd;
        public Nda nda;
        Record rc;
        Regret rg;
        Step step;
        Zebra game;
        
        
        public void judge(int position_x,int position_y) 
        {
            if (!jd.isEnd())
            {
                //go(position_x, position_y);
                step.judge(game.camp.Human, rc.Step, position_x, position_y);

            }
            
            
        }
        public void regret()
        {
            if (rc.Step >= 3)
            {

                DialogResult dr = MessageBox.Show("确认悔棋", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    rg.regret(cb);
                }

                
                  
                    
                
            }
            //step.judge(game.camp.Human,rc.Step);
            //step.judge(game.camp.Human,rc.Step,position_x,position_y);
            

        }
        public void pass() 
        {
            game.input.pass();
        }


        public Loop(Zebra game)
        {
            this.game = game;
            rc = game.record;
            cb = game.chessboard;
            rg = new Regret(rc);
            step = new Step(game.input);
            jd = new Judge(game);
        }
        public Loop(Zebra game,ISearch search)
        {
            this.game = game;
            rc = game.record;
            cb = game.chessboard;
            rg = new Regret(rc);
            step = new Step(game.input,search);
            jd = new Judge(game);
            nda = new Nda(game,search);
        }
    }
}
