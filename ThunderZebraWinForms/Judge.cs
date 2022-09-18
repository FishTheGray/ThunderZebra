using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThunderZebraWinForms
{
    public class Judge
    {
        private Zebra game;
        private int[,] cb;
        private Index idx;
        int end = 0;

        public Judge(Zebra game)
        {
            this.game = game;
            cb = game.chessboard;
            idx = new Index(cb);
        }

        public Boolean isEnd()
        {
            int[] s1 = { 1, 1, 1, 1, 1 };
            int[] s2 = { 2, 2, 2, 2, 2 };
            int sc1, sc2;
            sc1 = idx.shapeCampare(s1);
            sc2 = idx.shapeCampare(s2);
            if (sc1 != 0)
            {
                end = 1;
            }
            if (sc2 != 0)
            {
                end = 2;
            }
            
            if (sc1 + sc2 == 0 && game.input.BH)
            {
                
                return false;
            }

            if (!game.input.BH)
            {
                end = 1;
                Console.WriteLine("此步为禁手,白棋自动获胜");
            }
            //else
            //{
            //    end = 1;
            //}

            show(end);
            return true;
            
        }
        void show(int x)
        {
            string result="";
            switch (x)
            {
                case 1:
                    result = "白棋胜";
                    break;
                case 2:
                    result = "黑棋胜";
                    break;
                case 3:
                    result = "平局";
                    break;
            }
            MessageBox.Show(result,"比赛结束",MessageBoxButtons.OK);
        }
        void restart()
        {
            Console.WriteLine("是否重新开始0.是1.否");
            if(Convert.ToInt32( Console.ReadLine()) == 0)
            {
                //Start start = new Start("T");
            }
            

        }
    }
}
