using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra_console
{
    class Loop
    {
        int[,] cb;
        Record rc;
        Regret rg;
        Judge jd;
        Step step;
        Zebra game;
        public void judge()
        {
            while(!jd.isEnd()){
                go();


            }
            quit();
        }
        void quit()
        {
            rc.export();
        }
        void go()
        {
            if (rc.Step >= 3)
            {
                Console.WriteLine("要悔棋吗?0.不1.是");
                int r = Convert.ToInt32(Console.ReadLine());
                rg.isRegret = r == 1 ? true : false;
                if (rg.isRegret == true)
                {
                    rg.regret(cb);
                    game.display();
                }
            }
            //step.judge(game.camp.Human,rc.Step);
            step.judge(game.camp.Human,rc.Step);
            game.display();

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
        }
    }
}
