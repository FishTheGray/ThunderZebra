using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderZebraWinForms
{
    class NegaAlpha : NegaMax
    {
        

        public NegaAlpha(Zebra game)
            : base(game)
        {

        }
        public override void Step()
        {
            int step = game.record.Step;
            //if (step <= 20)
            //{
                alphabeta(1);
            //}
            //else
            //{
            //    alphabeta(2);
            //}

            


            input.insert(put_x, put_y);
            int t = e.getValue(game.chessboard, game.record.Step, put_x, put_y);
            System.Diagnostics.Debug.WriteLine("当前估值{0}",t );
        }
        private void alphabeta(int depth)
        {
            int bestvalue = int.MinValue;
            int value = int.MinValue;
            int step = game.record.Step;
            int con = 1;
            int[,] chessbroad = new int[15, 15];
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    chessbroad[x, y] = game.chessboard[x, y];
                }

            }
            System.Diagnostics.Debug.WriteLine("估值中");
            ////e.getValue(chessbroad, step);

            for (int x = 1; x <= 15; x++)
            {
                for (int y = 1; y <= 15; y++)
                {
                    if (isEmpty(x, y, chessbroad))
                    {
                        chessbroad[x - 1, y - 1] = step % 2 + 1;
                        //value = -alphabeta(depth - 1, x, y, -20000000, 1000000, chessbroad, step + 1);
                        value = -alphabeta(depth - 1, x, y, -int.MaxValue, int.MaxValue, chessbroad, step + 1);
                        //负极大值      负极小值
                        chessbroad[x - 1, y - 1] = 0;

                        //if (game.camp.Human  == game.record.Step%2 + 1)
                        //{
                        //    value = value * 8 / 10;
                        //}
                        //BannedHand hand = new BannedHand(chessbroad);
                        //if (game.record.Step == 0)
                        //{
                        //    if (!hand.isBH(x, y))
                        //    {
                        //        value = -int.MaxValue;
                        //    }
                        //}
                        System.Diagnostics.Debug.WriteLine("{0}/{1}", con, 255 - step + 1);
                        con++;
                        System.Diagnostics.Debug.WriteLine("解析点为({0},{1})", x, y);
                        System.Diagnostics.Debug.WriteLine("{0}", value);

                        if (value > bestvalue)
                        {
                            bestvalue = value;
                            put_x = x;
                            put_y = y;
                        }
                    }
                }
            }
        }
        private int alphabeta(int depth, int position_x, int position_y,int alpha ,int beta, int[,] chessbroad, int step)
        {
            
            int value;
            //fail-soft
            //int current = -int.MaxValue;
            if (depth == 0)
            {
                return e.getValue(chessbroad, step,position_x,position_y);
            }
            for (int x = 1; x <= 15; x++)
            {
                for (int y = 1; y <= 15; y++)
                {
                    if (isEmpty(x, y, chessbroad))
                    {
                        chessbroad[x - 1, y - 1] = step % 2 + 1;
                        value = -alphabeta(depth - 1, x, y, -beta, -alpha,chessbroad, step + 1);
                        chessbroad[x - 1, y - 1] = 0;
                        //if (value > bestvalue)
                        //{
                        //    bestvalue = value;
                        //}
                        if (Math.Abs(value) == int.MaxValue)
                        {
                            return value;
                        }
                        if (value >= alpha)
                        {
                            alpha = value;
                        }
                        if (alpha >= beta)
                        {
                            break;
                        }
                        //if (value > current)
                        //{
                        //    current = value;
                        //    if (value>=alpha)
                        //    {
                        //        alpha = value;
                        //    }
                        //    if (value>=beta)
                        //    {
                        //        break;
                        //    }
                        //}


                    }
                }
            }
            return alpha;
            //return current;





        }



    }    
}
